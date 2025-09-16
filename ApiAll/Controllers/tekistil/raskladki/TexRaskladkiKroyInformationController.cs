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
    public class TexRaskladkiKroyInformationController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexRaskladkiKroyInformationController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexRaskladkiKroyInformation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexRaskladkiKroyInformation>>> GetTexRaskladkiKroyInformation()
        {
            return await _context.TexRaskladkiKroyInformation.ToListAsync();
        }

        // GET: api/TexRaskladkiKroyInformation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexRaskladkiKroyInformation>> GetTexRaskladkiKroyInformation(long id)
        {
            var texRaskladkiKroyInformation = await _context.TexRaskladkiKroyInformation.FindAsync(id);

            if (texRaskladkiKroyInformation == null)
            {
                return NotFound();
            }

            return texRaskladkiKroyInformation;
        }

        // PUT: api/TexRaskladkiKroyInformation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexRaskladkiKroyInformation(long id, TexRaskladkiKroyInformation texRaskladkiKroyInformation)
        {
            if (id != texRaskladkiKroyInformation.id)
            {
                return BadRequest();
            }

            _context.Entry(texRaskladkiKroyInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexRaskladkiKroyInformationExists(id))
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

        // POST: api/TexRaskladkiKroyInformation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexRaskladkiKroyInformation>> PostTexRaskladkiKroyInformation(TexRaskladkiKroyInformation texRaskladkiKroyInformation)
        {
            _context.TexRaskladkiKroyInformation.Add(texRaskladkiKroyInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexRaskladkiKroyInformation", new { id = texRaskladkiKroyInformation.id }, texRaskladkiKroyInformation);
        }

        // DELETE: api/TexRaskladkiKroyInformation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexRaskladkiKroyInformation>> DeleteTexRaskladkiKroyInformation(long id)
        {
            var texRaskladkiKroyInformation = await _context.TexRaskladkiKroyInformation.FindAsync(id);
            if (texRaskladkiKroyInformation == null)
            {
                return NotFound();
            }

            _context.TexRaskladkiKroyInformation.Remove(texRaskladkiKroyInformation);
            await _context.SaveChangesAsync();

            return texRaskladkiKroyInformation;
        }

        private bool TexRaskladkiKroyInformationExists(long id)
        {
            return _context.TexRaskladkiKroyInformation.Any(e => e.id == id);
        }
    }
}
