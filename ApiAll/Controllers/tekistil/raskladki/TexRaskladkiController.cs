using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;

namespace ApiAll.Controllers.tekistil.raskladki
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexRaskladkiController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexRaskladkiController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexRaskladki
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexRaskladki>>> GetTexRaskladki()
        {
            return await _context.TexRaskladki.ToListAsync();
        }

        // GET: api/TexRaskladki/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexRaskladki>> GetTexRaskladki(long id)
        {
            var texRaskladki = await _context.TexRaskladki.FindAsync(id);

            if (texRaskladki == null)
            {
                return NotFound();
            }

            return texRaskladki;
        }

        // PUT: api/TexRaskladki/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexRaskladki(long id, TexRaskladki texRaskladki)
        {
            if (id != texRaskladki.id)
            {
                return BadRequest();
            }

            _context.Entry(texRaskladki).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexRaskladkiExists(id))
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

        // POST: api/TexRaskladki
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexRaskladki>> PostTexRaskladki(TexRaskladki texRaskladki)
        {
            _context.TexRaskladki.Update(texRaskladki);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexRaskladki", new { id = texRaskladki.id }, texRaskladki);
        }

        // DELETE: api/TexRaskladki/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexRaskladki>> DeleteTexRaskladki(long id)
        {
            var texRaskladki = await _context.TexRaskladki.FindAsync(id);
            if (texRaskladki == null)
            {
                return NotFound();
            }

            _context.TexRaskladki.Remove(texRaskladki);
            await _context.SaveChangesAsync();

            return texRaskladki;
        }

        private bool TexRaskladkiExists(long id)
        {
            return _context.TexRaskladki.Any(e => e.id == id);
        }
    }
}
