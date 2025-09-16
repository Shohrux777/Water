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
    public class ArchiveUserController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ArchiveUserController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ArchiveUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveUser>>> GetArchiveUser()
        {
            return await _context.ArchiveUser.Include(p => p.department).ToListAsync();
        }


        // GET: api/ArchiveUser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchiveUser>> GetArchiveUser(long id)
        {
            var archiveUser = await _context.ArchiveUser.FindAsync(id);

            if (archiveUser == null)
            {
                return NotFound();
            }

            return archiveUser;
        }

        [HttpGet("checkUserAuth")]
        public async Task<ActionResult<ArchiveUser>> checkUserAuth([FromQuery] String login,[FromQuery] String password)
        {
            var archiveUser = await _context.ArchiveUser.Where(p => p.login == login && p.password == password).ToListAsync();

            if (archiveUser == null || archiveUser.Count == 0)
            {
                return NotFound();
            }

            return archiveUser.First();
        }

        // PUT: api/ArchiveUser/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchiveUser(long id, ArchiveUser archiveUser)
        {
            if (id != archiveUser.id)
            {
                return BadRequest();
            }

            _context.Entry(archiveUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveUserExists(id))
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

        // POST: api/ArchiveUser
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArchiveUser>> PostArchiveUser(ArchiveUser archiveUser)
        {


            try
            {
                  _context.ArchiveUser.Update(archiveUser);
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

            return CreatedAtAction("GetArchiveUser", new { id = archiveUser.id }, archiveUser);
        }

        // DELETE: api/ArchiveUser/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchiveUser>> DeleteArchiveUser(long id)
        {
            var archiveUser = await _context.ArchiveUser.FindAsync(id);
            if (archiveUser == null)
            {
                return NotFound();
            }

            _context.ArchiveUser.Remove(archiveUser);
            await _context.SaveChangesAsync();

            return archiveUser;
        }

        private bool ArchiveUserExists(long id)
        {
            return _context.ArchiveUser.Any(e => e.id == id);
        }
    }
}
