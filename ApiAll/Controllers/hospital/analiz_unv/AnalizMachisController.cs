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
    public class AnalizMachisController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AnalizMachisController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/AnalizMachis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalizMachi>>> GetanalizMachis()
        {
            return await _context.analizMachis.OrderByDescending(p => p.Id).ToListAsync();
        }

        [HttpGet("getByPatientsIdAnalizMachis")]
        public async Task<ActionResult<IEnumerable<AnalizMachi>>> getByPatientsIdAnalizMachis([FromQuery] long PatientsId)
        {
            return await _context.analizMachis.Where(p => p.PatientsId == PatientsId).ToListAsync();
        }

        // GET: api/AnalizMachis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalizMachi>> GetAnalizMachi(long id)
        {
            var analizMachi = await _context.analizMachis.FindAsync(id);

            if (analizMachi == null)
            {
                return NotFound();
            }

            return analizMachi;
        }

        // PUT: api/AnalizMachis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalizMachi(long id, AnalizMachi analizMachi)
        {
            if (id != analizMachi.Id)
            {
                return BadRequest();
            }

            _context.Entry(analizMachi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalizMachiExists(id))
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

        // POST: api/AnalizMachis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnalizMachi>> PostAnalizMachi(AnalizMachi analizMachi)
        {
            analizMachi.ActiveStatus = true;
            _context.analizMachis.Update(analizMachi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalizMachi", new { id = analizMachi.Id }, analizMachi);
        }

        // DELETE: api/AnalizMachis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnalizMachi>> DeleteAnalizMachi(long id)
        {
            var analizMachi = await _context.analizMachis.FindAsync(id);
            if (analizMachi == null)
            {
                return NotFound();
            }

            _context.analizMachis.Remove(analizMachi);
            await _context.SaveChangesAsync();

            return analizMachi;
        }

        private bool AnalizMachiExists(long id)
        {
            return _context.analizMachis.Any(e => e.Id == id);
        }
    }
}
