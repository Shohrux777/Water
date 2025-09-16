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
    public class WaterContragentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public WaterContragentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/WaterContragents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterContragent>>> GetWaterContragent()
        {
            return await _context.WaterContragent.ToListAsync();
        }

        // GET: api/WaterContragents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterContragent>> GetWaterContragent(long id)
        {
            var waterContragent = await _context.WaterContragent.FindAsync(id);

            if (waterContragent == null)
            {
                return NotFound();
            }

            return waterContragent;
        }

        // PUT: api/WaterContragents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterContragent(long id, WaterContragent waterContragent)
        {
            if (id != waterContragent.id)
            {
                return BadRequest();
            }

            _context.Entry(waterContragent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterContragentExists(id))
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

        // POST: api/WaterContragents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WaterContragent>> PostWaterContragent(WaterContragent waterContragent)
        {
            _context.WaterContragent.Update(waterContragent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaterContragent", new { id = waterContragent.id }, waterContragent);
        }

        // DELETE: api/WaterContragents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WaterContragent>> DeleteWaterContragent(long id)
        {
            var waterContragent = await _context.WaterContragent.FindAsync(id);
            if (waterContragent == null)
            {
                return NotFound();
            }

            _context.WaterContragent.Remove(waterContragent);
            await _context.SaveChangesAsync();

            return waterContragent;
        }

        private bool WaterContragentExists(long id)
        {
            return _context.WaterContragent.Any(e => e.id == id);
        }
    }
}
