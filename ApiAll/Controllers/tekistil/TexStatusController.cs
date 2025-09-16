using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;

namespace ApiAll.Controllers.tekistil
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexStatusController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexStatusController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexStatus>>> GetTexStatus()
        {
            return await _context.TexStatus.ToListAsync();
        }

        // GET: api/TexStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexStatus>> GetTexStatus(long id)
        {
            var texStatus = await _context.TexStatus.FindAsync(id);

            if (texStatus == null)
            {
                return NotFound();
            }

            return texStatus;
        }

        // PUT: api/TexStatus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexStatus(long id, TexStatus texStatus)
        {
            if (id != texStatus.id)
            {
                return BadRequest();
            }

            _context.Entry(texStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexStatusExists(id))
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

        // POST: api/TexStatus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexStatus>> PostTexStatus(TexStatus texStatus)
        {
     

            try
            {
       _context.TexStatus.Update(texStatus);
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

            return CreatedAtAction("GetTexStatus", new { id = texStatus.id }, texStatus);
        }

        // DELETE: api/TexStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexStatus>> DeleteTexStatus(long id)
        {
            var texStatus = await _context.TexStatus.FindAsync(id);
            if (texStatus == null)
            {
                return NotFound();
            }

            _context.TexStatus.Remove(texStatus);
            await _context.SaveChangesAsync();

            return texStatus;
        }

        private bool TexStatusExists(long id)
        {
            return _context.TexStatus.Any(e => e.id == id);
        }
    }
}
