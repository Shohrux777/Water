using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.market;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class MarketUnitMeasurmentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketUnitMeasurmentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketUnitMeasurments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketUnitMeasurment>>> GetMarketUnitMeasurment()
        {
            return await _context.MarketUnitMeasurment.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/MarketUnitMeasurments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketUnitMeasurment>> GetMarketUnitMeasurment(long id)
        {
            var marketUnitMeasurment = await _context.MarketUnitMeasurment.FindAsync(id);

            if (marketUnitMeasurment == null)
            {
                return NotFound();
            }

            return marketUnitMeasurment;
        }

        // PUT: api/MarketUnitMeasurments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketUnitMeasurment(long id, MarketUnitMeasurment marketUnitMeasurment)
        {
            if (id != marketUnitMeasurment.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketUnitMeasurment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketUnitMeasurmentExists(id))
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

        // POST: api/MarketUnitMeasurments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketUnitMeasurment>> PostMarketUnitMeasurment(MarketUnitMeasurment marketUnitMeasurment)
        {
            _context.MarketUnitMeasurment.Add(marketUnitMeasurment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketUnitMeasurment", new { id = marketUnitMeasurment.Id }, marketUnitMeasurment);
        }

        // DELETE: api/MarketUnitMeasurments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketUnitMeasurment>> DeleteMarketUnitMeasurment(long id)
        {
            var marketUnitMeasurment = await _context.MarketUnitMeasurment.FindAsync(id);
            if (marketUnitMeasurment == null)
            {
                return NotFound();
            }

            _context.MarketUnitMeasurment.Remove(marketUnitMeasurment);
            await _context.SaveChangesAsync();

            return marketUnitMeasurment;
        }

        private bool MarketUnitMeasurmentExists(long id)
        {
            return _context.MarketUnitMeasurment.Any(e => e.Id == id);
        }
    }
}
