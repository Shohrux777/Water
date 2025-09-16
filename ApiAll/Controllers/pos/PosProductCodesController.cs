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
    public class PosProductCodesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosProductCodesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosProductCodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosProductCode>>> GetPosProductCode()
        {
            return await _context.PosProductCode.ToListAsync();
        }

        // GET: api/PosProductCodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosProductCode>> GetPosProductCode(long id)
        {
            var posProductCode = await _context.PosProductCode.FindAsync(id);

            if (posProductCode == null)
            {
                return NotFound();
            }

            return posProductCode;
        }

        // PUT: api/PosProductCodes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosProductCode(long id, PosProductCode posProductCode)
        {
            if (id != posProductCode.id)
            {
                return BadRequest();
            }

            _context.Entry(posProductCode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosProductCodeExists(id))
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

        // POST: api/PosProductCodes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosProductCode>> PostPosProductCode(PosProductCode posProductCode)
        {

            try
            {
                _context.PosProductCode.Update(posProductCode);
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

            return CreatedAtAction("GetPosProductCode", new { id = posProductCode.id }, posProductCode);
        }

        // DELETE: api/PosProductCodes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosProductCode>> DeletePosProductCode(long id)
        {
            var posProductCode = await _context.PosProductCode.FindAsync(id);
            if (posProductCode == null)
            {
                return NotFound();
            }

            _context.PosProductCode.Remove(posProductCode);
            await _context.SaveChangesAsync();

            return posProductCode;
        }

        private bool PosProductCodeExists(long id)
        {
            return _context.PosProductCode.Any(e => e.id == id);
        }
    }
}
