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
    public class ArchiveNotificationReciverController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ArchiveNotificationReciverController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ArchiveNotificationReciver
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveNotificationReciver>>> GetArchiveNotificationReciver()
        {
            return await _context.ArchiveNotificationReciver.ToListAsync();
        }

        // GET: api/ArchiveNotificationReciver/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchiveNotificationReciver>> GetArchiveNotificationReciver(long id)
        {
            var archiveNotificationReciver = await _context.ArchiveNotificationReciver.FindAsync(id);

            if (archiveNotificationReciver == null)
            {
                return NotFound();
            }

            return archiveNotificationReciver;
        }

        // PUT: api/ArchiveNotificationReciver/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchiveNotificationReciver(long id, ArchiveNotificationReciver archiveNotificationReciver)
        {
            if (id != archiveNotificationReciver.id)
            {
                return BadRequest();
            }

            _context.Entry(archiveNotificationReciver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveNotificationReciverExists(id))
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

        // POST: api/ArchiveNotificationReciver
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArchiveNotificationReciver>> PostArchiveNotificationReciver(ArchiveNotificationReciver archiveNotificationReciver)
        {

            try {
                _context.ArchiveNotificationReciver.Update(archiveNotificationReciver);
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

            return CreatedAtAction("GetArchiveNotificationReciver", new { id = archiveNotificationReciver.id }, archiveNotificationReciver);
        }

        // DELETE: api/ArchiveNotificationReciver/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchiveNotificationReciver>> DeleteArchiveNotificationReciver(long id)
        {
            var archiveNotificationReciver = await _context.ArchiveNotificationReciver.FindAsync(id);
            if (archiveNotificationReciver == null)
            {
                return NotFound();
            }

            _context.ArchiveNotificationReciver.Remove(archiveNotificationReciver);
            await _context.SaveChangesAsync();

            return archiveNotificationReciver;
        }

        private bool ArchiveNotificationReciverExists(long id)
        {
            return _context.ArchiveNotificationReciver.Any(e => e.id == id);
        }
    }
}
