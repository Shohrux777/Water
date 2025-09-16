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
    public class OquvMarkazUserSalaryItemController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazUserSalaryItemController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazUserSalaryItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazUserSalaryItem>>> GetOquvMarkazUserSalaryItem()
        {
            return await _context.OquvMarkazUserSalaryItem.ToListAsync();
        }

        // GET: api/OquvMarkazUserSalaryItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazUserSalaryItem>> GetOquvMarkazUserSalaryItem(long id)
        {
            var oquvMarkazUserSalaryItem = await _context.OquvMarkazUserSalaryItem.FindAsync(id);

            if (oquvMarkazUserSalaryItem == null)
            {
                return NotFound();
            }

            return oquvMarkazUserSalaryItem;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazUserSalaryItem> categoryList = await _context.OquvMarkazUserSalaryItem
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazUserSalaryItem>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazUserSalaryItem.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationSalaryInDetail")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationSalaryInDetail([FromQuery] int page, [FromQuery] int size, [FromQuery] long salary_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazUserSalaryItem> categoryList = await _context.OquvMarkazUserSalaryItem
                .Include(p => p.oquvchi)
                .Include(p => p.group)
                .Where(p => p.active_status == true && p.OquvMarkazUserSalaryid == salary_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazUserSalaryItem>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazUserSalaryItem
                .Where(p => p.active_status == true && p.OquvMarkazUserSalaryid == salary_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationSalaryInDetailBeatweenDate")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationSalaryInDetailBeatweenDate([FromQuery] int page,
            [FromQuery] int size, [FromQuery] long salary_id,[FromQuery] DateTime begin_date,[FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazUserSalaryItem> categoryList = await _context.OquvMarkazUserSalaryItem
                .Include(p => p.oquvchi)
                .Include(p => p.group)
                .Where(p => p.active_status == true
                && p.OquvMarkazUserSalaryid == salary_id
                &&(p .date_time >= begin_date && p.date_time <= end_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazUserSalaryItem>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazUserSalaryItem
                  .Where(p => p.active_status == true
                && p.OquvMarkazUserSalaryid == salary_id
                && (p.date_time >= begin_date && p.date_time <= end_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/OquvMarkazUserSalaryItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazUserSalaryItem(long id, OquvMarkazUserSalaryItem oquvMarkazUserSalaryItem)
        {
            if (id != oquvMarkazUserSalaryItem.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazUserSalaryItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazUserSalaryItemExists(id))
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

        // POST: api/OquvMarkazUserSalaryItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazUserSalaryItem>> PostOquvMarkazUserSalaryItem(OquvMarkazUserSalaryItem oquvMarkazUserSalaryItem)
        {
            _context.OquvMarkazUserSalaryItem.Update(oquvMarkazUserSalaryItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazUserSalaryItem", new { id = oquvMarkazUserSalaryItem.id }, oquvMarkazUserSalaryItem);
        }

        // DELETE: api/OquvMarkazUserSalaryItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazUserSalaryItem>> DeleteOquvMarkazUserSalaryItem(long id)
        {
            var oquvMarkazUserSalaryItem = await _context.OquvMarkazUserSalaryItem.FindAsync(id);
            if (oquvMarkazUserSalaryItem == null)
            {
                return NotFound();
            }

            _context.OquvMarkazUserSalaryItem.Remove(oquvMarkazUserSalaryItem);
            await _context.SaveChangesAsync();

            return oquvMarkazUserSalaryItem;
        }

        private bool OquvMarkazUserSalaryItemExists(long id)
        {
            return _context.OquvMarkazUserSalaryItem.Any(e => e.id == id);
        }
    }
}
