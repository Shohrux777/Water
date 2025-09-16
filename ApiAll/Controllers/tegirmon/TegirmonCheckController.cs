using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tegirmon;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tegirmon
{
    [ApiExplorerSettings(GroupName = "v7")]
    [Route("api/[controller]")]
    [ApiController]
    public class TegirmonCheckController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonCheckController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonCheck
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonCheck>>> GetTegirmonCheck()
        {
            return await _context.TegirmonCheck.ToListAsync();
        }

        [HttpGet("getKassaCurrentRealTegirmonPosition")]
        public async Task<ActionResult<IEnumerable<TegirmonMoneyInfoTemp>>> getKassaCurrentRealTegirmonPosition([FromQuery] DateTime begin_date, [FromQuery] DateTime end_date)
        {
            String beginDateStr = begin_date.ToString("yyyy-MM-dd hh:mm:ss");
            String endDateStr = end_date.ToString("yyyy-MM-dd hh:mm:ss");
            return await _context.TegirmonMoneyInfoTemp.FromSqlRaw("" +
                " SELECT   "+
                " sum(card) as card,   " +
                " sum(cash) as cash,   " +
                " sum(summ) as summ,   " +
                " sum(profit_summ) as profit_sum,   " +
                " sum(real_sum) as real_sum,   " +
                " sum(humo) as humo,   " +
                " sum(uz_card) as uz_card,   " +
                " sum(perchisleniya) as perchisleniya,   " +
                " sum(dolg) as dolg,   " +
                " sum(dolg_payed) as dolg_payed,   " +
                " sum(creadit_payed) as creadit_payed,   " +
                " sum(rasxod) as rasxod,   " +
                " sum(online) as online,   " +
                " sum(salary) as salary,   " +
                " sum(for_buy_tovar_rasxod) as for_buy_tovar_rasxod,   " +
                " sum(srogi_otganlar_uchun_rasxod) as srogi_otganlar_uchun_rasxod   " +
                "FROM public.tegirmon_check WHERE create_date BETWEEN '"+ beginDateStr + "' AND '"+endDateStr+"'").ToListAsync();



        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonCheck> categoryList = await _context.TegirmonCheck
                .Include(p =>p.client)
                .Include(p =>p.contragent)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonCheck>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonCheck.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationByBeatWeenTwoDate")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByBeatWeenTwoDate([FromQuery] int page, [FromQuery] int size,[FromQuery] DateTime begin_date,[FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonCheck> categoryList = await _context.TegirmonCheck
                .Include(p => p.client)
                .Include(p => p.contragent)
                .Where(p => p.active_status == true
                && (p.created_date_time >= begin_date  && p.created_date_time <= end_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonCheck>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonCheck
                .Where(p => p.active_status == true
                && (p.created_date_time >= begin_date && p.created_date_time <= end_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationRasxod")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationRasxod([FromQuery] int page, [FromQuery] int size,[FromQuery] DateTime begin_date,[FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonCheck> categoryList = await _context.TegirmonCheck
                .Include(p => p.client)
                .Include(p => p.contragent)
                .Where(p => p.active_status == true
                && (p.created_date_time >= begin_date && p.created_date_time <= end_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonCheck>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonCheck.Where(p => p.active_status == true
            && (p.created_date_time >= begin_date && p.created_date_time <= end_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TegirmonCheck/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonCheck>> GetTegirmonCheck(long id)
        {
            var tegirmonCheck = await _context.TegirmonCheck.FindAsync(id);

            if (tegirmonCheck == null)
            {
                return NotFound();
            }

            return tegirmonCheck;
        }

        [HttpGet("getcheckFullInfoById")]
        public async Task<ActionResult<TegirmonCheck>> getcheckFullInfoById([FromQuery]long check_id)
        {
            var tegirmonCheck = await _context.TegirmonCheck
                .Include(p => p.contragent)
                .Include(p =>p.client)
                .Include(p =>p.credit)
                .Where(p => p.id == check_id).ToListAsync();

            if (tegirmonCheck == null || tegirmonCheck.Count == 0)
            {
                return NotFound();
            }
            tegirmonCheck.First().payments = await _context.TegirmonPayments
                .Include(p =>p.product)
                .Where(p => p.TegirmonCheckid == check_id).ToListAsync();

            return tegirmonCheck.First();
        }

        // PUT: api/TegirmonCheck/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonCheck(long id, TegirmonCheck tegirmonCheck)
        {
            if (id != tegirmonCheck.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonCheck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonCheckExists(id))
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

        // POST: api/TegirmonCheck
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonCheck>> PostTegirmonCheck(TegirmonCheck tegirmonCheck)
        {
            _context.TegirmonCheck.Update(tegirmonCheck);
            await _context.SaveChangesAsync();
            //tovar sotsa ayrib qoyish kerak real qtydan
            if (tegirmonCheck.payments != null
                && tegirmonCheck.payments.Count > 0) {

                foreach (TegirmonPayments item in tegirmonCheck.payments) {
                    List<TegirmonOstatka> ostatkaList = await _context.TegirmonOstatka
                        .Where(p => p.TegirmonProductid == item.TegirmonProductid)
                        .ToListAsync();

                    if (ostatkaList != null && ostatkaList.Count > 0) {
                        ostatkaList.First().real_qty = ostatkaList.First().real_qty - item.qty;

                        _context.TegirmonOstatka.Update(ostatkaList.First());
                        await _context.SaveChangesAsync();

                    }

                }


            }

            

            return tegirmonCheck;
        }



        // DELETE: api/TegirmonCheck/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonCheck>> DeleteTegirmonCheck(long id)
        {
            var tegirmonCheck = await _context.TegirmonCheck.FindAsync(id);
            if (tegirmonCheck == null)
            {
                return NotFound();
            }

            _context.TegirmonCheck.Remove(tegirmonCheck);
            await _context.SaveChangesAsync();

            return tegirmonCheck;
        }

        private bool TegirmonCheckExists(long id)
        {
            return _context.TegirmonCheck.Any(e => e.id == id);
        }
    }
}
