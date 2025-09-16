using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil.access;

namespace ApiAll.Controllers.tekistil.sewaccess
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexWareHouseAccessController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexWareHouseAccessController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexWareHouseAccess
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexWareHouseAccess>>> GetTexWareHouseAccess()
        {
            return await _context.TexWareHouseAccess.ToListAsync();
        }

        // GET: api/TexWareHouseAccess/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexWareHouseAccess>> GetTexWareHouseAccess(long id)
        {
            var texWareHouseAccess = await _context.TexWareHouseAccess.FindAsync(id);

            if (texWareHouseAccess == null)
            {
                return NotFound();
            }

            return texWareHouseAccess;
        }

        // PUT: api/TexWareHouseAccess/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexWareHouseAccess(long id, TexWareHouseAccess texWareHouseAccess)
        {
            if (id != texWareHouseAccess.id)
            {
                return BadRequest();
            }

            _context.Entry(texWareHouseAccess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexWareHouseAccessExists(id))
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

        // POST: api/TexWareHouseAccess
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexWareHouseAccess>> PostTexWareHouseAccess(TexWareHouseAccess texWareHouseAccess)
        {
            _context.TexWareHouseAccess.Update(texWareHouseAccess);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexWareHouseAccess", new { id = texWareHouseAccess.id }, texWareHouseAccess);
        }

        // DELETE: api/TexWareHouseAccess/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexWareHouseAccess>> DeleteTexWareHouseAccess(long id)
        {
            var texWareHouseAccess = await _context.TexWareHouseAccess.FindAsync(id);
            if (texWareHouseAccess == null)
            {
                return NotFound();
            }

            _context.TexWareHouseAccess.Remove(texWareHouseAccess);
            await _context.SaveChangesAsync();

            return texWareHouseAccess;
        }

        private bool TexWareHouseAccessExists(long id)
        {
            return _context.TexWareHouseAccess.Any(e => e.id == id);
        }
    }
}
