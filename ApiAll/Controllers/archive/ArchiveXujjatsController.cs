using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.archive;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.archive
{
    [ApiExplorerSettings(GroupName = "v6")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArchiveXujjatsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ArchiveXujjatsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ArchiveXujjats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveXujjat>>> GetArchiveXujjat()
        {
            return await _context.ArchiveXujjat.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<ArchiveXujjat> categoryList = await _context.ArchiveXujjat
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<ArchiveXujjat>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.ArchiveXujjat.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/ArchiveXujjats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchiveXujjat>> GetArchiveXujjat(long id)
        {
            var archiveXujjat = await _context.ArchiveXujjat.FindAsync(id);

            if (archiveXujjat == null)
            {
                return NotFound();
            }

            return archiveXujjat;
        }

        // PUT: api/ArchiveXujjats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchiveXujjat(long id, ArchiveXujjat archiveXujjat)
        {
            if (id != archiveXujjat.id)
            {
                return BadRequest();
            }

            _context.Entry(archiveXujjat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveXujjatExists(id))
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

        // POST: api/ArchiveXujjats
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArchiveXujjat>> PostArchiveXujjat(ArchiveXujjat archiveXujjat)
        {
            _context.ArchiveXujjat.Update(archiveXujjat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArchiveXujjat", new { id = archiveXujjat.id }, archiveXujjat);
        }

        // DELETE: api/ArchiveXujjats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchiveXujjat>> DeleteArchiveXujjat(long id)
        {
            var archiveXujjat = await _context.ArchiveXujjat.FindAsync(id);
            if (archiveXujjat == null)
            {
                return NotFound();
            }

            _context.ArchiveXujjat.Remove(archiveXujjat);
            await _context.SaveChangesAsync();

            return archiveXujjat;
        }

        private bool ArchiveXujjatExists(long id)
        {
            return _context.ArchiveXujjat.Any(e => e.id == id);
        }
    }
}
