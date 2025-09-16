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
    public class MarketNeedToPayToAgentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketNeedToPayToAgentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketNeedToPayToAgents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketNeedToPayToAgents>>> GetMarketNeedToPayToAgents()
        {
            return await _context.MarketNeedToPayToAgents.OrderByDescending(p => p.Id).ToListAsync();
        }

        [HttpGet("getUnpaidAgentsList")]
        public async Task<ActionResult<IEnumerable<MarketNeedToPayToAgents>>> getUnpaidAgentsList()
        {
            return await _context.MarketNeedToPayToAgents.Where(p => p.realSumm > 0).OrderByDescending(p => p.Id).Include( p => p.marketAgent).ToListAsync();
        }
        

        // GET: api/MarketNeedToPayToAgents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketNeedToPayToAgents>> GetMarketNeedToPayToAgents(long id)
        {
            var marketNeedToPayToAgents = await _context.MarketNeedToPayToAgents.FindAsync(id);

            if (marketNeedToPayToAgents == null)
            {
                return NotFound();
            }

            return marketNeedToPayToAgents;
        }

        [HttpGet("paySummToAgents")]
        public async Task<ActionResult<MarketNeedToPayToAgents>> paySummToAgents([FromQuery]long MarketNeedToPayToAgentsId,[FromQuery] double summ,[FromQuery] long AuthId,[FromQuery]String paymentTypeStr/*naqt,plastik,perchisleniya*/)
        {
            var marketNeedToPayToAgents = await _context.MarketNeedToPayToAgents.FindAsync(MarketNeedToPayToAgentsId);

            if (marketNeedToPayToAgents == null)
            {
                return NotFound();
            }

            MarketNeedToPayToAgentDetail payToAgentDetail = new MarketNeedToPayToAgentDetail();
            payToAgentDetail.ActiveStatus = true;
            payToAgentDetail.AuthorizationId = AuthId;
            payToAgentDetail.summ = summ;
            payToAgentDetail.paymentTypeStr = paymentTypeStr;
            payToAgentDetail.dateTime = DateTime.Now;

            //add detail who get money
            _context.MarketNeedToPayToAgentDetail.Update(payToAgentDetail);
            await _context.SaveChangesAsync();

            //minus summ 
            marketNeedToPayToAgents.realSumm = marketNeedToPayToAgents.realSumm - summ;
            _context.MarketNeedToPayToAgents.Update(marketNeedToPayToAgents);
            await _context.SaveChangesAsync();

            return marketNeedToPayToAgents;
        }

        // PUT: api/MarketNeedToPayToAgents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketNeedToPayToAgents(long id, MarketNeedToPayToAgents marketNeedToPayToAgents)
        {
            if (id != marketNeedToPayToAgents.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketNeedToPayToAgents).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketNeedToPayToAgentsExists(id))
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

        // POST: api/MarketNeedToPayToAgents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketNeedToPayToAgents>> PostMarketNeedToPayToAgents(MarketNeedToPayToAgents marketNeedToPayToAgents)
        {
            _context.MarketNeedToPayToAgents.Update(marketNeedToPayToAgents);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketNeedToPayToAgents", new { id = marketNeedToPayToAgents.Id }, marketNeedToPayToAgents);
        }

        // DELETE: api/MarketNeedToPayToAgents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketNeedToPayToAgents>> DeleteMarketNeedToPayToAgents(long id)
        {
            var marketNeedToPayToAgents = await _context.MarketNeedToPayToAgents.FindAsync(id);
            if (marketNeedToPayToAgents == null)
            {
                return NotFound();
            }

            _context.MarketNeedToPayToAgents.Remove(marketNeedToPayToAgents);
            await _context.SaveChangesAsync();

            return marketNeedToPayToAgents;
        }

        private bool MarketNeedToPayToAgentsExists(long id)
        {
            return _context.MarketNeedToPayToAgents.Any(e => e.Id == id);
        }
    }
}
