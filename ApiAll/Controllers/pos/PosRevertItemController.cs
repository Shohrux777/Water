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
    public class PosRevertItemController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosRevertItemController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosRevertItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosRevertItem>>> GetPosRevertItem()
        {
            return await _context.PosRevertItem.ToListAsync();
        }

        // GET: api/PosRevertItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosRevertItem>> GetPosRevertItem(long id)
        {
            var posRevertItem = await _context.PosRevertItem.FindAsync(id);

            if (posRevertItem == null)
            {
                return NotFound();
            }

            return posRevertItem;
        }

        // PUT: api/PosRevertItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosRevertItem(long id, PosRevertItem posRevertItem)
        {
            if (id != posRevertItem.id)
            {
                return BadRequest();
            }

            _context.Entry(posRevertItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosRevertItemExists(id))
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

        // POST: api/PosRevertItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosRevertItem>> PostPosRevertItem(PosRevertItem posRevertItem)
        {
            _context.PosRevertItem.Update(posRevertItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosRevertItem", new { id = posRevertItem.id }, posRevertItem);
        }

        // DELETE: api/PosRevertItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosRevertItem>> DeletePosRevertItem(long id)
        {
            var posRevertItem = await _context.PosRevertItem.FindAsync(id);
            if (posRevertItem == null)
            {
                return NotFound();
            }

            _context.PosRevertItem.Remove(posRevertItem);
            await _context.SaveChangesAsync();

            return posRevertItem;
        }

        private bool PosRevertItemExists(long id)
        {
            return _context.PosRevertItem.Any(e => e.id == id);
        }
    }
}
