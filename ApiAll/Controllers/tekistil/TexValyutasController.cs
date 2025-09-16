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
    public class TexValyutasController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexValyutasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexValyutas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexValyuta>>> GetTexValyuta()
        {
            return await _context.TexValyuta.ToListAsync();
        }

        // GET: api/TexValyutas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexValyuta>> GetTexValyuta(long id)
        {
            var texValyuta = await _context.TexValyuta.FindAsync(id);

            if (texValyuta == null)
            {
                return NotFound();
            }

            return texValyuta;
        }

        // PUT: api/TexValyutas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexValyuta(long id, TexValyuta texValyuta)
        {
            if (id != texValyuta.id)
            {
                return BadRequest();
            }

            _context.Entry(texValyuta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexValyutaExists(id))
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

        // POST: api/TexValyutas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexValyuta>> PostTexValyuta(TexValyuta texValyuta)
        {
            

            try
            {
_context.TexValyuta.Update(texValyuta);
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

            return CreatedAtAction("GetTexValyuta", new { id = texValyuta.id }, texValyuta);
        }

        // DELETE: api/TexValyutas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexValyuta>> DeleteTexValyuta(long id)
        {
            var texValyuta = await _context.TexValyuta.FindAsync(id);
            if (texValyuta == null)
            {
                return NotFound();
            }

            _context.TexValyuta.Remove(texValyuta);
            await _context.SaveChangesAsync();

            return texValyuta;
        }

        private bool TexValyutaExists(long id)
        {
            return _context.TexValyuta.Any(e => e.id == id);
        }
    }
}
