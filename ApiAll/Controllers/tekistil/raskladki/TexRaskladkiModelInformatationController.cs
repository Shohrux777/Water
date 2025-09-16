using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil.raskladki;

namespace ApiAll.Controllers.tekistil.raskladki
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexRaskladkiModelInformatationController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexRaskladkiModelInformatationController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexRaskladkiModelInformatation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexRaskladkiModelInformatation>>> GetTexRaskladkiModelInformatation()
        {
            return await _context.TexRaskladkiModelInformatation.ToListAsync();
        }

        // GET: api/TexRaskladkiModelInformatation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexRaskladkiModelInformatation>> GetTexRaskladkiModelInformatation(long id)
        {
            var texRaskladkiModelInformatation = await _context.TexRaskladkiModelInformatation.FindAsync(id);

            if (texRaskladkiModelInformatation == null)
            {
                return NotFound();
            }

            return texRaskladkiModelInformatation;
        }

        // PUT: api/TexRaskladkiModelInformatation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexRaskladkiModelInformatation(long id, TexRaskladkiModelInformatation texRaskladkiModelInformatation)
        {
            if (id != texRaskladkiModelInformatation.id)
            {
                return BadRequest();
            }

            _context.Entry(texRaskladkiModelInformatation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexRaskladkiModelInformatationExists(id))
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

        // POST: api/TexRaskladkiModelInformatation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexRaskladkiModelInformatation>> PostTexRaskladkiModelInformatation(TexRaskladkiModelInformatation texRaskladkiModelInformatation)
        {
            _context.TexRaskladkiModelInformatation.Add(texRaskladkiModelInformatation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexRaskladkiModelInformatation", new { id = texRaskladkiModelInformatation.id }, texRaskladkiModelInformatation);
        }

        // DELETE: api/TexRaskladkiModelInformatation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexRaskladkiModelInformatation>> DeleteTexRaskladkiModelInformatation(long id)
        {
            var texRaskladkiModelInformatation = await _context.TexRaskladkiModelInformatation.FindAsync(id);
            if (texRaskladkiModelInformatation == null)
            {
                return NotFound();
            }

            _context.TexRaskladkiModelInformatation.Remove(texRaskladkiModelInformatation);
            await _context.SaveChangesAsync();

            return texRaskladkiModelInformatation;
        }

        private bool TexRaskladkiModelInformatationExists(long id)
        {
            return _context.TexRaskladkiModelInformatation.Any(e => e.id == id);
        }
    }
}
