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
    public class MarketProductPricesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketProductPricesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketProductPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketProductPrice>>> GetMarketProductPrice()
        {
            return await _context.MarketProductPrice.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/MarketProductPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketProductPrice>> GetMarketProductPrice(long id)
        {
            var marketProductPrice = await _context.MarketProductPrice.FindAsync(id);

            if (marketProductPrice == null)
            {
                return NotFound();
            }

            return marketProductPrice;
        }

        // PUT: api/MarketProductPrices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketProductPrice(long id, MarketProductPrice marketProductPrice)
        {
            if (id != marketProductPrice.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketProductPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketProductPriceExists(id))
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

        // POST: api/MarketProductPrices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketProductPrice>> PostMarketProductPrice(MarketProductPrice marketProductPrice)
        {
            _context.MarketProductPrice.Add(marketProductPrice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketProductPrice", new { id = marketProductPrice.Id }, marketProductPrice);
        }

        // DELETE: api/MarketProductPrices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketProductPrice>> DeleteMarketProductPrice(long id)
        {
            var marketProductPrice = await _context.MarketProductPrice.FindAsync(id);
            if (marketProductPrice == null)
            {
                return NotFound();
            }

            _context.MarketProductPrice.Remove(marketProductPrice);
            await _context.SaveChangesAsync();

            return marketProductPrice;
        }

        private bool MarketProductPriceExists(long id)
        {
            return _context.MarketProductPrice.Any(e => e.Id == id);
        }
    }
}
