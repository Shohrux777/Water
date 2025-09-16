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
    public class PosAuthorizationsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosAuthorizationsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosAuthorizations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosAuthorization>>> GetPosAuthorization()
        {
            return await _context.PosAuthorization.ToListAsync();
        }

        // GET: api/PosAuthorizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosAuthorization>> GetPosAuthorization(long id)
        {
            var posAuthorization = await _context.PosAuthorization.FindAsync(id);

            if (posAuthorization == null)
            {
                return NotFound();
            }

            return posAuthorization;
        }

        [HttpGet("checkPosAuth")]
        public async Task<ActionResult<PosAuthorization>> checkPosAuth([FromQuery] String login, [FromQuery] String password)
        {
            var posAuthorization = await _context.PosAuthorization
                .Include(p =>p.user)
                .Where(p =>p.login == login &&  p.password == password)
                .ToListAsync();

            if (posAuthorization == null || posAuthorization.Count == 0)
            {
                return NotFound("Password or login incorrect");
            }

            return posAuthorization.First();
        }

        // PUT: api/PosAuthorizations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosAuthorization(long id, PosAuthorization posAuthorization)
        {
            if (id != posAuthorization.id)
            {
                return BadRequest();
            }

            _context.Entry(posAuthorization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosAuthorizationExists(id))
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

        // POST: api/PosAuthorizations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosAuthorization>> PostPosAuthorization(PosAuthorization posAuthorization)
        {
            try
            {
                _context.PosAuthorization.Update(posAuthorization);
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
      

            return CreatedAtAction("GetPosAuthorization", new { id = posAuthorization.id }, posAuthorization);
        }

        // DELETE: api/PosAuthorizations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosAuthorization>> DeletePosAuthorization(long id)
        {
            var posAuthorization = await _context.PosAuthorization.FindAsync(id);
            if (posAuthorization == null)
            {
                return NotFound();
            }

            _context.PosAuthorization.Remove(posAuthorization);
            await _context.SaveChangesAsync();

            return posAuthorization;
        }

        private bool PosAuthorizationExists(long id)
        {
            return _context.PosAuthorization.Any(e => e.id == id);
        }
    }
}
