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
using ApiAll.Model.tegirmon;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.archive
{
    [ApiExplorerSettings(GroupName = "v6")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArchiveJavonsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ArchiveJavonsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ArchiveJavons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveJavon>>> GetArchiveJavon()
        {
            return await _context.ArchiveJavon.ToListAsync();
        }
        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<ArchiveJavon> categoryList = await _context.ArchiveJavon
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<ArchiveJavon>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.ArchiveJavon.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/ArchiveJavons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchiveJavon>> GetArchiveJavon(long id)
        {
            var archiveJavon = await _context.ArchiveJavon.FindAsync(id);

            if (archiveJavon == null)
            {
                return NotFound();
            }

            return archiveJavon;
        }

        // PUT: api/ArchiveJavons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchiveJavon(long id, ArchiveJavon archiveJavon)
        {
            if (id != archiveJavon.id)
            {
                return BadRequest();
            }

            _context.Entry(archiveJavon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveJavonExists(id))
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

        // POST: api/ArchiveJavons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArchiveJavon>> PostArchiveJavon(ArchiveJavon archiveJavon)
        {
            _context.ArchiveJavon.Update(archiveJavon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArchiveJavon", new { id = archiveJavon.id }, archiveJavon);
        }

        // DELETE: api/ArchiveJavons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchiveJavon>> DeleteArchiveJavon(long id)
        {
            var archiveJavon = await _context.ArchiveJavon.FindAsync(id);
            if (archiveJavon == null)
            {
                return NotFound();
            }

            _context.ArchiveJavon.Remove(archiveJavon);
            await _context.SaveChangesAsync();

            return archiveJavon;
        }

        private bool ArchiveJavonExists(long id)
        {
            return _context.ArchiveJavon.Any(e => e.id == id);
        }
    }
}
