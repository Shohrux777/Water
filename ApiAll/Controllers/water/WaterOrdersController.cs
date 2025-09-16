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
    public class WaterOrdersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public WaterOrdersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/WaterOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterOrder>>> GetWaterOrder()
        {
            return await _context.WaterOrder.ToListAsync();
        }

        public class CloseOrderDto
        {
            public long OrderId { get; set; }
            public long ClientId { get; set; }
            public long AddressId { get; set; }
            public long ProductId { get; set; }
            public double OlinganBakalshkaSoni { get; set; }
            public double BerilganBakalshkaSoni { get; set; }
            public long CheckId { get; set; }
            public WaterCheck Check { get; set; } // agar yangi check yuborish kerak bo‘lsa
        }

        [HttpPost("close-order")]
        public async Task<IActionResult> CloseOrder([FromBody] CloseOrderDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1. Zakazni qabul qilish (closeAcceptOrder)
                var waterOrder = await _context.WaterOrder.FindAsync(dto.OrderId);
                if (waterOrder == null) return NotFound("Order topilmadi");

                if (waterOrder.accepted_status == true)
                    return BadRequest("Order already accepted");

                waterOrder.accepted_status = true;
                _context.WaterOrder.Update(waterOrder);
                await _context.SaveChangesAsync();

                // 2. Bottle info (addBotlfInfoToClientForAccept)
                var bottleInfo = await _context.WaterClientBottleInfo
                    .FirstOrDefaultAsync(p => p.WaterClientid == dto.ClientId &&
                                            p.WaterClientAddressid == dto.AddressId &&
                                            p.WaterProductid == dto.ProductId);

                if (bottleInfo == null)
                {
                    bottleInfo = new WaterClientBottleInfo
                    {
                        bottle_count = dto.OlinganBakalshkaSoni + dto.BerilganBakalshkaSoni,
                        bottle_count_real = dto.BerilganBakalshkaSoni,
                        WaterProductid = dto.ProductId,
                        WaterClientAddressid = dto.AddressId,
                        WaterClientid = dto.ClientId,
                        active_status = true
                    };
                    _context.WaterClientBottleInfo.Add(bottleInfo);
                }
                else
                {
                    bottleInfo.bottle_count += dto.OlinganBakalshkaSoni + dto.BerilganBakalshkaSoni;
                    bottleInfo.bottle_count_real += dto.BerilganBakalshkaSoni;
                    _context.WaterClientBottleInfo.Update(bottleInfo);
                }
                await _context.SaveChangesAsync();

                // 3. Check (PostWaterCheck)
                if (dto.Check != null)
                {
                    _context.WaterCheck.Update(dto.Check);
                    await _context.SaveChangesAsync();
                }

                // 4. updateOrderFullReturningInfo
                waterOrder.reserverd_numeric_id_1 = -1 * dto.OlinganBakalshkaSoni;
                waterOrder.reserverd_numeric_id_2 = dto.BerilganBakalshkaSoni;
                waterOrder.reserverd_number_id_1 = bottleInfo.id; // yoki dto.CheckId
                waterOrder.reserverd_number_id_2 = dto.Check.id;
                _context.WaterOrder.Update(waterOrder);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return Ok(new { success = true, order = waterOrder, bottleInfo });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet("getPaginationOrderByClientId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationOrderByClientId([FromQuery] int page, [FromQuery] int size, [FromQuery] long client_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterOrder> categoryList = await _context.WaterOrder
               .Include(p => p.client)
               .Include(p => p.address)
               .Include(p => p.user)
                .Where(p => p.active_status == true && p.WaterClientid == client_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterOrder>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterOrder.Where(p => p.active_status == true && p.WaterClientid == client_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getOrderListByStrListWithAuthIdDelivered")]
        public async Task<ActionResult<IEnumerable<WaterOrder>>> getOrderListByStrListWithAuthIdDelivered([FromQuery] long id_auth)
        {
            var waterAuth = await _context.WaterAuth.FindAsync(id_auth);

            if (waterAuth == null)
            {
                return NotFound();
            }
            if (waterAuth.reserverd_note == null || waterAuth.reserverd_note.Trim().Length == 0)
            {
                return NotFound();
            }

            String[] id_list = waterAuth.reserverd_note.Split(',');
            List<WaterOrder> order_list = new List<WaterOrder>();
            foreach (String it in id_list)
            {
                try
                {
                    long id = long.Parse(it);
                    var waterOrder = await _context.WaterOrder
               .Include(p => p.client)
               .Include(p => p.address)
               .Include(p => p.user)
               .Where(p => p.id == id && p.accepted_status == true).ToListAsync();

                    if (waterOrder == null || waterOrder.Count == 0)
                    {
                        continue;
                    }

                    waterOrder.First().items = await _context.WaterOrderItem
                     .Include(p => p.product)
                     .Where(p => p.WaterOrderid == waterOrder.First().id)
                     .ToListAsync();
                    order_list.Add(waterOrder.First());
                }
                catch (FormatException) { }


            }

            ////add order list to phone list
            foreach (WaterOrder order_it in order_list)
            {
                order_it.phone_list_obj = await _context.WaterClientPhoneNumber.Where(p => p.WaterClientid == order_it.WaterClientid).ToListAsync();

            }


            return order_list;
        }

        [HttpGet("getOrderListByStrListWithAuthId")]
        public async Task<ActionResult<IEnumerable<WaterOrder>>> getOrderListByStrListWithAuthId([FromQuery] long id_auth)
        {
            var waterAuth = await _context.WaterAuth.FindAsync(id_auth);

            if (waterAuth == null)
            {
                return NotFound();
            }
            if (waterAuth.reserverd_note == null || waterAuth.reserverd_note.Trim().Length == 0) {
                return NotFound();
            }

            String[] id_list = waterAuth.reserverd_note.Split(',');
            List<WaterOrder> order_list = new List<WaterOrder>();
            foreach (String it in id_list)
            {
                try
                {
                    long id = long.Parse(it);
                    var waterOrder = await _context.WaterOrder
               .Include(p => p.client)
               .Include(p => p.address)
               .Include(p => p.user)
               .Where(p => p.id == id && p.accepted_status == false).ToListAsync();

                    if (waterOrder == null || waterOrder.Count == 0)
                    {
                        continue;
                    }

                    waterOrder.First().items = await _context.WaterOrderItem
                     .Include(p => p.product)
                     .Where(p => p.WaterOrderid == waterOrder.First().id)
                     .ToListAsync();
                    order_list.Add(waterOrder.First());
                }
                catch (FormatException) { }


            }

            ////add order list to phone list
            foreach (WaterOrder order_it in order_list) {
                order_it.phone_list_obj = await _context.WaterClientPhoneNumber.Where(p => p.WaterClientid == order_it.WaterClientid).ToListAsync();

            }


            return order_list;
        }

        [HttpGet("getOrderListByStrList")]
        public async Task<ActionResult<IEnumerable<WaterOrder>>> getOrderListByStrList([FromQuery] String id_str)
        {
            String[] id_list = id_str.Split(',');
            List<WaterOrder> order_list = new List<WaterOrder>();
            foreach (String it in id_list) {
                try
                {
                    long id = long.Parse(it);
                    var waterOrder = await _context.WaterOrder
               .Include(p => p.client)
               .Include(p => p.address)
               .Include(p => p.user)
               .Where(p => p.id == id).ToListAsync();

                    if (waterOrder == null || waterOrder.Count == 0)
                    {
                        continue;
                    }

                    waterOrder.First().items = await _context.WaterOrderItem
                     .Include(p => p.product)
                     .Where(p => p.WaterOrderid == waterOrder.First().id)
                     .ToListAsync();
                    order_list.Add(waterOrder.First());
                }
                catch (FormatException) { }
                

            }


            return order_list;
        }


        [HttpGet("getWaterOrderedProductList")]
        public async Task<ActionResult<IEnumerable<WaterOrderedProduct>>> getWaterOrderedProductList([FromQuery] DateTime begin_date,[FromQuery] DateTime end_date)
        {

            String beginDateStr = begin_date.ToString("yyyy-MM-dd hh:mm:ss");
            String endDateStr = end_date.ToString("yyyy-MM-dd hh:mm:ss");
            return await _context.WaterOrderedProduct.FromSqlRaw("" +
                "" +
                " SELECT "+
                " sum(woi.qty) as product_qty, "+
                " wp.name as product_name  "+
                " FROM water_order_item  woi  "+
                " LEFT JOIN water_product wp ON wp.id = woi.\"WaterProductid\" "+
                " WHERE woi.order_item_accepted_status = false  "+
                " AND woi.updated_date_time BETWEEN '"+ beginDateStr + "' AND '"+ endDateStr + "' "+
                " GROUP BY wp.name ").ToListAsync();
        }


        // GET: api/WaterOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterOrder>> GetWaterOrder(long id)
        {
            var waterOrder = await _context.WaterOrder.FindAsync(id);

            if (waterOrder == null)
            {
                return NotFound();
            }

            return waterOrder;
        }

        [HttpGet("getOrderFullInfoByIdForUpdate")]
        public async Task<ActionResult<WaterOrder>> getOrderFullInfoByIdForUpdate([FromQuery]long id)
        {
            var waterOrder = await _context.WaterOrder
                .Include(p => p.client)
                .Include(p => p.address)
                .Include(p => p.user)
                .Where(p => p.id == id).ToListAsync();

            if (waterOrder == null || waterOrder.Count == 0)
            {
                return NotFound();
            }

            waterOrder.First().items = await _context.WaterOrderItem
             .Include(p => p.product)
             .Where(p => p.WaterOrderid == waterOrder.First().id)
             .ToListAsync();

            return waterOrder.First(); ;
        }

        [HttpGet("getOrderFullInfoByid")]
        public async Task<ActionResult<WaterOrder>> getOrderFullInfoByid([FromQuery]long order_id)
        {
            var waterOrder = await _context.WaterOrder
                .Include(p => p.user)
                .Include(p => p.client)
                .Include(p => p.address)
                .Where(p => p.id == order_id).ToListAsync();

            if (waterOrder == null || waterOrder.Count == 0)
            {
                return NotFound();
            }

            waterOrder.First().items = await _context.WaterOrderItem
                .Include(p =>p.product)
                .Where(p =>p.WaterOrderid == waterOrder.First().id)
                .ToListAsync();


            return waterOrder.First();
        }

        [HttpGet("getLastOrderTwoOrdersFullInfoByid")]
        public async Task<ActionResult<IEnumerable<WaterOrder>>> getLastOrderFullInfoByid([FromQuery] long client_id)
        {
            var waterOrder = await _context.WaterOrder
                .Include(p => p.user)
                .Include(p => p.client)
                .Include(p => p.address)
                .Where(p => p.WaterClientid == client_id)
                .OrderByDescending( p => p.id).Take(2).ToListAsync();

            if (waterOrder == null || waterOrder.Count == 0)
            {
                return NotFound();
            }

            waterOrder.First().items = await _context.WaterOrderItem
                .Include(p => p.product)
                .Where(p => p.WaterOrderid == waterOrder.First().id)
                .ToListAsync();


            return waterOrder;
        }

        [HttpGet("closeAcceptOrder")]
        public async Task<ActionResult<WaterOrder>> closeAcceptOrder([FromQuery]long id)
        {
            var waterOrder = await _context.WaterOrder.FindAsync(id);

            if (waterOrder == null)
            {
                return NotFound();
            }
            if (waterOrder.accepted_status == true)
            {
                return NotFound("Already Accepted this order");
            }


            waterOrder.accepted_status = true;
            _context.WaterOrder.Update(waterOrder);
            await _context.SaveChangesAsync();

            return waterOrder;
        }

        [HttpGet("addAcceptOrderToUsersWithAuthid")]
        public async Task<ActionResult<WaterOrder>> addAcceptOrderToUsersWithAuthid([FromQuery] long id, [FromQuery] long user_auth_id)
        {
            var waterOrder = await _context.WaterOrder.FindAsync(id);

            if (waterOrder == null)
            {
                return NotFound();
            }

            if (waterOrder.accepted_status == true) {
                return NotFound("Already Accepted this order");
            }

            waterOrder.accepted_status = true;
            waterOrder.deleivered_user_auth_id = user_auth_id;
            _context.WaterOrder.Update(waterOrder);
            await _context.SaveChangesAsync();

            return waterOrder;
        }

        [HttpGet("addOrderToUsersWithAuthid")]
        public async Task<ActionResult<WaterOrder>> addOrderToUsersWithAuthid([FromQuery] long id,[FromQuery] long user_auth_id)
        {
            var waterOrder = await _context.WaterOrder.FindAsync(id);

            if (waterOrder == null)
            {
                return NotFound();
            }
            waterOrder.deleivered_user_auth_id = user_auth_id;
            _context.WaterOrder.Update(waterOrder);
            await _context.SaveChangesAsync();

            return waterOrder;
        }

        [HttpGet("addDeOrderToUsersWithAuthidRemoveCar")]
        public async Task<ActionResult<WaterOrder>> addDeOrderToUsersWithAuthidRemoveCar([FromQuery] long id)
        {
            var waterOrder = await _context.WaterOrder.FindAsync(id);

            if (waterOrder == null)
            {
                return NotFound();
            }
            waterOrder.deleivered_user_auth_id = null;
            _context.WaterOrder.Update(waterOrder);
            await _context.SaveChangesAsync();

            return waterOrder;
        }


        [HttpGet("closeAcceptOrderWithAllitemsTogather")]
        public async Task<ActionResult<WaterOrder>> closeAcceptOrderWithAllitemsTogather([FromQuery] long id,[FromQuery] double olingan_bakalshka_soni)
        {
            var waterOrder = await _context.WaterOrder.FindAsync(id);

            if (waterOrder == null)
            {
                return NotFound();
            }
            if (waterOrder.accepted_status == true) {
                return NotFound("Already accepted order");
            }

            waterOrder.accepted_status = true;

            List<WaterOrderItem> items = await _context.WaterOrderItem
                .Include(p => p.product)
                .Where(p =>p.WaterOrderid == id && p.order_item_accepted_status == false)
                .ToListAsync();

            if (items != null && items.Count > 0) {

                foreach (WaterOrderItem it in items) {
                    it.order_item_accepted_status = true;

                    if (it.product.main_product == true) {

                        await addBotlfInfoToClientForAccept(olingan_bakalshka_soni, it.real_qty,
                            it.WaterProductid, waterOrder.WaterClientid, waterOrder.WaterClientAddressid);

                    }
                    
                }

                _context.WaterOrderItem.UpdateRange(items);
                await _context.SaveChangesAsync();
            }
            _context.WaterOrder.Update(waterOrder);
            await _context.SaveChangesAsync();

            return waterOrder;
        }

        [HttpGet("updateOrderFullReturningInfo")]
        public async Task<ActionResult<WaterOrder>> updateOrderFullReturningInfo(
            [FromQuery] long order_id,
            [FromQuery] double olingan_bakalshka_soni,
            [FromQuery] double berilgan_bakalshka_soni,
            [FromQuery] long water_client_bottle_info,
            [FromQuery] long check_id)
        {


            var waterOrder = await _context.WaterOrder.FindAsync(order_id);

            if (waterOrder == null)
            {
                return NotFound();
            }



            //update order
            waterOrder.reserverd_numeric_id_1 = olingan_bakalshka_soni;
            waterOrder.reserverd_numeric_id_2 = berilgan_bakalshka_soni;
            waterOrder.reserverd_number_id_1 = water_client_bottle_info;
            waterOrder.reserverd_number_id_2 = check_id;
            _context.WaterOrder.Update(waterOrder);
            await _context.SaveChangesAsync();

            return waterOrder;
        }


        [HttpGet("deAgainAcceptAlredyPlannedOrderFullReturningInfo")]
        public async Task<ActionResult<WaterOrder>> deAgainAcceptAlredyPlannedOrderFullReturningInfo(
    [FromQuery] long order_id)
        {
            var waterOrder = await _context.WaterOrder.FindAsync(order_id);

            if (waterOrder == null)
            {
                return NotFound();
            }

            if (waterOrder.accepted_status == false) {
                return NotFound("Bajarilmagandi qaytara olmesz");
            }

            //bakalashkani orqaga qaytardim

            try
            {
                var waterbottleInfo = await _context.WaterClientBottleInfo.FindAsync(waterOrder.reserverd_number_id_1);
                if (waterbottleInfo != null)
                {
                    double berilgan_baklashka_soni = waterOrder.reserverd_numeric_id_2 ?? 0.0;
                    double olingan_bakalshka_soni = waterOrder.reserverd_numeric_id_1 ?? 0.0;

                    waterbottleInfo.bottle_count = waterbottleInfo.bottle_count + olingan_bakalshka_soni-berilgan_baklashka_soni;
                    waterbottleInfo.bottle_count_real = waterbottleInfo.bottle_count_real  + olingan_bakalshka_soni - berilgan_baklashka_soni;
                    _context.WaterClientBottleInfo.Update(waterbottleInfo);
                    await _context.SaveChangesAsync();
                }

               
            }
            catch (Exception) { }

            //check udalit qilindi
            try
            {
                var waterCheck = await _context.WaterCheck.FindAsync(waterOrder.reserverd_number_id_2);
                if (waterCheck != null)
                {
                    _context.WaterCheck.Remove(waterCheck);
                    await _context.SaveChangesAsync();
                }


            }
            catch (Exception) { }




            //update order
            waterOrder.accepted_status = false;
            waterOrder.reserverd_numeric_id_1 = null;
            waterOrder.reserverd_numeric_id_2 = null;
            waterOrder.reserverd_number_id_1 = null;
            waterOrder.reserverd_number_id_2 = null;
            _context.WaterOrder.Update(waterOrder);
            await _context.SaveChangesAsync();

            return waterOrder;
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


        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterOrder> categoryList = await _context.WaterOrder
                .Include(p => p.user)
                .Include(p => p.client)
                .Include(p => p.address)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterOrder>();
            }
            foreach (WaterOrder itm_o in categoryList)
            {

                List<WaterOrderItem> item_odr = await _context.WaterOrderItem
                
                    .Where(p => p.WaterOrderid == itm_o.id)
                    .ToListAsync();

                if (item_odr == null)
                {
                    item_odr = new List<WaterOrderItem>();
                }

                String product_name_list = "";
                String product_name_list_with_qty = "";
                String product_name_list_with_qty_sign = "";

                foreach (WaterOrderItem itom in item_odr)
                {
                    itom.product = await _context.WaterProduct.FindAsync(itom.WaterProductid);
                    product_name_list = product_name_list + itom.product.name;
                    product_name_list_with_qty = product_name_list_with_qty + itom.product.name + " (" + itom.qty.ToString() + ")   ";
                    product_name_list_with_qty_sign = product_name_list_with_qty_sign + itom.product.name + "==" + itom.qty.ToString() + "  ";
                }

                itm_o.name_pp = product_name_list;
                itm_o.name_pp1 = product_name_list_with_qty;
                itm_o.name_pp2 = product_name_list_with_qty_sign;


            }

            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterOrder.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationAllByDateTme")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationAllByDateTme([FromQuery] int page,
            [FromQuery] int size, [FromQuery] DateTime begin_date, [FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterOrder> categoryList = await _context.WaterOrder
                .Include(p => p.user)
                .Include(p => p.client)
                .Include(p => p.address)
                .Where(p => p.active_status == true
                && (p.order_date >= begin_date && p.order_date <= end_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterOrder>();
            }

            foreach (WaterOrder itm_o in categoryList)
            {

                List<WaterOrderItem> item_odr = await _context.WaterOrderItem
                    
                    .Where(p => p.WaterOrderid == itm_o.id)
                    .ToListAsync();

                if (item_odr == null)
                {
                    item_odr = new List<WaterOrderItem>();
                }

                String product_name_list = "";
                String product_name_list_with_qty = "";
                String product_name_list_with_qty_sign = "";

                foreach (WaterOrderItem itom in item_odr)
                {
                    itom.product = await _context.WaterProduct.FindAsync(itom.WaterProductid);
                    product_name_list = product_name_list + itom.product.name;
                    product_name_list_with_qty = product_name_list_with_qty + itom.product.name + " (" + itom.qty.ToString() + ")   ";
                    product_name_list_with_qty_sign = product_name_list_with_qty_sign + itom.product.name + "==" + itom.qty.ToString() + "  ";
                }

                itm_o.name_pp = product_name_list;
                itm_o.name_pp1 = product_name_list_with_qty;
                itm_o.name_pp2 = product_name_list_with_qty_sign;


            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterOrder.Where(p => p.active_status == true
            && (p.order_date >= begin_date && p.order_date <= end_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationAllAcceptedByDateTme")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationAllAcceptedByDateTme([FromQuery] int page,
    [FromQuery] int size, [FromQuery] DateTime begin_date, [FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterOrder> categoryList = await _context.WaterOrder
                .Include(p => p.user)
                .Include(p => p.client)
                .Include(p => p.address)
                .Where(p => p.accepted_status == true
                && (p.order_date >= begin_date && p.order_date <= end_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterOrder>();
            }

            foreach (WaterOrder itm_o in categoryList)
            {

                List<WaterOrderItem> item_odr = await _context.WaterOrderItem
                    
                    .Where(p => p.WaterOrderid == itm_o.id)
                    .ToListAsync();

                if (item_odr == null)
                {
                    item_odr = new List<WaterOrderItem>();
                }

                String product_name_list = "";
                String product_name_list_with_qty = "";
                String product_name_list_with_qty_sign = "";

                foreach (WaterOrderItem itom in item_odr)
                {
                    itom.product = await _context.WaterProduct.FindAsync(itom.WaterProductid);
                    product_name_list = product_name_list + itom.product.name;
                    product_name_list_with_qty = product_name_list_with_qty + itom.product.name + " (" + itom.qty.ToString() + ")   ";
                    product_name_list_with_qty_sign = product_name_list_with_qty_sign + itom.product.name + "==" + itom.qty.ToString() + "  ";
                }

                itm_o.name_pp = product_name_list;
                itm_o.name_pp1 = product_name_list_with_qty;
                itm_o.name_pp2 = product_name_list_with_qty_sign;


            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterOrder.Where(p => p.accepted_status == true
            && (p.order_date >= begin_date && p.order_date <= end_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationAllNotAcceptedByDateTme")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationAllNotAcceptedByDateTme([FromQuery] int page,
[FromQuery] int size, [FromQuery] DateTime begin_date, [FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterOrder> categoryList = await _context.WaterOrder
                .Include(p => p.user)
                .Include(p => p.client)
                .Include(p => p.address)
                .Where(p => p.accepted_status == false
                && (p.order_date >= begin_date && p.order_date <= end_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterOrder>();
            }

            foreach (WaterOrder itm_o in categoryList)
            {

                List<WaterOrderItem> item_odr = await _context.WaterOrderItem
                   
                    .Where(p => p.WaterOrderid == itm_o.id)
                    .ToListAsync();

                if (item_odr == null)
                {
                    item_odr = new List<WaterOrderItem>();
                }

                String product_name_list = "";
                String product_name_list_with_qty = "";
                String product_name_list_with_qty_sign = "";

                foreach (WaterOrderItem itom in item_odr)
                {
                    itom.product = await _context.WaterProduct.FindAsync(itom.WaterProductid);
                    product_name_list = product_name_list + itom.product.name;
                    product_name_list_with_qty = product_name_list_with_qty + itom.product.name + " (" + itom.qty.ToString() + ")   ";
                    product_name_list_with_qty_sign = product_name_list_with_qty_sign + itom.product.name + "==" + itom.qty.ToString() + "  ";
                }

                itm_o.name_pp = product_name_list;
                itm_o.name_pp1 = product_name_list_with_qty;
                itm_o.name_pp2 = product_name_list_with_qty_sign;


            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterOrder.Where(p => p.accepted_status == false
            && (p.order_date >= begin_date && p.order_date <= end_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationOpenOrdersList")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationOpenOrdersList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterOrder> categoryList = await _context.WaterOrder
                .Include(p => p.user)
                .Include(p => p.client)
                .Include(p => p.address)
                .Where(p => p.active_status == true && p.accepted_status == false)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterOrder>();
            }

            foreach (WaterOrder it in categoryList) {

                WaterOrder order = await _context.WaterOrder.FindAsync(it.id);
                if (order != null)
                {

                    List<WaterOrderItem> orderItems = await _context.WaterOrderItem
                        .Include(p => p.product)
                        .Where(p => p.WaterOrderid == order.id).ToListAsync();

                    if (orderItems != null)
                    {

                        String product_name_list = "";
                        String product_name_list1 = "";
                        String product_name_list2 = "";
                        foreach (WaterOrderItem itmord in orderItems)
                        {
                            product_name_list = product_name_list + itmord.product.name + "  ";
                            product_name_list1 = product_name_list1 + itmord.product.name + "_" + itmord.qty.ToString() + "  ";
                            product_name_list2 = product_name_list2 + itmord.product.name + "==" + itmord.qty.ToString() + "  ";
                        }

                        it.name_pp = product_name_list;
                        it.name_pp1 = product_name_list1;
                        it.name_pp2 = product_name_list2;


                    }

                }




                List<WaterClientPhoneNumber> phone_numbers = await _context
                    .WaterClientPhoneNumber.Where(p=>p.WaterClientid == it.WaterClientid).ToListAsync();

                double val_date = it.order_date.Date.Subtract(DateTime.Now.Date).TotalDays;
                it.days_count = val_date;
                if (val_date < 0) {
                    it.color_value = "black";
                }

                if (val_date == 0.0)
                {
                    it.color_value = "red";
                }

                if (val_date > 0.0)
                {
                    it.color_value = "green";
                }

                String phones_list_str_arr = "";

             if (phone_numbers != null && phone_numbers.Count > 0){

                    foreach (WaterClientPhoneNumber itm in phone_numbers){

                        phones_list_str_arr = phones_list_str_arr +" "+ itm.phone_number;

                    }

                }

                it.phone_number_list_arr = phones_list_str_arr;

            }

            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterOrder.Where(p => p.active_status == true && p.accepted_status == false).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationBeatweanDateWithoutTimeOpenOrdersListByAuthIdAsc")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationBeatweanDateWithoutTimeOpenOrdersListByAuthIdAsc([FromQuery] int page,
[FromQuery] int size,
[FromQuery] DateTime begin_date, [FromQuery] DateTime end_date, [FromQuery] long user_auth_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterOrder> categoryList = await _context.WaterOrder
                .Include(p => p.user)
                .Include(p => p.client)
                .Include(p => p.address)
                .Where(p => p.active_status == true
                && p.accepted_status == false
                && (p.order_date >= begin_date && p.order_date <= end_date)
                && p.deleivered_user_auth_id == user_auth_id)
                .Skip(page * size).Take(size).OrderBy(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterOrder>();
            }

            foreach (WaterOrder itm_o in categoryList)
            {

                List<WaterOrderItem> item_odr = await _context.WaterOrderItem
                    .Where(p => p.WaterOrderid == itm_o.id)
                    .ToListAsync();

                if (item_odr == null)
                {
                    item_odr = new List<WaterOrderItem>();
                }

                String product_name_list = "";
                String product_name_list_with_qty = "";
                String product_name_list_with_qty_sign = "";

                foreach (WaterOrderItem itom in item_odr)
                {
                    itom.product = await _context.WaterProduct.FindAsync(itom.WaterProductid);
                    product_name_list = product_name_list + itom.product.name;
                    product_name_list_with_qty = product_name_list_with_qty + itom.product.name + " (" + itom.qty.ToString() + ")   ";
                    product_name_list_with_qty_sign = product_name_list_with_qty_sign + itom.product.name + "==" + itom.qty.ToString() + "  ";
                }

                itm_o.name_pp = product_name_list;
                itm_o.name_pp1 = product_name_list_with_qty;
                itm_o.name_pp2 = product_name_list_with_qty_sign;


            }

            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterOrder.Where(p => p.active_status == true
            && p.accepted_status == false
            && (p.order_date >= begin_date && p.order_date <= end_date)
            && p.deleivered_user_auth_id == user_auth_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationBeatweanDateWithoutTimeOpenOrdersListByAuthId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationBeatweanDateWithoutTimeOpenOrdersListByAuthId([FromQuery] int page,
    [FromQuery] int size,
    [FromQuery] DateTime begin_date, [FromQuery] DateTime end_date,[FromQuery] long user_auth_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterOrder> categoryList = await _context.WaterOrder
                .Include(p => p.user)
                .Include(p => p.client)
                .Include(p => p.address)
                .Where(p => p.active_status == true
                && p.accepted_status == false
                && (p.order_date >= begin_date && p.order_date <= end_date)
                && p.deleivered_user_auth_id == user_auth_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterOrder>();
            }
            foreach (WaterOrder itm_o in categoryList)
            {

                List<WaterOrderItem> item_odr = await _context.WaterOrderItem
                    
                    .Where(p => p.WaterOrderid == itm_o.id)
                    .ToListAsync();

                if (item_odr == null)
                {
                    item_odr = new List<WaterOrderItem>();
                }

                String product_name_list = "";
                String product_name_list_with_qty = "";
                String product_name_list_with_qty_sign = "";

                foreach (WaterOrderItem itom in item_odr)
                {
                    itom.product = await _context.WaterProduct.FindAsync(itom.WaterProductid);
                    product_name_list = product_name_list + itom.product.name;
                    product_name_list_with_qty = product_name_list_with_qty + itom.product.name + " (" + itom.qty.ToString() + ")   ";
                    product_name_list_with_qty_sign = product_name_list_with_qty_sign + itom.product.name + "==" + itom.qty.ToString() + "  ";
                }

                itm_o.name_pp = product_name_list;
                itm_o.name_pp1 = product_name_list_with_qty;
                itm_o.name_pp2 = product_name_list_with_qty_sign;


            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterOrder.Where(p => p.active_status == true
            && p.accepted_status == false
            && (p.order_date >= begin_date && p.order_date <= end_date)
            && p.deleivered_user_auth_id == user_auth_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationBeatweanDateWithoutTimeOpenOrdersListByNotAddedAnyUser")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationBeatweanDateWithoutTimeOpenOrdersListByNotAddedAnyUser([FromQuery] int page,
    [FromQuery] int size,
    [FromQuery] DateTime begin_date, [FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterOrder> categoryList = await _context.WaterOrder
                .Include(p => p.user)
                .Include(p => p.client)
                .Include(p => p.address)
                .Where(p => p.active_status == true
                && p.accepted_status == false
                && (p.order_date >= begin_date && p.order_date <= end_date)
                && p.deleivered_user_auth_id == null)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterOrder>();
            }
            foreach (WaterOrder itm_o in categoryList)
            {

                List<WaterOrderItem> item_odr = await _context.WaterOrderItem
                    
                    .Where(p => p.WaterOrderid == itm_o.id)
                    .ToListAsync();

                if (item_odr == null)
                {
                    item_odr = new List<WaterOrderItem>();
                }

                String product_name_list = "";
                String product_name_list_with_qty = "";
                String product_name_list_with_qty_sign = "";

                foreach (WaterOrderItem itom in item_odr)
                {
                    itom.product = await _context.WaterProduct.FindAsync(itom.WaterProductid);
                    product_name_list = product_name_list + itom.product.name;
                    product_name_list_with_qty = product_name_list_with_qty + itom.product.name + " (" + itom.qty.ToString() + ")   ";
                    product_name_list_with_qty_sign = product_name_list_with_qty_sign + itom.product.name + "==" + itom.qty.ToString() + "  ";
                }

                itm_o.name_pp = product_name_list;
                itm_o.name_pp1 = product_name_list_with_qty;
                itm_o.name_pp2 = product_name_list_with_qty_sign;


            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterOrder.Where(p => p.active_status == true
            && p.accepted_status == false
            && (p.order_date >= begin_date && p.order_date <= end_date)
            && p.deleivered_user_auth_id == null).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationBeatweanDateWithoutTimeOpenOrdersList")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationBeatweanDateWithoutTimeOpenOrdersList([FromQuery] int page,
            [FromQuery] int size,
            [FromQuery] DateTime begin_date,[FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterOrder> categoryList = await _context.WaterOrder
                .Where(p => p.active_status == true
                && p.accepted_status == false
                && (p.order_date >= begin_date && p.order_date<= end_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterOrder>();
            }

            foreach (WaterOrder itm_o in categoryList) {
                itm_o.user = await _context.WaterUser.FindAsync(itm_o.WaterUserid);
                itm_o.client = await _context.WaterClient.FindAsync(itm_o.WaterClientid);
                itm_o.address = await _context.WaterClientAddress.FindAsync(itm_o.WaterClientAddressid);


                List<WaterOrderItem> item_odr = await _context.WaterOrderItem
                    .Where(p => p.WaterOrderid == itm_o.id)
                    .ToListAsync();

                if (item_odr == null) {
                    item_odr = new List<WaterOrderItem>();
                }

                String product_name_list = "";
                String product_name_list_with_qty = "";
                String product_name_list_with_qty_sign = "";

                foreach (WaterOrderItem itom in item_odr) {
                    itom.product = await _context.WaterProduct.FindAsync(itom.WaterProductid);
                    product_name_list = product_name_list  + itom.product.name;
                    product_name_list_with_qty = product_name_list_with_qty + itom.product.name + " (" + itom.qty.ToString() + ")   ";
                    product_name_list_with_qty_sign = product_name_list_with_qty_sign + itom.product.name + "==" + itom.qty.ToString() + "  ";
                }

                itm_o.name_pp = product_name_list;
                itm_o.name_pp1 = product_name_list_with_qty;
                itm_o.name_pp2 = product_name_list_with_qty_sign;


            }

            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterOrder.Where(p => p.active_status == true
            && p.accepted_status == false
            && (p.order_date >= begin_date && p.order_date <= end_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationBeatweanDateWithoutTimeClosedOrdersList")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationBeatweanDateWithoutTimeClosedOrdersList([FromQuery] int page,
    [FromQuery] int size,
    [FromQuery] DateTime begin_date, [FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterOrder> categoryList = await _context.WaterOrder
                .Include(p => p.user)
                .Include(p => p.client)
                .Include(p => p.address)
                .Where(p => p.active_status == true
                && p.accepted_status == true
                && (p.order_date >= begin_date && p.order_date <= end_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterOrder>();
            }
            foreach (WaterOrder itm_o in categoryList)
            {

                List<WaterOrderItem> item_odr = await _context.WaterOrderItem
                    .Where(p => p.WaterOrderid == itm_o.id)
                    .ToListAsync();

                if (item_odr == null)
                {
                    item_odr = new List<WaterOrderItem>();
                }

                String product_name_list = "";
                String product_name_list_with_qty = "";
                String product_name_list_with_qty_sign = "";

                foreach (WaterOrderItem itom in item_odr)
                {
                    itom.product = await _context.WaterProduct.FindAsync(itom.WaterProductid);
                    product_name_list = product_name_list + itom.product.name;
                    product_name_list_with_qty = product_name_list_with_qty + itom.product.name + " (" + itom.qty.ToString() + ")   ";
                    product_name_list_with_qty_sign = product_name_list_with_qty_sign + itom.product.name + "==" + itom.qty.ToString() + "  ";
                }

                itm_o.name_pp = product_name_list;
                itm_o.name_pp1 = product_name_list_with_qty;
                itm_o.name_pp2 = product_name_list_with_qty_sign;


            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterOrder.Where(p => p.active_status == true
            && p.accepted_status == true
            && (p.order_date >= begin_date && p.order_date <= end_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationClosedOrdersList")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationClosedOrdersList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterOrder> categoryList = await _context.WaterOrder
                .Include(p => p.user)
                .Include(p => p.client)
                .Include(p => p.address)
                .Where(p => p.active_status == true && p.accepted_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterOrder>();
            }
            foreach (WaterOrder itm_o in categoryList)
            {

                List<WaterOrderItem> item_odr = await _context.WaterOrderItem
                 
                    .Where(p => p.WaterOrderid == itm_o.id)
                    .ToListAsync();

                if (item_odr == null)
                {
                    item_odr = new List<WaterOrderItem>();
                }

                String product_name_list = "";
                String product_name_list_with_qty = "";
                String product_name_list_with_qty_sign = "";

                foreach (WaterOrderItem itom in item_odr)
                {
                    itom.product = await _context.WaterProduct.FindAsync(itom.WaterProductid);
                    product_name_list = product_name_list + itom.product.name;
                    product_name_list_with_qty = product_name_list_with_qty + itom.product.name + " (" + itom.qty.ToString() + ")   ";
                    product_name_list_with_qty_sign = product_name_list_with_qty_sign + itom.product.name + "==" + itom.qty.ToString() + "  ";
                }

                itm_o.name_pp = product_name_list;
                itm_o.name_pp1 = product_name_list_with_qty;
                itm_o.name_pp2 = product_name_list_with_qty_sign;


            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterOrder.Where(p => p.active_status == true && p.accepted_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/WaterOrders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterOrder(long id, WaterOrder waterOrder)
        {
            if (id != waterOrder.id)
            {
                return BadRequest();
            }

            _context.Entry(waterOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterOrderExists(id))
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

        // POST: api/WaterOrders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WaterOrder>> PostWaterOrder(WaterOrder waterOrder)
        {
            _context.WaterOrder.Update(waterOrder);
            await _context.SaveChangesAsync();

            return waterOrder;
        }

        [HttpPost("updateOrAddOrderList")]
        public async Task<ActionResult<IEnumerable<WaterOrder>>> updateOrAddOrderList(List<WaterOrder> waterOrderList)
        {
            _context.WaterOrder.UpdateRange(waterOrderList);
            await _context.SaveChangesAsync();

            return waterOrderList;
        }


        [HttpPost("updateOrAddOrderOnlyWithItems")]
        public async Task<ActionResult<WaterOrder>> updateOrAddOrderOnlyWithItems(WaterOrder order)
        {
            _context.WaterOrder.Update(order);
            await _context.SaveChangesAsync();

            return order;
        }
        // DELETE: api/WaterOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WaterOrder>> DeleteWaterOrder(long id)
        {
            var waterOrder = await _context.WaterOrder.FindAsync(id);
            if (waterOrder == null)
            {
                return NotFound();
            }

            _context.WaterOrder.Remove(waterOrder);
            await _context.SaveChangesAsync();

            return waterOrder;
        }

        private bool WaterOrderExists(long id)
        {
            return _context.WaterOrder.Any(e => e.id == id);
        }
    }
}
