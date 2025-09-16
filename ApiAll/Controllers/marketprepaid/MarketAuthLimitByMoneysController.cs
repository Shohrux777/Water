using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.market;
using ApiAll.Model;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class MarketAuthLimitByMoneysController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketAuthLimitByMoneysController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketAuthLimitByMoneys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketAuthLimitByMoney>>> GetMarketAuthLimitByMoney()
        {
            return await _context.MarketAuthLimitByMoney.OrderByDescending(p => p.Id).ToListAsync();
        }

        [HttpGet("getAllLimitListForMarket")]
        public async Task<ActionResult<IEnumerable<MarketLimitCustomItem>>> getAllLimitListForMarket()
        {

            var result = await _context.MarketLimitCustomItem.FromSqlRaw("" +
                "  select m.\"Id\" as id,   "+
                "  m.\"AuthorizationId\" as auth_id,   " +
                "  a.\"Login\" as auth_name, m.\"beginDateTime\"::timestamp::date as begin_date,   " +
                "  m.\"endDateTime\"::timestamp::date as end_date,  " +
                "  m.\"MarketProductId\" as product_id, mp.\"Name\" as product_name,   " +
                "  m.qty as limit_qty, m.\"realQty\" as real_qty, null as \"realSumm\",   " +
                "  null as \"reservedSumm\",  " +
                "  m.\"limitFinished\", true \"byProduct\"  " +
                "  from  \"MarketAuthLimitByProduct\" m   " +
                "  left join authorizations a on m.\"AuthorizationId\" = a.\"Id\"   " +
                "  left join \"MarketProduct\" mp on mp.\"Id\" = m.\"MarketProductId\"  " +
                "  UNION SELECT m.\"Id\", m.\"AuthorizationId\", a.\"Login\", m.\"beginDateTime\"::timestamp::date, m.\"endDateTime\"::timestamp::date, null, null, null, null, m.\"realSumm\",   " +
                "  m.\"reservedSumm\", m.\"limitFinished\", false FROM \"MarketAuthLimitByMoney\" m left join authorizations a on m.\"AuthorizationId\" = a.\"Id\"  ").ToListAsync();

            return result;
        }

        [HttpGet("getMarketAuthLimitByMoneyByAuthId")]
        public async Task<ActionResult<IEnumerable<MarketAuthLimitByMoney>>> getMarketAuthLimitByMoneyByAuthId([FromQuery] long AuthId)
        {

            List<MarketAuthLimitByMoney> authLimitByMoneyList =  await _context.MarketAuthLimitByMoney.Where( p => p.AuthorizationId == AuthId && p.realSumm > 0 && ( DateTime.Now >= p.beginDateTime &&  DateTime.Now <= p.endDateTime)).OrderByDescending(p => p.Id).ToListAsync();
            if (authLimitByMoneyList != null && authLimitByMoneyList.Count > 0) {
                Authorization authorization = await _context.authorizations.FindAsync(AuthId);
                if (authorization != null) {
                    List<MarketPrePaidMoney> prePaidMoneyList = await _context.MarketPrePaidMoney.Where(p => p.UsersId == authorization.UsersId && p.realSumm > 0).ToListAsync();
                    if (prePaidMoneyList != null && prePaidMoneyList.Count > 0)
                    {
                        double realMoney = 0;
                        double limitMoney = 0;

                        //real tolagan puli
                        foreach (MarketPrePaidMoney itemM  in  prePaidMoneyList )
                        {
                            realMoney = realMoney + itemM.realSumm;
                        }

                        //real limit puli
                        foreach (MarketAuthLimitByMoney itemL in authLimitByMoneyList)
                        {
                            limitMoney = limitMoney + itemL.realSumm;
                        }

                        if (realMoney <= limitMoney) {
                            foreach (MarketAuthLimitByMoney itemS in authLimitByMoneyList) {
                                itemS.realSumm = realMoney;
                            }
                        }
                    }
                    else {
                        foreach (MarketAuthLimitByMoney item in authLimitByMoneyList) {
                            item.realSumm = 0;
                        }
                    }

                }
            }

            return authLimitByMoneyList;
        }

        // GET: api/MarketAuthLimitByMoneys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketAuthLimitByMoney>> GetMarketAuthLimitByMoney(long id)
        {
            var marketAuthLimitByMoney = await _context.MarketAuthLimitByMoney.FindAsync(id);

            if (marketAuthLimitByMoney == null)
            {
                return NotFound();
            }

            return marketAuthLimitByMoney;
        }

        [HttpGet("getRemoveLimitSummFromMarketLimit")]
        public async Task<ActionResult<MarketAuthLimitByMoney>> getRemoveLimitSummFromMarketLimit([FromQuery]long authId,[FromQuery] double summ)
        {
            /*remove from  already paid summ*/
            Authorization authorization = await _context.authorizations.FindAsync(authId);
            Users users = await _context.Users.FindAsync(authorization.UsersId);
            List<MarketPrePaidMoney> marketPrePaids = await _context.MarketPrePaidMoney.Where(p => p.UsersId == users.Id && p.realSumm > 0).ToListAsync();
            if (marketPrePaids != null && marketPrePaids.Count > 0)
            {
                double realLeftSumm = 0;
                foreach (MarketPrePaidMoney item in marketPrePaids) {
                    realLeftSumm = realLeftSumm + item.realSumm;
                }
                //schotda bor pul ozi kam yetmedi digan xato
                if (summ > realLeftSumm) {
                    return NotFound();
                }

                double summOfForPay = summ;
                foreach (MarketPrePaidMoney it in marketPrePaids)
                {
                    if(summOfForPay > 0){
                        if (it.realSumm >= summOfForPay)
                        {
                            it.realSumm = it.realSumm - summOfForPay;
                            _context.MarketPrePaidMoney.Update(it);
                            await _context.SaveChangesAsync();
                            summOfForPay = 0;
                        }
                        else {
                            summOfForPay = summOfForPay - it.realSumm;
                            it.realSumm = 0;
                            _context.MarketPrePaidMoney.Update(it);
                            await _context.SaveChangesAsync();
                        }
                    }

                }
            }
            else {
                return NotFound();
            }


            /*remove from market limit*/
            List<MarketAuthLimitByMoney> authLimitByMoneyList = await _context.MarketAuthLimitByMoney.Where(p => p.AuthorizationId == authId && p.realSumm > 0).ToListAsync();
            if (authLimitByMoneyList != null && authLimitByMoneyList.Count > 0) {
                MarketAuthLimitByMoney limitByMoney = authLimitByMoneyList.First();
                limitByMoney.realSumm = limitByMoney.realSumm - summ;
                _context.MarketAuthLimitByMoney.Update(limitByMoney);
                await _context.SaveChangesAsync();
                return limitByMoney;
            }

            return new MarketAuthLimitByMoney();
        }

        // PUT: api/MarketAuthLimitByMoneys/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketAuthLimitByMoney(long id, MarketAuthLimitByMoney marketAuthLimitByMoney)
        {
            if (id != marketAuthLimitByMoney.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketAuthLimitByMoney).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketAuthLimitByMoneyExists(id))
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

        // POST: api/MarketAuthLimitByMoneys
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketAuthLimitByMoney>> PostMarketAuthLimitByMoney(MarketAuthLimitByMoney marketAuthLimitByMoney)
        {
            _context.MarketAuthLimitByMoney.Update(marketAuthLimitByMoney);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketAuthLimitByMoney", new { id = marketAuthLimitByMoney.Id }, marketAuthLimitByMoney);
        }

        // DELETE: api/MarketAuthLimitByMoneys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketAuthLimitByMoney>> DeleteMarketAuthLimitByMoney(long id)
        {
            var marketAuthLimitByMoney = await _context.MarketAuthLimitByMoney.FindAsync(id);
            if (marketAuthLimitByMoney == null)
            {
                return NotFound();
            }

            _context.MarketAuthLimitByMoney.Remove(marketAuthLimitByMoney);
            await _context.SaveChangesAsync();

            return marketAuthLimitByMoney;
        }

        private bool MarketAuthLimitByMoneyExists(long id)
        {
            return _context.MarketAuthLimitByMoney.Any(e => e.Id == id);
        }
    }
}
