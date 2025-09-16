using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tekistil
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexOrdersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexOrdersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexOrder>>> GetTexOrder()
        {
            return  await _context.TexOrder.Where(p => p.active_status == true).OrderByDescending(p => p.id).Include(p => p.client).Include(p => p.company).Include(p => p.department).Include(p => p.valyuta).ToListAsync();
        }

        [HttpGet("getSubTexOrderItemList")]
        public async Task<ActionResult<IEnumerable<TexOrderItem>>> getSubTexOrderItemList([FromQuery] long order_item_id)
        {
            return await _context.TexOrderItem.Where(p => p.main_order_item_id == order_item_id)
                .Include(p => p.product).ThenInclude(p => p.productionType)
                .Include(p => p.color)
                .Include(p => p.colorvariant)
                .Include(p => p.extrawork)
                .Include(p => p.mainProccess)
                .Include(p => p.serviceType)
                .Include(p => p.size)
                .Include(p => p.suroviyVid)
                .Include(p => p.order).ThenInclude(p => p.client)
                .Include(p => p.order.company)
                .Include(p => p.order.department)
                .Include(p => p.order.valyuta)
                .OrderBy(p => p.id)
                .ToListAsync();
        }

        // GET: api/TexOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexOrder>> GetTexOrder(long id)
        {
            var texOrder = await _context.TexOrder.FindAsync(id);

            if (texOrder == null)
            {
                return NotFound();
            }

            return texOrder;
        }

        [HttpGet("getOrderFullInfo")]
        public async Task<ActionResult<TexOrder>> getOrderFullInfo([FromQuery]long orderId)
        {
            var texOrder = await _context.TexOrder
                .Where(p => p.id == orderId)
                .Include(p => p.valyuta)
                .Include(p => p.client)
                .Include(p => p.company)
                .Include(p => p.department)
                .ToListAsync();

            if (texOrder == null || texOrder.Count == 0)
            {
                return NotFound();
            }
            List<TexOrderItem> orderItemList = await _context.TexOrderItem
                .Where(p => p.order_id == orderId && p.main_order_item_id == null)
                .Include(p => p.product).ThenInclude(p => p.productionType)
                .Include(p => p.color)
                .Include(p => p.colorvariant)
                .Include(p => p.extrawork)
                .Include(p => p.mainProccess)
                .Include(p => p.serviceType)
                .Include(p => p.size)
                .Include(p => p.suroviyVid)
                .Include(p => p.order).ThenInclude(p => p.client)
                .Include(p => p.order.company)
                .Include(p => p.order.department)
                .Include(p => p.order.valyuta)
                .OrderBy( p => p.id)
                .ToListAsync();

            if (orderItemList != null && orderItemList.Count > 0) {
                foreach (TexOrderItem item in orderItemList) {
              List<TexOrderItem> custom_order_item = await _context.TexOrderItem.Where(p => p.main_order_item_id == item.id)
                .Include(p => p.product).ThenInclude(p => p.productionType)
                .Include(p => p.color)
                .Include(p => p.colorvariant)
                .Include(p => p.extrawork)
                .Include(p => p.mainProccess)
                .Include(p => p.serviceType)
                .Include(p => p.size)
                .Include(p => p.suroviyVid)
                .Include(p => p.order).ThenInclude(p => p.client)
                .Include(p => p.order.company)
                .Include(p => p.order.department)
                .Include(p => p.order.valyuta)
                .OrderBy(p => p.id)
                .ToListAsync();
                item.child_order_item_list = custom_order_item;
                }
            
            }

            texOrder.First().orderItemList = orderItemList;

            return texOrder.First();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexOrder> itemList = await _context.TexOrder.Where(p => p.active_status == true).OrderByDescending(p => p.id).Include(p => p.client).Include(p => p.company).Include(p => p.department).Include( p =>p.valyuta).Skip(page * size).Take(size).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexOrder>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexOrder.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/TexOrders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexOrder(long id, TexOrder texOrder)
        {
            if (id != texOrder.id)
            {
                return BadRequest();
            }

            _context.Entry(texOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexOrderExists(id))
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

        // POST: api/TexOrders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexOrder>> PostTexOrder(TexOrder texOrder)
        {
            try
            {
            _context.TexOrder.Update(texOrder);
            await _context.SaveChangesAsync();
                
            if (texOrder.orderItemList != null && texOrder.orderItemList.Count > 0) {
                    //uppend order item list
                    List<TexOrderItem> itemList = texOrder.orderItemList;
                    foreach (TexOrderItem item in itemList) {
                        item.order_id = texOrder.id;
                    }
                    _context.TexOrderItem.UpdateRange(itemList);
                    await _context.SaveChangesAsync();

                    foreach (TexOrderItem item in itemList)
                    {
                        List<TexOrderItem> childOrderItem = item.child_order_item_list;
                        if (childOrderItem != null && childOrderItem.Count > 0) {
                            foreach (TexOrderItem item_order in childOrderItem) {
                                item_order.order_id = texOrder.id;
                                item_order.main_order_item_id = item.id;
                            }
                            _context.TexOrderItem.UpdateRange(childOrderItem);
                            await _context.SaveChangesAsync();

                        }
                        
                    }

                }
            }
            catch (DbUpdateException e)
            {
                if (texOrder.id > 0) {
                    await DeleteTexOrder(texOrder.id);
                }

                return NotFound(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                if (texOrder.id > 0)
                {
                    await DeleteTexOrder(texOrder.id);
                }
                return NotFound(e?.InnerException?.Message);
            }

            return CreatedAtAction("GetTexOrder", new { id = texOrder.id }, texOrder);
        }

        // DELETE: api/TexOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexOrder>> DeleteTexOrder(long id)
        {
            var texOrder = await _context.TexOrder.FindAsync(id);
            try {
                
                if (texOrder == null)
                {
                    return NotFound();
                }
                List<TexOrderItem> texOrderItemList = await _context.TexOrderItem.Where(p => p.order_id == id).ToListAsync();
                if (texOrderItemList != null && texOrderItemList.Count > 0)
                {
                    _context.TexOrderItem.RemoveRange(texOrderItemList);
                    await _context.SaveChangesAsync();
                }
                _context.TexOrder.Remove(texOrder);
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

            return texOrder;
        }

        private bool TexOrderExists(long id)
        {
            return _context.TexOrder.Any(e => e.id == id);
        }
    }
}
