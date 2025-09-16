using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tegirmon;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tegirmon
{
    [ApiExplorerSettings(GroupName = "v7")]
    [Route("api/[controller]")]
    [ApiController]
    public class TegirmonDistrictController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonDistrictController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonDistrict
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonDistrict>>> GetTegirmonDistrict()
        {
            return await _context.TegirmonDistrict.ToListAsync();
        }

        [HttpGet("getPaginationDistrict")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationDistrict([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonDistrict> categoryList = await _context.TegirmonDistrict
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonDistrict>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonDistrict
                .Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        // GET: api/TegirmonDistrict/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonDistrict>> GetTegirmonDistrict(long id)
        {
            var tegirmonDistrict = await _context.TegirmonDistrict.FindAsync(id);

            if (tegirmonDistrict == null)
            {
                return NotFound();
            }

            return tegirmonDistrict;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonDistrict> categoryList = await _context.TegirmonDistrict
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonDistrict>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonDistrict.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/TegirmonDistrict/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonDistrict(long id, TegirmonDistrict tegirmonDistrict)
        {
            if (id != tegirmonDistrict.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonDistrict).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonDistrictExists(id))
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

        // POST: api/TegirmonDistrict
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonDistrict>> PostTegirmonDistrict(TegirmonDistrict tegirmonDistrict)
        {
            _context.TegirmonDistrict.Update(tegirmonDistrict);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonDistrict", new { id = tegirmonDistrict.id }, tegirmonDistrict);
        }

        // DELETE: api/TegirmonDistrict/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonDistrict>> DeleteTegirmonDistrict(long id)
        {
            var tegirmonDistrict = await _context.TegirmonDistrict.FindAsync(id);
            if (tegirmonDistrict == null)
            {
                return NotFound();
            }

            _context.TegirmonDistrict.Remove(tegirmonDistrict);
            await _context.SaveChangesAsync();

            return tegirmonDistrict;
        }

        private bool TegirmonDistrictExists(long id)
        {
            return _context.TegirmonDistrict.Any(e => e.id == id);
        }
    }
}
