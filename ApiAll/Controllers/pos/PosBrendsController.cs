using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.pos;

namespace ApiAll.Controllers.pos
{
    [ApiExplorerSettings(GroupName = "v5")]
    [Route("api/[controller]")]
    [ApiController]
    public class PosBrendsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosBrendsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosBrends
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosBrend>>> GetPosBrend()
        {
            return await _context.PosBrend.ToListAsync();
        }

        // GET: api/PosBrends/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosBrend>> GetPosBrend(long id)
        {
            var posBrend = await _context.PosBrend.FindAsync(id);

            if (posBrend == null)
            {
                return NotFound();
            }

            return posBrend;
        }

        // PUT: api/PosBrends/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosBrend(long id, PosBrend posBrend)
        {
            if (id != posBrend.id)
            {
                return BadRequest();
            }

            _context.Entry(posBrend).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosBrendExists(id))
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

        // POST: api/PosBrends
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosBrend>> PostPosBrend(PosBrend posBrend)
        {
            try
            {
                       _context.PosBrend.Update(posBrend);
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

            return CreatedAtAction("GetPosBrend", new { id = posBrend.id }, posBrend);
        }

        // DELETE: api/PosBrends/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosBrend>> DeletePosBrend(long id)
        {
            var posBrend = await _context.PosBrend.FindAsync(id);
            if (posBrend == null)
            {
                return NotFound();
            }

            _context.PosBrend.Remove(posBrend);
            await _context.SaveChangesAsync();

            return posBrend;
        }

        private bool PosBrendExists(long id)
        {
            return _context.PosBrend.Any(e => e.id == id);
        }
    }
}
