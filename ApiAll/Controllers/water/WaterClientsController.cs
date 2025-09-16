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
using System.Net.Http;
namespace ApiAll.Controllers.water
{
    [ApiExplorerSettings(GroupName = "v9")]
    [Route("api/[controller]")]
    [ApiController]
    public class WaterClientsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        // private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _botToken = "5168670876:AAGp9WQY4jDrk2j_ZU57Cy3-0g6av0TE-ZA";
        private readonly string _chatId = "@extreme_water_clients"; // channel username

        public WaterClientsController(ApplicationContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        public class TelegramMessageDto
        {
            public string Text { get; set; }
        }
        // telegram kanalga xabar yuborish
        [HttpPost("send-telegram")]
        public async Task<IActionResult> SendTelegram([FromBody] TelegramMessageDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Text))
                return BadRequest("Text bo‘sh bo‘lmasligi kerak");

            var client = _httpClientFactory.CreateClient(); // shu yerdan HttpClient olasiz

            var url = $"https://api.telegram.org/bot{_botToken}/sendMessage" +
                    $"?chat_id={_chatId}&text={Uri.EscapeDataString(dto.Text)}";

            var response = await client.GetStringAsync(url);

            return Ok(new { success = true, response });
        }


        public class LocationDto
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }
        // telegram kanalga location yuborish
        [HttpPost("send-location")]
        public async Task<IActionResult> SendLocation([FromBody] LocationDto dto)
        {
            if (dto == null || dto.Latitude == 0 || dto.Longitude == 0)
                return BadRequest("Latitude va Longitude to‘g‘ri bo‘lishi kerak!");

            var client = _httpClientFactory.CreateClient();

            var url = $"https://api.telegram.org/bot{_botToken}/sendLocation" +
                      $"?chat_id={_chatId}" +
                      $"&latitude={dto.Latitude}" +
                      $"&longitude={dto.Longitude}";

            var response = await client.GetStringAsync(url);

            return Ok(new { success = true, response });
        }

        // GET: api/WaterClients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterClient>>> GetWaterClient()
        {
            return await _context.WaterClient.ToListAsync();
        }

        [HttpGet("getInfoAboutMoney")]
        public async Task<ActionResult<IEnumerable<WaterMoneyFakeInfo>>> getInfoAboutMoney()
        {
            return await _context.WaterMoneyFakeInfo.FromSqlRaw(
                "SELECT (SELECT (sum(wc.card) +sum(wc.cash)) as money_earned  " +
                "  FROM water_check wc) as full_money,  " +
                "  (select count(wc.id) FROM water_client wc  " +
                "  WHERE wc.reserverd_number_id_3 = 100 ) as otmen_client,  " +
                "  (select count(wc.id) FROM water_client wc  " +
                "  WHERE wc.reserverd_number_id_3 != 100 ) as real_client").ToListAsync();
        }

        [HttpGet("getLastOrderWithDate")]
        public async Task<ActionResult<IEnumerable<WaterClient>>> getLastOrderWithDate([FromQuery] DateTime date_time,[FromQuery] long client_id)
        {
            List<WaterClient> client_all_list = new List<WaterClient>();
            List<WaterClient> not_ordered_clients_list = new List<WaterClient>();
            if (client_id == 0)
            {
                client_all_list = await _context.WaterClient.ToListAsync();
            }
            else {
                client_all_list = await _context.WaterClient.Where(p => p.id == client_id).ToListAsync();
            }

            if (client_all_list == null) {
                return not_ordered_clients_list;

            }


            foreach (WaterClient item in client_all_list) {
                List<WaterOrder> order_list = await _context.WaterOrder.Where(p => p.order_accepted_date >= date_time
                && p.WaterClientid == item.id).ToListAsync();
                if (order_list == null || order_list.Count == 0) {
                    //zakaz qlmagan bu sanadan keyin umuman
                    not_ordered_clients_list.Add(item);
                }

            }

            foreach (WaterClient it in not_ordered_clients_list) {
                List<WaterOrder> last_order_list = await _context.WaterOrder
                    .Where(p => p.WaterClientid == it.id).OrderByDescending(p => p.id).ToListAsync();
                if (last_order_list != null && last_order_list.Count > 0) {
                    it.last_order_of_client = last_order_list.First();
                }

            }

            return not_ordered_clients_list;
        }
        

        // GET: api/WaterClients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterClient>> GetWaterClient(long id)
        {
            var waterClient = await _context.WaterClient
                .Include(p => p.tuman)
                .Include(p => p.addresses)
                .ThenInclude(p => p.tuman)
                .Include(p => p.phone_numbers_list)
                .Where( p=> p.id == id).ToListAsync();

            if (waterClient == null || waterClient.Count == 0)
            {
                return NotFound();
            }

            return waterClient.First();
        }


        [HttpGet("restoreDisableClientForDeletingAll")]
        public async Task<ActionResult<WaterClient>> restoreDisableClientForDeletingAll(long id)
        {
            var waterClient = await _context.WaterClient
                .Where(p => p.id == id).ToListAsync();

            if (waterClient == null || waterClient.Count == 0)
            {
                return NotFound();
            }

            //address
            List<WaterClientAddress> addressList = await _context.WaterClientAddress
                .Where(p => p.WaterClientid == waterClient.First().id).ToListAsync();

            foreach (WaterClientAddress it in addressList)
            {
                it.active_status = true;

            }

            //phone number
            List<WaterClientPhoneNumber> phoneNumbers = await _context.WaterClientPhoneNumber
                .Where(p => p.WaterClientid == waterClient.First().id)
                .ToListAsync();

            foreach (WaterClientPhoneNumber itm in phoneNumbers)
            {
                itm.active_status = true;
            }

            waterClient.First().active_status = true;
            waterClient.First().reserverd_number_id_3 = 99;

            //update user
            _context.WaterClient.Update(waterClient.First());
            await _context.SaveChangesAsync();

            //update user phone list
            _context.WaterClientPhoneNumber.UpdateRange(phoneNumbers);
            await _context.SaveChangesAsync();

            //update adress list
            _context.WaterClientAddress.UpdateRange(addressList);
            await _context.SaveChangesAsync();

            return waterClient.First();
        }

        [HttpGet("disableClientForDeletingAll")]
        public async Task<ActionResult<WaterClient>> disableClientForDeletingAll(long id)
        {
            var waterClient = await _context.WaterClient
                .Where(p => p.id == id).ToListAsync();

            if (waterClient == null || waterClient.Count == 0)
            {
                return NotFound();
            }

            //address
            List<WaterClientAddress> addressList = await _context.WaterClientAddress
                .Where(p => p.WaterClientid == waterClient.First().id).ToListAsync();

            foreach (WaterClientAddress it in addressList) {
                it.active_status = false;

            }

            //phone number
            List<WaterClientPhoneNumber> phoneNumbers = await _context.WaterClientPhoneNumber
                .Where(p => p.WaterClientid == waterClient.First().id)
                .ToListAsync();

            foreach (WaterClientPhoneNumber itm in phoneNumbers) {
                itm.active_status = false;
            }

            waterClient.First().active_status = false;
            waterClient.First().reserverd_number_id_3 = 100;

            //update user
            _context.WaterClient.Update(waterClient.First());
            await _context.SaveChangesAsync();

            //update user phone list
            _context.WaterClientPhoneNumber.UpdateRange(phoneNumbers);
            await _context.SaveChangesAsync();

            //update adress list
            _context.WaterClientAddress.UpdateRange(addressList);
            await _context.SaveChangesAsync();

            return waterClient.First();
        }


        [HttpGet("getLastClientInfo")]
        public async Task<ActionResult<WaterClient>> getLastClientById()
        {

            try
            {
                var id = await _context.WaterClient.MaxAsync(p => p.id);

            var waterClient = await _context.WaterClient
                .Include(p => p.tuman)
                .Include(p => p.addresses)
                .ThenInclude(p => p.tuman)
                .Include(p => p.phone_numbers_list)
                .Where(p => p.id == id).ToListAsync();

            if (waterClient == null || waterClient.Count == 0)
            {
                return NotFound();
            }
                return waterClient.First();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }

         
        }

        [HttpGet("getPaginationOnlyActiveClientListByTumanId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationOnlyActiveClientListByTumanId([FromQuery] int page, [FromQuery] int size, [FromQuery] long tuman_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterClientAddress> categoryList = new List<WaterClientAddress>();
            if (tuman_id == 0)
            {
                categoryList = await _context.WaterClientAddress
                .Include(p => p.client)
                .Where(p => p.active_status == true && p.WaterTumanid != tuman_id && p.client.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            }
            else
            {
                categoryList = await _context.WaterClientAddress
                .Include(p => p.client)
                .Where(p => p.active_status == true && p.WaterTumanid == tuman_id && p.client.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();

            }



            if (categoryList == null)
            {
                categoryList = new List<WaterClientAddress>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            if (tuman_id == 0)
            {
                paginationModel.items_count = await _context.WaterClientAddress
                .Where(p => p.active_status == true && p.WaterTumanid != tuman_id).CountAsync();
            }
            else
            {
                paginationModel.items_count = await _context.WaterClientAddress
                .Where(p => p.active_status == true && p.WaterTumanid == tuman_id).CountAsync();
            }


            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationClientListByTumanId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationClientListByTumanId([FromQuery] int page, [FromQuery] int size, [FromQuery] long tuman_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterClientAddress> categoryList = new List<WaterClientAddress>();
            if (tuman_id == 0)
            {
                categoryList = await _context.WaterClientAddress
                .Include(p => p.client)
                .Where(p => p.active_status == true && p.WaterTumanid != tuman_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            }
            else {
                categoryList = await _context.WaterClientAddress
                .Include(p => p.client)
                .Where(p => p.active_status == true && p.WaterTumanid == tuman_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();

            }



            if (categoryList == null)
            {
                categoryList = new List<WaterClientAddress>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            if (tuman_id == 0)
            {
                paginationModel.items_count = await _context.WaterClientAddress
                .Where(p => p.active_status == true && p.WaterTumanid != tuman_id).CountAsync();
            }
            else {
                paginationModel.items_count = await _context.WaterClientAddress
                .Where(p => p.active_status == true && p.WaterTumanid == tuman_id).CountAsync();
            }

  
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationAddessByClientId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationAddessByClientId([FromQuery] int page, [FromQuery] int size,[FromQuery] long client_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterClientAddress> categoryList = await _context.WaterClientAddress
                .Include(p => p.client)
                .Where(p => p.active_status == true && p.WaterClientid == client_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterClientAddress>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterClientAddress.Where(p => p.active_status == true && p.WaterClientid == client_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationPhoneNumberByClientId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationPhoneNumberByClientId([FromQuery] int page, [FromQuery] int size, [FromQuery] long client_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterClientPhoneNumber> categoryList = await _context.WaterClientPhoneNumber
                .Include(p => p.client)
                .Where(p => p.active_status == true && p.WaterClientid == client_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterClientPhoneNumber>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterClientPhoneNumber.Where(p => p.active_status == true && p.WaterClientid == client_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterClient> categoryList = await _context.WaterClient
                .Include(p => p.tuman)
                .Include(p => p.addresses)
                .Include(p =>p.phone_numbers_list)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterClient>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterClient.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationDeletedClients")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationDeletedClients([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterClient> categoryList = await _context.WaterClient
                .Include(p => p.tuman)
                .Include(p => p.addresses)
                .Include(p => p.phone_numbers_list)
                .Where(p => p.active_status == false
                && p.reserverd_number_id_3 == 100)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterClient>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterClient.Where(p => p.active_status == false
            && p.reserverd_number_id_3 == 100).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationRestoreDeletedClients")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationRestoreDeletedClients([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterClient> categoryList = await _context.WaterClient
                .Include(p => p.tuman)
                .Include(p => p.addresses)
                .Include(p => p.phone_numbers_list)
                .Where(p => p.active_status == true
                && p.reserverd_number_id_3 == 99)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterClient>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterClient.Where(p => p.active_status == true
            && p.reserverd_number_id_3 == 99).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("deleteClientByIdAndNote")]
        public async Task<ActionResult<WaterClient>> deleteClientByIdAndNote([FromQuery]long id,[FromQuery]String note)
        {
            var waterClient = await _context.WaterClient
                .Include(p => p.tuman)
                .Include(p => p.addresses)
                .ThenInclude(p => p.tuman)
                .Include(p => p.phone_numbers_list)
                .Where(p => p.id == id).ToListAsync();

            if (waterClient == null || waterClient.Count == 0)
            {
                return NotFound();
            }
            waterClient.First().active_status = false;
            waterClient.First().reserverd_number_id_3 = 100;
            waterClient.First().reserverd_note_3 = note;
            _context.WaterClient.Update(waterClient.First());
            await _context.SaveChangesAsync();
            return waterClient.First();
        }


        [HttpGet("restoreDeleteClientByIdAndNote")]
        public async Task<ActionResult<WaterClient>> restoreDeleteClientByIdAndNote([FromQuery] long id, [FromQuery] String note)
        {
            var waterClient = await _context.WaterClient
                .Include(p => p.tuman)
                .Include(p => p.addresses)
                .ThenInclude(p => p.tuman)
                .Include(p => p.phone_numbers_list)
                .Where(p => p.id == id).ToListAsync();

            if (waterClient == null || waterClient.Count == 0)
            {
                return NotFound();
            }
            waterClient.First().active_status = true;
            waterClient.First().reserverd_number_id_3 = 99;
            waterClient.First().reserverd_note_3 = note;
            _context.WaterClient.Update(waterClient.First());
            await _context.SaveChangesAsync();
            return waterClient.First();
        }

        [HttpGet("getPaginationStatistikReportQueryOtmenBolganlardiki2")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationStatistikReportQueryOtmenBolganlardiki2(
[FromQuery] int page, [FromQuery] int size,
[FromQuery] long tuman_id, [FromQuery] long client_id)
        {

            String tuman_str = " != 0";
            if (tuman_id > 0)
            {
                tuman_str = " = " + tuman_id.ToString();
            }
            String client_str = " != 0";

            if (client_id > 0)
            {
                client_str = " = " + client_id.ToString();
            }

            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterStatistikaFakeReport2> categoryList = await _context.WaterStatistikaFakeReport2
                .FromSqlRaw(" SELECT   " +
 " wc.fio as fio,   " +
 " wca.address as address,   " +
 " wt.name as tuman_name,   " +
 " (SELECT count(wo.id) as zakazlar_soni FROM water_order wo WHERE wo.\"WaterClientid\" = wc.id),   " +
" (SELECT array_to_string(array_agg(   " +
 " COALESCE(to_char(wo.order_accepted_date, 'YYYY/MM/DD'), '') || '_' || wot.qty), ' ')   " +
 " FROM  water_order wo   " +
 " LEFT JOIN water_order_item wot ON wot.\"WaterOrderid\" = wo.id   " +
 " LEFT JOIN water_product wp ON wp.id = wot.\"WaterProductid\"   " +
 " WHERE wo.accepted_status = true   " +
 " AND wp.main_product = true   " +
 " AND wo.\"WaterClientid\" = wc.id   " +
 " GROUP BY wo.id  ORDER BY wo.id DESC  LIMIT 1) as last_order_date,   " +
 " (SELECT array_to_string(array_agg(   " +
 " COALESCE(to_char(wo.order_accepted_date, 'YYYY/MM/DD'), '') || '_' || wot.qty), ' ')   " +
 " FROM water_order wo   " +
 " LEFT JOIN water_order_item wot ON wot.\"WaterOrderid\" = wo.id   " +
 " LEFT JOIN water_product wp ON wp.id = wot.\"WaterProductid\"   " +
 " WHERE wo.accepted_status = true   " +
 " AND wp.main_product = true   " +
 " AND wo.\"WaterClientid\" = wc.id   " +
 " GROUP BY wo.id ORDER BY wo.id ASC  LIMIT 1) as first_order_date,   " +
 " (SELECT sum(wot.qty) as qty   " +
 " FROM water_order wo   " +
 " LEFT JOIN water_order_item wot ON wot.\"WaterOrderid\" = wo.id   " +
 " LEFT JOIN water_product wp ON wp.id = wot.\"WaterProductid\"   " +
 " WHERE wo.accepted_status = true   " +
 " AND wp.main_product = true   " +
 " AND wo.\"WaterClientid\" = wc.id) as olgan_suv_soni,      " +
 " wbi.bottle_count as bakalashka_soni1   " +
 " FROM public.water_client_address wca   " +
 " LEFT JOIN water_client wc ON wc.id = wca.\"WaterClientid\"      " +
 " LEFT JOIN water_tuman wt ON wt.id = wca.\"WaterTumanid\"    " +
 " LEFT JOIN water_client_bottle_info wbi ON wbi.\"WaterClientAddressid\"  = wca.id   " +
 " WHERE wt.id  " + tuman_str + "   " +
 " AND wc.id  " + client_str + "  AND wc.active_status = false " +
 " ORDER BY wc.id ASC")
                .Skip(page * size).Take(size).ToListAsync();

            if (categoryList == null)
            {
                categoryList = new List<WaterStatistikaFakeReport2>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = categoryList.Count();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationStatistikReportQuery2")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationStatistikReportQuery2(
    [FromQuery] int page, [FromQuery] int size,
    [FromQuery] long tuman_id, [FromQuery] long client_id)
        {

            String tuman_str = " != 0";
            if (tuman_id > 0)
            {
                tuman_str = " = " + tuman_id.ToString();
            }
            String client_str = " != 0";

            if (client_id > 0)
            {
                client_str = " = " + client_id.ToString();
            }

            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterStatistikaFakeReport2> categoryList = await _context.WaterStatistikaFakeReport2
                .FromSqlRaw(" SELECT   "+
 " wc.fio as fio,   " +
 " wca.address as address,   " +
 " wt.name as tuman_name,   " +
 " (SELECT count(wo.id) as zakazlar_soni FROM water_order wo WHERE wo.\"WaterClientid\" = wc.id),   " +
" (SELECT array_to_string(array_agg(   " +
 " COALESCE(to_char(wo.order_accepted_date, 'YYYY/MM/DD'), '') || '_' || wot.qty), ' ')   " +
 " FROM  water_order wo   " +
 " LEFT JOIN water_order_item wot ON wot.\"WaterOrderid\" = wo.id   " +
 " LEFT JOIN water_product wp ON wp.id = wot.\"WaterProductid\"   " +
 " WHERE wo.accepted_status = true   " +
 " AND wp.main_product = true   " +
 " AND wo.\"WaterClientid\" = wc.id   " +
 " GROUP BY wo.id  ORDER BY wo.id DESC  LIMIT 1) as last_order_date,   " +
 " (SELECT array_to_string(array_agg(   " +
 " COALESCE(to_char(wo.order_accepted_date, 'YYYY/MM/DD'), '') || '_' || wot.qty), ' ')   " +
 " FROM water_order wo   " +
 " LEFT JOIN water_order_item wot ON wot.\"WaterOrderid\" = wo.id   " +
 " LEFT JOIN water_product wp ON wp.id = wot.\"WaterProductid\"   " +
 " WHERE wo.accepted_status = true   " +
 " AND wp.main_product = true   " +
 " AND wo.\"WaterClientid\" = wc.id   " +
 " GROUP BY wo.id ORDER BY wo.id ASC  LIMIT 1) as first_order_date,   " +
 " (SELECT sum(wot.qty) as qty   " +
 " FROM water_order wo   " +
 " LEFT JOIN water_order_item wot ON wot.\"WaterOrderid\" = wo.id   " +
 " LEFT JOIN water_product wp ON wp.id = wot.\"WaterProductid\"   " +
 " WHERE wo.accepted_status = true   " +
 " AND wp.main_product = true   " +
 " AND wo.\"WaterClientid\" = wc.id) as olgan_suv_soni,      " +
 " wbi.bottle_count as bakalashka_soni1   " +
 " FROM public.water_client_address wca   " +
 " LEFT JOIN water_client wc ON wc.id = wca.\"WaterClientid\"      " +
 " LEFT JOIN water_tuman wt ON wt.id = wca.\"WaterTumanid\"    " +
 " LEFT JOIN water_client_bottle_info wbi ON wbi.\"WaterClientAddressid\"  = wca.id   " +
 " WHERE wt.id  "+ tuman_str + "   " +
 " AND wc.id  "+ client_str + "  AND wc.active_status = true " +
 " AND (SELECT count(wo.id) FROM water_order wo WHERE wo.\"WaterClientid\" = wc.id) > 0 " +
 " ORDER BY wc.id DESC")
                .Skip(page * size).Take(size).ToListAsync();

            if (categoryList == null)
            {
                categoryList = new List<WaterStatistikaFakeReport2>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = categoryList.Count();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationStatistikReportQuery")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationStatistikReportQuery(
            [FromQuery] int page, [FromQuery] int size,
            [FromQuery] long tuman_id,[FromQuery] long client_id)
        {

            String tuman_str = " != 0";
            if (tuman_id > 0) {
                tuman_str = " = " + tuman_id.ToString();
            }
            String client_str = " != 0";

            if (client_id > 0) {
                client_str = " = " + client_id.ToString();
            }

            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterStatistikaFakeReport> categoryList = await _context.WaterStatistikaFakeReport
                .FromSqlRaw("SELECT    "+
                "   wc.fio as fio,    " +
                "   wca.address as address,    " +
                "   wt.name as tuman_name,    " +
                "   (SELECT array_to_string(array_agg(    " +
                "   COALESCE(to_char(wo.order_accepted_date, 'YYYY/MM/DD'), '') || '_' || wot.qty), ' ')    " +
                "   FROM  water_order wo    " +
                "   LEFT JOIN water_order_item wot ON wot.\"WaterOrderid\" = wo.id    " +
                "   LEFT JOIN water_product wp ON wp.id = wot.\"WaterProductid\"    " +
                "   WHERE wo.accepted_status = true    " +
                "   AND wp.main_product = true    " +
                "   AND wo.\"WaterClientid\" = wc.id    " +
                "   GROUP BY wo.id  ORDER BY wo.id DESC  LIMIT 1) as last_order_date,    " +
                "   (SELECT sum(wot.qty) as qty    " +
                "   FROM  water_order wo    " +
                "   LEFT JOIN water_order_item wot ON wot.\"WaterOrderid\" = wo.id    " +
                "   LEFT JOIN water_product wp ON wp.id = wot.\"WaterProductid\"    " +
                "   WHERE wo.accepted_status = true    " +
                "   AND wp.main_product = true    " +
                "   AND wo.\"WaterClientid\" = wc.id) as olgan_suv_soni,    " +
                "   wbi.bottle_count as bakalashka_soni1    " +
                "   FROM public.water_client_address wca    " +
                "   LEFT JOIN water_client wc ON wc.id = wca.\"WaterClientid\"    " +
                "   LEFT JOIN water_tuman wt ON wt.id = wca.\"WaterTumanid\"    " +
                "   LEFT JOIN water_client_bottle_info wbi ON wbi.\"WaterClientAddressid\"  = wca.id    " +
                "   WHERE wt.id   "+tuman_str+"    " +
                "   AND wc.id "+client_str+"    " +
                "   ORDER BY wc.id ASC")
                .Skip(page * size).Take(size).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterStatistikaFakeReport>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = categoryList.Count();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }




        [HttpGet("getPaginationForReportStatistika")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationForReportStatistika(
            [FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterClient> categoryList = await _context.WaterClient
                .Include(p => p.tuman)
                .Include(p => p.addresses)
                .Include(p => p.phone_numbers_list)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterClient>();
            }

            foreach (WaterClient item in categoryList) {
                item.order_item_list_for_report_desc = await _context.
                    WaterOrderItem
                    .Include(p => p.order)
                    .Include(p => p.product)
                    .Where(p => p.order.WaterClientid == item.id && p.product.main_product == true)
                    .OrderByDescending(p => p.id).ToListAsync();

            }

            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterClient.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationSearchByPhoneNumber")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationSearchByPhoneNumber([FromQuery] int page, [FromQuery] int size,[FromQuery]String phone_number)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterClient> categoryList = await _context.WaterClient
                .Include(p => p.tuman)
                .Include(p => p.addresses)
                .Include(p => p.phone_numbers_list)
                .Where(p => p.active_status == true
                && (p.phone_number.ToLower().Contains(phone_number.ToLower())
                || p.phone_number1.ToLower().Contains(phone_number.ToLower())
                || p.phone_number2.ToLower().Contains(phone_number.ToLower())
                || p.phone_number3.ToLower().Contains(phone_number.ToLower())))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterClient>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterClient.Where(p => p.active_status == true
                && (p.phone_number.ToLower().Contains(phone_number.ToLower())
                || p.phone_number1.ToLower().Contains(phone_number.ToLower())
                || p.phone_number2.ToLower().Contains(phone_number.ToLower())
                || p.phone_number3.ToLower().Contains(phone_number.ToLower()))).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationSearchByPhoneNumberFromArray")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationSearchByPhoneNumberFromArray([FromQuery] int page, [FromQuery] int size, [FromQuery] String phone_number)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterClientPhoneNumber> categoryList = await _context.WaterClientPhoneNumber
                .Include(p => p.client)
                .Where(p => p.active_status == true
                && (p.phone_number.ToLower().Contains(phone_number.ToLower())))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterClientPhoneNumber>();
            }

            foreach (WaterClientPhoneNumber it  in categoryList) {
                List<WaterClient> clientPhoneNumbers = await _context.WaterClient
                    .Include(p => p.addresses)
                    .Include(p => p.phone_numbers_list)
                    .Where(p => p.id == it.WaterClientid).ToListAsync();
                it.clinet_obj = JObject.FromObject(clientPhoneNumbers.First());
            }

            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterClientPhoneNumber.Where(p => p.active_status == true
                && (p.phone_number.ToLower().Contains(phone_number.ToLower()))).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationSearchByAddressFromArray")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationSearchByAddressFromArray([FromQuery] int page, [FromQuery] int size, [FromQuery] String address)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterClientAddress> categoryList = await _context.WaterClientAddress
                .Include(p => p.client)
                .Where(p => p.active_status == true
                && (p.address.ToLower().Contains(address.ToLower())))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterClientAddress>();
            }

            foreach (WaterClientAddress it in categoryList)
            {
                List<WaterClient> clientPhoneNumbers = await _context.WaterClient
                 .Include(p => p.addresses)
                 .Include(p => p.phone_numbers_list)
                 .Where(p => p.id == it.WaterClientid).ToListAsync();
                it.clinet_obj = JObject.FromObject(clientPhoneNumbers.First());
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterClientAddress.Where(p => p.active_status == true
                && (p.address.ToLower().Contains(address.ToLower()))).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationSearchByTumanIdFromArray")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationSearchByTumanIdFromArray([FromQuery] int page, [FromQuery] int size, [FromQuery] long tuman_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterClientAddress> categoryList = await _context.WaterClientAddress
                .Include(p => p.client)
                .Where(p => p.active_status == true
                && p.WaterTumanid == tuman_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterClientAddress>();
            }

            foreach (WaterClientAddress it in categoryList)
            {
                List<WaterClient> clientPhoneNumbers = await _context.WaterClient
                 .Include(p => p.addresses)
                 .Include(p => p.phone_numbers_list)
                 .Where(p => p.id == it.WaterClientid).ToListAsync();
                it.clinet_obj = JObject.FromObject(clientPhoneNumbers.First());
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterClientAddress.Where(p => p.active_status == true
                && p.WaterTumanid == tuman_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByTumanId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByTumanId([FromQuery] int page, [FromQuery] int size,[FromQuery] long tuman_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterClient> categoryList = await _context.WaterClient
                .Include(p => p.tuman)
                .Include(p => p.addresses)
                .Include(p => p.phone_numbers_list)
                .Where(p => p.active_status == true && p.WaterTumanid == tuman_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterClient>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterClient.Where(p => p.active_status == true && p.WaterTumanid == tuman_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationByName")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByName([FromQuery] int page, [FromQuery] int size, [FromQuery] String fio)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterClient> categoryList = await _context.WaterClient
                .Include(p => p.tuman)
                .Include(p => p.addresses)
                .Include(p => p.phone_numbers_list)
                .Where(p => p.active_status == true && p.fio.ToLower().Contains(fio.ToLower()))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterClient>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterClient.Where(p => p.active_status == true && p.fio.ToLower().Contains(fio.ToLower())).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        // PUT: api/WaterClients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterClient(long id, WaterClient waterClient)
        {
            if (id != waterClient.id)
            {
                return BadRequest();
            }

            _context.Entry(waterClient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterClientExists(id))
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

        // POST: api/WaterClients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WaterClient>> PostWaterClient(WaterClient waterClient)
        {
            _context.WaterClient.Update(waterClient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaterClient", new { id = waterClient.id }, waterClient);
        }

        // DELETE: api/WaterClients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WaterClient>> DeleteWaterClient(long id)
        {
            var waterClient = await _context.WaterClient.FindAsync(id);
            if (waterClient == null)
            {
                return NotFound();
            }

            _context.WaterClient.Remove(waterClient);
            await _context.SaveChangesAsync();

            return waterClient;
        }

        [HttpDelete("deleteAddress")]
        public async Task<ActionResult<WaterClientAddress>> deleteAddress([FromQuery]long address_id)
        {
            var waterClient = await _context.WaterClientAddress.FindAsync(address_id);
            if (waterClient == null)
            {
                return NotFound();
            }

            _context.WaterClientAddress.Remove(waterClient);
            await _context.SaveChangesAsync();

            return waterClient;
        }

        [HttpDelete("deletePhoneNumber")]
        public async Task<ActionResult<WaterClientPhoneNumber>> deletePhoneNumber([FromQuery] long phone_id)
        {
            var waterClient = await _context.WaterClientPhoneNumber.FindAsync(phone_id);
            if (waterClient == null)
            {
                return NotFound();
            }

            _context.WaterClientPhoneNumber.Remove(waterClient);
            await _context.SaveChangesAsync();

            return waterClient;
        }



        private bool WaterClientExists(long id)
        {
            return _context.WaterClient.Any(e => e.id == id);
        }
    }
}


