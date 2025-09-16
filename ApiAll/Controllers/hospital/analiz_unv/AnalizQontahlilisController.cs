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
    public class AnalizQontahlilisController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AnalizQontahlilisController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/AnalizQontahlilis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalizQontahlili>>> GetanalizQontahlilis()
        {
            return await _context.analizQontahlilis.OrderByDescending(p => p.Id).ToListAsync();
        }

        [HttpGet("getByPatientsIdAnalizQontahlilis")]
        public async Task<ActionResult<IEnumerable<AnalizQontahlili>>> getByPatientsIdAnalizQontahlilis([FromQuery] long PatientsId)
        {
            return await _context.analizQontahlilis.Where(a => a.PatientsId == PatientsId).ToListAsync();
        }

        // GET: api/AnalizQontahlilis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalizQontahlili>> GetAnalizQontahlili(long id)
        {
            var analizQontahlili = await _context.analizQontahlilis.FindAsync(id);

            if (analizQontahlili == null)
            {
                return NotFound();
            }

            return analizQontahlili;
        }

        // PUT: api/AnalizQontahlilis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalizQontahlili(long id, AnalizQontahlili analizQontahlili)
        {
            if (id != analizQontahlili.Id)
            {
                return BadRequest();
            }

            _context.Entry(analizQontahlili).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalizQontahliliExists(id))
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

        // POST: api/AnalizQontahlilis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnalizQontahlili>> PostAnalizQontahlili(AnalizQontahlili analizQontahlili)
        {
            analizQontahlili.ActiveStatus = true;
            _context.analizQontahlilis.Update(analizQontahlili);
            await _context.SaveChangesAsync();

            return analizQontahlili;
        }

        // DELETE: api/AnalizQontahlilis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnalizQontahlili>> DeleteAnalizQontahlili(long id)
        {
            var analizQontahlili = await _context.analizQontahlilis.FindAsync(id);
            if (analizQontahlili == null)
            {
                return NotFound();
            }

            _context.analizQontahlilis.Remove(analizQontahlili);
            await _context.SaveChangesAsync();

            return analizQontahlili;
        }

        private bool AnalizQontahliliExists(long id)
        {
            return _context.analizQontahlilis.Any(e => e.Id == id);
        }
    }
}
