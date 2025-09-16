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
    public class MarketProductRealQtiesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketProductRealQtiesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketProductRealQties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketProductRealQty>>> GetMarketProductRealQty()
        {
            return await _context.MarketProductRealQty.Include( p => p.product).OrderByDescending(p => p.Id).ToListAsync();
        }

        [HttpGet("getMinLimitLeftProducts")]
        public async Task<ActionResult<IEnumerable<MarketProductRealQty>>> getMinLimitLeftProducts()
        {
            List<MarketProductRealQty> marketProductRealQtiesList = await _context.MarketProductRealQty.Include(p => p.product).OrderByDescending(p => p.Id).ToListAsync();
            if (marketProductRealQtiesList != null && marketProductRealQtiesList.Count > 0)
            {
                List<MarketProductRealQty> limitedProductQty = new List<MarketProductRealQty>();
                foreach (MarketProductRealQty item in marketProductRealQtiesList) {
                    if (item.minValue != null) {
                        if (item.realQty <= item.minValue || item.qty <= item.minValue) {
                            limitedProductQty.Add(item);
                        }
                    }
                }

                return limitedProductQty;
            }
            else {
                return new  List<MarketProductRealQty>();
            }
           
        }

        // GET: api/MarketProductRealQties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketProductRealQty>> GetMarketProductRealQty(long id)
        {
            var marketProductRealQty = await _context.MarketProductRealQty.FindAsync(id);

            if (marketProductRealQty == null)
            {
                return NotFound();
            }

            return marketProductRealQty;
        }

        // PUT: api/MarketProductRealQties/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketProductRealQty(long id, MarketProductRealQty marketProductRealQty)
        {
            if (id != marketProductRealQty.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketProductRealQty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketProductRealQtyExists(id))
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

        // POST: api/MarketProductRealQties
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketProductRealQty>> PostMarketProductRealQty(MarketProductRealQty marketProductRealQty)
        {
            _context.MarketProductRealQty.Update(marketProductRealQty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketProductRealQty", new { id = marketProductRealQty.Id }, marketProductRealQty);
        }

        // DELETE: api/MarketProductRealQties/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketProductRealQty>> DeleteMarketProductRealQty(long id)
        {
            var marketProductRealQty = await _context.MarketProductRealQty.FindAsync(id);
            if (marketProductRealQty == null)
            {
                return NotFound();
            }

            _context.MarketProductRealQty.Remove(marketProductRealQty);
            await _context.SaveChangesAsync();

            return marketProductRealQty;
        }

        private bool MarketProductRealQtyExists(long id)
        {
            return _context.MarketProductRealQty.Any(e => e.Id == id);
        }
    }
}
