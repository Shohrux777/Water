using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;

namespace ApiAll.Model.tekistil.seworder
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexStepController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexStepController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexStep
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexStep>>> GetTexStep()
        {
            return await _context.TexStep.ToListAsync();
        }

        // GET: api/TexStep/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexStep>> GetTexStep(long id)
        {
            var texStep = await _context.TexStep.FindAsync(id);

            if (texStep == null)
            {
                return NotFound();
            }

            return texStep;
        }

        // PUT: api/TexStep/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexStep(long id, TexStep texStep)
        {
            if (id != texStep.id)
            {
                return BadRequest();
            }

            _context.Entry(texStep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexStepExists(id))
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

        // POST: api/TexStep
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexStep>> PostTexStep(TexStep texStep)
        {
            _context.TexStep.Update(texStep);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexStep", new { id = texStep.id }, texStep);
        }

        // DELETE: api/TexStep/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexStep>> DeleteTexStep(long id)
        {
            var texStep = await _context.TexStep.FindAsync(id);
            if (texStep == null)
            {
                return NotFound();
            }

            _context.TexStep.Remove(texStep);
            await _context.SaveChangesAsync();

            return texStep;
        }

        private bool TexStepExists(long id)
        {
            return _context.TexStep.Any(e => e.id == id);
        }
    }
}
