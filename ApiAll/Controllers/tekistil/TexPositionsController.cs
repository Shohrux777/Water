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
    public class TexPositionsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexPositionsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexPosition>>> GetTexPosition()
        {
            return await _context.TexPosition.Where(p =>p.active_status == true).OrderByDescending( p=>p.id).ToListAsync();
        }

        // GET: api/TexPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexPosition>> GetTexPosition(long id)
        {
            var texPosition = await _context.TexPosition.FindAsync(id);

            if (texPosition == null)
            {
                return NotFound();
            }

            return texPosition;
        }

        // PUT: api/TexPositions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexPosition(long id, TexPosition texPosition)
        {
            if (id != texPosition.id)
            {
                return BadRequest();
            }

            _context.Entry(texPosition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexPositionExists(id))
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

        // POST: api/TexPositions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexPosition>> PostTexPosition(TexPosition texPosition)
        {
            


            try
            {
_context.TexPosition.Update(texPosition);
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

            return CreatedAtAction("GetTexPosition", new { id = texPosition.id }, texPosition);
        }

        // DELETE: api/TexPositions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexPosition>> DeleteTexPosition(long id)
        {
            var texPosition = await _context.TexPosition.FindAsync(id);
            if (texPosition == null)
            {
                return NotFound();
            }
            texPosition.active_status = false;

            _context.TexPosition.Update(texPosition);
            await _context.SaveChangesAsync();

            return texPosition;
        }

        private bool TexPositionExists(long id)
        {
            return _context.TexPosition.Any(e => e.id == id);
        }
    }
}
