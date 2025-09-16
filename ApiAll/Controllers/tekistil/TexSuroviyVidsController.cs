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
    public class TexSuroviyVidsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexSuroviyVidsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexSuroviyVids
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexSuroviyVid>>> GetTexSuroviyVid()
        {
            return await _context.TexSuroviyVid.ToListAsync();
        }

        // GET: api/TexSuroviyVids/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexSuroviyVid>> GetTexSuroviyVid(long id)
        {
            var texSuroviyVid = await _context.TexSuroviyVid.FindAsync(id);

            if (texSuroviyVid == null)
            {
                return NotFound();
            }

            return texSuroviyVid;
        }

        // PUT: api/TexSuroviyVids/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexSuroviyVid(long id, TexSuroviyVid texSuroviyVid)
        {
            if (id != texSuroviyVid.id)
            {
                return BadRequest();
            }

            _context.Entry(texSuroviyVid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexSuroviyVidExists(id))
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

        // POST: api/TexSuroviyVids
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexSuroviyVid>> PostTexSuroviyVid(TexSuroviyVid texSuroviyVid)
        {
 

            try
            {
           _context.TexSuroviyVid.Update(texSuroviyVid);
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

            return CreatedAtAction("GetTexSuroviyVid", new { id = texSuroviyVid.id }, texSuroviyVid);
        }

        // DELETE: api/TexSuroviyVids/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexSuroviyVid>> DeleteTexSuroviyVid(long id)
        {
            var texSuroviyVid = await _context.TexSuroviyVid.FindAsync(id);
            if (texSuroviyVid == null)
            {
                return NotFound();
            }

            _context.TexSuroviyVid.Remove(texSuroviyVid);
            await _context.SaveChangesAsync();

            return texSuroviyVid;
        }

        private bool TexSuroviyVidExists(long id)
        {
            return _context.TexSuroviyVid.Any(e => e.id == id);
        }
    }
}
