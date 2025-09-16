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
    public class PosCurrencyTypeController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosCurrencyTypeController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosCurrencyType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosCurrencyType>>> GetPosCurrencyType()
        {
            return await _context.PosCurrencyType.ToListAsync();
        }

        // GET: api/PosCurrencyType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosCurrencyType>> GetPosCurrencyType(long id)
        {
            var posCurrencyType = await _context.PosCurrencyType.FindAsync(id);

            if (posCurrencyType == null)
            {
                return NotFound();
            }

            return posCurrencyType;
        }

        // PUT: api/PosCurrencyType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosCurrencyType(long id, PosCurrencyType posCurrencyType)
        {
            if (id != posCurrencyType.id)
            {
                return BadRequest();
            }

            _context.Entry(posCurrencyType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosCurrencyTypeExists(id))
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

        // POST: api/PosCurrencyType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosCurrencyType>> PostPosCurrencyType(PosCurrencyType posCurrencyType)
        {
            _context.PosCurrencyType.Add(posCurrencyType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosCurrencyType", new { id = posCurrencyType.id }, posCurrencyType);
        }

        // DELETE: api/PosCurrencyType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosCurrencyType>> DeletePosCurrencyType(long id)
        {
            var posCurrencyType = await _context.PosCurrencyType.FindAsync(id);
            if (posCurrencyType == null)
            {
                return NotFound();
            }

            _context.PosCurrencyType.Remove(posCurrencyType);
            await _context.SaveChangesAsync();

            return posCurrencyType;
        }

        private bool PosCurrencyTypeExists(long id)
        {
            return _context.PosCurrencyType.Any(e => e.id == id);
        }
    }
}
