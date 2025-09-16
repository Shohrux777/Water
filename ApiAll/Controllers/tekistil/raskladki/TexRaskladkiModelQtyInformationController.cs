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
    public class TexRaskladkiModelQtyInformationController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexRaskladkiModelQtyInformationController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexRaskladkiModelQtyInformation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexRaskladkiModelQtyInformation>>> GetTexRaskladkiModelQtyInformation()
        {
            return await _context.TexRaskladkiModelQtyInformation.ToListAsync();
        }

        // GET: api/TexRaskladkiModelQtyInformation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexRaskladkiModelQtyInformation>> GetTexRaskladkiModelQtyInformation(long id)
        {
            var texRaskladkiModelQtyInformation = await _context.TexRaskladkiModelQtyInformation.FindAsync(id);

            if (texRaskladkiModelQtyInformation == null)
            {
                return NotFound();
            }

            return texRaskladkiModelQtyInformation;
        }

        // PUT: api/TexRaskladkiModelQtyInformation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexRaskladkiModelQtyInformation(long id, TexRaskladkiModelQtyInformation texRaskladkiModelQtyInformation)
        {
            if (id != texRaskladkiModelQtyInformation.id)
            {
                return BadRequest();
            }

            _context.Entry(texRaskladkiModelQtyInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexRaskladkiModelQtyInformationExists(id))
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

        // POST: api/TexRaskladkiModelQtyInformation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexRaskladkiModelQtyInformation>> PostTexRaskladkiModelQtyInformation(TexRaskladkiModelQtyInformation texRaskladkiModelQtyInformation)
        {
            _context.TexRaskladkiModelQtyInformation.Add(texRaskladkiModelQtyInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexRaskladkiModelQtyInformation", new { id = texRaskladkiModelQtyInformation.id }, texRaskladkiModelQtyInformation);
        }

        // DELETE: api/TexRaskladkiModelQtyInformation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexRaskladkiModelQtyInformation>> DeleteTexRaskladkiModelQtyInformation(long id)
        {
            var texRaskladkiModelQtyInformation = await _context.TexRaskladkiModelQtyInformation.FindAsync(id);
            if (texRaskladkiModelQtyInformation == null)
            {
                return NotFound();
            }

            _context.TexRaskladkiModelQtyInformation.Remove(texRaskladkiModelQtyInformation);
            await _context.SaveChangesAsync();

            return texRaskladkiModelQtyInformation;
        }

        private bool TexRaskladkiModelQtyInformationExists(long id)
        {
            return _context.TexRaskladkiModelQtyInformation.Any(e => e.id == id);
        }
    }
}
