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
    public class OquvMarkazFanAndGroupPaymentController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazFanAndGroupPaymentController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazFanAndGroupPayment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazFanAndGroupPayment>>> GetOquvMarkazFanAndGroupPayment()
        {
            return await _context.OquvMarkazFanAndGroupPayment.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazFanAndGroupPayment> categoryList = await _context.OquvMarkazFanAndGroupPayment
                .Where(p => p.active_status == true)
                .Include(p => p.client)
                .Include(p =>p.group)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazFanAndGroupPayment>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazFanAndGroupPayment.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByClientId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByClientId([FromQuery] int page,
            [FromQuery] int size,[FromQuery] long client_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazFanAndGroupPayment> categoryList = await _context.OquvMarkazFanAndGroupPayment
                .Where(p => p.active_status == true && p.OquvMarkazClientid == client_id)
                .Include(p => p.client)
                .Include(p => p.group)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazFanAndGroupPayment>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazFanAndGroupPayment.Where(p => p.active_status == true && p.OquvMarkazClientid == client_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationByClientIdAndGroupId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByClientIdAndGroupId([FromQuery] int page,
    [FromQuery] int size, [FromQuery] long client_id,[FromQuery] long group_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazFanAndGroupPayment> categoryList = await _context.OquvMarkazFanAndGroupPayment
                .Where(p => p.active_status == true
                && p.OquvMarkazClientid == client_id
                && p.OquvMarkazPupilGroupsid == group_id)
                .Include(p => p.client)
                .Include(p => p.group)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazFanAndGroupPayment>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazFanAndGroupPayment.Where(p => p.active_status == true
            && p.OquvMarkazClientid == client_id
            && p.OquvMarkazPupilGroupsid == group_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/OquvMarkazFanAndGroupPayment/5
        [HttpGet("getPayFormarkazAndGroupPupil")]
        public async Task<ActionResult<OquvMarkazFanAndGroupPayment>> getPayFormarkazAndGroupPupil([FromQuery] long id,[FromQuery] int dars_soni, [FromQuery] int otilgan_dars_soni,[FromQuery] double bonus_summ,[FromQuery]long user_id)
        {
            var oquvMarkazFanAndGroupPayment = await _context.OquvMarkazFanAndGroupPayment
                .Include(p =>p.client)
                .Include(p =>p.group)
                .Where(p =>p.id == id).ToListAsync();

            if (oquvMarkazFanAndGroupPayment == null || oquvMarkazFanAndGroupPayment.Count == 0)
            {
                return NotFound();
            }

            List<OquvMarkazFanAndGroupPaymentLeftLessons> leftLessons = await _context.OquvMarkazFanAndGroupPaymentLeftLessons
                .Where(p => p.OquvMarkazClientid == oquvMarkazFanAndGroupPayment.First().OquvMarkazClientid
                 && p.OquvMarkazPupilGroupsid == oquvMarkazFanAndGroupPayment.First().OquvMarkazPupilGroupsid).ToListAsync();

            if (leftLessons != null && leftLessons.Count > 0)
            {
                //qogan darslarga qoshildi
                leftLessons.First().left_real_lessons_count = leftLessons.First().left_real_lessons_count
                    + dars_soni;

                leftLessons.First().lessons_count = leftLessons.First().lessons_count
                    + dars_soni;

                leftLessons.First().bonus_summ = leftLessons.First().bonus_summ + bonus_summ;

                leftLessons.First().bonus_summ_for_one_lesson = leftLessons.First().bonus_summ / leftLessons.First().left_real_lessons_count;


                _context.OquvMarkazFanAndGroupPaymentLeftLessons.Update(leftLessons.First());
                await _context.SaveChangesAsync();
            }
            else {
                OquvMarkazFanAndGroupPaymentLeftLessons lessons = new OquvMarkazFanAndGroupPaymentLeftLessons();
                lessons.active_status = true;
                lessons.OquvMarkazClientid = oquvMarkazFanAndGroupPayment.First().OquvMarkazClientid;
                lessons.OquvMarkazPupilGroupsid = oquvMarkazFanAndGroupPayment.First().OquvMarkazPupilGroupsid;
                lessons.left_real_lessons_count = dars_soni;
                lessons.lessons_count = dars_soni;
                lessons.bonus_summ = bonus_summ;
                lessons.bonus_summ_for_one_lesson = bonus_summ / dars_soni;

                _context.OquvMarkazFanAndGroupPaymentLeftLessons.Update(lessons);
                await _context.SaveChangesAsync();

            }

            return oquvMarkazFanAndGroupPayment.First();
        }



        // GET: api/OquvMarkazFanAndGroupPayment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazFanAndGroupPayment>> GetOquvMarkazFanAndGroupPayment(long id)
        {
            var oquvMarkazFanAndGroupPayment = await _context.OquvMarkazFanAndGroupPayment.FindAsync(id);

            if (oquvMarkazFanAndGroupPayment == null)
            {
                return NotFound();
            }

            return oquvMarkazFanAndGroupPayment;
        }

        // PUT: api/OquvMarkazFanAndGroupPayment/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazFanAndGroupPayment(long id, OquvMarkazFanAndGroupPayment oquvMarkazFanAndGroupPayment)
        {
            if (id != oquvMarkazFanAndGroupPayment.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazFanAndGroupPayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazFanAndGroupPaymentExists(id))
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

        // POST: api/OquvMarkazFanAndGroupPayment
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazFanAndGroupPayment>> PostOquvMarkazFanAndGroupPayment(OquvMarkazFanAndGroupPayment oquvMarkazFanAndGroupPayment)
        {
            _context.OquvMarkazFanAndGroupPayment.Update(oquvMarkazFanAndGroupPayment);
            await _context.SaveChangesAsync();

            if (oquvMarkazFanAndGroupPayment.otilgan_dars_soni > 0) {
                double bonus_sum = (oquvMarkazFanAndGroupPayment.all_summ / oquvMarkazFanAndGroupPayment.dars_soni)
                    * oquvMarkazFanAndGroupPayment.otilgan_dars_soni;

                oquvMarkazFanAndGroupPayment.dars_soni = oquvMarkazFanAndGroupPayment.dars_soni - oquvMarkazFanAndGroupPayment.otilgan_dars_soni;
                oquvMarkazFanAndGroupPayment.all_summ = oquvMarkazFanAndGroupPayment.all_summ - bonus_sum;

                //bonusdi oqituchnini oyligiga yozib qoyiladi
                List<OquvMarkazUserSalary> oylikList = await _context.OquvMarkazUserSalary
                    .Where(p => p.OquvMarkazUserid == oquvMarkazFanAndGroupPayment.user_id).ToListAsync();

                if (oylikList == null || oylikList.Count == 0)
                {
                    //oylik yaratldi birinchi martta ekan bu oylik
                    OquvMarkazUserSalary salary = new OquvMarkazUserSalary();
                    salary.real_summ = bonus_sum;
                    salary.summ = bonus_sum;
                    salary.OquvMarkazUserid = oquvMarkazFanAndGroupPayment.user_id;
                    salary.active_status = true;

                    _context.OquvMarkazUserSalary.Update(salary);
                    await _context.SaveChangesAsync();

                    OquvMarkazUserSalaryItem salary_item = new OquvMarkazUserSalaryItem();
                    salary_item.OquvMarkazUserSalaryid = salary.id;
                    salary_item.summ = bonus_sum;
                    salary_item.OquvMarkazClientid = oquvMarkazFanAndGroupPayment.OquvMarkazClientid;
                    salary_item.OquvMarkazPupilGroupsid = oquvMarkazFanAndGroupPayment.OquvMarkazPupilGroupsid;

                    _context.OquvMarkazUserSalaryItem.Update(salary_item);
                    await _context.SaveChangesAsync();

                }
                else {
                    oylikList.First().real_summ = oylikList.First().real_summ + bonus_sum;
                    oylikList.First().summ = oylikList.First().summ + bonus_sum;
                    _context.OquvMarkazUserSalary.Update(oylikList.First());
                    await _context.SaveChangesAsync();

                    OquvMarkazUserSalaryItem salary_item = new OquvMarkazUserSalaryItem();
                    salary_item.OquvMarkazUserSalaryid = oylikList.First().id;
                    salary_item.summ = bonus_sum;
                    salary_item.OquvMarkazClientid = oquvMarkazFanAndGroupPayment.OquvMarkazClientid;
                    salary_item.OquvMarkazPupilGroupsid = oquvMarkazFanAndGroupPayment.OquvMarkazPupilGroupsid;

                    _context.OquvMarkazUserSalaryItem.Update(salary_item);
                    await _context.SaveChangesAsync();

                }


            }

            await getPayFormarkazAndGroupPupil(oquvMarkazFanAndGroupPayment.id,
                oquvMarkazFanAndGroupPayment.dars_soni,
                oquvMarkazFanAndGroupPayment.otilgan_dars_soni,
                oquvMarkazFanAndGroupPayment.all_summ,
                oquvMarkazFanAndGroupPayment.user_id);

   

            return oquvMarkazFanAndGroupPayment;
        }

        // DELETE: api/OquvMarkazFanAndGroupPayment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazFanAndGroupPayment>> DeleteOquvMarkazFanAndGroupPayment(long id)
        {
            var oquvMarkazFanAndGroupPayment = await _context.OquvMarkazFanAndGroupPayment.FindAsync(id);
            if (oquvMarkazFanAndGroupPayment == null)
            {
                return NotFound();
            }

            _context.OquvMarkazFanAndGroupPayment.Remove(oquvMarkazFanAndGroupPayment);
            await _context.SaveChangesAsync();

            return oquvMarkazFanAndGroupPayment;
        }

        private bool OquvMarkazFanAndGroupPaymentExists(long id)
        {
            return _context.OquvMarkazFanAndGroupPayment.Any(e => e.id == id);
        }
    }
}
