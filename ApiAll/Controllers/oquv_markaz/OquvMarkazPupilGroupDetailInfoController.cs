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
    public class OquvMarkazPupilGroupDetailInfoController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazPupilGroupDetailInfoController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazPupilGroupDetailInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazPupilGroupDetailInfo>>> GetOquvMarkazPupilGroupDetailInfo()
        {
            return await _context.OquvMarkazPupilGroupDetailInfo.ToListAsync();
        }

        // GET: api/OquvMarkazPupilGroupDetailInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazPupilGroupDetailInfo>> GetOquvMarkazPupilGroupDetailInfo(long id)
        {
            var oquvMarkazPupilGroupDetailInfo = await _context.OquvMarkazPupilGroupDetailInfo.FindAsync(id);

            if (oquvMarkazPupilGroupDetailInfo == null)
            {
                return NotFound();
            }

            return oquvMarkazPupilGroupDetailInfo;
        }

        [HttpGet("deleteOquvchiWithStatus")]
        public async Task<ActionResult<OquvMarkazPupilGroupDetailInfo>> deleteOquvchiWithStatus([FromQuery]long pupil_group_detail_info_id,[FromQuery] String note)
        {
            var oquvMarkazPupilGroupDetailInfo = await _context.OquvMarkazPupilGroupDetailInfo
                .Include(p =>p.oquvchi)
                .Where(p => p.id == pupil_group_detail_info_id).ToListAsync();

            if (oquvMarkazPupilGroupDetailInfo == null || oquvMarkazPupilGroupDetailInfo.Count == 0)
            {
                return NotFound();
            }
            oquvMarkazPupilGroupDetailInfo.First().active_status = false;
            oquvMarkazPupilGroupDetailInfo.First().finished_group = false;
            oquvMarkazPupilGroupDetailInfo.First().oquvchi.active_status = false;
            oquvMarkazPupilGroupDetailInfo.First().oquvchi.note = note;
            oquvMarkazPupilGroupDetailInfo.First().updated_date_time = DateTime.Now;

            _context.OquvMarkazPupilGroupDetailInfo.Update(oquvMarkazPupilGroupDetailInfo.First());
            await _context.SaveChangesAsync();

            return oquvMarkazPupilGroupDetailInfo.First();
        }

        // PUT: api/OquvMarkazPupilGroupDetailInfo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazPupilGroupDetailInfo(long id, OquvMarkazPupilGroupDetailInfo oquvMarkazPupilGroupDetailInfo)
        {
            if (id != oquvMarkazPupilGroupDetailInfo.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazPupilGroupDetailInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazPupilGroupDetailInfoExists(id))
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

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazPupilGroupDetailInfo> categoryList = await _context.OquvMarkazPupilGroupDetailInfo
                .Include(p => p.oquvchi)
                .Include(p =>p.group)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazPupilGroupDetailInfo>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazPupilGroupDetailInfo.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationUdalitQilinganlarList")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationUdalitQilinganlarList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazPupilGroupDetailInfo> categoryList = await _context.OquvMarkazPupilGroupDetailInfo
                .Include(p => p.oquvchi)
                .Include(p => p.group)
                .Where(p => p.active_status == false)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazPupilGroupDetailInfo>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazPupilGroupDetailInfo.Where(p => p.active_status == false).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationUdalitQilinganlarListSearcByNote")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationUdalitQilinganlarListSearcByNote([FromQuery] int page, [FromQuery] int size,[FromQuery] String note)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazPupilGroupDetailInfo> categoryList = await _context.OquvMarkazPupilGroupDetailInfo
                .Include(p => p.oquvchi)
                .Include(p => p.group)
                .Where(p => p.active_status == false && p.oquvchi.note.ToLower().Contains(note.ToLower()))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazPupilGroupDetailInfo>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazPupilGroupDetailInfo
                .Where(p => p.active_status == false && p.oquvchi.note.ToLower().Contains(note.ToLower())).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByGroupId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByGroupId([FromQuery] int page, [FromQuery] int size,[FromQuery] long group_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazPupilGroupDetailInfo> categoryList = await _context.OquvMarkazPupilGroupDetailInfo
                .Include(p => p.oquvchi)
                .Include(p => p.group)
                .ThenInclude(p =>p.fan)
                .Where(p => p.active_status == true && p.OquvMarkazPupilGroupsid == group_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazPupilGroupDetailInfo>();
            }

            foreach (OquvMarkazPupilGroupDetailInfo item in categoryList) {
                List<OquvMarkazFanAndGroupPaymentLeftLessons> lesson_list = await _context.OquvMarkazFanAndGroupPaymentLeftLessons
                    .Where(p =>p.OquvMarkazPupilGroupsid == item.OquvMarkazPupilGroupsid &&
                    p.OquvMarkazClientid == item.OquvMarkazClientid)
                    .ToListAsync();

                if (lesson_list != null && lesson_list.Count > 0) {
                    item.lessons_cout = lesson_list.First().left_real_lessons_count;
                }

                item.payments_count = await _context.OquvMarkazFanAndGroupPayment.Where(
                    p => p.OquvMarkazPupilGroupsid == item.OquvMarkazPupilGroupsid
                    && p.OquvMarkazClientid == item.OquvMarkazClientid).CountAsync();

            }

            //bunga tolangan bolsa tolanganlarini listini chiqaraman 

            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazPupilGroupDetailInfo.Where(p => p.active_status == true && p.OquvMarkazPupilGroupsid == group_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // POST: api/OquvMarkazPupilGroupDetailInfo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazPupilGroupDetailInfo>> PostOquvMarkazPupilGroupDetailInfo(OquvMarkazPupilGroupDetailInfo oquvMarkazPupilGroupDetailInfo)
        {
            _context.OquvMarkazPupilGroupDetailInfo.Update(oquvMarkazPupilGroupDetailInfo);
            await _context.SaveChangesAsync();

            List<OquvMarkazFanAndGroupPaymentLeftLessons> lessonList = await _context.OquvMarkazFanAndGroupPaymentLeftLessons
                .Where(p => p.OquvMarkazPupilGroupsid == oquvMarkazPupilGroupDetailInfo.OquvMarkazPupilGroupsid
                && p.OquvMarkazClientid == oquvMarkazPupilGroupDetailInfo.OquvMarkazClientid)
                .ToListAsync();


            if (lessonList == null  || lessonList.Count == 0) {
                OquvMarkazFanAndGroupPaymentLeftLessons lessons = new OquvMarkazFanAndGroupPaymentLeftLessons();
                lessons.active_status = true;
                lessons.OquvMarkazClientid = oquvMarkazPupilGroupDetailInfo.OquvMarkazClientid;
                lessons.OquvMarkazPupilGroupsid = oquvMarkazPupilGroupDetailInfo.OquvMarkazPupilGroupsid;
                lessons.left_real_lessons_count = 0;
                lessons.bonus_summ = 0.0;
                lessons.bonus_summ_for_one_lesson = 0.0;
                lessons.lessons_count = 0;

                _context.OquvMarkazFanAndGroupPaymentLeftLessons.Update(lessons);
                await _context.SaveChangesAsync();

            }

            return oquvMarkazPupilGroupDetailInfo;
        }

        // DELETE: api/OquvMarkazPupilGroupDetailInfo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazPupilGroupDetailInfo>> DeleteOquvMarkazPupilGroupDetailInfo(long id)
        {
            var oquvMarkazPupilGroupDetailInfo = await _context.OquvMarkazPupilGroupDetailInfo.FindAsync(id);
            if (oquvMarkazPupilGroupDetailInfo == null)
            {
                return NotFound();
            }

            _context.OquvMarkazPupilGroupDetailInfo.Remove(oquvMarkazPupilGroupDetailInfo);
            await _context.SaveChangesAsync();

            return oquvMarkazPupilGroupDetailInfo;
        }

        private bool OquvMarkazPupilGroupDetailInfoExists(long id)
        {
            return _context.OquvMarkazPupilGroupDetailInfo.Any(e => e.id == id);
        }
    }
}
