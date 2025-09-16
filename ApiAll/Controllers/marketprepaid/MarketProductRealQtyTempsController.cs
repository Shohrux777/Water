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
    public class MarketProductRealQtyTempsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketProductRealQtyTempsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketProductRealQtyTemps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketProductRealQtyTemp>>> GetMarketProductRealQtyTemp()
        {
            return await _context.MarketProductRealQtyTemp.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/MarketProductRealQtyTemps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketProductRealQtyTemp>> GetMarketProductRealQtyTemp(long id)
        {
            var marketProductRealQtyTemp = await _context.MarketProductRealQtyTemp.FindAsync(id);

            if (marketProductRealQtyTemp == null)
            {
                return NotFound();
            }

            return marketProductRealQtyTemp;
        }

        // PUT: api/MarketProductRealQtyTemps/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketProductRealQtyTemp(long id, MarketProductRealQtyTemp marketProductRealQtyTemp)
        {
            if (id != marketProductRealQtyTemp.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketProductRealQtyTemp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketProductRealQtyTempExists(id))
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

        // POST: api/MarketProductRealQtyTemps
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketProductRealQtyTemp>> PostMarketProductRealQtyTemp(MarketProductRealQtyTemp marketProductRealQtyTemp)
        {
            _context.MarketProductRealQtyTemp.Add(marketProductRealQtyTemp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketProductRealQtyTemp", new { id = marketProductRealQtyTemp.Id }, marketProductRealQtyTemp);
        }

        // DELETE: api/MarketProductRealQtyTemps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketProductRealQtyTemp>> DeleteMarketProductRealQtyTemp(long id)
        {
            var marketProductRealQtyTemp = await _context.MarketProductRealQtyTemp.FindAsync(id);
            if (marketProductRealQtyTemp == null)
            {
                return NotFound();
            }

            _context.MarketProductRealQtyTemp.Remove(marketProductRealQtyTemp);
            await _context.SaveChangesAsync();

            return marketProductRealQtyTemp;
        }

        private bool MarketProductRealQtyTempExists(long id)
        {
            return _context.MarketProductRealQtyTemp.Any(e => e.Id == id);
        }
    }
}
