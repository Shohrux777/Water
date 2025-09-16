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
    public class TexRaskladkiDeviceInformationController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexRaskladkiDeviceInformationController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexRaskladkiDeviceInformation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexRaskladkiDeviceInformation>>> GetTexRaskladkiDeviceInformation()
        {
            return await _context.TexRaskladkiDeviceInformation.ToListAsync();
        }

        // GET: api/TexRaskladkiDeviceInformation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexRaskladkiDeviceInformation>> GetTexRaskladkiDeviceInformation(long id)
        {
            var texRaskladkiDeviceInformation = await _context.TexRaskladkiDeviceInformation.FindAsync(id);

            if (texRaskladkiDeviceInformation == null)
            {
                return NotFound();
            }

            return texRaskladkiDeviceInformation;
        }

        // PUT: api/TexRaskladkiDeviceInformation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexRaskladkiDeviceInformation(long id, TexRaskladkiDeviceInformation texRaskladkiDeviceInformation)
        {
            if (id != texRaskladkiDeviceInformation.id)
            {
                return BadRequest();
            }

            _context.Entry(texRaskladkiDeviceInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexRaskladkiDeviceInformationExists(id))
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

        // POST: api/TexRaskladkiDeviceInformation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexRaskladkiDeviceInformation>> PostTexRaskladkiDeviceInformation(TexRaskladkiDeviceInformation texRaskladkiDeviceInformation)
        {
            _context.TexRaskladkiDeviceInformation.Add(texRaskladkiDeviceInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexRaskladkiDeviceInformation", new { id = texRaskladkiDeviceInformation.id }, texRaskladkiDeviceInformation);
        }

        // DELETE: api/TexRaskladkiDeviceInformation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexRaskladkiDeviceInformation>> DeleteTexRaskladkiDeviceInformation(long id)
        {
            var texRaskladkiDeviceInformation = await _context.TexRaskladkiDeviceInformation.FindAsync(id);
            if (texRaskladkiDeviceInformation == null)
            {
                return NotFound();
            }

            _context.TexRaskladkiDeviceInformation.Remove(texRaskladkiDeviceInformation);
            await _context.SaveChangesAsync();

            return texRaskladkiDeviceInformation;
        }

        private bool TexRaskladkiDeviceInformationExists(long id)
        {
            return _context.TexRaskladkiDeviceInformation.Any(e => e.id == id);
        }
    }
}
