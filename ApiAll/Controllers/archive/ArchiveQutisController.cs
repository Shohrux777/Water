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
    public class ArchiveQutisController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ArchiveQutisController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ArchiveQutis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveQuti>>> GetArchiveQuti()
        {
            return await _context.ArchiveQuti.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<ArchiveQuti> categoryList = await _context.ArchiveQuti
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<ArchiveQuti>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.ArchiveQuti.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/ArchiveQutis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchiveQuti>> GetArchiveQuti(long id)
        {
            var archiveQuti = await _context.ArchiveQuti.FindAsync(id);

            if (archiveQuti == null)
            {
                return NotFound();
            }

            return archiveQuti;
        }

        // PUT: api/ArchiveQutis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchiveQuti(long id, ArchiveQuti archiveQuti)
        {
            if (id != archiveQuti.id)
            {
                return BadRequest();
            }

            _context.Entry(archiveQuti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveQutiExists(id))
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

        // POST: api/ArchiveQutis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArchiveQuti>> PostArchiveQuti(ArchiveQuti archiveQuti)
        {
            _context.ArchiveQuti.Update(archiveQuti);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArchiveQuti", new { id = archiveQuti.id }, archiveQuti);
        }

        // DELETE: api/ArchiveQutis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchiveQuti>> DeleteArchiveQuti(long id)
        {
            var archiveQuti = await _context.ArchiveQuti.FindAsync(id);
            if (archiveQuti == null)
            {
                return NotFound();
            }

            _context.ArchiveQuti.Remove(archiveQuti);
            await _context.SaveChangesAsync();

            return archiveQuti;
        }

        private bool ArchiveQutiExists(long id)
        {
            return _context.ArchiveQuti.Any(e => e.id == id);
        }
    }
}
