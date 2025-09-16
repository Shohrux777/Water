using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.pos;

namespace ApiAll.Controllers.pos
{
    [ApiExplorerSettings(GroupName = "v5")]
    [Route("api/[controller]")]
    [ApiController]
    public class PosProductTagsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosProductTagsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosProductTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosProductTag>>> GetPosProductTag()
        {
            return await _context.PosProductTag.ToListAsync();
        }

        // GET: api/PosProductTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosProductTag>> GetPosProductTag(long id)
        {
            var posProductTag = await _context.PosProductTag.FindAsync(id);

            if (posProductTag == null)
            {
                return NotFound();
            }

            return posProductTag;
        }

        // PUT: api/PosProductTags/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosProductTag(long id, PosProductTag posProductTag)
        {
            if (id != posProductTag.id)
            {
                return BadRequest();
            }

            _context.Entry(posProductTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosProductTagExists(id))
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

        // POST: api/PosProductTags
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosProductTag>> PostPosProductTag(PosProductTag posProductTag)
        {
 

            try
            {
               _context.PosProductTag.Update(posProductTag);
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

            return CreatedAtAction("GetPosProductTag", new { id = posProductTag.id }, posProductTag);
        }

        // DELETE: api/PosProductTags/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosProductTag>> DeletePosProductTag(long id)
        {
            var posProductTag = await _context.PosProductTag.FindAsync(id);
            if (posProductTag == null)
            {
                return NotFound();
            }

            _context.PosProductTag.Remove(posProductTag);
            await _context.SaveChangesAsync();

            return posProductTag;
        }

        private bool PosProductTagExists(long id)
        {
            return _context.PosProductTag.Any(e => e.id == id);
        }
    }
}
