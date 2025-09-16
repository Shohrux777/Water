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
    public class AnalizLeyshmaniysController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AnalizLeyshmaniysController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/AnalizLeyshmaniys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalizLeyshmaniy>>> GetanalizLeyshmaniys()
        {
            return await _context.analizLeyshmaniys.OrderByDescending(p => p.Id).ToListAsync();
        }

        [HttpGet("getByPatientsIdAnalizLeyshmaniys")]
        public async Task<ActionResult<IEnumerable<AnalizLeyshmaniy>>> getByPatientsIdAnalizLeyshmaniys([FromQuery] long PatientsId)
        {
            return await _context.analizLeyshmaniys.Where(p => p.PatientsId == PatientsId).ToListAsync();
        }

        // GET: api/AnalizLeyshmaniys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalizLeyshmaniy>> GetAnalizLeyshmaniy(long id)
        {
            var analizLeyshmaniy = await _context.analizLeyshmaniys.FindAsync(id);

            if (analizLeyshmaniy == null)
            {
                return NotFound();
            }

            return analizLeyshmaniy;
        }

        // PUT: api/AnalizLeyshmaniys/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalizLeyshmaniy(long id, AnalizLeyshmaniy analizLeyshmaniy)
        {
            if (id != analizLeyshmaniy.Id)
            {
                return BadRequest();
            }

            _context.Entry(analizLeyshmaniy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalizLeyshmaniyExists(id))
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

        // POST: api/AnalizLeyshmaniys
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnalizLeyshmaniy>> PostAnalizLeyshmaniy(AnalizLeyshmaniy analizLeyshmaniy)
        {
            _context.analizLeyshmaniys.Add(analizLeyshmaniy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalizLeyshmaniy", new { id = analizLeyshmaniy.Id }, analizLeyshmaniy);
        }

        [HttpGet("addAnalizLeyshmaniy")]
        public async Task<ActionResult<AnalizLeyshmaniy>> addAnalizLeyshmaniy([FromQuery] long PatientsId,[FromQuery] String result)
        {
            AnalizLeyshmaniy analizLeyshmaniy = new AnalizLeyshmaniy();
            analizLeyshmaniy.ActiveStatus = true;
            analizLeyshmaniy.result = result;
            analizLeyshmaniy.PatientsId = PatientsId;
            _context.analizLeyshmaniys.Add(analizLeyshmaniy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalizLeyshmaniy", new { id = analizLeyshmaniy.Id }, analizLeyshmaniy);
        }

        // DELETE: api/AnalizLeyshmaniys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnalizLeyshmaniy>> DeleteAnalizLeyshmaniy(long id)
        {
            var analizLeyshmaniy = await _context.analizLeyshmaniys.FindAsync(id);
            if (analizLeyshmaniy == null)
            {
                return NotFound();
            }

            _context.analizLeyshmaniys.Remove(analizLeyshmaniy);
            await _context.SaveChangesAsync();

            return analizLeyshmaniy;
        }

        private bool AnalizLeyshmaniyExists(long id)
        {
            return _context.analizLeyshmaniys.Any(e => e.Id == id);
        }
    }
}
