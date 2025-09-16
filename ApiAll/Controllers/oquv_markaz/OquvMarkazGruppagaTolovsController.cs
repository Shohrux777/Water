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
    public class OquvMarkazGruppagaTolovsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazGruppagaTolovsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazGruppagaTolovs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazGruppagaTolov>>> GetOquvMarkazGruppagaTolov()
        {
            return await _context.OquvMarkazGruppagaTolov.ToListAsync();
        }



        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazGruppagaTolov> categoryList = await _context.OquvMarkazGruppagaTolov
                .Include(p => p.oquvchi)
                .Include(p => p.group)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazGruppagaTolov>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazGruppagaTolov.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getGruppagaTolovByGroupIdAndDate")]
        public async Task<ActionResult<TexPaginationModel>> getGruppagaTolovByGroupIdAndDate([FromQuery] int page, [FromQuery] int size, [FromQuery] long group_id, [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazGruppagaTolov> categoryList = await _context.OquvMarkazGruppagaTolov
                .Include(p => p.oquvchi)
                .Include(p => p.group)
                .Where(p => p.active_status == true
                && p.OquvMarkazPupilGroupsid == group_id
                && (p.created_date_time >= b_date && p.created_date_time <= e_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazGruppagaTolov>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazGruppagaTolov
               .Where(p => p.active_status == true
                && p.OquvMarkazPupilGroupsid == group_id
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getGruppagaTolovByOquvchiIdAndDate")]
        public async Task<ActionResult<TexPaginationModel>> getGruppagaTolovByOquvchiIdAndDate([FromQuery] int page, [FromQuery] int size, [FromQuery] long oquvchi_id, [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazGruppagaTolov> categoryList = await _context.OquvMarkazGruppagaTolov
                .Include(p => p.oquvchi)
                .Include(p => p.group)
                .Where(p => p.active_status == true
                && p.OquvMarkazClientid == oquvchi_id
                && (p.created_date_time >= b_date && p.created_date_time <= e_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazGruppagaTolov>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazGruppagaTolov
               .Where(p => p.active_status == true
                && p.OquvMarkazClientid == oquvchi_id
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getGruppagaTolovByDateTime")]
        public async Task<ActionResult<TexPaginationModel>> getGruppagaTolovByDateTime([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazGruppagaTolov> categoryList = await _context.OquvMarkazGruppagaTolov
                .Include(p => p.oquvchi)
                .Include(p => p.group)
                .Where(p => p.active_status == true
                && (p.created_date_time >= b_date && p.created_date_time <= e_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazGruppagaTolov>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazGruppagaTolov
               .Where(p => p.active_status == true
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/OquvMarkazGruppagaTolovs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazGruppagaTolov>> GetOquvMarkazGruppagaTolov(long id)
        {
            var oquvMarkazGruppagaTolov = await _context.OquvMarkazGruppagaTolov.FindAsync(id);

            if (oquvMarkazGruppagaTolov == null)
            {
                return NotFound();
            }

            return oquvMarkazGruppagaTolov;
        }

        // PUT: api/OquvMarkazGruppagaTolovs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazGruppagaTolov(long id, OquvMarkazGruppagaTolov oquvMarkazGruppagaTolov)
        {
            if (id != oquvMarkazGruppagaTolov.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazGruppagaTolov).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazGruppagaTolovExists(id))
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

        // POST: api/OquvMarkazGruppagaTolovs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazGruppagaTolov>> PostOquvMarkazGruppagaTolov(OquvMarkazGruppagaTolov oquvMarkazGruppagaTolov)
        {
            _context.OquvMarkazGruppagaTolov.Update(oquvMarkazGruppagaTolov);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazGruppagaTolov", new { id = oquvMarkazGruppagaTolov.id }, oquvMarkazGruppagaTolov);
        }

        // DELETE: api/OquvMarkazGruppagaTolovs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazGruppagaTolov>> DeleteOquvMarkazGruppagaTolov(long id)
        {
            var oquvMarkazGruppagaTolov = await _context.OquvMarkazGruppagaTolov.FindAsync(id);
            if (oquvMarkazGruppagaTolov == null)
            {
                return NotFound();
            }

            _context.OquvMarkazGruppagaTolov.Remove(oquvMarkazGruppagaTolov);
            await _context.SaveChangesAsync();

            return oquvMarkazGruppagaTolov;
        }

        private bool OquvMarkazGruppagaTolovExists(long id)
        {
            return _context.OquvMarkazGruppagaTolov.Any(e => e.id == id);
        }
    }
}
