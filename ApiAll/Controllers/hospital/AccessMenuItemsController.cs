using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.settingsmodel;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccessMenuItemsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AccessMenuItemsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/AccessMenuItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccessMenuItem>>> GetaccessMenuItems()
        {
            return await _context.accessMenuItems.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/AccessMenuItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccessMenuItem>> GetAccessMenuItem(long id)
        {
            var accessMenuItem = await _context.accessMenuItems.FindAsync(id);

            if (accessMenuItem == null)
            {
                return NotFound();
            }

            return accessMenuItem;
        }

        // PUT: api/AccessMenuItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccessMenuItem(long id, AccessMenuItem accessMenuItem)
        {
            if (id != accessMenuItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(accessMenuItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccessMenuItemExists(id))
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

        // POST: api/AccessMenuItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AccessMenuItem>> PostAccessMenuItem(AccessMenuItem accessMenuItem)
        {
            _context.accessMenuItems.Add(accessMenuItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccessMenuItem", new { id = accessMenuItem.Id }, accessMenuItem);
        }

        // DELETE: api/AccessMenuItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccessMenuItem>> DeleteAccessMenuItem(long id)
        {
            var accessMenuItem = await _context.accessMenuItems.FindAsync(id);
            if (accessMenuItem == null)
            {
                return NotFound();
            }

            _context.accessMenuItems.Remove(accessMenuItem);
            await _context.SaveChangesAsync();

            return accessMenuItem;
        }

        private bool AccessMenuItemExists(long id)
        {
            return _context.accessMenuItems.Any(e => e.Id == id);
        }
    }
}
