using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.pos;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.pos
{
    [ApiExplorerSettings(GroupName = "v5")]
    [Route("api/[controller]")]
    [ApiController]
    public class PosChecksController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosChecksController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosChecks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosCheck>>> GetPosCheck()
        {
            return await _context.PosCheck.ToListAsync();
        }


        [HttpGet("getSaledSummOfKassirListBeatweenDateReport")]
        public async Task<ActionResult<TexPaginationModel>> getSaledSummOfKassirListBeatweenDateReport([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime begin_date, [FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            String begin_date_str = begin_date.Date.ToString("yyyy-MM-dd");
            String end_date_str = end_date.Date.ToString("yyyy-MM-dd");
            List<PosSaledProductsDegreeQty> itemList = await _context.PosSaledProductsDegreeQty.FromSqlRaw("" +
                " SELECT pu.fio as product_name, " +
                " sum(p_pay.qty) as total_qty, "+
                " sum(p_pay.summ) as total_saled_sum, "+
                " sum(pit.unit_buyed_price * p_pay.qty) as total_prixod_price, "+
                " (sum(p_pay.summ) - sum(pit.unit_buyed_price * p_pay.qty)) as profit_price "+
                " FROM pos_payments p_pay "+
                " LEFT JOIN pos_product p ON p.id = p_pay.product_id "+
                " LEFT JOIN pos_invoice_item pit ON pit.id = p_pay.\"PosInvoiceItemid\" "+
                " LEFT JOIN pos_check pc ON pc.id = p_pay.\"PosCheckid\" "+
                " LEFT JOIN pos_authorization pa ON pa.id = pc.\"PosAuthorizationid\" "+
                " LEFT JOIN pos_user pu ON pu.id = pa.user_id "+
                " WHERE p_pay.created_date_time between '"+ begin_date_str + " 00:00:00' and '"+ end_date_str + " 23:59:59' "+
                " GROUP BY pu.fio ORDER BY  total_saled_sum DESC")
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosSaledProductsDegreeQty>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosSaledProductsDegreeQty.FromSqlRaw("" +
                " SELECT pu.fio as product_name, " +
                " sum(p_pay.qty) as total_qty, " +
                " sum(p_pay.summ) as total_saled_sum, " +
                " sum(pit.unit_buyed_price * p_pay.qty) as total_prixod_price, " +
                " (sum(p_pay.summ) - sum(pit.unit_buyed_price * p_pay.qty)) as profit_price " +
                " FROM pos_payments p_pay " +
                " LEFT JOIN pos_product p ON p.id = p_pay.product_id " +
                " LEFT JOIN pos_invoice_item pit ON pit.id = p_pay.\"PosInvoiceItemid\" " +
                " LEFT JOIN pos_check pc ON pc.id = p_pay.\"PosCheckid\" " +
                " LEFT JOIN pos_authorization pa ON pa.id = pc.\"PosAuthorizationid\" " +
                " LEFT JOIN pos_user pu ON pu.id = pa.user_id " +
                " WHERE p_pay.created_date_time between '" + begin_date_str + " 00:00:00' and '" + end_date_str + " 23:59:59' " +
                " GROUP BY pu.fio ORDER BY  total_saled_sum DESC").CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getMaxSaledProductsByDate")]
        public async Task<ActionResult<TexPaginationModel>> getMaxSaledProductsByDate([FromQuery] int page, [FromQuery] int size,[FromQuery] DateTime begin_date,[FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            String begin_date_str = begin_date.Date.ToString("yyyy-MM-dd");
            String end_date_str = end_date.Date.ToString("yyyy-MM-dd");
            List<PosSaledProductsDegreeQty> itemList = await _context.PosSaledProductsDegreeQty.FromSqlRaw("" +
                    " SELECT p.name as product_name, " +
                    " sum(p_pay.qty) as total_qty, "+
                    " sum(p_pay.summ) as total_saled_sum, "+
                    " sum(pit.unit_buyed_price * p_pay.qty) as total_prixod_price, "+
                    " (sum(p_pay.summ) - sum(pit.unit_buyed_price * p_pay.qty)) as profit_price "+
                    " FROM pos_payments p_pay "+
                    " LEFT JOIN pos_product p ON p.id = p_pay.product_id "+
                    " LEFT JOIN pos_invoice_item pit ON pit.id = p_pay.\"PosInvoiceItemid\" "+
                    " WHERE p_pay.created_date_time between '"+ begin_date_str + " 00:00:00' and '"+ end_date_str + " 23:59:59' "+
                    " GROUP BY p.name ORDER BY  total_qty DESC")
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosSaledProductsDegreeQty>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count =  await _context.PosSaledProductsDegreeQty.FromSqlRaw("" +
                    " SELECT p.name as product_name, " +
                    " sum(p_pay.qty) as total_qty, " +
                    " sum(p_pay.summ) as total_saled_sum, " +
                    " sum(pit.unit_buyed_price * p_pay.qty) as total_prixod_price, " +
                    " (sum(p_pay.summ) - sum(pit.unit_buyed_price * p_pay.qty)) as profit_price " +
                    " FROM pos_payments p_pay " +
                    " LEFT JOIN pos_product p ON p.id = p_pay.product_id " +
                    " LEFT JOIN pos_invoice_item pit ON pit.id = p_pay.\"PosInvoiceItemid\" " +
                    " WHERE p_pay.created_date_time between '" + begin_date_str + " 00:00:00' and '" + end_date_str + " 23:59:59' " +
                    " GROUP BY p.name ORDER BY  total_qty DESC").CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPrixodQilinganProductsBeatweenDate")]
        public async Task<ActionResult<TexPaginationModel>> getPrixodQilinganProductsBeatweenDate([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime begin_date, [FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            String begin_date_str = begin_date.Date.ToString("yyyy-MM-dd");
            String end_date_str = end_date.Date.ToString("yyyy-MM-dd");
            List<PosSaledProductsDegreeQty> itemList = await _context.PosSaledProductsDegreeQty.FromSqlRaw("" +
                " SELECT p.name as product_name,  "+
                " sum(pit.qty) as total_qty, "+
                " sum(pit.unit_saled_price * pit.qty) as total_saled_sum,  "+
                " sum(pit.unit_buyed_price * pit.qty) as total_prixod_price, "+
                " (sum(pit.unit_saled_price * pit.qty) - sum(pit.unit_buyed_price * pit.qty)) as profit_price "+
                " FROM pos_invoice_item pit  "+
                " LEFT JOIN pos_product p ON p.id = pit.product_id  "+
                " WHERE pit.created_date_time between '"+ begin_date_str + " 00:00:00' and '"+ end_date_str + " 23:59:59' "+
                " GROUP BY p.name ORDER BY  total_qty DESC ")
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosSaledProductsDegreeQty>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosSaledProductsDegreeQty.FromSqlRaw("" +
                " SELECT p.name as product_name,  " +
                " sum(pit.qty) as total_qty, " +
                " sum(pit.unit_saled_price * pit.qty) as total_saled_sum,  " +
                " sum(pit.unit_buyed_price * pit.qty) as total_prixod_price, " +
                " (sum(pit.unit_saled_price * pit.qty) - sum(pit.unit_buyed_price * pit.qty)) as profit_price " +
                " FROM pos_invoice_item pit  " +
                " LEFT JOIN pos_product p ON p.id = pit.product_id  " +
                " WHERE pit.created_date_time between '" + begin_date_str + " 00:00:00' and '" + end_date_str + " 23:59:59' " +
                " GROUP BY p.name ORDER BY  total_qty DESC ").CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getReturnedProductsListByBeatweenDateForReport")]
        public async Task<ActionResult<TexPaginationModel>> getReturnedProductsListByBeatweenDateForReport([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime begin_date, [FromQuery] DateTime end_date, [FromQuery] int revert_status)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            String begin_date_str = begin_date.Date.ToString("yyyy-MM-dd");
            String end_date_str = end_date.Date.ToString("yyyy-MM-dd");
            List<PosSaledProductsDegreeQty> itemList = await _context.PosSaledProductsDegreeQty.FromSqlRaw("" +
                " SELECT pp.name as product_name, " +
                " sum(prt.qty) as total_qty, " +
                " sum(prt.qty * prt.price) as total_saled_sum, " +
                " 0 as total_prixod_price, " +
                " 0 as profit_price " +
                " FROM public.pos_revert_item prt " +
                " LEFT JOIN pos_product pp ON pp.id = prt.product_id " +
                " LEFT JOIN pos_invoice_item pit ON pit.id = prt.\"PosInvoiceItemid\" " +
                " LEFT JOIN pos_revert pr ON pr.id = prt.\"PosRevertid\" " +
                " WHERE pr.revert_status= " + revert_status + " AND prt.created_date_time between '" + begin_date_str + " 00:00:00' and '" + end_date_str + " 23:59:59' " +
                " GROUP BY pp.name ORDER  BY pp.name ASC")
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosSaledProductsDegreeQty>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosSaledProductsDegreeQty.FromSqlRaw("" +
                " SELECT pp.name as product_name, " +
                " sum(prt.qty) as total_qty, " +
                " sum(prt.qty * prt.price) as total_saled_sum, " +
                " 0 as total_prixod_price, " +
                " 0 as profit_price " +
                " FROM public.pos_revert_item prt " +
                " LEFT JOIN pos_product pp ON pp.id = prt.product_id " +
                " LEFT JOIN pos_invoice_item pit ON pit.id = prt.\"PosInvoiceItemid\" " +
                " LEFT JOIN pos_revert pr ON pr.id = prt.\"PosRevertid\" " +
                " WHERE pr.revert_status= " + revert_status + " AND prt.created_date_time between '" + begin_date_str + " 00:00:00' and '" + end_date_str + " 23:59:59' " +
                " GROUP BY pp.name ORDER  BY pp.name ASC").CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getCurrentPositionOfAllCashboxByUserList")]
        public async Task<ActionResult<TexPaginationModel>> getCurrentPositionOfAllCashboxByUserList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosKassaCurrentPositionWithName> itemList = await _context.PosKassaCurrentPositionWithName.FromSqlRaw("" +
                " SELECT pu.fio as user_name,sum(summ) as total_sum, sum(card_sum) as card_sum, " +
                " sum(cash_sum) as cash_sum, sum(payme_sum) as payme_sum, "+
                " sum(click_sum) as click_sum, sum(online_sum) as online_sum, "+
                " sum(humo_sum) as humo_sum, sum(mobil_sum) as mobil_sum, "+
                " sum(discount_summ) as discount_sum, sum(bonus_summ) as bonus_sum, "+
                " sum(profit_summ) as profit_sum, "+
                " (SELECT sum(summ) FROM public.pos_costs WHERE \"PosAuthorizationid\"=pc.\"PosAuthorizationid\"  " +
                " AND closed_status = false) as xarajat_sum "+
                " FROM pos_check pc "+
                " LEFT JOIN pos_authorization pa ON pa.id = pc.\"PosAuthorizationid\" "+
                " LEFT JOIN pos_user pu ON pu.id = pa.user_id "+
                " WHERE closed_status = false GROUP BY pc.\"PosAuthorizationid\", pu.fio ")
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosKassaCurrentPositionWithName>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosKassaCurrentPositionWithName.FromSqlRaw("" +
                " SELECT pu.fio as user_name,sum(summ) as total_sum, sum(card_sum) as card_sum, " +
                " sum(cash_sum) as cash_sum, sum(payme_sum) as payme_sum, " +
                " sum(click_sum) as click_sum, sum(online_sum) as online_sum, " +
                " sum(humo_sum) as humo_sum, sum(mobil_sum) as mobil_sum, " +
                " sum(discount_summ) as discount_sum, sum(bonus_summ) as bonus_sum, " +
                " sum(profit_summ) as profit_sum, " +
                " (SELECT sum(summ) FROM public.pos_costs WHERE \"PosAuthorizationid\"=pc.\"PosAuthorizationid\"  " +
                " AND closed_status = false) as xarajat_sum " +
                " FROM pos_check pc " +
                " LEFT JOIN pos_authorization pa ON pa.id = pc.\"PosAuthorizationid\" " +
                " LEFT JOIN pos_user pu ON pu.id = pa.user_id " +
                " WHERE closed_status = false GROUP BY pc.\"PosAuthorizationid\", pu.fio ").CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getReallCurrentSummOfKassa")]
        public async Task<ActionResult<PosKassaCurrentPosition>> getReallCurrentSummOfKassa([FromQuery] long pos_auth_id)
        {
            PosKassaCurrentPosition curSts = new PosKassaCurrentPosition();
            String id_str = " != 0 ";
            if (pos_auth_id > 0) {
                id_str = " = "+ pos_auth_id.ToString();
            }
            List<PosKassaCurrentPosition> currentPositionList = await _context.PosKassaCurrentPosition.FromSqlRaw("" +
                " SELECT sum(summ) as total_sum, sum(card_sum) as card_sum, "+
                " sum(cash_sum) as cash_sum, sum(payme_sum) as payme_sum, "+
                " sum(click_sum) as click_sum, sum(online_sum) as online_sum, "+
                " sum(humo_sum) as humo_sum, sum(mobil_sum) as mobil_sum,  "+
                " sum(discount_summ) as discount_sum, sum(bonus_summ) as bonus_sum, sum(profit_summ) as profit_sum, "+
                " (SELECT sum(summ) FROM public.pos_costs WHERE \"PosAuthorizationid\" "+ id_str + "  AND closed_status = false) as xarajat_sum "+
                " FROM public.pos_check WHERE \"PosAuthorizationid\" "+ id_str + " AND closed_status = false ").ToListAsync();

            if (currentPositionList != null && currentPositionList.Count > 0) {
                curSts = currentPositionList.First();
            }

            return curSts;
        }

        [HttpGet("getSummOfKassiWorkingForReport")]
        public async Task<ActionResult<PosKassirInfo>> getSummOfKassiWorkingForReport([FromQuery] long pos_auth_id,[FromQuery] DateTime begin_date,[FromQuery] DateTime end_time)
        {
            PosKassirInfo curSts = new PosKassirInfo();
            String id_str = " != 0 ";
            if (pos_auth_id > 0)
            {
                id_str = " = " + pos_auth_id.ToString();
            }
            String begin_date_str = begin_date.Date.ToString("yyyy-MM-dd");
            String end_date_str = end_time.Date.ToString("yyyy-MM-dd");

            List<PosKassirInfo> currentPositionList = await _context.PosKassirInfo.FromSqlRaw("" +
                " SELECT pu.fio as name, sum(pc.summ) as total_sum, sum(pc.profit_summ) as profit_sum "+
                " FROM public.pos_check pc "+
                " LEFT JOIN pos_authorization pa ON pa.id = \"PosAuthorizationid\"  "+
                " LEFT JOIN pos_user pu ON pu.id = pa.user_id  "+
                " WHERE \"PosAuthorizationid\" "+ id_str + " AND  "+
                " (date >= '"+ begin_date_str + " 00:00:00' AND date <= '"+ end_date_str + " 23:59:59') GROUP BY pu.fio").ToListAsync();

            if (currentPositionList != null && currentPositionList.Count > 0)
            {
                curSts = currentPositionList.First();
            }

            return curSts;
        }



        [HttpGet("closeKassaByAuthId")]
        public async Task<ActionResult<IEnumerable<PosCheck>>> closeKassaByAuthId([FromQuery] long pos_auth_id)
        {
            List<PosCheck> itemsList =  await _context.PosCheck.Where(p => p.PosAuthorizationid == pos_auth_id).ToListAsync();
            foreach (PosCheck item in itemsList) {
                item.closed_status = true;

            }
            List<PosCosts> posCostList = await _context.PosCosts.Where(p => p.PosAuthorizationid == pos_auth_id).ToListAsync();
            foreach (PosCosts itm in posCostList) {
                itm.closed_status = true;
            }

            _context.PosCosts.UpdateRange(posCostList);
            await _context.SaveChangesAsync();

            _context.PosCheck.UpdateRange(itemsList);
            await _context.SaveChangesAsync();



            return itemsList;
        }

        [HttpGet("getCheckList")]
        public async Task<ActionResult<TexPaginationModel>> getCheckList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosCheck> itemList = await _context.PosCheck
                .Where(p => p.active_status == true)
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosCheck>();
            }

            foreach (PosCheck item in itemList) {
                item.paymentsList = await _context.PosPayments
                    .Include(p =>p.product)
                    .Where(p => p.PosCheckid == item.id).OrderByDescending(p =>p.id).ToListAsync();
            }

            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosCheck
                .Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/PosChecks/5
        [HttpGet("getCheckFullInfo")]
        public async Task<ActionResult<PosCheck>> getCheckFullInfo(long id)
        {
            var posCheck = await _context.PosCheck.FindAsync(id);

            if (posCheck == null)
            {
                return NotFound();
            }
            posCheck.paymentsList = await _context.PosPayments
                    .Include(p => p.product)
                    .Include(p => p.item)
                    .Where(p => p.PosCheckid == id).OrderByDescending(p => p.id).ToListAsync();

            foreach (PosPayments it in posCheck.paymentsList)
            {
                it.product = await _context.PosProduct.FindAsync(it.product_id);
            }

            return posCheck;
        }



        [HttpGet("getProductFromCheckToBack")]
        public async Task<ActionResult<PosPayments>> getProductFromCheckToBack([FromQuery]long pos_payments_id)
        {
            var paymentsList = await _context.PosPayments.Include(p => p.product).Where(p => p.id == pos_payments_id).ToListAsync();

            if (paymentsList == null || paymentsList.Count == 0)
            {
                return NotFound("Payments not found");
            }

            if (paymentsList.First().check_revert_status)
            {
                return NotFound("Payments  already reverted");
            }

            foreach (PosPayments item in paymentsList)
            {
                item.check_revert_status = true;
                var priceList = await _context.PosProductPrice.Where(p => p.product_id == item.product_id).ToListAsync();
                if (priceList == null || priceList.Count == 0)
                {
                    PosProductPrice posProduct = new PosProductPrice();
                    posProduct.active_status = true;
                    posProduct.buyed_price = item.product.buyed_price;
                    posProduct.price = item.product.price;
                    posProduct.percantage = item.product.percentage;
                    posProduct.qty = item.qty;
                    posProduct.real_qty = item.qty;
                    posProduct.product_id = item.product.id;
                    _context.PosProductPrice.Update(posProduct);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    PosProductPrice posProduct = priceList.First();
                    posProduct.qty = posProduct.qty + item.qty;
                    posProduct.real_qty = posProduct.real_qty + item.qty;
                    _context.PosProductPrice.Update(posProduct);
                    await _context.SaveChangesAsync();
                }
            }

            _context.PosPayments.UpdateRange(paymentsList);
            await _context.SaveChangesAsync();


            return paymentsList.First();
        }


        [HttpGet("getCheckToBack")]
        public async Task<ActionResult<PosCheck>> getCheckToBack([FromQuery]long check_id)
        {
            var posCheck = await _context.PosCheck.FindAsync(check_id);

            if (posCheck == null)
            {
                return NotFound("Check not found");
            }

            if (posCheck.check_revert_status) {

                return NotFound("Check already reverted");

            }

            posCheck.check_revert_status = true;

            posCheck.paymentsList = await _context.PosPayments
                    .Include(p => p.product)
                    .Where(p => p.PosCheckid == check_id).OrderByDescending(p => p.id).ToListAsync();

            foreach (PosPayments item in posCheck.paymentsList)
            {
                PosInvoiceItem inv_item = await _context.PosInvoiceItem.FindAsync(item.PosInvoiceItemid);
                inv_item.real_qty = inv_item.real_qty + item.qty;
                inv_item.qty_in_pack = inv_item.qty_in_pack + item.qty_in_pack;
                _context.PosInvoiceItem.Update(inv_item);
                await _context.SaveChangesAsync();

                item.check_revert_status = true;
                var priceList = await _context.PosProductPrice.Where(p => p.product_id == item.product_id).ToListAsync();
                if (priceList == null || priceList.Count == 0)
                {
                    PosProductPrice posProduct = new PosProductPrice();
                    posProduct.active_status = true;
                    posProduct.buyed_price = item.product.buyed_price;
                    posProduct.price = item.product.price;
                    posProduct.percantage = item.product.percentage;
                    posProduct.qty = item.qty;
                    posProduct.real_qty = item.qty;
                    posProduct.product_id = item.product.id;
                    _context.PosProductPrice.Update(posProduct);
                    await _context.SaveChangesAsync();
                }
                else {
                    PosProductPrice posProduct = priceList.First();
                    posProduct.qty = posProduct.qty + item.qty;
                    posProduct.real_qty = posProduct.real_qty+ item.qty;
                    _context.PosProductPrice.Update(posProduct);
                    await _context.SaveChangesAsync();
                }
            }

            _context.PosCheck.Update(posCheck);
            await _context.SaveChangesAsync();

            _context.PosPayments.UpdateRange(posCheck.paymentsList);
            await _context.SaveChangesAsync();


            return posCheck;
        }



        // PUT: api/PosChecks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosCheck(long id, PosCheck posCheck)
        {
            if (id != posCheck.id)
            {
                return BadRequest();
            }

            _context.Entry(posCheck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosCheckExists(id))
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

        // POST: api/PosChecks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosCheck>> PostPosCheck(PosCheck posCheck)
        {

            try
            {
                _context.PosCheck.Update(posCheck);
                await _context.SaveChangesAsync();


                //tovarlarni sklatdan orqaga qaytarish yani ayrish kerak minusgayam sotsa boladi
                List<PosPayments> posPayments = posCheck.paymentsList;
                foreach (PosPayments item in posPayments) {

                    PosInvoiceItem inv_item = await _context.PosInvoiceItem.FindAsync(item.PosInvoiceItemid);

                    inv_item.real_qty = Math.Round(inv_item.real_qty - item.qty,4);
                    inv_item.qty_in_pack = Math.Round(inv_item.qty_in_pack - item.qty_in_pack,4);

                    _context.PosInvoiceItem.Update(inv_item);
                    await _context.SaveChangesAsync();

                    List<PosProductPrice> productPrice = await _context.PosProductPrice.Include(p => p.product).Where(p => p.product_id == item.product_id).ToListAsync();
                    if (productPrice == null || productPrice.Count == 0) {

                        PosProductPrice price = new PosProductPrice();
                        price.active_status = true;
                        price.qty = -1 * item.qty;
                        price.real_qty = -1 * item.qty;
                        price.qty_in_pack = -1 * item.qty_in_pack;
                        price.percantage = item.product.percentage;
                        price.buyed_price = item.product.buyed_price;
                        price.price = item.product.price;
                        price.product_id = item.product.id;

                        _context.PosProductPrice.Update(price);
                        await _context.SaveChangesAsync();

                    }
                    else {
                        PosProductPrice posProduct = productPrice.First();
                        posProduct.real_qty = Math.Round(posProduct.real_qty - item.qty,4);
                        posProduct.qty_in_pack = Math.Round(posProduct.qty_in_pack - item.qty_in_pack,4);

                        _context.PosProductPrice.Update(posProduct);
                        await _context.SaveChangesAsync();
                    }

                }

            }
            catch (DbUpdateException e)
            {
                return NotFound(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFound(e?.InnerException?.Message);
            }

            return posCheck;
        }

        // DELETE: api/PosChecks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosCheck>> DeletePosCheck(long id)
        {
            var posCheck = await _context.PosCheck.FindAsync(id);
            if (posCheck == null)
            {
                return NotFound();
            }

            _context.PosCheck.Remove(posCheck);
            await _context.SaveChangesAsync();

            return posCheck;
        }

        private bool PosCheckExists(long id)
        {
            return _context.PosCheck.Any(e => e.id == id);
        }
    }
}
