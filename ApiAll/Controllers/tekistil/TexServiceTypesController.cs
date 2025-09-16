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
    public class TexServiceTypesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexServiceTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexServiceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexServiceType>>> GetTexServiceType()
        {
            return await _context.TexServiceType.ToListAsync();
        }

        // GET: api/TexServiceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexServiceType>> GetTexServiceType(long id)
        {
            var texServiceType = await _context.TexServiceType.FindAsync(id);

            if (texServiceType == null)
            {
                return NotFound();
            }

            return texServiceType;
        }

        // PUT: api/TexServiceTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexServiceType(long id, TexServiceType texServiceType)
        {
            if (id != texServiceType.id)
            {
                return BadRequest();
            }

            _context.Entry(texServiceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexServiceTypeExists(id))
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

        // POST: api/TexServiceTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexServiceType>> PostTexServiceType(TexServiceType texServiceType)
        {
            

            try
            {
                _context.TexServiceType.Update(texServiceType);
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

            return CreatedAtAction("GetTexServiceType", new { id = texServiceType.id }, texServiceType);
        }

        // DELETE: api/TexServiceTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexServiceType>> DeleteTexServiceType(long id)
        {
            var texServiceType = await _context.TexServiceType.FindAsync(id);
            if (texServiceType == null)
            {
                return NotFound();
            }

            _context.TexServiceType.Remove(texServiceType);
            await _context.SaveChangesAsync();

            return texServiceType;
        }

        private bool TexServiceTypeExists(long id)
        {
            return _context.TexServiceType.Any(e => e.id == id);
        }
    }
}
