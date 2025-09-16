using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil.sewextrawork;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tekistil.sewextrawork
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexSewExtraWorkController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexSewExtraWorkController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexSewExtraWork
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexSewExtraWork>>> GetTexSewExtraWork()
        {
            return await _context.TexSewExtraWork.ToListAsync();
        }

        // GET: api/TexSewExtraWork/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexSewExtraWork>> GetTexSewExtraWork(long id)
        {
            var texSewExtraWork = await _context.TexSewExtraWork.FindAsync(id);

            if (texSewExtraWork == null)
            {
                return NotFound();
            }

            return texSewExtraWork;
        }

        [HttpGet("getFullInfoSewExtraWork")]
        public async Task<ActionResult<TexSewExtraWork>> getFullInfoSewExtraWork([FromQuery]long sew_extra_work_id)
        {
            var texSewExtraWork = await _context.TexSewExtraWork
                .Where(p=>p.id==sew_extra_work_id)
                .Include(p => p.texSewOrder)
                .Include(p => p.texPlanning)
                .Include(p => p.texProduct)
                .Include(p => p.contragent)
                .Include(p => p.authorization)
                .Include(p => p.item_list)
                .Include(p => p.texProduct)
                .ToListAsync();

            if (texSewExtraWork == null || texSewExtraWork.Count == 0)
            {
                return NotFound();
            }

            return texSewExtraWork.First();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexSewExtraWork> categoryList = await _context.TexSewExtraWork.Where(p => p.active_status == true)
                .Include(p => p.texSewOrder)
                .Include(p => p.texPlanning)
                .Include(p => p.texProduct)
                .Include(p => p.contragent)
                .Include(p => p.authorization)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TexSewExtraWork>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TexSewExtraWork.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationFinished")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationFinished([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexSewExtraWork> categoryList = await _context.TexSewExtraWork
                .Where(p => p.active_status == true && p.end_status == true)
                .Include(p => p.texSewOrder)
                .Include(p => p.texPlanning)
                .Include(p => p.texProduct)
                .Include(p => p.contragent)
                .Include(p => p.authorization)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TexSewExtraWork>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TexSewExtraWork.Where(p => p.active_status == true && p.end_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationNotStarted")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationNotStarted([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexSewExtraWork> categoryList = await _context.TexSewExtraWork
                .Where(p => p.active_status == true && p.start_status == false)
                .Include(p => p.texSewOrder)
                .Include(p => p.texPlanning)
                .Include(p => p.texProduct)
                .Include(p => p.contragent)
                .Include(p => p.authorization)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TexSewExtraWork>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TexSewExtraWork.Where(p => p.active_status == true && p.start_status == false).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationNotFinished")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationNotFinished([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexSewExtraWork> categoryList = await _context.TexSewExtraWork
                .Where(p => p.active_status == true && p.end_status == false && p.start_status == true)
                .Include(p => p.texSewOrder)
                .Include(p => p.texPlanning)
                .Include(p => p.texProduct)
                .Include(p => p.contragent)
                .Include(p => p.authorization)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TexSewExtraWork>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TexSewExtraWork.Where(p => p.active_status == true && p.end_status == false && p.start_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationvaqtidanOtibKetganlar")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationvaqtidanOtibKetganlar([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexSewExtraWork> categoryList = await _context.TexSewExtraWork
                .Where(p => p.active_status == true && p.end_status == false  && p.tahminiy_tugah_vaqti <= DateTime.Now)
                .Include(p => p.texSewOrder)
                .Include(p => p.texPlanning)
                .Include(p => p.texProduct)
                .Include(p => p.contragent)
                .Include(p => p.authorization)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TexSewExtraWork>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TexSewExtraWork.Where(p => p.active_status == true && p.end_status == false && p.tahminiy_tugah_vaqti <= DateTime.Now).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/TexSewExtraWork/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexSewExtraWork(long id, TexSewExtraWork texSewExtraWork)
        {
            if (id != texSewExtraWork.id)
            {
                return BadRequest();
            }

            _context.Entry(texSewExtraWork).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexSewExtraWorkExists(id))
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

        // POST: api/TexSewExtraWork
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexSewExtraWork>> PostTexSewExtraWork(TexSewExtraWork texSewExtraWork)
        {
            _context.TexSewExtraWork.Update(texSewExtraWork);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexSewExtraWork", new { id = texSewExtraWork.id }, texSewExtraWork);
        }

        // DELETE: api/TexSewExtraWork/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexSewExtraWork>> DeleteTexSewExtraWork(long id)
        {
            var texSewExtraWork = await _context.TexSewExtraWork.FindAsync(id);
            if (texSewExtraWork == null)
            {
                return NotFound();
            }

            _context.TexSewExtraWork.Remove(texSewExtraWork);
            await _context.SaveChangesAsync();

            return texSewExtraWork;
        }

        private bool TexSewExtraWorkExists(long id)
        {
            return _context.TexSewExtraWork.Any(e => e.id == id);
        }
    }
}
