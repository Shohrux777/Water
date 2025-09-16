using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class AnalizCovidMazoksController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AnalizCovidMazoksController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/AnalizCovidMazoks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalizCovidMazok>>> GetAnalizCovidMazok()
        {
            return await _context.AnalizCovidMazok.Include(p => p.patients).OrderByDescending( p => p.Id).ToListAsync();
        }

        [HttpGet("getAnalizCovidMazokByPatientId")]
        public async Task<ActionResult<IEnumerable<AnalizCovidMazok>>> getAnalizCovidMazokByPatientId([FromQuery] long patientId)
        {
            return await _context.AnalizCovidMazok.Where(p => p.PatientsId == patientId).Include(p => p.patients).OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/AnalizCovidMazoks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalizCovidMazok>> GetAnalizCovidMazok(long id)
        {
            var analizCovidMazok = await _context.AnalizCovidMazok.FindAsync(id);

            if (analizCovidMazok == null)
            {
                return NotFound();
            }

            return analizCovidMazok;
        }

        // PUT: api/AnalizCovidMazoks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalizCovidMazok(long id, AnalizCovidMazok analizCovidMazok)
        {
            if (id != analizCovidMazok.Id)
            {
                return BadRequest();
            }

            _context.Entry(analizCovidMazok).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalizCovidMazokExists(id))
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

        // POST: api/AnalizCovidMazoks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnalizCovidMazok>> PostAnalizCovidMazok(AnalizCovidMazok analizCovidMazok)
        {
            _context.AnalizCovidMazok.Update(analizCovidMazok);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalizCovidMazok", new { id = analizCovidMazok.Id }, analizCovidMazok);
        }

        // DELETE: api/AnalizCovidMazoks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnalizCovidMazok>> DeleteAnalizCovidMazok(long id)
        {
            var analizCovidMazok = await _context.AnalizCovidMazok.FindAsync(id);
            if (analizCovidMazok == null)
            {
                return NotFound();
            }

            _context.AnalizCovidMazok.Remove(analizCovidMazok);
            await _context.SaveChangesAsync();

            return analizCovidMazok;
        }

        private bool AnalizCovidMazokExists(long id)
        {
            return _context.AnalizCovidMazok.Any(e => e.Id == id);
        }
    }
}
