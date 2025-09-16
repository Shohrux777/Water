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
    public class ArchiveDepartmentController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ArchiveDepartmentController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ArchiveDepartment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveDepartment>>> GetArchiveDepartment()
        {
            return await _context.ArchiveDepartment.Include(p => p.company).ToListAsync();
        }

        // GET: api/ArchiveDepartment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchiveDepartment>> GetArchiveDepartment(long id)
        {
            var archiveDepartment = await _context.ArchiveDepartment.FindAsync(id);

            if (archiveDepartment == null)
            {
                return NotFound();
            }

            return archiveDepartment;
        }

        // PUT: api/ArchiveDepartment/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchiveDepartment(long id, ArchiveDepartment archiveDepartment)
        {
            if (id != archiveDepartment.id)
            {
                return BadRequest();
            }

            _context.Entry(archiveDepartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveDepartmentExists(id))
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

        // POST: api/ArchiveDepartment
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArchiveDepartment>> PostArchiveDepartment(ArchiveDepartment archiveDepartment)
        {


            try
            {
            _context.ArchiveDepartment.Update(archiveDepartment);
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

            return CreatedAtAction("GetArchiveDepartment", new { id = archiveDepartment.id }, archiveDepartment);
        }

        // DELETE: api/ArchiveDepartment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchiveDepartment>> DeleteArchiveDepartment(long id)
        {
            var archiveDepartment = await _context.ArchiveDepartment.FindAsync(id);
            if (archiveDepartment == null)
            {
                return NotFound();
            }

            _context.ArchiveDepartment.Remove(archiveDepartment);
            await _context.SaveChangesAsync();

            return archiveDepartment;
        }

        private bool ArchiveDepartmentExists(long id)
        {
            return _context.ArchiveDepartment.Any(e => e.id == id);
        }
    }
}
