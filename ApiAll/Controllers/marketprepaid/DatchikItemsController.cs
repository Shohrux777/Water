using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class DatchikItemsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public DatchikItemsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/DatchikItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DatchikItem>>> GetdatchikItems()
        {
            List<DatchikItem> datchikItems = await _context.datchikItems.OrderByDescending(p => p.Id).ToListAsync();
            
            foreach (DatchikItem item  in datchikItems) {
                Rooms rooms = await _context.rooms.FindAsync(item.RoomsId);
                Datchik datchik = await _context.datchiks.FindAsync(item.DatchikId);
                Color color = await _context.colors.FindAsync(item.ColorId);
                item.color = color;
                item.rooms = rooms;
                item.datchik = datchik;
            }
            return datchikItems;
        }

        // GET: api/DatchikItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DatchikItem>> GetDatchikItem(long id)
        {
            var datchikItem = await _context.datchikItems.FindAsync(id);

            if (datchikItem == null)
            {
                return NotFound();
            }

            return datchikItem;
        }

        // PUT: api/DatchikItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDatchikItem(long id, DatchikItem datchikItem)
        {
            if (id != datchikItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(datchikItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatchikItemExists(id))
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

        // POST: api/DatchikItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DatchikItem>> PostDatchikItem(DatchikItem datchikItem)
        {
            _context.datchikItems.Add(datchikItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDatchikItem", new { id = datchikItem.Id }, datchikItem);
        }

        [HttpGet("addDatchikItem")]
        public async Task<ActionResult<DatchikItem>> addDatchikItem([FromQuery] long Id, [FromQuery] long roomId, [FromQuery] long colorId, [FromQuery] long datchikId )
        {
            DatchikItem datchikItem = new DatchikItem();
            datchikItem.ActiveStatus = true;
            datchikItem.Id = Id;
            datchikItem.RoomsId = roomId;
            datchikItem.ColorId = colorId;
            datchikItem.DatchikId = datchikId;
            _context.datchikItems.Update(datchikItem);
            await _context.SaveChangesAsync();

            return datchikItem;
        }

        // DELETE: api/DatchikItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DatchikItem>> DeleteDatchikItem(long id)
        {
            var datchikItem = await _context.datchikItems.FindAsync(id);
            if (datchikItem == null)
            {
                return NotFound();
            }

            _context.datchikItems.Remove(datchikItem);
            await _context.SaveChangesAsync();

            return datchikItem;
        }

        private bool DatchikItemExists(long id)
        {
            return _context.datchikItems.Any(e => e.Id == id);
        }
    }
}
