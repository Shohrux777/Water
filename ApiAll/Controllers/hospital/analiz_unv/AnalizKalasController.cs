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
    public class AnalizKalasController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AnalizKalasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/AnalizKalas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalizKala>>> GetanalizKalas()
        {
            return await _context.analizKalas.OrderByDescending(p => p.Id).ToListAsync();
        }

        [HttpGet("getByPatientsIdAnalizKalas")]
        public async Task<ActionResult<IEnumerable<AnalizKala>>> getByPatientsIdAnalizKalas([FromQuery] long PatientsId)
        {
            return await _context.analizKalas.Where(p => p.PatientsId == PatientsId).ToListAsync();
        }

        // GET: api/AnalizKalas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalizKala>> GetAnalizKala(long id)
        {
            var analizKala = await _context.analizKalas.FindAsync(id);

            if (analizKala == null)
            {
                return NotFound();
            }

            return analizKala;
        }

        // PUT: api/AnalizKalas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalizKala(long id, AnalizKala analizKala)
        {
            if (id != analizKala.Id)
            {
                return BadRequest();
            }

            _context.Entry(analizKala).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalizKalaExists(id))
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

        // POST: api/AnalizKalas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnalizKala>> PostAnalizKala(AnalizKala analizKala)
        {
            _context.analizKalas.Add(analizKala);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalizKala", new { id = analizKala.Id }, analizKala);
        }


        [HttpGet("AddAnalizKala")]
        public async Task<ActionResult<AnalizKala>> AddAnalizKala(
             [FromQuery] String count,
            [FromQuery] String zichlik,
            [FromQuery] String shakli,
            [FromQuery] String rang,
            [FromQuery] String reaksiya,
            [FromQuery] String xid,
            [FromQuery] String ovqat_qoldiqlari,
            [FromQuery] String konsistensiya,
            [FromQuery] String sliz,
            [FromQuery] String qon,
            [FromQuery] String yiring,
            [FromQuery] long PatientsId

            )
        {



        AnalizKala analizKala = new AnalizKala();
            analizKala.ActiveStatus = true;
            analizKala.count = count;
            analizKala.zichlik = zichlik;
            analizKala.shakli = shakli;
            analizKala.rang = rang;
            analizKala.reaksiya = reaksiya;
            analizKala.xid = xid;
            analizKala.ovqat_qoldiqlari = ovqat_qoldiqlari;
            analizKala.konsistensiya = konsistensiya;
            analizKala.sliz = sliz;
            analizKala.qon = qon;
            analizKala.yiring = yiring;
            analizKala.PatientsId = PatientsId;
            _context.analizKalas.Update(analizKala);
            await _context.SaveChangesAsync();

            return analizKala;
        }
        // DELETE: api/AnalizKalas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnalizKala>> DeleteAnalizKala(long id)
        {
            var analizKala = await _context.analizKalas.FindAsync(id);
            if (analizKala == null)
            {
                return NotFound();
            }

            _context.analizKalas.Remove(analizKala);
            await _context.SaveChangesAsync();

            return analizKala;
        }

        private bool AnalizKalaExists(long id)
        {
            return _context.analizKalas.Any(e => e.Id == id);
        }
    }
}
