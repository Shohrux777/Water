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
    public class AnalizZamburugsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AnalizZamburugsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/AnalizZamburugs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalizZamburug>>> GetanalizZamburugs()
        {
            return await _context.analizZamburugs.OrderByDescending(p => p.Id).ToListAsync();
        }

        [HttpGet("getByPatientsIdAnalizZamburugs")]
        public async Task<ActionResult<IEnumerable<AnalizZamburug>>> getByPatientsIdAnalizZamburugs([FromQuery] long PatientsId)
        {
            return await _context.analizZamburugs.Where(a => a.PatientsId == PatientsId).ToListAsync();
        }

        // GET: api/AnalizZamburugs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalizZamburug>> GetAnalizZamburug(long id)
        {
            var analizZamburug = await _context.analizZamburugs.FindAsync(id);

            if (analizZamburug == null)
            {
                return NotFound();
            }

            return analizZamburug;
        }

        // PUT: api/AnalizZamburugs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalizZamburug(long id, AnalizZamburug analizZamburug)
        {
            if (id != analizZamburug.Id)
            {
                return BadRequest();
            }

            _context.Entry(analizZamburug).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalizZamburugExists(id))
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

        // POST: api/AnalizZamburugs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnalizZamburug>> PostAnalizZamburug(AnalizZamburug analizZamburug)
        {
            analizZamburug.ActiveStatus = true;
            _context.analizZamburugs.Update(analizZamburug);
            await _context.SaveChangesAsync();

            return analizZamburug;
        }

        // DELETE: api/AnalizZamburugs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnalizZamburug>> DeleteAnalizZamburug(long id)
        {
            var analizZamburug = await _context.analizZamburugs.FindAsync(id);
            if (analizZamburug == null)
            {
                return NotFound();
            }

            _context.analizZamburugs.Remove(analizZamburug);
            await _context.SaveChangesAsync();

            return analizZamburug;
        }

        private bool AnalizZamburugExists(long id)
        {
            return _context.analizZamburugs.Any(e => e.Id == id);
        }
    }
}
