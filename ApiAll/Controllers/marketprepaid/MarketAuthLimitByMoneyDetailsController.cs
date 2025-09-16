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
    public class MarketAuthLimitByMoneyDetailsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketAuthLimitByMoneyDetailsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketAuthLimitByMoneyDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketAuthLimitByMoneyDetail>>> GetMarketAuthLimitByMoneyDetail()
        {
            return await _context.MarketAuthLimitByMoneyDetail.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/MarketAuthLimitByMoneyDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketAuthLimitByMoneyDetail>> GetMarketAuthLimitByMoneyDetail(long id)
        {
            var marketAuthLimitByMoneyDetail = await _context.MarketAuthLimitByMoneyDetail.FindAsync(id);

            if (marketAuthLimitByMoneyDetail == null)
            {
                return NotFound();
            }

            return marketAuthLimitByMoneyDetail;
        }

        // PUT: api/MarketAuthLimitByMoneyDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketAuthLimitByMoneyDetail(long id, MarketAuthLimitByMoneyDetail marketAuthLimitByMoneyDetail)
        {
            if (id != marketAuthLimitByMoneyDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketAuthLimitByMoneyDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketAuthLimitByMoneyDetailExists(id))
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

        // POST: api/MarketAuthLimitByMoneyDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketAuthLimitByMoneyDetail>> PostMarketAuthLimitByMoneyDetail(MarketAuthLimitByMoneyDetail marketAuthLimitByMoneyDetail)
        {
            _context.MarketAuthLimitByMoneyDetail.Add(marketAuthLimitByMoneyDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketAuthLimitByMoneyDetail", new { id = marketAuthLimitByMoneyDetail.Id }, marketAuthLimitByMoneyDetail);
        }

        // DELETE: api/MarketAuthLimitByMoneyDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketAuthLimitByMoneyDetail>> DeleteMarketAuthLimitByMoneyDetail(long id)
        {
            var marketAuthLimitByMoneyDetail = await _context.MarketAuthLimitByMoneyDetail.FindAsync(id);
            if (marketAuthLimitByMoneyDetail == null)
            {
                return NotFound();
            }

            _context.MarketAuthLimitByMoneyDetail.Remove(marketAuthLimitByMoneyDetail);
            await _context.SaveChangesAsync();

            return marketAuthLimitByMoneyDetail;
        }

        private bool MarketAuthLimitByMoneyDetailExists(long id)
        {
            return _context.MarketAuthLimitByMoneyDetail.Any(e => e.Id == id);
        }
    }
}
