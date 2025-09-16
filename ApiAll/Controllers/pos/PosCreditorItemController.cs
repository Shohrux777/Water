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
    public class PosCreditorItemController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosCreditorItemController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosCreditorItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosCreditorItem>>> GetPosCreditorItem()
        {
            return await _context.PosCreditorItem.ToListAsync();
        }

        // GET: api/PosCreditorItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosCreditorItem>> GetPosCreditorItem(long id)
        {
            var posCreditorItem = await _context.PosCreditorItem.FindAsync(id);

            if (posCreditorItem == null)
            {
                return NotFound();
            }

            return posCreditorItem;
        }

        // PUT: api/PosCreditorItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosCreditorItem(long id, PosCreditorItem posCreditorItem)
        {
            if (id != posCreditorItem.id)
            {
                return BadRequest();
            }

            _context.Entry(posCreditorItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosCreditorItemExists(id))
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

        // POST: api/PosCreditorItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosCreditorItem>> PostPosCreditorItem(PosCreditorItem posCreditorItem)
        {
            _context.PosCreditorItem.Update(posCreditorItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosCreditorItem", new { id = posCreditorItem.id }, posCreditorItem);
        }

        // DELETE: api/PosCreditorItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosCreditorItem>> DeletePosCreditorItem(long id)
        {
            var posCreditorItem = await _context.PosCreditorItem.FindAsync(id);
            if (posCreditorItem == null)
            {
                return NotFound();
            }

            _context.PosCreditorItem.Remove(posCreditorItem);
            await _context.SaveChangesAsync();

            return posCreditorItem;
        }

        private bool PosCreditorItemExists(long id)
        {
            return _context.PosCreditorItem.Any(e => e.id == id);
        }
    }
}
