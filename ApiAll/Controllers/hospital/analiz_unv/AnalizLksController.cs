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
    public class AnalizLksController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AnalizLksController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/AnalizLks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalizLk>>> GetanalizLks()
        {
            return await _context.analizLks.OrderByDescending(p => p.Id).ToListAsync();
        }

        [HttpGet("getByPatientsIdAnalizLks")]
        public async Task<ActionResult<IEnumerable<AnalizLk>>> getByPatientsIdAnalizLks([FromQuery] long PatientsId)
        {
            return await _context.analizLks.Where(p => p.PatientsId == PatientsId).ToListAsync();
        }

        // GET: api/AnalizLks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalizLk>> GetAnalizLk(long id)
        {
            var analizLk = await _context.analizLks.FindAsync(id);

            if (analizLk == null)
            {
                return NotFound();
            }

            return analizLk;
        }

        // PUT: api/AnalizLks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalizLk(long id, AnalizLk analizLk)
        {
            if (id != analizLk.Id)
            {
                return BadRequest();
            }

            _context.Entry(analizLk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalizLkExists(id))
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

        // POST: api/AnalizLks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnalizLk>> PostAnalizLk(AnalizLk analizLk)
        {
            analizLk.ActiveStatus = true;
            _context.analizLks.Update(analizLk);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalizLk", new { id = analizLk.Id }, analizLk);
        }

        // DELETE: api/AnalizLks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnalizLk>> DeleteAnalizLk(long id)
        {
            var analizLk = await _context.analizLks.FindAsync(id);
            if (analizLk == null)
            {
                return NotFound();
            }

            _context.analizLks.Remove(analizLk);
            await _context.SaveChangesAsync();

            return analizLk;
        }

        private bool AnalizLkExists(long id)
        {
            return _context.analizLks.Any(e => e.Id == id);
        }
    }
}
