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
    public class TexPlaningTypesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexPlaningTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexPlaningTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexPlaningType>>> GetTexPlaningType()
        {
            return await _context.TexPlaningType.Where(p => p.active_status == true).OrderByDescending(p =>p.id).ToListAsync();
        }

        // GET: api/TexPlaningTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexPlaningType>> GetTexPlaningType(long id)
        {
            var texPlaningType = await _context.TexPlaningType.FindAsync(id);

            if (texPlaningType == null)
            {
                return NotFound();
            }

            return texPlaningType;
        }

        // PUT: api/TexPlaningTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexPlaningType(long id, TexPlaningType texPlaningType)
        {
            if (id != texPlaningType.id)
            {
                return BadRequest();
            }

            _context.Entry(texPlaningType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexPlaningTypeExists(id))
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

        // POST: api/TexPlaningTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexPlaningType>> PostTexPlaningType(TexPlaningType texPlaningType)
        {
       


            try
            {
            _context.TexPlaningType.Update(texPlaningType);
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

            return CreatedAtAction("GetTexPlaningType", new { id = texPlaningType.id }, texPlaningType);
        }

        // DELETE: api/TexPlaningTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexPlaningType>> DeleteTexPlaningType(long id)
        {
            var texPlaningType = await _context.TexPlaningType.FindAsync(id);
            if (texPlaningType == null)
            {
                return NotFound();
            }

            try { 
                _context.TexPlaningType.Remove(texPlaningType);
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
            return texPlaningType;
        }

        private bool TexPlaningTypeExists(long id)
        {
            return _context.TexPlaningType.Any(e => e.id == id);
        }
    }
}
