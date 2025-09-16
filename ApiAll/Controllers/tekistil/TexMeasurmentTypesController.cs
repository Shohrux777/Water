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
    public class TexMeasurmentTypesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexMeasurmentTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexMeasurmentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexMeasurmentType>>> GetTexMeasurmentType()
        {
            return await _context.TexMeasurmentType.Where(p=>p.active_status == true).OrderByDescending(p => p.id).ToListAsync();
        }

        // GET: api/TexMeasurmentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexMeasurmentType>> GetTexMeasurmentType(long id)
        {
            var texMeasurmentType = await _context.TexMeasurmentType.FindAsync(id);

            if (texMeasurmentType == null)
            {
                return NotFound();
            }

            return texMeasurmentType;
        }

        // PUT: api/TexMeasurmentTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexMeasurmentType(long id, TexMeasurmentType texMeasurmentType)
        {
            if (id != texMeasurmentType.id)
            {
                return BadRequest();
            }

            _context.Entry(texMeasurmentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexMeasurmentTypeExists(id))
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

        // POST: api/TexMeasurmentTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexMeasurmentType>> PostTexMeasurmentType(TexMeasurmentType texMeasurmentType)
        {



            try
            {
            _context.TexMeasurmentType.Update(texMeasurmentType);
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

            return CreatedAtAction("GetTexMeasurmentType", new { id = texMeasurmentType.id }, texMeasurmentType);
        }

        // DELETE: api/TexMeasurmentTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexMeasurmentType>> DeleteTexMeasurmentType(long id)
        {
            var texMeasurmentType = await _context.TexMeasurmentType.FindAsync(id);
            if (texMeasurmentType == null)
            {
                return NotFound();
            }

            _context.TexMeasurmentType.Update(texMeasurmentType);
            await _context.SaveChangesAsync();

            return texMeasurmentType;
        }

        private bool TexMeasurmentTypeExists(long id)
        {
            return _context.TexMeasurmentType.Any(e => e.id == id);
        }
    }
}
