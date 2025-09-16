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
    public class PosRevertController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosRevertController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosRevert
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosRevert>>> GetPosRevert()
        {
            return await _context.PosRevert.ToListAsync();
        }


        [HttpGet("getPaginationSpisatQilinganTovarovList")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationSpisatQilinganTovarovList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosRevert> itemList = await _context.PosRevert
                .Where(p => p.active_status == true && p.revert_status == 1)
                .Include(p => p.postavshik)
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosRevert>();
            }

            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosRevert
                .Where(p => p.active_status == true && p.revert_status == 1).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        [HttpGet("getPaginationSpisatQilinganTovarovListForReport")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationSpisatQilinganTovarovListForReport([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime begin_date, [FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosRevert> itemList = await _context.PosRevert
                .Where(p => p.active_status == true && p.revert_status == 1 && (p.reg_date >= begin_date && p.reg_date <= end_date))
                .Include(p => p.postavshik)
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosRevert>();
            }

            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosRevert
                .Where(p => p.active_status == true && p.revert_status == 1 && (p.reg_date >= begin_date && p.reg_date <= end_date)).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationKontragentgaQaytarilganTovarovListForReport")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationKontragentgaQaytarilganTovarovListForReport([FromQuery] int page, [FromQuery] int size,[FromQuery] DateTime begin_date,[FromQuery] DateTime end_date,[FromQuery] long postavshik_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosRevert> itemList = new List<PosRevert>();
            if (postavshik_id == 0) {
                itemList = await _context.PosRevert
                   .Where(p => p.active_status == true && p.revert_status == 2 && (p.reg_date >= begin_date && p.reg_date <= end_date))
                   .Include(p => p.postavshik)
                   .OrderByDescending(p => p.id)
                   .Skip(size * page).Take(size)
                   .ToListAsync();
            }
            else {
                itemList = await _context.PosRevert
                  .Where(p => p.active_status == true && p.revert_status == 2 && (p.reg_date >= begin_date && p.reg_date <= end_date) && p.postavshik_id == postavshik_id)
                  .Include(p => p.postavshik)
                  .OrderByDescending(p => p.id)
                  .Skip(size * page).Take(size)
                  .ToListAsync();
            }

            if (itemList == null)
            {
                itemList = new List<PosRevert>();
            }

            paginationModel.items_list = JArray.FromObject(itemList);
            if (postavshik_id == 0) {
                paginationModel.items_count = await _context.PosRevert
                    .Where(p => p.active_status == true && p.revert_status == 2 && (p.reg_date >= begin_date && p.reg_date <= end_date)).CountAsync();
            }
            else {
                paginationModel.items_count = await _context.PosRevert
                    .Where(p => p.active_status == true && p.revert_status == 2 && (p.reg_date >= begin_date && p.reg_date <= end_date) && p.postavshik_id == postavshik_id).CountAsync();
            }

            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationKontragentgaQaytarilganTovarovList")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationKontragentgaQaytarilganTovarovList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosRevert> itemList = await _context.PosRevert
                .Where(p => p.active_status == true && p.revert_status == 2)
                .Include(p => p.postavshik)
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosRevert>();
            }

            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosRevert
                .Where(p => p.active_status == true && p.revert_status == 2).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationKlientdanQaytaribOlinganTovarovList")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationKlientdanQaytaribOlinganTovarovList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosRevert> itemList = await _context.PosRevert
                .Where(p => p.active_status == true && p.revert_status == 3)
                .Include(p => p.postavshik)
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosRevert>();
            }

            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosRevert
                .Where(p => p.active_status == true && p.revert_status == 3).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationKlientdanQaytaribOlinganTovarovListForReport")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationKlientdanQaytaribOlinganTovarovListForReport([FromQuery] int page, [FromQuery] int size,[FromQuery] DateTime begin_date,[FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosRevert> itemList = await _context.PosRevert
                .Where(p => p.active_status == true && p.revert_status == 3 && (p.reg_date >= begin_date && p.reg_date <=end_date))
                .Include(p => p.postavshik)
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosRevert>();
            }

            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosRevert
                .Where(p => p.active_status == true && p.revert_status == 3 && (p.reg_date >= begin_date && p.reg_date <= end_date)).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/PosRevert/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosRevert>> GetPosRevert(long id)
        {
            var posRevert = await _context.PosRevert.FindAsync(id);

            if (posRevert == null)
            {
                return NotFound();
            }

            return posRevert;
        }


        /// <param name="reverted_status_code"> Списания товары 1;  Возврат товары  2; Возврат от пакупатели  3;</param>
        [HttpGet("applyOrDisableRevertedProductsByStatusAndId")]
        public async Task<ActionResult<PosRevert>> applyOrDisableRevertedProductsByStatusAndId([FromQuery]long revert_inv_id, [FromQuery] bool applayment_status,[FromQuery] long pos_auth_id)
        {
            int reverted_status_code = 0;
            var posRevertList = await _context.PosRevert.Include(p => p.items_list).ThenInclude(p => p.product).Where(p => p.id==revert_inv_id).ToListAsync();

            if (posRevertList == null || posRevertList.Count == 0)
            {
                return NotFound("Reverted products not found ");
            }
            List<PosRevertItem> itemsList = posRevertList.First().items_list;
            if (itemsList == null || itemsList.Count == 0)
            {

                return NotFound("Items not found");
            }

            reverted_status_code = posRevertList.First().revert_status;

            try
            {
                if (applayment_status)
                {
                    if (posRevertList.First().applayment_status == true) {
                        return NotFound("Уже подтверждено");
                    }


                    //need to apply
                    //bu statsus tovarlardi sisaniya qilish uchun kerak 
                    //Списания товары 1;
                    if (reverted_status_code == 1)
                    {
                        //tovarlar sotib olgan narxida spisaniya qilinadi skladdan udalit qilib tashlanadi lekin bazada qoladi istoriyasi
                        //xamamsini bitta bitta orqaga qaytarish kerak
                        foreach (PosRevertItem itm in posRevertList.First().items_list)
                        {

                            //pakupkaga orqaga qaytarilib qoyildi sotib olgan narsalardi 
                            PosInvoiceItem rev_inv = await _context.PosInvoiceItem.FindAsync(itm.PosInvoiceItemid);
                            rev_inv.real_qty = rev_inv.real_qty - itm.qty;
                            rev_inv.qty_in_pack = rev_inv.qty_in_pack - itm.qty_in_pack;
                            _context.PosInvoiceItem.Update(rev_inv);
                            await _context.SaveChangesAsync();

                            //realcountlardiyam orqaga qaytarildi
                            List<PosProductPrice> productPriceList = await _context.PosProductPrice.Where(p => p.product_id == itm.product_id).ToListAsync();
                            if (productPriceList != null && productPriceList.Count > 0)
                            {
                                PosProductPrice product_price_itm = productPriceList.First();
                                product_price_itm.real_qty = product_price_itm.real_qty - itm.qty;
                                product_price_itm.qty_in_pack = product_price_itm.qty_in_pack - itm.qty_in_pack;
                                _context.PosProductPrice.Update(product_price_itm);
                                await _context.SaveChangesAsync();
                            }

                        }
                        //appled statsuini orqaga qaytarib qoyildi
                        PosRevert posRevert = posRevertList.First();
                        posRevert.applayment_status = true;
                        _context.PosRevert.Update(posRevert);
                        await _context.SaveChangesAsync();

                    }
                    //Возврат товары  2;
                    else if (reverted_status_code == 2)
                    {
                        //tovarlardi postavshikka qaytarish uchun kerak faqat ozidan sotib olgandagina qaytara oladi bolmasa yoq
                        //xamamsini bitta bitta orqaga qaytarish kerak
                        foreach (PosRevertItem itm in posRevertList.First().items_list)
                        {

                            //pakupkaga orqaga qaytarilib qoyildi sotib olgan narsalardi 
                            PosInvoiceItem rev_inv = await _context.PosInvoiceItem.FindAsync(itm.PosInvoiceItemid);
                            rev_inv.real_qty = rev_inv.real_qty - itm.qty;
                            rev_inv.qty_in_pack = rev_inv.qty_in_pack - itm.qty_in_pack;
                            _context.PosInvoiceItem.Update(rev_inv);
                            await _context.SaveChangesAsync();

                            //realcountlardiyam orqaga qaytarildi
                            List<PosProductPrice> productPriceList = await _context.PosProductPrice.Where(p => p.product_id == itm.product_id).ToListAsync();
                            if (productPriceList != null && productPriceList.Count > 0)
                            {
                                PosProductPrice product_price_itm = productPriceList.First();
                                product_price_itm.real_qty = product_price_itm.real_qty - itm.qty;
                                product_price_itm.qty_in_pack = product_price_itm.qty_in_pack - itm.qty_in_pack;
                                _context.PosProductPrice.Update(product_price_itm);
                                await _context.SaveChangesAsync();
                            }

                        }
                        //appled statsuini orqaga qaytarib qoyildi
                        PosRevert posRevert = posRevertList.First();
                        posRevert.applayment_status = true;
                        _context.PosRevert.Update(posRevert);
                        await _context.SaveChangesAsync();


                    }
                    // Возврат от пакупатели  3
                    else if (reverted_status_code == 3)
                    {
                        if (pos_auth_id == 0) {
                            return NotFound("Пожалуйста, перед входом в систему для использования этой функции");
                        }
                        //faqat 1 xaftalik tovarlardi qaytarish mumkin unda ortigini umuman qaytara olmedi
                        // kassadan puli minus bolib qoladi

                        //rasxodlardi yozib qoyadi qaytargan userdi idsini
                        PosCosts posCosts = new PosCosts();
                        posCosts.active_status = true;
                        posCosts.real_company_id = 0;
                        posCosts.summ = posRevertList.First().summ;
                        posCosts.note = "Возврат от пакупатели";
                        posCosts.PosAuthorizationid = pos_auth_id;
                        _context.PosCosts.Update(posCosts);
                        await _context.SaveChangesAsync();

                        //xamamsini bitta bitta orqaga qaytarish kerak
                        foreach (PosRevertItem itm in posRevertList.First().items_list) {

                            //pakupkaga orqaga qaytarilib qoyildi sotib olgan narsalardi 
                            PosInvoiceItem rev_inv = await _context.PosInvoiceItem.FindAsync(itm.PosInvoiceItemid);
                            rev_inv.real_qty = rev_inv.real_qty + itm.qty;
                            rev_inv.qty_in_pack = rev_inv.qty_in_pack + itm.qty_in_pack;
                            _context.PosInvoiceItem.Update(rev_inv);
                            await _context.SaveChangesAsync();

                            //realcountlardiyam orqaga qaytarildi
                            List<PosProductPrice> productPriceList = await _context.PosProductPrice.Where(p => p.product_id == itm.product_id).ToListAsync();
                            if (productPriceList != null && productPriceList.Count > 0) {
                                PosProductPrice product_price_itm = productPriceList.First();
                                product_price_itm.real_qty = product_price_itm.real_qty + itm.qty;
                                product_price_itm.qty_in_pack = product_price_itm.qty_in_pack + itm.qty_in_pack;
                                _context.PosProductPrice.Update(product_price_itm);
                                await _context.SaveChangesAsync();
                            }

                        }
                        //appled statsuini orqaga qaytarib qoyildi
                        PosRevert posRevert = posRevertList.First();
                        posRevert.applayment_status = true;
                        _context.PosRevert.Update(posRevert);
                        await _context.SaveChangesAsync();


                    }
                    else {

                        return NotFound("Пожалуйста, прочтите документацию, вы отправляете неверный статус");

                    }




                }
                else {
                    if (posRevertList.First().applayment_status == false)
                    {
                        return NotFound("Уже отменено");
                    }

                    //Списания товары 1;
                    if (reverted_status_code == 1)
                    {
                        //tovarlar sotib olgan narxida spisaniya qilinadi skladdan udalit qilib tashlanadi lekin bazada qoladi istoriyasi
                        
                        foreach (PosRevertItem itm in posRevertList.First().items_list)
                        {

                            //pakupkaga orqaga qaytarilib qoyildi sotib olgan narsalardi 
                            PosInvoiceItem rev_inv = await _context.PosInvoiceItem.FindAsync(itm.PosInvoiceItemid);
                            rev_inv.real_qty = rev_inv.real_qty + itm.qty;
                            rev_inv.qty_in_pack = rev_inv.qty_in_pack + itm.qty_in_pack;
                            _context.PosInvoiceItem.Update(rev_inv);
                            await _context.SaveChangesAsync();

                            //realcountlardiyam orqaga qaytarildi
                            List<PosProductPrice> productPriceList = await _context.PosProductPrice.Where(p => p.product_id == itm.product_id).ToListAsync();
                            if (productPriceList != null && productPriceList.Count > 0)
                            {
                                PosProductPrice product_price_itm = productPriceList.First();
                                product_price_itm.real_qty = product_price_itm.real_qty + itm.qty;
                                product_price_itm.qty_in_pack = product_price_itm.qty_in_pack + itm.qty_in_pack;
                                _context.PosProductPrice.Update(product_price_itm);
                                await _context.SaveChangesAsync();
                            }

                        }
                        //appled statsuini orqaga qaytarib qoyildi
                        PosRevert posRevert = posRevertList.First();
                        posRevert.applayment_status = false;
                        _context.PosRevert.Update(posRevert);
                        await _context.SaveChangesAsync();

                    }
                    //Возврат товары  2;
                    else if (reverted_status_code == 2)
                    {
                        //tovarlardi postavshikka qaytarish uchun kerak faqat ozidan sotib olgandagina qaytara oladi bolmasa yoq
                        //xamamsini bitta bitta orqaga qaytarish kerak
                        foreach (PosRevertItem itm in posRevertList.First().items_list)
                        {

                            //pakupkaga orqaga qaytarilib qoyildi sotib olgan narsalardi 
                            PosInvoiceItem rev_inv = await _context.PosInvoiceItem.FindAsync(itm.PosInvoiceItemid);
                            rev_inv.real_qty = rev_inv.real_qty + itm.qty;
                            rev_inv.qty_in_pack = rev_inv.qty_in_pack + itm.qty_in_pack;
                            _context.PosInvoiceItem.Update(rev_inv);
                            await _context.SaveChangesAsync();

                            //realcountlardiyam orqaga qaytarildi
                            List<PosProductPrice> productPriceList = await _context.PosProductPrice.Where(p => p.product_id == itm.product_id).ToListAsync();
                            if (productPriceList != null && productPriceList.Count > 0)
                            {
                                PosProductPrice product_price_itm = productPriceList.First();
                                product_price_itm.real_qty = product_price_itm.real_qty + itm.qty;
                                product_price_itm.qty_in_pack = product_price_itm.qty_in_pack + itm.qty_in_pack;
                                _context.PosProductPrice.Update(product_price_itm);
                                await _context.SaveChangesAsync();
                            }

                        }
                        //appled statsuini orqaga qaytarib qoyildi
                        PosRevert posRevert = posRevertList.First();
                        posRevert.applayment_status = false;
                        _context.PosRevert.Update(posRevert);
                        await _context.SaveChangesAsync();


                    }
                    // Возврат от пакупатели  3
                    else if (reverted_status_code == 3)
                    {
                        //sotib olingandan keyin orqaga qaytargandan keyin yana kilentga berib bolmeydi endi pixod qilish kerak sklada qoshish uchun
                        return NotFound("После получения от клиента вы не можете изменить,вы должны добавить вручную");

                    }
                    else
                    {

                        return NotFound("Пожалуйста, прочтите документацию, вы отправляете неверный статус");

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

            return posRevertList.First();
        }

        // PUT: api/PosRevert/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosRevert(long id, PosRevert posRevert)
        {
            if (id != posRevert.id)
            {
                return BadRequest();
            }

            _context.Entry(posRevert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosRevertExists(id))
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

        // POST: api/PosRevert
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosRevert>> PostPosRevert(PosRevert posRevert)
        {
            try
            {
            if (posRevert.applayment_status == true) {
                return  NotFound("Already applyed");
            }


            _context.PosRevert.Update(posRevert);
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

            return posRevert;
        }

        // DELETE: api/PosRevert/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosRevert>> DeletePosRevert(long id)
        {
            var posRevert = await _context.PosRevert.FindAsync(id);
            if (posRevert == null)
            {
                return NotFound();
            }

            _context.PosRevert.Remove(posRevert);
            await _context.SaveChangesAsync();

            return posRevert;
        }

        private bool PosRevertExists(long id)
        {
            return _context.PosRevert.Any(e => e.id == id);
        }
    }
}
