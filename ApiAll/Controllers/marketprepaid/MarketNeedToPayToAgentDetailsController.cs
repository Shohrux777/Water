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
    public class MarketNeedToPayToAgentDetailsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketNeedToPayToAgentDetailsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketNeedToPayToAgentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketNeedToPayToAgentDetail>>> GetMarketNeedToPayToAgentDetail()
        {
            return await _context.MarketNeedToPayToAgentDetail.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/MarketNeedToPayToAgentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketNeedToPayToAgentDetail>> GetMarketNeedToPayToAgentDetail(long id)
        {
            var marketNeedToPayToAgentDetail = await _context.MarketNeedToPayToAgentDetail.FindAsync(id);

            if (marketNeedToPayToAgentDetail == null)
            {
                return NotFound();
            }

            return marketNeedToPayToAgentDetail;
        }

        // PUT: api/MarketNeedToPayToAgentDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketNeedToPayToAgentDetail(long id, MarketNeedToPayToAgentDetail marketNeedToPayToAgentDetail)
        {
            if (id != marketNeedToPayToAgentDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketNeedToPayToAgentDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketNeedToPayToAgentDetailExists(id))
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

        // POST: api/MarketNeedToPayToAgentDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketNeedToPayToAgentDetail>> PostMarketNeedToPayToAgentDetail(MarketNeedToPayToAgentDetail marketNeedToPayToAgentDetail)
        {
            _context.MarketNeedToPayToAgentDetail.Update(marketNeedToPayToAgentDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketNeedToPayToAgentDetail", new { id = marketNeedToPayToAgentDetail.Id }, marketNeedToPayToAgentDetail);
        }

        // DELETE: api/MarketNeedToPayToAgentDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketNeedToPayToAgentDetail>> DeleteMarketNeedToPayToAgentDetail(long id)
        {
            var marketNeedToPayToAgentDetail = await _context.MarketNeedToPayToAgentDetail.FindAsync(id);
            if (marketNeedToPayToAgentDetail == null)
            {
                return NotFound();
            }

            _context.MarketNeedToPayToAgentDetail.Remove(marketNeedToPayToAgentDetail);
            await _context.SaveChangesAsync();

            return marketNeedToPayToAgentDetail;
        }

        private bool MarketNeedToPayToAgentDetailExists(long id)
        {
            return _context.MarketNeedToPayToAgentDetail.Any(e => e.Id == id);
        }
    }
}
