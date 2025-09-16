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
    public class PosDebitorItemController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosDebitorItemController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosDebitorItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosDebitorItem>>> GetPosDebitorItem()
        {
            return await _context.PosDebitorItem.ToListAsync();
        }

        // GET: api/PosDebitorItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosDebitorItem>> GetPosDebitorItem(long id)
        {
            var posDebitorItem = await _context.PosDebitorItem.FindAsync(id);

            if (posDebitorItem == null)
            {
                return NotFound();
            }

            return posDebitorItem;
        }

        // PUT: api/PosDebitorItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosDebitorItem(long id, PosDebitorItem posDebitorItem)
        {
            if (id != posDebitorItem.id)
            {
                return BadRequest();
            }

            _context.Entry(posDebitorItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosDebitorItemExists(id))
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

        // POST: api/PosDebitorItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosDebitorItem>> PostPosDebitorItem(PosDebitorItem posDebitorItem)
        {
            _context.PosDebitorItem.Update(posDebitorItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosDebitorItem", new { id = posDebitorItem.id }, posDebitorItem);
        }

        // DELETE: api/PosDebitorItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosDebitorItem>> DeletePosDebitorItem(long id)
        {
            var posDebitorItem = await _context.PosDebitorItem.FindAsync(id);
            if (posDebitorItem == null)
            {
                return NotFound();
            }

            _context.PosDebitorItem.Remove(posDebitorItem);
            await _context.SaveChangesAsync();

            return posDebitorItem;
        }

        private bool PosDebitorItemExists(long id)
        {
            return _context.PosDebitorItem.Any(e => e.id == id);
        }
    }
}
