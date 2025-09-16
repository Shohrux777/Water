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
    public class MarketAuthLimitByProductsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketAuthLimitByProductsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketAuthLimitByProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketAuthLimitByProduct>>> GetMarketAuthLimitByProduct()
        {
            return await _context.MarketAuthLimitByProduct.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/MarketAuthLimitByProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketAuthLimitByProduct>> GetMarketAuthLimitByProduct(long id)
        {
            var marketAuthLimitByProduct = await _context.MarketAuthLimitByProduct.FindAsync(id);

            if (marketAuthLimitByProduct == null)
            {
                return NotFound();
            }

            return marketAuthLimitByProduct;
        }

        // PUT: api/MarketAuthLimitByProducts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketAuthLimitByProduct(long id, MarketAuthLimitByProduct marketAuthLimitByProduct)
        {
            if (id != marketAuthLimitByProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketAuthLimitByProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketAuthLimitByProductExists(id))
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

        // POST: api/MarketAuthLimitByProducts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketAuthLimitByProduct>> PostMarketAuthLimitByProduct(MarketAuthLimitByProduct marketAuthLimitByProduct)
        {
            _context.MarketAuthLimitByProduct.Add(marketAuthLimitByProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketAuthLimitByProduct", new { id = marketAuthLimitByProduct.Id }, marketAuthLimitByProduct);
        }

        // DELETE: api/MarketAuthLimitByProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketAuthLimitByProduct>> DeleteMarketAuthLimitByProduct(long id)
        {
            var marketAuthLimitByProduct = await _context.MarketAuthLimitByProduct.FindAsync(id);
            if (marketAuthLimitByProduct == null)
            {
                return NotFound();
            }

            _context.MarketAuthLimitByProduct.Remove(marketAuthLimitByProduct);
            await _context.SaveChangesAsync();

            return marketAuthLimitByProduct;
        }

        private bool MarketAuthLimitByProductExists(long id)
        {
            return _context.MarketAuthLimitByProduct.Any(e => e.Id == id);
        }
    }
}
