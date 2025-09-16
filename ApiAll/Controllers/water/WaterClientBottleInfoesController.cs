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
    public class WaterClientBottleInfoesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public WaterClientBottleInfoesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/WaterClientBottleInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterClientBottleInfo>>> GetWaterClientBottleInfo()
        {
            return await _context.WaterClientBottleInfo.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterClientBottleInfo> categoryList = await _context.WaterClientBottleInfo
                .Include(p => p.product)
                .Include(p => p.client)
                .Include(p => p.address)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterClientBottleInfo>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterClientBottleInfo.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationClientId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationClientId([FromQuery] int page, [FromQuery] int size,[FromQuery] long client_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterClientBottleInfo> categoryList = await _context.WaterClientBottleInfo
                .Include(p => p.product)
                .Include(p => p.client)
                .Include(p => p.address)
                .Where(p => p.active_status == true && p.WaterClientid == client_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterClientBottleInfo>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterClientBottleInfo.Where(p => p.active_status == true && p.WaterClientid == client_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationClientIdAndAddressId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationClientIdAndAddressId([FromQuery] int page, [FromQuery] int size, [FromQuery] long client_id,[FromQuery] long address_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterClientBottleInfo> categoryList = await _context.WaterClientBottleInfo
                .Include(p => p.product)
                .Include(p => p.client)
                .Include(p => p.address)
                .Where(p => p.active_status == true
                && p.WaterClientid == client_id
                && p.WaterClientAddressid == address_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterClientBottleInfo>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterClientBottleInfo.Where(p => p.active_status == true
            && p.WaterClientid == client_id
            && p.WaterClientAddressid == address_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationClientIdAndAddressIdAndProductId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationClientIdAndAddressIdAndProductId([FromQuery] int page, [FromQuery] int size, [FromQuery] long client_id, [FromQuery] long address_id,[FromQuery] long product_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterClientBottleInfo> categoryList = await _context.WaterClientBottleInfo
                .Include(p => p.product)
                .Include(p => p.client)
                .Include(p => p.address)
                .Where(p => p.active_status == true
                && p.WaterClientid == client_id
                && p.WaterClientAddressid == address_id
                && p.WaterProductid == product_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterClientBottleInfo>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterClientBottleInfo.Where(p => p.active_status == true
            && p.WaterClientid == client_id
            && p.WaterClientAddressid == address_id
            && p.WaterProductid == product_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationAddressId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationAddressId([FromQuery] int page, [FromQuery] int size, [FromQuery] long addres_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterClientBottleInfo> categoryList = await _context.WaterClientBottleInfo
                .Include(p => p.product)
                .Include(p => p.client)
                .Include(p => p.address)
                .Where(p => p.active_status == true && p.WaterClientAddressid == addres_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterClientBottleInfo>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterClientBottleInfo.Where(p => p.active_status == true && p.WaterClientAddressid == addres_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationSerachByClientName")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationSerachByClientName([FromQuery] int page, [FromQuery] int size,[FromQuery] String client_name)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterClientBottleInfo> categoryList = await _context.WaterClientBottleInfo
                .Include(p => p.product)
                .Include(p => p.client)
                .Include(p => p.address)
                .Where(p => p.active_status == true && p.client.fio.ToLower().Contains(client_name.ToLower()))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterClientBottleInfo>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterClientBottleInfo.Where(p => p.active_status == true && p.client.fio.ToLower().Contains(client_name.ToLower())).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/WaterClientBottleInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterClientBottleInfo>> GetWaterClientBottleInfo(long id)
        {
            var waterClientBottleInfo = await _context.WaterClientBottleInfo
                .Include(p => p.product)
                .Include(p => p.client)
                .Include(p => p.address)
                .Where(p => p.id==id).ToListAsync();

            if (waterClientBottleInfo == null || waterClientBottleInfo.Count == 0)
            {
                return NotFound();
            }

            return waterClientBottleInfo.First();
        }

        [HttpGet("checkBottleExitsOrNotByAddressId")]
        public async Task<ActionResult<WaterClientBottleInfo>> checkBottleExitsOrNotByAddressId([FromQuery]long adress_id)
        {
            var waterClientBottleInfo = await _context.WaterClientBottleInfo
                .Include(p => p.product)
                .Include(p => p.client)
                .Include(p => p.address)
                .Where(p => p.id == adress_id).ToListAsync();

            if (waterClientBottleInfo == null || waterClientBottleInfo.Count == 0)
            {
                return NotFound();
            }

            return waterClientBottleInfo.First();
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
            else {
                waterClientBottleInfo.First().bottle_count = waterClientBottleInfo.First().bottle_count +(olingan_bakalshka_soni + berilgan_bakalshka_soni);
                waterClientBottleInfo.First().bottle_count_real = waterClientBottleInfo.First().bottle_count_real + berilgan_bakalshka_soni;
                _context.WaterClientBottleInfo.Update(waterClientBottleInfo.First());
                await _context.SaveChangesAsync();
            }

            return waterClientBottleInfo.First();
        }

        // PUT: api/WaterClientBottleInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterClientBottleInfo(long id, WaterClientBottleInfo waterClientBottleInfo)
        {
            if (id != waterClientBottleInfo.id)
            {
                return BadRequest();
            }

            _context.Entry(waterClientBottleInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterClientBottleInfoExists(id))
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

        // POST: api/WaterClientBottleInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WaterClientBottleInfo>> PostWaterClientBottleInfo(WaterClientBottleInfo waterClientBottleInfo)
        {
            _context.WaterClientBottleInfo.Update(waterClientBottleInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaterClientBottleInfo", new { id = waterClientBottleInfo.id }, waterClientBottleInfo);
        }

        // DELETE: api/WaterClientBottleInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WaterClientBottleInfo>> DeleteWaterClientBottleInfo(long id)
        {
            var waterClientBottleInfo = await _context.WaterClientBottleInfo.FindAsync(id);
            if (waterClientBottleInfo == null)
            {
                return NotFound();
            }

            _context.WaterClientBottleInfo.Remove(waterClientBottleInfo);
            await _context.SaveChangesAsync();

            return waterClientBottleInfo;
        }

        [HttpDelete("deleteAdressWithoutCheking")]
        public async Task<ActionResult<WaterClientAddress>> deleteAdressWithoutCheking([FromQuery]long adress_id)
        {
            var waterClientAddress = await _context.WaterClientAddress.FindAsync(adress_id);
            if (waterClientAddress == null)
            {
                return NotFound();
            }

            _context.WaterClientAddress.Remove(waterClientAddress);
            await _context.SaveChangesAsync();

            return waterClientAddress;
        }


        

        private bool WaterClientBottleInfoExists(long id)
        {
            return _context.WaterClientBottleInfo.Any(e => e.id == id);
        }

        private bool WaterClienBottleInfotExitsByAdressid(long adress_id)
        {
            return _context.WaterClientBottleInfo.Any(e => e.WaterClientAddressid == adress_id);
        }
    }
}
