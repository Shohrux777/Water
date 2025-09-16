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
    public class ArchiveAccessMenuController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ArchiveAccessMenuController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ArchiveAccessMenu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveAccessMenu>>> GetArchiveAccessMenu()
        {
            return await _context.ArchiveAccessMenu.ToListAsync();
        }

        // GET: api/ArchiveAccessMenu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchiveAccessMenu>> GetArchiveAccessMenu(long id)
        {
            var archiveAccessMenu = await _context.ArchiveAccessMenu.FindAsync(id);

            if (archiveAccessMenu == null)
            {
                return NotFound();
            }

            return archiveAccessMenu;
        }

        // PUT: api/ArchiveAccessMenu/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchiveAccessMenu(long id, ArchiveAccessMenu archiveAccessMenu)
        {
            if (id != archiveAccessMenu.id)
            {
                return BadRequest();
            }

            _context.Entry(archiveAccessMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveAccessMenuExists(id))
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

        // POST: api/ArchiveAccessMenu
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArchiveAccessMenu>> PostArchiveAccessMenu(ArchiveAccessMenu archiveAccessMenu)
        {


            try
            {
            _context.ArchiveAccessMenu.Update(archiveAccessMenu);
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

            return CreatedAtAction("GetArchiveAccessMenu", new { id = archiveAccessMenu.id }, archiveAccessMenu);
        }

        // DELETE: api/ArchiveAccessMenu/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchiveAccessMenu>> DeleteArchiveAccessMenu(long id)
        {
            var archiveAccessMenu = await _context.ArchiveAccessMenu.FindAsync(id);
            if (archiveAccessMenu == null)
            {
                return NotFound();
            }

            _context.ArchiveAccessMenu.Remove(archiveAccessMenu);
            await _context.SaveChangesAsync();

            return archiveAccessMenu;
        }

        private bool ArchiveAccessMenuExists(long id)
        {
            return _context.ArchiveAccessMenu.Any(e => e.id == id);
        }
    }
}
