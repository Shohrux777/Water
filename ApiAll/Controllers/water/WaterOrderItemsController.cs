using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.water;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.water
{
    [ApiExplorerSettings(GroupName = "v9")]
    [Route("api/[controller]")]
    [ApiController]
    public class WaterOrderItemsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public WaterOrderItemsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/WaterOrderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterOrderItem>>> GetWaterOrderItem()
        {
            return await _context.WaterOrderItem.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterOrderItem> categoryList = await _context.WaterOrderItem
                .Include(p =>p.product)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterOrderItem>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterOrderItem.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationOrderItemListByClientId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationOrderItemListByClientId([FromQuery] int page, [FromQuery] int size,[FromQuery] long client_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterOrderItem> categoryList = await _context.WaterOrderItem
                .Include(p => p.product)
                .Include(p => p.order)
                .Where(p => p.active_status == true && p.order.WaterClientid == client_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterOrderItem>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterOrderItem.Include(p => p.order).Where(p => p.active_status == true && p.order.WaterClientid == client_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/WaterOrderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterOrderItem>> GetWaterOrderItem(long id)
        {
            var waterOrderItem = await _context.WaterOrderItem.FindAsync(id);

            if (waterOrderItem == null)
            {
                return NotFound();
            }

            return waterOrderItem;
        }

        [HttpGet("closeAcceptOrderItem")]
        public async Task<ActionResult<WaterOrderItem>> closeAcceptOrderItem([FromQuery]long order_item_id)
        {
            var waterOrderItem = await _context.WaterOrderItem.FindAsync(order_item_id);

            if (waterOrderItem == null)
            {
                return NotFound();
            }
            waterOrderItem.order_item_accepted_status = true;
            _context.WaterOrderItem.Update(waterOrderItem);

            await _context.SaveChangesAsync();

            return waterOrderItem;
        }

        [HttpGet("closeAcceptOrderItemAvtoCalculateAll")]
        public async Task<ActionResult<WaterOrderItem>> closeAcceptOrderItemAvtoCalculateAll([FromQuery] long order_item_id,double olingan_baklashka_soni)
        {
            var waterOrderItem = await _context.WaterOrderItem.FindAsync(order_item_id);
           
            if (waterOrderItem == null)
            {
                return NotFound();
            }

            var waterProduct = await _context.WaterProduct.FindAsync(waterOrderItem.WaterProductid);
            var waterOrder = await _context.WaterOrder.FindAsync(waterOrderItem.id);
            if (waterProduct.main_product == true) {

                await addBotlfInfoToClientForAccept(olingan_baklashka_soni,
                    waterOrderItem.qty,
                    waterOrderItem.WaterProductid,
                    waterOrder.WaterClientid,
                    waterOrder.WaterClientAddressid);

            }
            waterOrderItem.order_item_accepted_status = true;
            _context.WaterOrderItem.Update(waterOrderItem);

            await _context.SaveChangesAsync();

            return waterOrderItem;
        }

        [HttpGet("addBotlfInfoToClientForAccept")]
        public async Task<ActionResult<WaterClientBottleInfo>> addBotlfInfoToClientForAccept(
        [FromQuery] double olingan_bakalshka_soni,
        [FromQuery] double berilgan_bakalshka_soni,
        [FromQuery] long product_id,
        [FromQuery] long client_id,
        [FromQuery] long address_id)
        {
            var waterClientBottleInfo = await _context.WaterClientBottleInfo.Where(p => p.WaterClientid == client_id
            && p.WaterClientAddressid == address_id && (p.WaterProductid == product_id)).ToListAsync();


            WaterMessageLog messageLog = new WaterMessageLog();
            messageLog.active_status = true;
            WaterClient client = await _context.WaterClient.FindAsync(client_id);
            WaterProduct product = await _context.WaterProduct.FindAsync(product_id);
            WaterClientAddress clientAddress = await _context.WaterClientAddress.FindAsync(address_id);

            String message_str =
                  " Klient: " + client.fio + " "
                + " Adress: " + clientAddress.address + "  "
                + " Tovar: " + product.name + " "
                + " Olingan soni: " + olingan_bakalshka_soni.ToString() + " "
                + " Berilgan soni: " + berilgan_bakalshka_soni.ToString();
            messageLog.message_str = message_str;

            _context.WaterMessageLog.Update(messageLog);
            await _context.SaveChangesAsync();



            if (waterClientBottleInfo == null || waterClientBottleInfo.Count() == 0)
            {
                //topilmadi yangi yaratamiz
                WaterClientBottleInfo info = new WaterClientBottleInfo();
                info.bottle_count = olingan_bakalshka_soni + berilgan_bakalshka_soni;
                info.bottle_count_real = berilgan_bakalshka_soni;
                info.WaterProductid = product_id;
                info.WaterClientAddressid = address_id;
                info.WaterClientid = client_id;
                info.active_status = true;
                _context.WaterClientBottleInfo.Update(info);
                await _context.SaveChangesAsync();
                return info;
            }
            else
            {
                waterClientBottleInfo.First().bottle_count = waterClientBottleInfo.First().bottle_count + (olingan_bakalshka_soni + berilgan_bakalshka_soni);
                waterClientBottleInfo.First().bottle_count_real = waterClientBottleInfo.First().bottle_count_real + berilgan_bakalshka_soni;
                _context.WaterClientBottleInfo.Update(waterClientBottleInfo.First());
                await _context.SaveChangesAsync();
            }

            return waterClientBottleInfo.First();
        }

        // PUT: api/WaterOrderItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterOrderItem(long id, WaterOrderItem waterOrderItem)
        {
            if (id != waterOrderItem.id)
            {
                return BadRequest();
            }

            _context.Entry(waterOrderItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterOrderItemExists(id))
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

        // POST: api/WaterOrderItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WaterOrderItem>> PostWaterOrderItem(WaterOrderItem waterOrderItem)
        {
            _context.WaterOrderItem.Update(waterOrderItem);
            await _context.SaveChangesAsync();

            return waterOrderItem;
        }

        // DELETE: api/WaterOrderItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WaterOrderItem>> DeleteWaterOrderItem(long id)
        {
            var waterOrderItem = await _context.WaterOrderItem.FindAsync(id);
            if (waterOrderItem == null)
            {
                return NotFound();
            }

            _context.WaterOrderItem.Remove(waterOrderItem);
            await _context.SaveChangesAsync();

            return waterOrderItem;
        }

        private bool WaterOrderItemExists(long id)
        {
            return _context.WaterOrderItem.Any(e => e.id == id);
        }
    }
}
