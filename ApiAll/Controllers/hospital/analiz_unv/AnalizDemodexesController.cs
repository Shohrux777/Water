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
    public class AnalizDemodexesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AnalizDemodexesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/AnalizDemodexes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalizDemodex>>> GetanalizDemodices()
        {
            return await _context.analizDemodices.OrderByDescending(p => p.Id).ToListAsync();
        }

        [HttpGet("getAnalizDemodicesByPatientId")]
        public async Task<ActionResult<IEnumerable<AnalizDemodex>>> getAnalizDemodicesByPatientId([FromQuery] long PatientsId)
        {
            return await _context.analizDemodices.Where(a => a.PatientsId == PatientsId).ToListAsync();
        }

        // GET: api/AnalizDemodexes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalizDemodex>> GetAnalizDemodex(long id)
        {
            var analizDemodex = await _context.analizDemodices.FindAsync(id);

            if (analizDemodex == null)
            {
                return NotFound();
            }

            return analizDemodex;
        }

        // PUT: api/AnalizDemodexes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalizDemodex(long id, AnalizDemodex analizDemodex)
        {
            if (id != analizDemodex.Id)
            {
                return BadRequest();
            }

            _context.Entry(analizDemodex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalizDemodexExists(id))
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

        // POST: api/AnalizDemodexes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnalizDemodex>> PostAnalizDemodex(AnalizDemodex analizDemodex)
        {
            _context.analizDemodices.Add(analizDemodex);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalizDemodex", new { id = analizDemodex.Id }, analizDemodex);
        }

        [HttpGet("AddAnalizDemodex")]
        public async Task<ActionResult<AnalizDemodex>> AddAnalizDemodex([FromQuery]String result,[FromQuery]long PatientsId)
        {
            AnalizDemodex analizDemodex = new AnalizDemodex();
            analizDemodex.ActiveStatus = true;
            analizDemodex.result = result;
            analizDemodex.PatientsId = PatientsId;
            _context.analizDemodices.Update(analizDemodex);
            await _context.SaveChangesAsync();

            return analizDemodex;
        }

        // DELETE: api/AnalizDemodexes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnalizDemodex>> DeleteAnalizDemodex(long id)
        {
            var analizDemodex = await _context.analizDemodices.FindAsync(id);
            if (analizDemodex == null)
            {
                return NotFound();
            }

            _context.analizDemodices.Remove(analizDemodex);
            await _context.SaveChangesAsync();

            return analizDemodex;
        }

        private bool AnalizDemodexExists(long id)
        {
            return _context.analizDemodices.Any(e => e.Id == id);
        }
    }
}
