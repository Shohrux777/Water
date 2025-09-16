using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.water;

namespace ApiAll.Controllers.water
{
    [ApiExplorerSettings(GroupName = "v9")]
    [Route("api/[controller]")]
    [ApiController]
    public class WaterInvoiceItemsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public WaterInvoiceItemsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/WaterInvoiceItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterInvoiceItem>>> GetWaterInvoiceItem()
        {
            return await _context.WaterInvoiceItem.ToListAsync();
        }

        // GET: api/WaterInvoiceItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterInvoiceItem>> GetWaterInvoiceItem(long id)
        {
            var waterInvoiceItem = await _context.WaterInvoiceItem.FindAsync(id);

            if (waterInvoiceItem == null)
            {
                return NotFound();
            }

            return waterInvoiceItem;
        }

        // PUT: api/WaterInvoiceItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterInvoiceItem(long id, WaterInvoiceItem waterInvoiceItem)
        {
            if (id != waterInvoiceItem.id)
            {
                return BadRequest();
            }

            _context.Entry(waterInvoiceItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterInvoiceItemExists(id))
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

        // POST: api/WaterInvoiceItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WaterInvoiceItem>> PostWaterInvoiceItem(WaterInvoiceItem waterInvoiceItem)
        {
            _context.WaterInvoiceItem.Update(waterInvoiceItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaterInvoiceItem", new { id = waterInvoiceItem.id }, waterInvoiceItem);
        }

        // DELETE: api/WaterInvoiceItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WaterInvoiceItem>> DeleteWaterInvoiceItem(long id)
        {
            var waterInvoiceItem = await _context.WaterInvoiceItem.FindAsync(id);
            if (waterInvoiceItem == null)
            {
                return NotFound();
            }

            _context.WaterInvoiceItem.Remove(waterInvoiceItem);
            await _context.SaveChangesAsync();

            return waterInvoiceItem;
        }

        private bool WaterInvoiceItemExists(long id)
        {
            return _context.WaterInvoiceItem.Any(e => e.id == id);
        }
    }
}
