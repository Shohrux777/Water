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
    public class TexExtraworksController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexExtraworksController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexExtraworks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexExtrawork>>> GetTexExtrawork()
        {
            return await _context.TexExtrawork.Where( p => p.active_status == true).ToListAsync();
        }

        // GET: api/TexExtraworks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexExtrawork>> GetTexExtrawork(long id)
        {
            var texExtrawork = await _context.TexExtrawork.FindAsync(id);

            if (texExtrawork == null)
            {
                return NotFound();
            }

            return texExtrawork;
        }

        // PUT: api/TexExtraworks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexExtrawork(long id, TexExtrawork texExtrawork)
        {
            if (id != texExtrawork.id)
            {
                return BadRequest();
            }

            _context.Entry(texExtrawork).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexExtraworkExists(id))
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

        // POST: api/TexExtraworks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexExtrawork>> PostTexExtrawork(TexExtrawork texExtrawork)
        {


            try
            {
            _context.TexExtrawork.Update(texExtrawork);
            await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                return NotFound(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFound(e?.InnerException?.Message);
            }
            return CreatedAtAction("GetTexExtrawork", new { id = texExtrawork.id }, texExtrawork);
        }

        // DELETE: api/TexExtraworks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexExtrawork>> DeleteTexExtrawork(long id)
        {
            var texExtrawork = await _context.TexExtrawork.FindAsync(id);
            if (texExtrawork == null)
            {
                return NotFound();
            }

            texExtrawork.active_status = false;
            _context.TexExtrawork.Update(texExtrawork);
            await _context.SaveChangesAsync();

            return texExtrawork;
        }

        private bool TexExtraworkExists(long id)
        {
            return _context.TexExtrawork.Any(e => e.id == id);
        }
    }
}
