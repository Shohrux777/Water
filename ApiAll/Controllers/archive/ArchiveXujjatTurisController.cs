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
    public class ArchiveXujjatTurisController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ArchiveXujjatTurisController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ArchiveXujjatTuris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveXujjatTuri>>> GetArchiveXujjatTuri()
        {
            return await _context.ArchiveXujjatTuri.ToListAsync();
        }


        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<ArchiveXujjatTuri> categoryList = await _context.ArchiveXujjatTuri
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<ArchiveXujjatTuri>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.ArchiveXujjatTuri.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/ArchiveXujjatTuris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchiveXujjatTuri>> GetArchiveXujjatTuri(long id)
        {
            var archiveXujjatTuri = await _context.ArchiveXujjatTuri.FindAsync(id);

            if (archiveXujjatTuri == null)
            {
                return NotFound();
            }

            return archiveXujjatTuri;
        }

        // PUT: api/ArchiveXujjatTuris/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchiveXujjatTuri(long id, ArchiveXujjatTuri archiveXujjatTuri)
        {
            if (id != archiveXujjatTuri.id)
            {
                return BadRequest();
            }

            _context.Entry(archiveXujjatTuri).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveXujjatTuriExists(id))
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

        // POST: api/ArchiveXujjatTuris
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArchiveXujjatTuri>> PostArchiveXujjatTuri(ArchiveXujjatTuri archiveXujjatTuri)
        {
            _context.ArchiveXujjatTuri.Update(archiveXujjatTuri);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArchiveXujjatTuri", new { id = archiveXujjatTuri.id }, archiveXujjatTuri);
        }

        // DELETE: api/ArchiveXujjatTuris/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchiveXujjatTuri>> DeleteArchiveXujjatTuri(long id)
        {
            var archiveXujjatTuri = await _context.ArchiveXujjatTuri.FindAsync(id);
            if (archiveXujjatTuri == null)
            {
                return NotFound();
            }

            _context.ArchiveXujjatTuri.Remove(archiveXujjatTuri);
            await _context.SaveChangesAsync();

            return archiveXujjatTuri;
        }

        private bool ArchiveXujjatTuriExists(long id)
        {
            return _context.ArchiveXujjatTuri.Any(e => e.id == id);
        }
    }
}
