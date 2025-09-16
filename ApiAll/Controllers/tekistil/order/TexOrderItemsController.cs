using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;

namespace ApiAll.Controllers.tekistil
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexOrderItemsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexOrderItemsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexOrderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexOrderItem>>> GetTexOrderItem()
        {
            return await _context.TexOrderItem.ToListAsync();
        }

        // GET: api/TexOrderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexOrderItem>> GetTexOrderItem(long id)
        {
            var texOrderItem = await _context.TexOrderItem.FindAsync(id);

            if (texOrderItem == null)
            {
                return NotFound();
            }

            return texOrderItem;
        }

        [HttpGet("changeStartOrStopStatusOrderItem")]
        public async Task<ActionResult<TexOrderItem>> changeStartOrStopStatusOrderItem([FromQuery]long order_item_id,[FromQuery] bool start_or_stop_status)
        {
            var texOrderItem = await _context.TexOrderItem.FindAsync(order_item_id);
            if (texOrderItem == null)
            {
                return NotFound("Order item not found");
            }
            if (texOrderItem.started_status == start_or_stop_status)
            {
                return NotFound("Please, update your page");
            }
            texOrderItem.started_status = start_or_stop_status;

            try
            {
                _context.TexOrderItem.Update(texOrderItem);
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

            return texOrderItem;
        }

        [HttpGet("getOrderItemFullInfoById")]
        public async Task<ActionResult<TexOrderItem>> getOrderItemFullInfoById([FromQuery]long order_item_id)
        {
            var texOrderItemList = await _context.TexOrderItem.Where(p =>p.id == order_item_id)
                .Include( p => p.product).ThenInclude(p => p.productionType)
                .Include( p => p.color)
                .Include( p => p.colorvariant)
                .Include( p => p.extrawork)
                .Include( p => p.mainProccess)
                .Include( p => p.serviceType)
                .Include( p => p.size)
                .Include( p => p.suroviyVid)
                .Include( p => p.order).ThenInclude( p => p.client)
                .Include( p => p.order.company)
                .Include( p => p.order.department)
                .Include( p => p.order.valyuta)
                .Include(p =>p.model)
                .ToListAsync();

            if (texOrderItemList == null || texOrderItemList.Count == 0)
            {
                return NotFound();
            }

            return texOrderItemList.First();
        }

        // PUT: api/TexOrderItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexOrderItem(long id, TexOrderItem texOrderItem)
        {
            if (id != texOrderItem.id)
            {
                return BadRequest();
            }

            _context.Entry(texOrderItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexOrderItemExists(id))
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

        // POST: api/TexOrderItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexOrderItem>> PostTexOrderItem(TexOrderItem texOrderItem)
        {



            try
            {
            _context.TexOrderItem.Update(texOrderItem);
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

            return CreatedAtAction("GetTexOrderItem", new { id = texOrderItem.id }, texOrderItem);
        }

        // DELETE: api/TexOrderItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexOrderItem>> DeleteTexOrderItem(long id)
        {
            var texOrderItem = await _context.TexOrderItem.FindAsync(id);
            if (texOrderItem == null)
            {
                return NotFound();
            }

            _context.TexOrderItem.Remove(texOrderItem);
            await _context.SaveChangesAsync();

            return texOrderItem;
        }

        private bool TexOrderItemExists(long id)
        {
            return _context.TexOrderItem.Any(e => e.id == id);
        }
    }
}
