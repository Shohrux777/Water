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
    public class AccessMenusController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AccessMenusController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/AccessMenus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccessMenu>>> GetaccessMenus()
        {
            return await _context.accessMenus.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/AccessMenus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccessMenu>> GetAccessMenu(long id)
        {
            var accessMenu = await _context.accessMenus.FindAsync(id);

            if (accessMenu == null)
            {
                return NotFound();
            }

            return accessMenu;
        }

        // PUT: api/AccessMenus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccessMenu(long id, AccessMenu accessMenu)
        {
            if (id != accessMenu.Id)
            {
                return BadRequest();
            }

            _context.Entry(accessMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccessMenuExists(id))
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

        // POST: api/AccessMenus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AccessMenu>> PostAccessMenu(AccessMenu accessMenu)
        {
            _context.accessMenus.Add(accessMenu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccessMenu", new { id = accessMenu.Id }, accessMenu);
        }

        // DELETE: api/AccessMenus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccessMenu>> DeleteAccessMenu(long id)
        {
            var accessMenu = await _context.accessMenus.FindAsync(id);
            if (accessMenu == null)
            {
                return NotFound();
            }

            _context.accessMenus.Remove(accessMenu);
            await _context.SaveChangesAsync();

            return accessMenu;
        }

        private bool AccessMenuExists(long id)
        {
            return _context.accessMenus.Any(e => e.Id == id);
        }
    }
}
