using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;

namespace ApiAll.Controllers.tekistil
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexDeviceTypesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexDeviceTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexDeviceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexDeviceType>>> GetTexDeviceType()
        {
            return await _context.TexDeviceType.ToListAsync();
        }

        // GET: api/TexDeviceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexDeviceType>> GetTexDeviceType(long id)
        {
            var texDeviceType = await _context.TexDeviceType.FindAsync(id);

            if (texDeviceType == null)
            {
                return NotFound();
            }

            return texDeviceType;
        }

        // PUT: api/TexDeviceTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexDeviceType(long id, TexDeviceType texDeviceType)
        {
            if (id != texDeviceType.id)
            {
                return BadRequest();
            }

            _context.Entry(texDeviceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexDeviceTypeExists(id))
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

        // POST: api/TexDeviceTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexDeviceType>> PostTexDeviceType(TexDeviceType texDeviceType)
        {
            _context.TexDeviceType.Update(texDeviceType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexDeviceType", new { id = texDeviceType.id }, texDeviceType);
        }

        // DELETE: api/TexDeviceTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexDeviceType>> DeleteTexDeviceType(long id)
        {
            var texDeviceType = await _context.TexDeviceType.FindAsync(id);
            if (texDeviceType == null)
            {
                return NotFound();
            }

            _context.TexDeviceType.Remove(texDeviceType);
            await _context.SaveChangesAsync();

            return texDeviceType;
        }

        private bool TexDeviceTypeExists(long id)
        {
            return _context.TexDeviceType.Any(e => e.id == id);
        }
    }
}
