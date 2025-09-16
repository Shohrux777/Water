using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil.sewextrawork;

namespace ApiAll.Controllers.tekistil.sewextrawork
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexSewExtraWorkItemController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexSewExtraWorkItemController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexSewExtraWorkItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexSewExtraWorkItem>>> GetTexSewExtraWorkItem()
        {
            return await _context.TexSewExtraWorkItem.ToListAsync();
        }

        // GET: api/TexSewExtraWorkItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexSewExtraWorkItem>> GetTexSewExtraWorkItem(long id)
        {
            var texSewExtraWorkItem = await _context.TexSewExtraWorkItem.FindAsync(id);

            if (texSewExtraWorkItem == null)
            {
                return NotFound();
            }

            return texSewExtraWorkItem;
        }

        // PUT: api/TexSewExtraWorkItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexSewExtraWorkItem(long id, TexSewExtraWorkItem texSewExtraWorkItem)
        {
            if (id != texSewExtraWorkItem.id)
            {
                return BadRequest();
            }

            _context.Entry(texSewExtraWorkItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexSewExtraWorkItemExists(id))
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

        // POST: api/TexSewExtraWorkItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexSewExtraWorkItem>> PostTexSewExtraWorkItem(TexSewExtraWorkItem texSewExtraWorkItem)
        {
            _context.TexSewExtraWorkItem.Update(texSewExtraWorkItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexSewExtraWorkItem", new { id = texSewExtraWorkItem.id }, texSewExtraWorkItem);
        }

        // DELETE: api/TexSewExtraWorkItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexSewExtraWorkItem>> DeleteTexSewExtraWorkItem(long id)
        {
            var texSewExtraWorkItem = await _context.TexSewExtraWorkItem.FindAsync(id);
            if (texSewExtraWorkItem == null)
            {
                return NotFound();
            }

            _context.TexSewExtraWorkItem.Remove(texSewExtraWorkItem);
            await _context.SaveChangesAsync();

            return texSewExtraWorkItem;
        }

        private bool TexSewExtraWorkItemExists(long id)
        {
            return _context.TexSewExtraWorkItem.Any(e => e.id == id);
        }
    }
}
