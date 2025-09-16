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
    public class PosProductTypesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosProductTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosProductTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosProductType>>> GetPosProductType()
        {
            return await _context.PosProductType.ToListAsync();
        }

        // GET: api/PosProductTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosProductType>> GetPosProductType(long id)
        {
            var posProductType = await _context.PosProductType.FindAsync(id);

            if (posProductType == null)
            {
                return NotFound();
            }

            return posProductType;
        }

        // PUT: api/PosProductTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosProductType(long id, PosProductType posProductType)
        {
            if (id != posProductType.id)
            {
                return BadRequest();
            }

            _context.Entry(posProductType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosProductTypeExists(id))
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

        // POST: api/PosProductTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosProductType>> PostPosProductType(PosProductType posProductType)
        {


            try
            {
                _context.PosProductType.Update(posProductType);
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

            return CreatedAtAction("GetPosProductType", new { id = posProductType.id }, posProductType);
        }

        // DELETE: api/PosProductTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosProductType>> DeletePosProductType(long id)
        {
            var posProductType = await _context.PosProductType.FindAsync(id);
            if (posProductType == null)
            {
                return NotFound();
            }

            _context.PosProductType.Remove(posProductType);
            await _context.SaveChangesAsync();

            return posProductType;
        }

        private bool PosProductTypeExists(long id)
        {
            return _context.PosProductType.Any(e => e.id == id);
        }
    }
}
