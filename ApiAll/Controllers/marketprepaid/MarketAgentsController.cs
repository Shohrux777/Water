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
    public class MarketAgentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketAgentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketAgents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketAgent>>> GetMarketAgent()
        {
            return await _context.MarketAgent.ToListAsync();
        }

        // GET: api/MarketAgents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketAgent>> GetMarketAgent(long id)
        {
            var marketAgent = await _context.MarketAgent.FindAsync(id);

            if (marketAgent == null)
            {
                return NotFound();
            }

            return marketAgent;
        }

        // PUT: api/MarketAgents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketAgent(long id, MarketAgent marketAgent)
        {
            if (id != marketAgent.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketAgent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketAgentExists(id))
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

        // POST: api/MarketAgents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketAgent>> PostMarketAgent(MarketAgent marketAgent)
        {
            _context.MarketAgent.Update(marketAgent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketAgent", new { id = marketAgent.Id }, marketAgent);
        }

        // DELETE: api/MarketAgents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketAgent>> DeleteMarketAgent(long id)
        {
            var marketAgent = await _context.MarketAgent.FindAsync(id);
            if (marketAgent == null)
            {
                return NotFound();
            }

            _context.MarketAgent.Remove(marketAgent);
            await _context.SaveChangesAsync();

            return marketAgent;
        }

        private bool MarketAgentExists(long id)
        {
            return _context.MarketAgent.Any(e => e.Id == id);
        }
    }
}
