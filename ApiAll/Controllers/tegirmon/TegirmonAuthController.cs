using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tegirmon;

namespace ApiAll.Controllers.tegirmon
{
    [ApiExplorerSettings(GroupName = "v7")]
    [Route("api/[controller]")]
    [ApiController]
    public class TegirmonAuthController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonAuthController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonAuth
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonAuth>>> GetTegirmonAuth()
        {
            return await _context.TegirmonAuth.ToListAsync();
        }

        // GET: api/TegirmonAuth/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonAuth>> GetTegirmonAuth(long id)
        {
            var tegirmonAuth = await _context.TegirmonAuth.FindAsync(id);

            if (tegirmonAuth == null)
            {
                return NotFound();
            }

            return tegirmonAuth;
        }

        [HttpGet("checkAuthByLoginAndPassword")]
        public async Task<ActionResult<TegirmonAuth>> checkAuthByLoginAndPassword([FromQuery] String login , [FromQuery] String password)
        {
            var tegirmonAuth = await _context.TegirmonAuth.Include(p =>p.user).Where(p=>p.login == login && p.pasword == password).ToListAsync();

            if (tegirmonAuth == null || tegirmonAuth.Count == 0)
            {
                return NotFound("Login or Password incorrect");
            }

            return tegirmonAuth.First();
        }

        // PUT: api/TegirmonAuth/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonAuth(long id, TegirmonAuth tegirmonAuth)
        {
            if (id != tegirmonAuth.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonAuth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonAuthExists(id))
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

        // POST: api/TegirmonAuth
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonAuth>> PostTegirmonAuth(TegirmonAuth tegirmonAuth)
        {
            _context.TegirmonAuth.Update(tegirmonAuth);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonAuth", new { id = tegirmonAuth.id }, tegirmonAuth);
        }

        // DELETE: api/TegirmonAuth/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonAuth>> DeleteTegirmonAuth(long id)
        {
            var tegirmonAuth = await _context.TegirmonAuth.FindAsync(id);
            if (tegirmonAuth == null)
            {
                return NotFound();
            }

            _context.TegirmonAuth.Remove(tegirmonAuth);
            await _context.SaveChangesAsync();

            return tegirmonAuth;
        }

        private bool TegirmonAuthExists(long id)
        {
            return _context.TegirmonAuth.Any(e => e.id == id);
        }
    }
}
