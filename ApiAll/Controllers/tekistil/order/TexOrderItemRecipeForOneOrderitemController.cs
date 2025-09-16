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
    public class TexOrderItemRecipeForOneOrderitemController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexOrderItemRecipeForOneOrderitemController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexOrderItemRecipeForOneOrderitem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexOrderItemRecipeForOneOrderitem>>> GetTexOrderItemRecipeForOneOrderitem()
        {
            return await _context.TexOrderItemRecipeForOneOrderitem.ToListAsync();
        }

        // GET: api/TexOrderItemRecipeForOneOrderitem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexOrderItemRecipeForOneOrderitem>> GetTexOrderItemRecipeForOneOrderitem(long id)
        {
            var texOrderItemRecipeForOneOrderitem = await _context.TexOrderItemRecipeForOneOrderitem.FindAsync(id);

            if (texOrderItemRecipeForOneOrderitem == null)
            {
                return NotFound();
            }

            return texOrderItemRecipeForOneOrderitem;
        }

        // PUT: api/TexOrderItemRecipeForOneOrderitem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexOrderItemRecipeForOneOrderitem(long id, TexOrderItemRecipeForOneOrderitem texOrderItemRecipeForOneOrderitem)
        {
            if (id != texOrderItemRecipeForOneOrderitem.id)
            {
                return BadRequest();
            }

            _context.Entry(texOrderItemRecipeForOneOrderitem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexOrderItemRecipeForOneOrderitemExists(id))
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

        // POST: api/TexOrderItemRecipeForOneOrderitem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexOrderItemRecipeForOneOrderitem>> PostTexOrderItemRecipeForOneOrderitem(TexOrderItemRecipeForOneOrderitem texOrderItemRecipeForOneOrderitem)
        {
            _context.TexOrderItemRecipeForOneOrderitem.Update(texOrderItemRecipeForOneOrderitem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexOrderItemRecipeForOneOrderitem", new { id = texOrderItemRecipeForOneOrderitem.id }, texOrderItemRecipeForOneOrderitem);
        }

        // DELETE: api/TexOrderItemRecipeForOneOrderitem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexOrderItemRecipeForOneOrderitem>> DeleteTexOrderItemRecipeForOneOrderitem(long id)
        {
            var texOrderItemRecipeForOneOrderitem = await _context.TexOrderItemRecipeForOneOrderitem.FindAsync(id);
            if (texOrderItemRecipeForOneOrderitem == null)
            {
                return NotFound();
            }

            _context.TexOrderItemRecipeForOneOrderitem.Remove(texOrderItemRecipeForOneOrderitem);
            await _context.SaveChangesAsync();

            return texOrderItemRecipeForOneOrderitem;
        }

        private bool TexOrderItemRecipeForOneOrderitemExists(long id)
        {
            return _context.TexOrderItemRecipeForOneOrderitem.Any(e => e.id == id);
        }
    }
}
