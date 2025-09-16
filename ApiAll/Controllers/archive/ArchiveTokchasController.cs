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
    public class ArchiveTokchasController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ArchiveTokchasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ArchiveTokchas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveTokcha>>> GetArchiveTokcha()
        {
            return await _context.ArchiveTokcha.ToListAsync();
        }
        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<ArchiveTokcha> categoryList = await _context.ArchiveTokcha
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<ArchiveTokcha>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.ArchiveTokcha.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // GET: api/ArchiveTokchas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchiveTokcha>> GetArchiveTokcha(long id)
        {
            var archiveTokcha = await _context.ArchiveTokcha.FindAsync(id);

            if (archiveTokcha == null)
            {
                return NotFound();
            }

            return archiveTokcha;
        }

        // PUT: api/ArchiveTokchas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchiveTokcha(long id, ArchiveTokcha archiveTokcha)
        {
            if (id != archiveTokcha.id)
            {
                return BadRequest();
            }

            _context.Entry(archiveTokcha).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveTokchaExists(id))
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

        // POST: api/ArchiveTokchas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArchiveTokcha>> PostArchiveTokcha(ArchiveTokcha archiveTokcha)
        {
            _context.ArchiveTokcha.Update(archiveTokcha);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArchiveTokcha", new { id = archiveTokcha.id }, archiveTokcha);
        }

        // DELETE: api/ArchiveTokchas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchiveTokcha>> DeleteArchiveTokcha(long id)
        {
            var archiveTokcha = await _context.ArchiveTokcha.FindAsync(id);
            if (archiveTokcha == null)
            {
                return NotFound();
            }

            _context.ArchiveTokcha.Remove(archiveTokcha);
            await _context.SaveChangesAsync();

            return archiveTokcha;
        }

        private bool ArchiveTokchaExists(long id)
        {
            return _context.ArchiveTokcha.Any(e => e.id == id);
        }
    }
}
