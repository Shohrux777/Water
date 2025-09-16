using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class AnalizCovidsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AnalizCovidsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/AnalizCovids
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalizCovid>>> GetAnalizCovid()
        {
            return await _context.AnalizCovid.Include(p => p.patients).OrderByDescending( p => p.Id).ToListAsync();
        }

        // GET: api/AnalizCovids
        [HttpGet("getCovidAnalizByPatientId")]
        public async Task<ActionResult<IEnumerable<AnalizCovid>>> getCovidAnalizByPatientId([FromQuery] long patientId)
        {
            return await _context.AnalizCovid.Include(p => p.patients).OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/AnalizCovids/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalizCovid>> GetAnalizCovid(long id)
        {
            var analizCovid = await _context.AnalizCovid.FindAsync(id);

            if (analizCovid == null)
            {
                return NotFound();
            }

            return analizCovid;
        }

        // PUT: api/AnalizCovids/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalizCovid(long id, AnalizCovid analizCovid)
        {
            if (id != analizCovid.Id)
            {
                return BadRequest();
            }

            _context.Entry(analizCovid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalizCovidExists(id))
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

        // POST: api/AnalizCovids
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnalizCovid>> PostAnalizCovid(AnalizCovid analizCovid)
        {
            _context.AnalizCovid.Update(analizCovid);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalizCovid", new { id = analizCovid.Id }, analizCovid);
        }

        // DELETE: api/AnalizCovids/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnalizCovid>> DeleteAnalizCovid(long id)
        {
            var analizCovid = await _context.AnalizCovid.FindAsync(id);
            if (analizCovid == null)
            {
                return NotFound();
            }

            _context.AnalizCovid.Remove(analizCovid);
            await _context.SaveChangesAsync();

            return analizCovid;
        }

        private bool AnalizCovidExists(long id)
        {
            return _context.AnalizCovid.Any(e => e.Id == id);
        }
    }
}
