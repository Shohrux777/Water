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
    public class TexRaskladkiStepInformationController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexRaskladkiStepInformationController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexRaskladkiStepInformation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexRaskladkiStepInformation>>> GetTexRaskladkiStepInformation()
        {
            return await _context.TexRaskladkiStepInformation.ToListAsync();
        }

        // GET: api/TexRaskladkiStepInformation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexRaskladkiStepInformation>> GetTexRaskladkiStepInformation(long id)
        {
            var texRaskladkiStepInformation = await _context.TexRaskladkiStepInformation.FindAsync(id);

            if (texRaskladkiStepInformation == null)
            {
                return NotFound();
            }

            return texRaskladkiStepInformation;
        }

        // PUT: api/TexRaskladkiStepInformation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexRaskladkiStepInformation(long id, TexRaskladkiStepInformation texRaskladkiStepInformation)
        {
            if (id != texRaskladkiStepInformation.id)
            {
                return BadRequest();
            }

            _context.Entry(texRaskladkiStepInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexRaskladkiStepInformationExists(id))
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

        // POST: api/TexRaskladkiStepInformation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexRaskladkiStepInformation>> PostTexRaskladkiStepInformation(TexRaskladkiStepInformation texRaskladkiStepInformation)
        {
            _context.TexRaskladkiStepInformation.Add(texRaskladkiStepInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexRaskladkiStepInformation", new { id = texRaskladkiStepInformation.id }, texRaskladkiStepInformation);
        }

        // DELETE: api/TexRaskladkiStepInformation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexRaskladkiStepInformation>> DeleteTexRaskladkiStepInformation(long id)
        {
            var texRaskladkiStepInformation = await _context.TexRaskladkiStepInformation.FindAsync(id);
            if (texRaskladkiStepInformation == null)
            {
                return NotFound();
            }

            _context.TexRaskladkiStepInformation.Remove(texRaskladkiStepInformation);
            await _context.SaveChangesAsync();

            return texRaskladkiStepInformation;
        }

        private bool TexRaskladkiStepInformationExists(long id)
        {
            return _context.TexRaskladkiStepInformation.Any(e => e.id == id);
        }
    }
}
