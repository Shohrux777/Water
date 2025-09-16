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
    public class OquvMarkazBookAndGroupDetilsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazBookAndGroupDetilsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazBookAndGroupDetils
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazBookAndGroupDetil>>> GetOquvMarkazBookAndGroupDetil()
        {
            return await _context.OquvMarkazBookAndGroupDetil.ToListAsync();
        }

        // GET: api/OquvMarkazBookAndGroupDetils/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazBookAndGroupDetil>> GetOquvMarkazBookAndGroupDetil(long id)
        {
            var oquvMarkazBookAndGroupDetil = await _context.OquvMarkazBookAndGroupDetil.FindAsync(id);

            if (oquvMarkazBookAndGroupDetil == null)
            {
                return NotFound();
            }

            return oquvMarkazBookAndGroupDetil;
        }

        [HttpGet("addAcceptAsReaded")]
        public async Task<ActionResult<OquvMarkazBookAndGroupDetil>> addAcceptAsReaded([FromQuery]long id)
        {
            var oquvMarkazBookAndGroupDetil = await _context.OquvMarkazBookAndGroupDetil.FindAsync(id);

            if (oquvMarkazBookAndGroupDetil == null)
            {
                return NotFound();
            }
            oquvMarkazBookAndGroupDetil.readed = true;
            _context.OquvMarkazBookAndGroupDetil.Update(oquvMarkazBookAndGroupDetil);
            await _context.SaveChangesAsync();

            return oquvMarkazBookAndGroupDetil;
        }

        [HttpGet("addReturnAcceptAsUnReaded")]
        public async Task<ActionResult<OquvMarkazBookAndGroupDetil>> addReturnAcceptAsUnReaded([FromQuery] long id)
        {
            var oquvMarkazBookAndGroupDetil = await _context.OquvMarkazBookAndGroupDetil.FindAsync(id);

            if (oquvMarkazBookAndGroupDetil == null)
            {
                return NotFound();
            }
            oquvMarkazBookAndGroupDetil.readed = false;
            _context.OquvMarkazBookAndGroupDetil.Update(oquvMarkazBookAndGroupDetil);
            await _context.SaveChangesAsync();

            return oquvMarkazBookAndGroupDetil;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazBookAndGroupDetil> categoryList = await _context.OquvMarkazBookAndGroupDetil
                .Include(p => p.unit)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazBookAndGroupDetil>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazBookAndGroupDetil
                .Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationBookAndByGroupId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationBookAndByGroupId([FromQuery] int page, [FromQuery] int size,[FromQuery] long book_and_group_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazBookAndGroupDetil> categoryList = await _context.OquvMarkazBookAndGroupDetil
                .Include(p => p.unit)
                .Where(p => p.active_status == true && p.OquvMarkazBookAndGroupid == book_and_group_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazBookAndGroupDetil>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazBookAndGroupDetil
                 .Where(p => p.active_status == true && p.OquvMarkazBookAndGroupid == book_and_group_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationBookAndByGroupIdNotAccepted")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationBookAndByGroupIdNotAccepted([FromQuery] int page, [FromQuery] int size, [FromQuery] long book_and_group_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazBookAndGroupDetil> categoryList = await _context.OquvMarkazBookAndGroupDetil
                .Include(p => p.unit)
                .Where(p => p.active_status == true
                && p.OquvMarkazBookAndGroupid == book_and_group_id
                && p.readed == false)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazBookAndGroupDetil>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazBookAndGroupDetil
                 .Where(p => p.active_status == true
                && p.OquvMarkazBookAndGroupid == book_and_group_id
                && p.readed == false).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationBookAndByGroupIdAccepted")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationBookAndByGroupIdAccepted([FromQuery] int page, [FromQuery] int size, [FromQuery] long book_and_group_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazBookAndGroupDetil> categoryList = await _context.OquvMarkazBookAndGroupDetil
                .Include(p => p.unit)
                .Where(p => p.active_status == true
                && p.OquvMarkazBookAndGroupid == book_and_group_id
                && p.readed == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazBookAndGroupDetil>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazBookAndGroupDetil
                 .Where(p => p.active_status == true
                && p.OquvMarkazBookAndGroupid == book_and_group_id
                && p.readed == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/OquvMarkazBookAndGroupDetils/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazBookAndGroupDetil(long id, OquvMarkazBookAndGroupDetil oquvMarkazBookAndGroupDetil)
        {
            if (id != oquvMarkazBookAndGroupDetil.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazBookAndGroupDetil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazBookAndGroupDetilExists(id))
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

        // POST: api/OquvMarkazBookAndGroupDetils
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazBookAndGroupDetil>> PostOquvMarkazBookAndGroupDetil(OquvMarkazBookAndGroupDetil oquvMarkazBookAndGroupDetil)
        {
            _context.OquvMarkazBookAndGroupDetil.Update(oquvMarkazBookAndGroupDetil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazBookAndGroupDetil", new { id = oquvMarkazBookAndGroupDetil.id }, oquvMarkazBookAndGroupDetil);
        }

        // DELETE: api/OquvMarkazBookAndGroupDetils/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazBookAndGroupDetil>> DeleteOquvMarkazBookAndGroupDetil(long id)
        {
            var oquvMarkazBookAndGroupDetil = await _context.OquvMarkazBookAndGroupDetil.FindAsync(id);
            if (oquvMarkazBookAndGroupDetil == null)
            {
                return NotFound();
            }

            _context.OquvMarkazBookAndGroupDetil.Remove(oquvMarkazBookAndGroupDetil);
            await _context.SaveChangesAsync();

            return oquvMarkazBookAndGroupDetil;
        }

        private bool OquvMarkazBookAndGroupDetilExists(long id)
        {
            return _context.OquvMarkazBookAndGroupDetil.Any(e => e.id == id);
        }
    }
}
