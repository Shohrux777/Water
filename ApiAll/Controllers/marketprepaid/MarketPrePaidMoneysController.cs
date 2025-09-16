using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class MarketPrePaidMoneysController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketPrePaidMoneysController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketPrePaidMoneys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketPrePaidMoney>>> GetMarketPrePaidMoney()
        {
            return await _context.MarketPrePaidMoney.OrderByDescending( p => p.Id).Include( p => p.users).ToListAsync();
        }

        [HttpGet("getLeftPrePaidSummListByUserId")]
        public async Task<ActionResult<IEnumerable<MarketPrePaidMoney>>> getLeftPrePaidSummListByUserId([FromQuery] long userId)
        {
            return await _context.MarketPrePaidMoney.Where( p => p.UsersId == userId && p.ActiveStatus == true && p.realSumm > 0).OrderByDescending(p => p.Id).Include(p => p.users).ToListAsync();
        }

        [HttpGet("getRealLeftMoneyOfUserByUserId")]
        public async Task<ActionResult<MarketPrePaidMoney>> getRealLeftMoneyOfUserByUserId([FromQuery] long userId)
        {
            List<MarketPrePaidMoney> marketPrePaidMoney =  await _context.MarketPrePaidMoney.Where(p => p.UsersId == userId && p.ActiveStatus == true && p.realSumm > 0).OrderByDescending(p => p.Id).Include(p => p.users).ToListAsync();
            MarketPrePaidMoney paidMoney = new MarketPrePaidMoney();
            paidMoney.realSumm = 0;
            paidMoney.reservedSumm = 0;
            paidMoney.createdDateTime = DateTime.Now;
            paidMoney.ActiveStatus = true;
            paidMoney.Id = 0;
            if (marketPrePaidMoney != null && marketPrePaidMoney.Count > 0) {
                double realMoneySumm = 0;
                double paidMoneySumm = 0;
                foreach (MarketPrePaidMoney item in marketPrePaidMoney) {
                    realMoneySumm = realMoneySumm + item.realSumm;
                    paidMoneySumm = paidMoneySumm + item.reservedSumm;
                }
                paidMoney.realSumm = realMoneySumm;
                paidMoney.reservedSumm = paidMoneySumm;
            }

            return paidMoney;

        }


        // GET: api/MarketPrePaidMoneys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketPrePaidMoney>> GetMarketPrePaidMoney(long id)
        {
            var marketPrePaidMoney = await _context.MarketPrePaidMoney.FindAsync(id);

            if (marketPrePaidMoney == null)
            {
                return NotFound();
            }

            return marketPrePaidMoney;
        }

        // PUT: api/MarketPrePaidMoneys/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketPrePaidMoney(long id, MarketPrePaidMoney marketPrePaidMoney)
        {
            if (id != marketPrePaidMoney.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketPrePaidMoney).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketPrePaidMoneyExists(id))
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

        // POST: api/MarketPrePaidMoneys
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketPrePaidMoney>> PostMarketPrePaidMoney(MarketPrePaidMoney marketPrePaidMoney)
        {
            marketPrePaidMoney.ActiveStatus = true;
            marketPrePaidMoney.createdDateTime = DateTime.Now;
            _context.MarketPrePaidMoney.Update(marketPrePaidMoney);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketPrePaidMoney", new { id = marketPrePaidMoney.Id }, marketPrePaidMoney);
        }

        // DELETE: api/MarketPrePaidMoneys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketPrePaidMoney>> DeleteMarketPrePaidMoney(long id)
        {
            var marketPrePaidMoney = await _context.MarketPrePaidMoney.FindAsync(id);
            if (marketPrePaidMoney == null)
            {
                return NotFound();
            }

            _context.MarketPrePaidMoney.Remove(marketPrePaidMoney);
            await _context.SaveChangesAsync();

            return marketPrePaidMoney;
        }

        private bool MarketPrePaidMoneyExists(long id)
        {
            return _context.MarketPrePaidMoney.Any(e => e.Id == id);
        }
    }
}
