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
    public class ArchiveDatchikController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ArchiveDatchikController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ArchiveDatchikCOntroller
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveDatchik>>> GetArchiveDatchik()
        {
            return await _context.ArchiveDatchik.ToListAsync();
        }

        // GET: api/ArchiveDatchikCOntroller/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchiveDatchik>> GetArchiveDatchik(long id)
        {
            var archiveDatchik = await _context.ArchiveDatchik.FindAsync(id);

            if (archiveDatchik == null)
            {
                return NotFound();
            }

            return archiveDatchik;
        }

        // PUT: api/ArchiveDatchikCOntroller/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchiveDatchik(long id, ArchiveDatchik archiveDatchik)
        {
            if (id != archiveDatchik.id)
            {
                return BadRequest();
            }

            _context.Entry(archiveDatchik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveDatchikExists(id))
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

        // POST: api/ArchiveDatchikCOntroller
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArchiveDatchik>> PostArchiveDatchik(ArchiveDatchik archiveDatchik)
        {


            try
            {
                _context.ArchiveDatchik.Update(archiveDatchik);
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

            return CreatedAtAction("GetArchiveDatchik", new { id = archiveDatchik.id }, archiveDatchik);
        }

        // DELETE: api/ArchiveDatchikCOntroller/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchiveDatchik>> DeleteArchiveDatchik(long id)
        {
            var archiveDatchik = await _context.ArchiveDatchik.FindAsync(id);
            if (archiveDatchik == null)
            {
                return NotFound();
            }

            _context.ArchiveDatchik.Remove(archiveDatchik);
            await _context.SaveChangesAsync();

            return archiveDatchik;
        }

        private bool ArchiveDatchikExists(long id)
        {
            return _context.ArchiveDatchik.Any(e => e.id == id);
        }
    }
}
