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
    public class AnalizMuhimbelgilarsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AnalizMuhimbelgilarsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/AnalizMuhimbelgilars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalizMuhimbelgilar>>> GetanalizMuhimbelgilars()
        {
            return await _context.analizMuhimbelgilars.OrderByDescending(p => p.Id).ToListAsync();
        }

        [HttpGet("getByPatientsIdAnalizMuhimbelgilars")]
        public async Task<ActionResult<IEnumerable<AnalizMuhimbelgilar>>> getByPatientsIdAnalizMuhimbelgilars([FromQuery] long PatientsId)
        {
            return await _context.analizMuhimbelgilars.Where(p =>p.PatientsId == PatientsId).ToListAsync();
        }

        // GET: api/AnalizMuhimbelgilars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalizMuhimbelgilar>> GetAnalizMuhimbelgilar(long id)
        {
            var analizMuhimbelgilar = await _context.analizMuhimbelgilars.FindAsync(id);

            if (analizMuhimbelgilar == null)
            {
                return NotFound();
            }

            return analizMuhimbelgilar;
        }

        // PUT: api/AnalizMuhimbelgilars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalizMuhimbelgilar(long id, AnalizMuhimbelgilar analizMuhimbelgilar)
        {
            if (id != analizMuhimbelgilar.Id)
            {
                return BadRequest();
            }

            _context.Entry(analizMuhimbelgilar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalizMuhimbelgilarExists(id))
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

        // POST: api/AnalizMuhimbelgilars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnalizMuhimbelgilar>> PostAnalizMuhimbelgilar(AnalizMuhimbelgilar analizMuhimbelgilar)
        {
            analizMuhimbelgilar.ActiveStatus = true;
            _context.analizMuhimbelgilars.Update(analizMuhimbelgilar);
            await _context.SaveChangesAsync();

            return analizMuhimbelgilar;
        }
        // DELETE: api/AnalizMuhimbelgilars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnalizMuhimbelgilar>> DeleteAnalizMuhimbelgilar(long id)
        {
            var analizMuhimbelgilar = await _context.analizMuhimbelgilars.FindAsync(id);
            if (analizMuhimbelgilar == null)
            {
                return NotFound();
            }

            _context.analizMuhimbelgilars.Remove(analizMuhimbelgilar);
            await _context.SaveChangesAsync();

            return analizMuhimbelgilar;
        }

        private bool AnalizMuhimbelgilarExists(long id)
        {
            return _context.analizMuhimbelgilars.Any(e => e.Id == id);
        }
    }
}
