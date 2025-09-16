using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.pos;

namespace ApiAll.Controllers.pos
{
    [ApiExplorerSettings(GroupName = "v5")]
    [Route("api/[controller]")]
    [ApiController]
    public class PosRecipesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosRecipesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosRecipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosRecipe>>> GetPosRecipe()
        {
            return await _context.PosRecipe.ToListAsync();
        }

        // GET: api/PosRecipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosRecipe>> GetPosRecipe(long id)
        {
            var posRecipe = await _context.PosRecipe.FindAsync(id);

            if (posRecipe == null)
            {
                return NotFound();
            }

            return posRecipe;
        }

        // PUT: api/PosRecipes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosRecipe(long id, PosRecipe posRecipe)
        {
            if (id != posRecipe.id)
            {
                return BadRequest();
            }

            _context.Entry(posRecipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosRecipeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PosRecipes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosRecipe>> PostPosRecipe(PosRecipe posRecipe)
        {
            _context.PosRecipe.Update(posRecipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosRecipe", new { id = posRecipe.id }, posRecipe);
        }

        // DELETE: api/PosRecipes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosRecipe>> DeletePosRecipe(long id)
        {
            var posRecipe = await _context.PosRecipe.FindAsync(id);
            if (posRecipe == null)
            {
                return NotFound();
            }

            _context.PosRecipe.Remove(posRecipe);
            await _context.SaveChangesAsync();

            return posRecipe;
        }

        private bool PosRecipeExists(long id)
        {
            return _context.PosRecipe.Any(e => e.id == id);
        }
    }
}
