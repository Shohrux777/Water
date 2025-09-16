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
    public class TexXarakteristikaToolsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexXarakteristikaToolsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexXarakteristikaTools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexXarakteristikaTool>>> GetTexXarakteristikaTool()
        {
            return await _context.TexXarakteristikaTool.Where(p => p.active_status == true).OrderByDescending(p => p.id).ToListAsync();
        }

        // GET: api/TexXarakteristikaTools/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexXarakteristikaTool>> GetTexXarakteristikaTool(long id)
        {
            var texXarakteristikaTool = await _context.TexXarakteristikaTool.FindAsync(id);

            if (texXarakteristikaTool == null)
            {
                return NotFound();
            }
            texXarakteristikaTool.xarakteristika = await _context.TexXarakteristika.FindAsync(texXarakteristikaTool.xarakteristika_id);

            return texXarakteristikaTool;
        }

        // PUT: api/TexXarakteristikaTools/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexXarakteristikaTool(long id, TexXarakteristikaTool texXarakteristikaTool)
        {
            if (id != texXarakteristikaTool.id)
            {
                return BadRequest();
            }

            _context.Entry(texXarakteristikaTool).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexXarakteristikaToolExists(id))
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

        // POST: api/TexXarakteristikaTools
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexXarakteristikaTool>> PostTexXarakteristikaTool(TexXarakteristikaTool texXarakteristikaTool)
        {



            try
            {
            _context.TexXarakteristikaTool.Update(texXarakteristikaTool);
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

            return CreatedAtAction("GetTexXarakteristikaTool", new { id = texXarakteristikaTool.id }, texXarakteristikaTool);
        }

        // DELETE: api/TexXarakteristikaTools/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexXarakteristikaTool>> DeleteTexXarakteristikaTool(long id)
        {
            var texXarakteristikaTool = await _context.TexXarakteristikaTool.FindAsync(id);
            if (texXarakteristikaTool == null)
            {
                return NotFound();
            }

            try { 
                _context.TexXarakteristikaTool.Remove(texXarakteristikaTool);
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
            return texXarakteristikaTool;
        }

        private bool TexXarakteristikaToolExists(long id)
        {
            return _context.TexXarakteristikaTool.Any(e => e.id == id);
        }
    }
}
