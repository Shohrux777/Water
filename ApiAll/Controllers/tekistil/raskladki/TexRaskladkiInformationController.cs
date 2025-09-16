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
    public class TexRaskladkiInformationController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexRaskladkiInformationController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexRaskladkiInformation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexRaskladkiInformation>>> GetTexRaskladkiInformation()
        {
            return await _context.TexRaskladkiInformation.ToListAsync();
        }

        // GET: api/TexRaskladkiInformation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexRaskladkiInformation>> GetTexRaskladkiInformation(long id)
        {
            var texRaskladkiInformation = await _context.TexRaskladkiInformation.FindAsync(id);

            if (texRaskladkiInformation == null)
            {
                return NotFound();
            }

            return texRaskladkiInformation;
        }

        // PUT: api/TexRaskladkiInformation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexRaskladkiInformation(long id, TexRaskladkiInformation texRaskladkiInformation)
        {
            if (id != texRaskladkiInformation.id)
            {
                return BadRequest();
            }

            _context.Entry(texRaskladkiInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexRaskladkiInformationExists(id))
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

        // POST: api/TexRaskladkiInformation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexRaskladkiInformation>> PostTexRaskladkiInformation(TexRaskladkiInformation texRaskladkiInformation)
        {
            _context.TexRaskladkiInformation.Add(texRaskladkiInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexRaskladkiInformation", new { id = texRaskladkiInformation.id }, texRaskladkiInformation);
        }

        // DELETE: api/TexRaskladkiInformation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexRaskladkiInformation>> DeleteTexRaskladkiInformation(long id)
        {
            var texRaskladkiInformation = await _context.TexRaskladkiInformation.FindAsync(id);
            if (texRaskladkiInformation == null)
            {
                return NotFound();
            }

            _context.TexRaskladkiInformation.Remove(texRaskladkiInformation);
            await _context.SaveChangesAsync();

            return texRaskladkiInformation;
        }

        private bool TexRaskladkiInformationExists(long id)
        {
            return _context.TexRaskladkiInformation.Any(e => e.id == id);
        }
    }
}
