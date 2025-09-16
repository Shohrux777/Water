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
    public class ArchiveStelajsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ArchiveStelajsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ArchiveStelajs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveStelaj>>> GetArchiveStelaj()
        {
            return await _context.ArchiveStelaj.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<ArchiveStelaj> categoryList = await _context.ArchiveStelaj
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<ArchiveStelaj>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.ArchiveStelaj.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/ArchiveStelajs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchiveStelaj>> GetArchiveStelaj(long id)
        {
            var archiveStelaj = await _context.ArchiveStelaj.FindAsync(id);

            if (archiveStelaj == null)
            {
                return NotFound();
            }

            return archiveStelaj;
        }

        // PUT: api/ArchiveStelajs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchiveStelaj(long id, ArchiveStelaj archiveStelaj)
        {
            if (id != archiveStelaj.id)
            {
                return BadRequest();
            }

            _context.Entry(archiveStelaj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveStelajExists(id))
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

        // POST: api/ArchiveStelajs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArchiveStelaj>> PostArchiveStelaj(ArchiveStelaj archiveStelaj)
        {
            _context.ArchiveStelaj.Update(archiveStelaj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArchiveStelaj", new { id = archiveStelaj.id }, archiveStelaj);
        }

        // DELETE: api/ArchiveStelajs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchiveStelaj>> DeleteArchiveStelaj(long id)
        {
            var archiveStelaj = await _context.ArchiveStelaj.FindAsync(id);
            if (archiveStelaj == null)
            {
                return NotFound();
            }

            _context.ArchiveStelaj.Remove(archiveStelaj);
            await _context.SaveChangesAsync();

            return archiveStelaj;
        }

        private bool ArchiveStelajExists(long id)
        {
            return _context.ArchiveStelaj.Any(e => e.id == id);
        }
    }
}
