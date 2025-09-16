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
    public class AnalizBakterioskopiyasController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AnalizBakterioskopiyasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/AnalizBakterioskopiyas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalizBakterioskopiya>>> GetanalizBakterioskopiyas()
        {
            return await _context.analizBakterioskopiyas.OrderByDescending(p => p.Id).ToListAsync();
        }

        [HttpGet("getAnalizBakterioskopiyasByPatientId")]
        public async Task<ActionResult<IEnumerable<AnalizBakterioskopiya>>> getAnalizBakterioskopiyasByPatientId([FromQuery] long PatientsId)
        {
            return await _context.analizBakterioskopiyas.Where(a => a.PatientsId == PatientsId).ToListAsync();
        }

        // GET: api/AnalizBakterioskopiyas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalizBakterioskopiya>> GetAnalizBakterioskopiya(long id)
        {
            var analizBakterioskopiya = await _context.analizBakterioskopiyas.FindAsync(id);

            if (analizBakterioskopiya == null)
            {
                return NotFound();
            }

            return analizBakterioskopiya;
        }

        // PUT: api/AnalizBakterioskopiyas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalizBakterioskopiya(long id, AnalizBakterioskopiya analizBakterioskopiya)
        {
            if (id != analizBakterioskopiya.Id)
            {
                return BadRequest();
            }

            _context.Entry(analizBakterioskopiya).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalizBakterioskopiyaExists(id))
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

        // POST: api/AnalizBakterioskopiyas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnalizBakterioskopiya>> PostAnalizBakterioskopiya(AnalizBakterioskopiya analizBakterioskopiya)
        {
            _context.analizBakterioskopiyas.Add(analizBakterioskopiya);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalizBakterioskopiya", new { id = analizBakterioskopiya.Id }, analizBakterioskopiya);
        }

        [HttpGet("addtAnalizBakterioskopiya")]
        public async Task<ActionResult<AnalizBakterioskopiya>> addtAnalizBakterioskopiya(
                 [FromQuery] String bakterios,
                 [FromQuery]  String leykosit,
                 [FromQuery]  String epitkletka,
                 [FromQuery]  String gonokokki,
                 [FromQuery]  String trixomonad,
                 [FromQuery]  String mikflora,
                 [FromQuery]  String ureplazma,
                 [FromQuery]  String xlamidoz,
                 [FromQuery]  String gardnerelez,
                 [FromQuery]  String gribok,
                 [FromQuery]  String vposeve,
                 [FromQuery]  long PatientsId 
            )
        {
            AnalizBakterioskopiya analizBakterioskopiya = new AnalizBakterioskopiya();
            analizBakterioskopiya.ActiveStatus = true;
            analizBakterioskopiya.bakterios =  bakterios;
            analizBakterioskopiya.leykosit =  leykosit;
            analizBakterioskopiya.epitkletka = epitkletka;
            analizBakterioskopiya.gonokokki =  gonokokki;
            analizBakterioskopiya.trixomonad =  trixomonad;
            analizBakterioskopiya.mikflora =  mikflora;
            analizBakterioskopiya.ureplazma =  ureplazma;
            analizBakterioskopiya.xlamidoz =  xlamidoz;
            analizBakterioskopiya.gardnerelez =  gardnerelez;
            analizBakterioskopiya.gribok =  gribok;
            analizBakterioskopiya.vposeve =  vposeve;
            analizBakterioskopiya.PatientsId =  PatientsId;

            _context.analizBakterioskopiyas.Update(analizBakterioskopiya);
            await _context.SaveChangesAsync();

            return analizBakterioskopiya;
        }

        // DELETE: api/AnalizBakterioskopiyas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnalizBakterioskopiya>> DeleteAnalizBakterioskopiya(long id)
        {
            var analizBakterioskopiya = await _context.analizBakterioskopiyas.FindAsync(id);
            if (analizBakterioskopiya == null)
            {
                return NotFound();
            }

            _context.analizBakterioskopiyas.Remove(analizBakterioskopiya);
            await _context.SaveChangesAsync();

            return analizBakterioskopiya;
        }

        private bool AnalizBakterioskopiyaExists(long id)
        {
            return _context.analizBakterioskopiyas.Any(e => e.Id == id);
        }
    }
}
