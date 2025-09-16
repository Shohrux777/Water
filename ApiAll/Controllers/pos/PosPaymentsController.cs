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
    public class PosPaymentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosPaymentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosPayments>>> GetPosPayments()
        {
            return await _context.PosPayments.ToListAsync();
        }

        // GET: api/PosPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosPayments>> GetPosPayments(long id)
        {
            var posPayments = await _context.PosPayments.FindAsync(id);

            if (posPayments == null)
            {
                return NotFound();
            }

            return posPayments;
        }

        // PUT: api/PosPayments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosPayments(long id, PosPayments posPayments)
        {
            if (id != posPayments.id)
            {
                return BadRequest();
            }

            _context.Entry(posPayments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosPaymentsExists(id))
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

        // POST: api/PosPayments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosPayments>> PostPosPayments(PosPayments posPayments)
        {
            try
            {
            _context.PosPayments.Update(posPayments);
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

            return CreatedAtAction("GetPosPayments", new { id = posPayments.id }, posPayments);
        }

        // DELETE: api/PosPayments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosPayments>> DeletePosPayments(long id)
        {
            var posPayments = await _context.PosPayments.FindAsync(id);
            if (posPayments == null)
            {
                return NotFound();
            }

            _context.PosPayments.Remove(posPayments);
            await _context.SaveChangesAsync();

            return posPayments;
        }

        private bool PosPaymentsExists(long id)
        {
            return _context.PosPayments.Any(e => e.id == id);
        }
    }
}
