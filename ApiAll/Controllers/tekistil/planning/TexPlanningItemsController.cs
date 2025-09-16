using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil.planning;

namespace ApiAll.Controllers.tekistil.planning
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexPlanningItemsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexPlanningItemsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexPlanningItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexPlanningItems>>> GetTexPlanningItems()
        {
            return await _context.TexPlanningItems.ToListAsync();
        }

        // GET: api/TexPlanningItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexPlanningItems>> GetTexPlanningItems(long id)
        {
            var texPlanningItems = await _context.TexPlanningItems.FindAsync(id);

            if (texPlanningItems == null)
            {
                return NotFound();
            }

            return texPlanningItems;
        }

        // PUT: api/TexPlanningItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexPlanningItems(long id, TexPlanningItems texPlanningItems)
        {
            if (id != texPlanningItems.id)
            {
                return BadRequest();
            }

            _context.Entry(texPlanningItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexPlanningItemsExists(id))
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

        // POST: api/TexPlanningItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexPlanningItems>> PostTexPlanningItems(TexPlanningItems texPlanningItems)
        {
            _context.TexPlanningItems.Update(texPlanningItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexPlanningItems", new { id = texPlanningItems.id }, texPlanningItems);
        }

        // DELETE: api/TexPlanningItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexPlanningItems>> DeleteTexPlanningItems(long id)
        {
            var texPlanningItems = await _context.TexPlanningItems.FindAsync(id);
            if (texPlanningItems == null)
            {
                return NotFound();
            }

            _context.TexPlanningItems.Remove(texPlanningItems);
            await _context.SaveChangesAsync();

            return texPlanningItems;
        }

        private bool TexPlanningItemsExists(long id)
        {
            return _context.TexPlanningItems.Any(e => e.id == id);
        }
    }
}
