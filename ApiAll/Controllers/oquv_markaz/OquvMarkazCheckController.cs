using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.oquv_markaz;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.oquv_markaz
{
    [ApiExplorerSettings(GroupName = "v8")]
    [Route("api/[controller]")]
    [ApiController]
    public class OquvMarkazCheckController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazCheckController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazCheck
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazCheck>>> GetOquvMarkazCheck()
        {
            return await _context.OquvMarkazCheck.ToListAsync();
        }

        [HttpGet("getKassaCurrentRealOquvMarkazPosition")]
        public async Task<ActionResult<IEnumerable<OquvMarkazKassaCurrentCondition>>> getKassaCurrentRealOquvMarkazPosition([FromQuery] DateTime begin_date,[FromQuery] DateTime end_date)
        {
            String beginDateStr = begin_date.ToString("yyyy-MM-dd hh:mm:ss");
            String endDateStr = end_date.ToString("yyyy-MM-dd hh:mm:ss");
            


           return await _context.OquvMarkazKassaCurrentCondition.FromSqlRaw("" +

                " SELECT"+
                " COALESCE(sum(summ), 0) as summ,"+
                " COALESCE(sum(credit), 0) as credit,"+
                " COALESCE(sum(debit), 0) as debit,"+
                " COALESCE(sum(cash), 0) as cash,"+
                " COALESCE(sum(card), 0) as card,"+
                " COALESCE(sum(online), 0) as online,"+
                " COALESCE(sum(salary), 0) as salary,"+
                " COALESCE(sum(rasxod), 0) as rasxod,"+
                " COALESCE(sum(discount), 0) as discount,"+
                " COALESCE(sum(discount_pesantage), 0) as discount_pesantage,"+
                " COALESCE(sum(discount_summ), 0) as discount_summ,"+
                " COALESCE(sum(bonus_summ), 0) as bonus_summ,"+
                " COALESCE(sum(cashback_summ), 0) as cashback_summ,"+
                " COALESCE(sum(kam_chiqqan_summ), 0) as kam_chiqqan_summ"+
                " FROM public.oquv_markaz_check WHERE  created_date_time BETWEEN '"+beginDateStr+"' AND '"+endDateStr+"' "+
                "").ToListAsync();


            

        }

        //OquvMarkazKassaCurrentCondition

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazCheck> categoryList = await _context.OquvMarkazCheck.Where(p => p.active_status == true)
                .Include(p =>p.payment_list)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazCheck>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazCheck.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationCheckBeetweenDateTime")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationCheckBeetweenDateTime([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazCheck> categoryList = await _context.OquvMarkazCheck
                .Where(p => p.active_status == true && (p.created_date_time >= b_date && p.created_date_time <= e_date))
                .Include(p => p.client)
                .Include(p => p.user)
                .Include(p => p.auth)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazCheck>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = categoryList.Count();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationCheckBeetweenDateTimeByUserIdOnlySalary")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationCheckBeetweenDateTimeByUserIdOnlySalary([FromQuery] int page, [FromQuery] int size,
            [FromQuery] DateTime b_date, [FromQuery] DateTime e_date,[FromQuery] long user_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazCheck> categoryList = await _context.OquvMarkazCheck
                .Where(p => p.active_status == true
                && p.salary > 0 && p.OquvMarkazUserid == user_id
                && (p.created_date_time >= b_date && p.created_date_time <= e_date))
                .Include(p => p.client)
                .Include(p => p.user)
                .Include(p => p.auth)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazCheck>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazCheck
                .Where(p => p.active_status == true
                && p.salary > 0 && p.OquvMarkazUserid == user_id
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationCheckBeetweenDateTimeCard")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationCheckBeetweenDateTimeCard([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazCheck> categoryList = await _context.OquvMarkazCheck
                .Where(p => p.active_status == true && p.card > 0
                && (p.created_date_time >= b_date && p.created_date_time <= e_date))
                .Include(p => p.client)
                .Include(p => p.user)
                .Include(p => p.auth)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazCheck>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = categoryList.Count();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationCheckBeetweenDateTimeCash")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationCheckBeetweenDateTimeCash([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazCheck> categoryList = await _context.OquvMarkazCheck
                .Where(p => p.active_status == true && p.cash > 0
                && (p.created_date_time >= b_date && p.created_date_time <= e_date))
                .Include(p => p.client)
                .Include(p => p.user)
                .Include(p => p.auth)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazCheck>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = categoryList.Count();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationCheckBeetweenDateTimeDebit")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationCheckBeetweenDateTimeDebit([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazCheck> categoryList = await _context.OquvMarkazCheck
                .Where(p => p.active_status == true && p.debit > 0
                && (p.created_date_time >= b_date && p.created_date_time <= e_date))
                .Include(p => p.client)
                .Include(p => p.user)
                .Include(p => p.auth)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazCheck>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = categoryList.Count();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationCheckBeetweenDateTimeOnline")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationCheckBeetweenDateTimeOnline([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazCheck> categoryList = await _context.OquvMarkazCheck
                .Where(p => p.active_status == true && p.online > 0
                && (p.created_date_time >= b_date && p.created_date_time <= e_date))
                .Include(p => p.client)
                .Include(p => p.user)
                .Include(p => p.auth)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazCheck>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = categoryList.Count();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationCheckBeetweenDateTimeRasxod")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationCheckBeetweenDateTimeRasxod([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazCheck> categoryList = await _context.OquvMarkazCheck
                .Where(p => p.active_status == true && p.rasxod > 0
                && (p.created_date_time >= b_date && p.created_date_time <= e_date))
                .Include(p => p.client)
                .Include(p => p.user)
                .Include(p => p.auth)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazCheck>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = categoryList.Count();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationCheckBeetweenDateTimeDiscount")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationCheckBeetweenDateTimeDiscount([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazCheck> categoryList = await _context.OquvMarkazCheck
                .Where(p => p.active_status == true && p.discount > 0
                && (p.created_date_time >= b_date && p.created_date_time <= e_date))
                .Include(p => p.client)
                .Include(p => p.user)
                .Include(p => p.auth)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazCheck>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = categoryList.Count();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationCheckBeetweenDateTimeSumm")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationCheckBeetweenDateTimeSumm([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazCheck> categoryList = await _context.OquvMarkazCheck
                .Where(p => p.active_status == true && p.summ > 0
                && (p.created_date_time >= b_date && p.created_date_time <= e_date))
                .Include(p => p.client)
                .Include(p => p.user)
                .Include(p => p.auth)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazCheck>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = categoryList.Count();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // GET: api/OquvMarkazCheck/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazCheck>> GetOquvMarkazCheck(long id)
        {
            var oquvMarkazCheck = await _context.OquvMarkazCheck.FindAsync(id);

            if (oquvMarkazCheck == null)
            {
                return NotFound();
            }

            return oquvMarkazCheck;
        }

        // PUT: api/OquvMarkazCheck/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazCheck(long id, OquvMarkazCheck oquvMarkazCheck)
        {
            if (id != oquvMarkazCheck.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazCheck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazCheckExists(id))
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

        // POST: api/OquvMarkazCheck
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazCheck>> PostOquvMarkazCheck(OquvMarkazCheck oquvMarkazCheck)
        {
            _context.OquvMarkazCheck.Update(oquvMarkazCheck);
            await _context.SaveChangesAsync();

            if (oquvMarkazCheck.debit > 0) {
                List<OquvMarkazDebit> oquvMarkazDebitList = await _context.OquvMarkazDebit
                    .Include(p => p.items)
                    .Include(p => p.client)
                    .Where( p => p.OquvMarkazClientid == oquvMarkazCheck.OquvMarkazClientid).ToListAsync();
                if (oquvMarkazDebitList == null || oquvMarkazDebitList.Count == 0)
                {

                    OquvMarkazDebit debit = new OquvMarkazDebit();
                    debit.active_status = true;
                    debit.summ = oquvMarkazCheck.debit;
                    debit.real_summ = oquvMarkazCheck.debit;
                    debit.OquvMarkazClientid = oquvMarkazCheck.OquvMarkazClientid ?? default(long);

                    OquvMarkazDebitItem debitItem = new OquvMarkazDebitItem();
                    debitItem.active_status = true;
                    debitItem.summ = oquvMarkazCheck.debit;
                    debitItem.OquvMarkazCheckid = oquvMarkazCheck.id;
                    debitItem.debit = debit;

                    List<OquvMarkazDebitItem> debitItems = new List<OquvMarkazDebitItem>();
                    debitItems.Add(debitItem);

                    debit.items = debitItems;

                    _context.OquvMarkazDebit.Update(debit);
                    await _context.SaveChangesAsync();


                }
                else {

                    OquvMarkazDebit debit = oquvMarkazDebitList.First();
                    debit.active_status = true;
                    debit.summ = debit.summ + oquvMarkazCheck.debit;
                    debit.real_summ = debit.real_summ  + oquvMarkazCheck.debit;
                    

                    OquvMarkazDebitItem debitItem = new OquvMarkazDebitItem();
                    debitItem.active_status = true;
                    debitItem.summ = oquvMarkazCheck.debit;
                    debitItem.OquvMarkazCheckid = oquvMarkazCheck.id;
                    debitItem.debit = debit;
                    debit.items.Add(debitItem);
                    _context.OquvMarkazDebit.Update(debit);
                    await _context.SaveChangesAsync();

                }
            }

            return oquvMarkazCheck;
        }


        // DELETE: api/OquvMarkazCheck/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazCheck>> DeleteOquvMarkazCheck(long id)
        {
            var oquvMarkazCheck = await _context.OquvMarkazCheck.FindAsync(id);
            if (oquvMarkazCheck == null)
            {
                return NotFound();
            }

            _context.OquvMarkazCheck.Remove(oquvMarkazCheck);
            await _context.SaveChangesAsync();

            return oquvMarkazCheck;
        }

        private bool OquvMarkazCheckExists(long id)
        {
            return _context.OquvMarkazCheck.Any(e => e.id == id);
        }
    }
}
