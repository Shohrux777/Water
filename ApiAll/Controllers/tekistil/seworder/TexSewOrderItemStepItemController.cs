using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil.seworder;

namespace ApiAll.Controllers.tekistil.seworder
{

    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexSewOrderItemStepItemController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexSewOrderItemStepItemController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexSewOrderItemStepItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexSewOrderItemStepItem>>> GetTexSewOrderItemStepItem()
        {
            return await _context.TexSewOrderItemStepItem.ToListAsync();
        }

        // GET: api/TexSewOrderItemStepItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexSewOrderItemStepItem>> GetTexSewOrderItemStepItem(long id)
        {
            var texSewOrderItemStepItem = await _context.TexSewOrderItemStepItem.FindAsync(id);

            if (texSewOrderItemStepItem == null)
            {
                return NotFound();
            }

            return texSewOrderItemStepItem;
        }

        // PUT: api/TexSewOrderItemStepItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexSewOrderItemStepItem(long id, TexSewOrderItemStepItem texSewOrderItemStepItem)
        {
            if (id != texSewOrderItemStepItem.id)
            {
                return BadRequest();
            }

            _context.Entry(texSewOrderItemStepItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexSewOrderItemStepItemExists(id))
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

        // POST: api/TexSewOrderItemStepItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexSewOrderItemStepItem>> PostTexSewOrderItemStepItem(TexSewOrderItemStepItem texSewOrderItemStepItem)
        {
            _context.TexSewOrderItemStepItem.Update(texSewOrderItemStepItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexSewOrderItemStepItem", new { id = texSewOrderItemStepItem.id }, texSewOrderItemStepItem);
        }

        // DELETE: api/TexSewOrderItemStepItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexSewOrderItemStepItem>> DeleteTexSewOrderItemStepItem(long id)
        {
            var texSewOrderItemStepItem = await _context.TexSewOrderItemStepItem.FindAsync(id);
            if (texSewOrderItemStepItem == null)
            {
                return NotFound();
            }

            _context.TexSewOrderItemStepItem.Remove(texSewOrderItemStepItem);
            await _context.SaveChangesAsync();

            return texSewOrderItemStepItem;
        }

        private bool TexSewOrderItemStepItemExists(long id)
        {
            return _context.TexSewOrderItemStepItem.Any(e => e.id == id);
        }
    }
}
