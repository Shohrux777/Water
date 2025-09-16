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
    public class TexMainProccessesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexMainProccessesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexMainProccesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexMainProccess>>> GetTexMainProccess()
        {
            return await _context.TexMainProccess.Where(p => p.active_status == true).ToListAsync();
        }

        // GET: api/TexMainProccesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexMainProccess>> GetTexMainProccess(long id)
        {
            var texMainProccess = await _context.TexMainProccess.FindAsync(id);

            if (texMainProccess == null)
            {
                return NotFound();
            }

            return texMainProccess;
        }

        // PUT: api/TexMainProccesses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexMainProccess(long id, TexMainProccess texMainProccess)
        {
            if (id != texMainProccess.id)
            {
                return BadRequest();
            }

            _context.Entry(texMainProccess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexMainProccessExists(id))
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

        // POST: api/TexMainProccesses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexMainProccess>> PostTexMainProccess(TexMainProccess texMainProccess)
        {
         


            try
            {
   _context.TexMainProccess.Update(texMainProccess);
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

            return CreatedAtAction("GetTexMainProccess", new { id = texMainProccess.id }, texMainProccess);
        }

        // DELETE: api/TexMainProccesses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexMainProccess>> DeleteTexMainProccess(long id)
        {
            var texMainProccess = await _context.TexMainProccess.FindAsync(id);
            if (texMainProccess == null)
            {
                return NotFound();
            }
            texMainProccess.active_status = false;

            _context.TexMainProccess.Update(texMainProccess);
            await _context.SaveChangesAsync();

            return texMainProccess;
        }

        private bool TexMainProccessExists(long id)
        {
            return _context.TexMainProccess.Any(e => e.id == id);
        }
    }
}
