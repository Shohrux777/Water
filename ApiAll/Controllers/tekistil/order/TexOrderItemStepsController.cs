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
    public class TexOrderItemStepsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexOrderItemStepsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexOrderItemSteps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexOrderItemSteps>>> GetTexOrderItemSteps()
        {
            return await _context.TexOrderItemSteps.OrderByDescending( p =>p.id).ToListAsync();
        }

        // GET: api/TexOrderItemSteps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexOrderItemSteps>> GetTexOrderItemSteps(long id)
        {
            var texOrderItemSteps = await _context.TexOrderItemSteps.FindAsync(id);

            if (texOrderItemSteps == null)
            {
                return NotFound();
            }

            return texOrderItemSteps;
        }

        // PUT: api/TexOrderItemSteps/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexOrderItemSteps(long id, TexOrderItemSteps texOrderItemSteps)
        {
            if (id != texOrderItemSteps.id)
            {
                return BadRequest();
            }

            _context.Entry(texOrderItemSteps).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexOrderItemStepsExists(id))
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

        // POST: api/TexOrderItemSteps
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexOrderItemSteps>> PostTexOrderItemSteps(TexOrderItemSteps texOrderItemSteps)
        {


            try {
                _context.TexOrderItemSteps.Update(texOrderItemSteps);
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

            return CreatedAtAction("GetTexOrderItemSteps", new { id = texOrderItemSteps.id }, texOrderItemSteps);
        }

        // DELETE: api/TexOrderItemSteps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexOrderItemSteps>> DeleteTexOrderItemSteps(long id)
        {
            var texOrderItemSteps = await _context.TexOrderItemSteps.FindAsync(id);
            if (texOrderItemSteps == null)
            {
                return NotFound();
            }

            _context.TexOrderItemSteps.Remove(texOrderItemSteps);
            await _context.SaveChangesAsync();

            return texOrderItemSteps;
        }

        private bool TexOrderItemStepsExists(long id)
        {
            return _context.TexOrderItemSteps.Any(e => e.id == id);
        }
    }
}
