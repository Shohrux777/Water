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
    public class TexOrderItemRecipeReserveController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexOrderItemRecipeReserveController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexOrderItemRecipeReserve
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexOrderItemRecipeReserve>>> GetTexOrderItemRecipeReserve()
        {
            return await _context.TexOrderItemRecipeReserve.ToListAsync();
        }

        // GET: api/TexOrderItemRecipeReserve/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexOrderItemRecipeReserve>> GetTexOrderItemRecipeReserve(long id)
        {
            var texOrderItemRecipeReserve = await _context.TexOrderItemRecipeReserve.FindAsync(id);

            if (texOrderItemRecipeReserve == null)
            {
                return NotFound();
            }

            return texOrderItemRecipeReserve;
        }

        // PUT: api/TexOrderItemRecipeReserve/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexOrderItemRecipeReserve(long id, TexOrderItemRecipeReserve texOrderItemRecipeReserve)
        {
            if (id != texOrderItemRecipeReserve.id)
            {
                return BadRequest();
            }

            _context.Entry(texOrderItemRecipeReserve).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexOrderItemRecipeReserveExists(id))
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

        // POST: api/TexOrderItemRecipeReserve
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexOrderItemRecipeReserve>> PostTexOrderItemRecipeReserve(TexOrderItemRecipeReserve texOrderItemRecipeReserve)
        {
            _context.TexOrderItemRecipeReserve.Update(texOrderItemRecipeReserve);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexOrderItemRecipeReserve", new { id = texOrderItemRecipeReserve.id }, texOrderItemRecipeReserve);
        }

        // DELETE: api/TexOrderItemRecipeReserve/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexOrderItemRecipeReserve>> DeleteTexOrderItemRecipeReserve(long id)
        {
            var texOrderItemRecipeReserve = await _context.TexOrderItemRecipeReserve.FindAsync(id);
            if (texOrderItemRecipeReserve == null)
            {
                return NotFound();
            }

            _context.TexOrderItemRecipeReserve.Remove(texOrderItemRecipeReserve);
            await _context.SaveChangesAsync();

            return texOrderItemRecipeReserve;
        }

        private bool TexOrderItemRecipeReserveExists(long id)
        {
            return _context.TexOrderItemRecipeReserve.Any(e => e.id == id);
        }
    }
}
