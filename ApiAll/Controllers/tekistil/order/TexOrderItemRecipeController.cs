using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;

namespace ApiAll.Controllers.tekistil.order
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexOrderItemRecipeController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexOrderItemRecipeController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexOrderItemRecipe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexOrderItemRecipe>>> GetTexOrderItemRecipe()
        {
            return await _context.TexOrderItemRecipe.ToListAsync();
        }

        // GET: api/TexOrderItemRecipe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexOrderItemRecipe>> GetTexOrderItemRecipe(long id)
        {
            var texOrderItemRecipe = await _context.TexOrderItemRecipe.FindAsync(id);

            if (texOrderItemRecipe == null)
            {
                return NotFound();
            }

            return texOrderItemRecipe;
        }

        // PUT: api/TexOrderItemRecipe/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexOrderItemRecipe(long id, TexOrderItemRecipe texOrderItemRecipe)
        {
            if (id != texOrderItemRecipe.id)
            {
                return BadRequest();
            }

            _context.Entry(texOrderItemRecipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexOrderItemRecipeExists(id))
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

        // POST: api/TexOrderItemRecipe
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexOrderItemRecipe>> PostTexOrderItemRecipe(TexOrderItemRecipe texOrderItemRecipe)
        {
            _context.TexOrderItemRecipe.Update(texOrderItemRecipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexOrderItemRecipe", new { id = texOrderItemRecipe.id }, texOrderItemRecipe);
        }

        // DELETE: api/TexOrderItemRecipe/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexOrderItemRecipe>> DeleteTexOrderItemRecipe(long id)
        {
            var texOrderItemRecipe = await _context.TexOrderItemRecipe.FindAsync(id);
            if (texOrderItemRecipe == null)
            {
                return NotFound();
            }

            _context.TexOrderItemRecipe.Remove(texOrderItemRecipe);
            await _context.SaveChangesAsync();

            return texOrderItemRecipe;
        }

        private bool TexOrderItemRecipeExists(long id)
        {
            return _context.TexOrderItemRecipe.Any(e => e.id == id);
        }
    }
}
