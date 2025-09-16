using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tegirmon;

namespace ApiAll.Controllers.tegirmon
{
    [ApiExplorerSettings(GroupName = "v7")]
    [Route("api/[controller]")]
    [ApiController]
    public class TegirmonClientOstatkaItemsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonClientOstatkaItemsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonClientOstatkaItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonClientOstatkaItem>>> GetTegirmonClientOstatkaItem()
        {
            return await _context.TegirmonClientOstatkaItem.ToListAsync();
        }

        // GET: api/TegirmonClientOstatkaItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonClientOstatkaItem>> GetTegirmonClientOstatkaItem(long id)
        {
            var tegirmonClientOstatkaItem = await _context.TegirmonClientOstatkaItem.FindAsync(id);

            if (tegirmonClientOstatkaItem == null)
            {
                return NotFound();
            }

            return tegirmonClientOstatkaItem;
        }

        // PUT: api/TegirmonClientOstatkaItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonClientOstatkaItem(long id, TegirmonClientOstatkaItem tegirmonClientOstatkaItem)
        {
            if (id != tegirmonClientOstatkaItem.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonClientOstatkaItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonClientOstatkaItemExists(id))
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

        // POST: api/TegirmonClientOstatkaItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonClientOstatkaItem>> PostTegirmonClientOstatkaItem(TegirmonClientOstatkaItem tegirmonClientOstatkaItem)
        {
            _context.TegirmonClientOstatkaItem.Update(tegirmonClientOstatkaItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonClientOstatkaItem", new { id = tegirmonClientOstatkaItem.id }, tegirmonClientOstatkaItem);
        }

        // DELETE: api/TegirmonClientOstatkaItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonClientOstatkaItem>> DeleteTegirmonClientOstatkaItem(long id)
        {
            var tegirmonClientOstatkaItem = await _context.TegirmonClientOstatkaItem.FindAsync(id);
            if (tegirmonClientOstatkaItem == null)
            {
                return NotFound();
            }

            _context.TegirmonClientOstatkaItem.Remove(tegirmonClientOstatkaItem);
            await _context.SaveChangesAsync();

            return tegirmonClientOstatkaItem;
        }

        private bool TegirmonClientOstatkaItemExists(long id)
        {
            return _context.TegirmonClientOstatkaItem.Any(e => e.id == id);
        }
    }
}
