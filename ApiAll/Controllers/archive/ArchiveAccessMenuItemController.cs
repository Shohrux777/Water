using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.archive;

namespace ApiAll.Controllers.archive
{
    [ApiExplorerSettings(GroupName = "v6")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArchiveAccessMenuItemController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ArchiveAccessMenuItemController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ArchiveAccessMenuItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveAccessMenuItem>>> GetArchiveAccessMenuItem()
        {
            return await _context.ArchiveAccessMenuItem.ToListAsync();
        }

        // GET: api/ArchiveAccessMenuItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchiveAccessMenuItem>> GetArchiveAccessMenuItem(long id)
        {
            var archiveAccessMenuItem = await _context.ArchiveAccessMenuItem.FindAsync(id);

            if (archiveAccessMenuItem == null)
            {
                return NotFound();
            }

            return archiveAccessMenuItem;
        }

        // PUT: api/ArchiveAccessMenuItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchiveAccessMenuItem(long id, ArchiveAccessMenuItem archiveAccessMenuItem)
        {
            if (id != archiveAccessMenuItem.id)
            {
                return BadRequest();
            }

            _context.Entry(archiveAccessMenuItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveAccessMenuItemExists(id))
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

        // POST: api/ArchiveAccessMenuItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArchiveAccessMenuItem>> PostArchiveAccessMenuItem(ArchiveAccessMenuItem archiveAccessMenuItem)
        {
  

            try {
          _context.ArchiveAccessMenuItem.Update(archiveAccessMenuItem);
            await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                return NotFound(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFound(e?.InnerException?.Message);
            }

            return CreatedAtAction("GetArchiveAccessMenuItem", new { id = archiveAccessMenuItem.id }, archiveAccessMenuItem);
        }

        // DELETE: api/ArchiveAccessMenuItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchiveAccessMenuItem>> DeleteArchiveAccessMenuItem(long id)
        {
            var archiveAccessMenuItem = await _context.ArchiveAccessMenuItem.FindAsync(id);
            if (archiveAccessMenuItem == null)
            {
                return NotFound();
            }

            _context.ArchiveAccessMenuItem.Remove(archiveAccessMenuItem);
            await _context.SaveChangesAsync();

            return archiveAccessMenuItem;
        }

        private bool ArchiveAccessMenuItemExists(long id)
        {
            return _context.ArchiveAccessMenuItem.Any(e => e.id == id);
        }
    }
}
