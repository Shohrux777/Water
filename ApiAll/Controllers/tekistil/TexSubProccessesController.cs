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
    public class TexSubProccessesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexSubProccessesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexSubProccesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexSubProccess>>> GetTexSubProccess()
        {
            return await _context.TexSubProccess.ToListAsync();
        }

        // GET: api/TexSubProccesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexSubProccess>> GetTexSubProccess(long id)
        {
            var texSubProccess = await _context.TexSubProccess.FindAsync(id);

            if (texSubProccess == null)
            {
                return NotFound();
            }

            return texSubProccess;
        }

        // PUT: api/TexSubProccesses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexSubProccess(long id, TexSubProccess texSubProccess)
        {
            if (id != texSubProccess.id)
            {
                return BadRequest();
            }

            _context.Entry(texSubProccess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexSubProccessExists(id))
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

        // POST: api/TexSubProccesses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexSubProccess>> PostTexSubProccess(TexSubProccess texSubProccess)
        {


            try
            {
            _context.TexSubProccess.Update(texSubProccess);
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

            return CreatedAtAction("GetTexSubProccess", new { id = texSubProccess.id }, texSubProccess);
        }

        // DELETE: api/TexSubProccesses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexSubProccess>> DeleteTexSubProccess(long id)
        {
            var texSubProccess = await _context.TexSubProccess.FindAsync(id);
            if (texSubProccess == null)
            {
                return NotFound();
            }

            texSubProccess.active_status = false;
            _context.TexSubProccess.Update(texSubProccess);
            await _context.SaveChangesAsync();

            return texSubProccess;
        }

        private bool TexSubProccessExists(long id)
        {
            return _context.TexSubProccess.Any(e => e.id == id);
        }
    }
}
