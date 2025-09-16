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
    public class ArchiveCompanyController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ArchiveCompanyController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ArchiveCompany
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveCompany>>> GetArchiveCompany()
        {
            return await _context.ArchiveCompany.ToListAsync();
        }

        // GET: api/ArchiveCompany/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchiveCompany>> GetArchiveCompany(long id)
        {
            var archiveCompany = await _context.ArchiveCompany.FindAsync(id);

            if (archiveCompany == null)
            {
                return NotFound();
            }

            return archiveCompany;
        }

        // PUT: api/ArchiveCompany/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchiveCompany(long id, ArchiveCompany archiveCompany)
        {
            if (id != archiveCompany.id)
            {
                return BadRequest();
            }

            _context.Entry(archiveCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveCompanyExists(id))
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

        // POST: api/ArchiveCompany
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArchiveCompany>> PostArchiveCompany(ArchiveCompany archiveCompany)
        {


            try
            {
                _context.ArchiveCompany.Update(archiveCompany);
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

            return CreatedAtAction("GetArchiveCompany", new { id = archiveCompany.id }, archiveCompany);
        }

        // DELETE: api/ArchiveCompany/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchiveCompany>> DeleteArchiveCompany(long id)
        {
            var archiveCompany = await _context.ArchiveCompany.FindAsync(id);
            if (archiveCompany == null)
            {
                return NotFound();
            }

            _context.ArchiveCompany.Remove(archiveCompany);
            await _context.SaveChangesAsync();

            return archiveCompany;
        }

        private bool ArchiveCompanyExists(long id)
        {
            return _context.ArchiveCompany.Any(e => e.id == id);
        }
    }
}
