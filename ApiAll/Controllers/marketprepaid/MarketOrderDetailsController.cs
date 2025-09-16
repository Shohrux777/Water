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
    public class MarketOrderDetailsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketOrderDetailsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketOrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketOrderDetail>>> GetMarketOrderDetail()
        {
            return await _context.MarketOrderDetail.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/MarketOrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketOrderDetail>> GetMarketOrderDetail(long id)
        {
            var marketOrderDetail = await _context.MarketOrderDetail.FindAsync(id);

            if (marketOrderDetail == null)
            {
                return NotFound();
            }

            return marketOrderDetail;
        }

        // PUT: api/MarketOrderDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketOrderDetail(long id, MarketOrderDetail marketOrderDetail)
        {
            if (id != marketOrderDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketOrderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketOrderDetailExists(id))
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

        // POST: api/MarketOrderDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketOrderDetail>> PostMarketOrderDetail(MarketOrderDetail marketOrderDetail)
        {
            _context.MarketOrderDetail.Add(marketOrderDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketOrderDetail", new { id = marketOrderDetail.Id }, marketOrderDetail);
        }

        // DELETE: api/MarketOrderDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketOrderDetail>> DeleteMarketOrderDetail(long id)
        {
            var marketOrderDetail = await _context.MarketOrderDetail.FindAsync(id);
            if (marketOrderDetail == null)
            {
                return NotFound();
            }

            _context.MarketOrderDetail.Remove(marketOrderDetail);
            await _context.SaveChangesAsync();

            return marketOrderDetail;
        }

        private bool MarketOrderDetailExists(long id)
        {
            return _context.MarketOrderDetail.Any(e => e.Id == id);
        }
    }
}
