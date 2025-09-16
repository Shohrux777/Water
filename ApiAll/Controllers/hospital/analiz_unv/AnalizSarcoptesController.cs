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
    public class AnalizSarcoptesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AnalizSarcoptesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/AnalizSarcoptes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalizSarcoptes>>> GetanalizSarcoptes()
        {
            return await _context.analizSarcoptes.OrderByDescending(p => p.Id).ToListAsync();
        }
        [HttpGet("getByPatientsIdAnalizSarcoptes")]
        public async Task<ActionResult<IEnumerable<AnalizSarcoptes>>> getByPatientsIdAnalizSarcoptes([FromQuery] long PatientsId)
        {
            return await _context.analizSarcoptes.Where( a => a.PatientsId == PatientsId).ToListAsync();
        }

        // GET: api/AnalizSarcoptes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalizSarcoptes>> GetAnalizSarcoptes(long id)
        {
            var analizSarcoptes = await _context.analizSarcoptes.FindAsync(id);

            if (analizSarcoptes == null)
            {
                return NotFound();
            }

            return analizSarcoptes;
        }

        // PUT: api/AnalizSarcoptes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalizSarcoptes(long id, AnalizSarcoptes analizSarcoptes)
        {
            if (id != analizSarcoptes.Id)
            {
                return BadRequest();
            }

            _context.Entry(analizSarcoptes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalizSarcoptesExists(id))
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

        // POST: api/AnalizSarcoptes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnalizSarcoptes>> PostAnalizSarcoptes(AnalizSarcoptes analizSarcoptes)
        {
            analizSarcoptes.ActiveStatus = true;
            _context.analizSarcoptes.Update(analizSarcoptes);
            await _context.SaveChangesAsync();

            return analizSarcoptes;
        }

        // DELETE: api/AnalizSarcoptes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnalizSarcoptes>> DeleteAnalizSarcoptes(long id)
        {
            var analizSarcoptes = await _context.analizSarcoptes.FindAsync(id);
            if (analizSarcoptes == null)
            {
                return NotFound();
            }

            _context.analizSarcoptes.Remove(analizSarcoptes);
            await _context.SaveChangesAsync();

            return analizSarcoptes;
        }

        private bool AnalizSarcoptesExists(long id)
        {
            return _context.analizSarcoptes.Any(e => e.Id == id);
        }
    }
}
