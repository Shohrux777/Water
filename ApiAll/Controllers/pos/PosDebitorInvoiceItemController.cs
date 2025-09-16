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
    public class PosDebitorInvoiceItemController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosDebitorInvoiceItemController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosDebitorInvoiceItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosDebitorInvoiceItem>>> GetPosDebitorInvoiceItem()
        {
            return await _context.PosDebitorInvoiceItem.ToListAsync();
        }

        // GET: api/PosDebitorInvoiceItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosDebitorInvoiceItem>> GetPosDebitorInvoiceItem(long id)
        {
            var posDebitorInvoiceItem = await _context.PosDebitorInvoiceItem.FindAsync(id);

            if (posDebitorInvoiceItem == null)
            {
                return NotFound();
            }

            return posDebitorInvoiceItem;
        }

        // PUT: api/PosDebitorInvoiceItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosDebitorInvoiceItem(long id, PosDebitorInvoiceItem posDebitorInvoiceItem)
        {
            if (id != posDebitorInvoiceItem.id)
            {
                return BadRequest();
            }

            _context.Entry(posDebitorInvoiceItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosDebitorInvoiceItemExists(id))
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

        // POST: api/PosDebitorInvoiceItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosDebitorInvoiceItem>> PostPosDebitorInvoiceItem(PosDebitorInvoiceItem posDebitorInvoiceItem)
        {
            _context.PosDebitorInvoiceItem.Update(posDebitorInvoiceItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosDebitorInvoiceItem", new { id = posDebitorInvoiceItem.id }, posDebitorInvoiceItem);
        }

        // DELETE: api/PosDebitorInvoiceItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosDebitorInvoiceItem>> DeletePosDebitorInvoiceItem(long id)
        {
            var posDebitorInvoiceItem = await _context.PosDebitorInvoiceItem.FindAsync(id);
            if (posDebitorInvoiceItem == null)
            {
                return NotFound();
            }

            _context.PosDebitorInvoiceItem.Remove(posDebitorInvoiceItem);
            await _context.SaveChangesAsync();

            return posDebitorInvoiceItem;
        }

        private bool PosDebitorInvoiceItemExists(long id)
        {
            return _context.PosDebitorInvoiceItem.Any(e => e.id == id);
        }
    }
}
