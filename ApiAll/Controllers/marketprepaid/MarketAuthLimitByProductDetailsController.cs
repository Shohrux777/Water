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
    public class MarketAuthLimitByProductDetailsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketAuthLimitByProductDetailsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketAuthLimitByProductDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketAuthLimitByProductDetail>>> GetMarketAuthLimitByProductDetail()
        {
            return await _context.MarketAuthLimitByProductDetail.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/MarketAuthLimitByProductDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketAuthLimitByProductDetail>> GetMarketAuthLimitByProductDetail(long id)
        {
            var marketAuthLimitByProductDetail = await _context.MarketAuthLimitByProductDetail.FindAsync(id);

            if (marketAuthLimitByProductDetail == null)
            {
                return NotFound();
            }

            return marketAuthLimitByProductDetail;
        }

        // PUT: api/MarketAuthLimitByProductDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketAuthLimitByProductDetail(long id, MarketAuthLimitByProductDetail marketAuthLimitByProductDetail)
        {
            if (id != marketAuthLimitByProductDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketAuthLimitByProductDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketAuthLimitByProductDetailExists(id))
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

        // POST: api/MarketAuthLimitByProductDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketAuthLimitByProductDetail>> PostMarketAuthLimitByProductDetail(MarketAuthLimitByProductDetail marketAuthLimitByProductDetail)
        {
            _context.MarketAuthLimitByProductDetail.Add(marketAuthLimitByProductDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketAuthLimitByProductDetail", new { id = marketAuthLimitByProductDetail.Id }, marketAuthLimitByProductDetail);
        }

        // DELETE: api/MarketAuthLimitByProductDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketAuthLimitByProductDetail>> DeleteMarketAuthLimitByProductDetail(long id)
        {
            var marketAuthLimitByProductDetail = await _context.MarketAuthLimitByProductDetail.FindAsync(id);
            if (marketAuthLimitByProductDetail == null)
            {
                return NotFound();
            }

            _context.MarketAuthLimitByProductDetail.Remove(marketAuthLimitByProductDetail);
            await _context.SaveChangesAsync();

            return marketAuthLimitByProductDetail;
        }

        private bool MarketAuthLimitByProductDetailExists(long id)
        {
            return _context.MarketAuthLimitByProductDetail.Any(e => e.Id == id);
        }
    }
}
