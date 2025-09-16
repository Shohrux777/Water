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
    public class MarketProductGroupDetailsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketProductGroupDetailsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketProductGroupDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketProductGroupDetail>>> GetMarketProductGroupDetail()
        {
            return await _context.MarketProductGroupDetail.OrderByDescending(p => p.Id).ToListAsync();
        }
        [HttpGet("getProductListByMarketProductGroupId")]
        public async Task<ActionResult<IEnumerable<MarketProductGroupDetail>>> getProductListByMarketProductGroupId([FromQuery] long MarketProductGroupId)
        {
            List<MarketProductGroupDetail> marketProductGroupDetails = await _context.MarketProductGroupDetail.Where(p => p.MarketProductGroupId == MarketProductGroupId).Include(p => p.product).ThenInclude(p => p.marketUnitMeasurment).ToListAsync();
            return marketProductGroupDetails;
        }

        // GET: api/MarketProductGroupDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketProductGroupDetail>> GetMarketProductGroupDetail(long id)
        {
            var marketProductGroupDetail = await _context.MarketProductGroupDetail.FindAsync(id);

            if (marketProductGroupDetail == null)
            {
                return NotFound();
            }

            return marketProductGroupDetail;
        }

        // PUT: api/MarketProductGroupDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketProductGroupDetail(long id, MarketProductGroupDetail marketProductGroupDetail)
        {
            if (id != marketProductGroupDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketProductGroupDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketProductGroupDetailExists(id))
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

        // POST: api/MarketProductGroupDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketProductGroupDetail>> PostMarketProductGroupDetail(MarketProductGroupDetail marketProductGroupDetail)
        {
            _context.MarketProductGroupDetail.Add(marketProductGroupDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketProductGroupDetail", new { id = marketProductGroupDetail.Id }, marketProductGroupDetail);
        }

        // DELETE: api/MarketProductGroupDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketProductGroupDetail>> DeleteMarketProductGroupDetail(long id)
        {
            var marketProductGroupDetail = await _context.MarketProductGroupDetail.FindAsync(id);
            if (marketProductGroupDetail == null)
            {
                return NotFound();
            }

            _context.MarketProductGroupDetail.Remove(marketProductGroupDetail);
            await _context.SaveChangesAsync();

            return marketProductGroupDetail;
        }

        private bool MarketProductGroupDetailExists(long id)
        {
            return _context.MarketProductGroupDetail.Any(e => e.Id == id);
        }
    }
}
