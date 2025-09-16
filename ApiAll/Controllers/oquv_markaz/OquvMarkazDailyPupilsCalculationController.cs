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
    public class OquvMarkazDailyPupilsCalculationController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazDailyPupilsCalculationController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazDailyPupilsCalculation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazDailyPupilsCalculation>>> GetOquvMarkazDailyPupilsCalculation()
        {
            return await _context.OquvMarkazDailyPupilsCalculation.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazDailyPupilsCalculation> categoryList = await _context.OquvMarkazDailyPupilsCalculation
                .Include(p => p.group)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazDailyPupilsCalculation>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazDailyPupilsCalculation.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationTeacherBonusList")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationTeacherBonusList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazTeachersBonus> categoryList = await _context.OquvMarkazTeachersBonus
                .Include(p => p.user)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazTeachersBonus>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazTeachersBonus.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationNoAcceptedMain")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationNoAcceptedMain([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazDailyPupilsCalculation> categoryList = await _context
                .OquvMarkazDailyPupilsCalculation
                .Include(p => p.group)
                .ThenInclude(p => p.user)
                .Include(p =>p.group).ThenInclude(p =>p.fan)
            
                .Where(p => p.active_status == true && p.all_accepted_status == false)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazDailyPupilsCalculation>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazDailyPupilsCalculation.Where(p => p.active_status == true && p.all_accepted_status == false).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/OquvMarkazDailyPupilsCalculation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazDailyPupilsCalculation>> GetOquvMarkazDailyPupilsCalculation(long id)
        {
            var oquvMarkazDailyPupilsCalculation = await _context.OquvMarkazDailyPupilsCalculation.FindAsync(id);

            if (oquvMarkazDailyPupilsCalculation == null)
            {
                return NotFound();
            }

            return oquvMarkazDailyPupilsCalculation;
        }

        [HttpGet("acceptAllPupilsAndCalculatedBonus")]
        public async Task<ActionResult<OquvMarkazDailyPupilsCalculation>> acceptAllPupilsAndCalculatedBonus([FromQuery]long caculation_id)
        {
            var oquvMarkazDailyPupilsCalculation = await _context.OquvMarkazDailyPupilsCalculation.FindAsync(caculation_id);

            if (oquvMarkazDailyPupilsCalculation == null)
            {
                return NotFound("Any item not found");
            }

            if (oquvMarkazDailyPupilsCalculation.all_accepted_status) {
                return NotFound("Already accepted");
            }

            oquvMarkazDailyPupilsCalculation.all_accepted_status = true;

            List<OquvMarkazDailyPupilsCalculationInfo> item_list =
                await _context.OquvMarkazDailyPupilsCalculationInfo
                .Where(p => p.OquvMarkazDailyPupilsCalculationid == oquvMarkazDailyPupilsCalculation.id &&
                p.accepted_status_client == false && p.disaccepted_staus_client == false)
                .ToListAsync();


            foreach (OquvMarkazDailyPupilsCalculationInfo itm in item_list) {
                itm.accepted_status_client = true;

                List<OquvMarkazTeachersBonus> bonus = await _context.OquvMarkazTeachersBonus
                    .Where(p => p.OquvMarkazUserid == itm.OquvMarkazUserid)
                    .ToListAsync();

                if (bonus == null || bonus.Count == 0)
                {
                    OquvMarkazTeachersBonus bonus_real = new OquvMarkazTeachersBonus();
                    bonus_real.OquvMarkazUserid = itm.OquvMarkazUserid;
                    bonus_real.active_status = true;
                    bonus_real.real_summ = itm.oqituvchi_bounus;
                    bonus_real.summ = itm.oqituvchi_bounus;
                    _context.OquvMarkazTeachersBonus.Update(bonus_real);
                    await _context.SaveChangesAsync();
                }
                else {

                    bonus.First().real_summ = bonus.First().real_summ + itm.oqituvchi_bounus;
                    bonus.First().summ = bonus.First().summ + itm.oqituvchi_bounus;
                    _context.OquvMarkazTeachersBonus.Update(bonus.First());
                    await _context.SaveChangesAsync();
                }

                OquvMarkazTeachersBonusItem bonus_item = new OquvMarkazTeachersBonusItem();
                bonus_item.OquvMarkazUserid = itm.OquvMarkazUserid;
                bonus_item.summ = itm.oqituvchi_bounus;
                _context.OquvMarkazTeachersBonusItem.Update(bonus_item);
                await _context.SaveChangesAsync();


                _context.OquvMarkazDailyPupilsCalculationInfo.Update(itm);
               await _context.SaveChangesAsync();


                //darsdan ayirish kerak endi
                List<OquvMarkazFanAndGroupPaymentLeftLessons> darslar = await _context.OquvMarkazFanAndGroupPaymentLeftLessons
                    .Where(p =>p.OquvMarkazPupilGroupsid == itm.OquvMarkazPupilGroupsid
                     && p.OquvMarkazClientid == itm.OquvMarkazClientid)
                    .ToListAsync();

                if (darslar != null && darslar.Count > 0) {

                    if (darslar.First().left_real_lessons_count > 0) {

                        darslar.First().left_real_lessons_count = darslar.First().left_real_lessons_count - 1;
                        darslar.First().bonus_summ = darslar.First().bonus_summ - darslar.First().bonus_summ_for_one_lesson;

                        //darslar.First().lessons_count = darslar.First().lessons_count - 1;


                        //bonusdi oqituchnini oyligiga yozib qoyiladi
                        List<OquvMarkazUserSalary> oylikList = await _context.OquvMarkazUserSalary
                            .Where(p => p.OquvMarkazUserid == itm.OquvMarkazUserid).ToListAsync();

                        if (oylikList == null || oylikList.Count == 0)
                        {
                            //oylik yaratldi birinchi martta ekan bu oylik
                            OquvMarkazUserSalary salary = new OquvMarkazUserSalary();
                            salary.real_summ = darslar.First().bonus_summ_for_one_lesson;
                            salary.summ = darslar.First().bonus_summ_for_one_lesson;
                            salary.OquvMarkazUserid = itm.OquvMarkazUserid;
                            salary.active_status = true;

                            _context.OquvMarkazUserSalary.Update(salary);
                            await _context.SaveChangesAsync();


                            OquvMarkazUserSalaryItem salary_item = new OquvMarkazUserSalaryItem();
                            salary_item.OquvMarkazUserSalaryid = salary.id;
                            salary_item.summ = darslar.First().bonus_summ_for_one_lesson;
                            salary_item.OquvMarkazClientid = itm.OquvMarkazClientid;
                            salary_item.OquvMarkazPupilGroupsid = itm.OquvMarkazPupilGroupsid;

                            _context.OquvMarkazUserSalaryItem.Update(salary_item);
                            await _context.SaveChangesAsync();

                        }
                        else
                        {
                            oylikList.First().real_summ = oylikList.First().real_summ + darslar.First().bonus_summ_for_one_lesson; 
                            oylikList.First().summ = oylikList.First().summ + darslar.First().bonus_summ_for_one_lesson;
                            _context.OquvMarkazUserSalary.Update(oylikList.First());
                            await _context.SaveChangesAsync();

                            OquvMarkazUserSalaryItem salary_item = new OquvMarkazUserSalaryItem();
                            salary_item.OquvMarkazUserSalaryid = oylikList.First().id;
                            salary_item.summ = darslar.First().bonus_summ_for_one_lesson;
                            salary_item.OquvMarkazClientid = itm.OquvMarkazClientid;
                            salary_item.OquvMarkazPupilGroupsid = itm.OquvMarkazPupilGroupsid;

                            _context.OquvMarkazUserSalaryItem.Update(salary_item);
                            await _context.SaveChangesAsync();

                        }


                        _context.OquvMarkazFanAndGroupPaymentLeftLessons.Update(darslar.First());
                        await _context.SaveChangesAsync();
                    }




                }



            }

            _context.OquvMarkazDailyPupilsCalculation.Update(oquvMarkazDailyPupilsCalculation);
            await _context.SaveChangesAsync();




            return oquvMarkazDailyPupilsCalculation;
        }

        // PUT: api/OquvMarkazDailyPupilsCalculation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazDailyPupilsCalculation(long id, OquvMarkazDailyPupilsCalculation oquvMarkazDailyPupilsCalculation)
        {
            if (id != oquvMarkazDailyPupilsCalculation.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazDailyPupilsCalculation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazDailyPupilsCalculationExists(id))
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

        // POST: api/OquvMarkazDailyPupilsCalculation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazDailyPupilsCalculation>> PostOquvMarkazDailyPupilsCalculation(OquvMarkazDailyPupilsCalculation oquvMarkazDailyPupilsCalculation)
        {
            _context.OquvMarkazDailyPupilsCalculation.Update(oquvMarkazDailyPupilsCalculation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazDailyPupilsCalculation", new { id = oquvMarkazDailyPupilsCalculation.id }, oquvMarkazDailyPupilsCalculation);
        }

        // DELETE: api/OquvMarkazDailyPupilsCalculation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazDailyPupilsCalculation>> DeleteOquvMarkazDailyPupilsCalculation(long id)
        {
            var oquvMarkazDailyPupilsCalculation = await _context.OquvMarkazDailyPupilsCalculation.FindAsync(id);
            if (oquvMarkazDailyPupilsCalculation == null)
            {
                return NotFound();
            }

            _context.OquvMarkazDailyPupilsCalculation.Remove(oquvMarkazDailyPupilsCalculation);
            await _context.SaveChangesAsync();

            return oquvMarkazDailyPupilsCalculation;
        }

        private bool OquvMarkazDailyPupilsCalculationExists(long id)
        {
            return _context.OquvMarkazDailyPupilsCalculation.Any(e => e.id == id);
        }
    }
}
