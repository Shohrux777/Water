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
    public class AnalizQondagiGarmonlarsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AnalizQondagiGarmonlarsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/AnalizQondagiGarmonlars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalizQondagiGarmonlar>>> GetAnalizQondagiGarmonlar()
        {
            return await _context.AnalizQondagiGarmonlar.Include(p => p.patients).OrderByDescending(p => p.Id).ToListAsync();
        }

        [HttpGet("getAnalizQondagiGarmonlarGetByPatientId")]
        public async Task<ActionResult<IEnumerable<AnalizQondagiGarmonlar>>> getAnalizQondagiGarmonlarGetByPatientId([FromQuery] long patientId)
        {
            return await _context.AnalizQondagiGarmonlar.Where( p => p.PatientsId == patientId).Include(p => p.patients).OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/AnalizQondagiGarmonlars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalizQondagiGarmonlar>> GetAnalizQondagiGarmonlar(long id)
        {
            var analizQondagiGarmonlar = await _context.AnalizQondagiGarmonlar.FindAsync(id);

            if (analizQondagiGarmonlar == null)
            {
                return NotFound();
            }

            return analizQondagiGarmonlar;
        }

        // PUT: api/AnalizQondagiGarmonlars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalizQondagiGarmonlar(long id, AnalizQondagiGarmonlar analizQondagiGarmonlar)
        {
            if (id != analizQondagiGarmonlar.Id)
            {
                return BadRequest();
            }

            _context.Entry(analizQondagiGarmonlar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalizQondagiGarmonlarExists(id))
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

        // POST: api/AnalizQondagiGarmonlars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnalizQondagiGarmonlar>> PostAnalizQondagiGarmonlar(AnalizQondagiGarmonlar analizQondagiGarmonlar)
        {
            _context.AnalizQondagiGarmonlar.Add(analizQondagiGarmonlar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalizQondagiGarmonlar", new { id = analizQondagiGarmonlar.Id }, analizQondagiGarmonlar);
        }

        // DELETE: api/AnalizQondagiGarmonlars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnalizQondagiGarmonlar>> DeleteAnalizQondagiGarmonlar(long id)
        {
            var analizQondagiGarmonlar = await _context.AnalizQondagiGarmonlar.FindAsync(id);
            if (analizQondagiGarmonlar == null)
            {
                return NotFound();
            }

            _context.AnalizQondagiGarmonlar.Remove(analizQondagiGarmonlar);
            await _context.SaveChangesAsync();

            return analizQondagiGarmonlar;
        }

        private bool AnalizQondagiGarmonlarExists(long id)
        {
            return _context.AnalizQondagiGarmonlar.Any(e => e.Id == id);
        }
    }
}
