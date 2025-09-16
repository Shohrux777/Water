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
    public class WaterInvoicesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public WaterInvoicesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/WaterInvoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterInvoice>>> GetWaterInvoice()
        {
            return await _context.WaterInvoice.ToListAsync();
        }

        // GET: api/WaterInvoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterInvoice>> GetWaterInvoice(long id)
        {
            var waterInvoice = await _context.WaterInvoice.FindAsync(id);

            if (waterInvoice == null)
            {
                return NotFound();
            }

            return waterInvoice;
        }

        // PUT: api/WaterInvoices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterInvoice(long id, WaterInvoice waterInvoice)
        {
            if (id != waterInvoice.id)
            {
                return BadRequest();
            }

            _context.Entry(waterInvoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterInvoiceExists(id))
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

        // POST: api/WaterInvoices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WaterInvoice>> PostWaterInvoice(WaterInvoice waterInvoice)
        {
            _context.WaterInvoice.Update(waterInvoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaterInvoice", new { id = waterInvoice.id }, waterInvoice);
        }

        // DELETE: api/WaterInvoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WaterInvoice>> DeleteWaterInvoice(long id)
        {
            var waterInvoice = await _context.WaterInvoice.FindAsync(id);
            if (waterInvoice == null)
            {
                return NotFound();
            }

            _context.WaterInvoice.Remove(waterInvoice);
            await _context.SaveChangesAsync();

            return waterInvoice;
        }

        private bool WaterInvoiceExists(long id)
        {
            return _context.WaterInvoice.Any(e => e.id == id);
        }
    }
}
