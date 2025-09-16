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
    public class TexUnitmeasurmentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexUnitmeasurmentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexUnitmeasurments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexUnitmeasurment>>> GetTexUnitmeasurment()
        {
            return await _context.TexUnitmeasurment.ToListAsync();
        }

        // GET: api/TexUnitmeasurments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexUnitmeasurment>> GetTexUnitmeasurment(long id)
        {
            var texUnitmeasurment = await _context.TexUnitmeasurment.FindAsync(id);

            if (texUnitmeasurment == null)
            {
                return NotFound();
            }

            return texUnitmeasurment;
        }

        // PUT: api/TexUnitmeasurments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexUnitmeasurment(long id, TexUnitmeasurment texUnitmeasurment)
        {
            if (id != texUnitmeasurment.id)
            {
                return BadRequest();
            }

            _context.Entry(texUnitmeasurment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexUnitmeasurmentExists(id))
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

        // POST: api/TexUnitmeasurments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexUnitmeasurment>> PostTexUnitmeasurment(TexUnitmeasurment texUnitmeasurment)
        {
            try
            {
                 _context.TexUnitmeasurment.Update(texUnitmeasurment);
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



            return CreatedAtAction("GetTexUnitmeasurment", new { id = texUnitmeasurment.id }, texUnitmeasurment);
        }

        // DELETE: api/TexUnitmeasurments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexUnitmeasurment>> DeleteTexUnitmeasurment(long id)
        {
            var texUnitmeasurment = await _context.TexUnitmeasurment.FindAsync(id);
            if (texUnitmeasurment == null)
            {
                return NotFound();
            }

            _context.TexUnitmeasurment.Remove(texUnitmeasurment);
            await _context.SaveChangesAsync();

            return texUnitmeasurment;
        }

        private bool TexUnitmeasurmentExists(long id)
        {
            return _context.TexUnitmeasurment.Any(e => e.id == id);
        }
    }
}
