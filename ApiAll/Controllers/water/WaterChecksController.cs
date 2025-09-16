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
    public class WaterChecksController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public WaterChecksController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/WaterChecks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterCheck>>> GetWaterCheck()
        {
            return await _context.WaterCheck.ToListAsync();
        }

        [HttpGet("olinganTowarlarSoniVaList")]
        public async Task<ActionResult<IEnumerable<WaterSelledProductsTemp>>> olinganTowarlarSoniVaList(
            [FromQuery] DateTime begin_date, [FromQuery] DateTime end_date)
        {
            String beginDateStr = begin_date.ToString("yyyy-MM-dd hh:mm:ss");
            String endDateStr = end_date.ToString("yyyy-MM-dd hh:mm:ss");
            return await _context.WaterSelledProductsTemp.FromSqlRaw(
                " SELECT wp.name as tovar_nomi, sum(wot.qty) as soni, sum(wot.real_qty) as xaqiqiy_soni, "+
                " (sum(wc.cash)+sum(wc.card)) as money_sum "+
                " FROM water_check wc " +
                " LEFT JOIN water_order wo ON wo.id = wc.reserverd_number_id_3 "+
                " LEFT JOIN water_order_item wot ON wot.\"WaterOrderid\" = wo.id "+
                " LEFT JOIN water_product wp ON wp.id = wot.\"WaterProductid\" "+
                " WHERE wc.created_date_time BETWEEN '"+ beginDateStr + "' AND '"+ endDateStr + "' "+
                " GROUP BY wp.name ").ToListAsync();
        }

        [HttpGet("getIshlanganPullarList")]
        public async Task<ActionResult<IEnumerable<WaterCheckFakeModel>>> getIshlanganPullarList(
            [FromQuery] DateTime begin_date,[FromQuery] DateTime end_date)
        {

            String beginDateStr = begin_date.ToString("yyyy-MM-dd hh:mm:ss");
            String endDateStr = end_date.ToString("yyyy-MM-dd hh:mm:ss");
            return await _context.WaterCheckFakeModel.FromSqlRaw("" +
                "SELECT   "+
                "sum(wc.summ) as summa,   " +
                "sum(wc.cash) as naqt,   " +
                "sum(wc.card) as karta,   " +
                "sum(wc.debit) as debit,   " +
                "sum(wc.rasxod) as rasxod,   " +
                "wu.fio as fio   " +
                "FROM water_check wc   " +
                "LEFT JOIN water_auth wa ON wa.id = wc.\"WaterAuthid\"   " +
                "LEFT JOIN water_user wu ON wu.id = wa.\"WaterUserid\"   " +
                "WHERE wa.created_date_time >= '"+beginDateStr+"'   " +
                "AND wa.created_date_time <= '"+ endDateStr + "'   " +
                "GROUP BY wu.fio").ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterCheck> categoryList = await _context.WaterCheck
                .Include(p => p.auth)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterCheck>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterCheck.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByDateTime")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByDateTime([FromQuery] int page, [FromQuery] int size,[FromQuery] DateTime begin_date,[FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterCheck> categoryList = await _context.WaterCheck
                .Include(p => p.auth)
                .Where(p => p.active_status == true && ( p.created_date_time >= begin_date && p.created_date_time <= end_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterCheck>();
            }

            foreach (WaterCheck itm in categoryList) {
                WaterOrder order = await _context.WaterOrder.FindAsync(itm.reserverd_number_id_3);
                if (order != null) {

                    List<WaterOrderItem> orderItems = await _context.WaterOrderItem
                        .Include(p => p.product)
                        .Where(p => p.WaterOrderid == order.id).ToListAsync();

                    if (orderItems != null) {

                        String product_name_list = "";
                        String product_name_list1 = "";
                        String product_name_list2 = "";
                        foreach (WaterOrderItem itmord in orderItems) {
                            product_name_list = product_name_list + itmord.product.name+"  ";
                            product_name_list1 = product_name_list1 + itmord.product.name +"_"+itmord.qty.ToString()+ "  ";
                            product_name_list2 = product_name_list2 + itmord.product.name + "==" + itmord.qty.ToString() + "  ";
                        }

                        itm.product_name_list_pp = product_name_list;
                        itm.product_name_list_pp_1 = product_name_list1;
                        itm.product_name_list_pp_2 = product_name_list2;


                    }

                }

            }


            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterCheck.Where(p => p.active_status == true && (p.created_date_time >= begin_date && p.created_date_time <= end_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByAuthIdByDateTime")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByAuthIdByDateTime([FromQuery] int page, [FromQuery] int size, [FromQuery] long auth_id, [FromQuery] DateTime begin_date, [FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterCheck> categoryList = await _context.WaterCheck
                .Include(p => p.auth)
                .Where(p => p.active_status == true
                && p.WaterAuthid == auth_id
                 && (p.created_date_time >= begin_date && p.created_date_time <= end_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterCheck>();
            }

            foreach (WaterCheck itm in categoryList)
            {
                WaterOrder order = await _context.WaterOrder.FindAsync(itm.reserverd_number_id_3);
                if (order != null)
                {

                    List<WaterOrderItem> orderItems = await _context.WaterOrderItem
                        .Include(p => p.product)
                        .Where(p => p.WaterOrderid == order.id).ToListAsync();

                    if (orderItems != null)
                    {

                        String product_name_list = "";
                        foreach (WaterOrderItem itmord in orderItems)
                        {
                            product_name_list = product_name_list + itmord.product.name + "_" + itmord.qty.ToString();
                        }

                        itm.product_name_list_pp = product_name_list;



                    }

                }

            }

            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterCheck.Where(p => p.active_status == true
            && p.WaterAuthid == auth_id
             && (p.created_date_time >= begin_date && p.created_date_time <= end_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByAuthId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByAuthId([FromQuery] int page, [FromQuery] int size,[FromQuery] long auth_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterCheck> categoryList = await _context.WaterCheck
                .Include(p => p.auth)
                .Where(p => p.active_status == true && p.WaterAuthid == auth_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterCheck>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterCheck.Where(p => p.active_status == true && p.WaterAuthid == auth_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/WaterChecks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterCheck>> GetWaterCheck(long id)
        {
            var waterCheck = await _context.WaterCheck.FindAsync(id);

            if (waterCheck == null)
            {
                return NotFound();
            }

            return waterCheck;
        }

        // PUT: api/WaterChecks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterCheck(long id, WaterCheck waterCheck)
        {
            if (id != waterCheck.id)
            {
                return BadRequest();
            }

            _context.Entry(waterCheck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterCheckExists(id))
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

        // POST: api/WaterChecks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WaterCheck>> PostWaterCheck(WaterCheck waterCheck)
        {
            _context.WaterCheck.Update(waterCheck);
            await _context.SaveChangesAsync();

            return waterCheck;
        }

        // DELETE: api/WaterChecks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WaterCheck>> DeleteWaterCheck(long id)
        {
            var waterCheck = await _context.WaterCheck.FindAsync(id);
            if (waterCheck == null)
            {
                return NotFound();
            }

            _context.WaterCheck.Remove(waterCheck);
            await _context.SaveChangesAsync();

            return waterCheck;
        }

        private bool WaterCheckExists(long id)
        {
            return _context.WaterCheck.Any(e => e.id == id);
        }
    }
}
