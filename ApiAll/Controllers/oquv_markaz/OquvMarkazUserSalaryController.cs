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
    public class OquvMarkazUserSalaryController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazUserSalaryController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazUserSalary
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazUserSalary>>> GetOquvMarkazUserSalary()
        {
            return await _context.OquvMarkazUserSalary.ToListAsync();
        }

        // GET: api/OquvMarkazUserSalary/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazUserSalary>> GetOquvMarkazUserSalary(long id)
        {
            var oquvMarkazUserSalary = await _context.OquvMarkazUserSalary.FindAsync(id);

            if (oquvMarkazUserSalary == null)
            {
                return NotFound();
            }

            return oquvMarkazUserSalary;
        }

        [HttpGet("paySalaryForUser")]
        public async Task<ActionResult<OquvMarkazUserSalary>> paySalaryForUser([FromQuery]long id,[FromQuery] double cash_summ, [FromQuery] double card_summ)
        {
            var oquvMarkazUserSalary = await _context.OquvMarkazUserSalary.FindAsync(id);

            if (oquvMarkazUserSalary == null)
            {
                return NotFound();
            }

            oquvMarkazUserSalary.real_summ = oquvMarkazUserSalary.real_summ - (card_summ + cash_summ);



            _context.OquvMarkazUserSalary.Update(oquvMarkazUserSalary);
            await _context.SaveChangesAsync();

            //info 
            OquvMarkazUserSalaryMonthly info = new OquvMarkazUserSalaryMonthly();
            info.active_status = true;
            info.payed_for_card_summ = card_summ;
            info.OquvMarkazUserid = oquvMarkazUserSalary.OquvMarkazUserid;
            info.summ = card_summ + cash_summ;
            info.real_summ = cash_summ + card_summ;
            info.payed_summ = cash_summ;
            info.year = DateTime.Now.Year;
            info.month = DateTime.Now.Month;

            _context.OquvMarkazUserSalaryMonthly.Update(info);
            await _context.SaveChangesAsync();



            return oquvMarkazUserSalary;
        }


        [HttpGet("getPayForTeacherBonusId")]
        public async Task<ActionResult<OquvMarkazTeachersBonus>> getPayForTeacherBonusId([FromQuery]long bonus_id,[FromQuery] double  summ)
        {
            var bonus = await _context.OquvMarkazTeachersBonus.FindAsync(bonus_id);

            if (bonus == null)
            {
                return NotFound();
            }

            bonus.real_summ = bonus.real_summ - summ;
            _context.OquvMarkazTeachersBonus.Update(bonus);
            await _context.SaveChangesAsync();


            OquvMarkazTeachersBonusItem itm_bonus = new OquvMarkazTeachersBonusItem();
            itm_bonus.active_status = true;
            itm_bonus.OquvMarkazUserid = bonus.OquvMarkazUserid;
            itm_bonus.summ = -summ;

            _context.OquvMarkazTeachersBonusItem.Update(itm_bonus);
            await _context.SaveChangesAsync();


            return bonus;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazUserSalary> categoryList = await _context.OquvMarkazUserSalary
                .Include(p =>p.user)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazUserSalary>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazUserSalary.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationByUserId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByUserId([FromQuery] int page, [FromQuery] int size,[FromQuery] long user_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazUserSalary> categoryList = await _context.OquvMarkazUserSalary
                .Include(p => p.user)
                .Where(p => p.active_status == true && p.OquvMarkazUserid == user_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazUserSalary>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazUserSalary
                .Where(p => p.active_status == true && p.OquvMarkazUserid == user_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationUserBonusList")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationUserBonusList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazTeachersBonus> categoryList = await _context.OquvMarkazTeachersBonus
                .Include(p =>p.user)
                .Where(p => p.active_status == true && p.real_summ > 0)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazTeachersBonus>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazTeachersBonus.Where(p => p.active_status == true && p.real_summ > 0).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationUserBonusPayedItemList")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationUserBonusPayedItemList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazTeachersBonusItem> categoryList = await _context.OquvMarkazTeachersBonusItem
                .Include(p => p.user)
                .Where(p => p.active_status == true && p.summ < 0)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazTeachersBonusItem>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazTeachersBonusItem.Where(p => p.active_status == true && p.summ < 0).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        // PUT: api/OquvMarkazUserSalary/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazUserSalary(long id, OquvMarkazUserSalary oquvMarkazUserSalary)
        {
            if (id != oquvMarkazUserSalary.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazUserSalary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazUserSalaryExists(id))
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

        // POST: api/OquvMarkazUserSalary
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazUserSalary>> PostOquvMarkazUserSalary(OquvMarkazUserSalary oquvMarkazUserSalary)
        {
            _context.OquvMarkazUserSalary.Update(oquvMarkazUserSalary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazUserSalary", new { id = oquvMarkazUserSalary.id }, oquvMarkazUserSalary);
        }

        // DELETE: api/OquvMarkazUserSalary/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazUserSalary>> DeleteOquvMarkazUserSalary(long id)
        {
            var oquvMarkazUserSalary = await _context.OquvMarkazUserSalary.FindAsync(id);
            if (oquvMarkazUserSalary == null)
            {
                return NotFound();
            }

            _context.OquvMarkazUserSalary.Remove(oquvMarkazUserSalary);
            await _context.SaveChangesAsync();

            return oquvMarkazUserSalary;
        }

        private bool OquvMarkazUserSalaryExists(long id)
        {
            return _context.OquvMarkazUserSalary.Any(e => e.id == id);
        }
    }
}
