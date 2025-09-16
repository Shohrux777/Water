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
    public class PosClientCardTypesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosClientCardTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosClientCardTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosClientCardType>>> GetPosClientCardType()
        {
            return await _context.PosClientCardType.ToListAsync();
        }

        // GET: api/PosClientCardTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosClientCardType>> GetPosClientCardType(long id)
        {
            var posClientCardType = await _context.PosClientCardType.FindAsync(id);

            if (posClientCardType == null)
            {
                return NotFound();
            }

            return posClientCardType;
        }

        // PUT: api/PosClientCardTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosClientCardType(long id, PosClientCardType posClientCardType)
        {
            if (id != posClientCardType.Id)
            {
                return BadRequest();
            }

            _context.Entry(posClientCardType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosClientCardTypeExists(id))
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

        // POST: api/PosClientCardTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosClientCardType>> PostPosClientCardType(PosClientCardType posClientCardType)
        {
            try
            {
                _context.PosClientCardType.Update(posClientCardType);
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

            return CreatedAtAction("GetPosClientCardType", new { id = posClientCardType.Id }, posClientCardType);
        }

        // DELETE: api/PosClientCardTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosClientCardType>> DeletePosClientCardType(long id)
        {
            var posClientCardType = await _context.PosClientCardType.FindAsync(id);
            if (posClientCardType == null)
            {
                return NotFound();
            }

            _context.PosClientCardType.Remove(posClientCardType);
            await _context.SaveChangesAsync();

            return posClientCardType;
        }

        private bool PosClientCardTypeExists(long id)
        {
            return _context.PosClientCardType.Any(e => e.Id == id);
        }
    }
}
