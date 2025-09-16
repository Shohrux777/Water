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
    public class TexProductionTypesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexProductionTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexProductionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexProductionType>>> GetTexProductionType()
        {
            return await _context.TexProductionType.Where( p=>p.active_status == true).OrderByDescending( p =>p.id).ToListAsync();
        }

        // GET: api/TexProductionTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexProductionType>> GetTexProductionType(long id)
        {
            var texProductionType = await _context.TexProductionType.FindAsync(id);

            if (texProductionType == null)
            {
                return NotFound();
            }

            return texProductionType;
        }

        // PUT: api/TexProductionTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexProductionType(long id, TexProductionType texProductionType)
        {
            if (id != texProductionType.id)
            {
                return BadRequest();
            }

            _context.Entry(texProductionType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexProductionTypeExists(id))
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

        // POST: api/TexProductionTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexProductionType>> PostTexProductionType(TexProductionType texProductionType)
        {



            try
            {
            _context.TexProductionType.Update(texProductionType);
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

            return CreatedAtAction("GetTexProductionType", new { id = texProductionType.id }, texProductionType);
        }

        // DELETE: api/TexProductionTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexProductionType>> DeleteTexProductionType(long id)
        {
            var texProductionType = await _context.TexProductionType.FindAsync(id);
            if (texProductionType == null)
            {
                return NotFound();
            }
            try { 
                _context.TexProductionType.Remove(texProductionType);
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
            return texProductionType;
        }

        private bool TexProductionTypeExists(long id)
        {
            return _context.TexProductionType.Any(e => e.id == id);
        }
    }
}
