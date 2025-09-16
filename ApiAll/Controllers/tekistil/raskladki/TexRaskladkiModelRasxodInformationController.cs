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
    public class TexRaskladkiModelRasxodInformationController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexRaskladkiModelRasxodInformationController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexRaskladkiModelRasxodInformation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexRaskladkiModelRasxodInformation>>> GetTexRaskladkiModelRasxodInformation()
        {
            return await _context.TexRaskladkiModelRasxodInformation.ToListAsync();
        }

        // GET: api/TexRaskladkiModelRasxodInformation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexRaskladkiModelRasxodInformation>> GetTexRaskladkiModelRasxodInformation(long id)
        {
            var texRaskladkiModelRasxodInformation = await _context.TexRaskladkiModelRasxodInformation.FindAsync(id);

            if (texRaskladkiModelRasxodInformation == null)
            {
                return NotFound();
            }

            return texRaskladkiModelRasxodInformation;
        }

        // PUT: api/TexRaskladkiModelRasxodInformation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexRaskladkiModelRasxodInformation(long id, TexRaskladkiModelRasxodInformation texRaskladkiModelRasxodInformation)
        {
            if (id != texRaskladkiModelRasxodInformation.id)
            {
                return BadRequest();
            }

            _context.Entry(texRaskladkiModelRasxodInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexRaskladkiModelRasxodInformationExists(id))
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

        // POST: api/TexRaskladkiModelRasxodInformation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexRaskladkiModelRasxodInformation>> PostTexRaskladkiModelRasxodInformation(TexRaskladkiModelRasxodInformation texRaskladkiModelRasxodInformation)
        {
            _context.TexRaskladkiModelRasxodInformation.Add(texRaskladkiModelRasxodInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexRaskladkiModelRasxodInformation", new { id = texRaskladkiModelRasxodInformation.id }, texRaskladkiModelRasxodInformation);
        }

        // DELETE: api/TexRaskladkiModelRasxodInformation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexRaskladkiModelRasxodInformation>> DeleteTexRaskladkiModelRasxodInformation(long id)
        {
            var texRaskladkiModelRasxodInformation = await _context.TexRaskladkiModelRasxodInformation.FindAsync(id);
            if (texRaskladkiModelRasxodInformation == null)
            {
                return NotFound();
            }

            _context.TexRaskladkiModelRasxodInformation.Remove(texRaskladkiModelRasxodInformation);
            await _context.SaveChangesAsync();

            return texRaskladkiModelRasxodInformation;
        }

        private bool TexRaskladkiModelRasxodInformationExists(long id)
        {
            return _context.TexRaskladkiModelRasxodInformation.Any(e => e.id == id);
        }
    }
}
