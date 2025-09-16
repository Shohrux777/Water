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
    public class AnalizMikroskopiyasController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AnalizMikroskopiyasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/AnalizMikroskopiyas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalizMikroskopiya>>> GetanalizMikroskopiyas()
        {
            return await _context.analizMikroskopiyas.OrderByDescending(p => p.Id).ToListAsync();
        }

        [HttpGet("getByPatientsIdAnalizMikroskopiyas")]
        public async Task<ActionResult<IEnumerable<AnalizMikroskopiya>>> getByPatientsIdAnalizMikroskopiyas([FromQuery] long PatientsId)
        {
            return await _context.analizMikroskopiyas.Where(p => p.PatientsId == PatientsId).ToListAsync();
        }

        // GET: api/AnalizMikroskopiyas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalizMikroskopiya>> GetAnalizMikroskopiya(long id)
        {
            var analizMikroskopiya = await _context.analizMikroskopiyas.FindAsync(id);

            if (analizMikroskopiya == null)
            {
                return NotFound();
            }

            return analizMikroskopiya;
        }

        // PUT: api/AnalizMikroskopiyas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalizMikroskopiya(long id, AnalizMikroskopiya analizMikroskopiya)
        {
            if (id != analizMikroskopiya.Id)
            {
                return BadRequest();
            }

            _context.Entry(analizMikroskopiya).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalizMikroskopiyaExists(id))
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

        // POST: api/AnalizMikroskopiyas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnalizMikroskopiya>> PostAnalizMikroskopiya(AnalizMikroskopiya analizMikroskopiya)
        {
            analizMikroskopiya.ActiveStatus = true;
            _context.analizMikroskopiyas.Update(analizMikroskopiya);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalizMikroskopiya", new { id = analizMikroskopiya.Id }, analizMikroskopiya);
        }

        // DELETE: api/AnalizMikroskopiyas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnalizMikroskopiya>> DeleteAnalizMikroskopiya(long id)
        {
            var analizMikroskopiya = await _context.analizMikroskopiyas.FindAsync(id);
            if (analizMikroskopiya == null)
            {
                return NotFound();
            }

            _context.analizMikroskopiyas.Remove(analizMikroskopiya);
            await _context.SaveChangesAsync();

            return analizMikroskopiya;
        }

        private bool AnalizMikroskopiyaExists(long id)
        {
            return _context.analizMikroskopiyas.Any(e => e.Id == id);
        }
    }
}
