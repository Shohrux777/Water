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
    public class MarketClientInfoesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketClientInfoesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketClientInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketClientInfo>>> GetMarketClientInfo()
        {
            return await _context.MarketClientInfo.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/MarketClientInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketClientInfo>> GetMarketClientInfo(long id)
        {
            var marketClientInfo = await _context.MarketClientInfo.FindAsync(id);

            if (marketClientInfo == null)
            {
                return NotFound();
            }

            return marketClientInfo;
        }

        // PUT: api/MarketClientInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketClientInfo(long id, MarketClientInfo marketClientInfo)
        {
            if (id != marketClientInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketClientInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketClientInfoExists(id))
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

        // POST: api/MarketClientInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketClientInfo>> PostMarketClientInfo(MarketClientInfo marketClientInfo)
        {
            _context.MarketClientInfo.Add(marketClientInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketClientInfo", new { id = marketClientInfo.Id }, marketClientInfo);
        }

        // DELETE: api/MarketClientInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketClientInfo>> DeleteMarketClientInfo(long id)
        {
            var marketClientInfo = await _context.MarketClientInfo.FindAsync(id);
            if (marketClientInfo == null)
            {
                return NotFound();
            }

            _context.MarketClientInfo.Remove(marketClientInfo);
            await _context.SaveChangesAsync();

            return marketClientInfo;
        }

        private bool MarketClientInfoExists(long id)
        {
            return _context.MarketClientInfo.Any(e => e.Id == id);
        }
    }
}
