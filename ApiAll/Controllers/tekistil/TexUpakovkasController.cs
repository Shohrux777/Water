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
    public class TexUpakovkasController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexUpakovkasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexUpakovkas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexUpakovka>>> GetTexUpakovka()
        {
            return await _context.TexUpakovka.ToListAsync();
        }

        // GET: api/TexUpakovkas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexUpakovka>> GetTexUpakovka(long id)
        {
            var texUpakovka = await _context.TexUpakovka.FindAsync(id);

            if (texUpakovka == null)
            {
                return NotFound();
            }

            return texUpakovka;
        }

        // PUT: api/TexUpakovkas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexUpakovka(long id, TexUpakovka texUpakovka)
        {
            if (id != texUpakovka.id)
            {
                return BadRequest();
            }

            _context.Entry(texUpakovka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexUpakovkaExists(id))
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

        // POST: api/TexUpakovkas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexUpakovka>> PostTexUpakovka(TexUpakovka texUpakovka)
        {
    

            try
            {
              _context.TexUpakovka.Update(texUpakovka);
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

            return CreatedAtAction("GetTexUpakovka", new { id = texUpakovka.id }, texUpakovka);
        }

        // DELETE: api/TexUpakovkas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexUpakovka>> DeleteTexUpakovka(long id)
        {
            var texUpakovka = await _context.TexUpakovka.FindAsync(id);
            if (texUpakovka == null)
            {
                return NotFound();
            }

            _context.TexUpakovka.Remove(texUpakovka);
            await _context.SaveChangesAsync();

            return texUpakovka;
        }

        private bool TexUpakovkaExists(long id)
        {
            return _context.TexUpakovka.Any(e => e.id == id);
        }
    }
}
