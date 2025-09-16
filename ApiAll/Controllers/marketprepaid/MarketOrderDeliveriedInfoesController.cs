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
    public class MarketOrderDeliveriedInfoesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketOrderDeliveriedInfoesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketOrderDeliveriedInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketOrderDeliveriedInfo>>> GetMarketOrderDeliveriedInfo()
        {
            return await _context.MarketOrderDeliveriedInfo.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/MarketOrderDeliveriedInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketOrderDeliveriedInfo>> GetMarketOrderDeliveriedInfo(long id)
        {
            var marketOrderDeliveriedInfo = await _context.MarketOrderDeliveriedInfo.FindAsync(id);

            if (marketOrderDeliveriedInfo == null)
            {
                return NotFound();
            }

            return marketOrderDeliveriedInfo;
        }

        // PUT: api/MarketOrderDeliveriedInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketOrderDeliveriedInfo(long id, MarketOrderDeliveriedInfo marketOrderDeliveriedInfo)
        {
            if (id != marketOrderDeliveriedInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketOrderDeliveriedInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketOrderDeliveriedInfoExists(id))
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

        // POST: api/MarketOrderDeliveriedInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketOrderDeliveriedInfo>> PostMarketOrderDeliveriedInfo(MarketOrderDeliveriedInfo marketOrderDeliveriedInfo)
        {
            _context.MarketOrderDeliveriedInfo.Add(marketOrderDeliveriedInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketOrderDeliveriedInfo", new { id = marketOrderDeliveriedInfo.Id }, marketOrderDeliveriedInfo);
        }

        // DELETE: api/MarketOrderDeliveriedInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketOrderDeliveriedInfo>> DeleteMarketOrderDeliveriedInfo(long id)
        {
            var marketOrderDeliveriedInfo = await _context.MarketOrderDeliveriedInfo.FindAsync(id);
            if (marketOrderDeliveriedInfo == null)
            {
                return NotFound();
            }

            _context.MarketOrderDeliveriedInfo.Remove(marketOrderDeliveriedInfo);
            await _context.SaveChangesAsync();

            return marketOrderDeliveriedInfo;
        }

        private bool MarketOrderDeliveriedInfoExists(long id)
        {
            return _context.MarketOrderDeliveriedInfo.Any(e => e.Id == id);
        }
    }
}
