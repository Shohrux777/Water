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
    public class OquvMarkazDailyPupilsCalculationInfoController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazDailyPupilsCalculationInfoController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazDailyPupilsCalculationInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazDailyPupilsCalculationInfo>>> GetOquvMarkazDailyPupilsCalculationInfo()
        {
            return await _context.OquvMarkazDailyPupilsCalculationInfo.ToListAsync();
        }

        // GET: api/OquvMarkazDailyPupilsCalculationInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazDailyPupilsCalculationInfo>> GetOquvMarkazDailyPupilsCalculationInfo(long id)
        {
            var oquvMarkazDailyPupilsCalculationInfo = await _context.OquvMarkazDailyPupilsCalculationInfo.FindAsync(id);

            if (oquvMarkazDailyPupilsCalculationInfo == null)
            {
                return NotFound();
            }

            return oquvMarkazDailyPupilsCalculationInfo;
        }

        [HttpGet("getDisableNotComePupilForLessons")]
        public async Task<ActionResult<OquvMarkazDailyPupilsCalculationInfo>> getDisableNotComePupilForLessons([FromQuery]long id)
        {
            var oquvMarkazDailyPupilsCalculationInfo = await _context.OquvMarkazDailyPupilsCalculationInfo.FindAsync(id);

            if (oquvMarkazDailyPupilsCalculationInfo == null)
            {
                return NotFound();
            }
            oquvMarkazDailyPupilsCalculationInfo.disaccepted_staus_client = true;
            _context.OquvMarkazDailyPupilsCalculationInfo.Update(oquvMarkazDailyPupilsCalculationInfo);
            await _context.SaveChangesAsync();

            return oquvMarkazDailyPupilsCalculationInfo;
        }

        [HttpGet("getAllCalculatedLessonsList")]
        public async Task<ActionResult<OquvMarkazDailyPupilsCalculationInfo>> getAllCalculatedLessonsList([FromQuery] DateTime date)
        {
            List<OquvMarkazDailyPupilsCalculation> list = await _context.OquvMarkazDailyPupilsCalculation
                .Include(p => p.item_list)
                .Where(p =>p.date_only.Date == date.Date)
                .ToListAsync();

            if (list == null || list.Count == 0)
            {
                DayOfWeek week_day = date.Date.DayOfWeek;
                int day_of_week = -1;

                if (week_day == DayOfWeek.Monday)
                {
                    day_of_week = 0;
                }
                else if (week_day == DayOfWeek.Tuesday)
                {
                    day_of_week = 1;
                }
                else if (week_day == DayOfWeek.Wednesday)
                {
                    day_of_week = 2;
                }
                else if (week_day == DayOfWeek.Thursday)
                {
                    day_of_week = 3;
                }
                else if (week_day == DayOfWeek.Friday)
                {
                    day_of_week = 4;
                }
                else if (week_day == DayOfWeek.Saturday)
                {
                    day_of_week = 5;
                }
                else if (week_day == DayOfWeek.Sunday)
                {
                    day_of_week = 6;
                }

                if (day_of_week == -1)
                {
                    return NotFound("Incorrect data format oy day");
                }

                List<OquvMarkazPupilGroups> groupsList = await _context.OquvMarkazPupilGroups
                    .Include(p => p.fan)
                    .Where(p => p.finish_group == false && p.opened_group_status == true && p.week_days.Contains(day_of_week))
                    .ToListAsync();

                if (groupsList == null || groupsList.Count == 0)
                {
                    return NotFound("Any lessons found in this day");
                }

                List<OquvMarkazDailyPupilsCalculation> main_item_list = new List<OquvMarkazDailyPupilsCalculation>();

                foreach (OquvMarkazPupilGroups it in groupsList)
                {

                    OquvMarkazDailyPupilsCalculation item = new OquvMarkazDailyPupilsCalculation();
                    item.active_status = true;
                    item.OquvMarkazPupilGroupsid = it.id;
                    main_item_list.Add(item);

                    List<OquvMarkazPupilGroupDetailInfo> detail_list = await _context.OquvMarkazPupilGroupDetailInfo
                        .Where(p => p.OquvMarkazPupilGroupsid == it.id && p.finished_group == false)
                        .ToListAsync();


                    List<OquvMarkazDailyPupilsCalculationInfo> i_items = new List<OquvMarkazDailyPupilsCalculationInfo>();
                    item.item_list = i_items;
                    foreach (OquvMarkazPupilGroupDetailInfo itm in detail_list)
                    {
                        OquvMarkazDailyPupilsCalculationInfo itm_info_cal = new OquvMarkazDailyPupilsCalculationInfo();
                        itm_info_cal.active_status = true;
                        itm_info_cal.OquvMarkazPupilGroupsid = it.id;
                        itm_info_cal.OquvMarkazClientid = itm.OquvMarkazClientid;
                        itm_info_cal.OquvMarkazUserid = it.OquvMarkazUserid;
                        itm_info_cal.oqituvchi_bounus = it.fan.summ_for_teacher;

                        i_items.Add(itm_info_cal);

                    }

                }



                _context.OquvMarkazDailyPupilsCalculation.UpdateRange(main_item_list);
                await _context.SaveChangesAsync();


            }
            else {
                DayOfWeek week_day = date.Date.DayOfWeek;
                int day_of_week = -1;

                if (week_day == DayOfWeek.Monday)
                {
                    day_of_week = 0;
                }
                else if (week_day == DayOfWeek.Tuesday)
                {
                    day_of_week = 1;
                }
                else if (week_day == DayOfWeek.Wednesday)
                {
                    day_of_week = 2;
                }
                else if (week_day == DayOfWeek.Thursday)
                {
                    day_of_week = 3;
                }
                else if (week_day == DayOfWeek.Friday)
                {
                    day_of_week = 4;
                }
                else if (week_day == DayOfWeek.Saturday)
                {
                    day_of_week = 5;
                }
                else if (week_day == DayOfWeek.Sunday)
                {
                    day_of_week = 6;
                }

                if (day_of_week == -1)
                {
                    return NotFound("Incorrect data format oy day");
                }

                List<OquvMarkazPupilGroups> groupsList = await _context.OquvMarkazPupilGroups
                    .Include(p => p.fan)
                    .Where(p => p.finish_group == false && p.opened_group_status == true && p.week_days.Contains(day_of_week))
                    .ToListAsync();

                if (groupsList == null || groupsList.Count == 0)
                {
                    return NotFound("Any lessons found in this day");
                }

                List<OquvMarkazDailyPupilsCalculation> main_item_list = new List<OquvMarkazDailyPupilsCalculation>();

                foreach (OquvMarkazPupilGroups it in groupsList)
                {

                    OquvMarkazDailyPupilsCalculation item = new OquvMarkazDailyPupilsCalculation();
                    item.active_status = true;
                    item.OquvMarkazPupilGroupsid = it.id;
                    main_item_list.Add(item);

                    List<OquvMarkazPupilGroupDetailInfo> detail_list = await _context.OquvMarkazPupilGroupDetailInfo
                        .Where(p => p.OquvMarkazPupilGroupsid == it.id && p.finished_group == false)
                        .ToListAsync();


                    List<OquvMarkazDailyPupilsCalculationInfo> i_items = new List<OquvMarkazDailyPupilsCalculationInfo>();
                    item.item_list = i_items;
                    foreach (OquvMarkazPupilGroupDetailInfo itm in detail_list)
                    {
                        OquvMarkazDailyPupilsCalculationInfo itm_info_cal = new OquvMarkazDailyPupilsCalculationInfo();
                        itm_info_cal.active_status = true;
                        itm_info_cal.OquvMarkazPupilGroupsid = it.id;
                        itm_info_cal.OquvMarkazClientid = itm.OquvMarkazClientid;
                        itm_info_cal.OquvMarkazUserid = it.OquvMarkazUserid;
                        itm_info_cal.oqituvchi_bounus = it.fan.summ_for_teacher;

                        i_items.Add(itm_info_cal);

                    }

                }

                List<OquvMarkazDailyPupilsCalculation> not_added_groups = new List<OquvMarkazDailyPupilsCalculation>();

                foreach (OquvMarkazDailyPupilsCalculation itm in main_item_list) {
                    //update if new item added

                    bool need_to_add = true;
                    foreach (OquvMarkazDailyPupilsCalculation it_n in list) {

                        if (it_n.OquvMarkazPupilGroupsid == itm.OquvMarkazPupilGroupsid) {
                            need_to_add = false;
                        }

                    }

                    if (need_to_add) {
                        not_added_groups.Add(itm);
                    }
                }

                if (not_added_groups.Count  > 0) {
                    _context.OquvMarkazDailyPupilsCalculation.UpdateRange(not_added_groups);
                    await _context.SaveChangesAsync();
                }


                //endi qoshilmagan oquvchilardi qaytadan topamiz
                foreach (OquvMarkazDailyPupilsCalculation it_n in list)
                {
                    foreach (OquvMarkazDailyPupilsCalculation itm in main_item_list)
                    {
                        if (itm.OquvMarkazPupilGroupsid == it_n.OquvMarkazPupilGroupsid) {

                            if (itm.item_list != null && it_n.item_list != null) {
                                Console.WriteLine("C1: " + itm.item_list.Count + " C2: " + it_n.item_list.Count);

                                if (itm.item_list.Count > it_n.item_list.Count) {
                                    List<OquvMarkazDailyPupilsCalculationInfo> inf_list = new List<OquvMarkazDailyPupilsCalculationInfo>();

                                    foreach (OquvMarkazDailyPupilsCalculationInfo mt in itm.item_list) {
                                        bool need_add_val = true;

                                        foreach (OquvMarkazDailyPupilsCalculationInfo lmt in it_n.item_list) {
                                            if (lmt.OquvMarkazClientid == mt.OquvMarkazClientid) {
                                                need_add_val = false;
                                            }
                                        }

                                        if (need_add_val) {
                                            //topilmadi yangi bola ekan qoshish kerak
                                            
                                            inf_list.Add(mt);
                                        }



                                    }

                                    if (inf_list.Count > 0) {
                                        //kotta demak bor yangi oquvchi oqshish kerak
                                        it_n.item_list.AddRange(inf_list);

                                    }


                                }


                            }
                            else {
                                Console.WriteLine("ITEMS NOT GET ------>>>>>>");
                            }


                        }


                    }
                }


                //update list agar yangi bola qoshilsa
                _context.OquvMarkazDailyPupilsCalculation.UpdateRange(list);
                await _context.SaveChangesAsync();

            }

            return new OquvMarkazDailyPupilsCalculationInfo();
        }

        [HttpGet("getPaginationAcceptedList")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationAcceptedList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazDailyPupilsCalculationInfo> categoryList = await _context.OquvMarkazDailyPupilsCalculationInfo
                .Include(p => p.group)
                .Include(p => p.user)
                .Include(p => p.client)

                .Where(p => p.accepted_status_client == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazDailyPupilsCalculationInfo>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazDailyPupilsCalculationInfo.Where(p => p.accepted_status_client == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationNotAcceptedList")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationNotAcceptedList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazDailyPupilsCalculationInfo> categoryList = await _context.OquvMarkazDailyPupilsCalculationInfo
                .Include(p => p.group)
                .Include(p => p.user)
                .Include(p => p.client)

                .Where(p => p.accepted_status_client == false)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazDailyPupilsCalculationInfo>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazDailyPupilsCalculationInfo.Where(p => p.accepted_status_client == false).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationDisAcceptedList")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationDisAcceptedList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazDailyPupilsCalculationInfo> categoryList = await _context.OquvMarkazDailyPupilsCalculationInfo
                .Include(p => p.group)
                .Include(p => p.user)
                .Include(p => p.client)

                .Where(p => p.disaccepted_staus_client == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazDailyPupilsCalculationInfo>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazDailyPupilsCalculationInfo.Where(p => p.disaccepted_staus_client == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazDailyPupilsCalculationInfo> categoryList = await _context.OquvMarkazDailyPupilsCalculationInfo
                .Include(p => p.group)
                .Include(p => p.user)
                .Include(p => p.client)

                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazDailyPupilsCalculationInfo>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazDailyPupilsCalculationInfo.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByMainCalculationIdForView")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByMainCalculationIdForView([FromQuery] int page, [FromQuery] int size,[FromQuery] long calc_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazDailyPupilsCalculationInfo> categoryList = await _context.OquvMarkazDailyPupilsCalculationInfo
                .Include(p => p.group)
                .Include(p => p.user)
                .Include(p => p.client)

                .Where(p => p.active_status == true && p.OquvMarkazDailyPupilsCalculationid == calc_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazDailyPupilsCalculationInfo>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazDailyPupilsCalculationInfo.Where(p => p.active_status == true && p.OquvMarkazDailyPupilsCalculationid == calc_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/OquvMarkazDailyPupilsCalculationInfo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazDailyPupilsCalculationInfo(long id, OquvMarkazDailyPupilsCalculationInfo oquvMarkazDailyPupilsCalculationInfo)
        {
            if (id != oquvMarkazDailyPupilsCalculationInfo.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazDailyPupilsCalculationInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazDailyPupilsCalculationInfoExists(id))
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

        // POST: api/OquvMarkazDailyPupilsCalculationInfo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazDailyPupilsCalculationInfo>> PostOquvMarkazDailyPupilsCalculationInfo(OquvMarkazDailyPupilsCalculationInfo oquvMarkazDailyPupilsCalculationInfo)
        {
            _context.OquvMarkazDailyPupilsCalculationInfo.Update(oquvMarkazDailyPupilsCalculationInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazDailyPupilsCalculationInfo", new { id = oquvMarkazDailyPupilsCalculationInfo.id }, oquvMarkazDailyPupilsCalculationInfo);
        }

        // DELETE: api/OquvMarkazDailyPupilsCalculationInfo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazDailyPupilsCalculationInfo>> DeleteOquvMarkazDailyPupilsCalculationInfo(long id)
        {
            var oquvMarkazDailyPupilsCalculationInfo = await _context.OquvMarkazDailyPupilsCalculationInfo.FindAsync(id);
            if (oquvMarkazDailyPupilsCalculationInfo == null)
            {
                return NotFound();
            }

            _context.OquvMarkazDailyPupilsCalculationInfo.Remove(oquvMarkazDailyPupilsCalculationInfo);
            await _context.SaveChangesAsync();

            return oquvMarkazDailyPupilsCalculationInfo;
        }

        private bool OquvMarkazDailyPupilsCalculationInfoExists(long id)
        {
            return _context.OquvMarkazDailyPupilsCalculationInfo.Any(e => e.id == id);
        }
    }
}
