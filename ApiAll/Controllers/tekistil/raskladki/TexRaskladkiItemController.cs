using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;

namespace ApiAll.Controllers.tekistil.raskladki
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexRaskladkiItemController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexRaskladkiItemController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexRaskladkiItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexRaskladkiItem>>> GetTexRaskladkiItem()
        {
            return await _context.TexRaskladkiItem.ToListAsync();
        }

        // GET: api/TexRaskladkiItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexRaskladkiItem>> GetTexRaskladkiItem(long id)
        {
            var texRaskladkiItem = await _context.TexRaskladkiItem.FindAsync(id);

            if (texRaskladkiItem == null)
            {
                return NotFound();
            }

            return texRaskladkiItem;
        }

        // PUT: api/TexRaskladkiItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexRaskladkiItem(long id, TexRaskladkiItem texRaskladkiItem)
        {
            if (id != texRaskladkiItem.id)
            {
                return BadRequest();
            }

            _context.Entry(texRaskladkiItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexRaskladkiItemExists(id))
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

        // POST: api/TexRaskladkiItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexRaskladkiItem>> PostTexRaskladkiItem(TexRaskladkiItem texRaskladkiItem)
        {
            _context.TexRaskladkiItem.Add(texRaskladkiItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexRaskladkiItem", new { id = texRaskladkiItem.id }, texRaskladkiItem);
        }

        // DELETE: api/TexRaskladkiItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexRaskladkiItem>> DeleteTexRaskladkiItem(long id)
        {
            var texRaskladkiItem = await _context.TexRaskladkiItem.FindAsync(id);
            if (texRaskladkiItem == null)
            {
                return NotFound();
            }

            _context.TexRaskladkiItem.Remove(texRaskladkiItem);
            await _context.SaveChangesAsync();

            return texRaskladkiItem;
        }

        private bool TexRaskladkiItemExists(long id)
        {
            return _context.TexRaskladkiItem.Any(e => e.id == id);
        }
    }
}
