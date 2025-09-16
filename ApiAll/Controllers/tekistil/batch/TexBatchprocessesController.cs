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
    public class TexBatchprocessesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexBatchprocessesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexBatchprocesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexBatchprocess>>> GetTexBatchprocess()
        {
            return await _context.TexBatchprocess.ToListAsync();
        }

        // GET: api/TexBatchprocesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexBatchprocess>> GetTexBatchprocess(long id)
        {
            var texBatchprocess = await _context.TexBatchprocess.FindAsync(id);

            if (texBatchprocess == null)
            {
                return NotFound();
            }

            return texBatchprocess;
        }

        // PUT: api/TexBatchprocesses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexBatchprocess(long id, TexBatchprocess texBatchprocess)
        {
            if (id != texBatchprocess.id)
            {
                return BadRequest();
            }

            _context.Entry(texBatchprocess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexBatchprocessExists(id))
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

        // POST: api/TexBatchprocesses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexBatchprocess>> PostTexBatchprocess(TexBatchprocess texBatchprocess)
        {
            _context.TexBatchprocess.Update(texBatchprocess);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexBatchprocess", new { id = texBatchprocess.id }, texBatchprocess);
        }

        // DELETE: api/TexBatchprocesses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexBatchprocess>> DeleteTexBatchprocess(long id)
        {
            var texBatchprocess = await _context.TexBatchprocess.FindAsync(id);
            if (texBatchprocess == null)
            {
                return NotFound();
            }

            _context.TexBatchprocess.Remove(texBatchprocess);
            await _context.SaveChangesAsync();

            return texBatchprocess;
        }

        private bool TexBatchprocessExists(long id)
        {
            return _context.TexBatchprocess.Any(e => e.id == id);
        }
    }
}
