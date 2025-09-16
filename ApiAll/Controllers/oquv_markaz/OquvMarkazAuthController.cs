using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.oquv_markaz;

namespace ApiAll.Controllers.oquv_markaz
{
    [ApiExplorerSettings(GroupName = "v8")]
    [Route("api/[controller]")]
    [ApiController]
    public class OquvMarkazAuthController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazAuthController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazAuth
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazAuth>>> GetOquvMarkazAuth()
        {
            return await _context.OquvMarkazAuth.ToListAsync();
        }

        // GET: api/OquvMarkazAuth/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazAuth>> GetOquvMarkazAuth(long id)
        {
            var oquvMarkazAuth = await _context.OquvMarkazAuth.FindAsync(id);

            if (oquvMarkazAuth == null)
            {
                return NotFound();
            }

            return oquvMarkazAuth;
        }

        [HttpGet("checkLoginPassoword")]
        public async Task<ActionResult<OquvMarkazAuth>> checkLoginPassoword([FromQuery]String login,[FromQuery] String password)
        {
            var oquvMarkazAuth = await _context.OquvMarkazAuth.Where(p =>p.login == login && p.password == password).ToListAsync();

            if (oquvMarkazAuth == null && oquvMarkazAuth.Count  == 0)
            {
                return NotFound("Password or login incorrect");
            }

            return oquvMarkazAuth.First();
        }

        // PUT: api/OquvMarkazAuth/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazAuth(long id, OquvMarkazAuth oquvMarkazAuth)
        {
            if (id != oquvMarkazAuth.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazAuth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazAuthExists(id))
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

        // POST: api/OquvMarkazAuth
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazAuth>> PostOquvMarkazAuth(OquvMarkazAuth oquvMarkazAuth)
        {
            _context.OquvMarkazAuth.Update(oquvMarkazAuth);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazAuth", new { id = oquvMarkazAuth.id }, oquvMarkazAuth);
        }

        // DELETE: api/OquvMarkazAuth/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazAuth>> DeleteOquvMarkazAuth(long id)
        {
            var oquvMarkazAuth = await _context.OquvMarkazAuth.FindAsync(id);
            if (oquvMarkazAuth == null)
            {
                return NotFound();
            }

            _context.OquvMarkazAuth.Remove(oquvMarkazAuth);
            await _context.SaveChangesAsync();

            return oquvMarkazAuth;
        }

        private bool OquvMarkazAuthExists(long id)
        {
            return _context.OquvMarkazAuth.Any(e => e.id == id);
        }
    }
}
