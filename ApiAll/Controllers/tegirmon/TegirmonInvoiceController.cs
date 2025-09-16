using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tegirmon;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tegirmon
{
    [ApiExplorerSettings(GroupName = "v7")]
    [Route("api/[controller]")]
    [ApiController]
    public class TegirmonInvoiceController : ControllerBase
    {
        private readonly ApplicationContext _context;

        //INVOICE TURLARI
        private String INVOICE_BUGDOY_SOTISH_PULGA = "INVOICE_BUGDOY_SOTISH_PULGA";
        private String INVOICE_BUGDOY_CHIQARISH_TEGIRMONDAN_UN_QILISH = "INVOICE_BUGDOY_CHIQARISH_TEGIRMONDAN_UN_QILISH";
        private String INVOICE_BUGDOY_PRIXOD_QILISH = "INVOICE_BUGDOY_PRIXOD_QILISH";
        private String INVOICE_BUGDOY_RASXOD_BRAK_CHIQQANLAR = "INVOICE_BUGDOY_RASXOD_BRAK_CHIQQANLAR";
        private String INVOICE_BUGDOY_NARSALARGA_ALMASHTRISH = "INVOICE_BUGDOY_NARSALARGA_ALMASHTRISH";
        private String INVOICE_BUGDOY_ZAXIRADAN_NARSALARGA_ALMASHTRISH = "INVOICE_BUGDOY_ZAXIRADAN_NARSALARGA_ALMASHTRISH";
        private String INVOICE_BUGDOY_NARSALARGA_ALMASHTRISH_UCHUN_ZAXIRAGA_OLIB_QOLISH = "INVOICE_BUGDOY_NARSALARGA_ALMASHTRISH_UCHUN_ZAXIRAGA_OLIB_QOLISH";

        public TegirmonInvoiceController(ApplicationContext context)
        {
            _context = context;
        }


        /// <summary>
        /// BUGDOYNI PULGA ALMASHTRISH BOLDI 
        /// </summary>
        /// <param name="tegirmonInvoice"></param>
        /// <returns></returns>

        [HttpPost("postInvoiceBugdoyPulgaAlmashibQoyish")]
        public async Task<ActionResult<TegirmonInvoice>> postInvoiceBugdoyPulgaAlmashibQoyish(TegirmonInvoice tegirmonInvoice)
        {
            tegirmonInvoice.status_inv_type_name = INVOICE_BUGDOY_SOTISH_PULGA;
            if (tegirmonInvoice.TegirmonProductid != null) {
                List<TegirmonOstatka> ostatkaList = await _context.TegirmonOstatka
                    .Where(p => p.TegirmonProductid == tegirmonInvoice.TegirmonProductid)
                    .ToListAsync();
                if (ostatkaList != null && ostatkaList.Count > 0)
                {
                    ostatkaList.First().qty = ostatkaList.First().qty + tegirmonInvoice.qty_real;
                    ostatkaList.First().real_qty = ostatkaList.First().real_qty + tegirmonInvoice.qty_real;

                    _context.TegirmonOstatka.UpdateRange(ostatkaList);
                    await _context.SaveChangesAsync();
                }
                else {
                    TegirmonOstatka ostatka = new TegirmonOstatka();
                    ostatka.active_status = true;
                    ostatka.qty = tegirmonInvoice.qty_real;
                    ostatka.real_qty = tegirmonInvoice.qty_real;
                    ostatka.TegirmonProductid = tegirmonInvoice.TegirmonProductid ?? default(long);
                    _context.TegirmonOstatka.Update(ostatka);
                    await _context.SaveChangesAsync();
                }
            }

            tegirmonInvoice.inv_accepted_status = true;
            _context.TegirmonInvoice.Update(tegirmonInvoice);
            await _context.SaveChangesAsync();

            return tegirmonInvoice;
        }

        [HttpPost("addChangeBugdoyToMoney")]
        public async Task<ActionResult<TegirmonInvoice>> addChangeBugdoyToMoney(TegirmonInvoice tegirmonInvoice)
        {
            tegirmonInvoice.status_inv_type_name = INVOICE_BUGDOY_SOTISH_PULGA;
            _context.TegirmonInvoice.Update(tegirmonInvoice);
            await _context.SaveChangesAsync();

            return tegirmonInvoice;
        }

        [HttpGet("acceptChangeBugdoyToMoney")]
        public async Task<ActionResult<TegirmonInvoice>> acceptChangeBugdoyToMoney([FromQuery]long id)
        {
            var tegirmonInvoice = await _context.TegirmonInvoice
               .Include(p => p.item_list)
               .Where(p => p.id == id).ToListAsync();

            if (tegirmonInvoice == null || tegirmonInvoice.Count == 0)
            {
                return NotFound();
            }
            await postInvoiceBugdoyPulgaAlmashibQoyish(tegirmonInvoice.First());

            return tegirmonInvoice.First();
        }





        /// <summary>
        /// Zahiraga olib qoyish klientni bugdoyini
        /// </summary>
        /// <param name="tegirmonInvoice"></param>
        /// <returns></returns>

        [HttpPost("postInvoiceBugdoyniZaxiragaOlibQolishClientdan")]
        public async Task<ActionResult<TegirmonInvoice>> postInvoiceBugdoyniZaxiragaOlibQolishClientdan(TegirmonInvoice tegirmonInvoice)
        {
            tegirmonInvoice.status_inv_type_name = INVOICE_BUGDOY_NARSALARGA_ALMASHTRISH_UCHUN_ZAXIRAGA_OLIB_QOLISH;
            if (tegirmonInvoice.TegirmonClientid == null || tegirmonInvoice.TegirmonProductid == null) {

                return NotFound("Client or product not selected");
            }

            
            if (tegirmonInvoice.TegirmonProductid != null)
            {
                List<TegirmonOstatka> ostatkaList = await _context.TegirmonOstatka
                    .Where(p => p.TegirmonProductid == tegirmonInvoice.TegirmonProductid)
                    .ToListAsync();
                if (ostatkaList != null && ostatkaList.Count > 0)
                {
                    ostatkaList.First().qty = ostatkaList.First().qty + tegirmonInvoice.qty_real;
                    ostatkaList.First().real_qty = ostatkaList.First().real_qty + tegirmonInvoice.qty_real;

                    _context.TegirmonOstatka.UpdateRange(ostatkaList);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    TegirmonOstatka ostatka = new TegirmonOstatka();
                    ostatka.active_status = true;
                    ostatka.qty = tegirmonInvoice.qty_real;
                    ostatka.real_qty = tegirmonInvoice.qty_real;
                    ostatka.TegirmonProductid = tegirmonInvoice.TegirmonProductid ?? default(long);
                    _context.TegirmonOstatka.Update(ostatka);
                    await _context.SaveChangesAsync();
                }

                List<TegirmonClientOstatka> ostatkaClientList = await _context.TegirmonClientOstatka
                    .Where(p =>p.TegirmonClientid == tegirmonInvoice.TegirmonClientid
                    && p.TegirmonProductid == tegirmonInvoice.TegirmonProductid).ToListAsync();

                if (ostatkaClientList != null && ostatkaClientList.Count > 0) {
                    ostatkaClientList.First().real_qty = ostatkaClientList.First().real_qty + tegirmonInvoice.qty_real;
                    ostatkaClientList.First().qty = ostatkaClientList.First().qty + tegirmonInvoice.qty_real;
                    _context.TegirmonClientOstatka.UpdateRange(ostatkaClientList);
                    await _context.SaveChangesAsync();
                }
                else {

                    TegirmonClientOstatka clientOstatka = new TegirmonClientOstatka();
                    clientOstatka.active_status = true;
                    clientOstatka.qty = tegirmonInvoice.qty_real;
                    clientOstatka.real_qty = tegirmonInvoice.qty_real;
                    clientOstatka.TegirmonProductid = tegirmonInvoice.TegirmonProductid ?? default(long);
                    clientOstatka.TegirmonClientid = tegirmonInvoice.TegirmonClientid ?? default(long);
                    _context.TegirmonClientOstatka.Update(clientOstatka);
                    await _context.SaveChangesAsync();

                }


            }

            tegirmonInvoice.inv_accepted_status = true;
            _context.TegirmonInvoice.Update(tegirmonInvoice);
            await _context.SaveChangesAsync();

            return tegirmonInvoice;
        }
        [HttpPost("addBugdoyToClientForZaxira")]
        public async Task<ActionResult<TegirmonInvoice>> addBugdoyToClientForZaxira(TegirmonInvoice tegirmonInvoice)
        {
            tegirmonInvoice.status_inv_type_name = INVOICE_BUGDOY_NARSALARGA_ALMASHTRISH_UCHUN_ZAXIRAGA_OLIB_QOLISH;
            _context.TegirmonInvoice.Update(tegirmonInvoice);
            await _context.SaveChangesAsync();

            return tegirmonInvoice;
        }
        [HttpGet("acceptBugdoyToClientForZaxira")]
        public async Task<ActionResult<TegirmonInvoice>> acceptBugdoyToClientForZaxira([FromQuery] long id)
        {
            var tegirmonInvoice = await _context.TegirmonInvoice
                 .Include(p => p.item_list)
                 .Where(p => p.id == id).ToListAsync();

            if (tegirmonInvoice == null || tegirmonInvoice.Count == 0)
            {
                return NotFound();
            }
            await postInvoiceBugdoyniZaxiragaOlibQolishClientdan(tegirmonInvoice.First());

            return tegirmonInvoice.First();
        }



        /// <summary>
        /// Bunda bugdoyni klintni registratsiya qilmasdan almasnhtrib yuborish uchun keak api
        /// </summary>
        /// <param name="tegirmonInvoice"></param>
        /// <returns></returns>

        [HttpPost("deAcceptpostInvoiceBugdoyniClientniRegistratsiyaQilmasdanNarsalargaAlmashtribYuborish")]
        public async Task<ActionResult<TegirmonInvoice>> deAcceptpostInvoiceBugdoyniClientniRegistratsiyaQilmasdanNarsalargaAlmashtribYuborish(TegirmonInvoice tegirmonInvoice)
        {

            if (tegirmonInvoice.inv_accepted_status != true) {
                return NotFound("Accept qilinmagan invoice ");
            }

            tegirmonInvoice.status_inv_type_name = INVOICE_BUGDOY_NARSALARGA_ALMASHTRISH;
            if (tegirmonInvoice.TegirmonProductid != null)
            {
                List<TegirmonOstatka> ostatkaList = await _context.TegirmonOstatka
                    .Where(p => p.TegirmonProductid == tegirmonInvoice.TegirmonProductid)
                    .ToListAsync();
                if (ostatkaList != null && ostatkaList.Count > 0)
                {
                    ostatkaList.First().qty = ostatkaList.First().qty - tegirmonInvoice.qty_real;
                    ostatkaList.First().real_qty = ostatkaList.First().real_qty - tegirmonInvoice.qty_real;

                    _context.TegirmonOstatka.UpdateRange(ostatkaList);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    TegirmonOstatka ostatka = new TegirmonOstatka();
                    ostatka.active_status = true;
                    ostatka.qty = -1 * tegirmonInvoice.qty_real;
                    ostatka.real_qty = -1 * tegirmonInvoice.qty_real;
                    ostatka.TegirmonProductid = tegirmonInvoice.TegirmonProductid ?? default(long);

                    _context.TegirmonOstatka.Update(ostatka);
                    await _context.SaveChangesAsync();
                }
            }

            //nima sotib olsa oshani ostatkadan ayrib qoyadi
            if (tegirmonInvoice.item_list != null && tegirmonInvoice.item_list.Count > 0)
            {
                foreach (TegirmonInvoiceItem item in tegirmonInvoice.item_list)
                {
                    List<TegirmonOstatka> ostatkaList = await _context.TegirmonOstatka
                   .Where(p => p.TegirmonProductid == item.TegirmonProductid)
                   .ToListAsync();
                    if (ostatkaList != null && ostatkaList.Count > 0)
                    {
                        ostatkaList.First().qty = ostatkaList.First().qty + item.qty;
                        ostatkaList.First().real_qty = ostatkaList.First().real_qty + item.qty;

                        _context.TegirmonOstatka.UpdateRange(ostatkaList);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        TegirmonOstatka ostatka = new TegirmonOstatka();
                        ostatka.active_status = true;
                        ostatka.qty =  item.qty;
                        ostatka.real_qty =  item.qty;
                        ostatka.TegirmonProductid = item.TegirmonProductid;

                        _context.TegirmonOstatka.Update(ostatka);
                        await _context.SaveChangesAsync();
                    }

                }

            }

            tegirmonInvoice.inv_accepted_status = false;
            _context.TegirmonInvoice.Update(tegirmonInvoice);
            await _context.SaveChangesAsync();

            return tegirmonInvoice;
        }


        [HttpPost("deleteNoTestedAcceptpostInvoiceBugdoyniClientniRegistratsiyaQilmasdanNarsalargaAlmashtribYuborish")]
        public async Task<ActionResult<TegirmonInvoice>> deleteNoTestedAcceptpostInvoiceBugdoyniClientniRegistratsiyaQilmasdanNarsalargaAlmashtribYuborish(TegirmonInvoice tegirmonInvoice)
        {

            if (tegirmonInvoice.inv_accepted_status != true)
            {
                return NotFound("Accept qilinmagan invoice ");
            }

            tegirmonInvoice.status_inv_type_name = INVOICE_BUGDOY_NARSALARGA_ALMASHTRISH;
            if (tegirmonInvoice.TegirmonProductid != null)
            {
                List<TegirmonOstatka> ostatkaList = await _context.TegirmonOstatka
                    .Where(p => p.TegirmonProductid == tegirmonInvoice.TegirmonProductid)
                    .ToListAsync();
                if (ostatkaList != null && ostatkaList.Count > 0)
                {
                    ostatkaList.First().qty = ostatkaList.First().qty - tegirmonInvoice.qty_real;
                    ostatkaList.First().real_qty = ostatkaList.First().real_qty - tegirmonInvoice.qty_real;

                    _context.TegirmonOstatka.UpdateRange(ostatkaList);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    TegirmonOstatka ostatka = new TegirmonOstatka();
                    ostatka.active_status = true;
                    ostatka.qty = -1 * tegirmonInvoice.qty_real;
                    ostatka.real_qty = -1 * tegirmonInvoice.qty_real;
                    ostatka.TegirmonProductid = tegirmonInvoice.TegirmonProductid ?? default(long);

                    _context.TegirmonOstatka.Update(ostatka);
                    await _context.SaveChangesAsync();
                }
            }

            //nima sotib olsa oshani ostatkadan ayrib qoyadi
            if (tegirmonInvoice.item_list != null && tegirmonInvoice.item_list.Count > 0)
            {
                foreach (TegirmonInvoiceItem item in tegirmonInvoice.item_list)
                {
                    List<TegirmonOstatka> ostatkaList = await _context.TegirmonOstatka
                   .Where(p => p.TegirmonProductid == item.TegirmonProductid)
                   .ToListAsync();
                    if (ostatkaList != null && ostatkaList.Count > 0)
                    {
                        ostatkaList.First().qty = ostatkaList.First().qty + item.qty;
                        ostatkaList.First().real_qty = ostatkaList.First().real_qty + item.qty;

                        _context.TegirmonOstatka.UpdateRange(ostatkaList);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        TegirmonOstatka ostatka = new TegirmonOstatka();
                        ostatka.active_status = true;
                        ostatka.qty = item.qty;
                        ostatka.real_qty = item.qty;
                        ostatka.TegirmonProductid = item.TegirmonProductid;

                        _context.TegirmonOstatka.Update(ostatka);
                        await _context.SaveChangesAsync();
                    }

                }

            }

            tegirmonInvoice.inv_accepted_status = false;
            _context.TegirmonInvoice.Update(tegirmonInvoice);
            await _context.SaveChangesAsync();

            return tegirmonInvoice;
        }




        /// <summary>
        /// Bunda bugdoyni klintni registratsiya qilmasdan almasnhtrib yuborish uchun keak api
        /// </summary>
        /// <param name="tegirmonInvoice"></param>
        /// <returns></returns>

        [HttpPost("postInvoiceBugdoyniClientniRegistratsiyaQilmasdanNarsalargaAlmashtribYuborish")]
        public async Task<ActionResult<TegirmonInvoice>> postInvoiceBugdoyniClientniRegistratsiyaQilmasdanNarsalargaAlmashtribYuborish(TegirmonInvoice tegirmonInvoice)
        {
            tegirmonInvoice.status_inv_type_name = INVOICE_BUGDOY_NARSALARGA_ALMASHTRISH;
            if (tegirmonInvoice.TegirmonProductid != null)
            {
                List<TegirmonOstatka> ostatkaList = await _context.TegirmonOstatka
                    .Where(p => p.TegirmonProductid == tegirmonInvoice.TegirmonProductid)
                    .ToListAsync();
                if (ostatkaList != null && ostatkaList.Count > 0)
                {
                    ostatkaList.First().qty = ostatkaList.First().qty + tegirmonInvoice.qty_real;
                    ostatkaList.First().real_qty = ostatkaList.First().real_qty + tegirmonInvoice.qty_real;

                    _context.TegirmonOstatka.UpdateRange(ostatkaList);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    TegirmonOstatka ostatka = new TegirmonOstatka();
                    ostatka.active_status = true;
                    ostatka.qty =  tegirmonInvoice.qty_real;
                    ostatka.real_qty =  tegirmonInvoice.qty_real;
                    ostatka.TegirmonProductid = tegirmonInvoice.TegirmonProductid ?? default(long);

                    _context.TegirmonOstatka.Update(ostatka);
                    await _context.SaveChangesAsync();
                }
            }

            //nima sotib olsa oshani ostatkadan ayrib qoyadi
            if (tegirmonInvoice.item_list != null && tegirmonInvoice.item_list.Count > 0)
            {
                foreach (TegirmonInvoiceItem item in tegirmonInvoice.item_list)
                {
                    List<TegirmonOstatka> ostatkaList = await _context.TegirmonOstatka
                   .Where(p => p.TegirmonProductid == item.TegirmonProductid)
                   .ToListAsync();
                    if (ostatkaList != null && ostatkaList.Count > 0)
                    {
                        ostatkaList.First().qty = ostatkaList.First().qty - item.qty;
                        ostatkaList.First().real_qty = ostatkaList.First().real_qty - item.qty;

                        _context.TegirmonOstatka.UpdateRange(ostatkaList);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        TegirmonOstatka ostatka = new TegirmonOstatka();
                        ostatka.active_status = true;
                        ostatka.qty = -1 * item.qty;
                        ostatka.real_qty = -1 * item.qty;
                        ostatka.TegirmonProductid = item.TegirmonProductid;

                        _context.TegirmonOstatka.Update(ostatka);
                        await _context.SaveChangesAsync();
                    }

                }

            }

            tegirmonInvoice.inv_accepted_status = true;
            _context.TegirmonInvoice.Update(tegirmonInvoice);
            await _context.SaveChangesAsync();

            return tegirmonInvoice;
        }
        [HttpPost("addChangeBugdoyProductsWithoutRegistartion")]
        public async Task<ActionResult<TegirmonInvoice>> addChangeBugdoyProductsWithoutRegistartion(TegirmonInvoice tegirmonInvoice)
        {
            tegirmonInvoice.status_inv_type_name = INVOICE_BUGDOY_NARSALARGA_ALMASHTRISH;
            _context.TegirmonInvoice.Update(tegirmonInvoice);
            await _context.SaveChangesAsync();

            return tegirmonInvoice;
        }
        [HttpGet("acceptChangeBugdoyProductsWithoutRegistartion")]
        public async Task<ActionResult<TegirmonInvoice>> acceptChangeBugdoyProductsWithoutRegistartion([FromQuery] long id)
        {
            var tegirmonInvoice = await _context.TegirmonInvoice
             .Include(p => p.item_list)
             .Where(p => p.id == id).ToListAsync();

            if (tegirmonInvoice == null || tegirmonInvoice.Count == 0)
            {
                return NotFound();
            }
            await postInvoiceBugdoyniClientniRegistratsiyaQilmasdanNarsalargaAlmashtribYuborish(tegirmonInvoice.First());

            return tegirmonInvoice.First();
        }

        [HttpGet("acceptTegirmonTortilganBugdoyRoyxatiGroupFromInvoice")]
        public async Task<ActionResult<TegirmonTortilganBugdoyRoyxatiGroup>> acceptTegirmonTortilganBugdoyRoyxatiGroupFromInvoice([FromQuery] long id)
        {
            var tegirmonTortilganBugdoyRoyxatiGroup = await _context.TegirmonTortilganBugdoyRoyxatiGroup.FindAsync(id);

            if (tegirmonTortilganBugdoyRoyxatiGroup == null)
            {
                return NotFound();
            }

            tegirmonTortilganBugdoyRoyxatiGroup.accepted_status = true;

            List<TegirmonTortilganBugdoyRoyxatiGroupDetail> detail_list = await _context.TegirmonTortilganBugdoyRoyxatiGroupDetail
                .Include(p => p.royxati)
                .Include(p => p.invoice)
                .Where(p => p.TegirmonTortilganBugdoyRoyxatiGroupid == id)
                .ToListAsync();


            //details for accepted and invoice
            if (detail_list != null && detail_list.Count > 0)
            {

                foreach (TegirmonTortilganBugdoyRoyxatiGroupDetail item in detail_list)
                {
                    item.royxati.accepted_get_value = true;
                    await acceptChangeBugdoyProductsWithoutRegistartion(item.TegirmonInvoiceid);
                }

                //update
                _context.TegirmonTortilganBugdoyRoyxatiGroupDetail.UpdateRange(detail_list);
                await _context.SaveChangesAsync();

            }

            //update
            _context.TegirmonTortilganBugdoyRoyxatiGroup.Update(tegirmonTortilganBugdoyRoyxatiGroup);
            await _context.SaveChangesAsync();

            return tegirmonTortilganBugdoyRoyxatiGroup;
        }







        /// <summary>
        /// Bu zaxiraga olgandan keyin osha ostatkadan narsaga almashtrish uchun kerak boladi
        /// </summary>
        /// <param name="tegirmonInvoice"></param>
        /// <returns></returns>
        [HttpPost("postInvoiceBugdoyniZaxiradanNarsalargaAlmashtrish")]
        public async Task<ActionResult<TegirmonInvoice>> postInvoiceBugdoyniZaxiradanNarsalargaAlmashtrish(TegirmonInvoice tegirmonInvoice)
        {
            tegirmonInvoice.status_inv_type_name = INVOICE_BUGDOY_ZAXIRADAN_NARSALARGA_ALMASHTRISH;
            if (tegirmonInvoice.TegirmonProductid == null || tegirmonInvoice.TegirmonProductid == null) {
                return NotFound("Client or product not found");
            }

            if (tegirmonInvoice.TegirmonProductid != null)
            {
                List<TegirmonClientOstatka> ostatkaList = await _context.TegirmonClientOstatka
                    .Where(p => p.TegirmonProductid == tegirmonInvoice.TegirmonProductid
                    && p.TegirmonClientid == tegirmonInvoice.TegirmonClientid)
                    .ToListAsync();
                if (ostatkaList != null && ostatkaList.Count > 0)
                {
                    ostatkaList.First().qty = ostatkaList.First().qty - tegirmonInvoice.qty_real;
                    ostatkaList.First().real_qty = ostatkaList.First().real_qty - tegirmonInvoice.qty_real;

                    _context.TegirmonClientOstatka.UpdateRange(ostatkaList);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    TegirmonClientOstatka ostatka = new TegirmonClientOstatka();
                    ostatka.active_status = true;
                    ostatka.qty = -1 * tegirmonInvoice.qty_real;
                    ostatka.real_qty = -1 * tegirmonInvoice.qty_real;
                    ostatka.TegirmonProductid = tegirmonInvoice.TegirmonProductid ?? default(long);
                    ostatka.TegirmonClientid = tegirmonInvoice.TegirmonClientid ?? default(long);

                    _context.TegirmonClientOstatka.Update(ostatka);
                    await _context.SaveChangesAsync();
                }
            }

            //nima sotib olsa oshani ostatkadan ayrib qoyadi
            if (tegirmonInvoice.item_list != null && tegirmonInvoice.item_list.Count > 0)
            {
                foreach (TegirmonInvoiceItem item in tegirmonInvoice.item_list)
                {
                    List<TegirmonOstatka> ostatkaList = await _context.TegirmonOstatka
                   .Where(p => p.TegirmonProductid == item.TegirmonProductid)
                   .ToListAsync();
                    if (ostatkaList != null && ostatkaList.Count > 0)
                    {
                        ostatkaList.First().qty = ostatkaList.First().qty - item.qty;
                        ostatkaList.First().real_qty = ostatkaList.First().real_qty - item.qty;

                        _context.TegirmonOstatka.UpdateRange(ostatkaList);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        TegirmonOstatka ostatka = new TegirmonOstatka();
                        ostatka.active_status = true;
                        ostatka.qty = -1 * item.qty;
                        ostatka.real_qty = -1 * item.qty;
                        ostatka.TegirmonProductid = item.TegirmonProductid;

                        _context.TegirmonOstatka.Update(ostatka);
                        await _context.SaveChangesAsync();
                    }

                }

            }

            tegirmonInvoice.inv_accepted_status = true;
            _context.TegirmonInvoice.Update(tegirmonInvoice);
            await _context.SaveChangesAsync();

            return tegirmonInvoice;
        }
        [HttpPost("addChangeBugdoyFomClientZaxiradanToProducts")]
        public async Task<ActionResult<TegirmonInvoice>> addChangeBugdoyFomClientZaxiradanToProducts(TegirmonInvoice tegirmonInvoice)
        {
            tegirmonInvoice.status_inv_type_name = INVOICE_BUGDOY_ZAXIRADAN_NARSALARGA_ALMASHTRISH;
            _context.TegirmonInvoice.Update(tegirmonInvoice);
            await _context.SaveChangesAsync();

            return tegirmonInvoice;
        }
        [HttpGet("acceptChangeBugdoyFomClientZaxiradanToProducts")]
        public async Task<ActionResult<TegirmonInvoice>> acceptChangeBugdoyFomClientZaxiradanToProducts([FromQuery] long id)
        {
            var tegirmonInvoice = await _context.TegirmonInvoice
             .Include(p => p.item_list)
             .Where(p => p.id == id).ToListAsync();

            if (tegirmonInvoice == null || tegirmonInvoice.Count == 0)
            {
                return NotFound();
            }
            await postInvoiceBugdoyniZaxiradanNarsalargaAlmashtrish(tegirmonInvoice.First());

            return tegirmonInvoice.First();
        }






        /// <summary>
        /// Bu bugdoyni tegirmon qilishi uchun ishlatiladi 
        /// </summary>
        /// <param name="tegirmonInvoice"></param>
        /// <returns></returns>
        [HttpPost("postInvoiceBugdoyniTegirmongaUnQilibTortish")]
        public async Task<ActionResult<TegirmonInvoice>> postInvoiceBugdoyniTegirmongaUnQilibTortish(TegirmonInvoice tegirmonInvoice)
        {
            tegirmonInvoice.status_inv_type_name = INVOICE_BUGDOY_CHIQARISH_TEGIRMONDAN_UN_QILISH;
            if (tegirmonInvoice.TegirmonProductid != null)
            {
                List<TegirmonOstatka> ostatkaList = await _context.TegirmonOstatka
                    .Where(p => p.TegirmonProductid == tegirmonInvoice.TegirmonProductid)
                    .ToListAsync();
                if (ostatkaList != null && ostatkaList.Count > 0)
                {
                    ostatkaList.First().qty = ostatkaList.First().qty - tegirmonInvoice.qty_real;
                    ostatkaList.First().real_qty = ostatkaList.First().real_qty - tegirmonInvoice.qty_real;

                    _context.TegirmonOstatka.UpdateRange(ostatkaList);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    TegirmonOstatka ostatka = new TegirmonOstatka();
                    ostatka.active_status = true;
                    ostatka.qty = -1 * tegirmonInvoice.qty_real;
                    ostatka.real_qty = -1 * tegirmonInvoice.qty_real;
                    ostatka.TegirmonProductid = tegirmonInvoice.TegirmonProductid ?? default(long);

                    _context.TegirmonOstatka.Update(ostatka);
                    await _context.SaveChangesAsync();
                }
            }

            //kepak un otxotlardi prixod qilish uchun
            if (tegirmonInvoice.item_list != null && tegirmonInvoice.item_list.Count > 0) {
                foreach (TegirmonInvoiceItem item in tegirmonInvoice.item_list) {
                    List<TegirmonOstatka> ostatkaList = await _context.TegirmonOstatka
                   .Where(p => p.TegirmonProductid == item.TegirmonProductid)
                   .ToListAsync();
                    if (ostatkaList != null && ostatkaList.Count > 0)
                    {
                        ostatkaList.First().qty = ostatkaList.First().qty + item.qty;
                        ostatkaList.First().real_qty = ostatkaList.First().real_qty + item.qty;

                        _context.TegirmonOstatka.UpdateRange(ostatkaList);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        TegirmonOstatka ostatka = new TegirmonOstatka();
                        ostatka.active_status = true;
                        ostatka.qty =  item.qty;
                        ostatka.real_qty = item.qty;
                        ostatka.TegirmonProductid = item.TegirmonProductid;

                        _context.TegirmonOstatka.Update(ostatka);
                        await _context.SaveChangesAsync();
                    }

                }
            
            }

            tegirmonInvoice.inv_accepted_status = true;
            _context.TegirmonInvoice.Update(tegirmonInvoice);
            await _context.SaveChangesAsync();

            return tegirmonInvoice;
        }
        [HttpPost("addBugdoyniUnQilish")]
        public async Task<ActionResult<TegirmonInvoice>> addBugdoyniUnQilish(TegirmonInvoice tegirmonInvoice)
        {
            tegirmonInvoice.status_inv_type_name = INVOICE_BUGDOY_CHIQARISH_TEGIRMONDAN_UN_QILISH;
            _context.TegirmonInvoice.Update(tegirmonInvoice);
            await _context.SaveChangesAsync();

            return tegirmonInvoice;
        }

        [HttpGet("acceptBugdoyniUnQilish")]
        public async Task<ActionResult<TegirmonInvoice>> acceptBugdoyniUnQilish([FromQuery] long id)
        {
            var tegirmonInvoice = await _context.TegirmonInvoice
                .Include(p => p.item_list)
                .Where(p => p.id == id).ToListAsync();

            if (tegirmonInvoice == null || tegirmonInvoice.Count == 0)
            {
                return NotFound();
            }
            await postInvoiceBugdoyniTegirmongaUnQilibTortish(tegirmonInvoice.First());

            return tegirmonInvoice.First();
        }






        /// <summary>
        /// bu tovarlardi prixod qilgani ozi uchun bozordan opkesa nimadr yog nilardir
        /// </summary>
        /// <param name="tegirmonInvoice"></param>
        /// <returns></returns>
        [HttpPost("postInvoiceBugdoyTovarlarniPrixodQilishSkladga")]
        public async Task<ActionResult<TegirmonInvoice>> postInvoiceBugdoyTovarlarniPrixodQilishSkladga(TegirmonInvoice tegirmonInvoice)
        {
            tegirmonInvoice.status_inv_type_name = INVOICE_BUGDOY_PRIXOD_QILISH;
            //tovarlani prixod qilish ostatkalardi qoshish bolmasa yaratish uchun kerak
            if (tegirmonInvoice.item_list != null && tegirmonInvoice.item_list.Count > 0)
            {
                foreach (TegirmonInvoiceItem item in tegirmonInvoice.item_list)
                {
                    List<TegirmonOstatka> ostatkaList = await _context.TegirmonOstatka
                   .Where(p => p.TegirmonProductid == item.TegirmonProductid)
                   .ToListAsync();
                    if (ostatkaList != null && ostatkaList.Count > 0)
                    {
                        ostatkaList.First().qty = ostatkaList.First().qty + item.qty;
                        ostatkaList.First().real_qty = ostatkaList.First().real_qty + item.qty;

                        _context.TegirmonOstatka.UpdateRange(ostatkaList);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        TegirmonOstatka ostatka = new TegirmonOstatka();
                        ostatka.active_status = true;
                        ostatka.qty = item.qty;
                        ostatka.real_qty = item.qty;
                        ostatka.TegirmonProductid = item.TegirmonProductid;

                        _context.TegirmonOstatka.Update(ostatka);
                        await _context.SaveChangesAsync();
                    }

                }

            }

            tegirmonInvoice.inv_accepted_status = true;
            _context.TegirmonInvoice.Update(tegirmonInvoice);
            await _context.SaveChangesAsync();

            return tegirmonInvoice;
        }
        [HttpPost("addTovarlardiPrixodQilish")]
        public async Task<ActionResult<TegirmonInvoice>> addTovarlardiPrixodQilish(TegirmonInvoice tegirmonInvoice)
        {
            tegirmonInvoice.status_inv_type_name = INVOICE_BUGDOY_PRIXOD_QILISH;
            _context.TegirmonInvoice.Update(tegirmonInvoice);
            await _context.SaveChangesAsync();

            return tegirmonInvoice;
        }

        [HttpGet("acceptTovarlardiPrixodQilish")]
        public async Task<ActionResult<TegirmonInvoice>> acceptTovarlardiPrixodQilish([FromQuery] long id)
        {
            var tegirmonInvoice = await _context.TegirmonInvoice
                .Include(p => p.item_list)
                .Where(p =>p.id == id).ToListAsync();

            if (tegirmonInvoice == null || tegirmonInvoice.Count == 0)
            {
                return NotFound();
            }
            await postInvoiceBugdoyTovarlarniPrixodQilishSkladga(tegirmonInvoice.First());

            return tegirmonInvoice.First();
        }







        /// <summary>
        /// Bu srogi otgan tovarlardi spisaniya qilish uchun 
        /// </summary>
        /// <param name="tegirmonInvoice"></param>
        /// <returns></returns>
        [HttpPost("postInvoiceBugdoyEskirganTovarlardiSklatdanSpisaniyaQilish")]
        public async Task<ActionResult<TegirmonInvoice>> postInvoiceBugdoyEskirganTovarlardiSklatdanSpisaniyaQilish(TegirmonInvoice tegirmonInvoice)
        {
            tegirmonInvoice.status_inv_type_name = INVOICE_BUGDOY_RASXOD_BRAK_CHIQQANLAR;
            //tovarlani prixod qilish ostatkalardi qoshish bolmasa yaratish uchun kerak
            if (tegirmonInvoice.item_list != null && tegirmonInvoice.item_list.Count > 0)
            {
                foreach (TegirmonInvoiceItem item in tegirmonInvoice.item_list)
                {
                    List<TegirmonOstatka> ostatkaList = await _context.TegirmonOstatka
                   .Where(p => p.TegirmonProductid == item.TegirmonProductid)
                   .ToListAsync();
                    if (ostatkaList != null && ostatkaList.Count > 0)
                    {
                        ostatkaList.First().qty = ostatkaList.First().qty - item.qty;
                        ostatkaList.First().real_qty = ostatkaList.First().real_qty - item.qty;

                        _context.TegirmonOstatka.UpdateRange(ostatkaList);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        TegirmonOstatka ostatka = new TegirmonOstatka();
                        ostatka.active_status = true;
                        ostatka.qty = -1 * item.qty;
                        ostatka.real_qty =-1 *  item.qty;
                        ostatka.TegirmonProductid = item.TegirmonProductid;

                        _context.TegirmonOstatka.Update(ostatka);
                        await _context.SaveChangesAsync();
                    }

                }

            }


            tegirmonInvoice.inv_accepted_status = true;
            _context.TegirmonInvoice.Update(tegirmonInvoice);
            await _context.SaveChangesAsync();

            return tegirmonInvoice;
        }
        [HttpPost("addSrogiOtganTovarlardiRasxodQilish")]
        public async Task<ActionResult<TegirmonInvoice>> addSrogiOtganTovarlardiRasxodQilish(TegirmonInvoice tegirmonInvoice)
        {
            tegirmonInvoice.status_inv_type_name = INVOICE_BUGDOY_RASXOD_BRAK_CHIQQANLAR;
            _context.TegirmonInvoice.Update(tegirmonInvoice);
            await _context.SaveChangesAsync();

            return tegirmonInvoice;
        }

        [HttpGet("acceptSrogiOtganTovarlardiRasxodQilish")]
        public async Task<ActionResult<TegirmonInvoice>> acceptSrogiOtganTovarlardiRasxodQilish([FromQuery] long id)
        {
            var tegirmonInvoice = await _context.TegirmonInvoice.FindAsync(id);

            if (tegirmonInvoice == null)
            {
                return NotFound();
            }
            await postInvoiceBugdoyEskirganTovarlardiSklatdanSpisaniyaQilish(tegirmonInvoice);

            return tegirmonInvoice;
        }



        [HttpGet("getPaginationBugdoyPrixodQilinganTovarlarListiVaqtsz")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationBugdoyPrixodQilinganTovarlarListiVaqtsz([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonInvoice> categoryList = await _context.TegirmonInvoice
                .Include(p => p.contragent)
                .Include(p => p.product)
                .Include(p =>p.client)
                .Where(p => p.active_status == true
               
                && p.status_inv_type_name == INVOICE_BUGDOY_PRIXOD_QILISH)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonInvoice
                .Where(p => p.active_status == true
                && p.status_inv_type_name == INVOICE_BUGDOY_PRIXOD_QILISH).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationByClientId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByClientId([FromQuery] int page, [FromQuery] int size,[FromQuery] long client_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonInvoice> categoryList = await _context.TegirmonInvoice
                .Include(p => p.contragent)
                .Include(p => p.product)
                .Include(p => p.client)
                .Where(p => p.active_status == true

                && p.TegirmonClientid == client_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonInvoice
                .Where(p => p.active_status == true
                && p.TegirmonClientid == client_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }



        [HttpGet("getPaginationBugdoyPrixodQilinganTovarlarListi")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationBugdoyPrixodQIlinganTovarlarListi([FromQuery] int page, [FromQuery] int size,
    [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonInvoice> categoryList = await _context.TegirmonInvoice
                .Include(p => p.contragent)
                .Include(p =>p.product)
                .Where(p => p.active_status == true
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)
                && p.status_inv_type_name == INVOICE_BUGDOY_PRIXOD_QILISH)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonInvoice
                .Where(p => p.active_status == true
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)
                && p.status_inv_type_name == INVOICE_BUGDOY_PRIXOD_QILISH).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationBugdoyniPulgaAlmashishListi")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationBugdoyniPulgaAlmashishListi([FromQuery] int page, [FromQuery] int size,
            [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonInvoice> categoryList = await _context.TegirmonInvoice
                .Where(p => p.active_status == true
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)
                && p.status_inv_type_name == INVOICE_BUGDOY_SOTISH_PULGA)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonInvoice>();
            } 
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonInvoice
                .Where(p => p.active_status == true
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)
                && p.status_inv_type_name == INVOICE_BUGDOY_SOTISH_PULGA).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationBugdoyTortilganTegirmondanUnUchunListi")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationBugdoyTortilganTegirmondanUnUchunListi([FromQuery] int page, [FromQuery] int size,
    [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonInvoice> categoryList = await _context.TegirmonInvoice
                .Where(p => p.active_status == true
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)
                && p.status_inv_type_name == INVOICE_BUGDOY_CHIQARISH_TEGIRMONDAN_UN_QILISH)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonInvoice
                .Where(p => p.active_status == true
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)
                && p.status_inv_type_name == INVOICE_BUGDOY_CHIQARISH_TEGIRMONDAN_UN_QILISH).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationSpisatQilinganTovarlarListi")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationSpisatQilinganTovarlarListi([FromQuery] int page, [FromQuery] int size,
[FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonInvoice> categoryList = await _context.TegirmonInvoice
                .Where(p => p.active_status == true
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)
                && p.status_inv_type_name == INVOICE_BUGDOY_RASXOD_BRAK_CHIQQANLAR)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonInvoice
                .Where(p => p.active_status == true
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)
                && p.status_inv_type_name == INVOICE_BUGDOY_RASXOD_BRAK_CHIQQANLAR).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationZahiragaOlibQolinganTovarlarListilarListi")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationZahiragaOlibQolinganTovarlarListilarListi([FromQuery] int page, [FromQuery] int size,
[FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonInvoice> categoryList = await _context.TegirmonInvoice
                .Include( p => p.client)
                .Include( p => p.product)
                .Include( p => p.contragent)
                .Where(p => p.active_status == true
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)
                && p.status_inv_type_name == INVOICE_BUGDOY_NARSALARGA_ALMASHTRISH_UCHUN_ZAXIRAGA_OLIB_QOLISH)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonInvoice
                .Where(p => p.active_status == true
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)
                && p.status_inv_type_name == INVOICE_BUGDOY_NARSALARGA_ALMASHTRISH_UCHUN_ZAXIRAGA_OLIB_QOLISH).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationBugdoyniRegistratsiyaQilmasdanNarsalargaALmashtrilganlarListi")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationBugdoyniRegistratsiyaQilmasdanNarsalargaALmashtrilganlarListi([FromQuery] int page, [FromQuery] int size,
[FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonInvoice> categoryList = await _context.TegirmonInvoice
                .Include(p => p.client)
                .Include(p => p.product)
                .Include(p => p.contragent)
                .Where(p => p.active_status == true
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)
                && p.status_inv_type_name == INVOICE_BUGDOY_NARSALARGA_ALMASHTRISH)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonInvoice
                .Where(p => p.active_status == true
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)
                && p.status_inv_type_name == INVOICE_BUGDOY_NARSALARGA_ALMASHTRISH).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationZahiradanNarsalargaAlmashganlardiListi")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationZahiradanNarsalargaAlmashganlardiListi([FromQuery] int page, [FromQuery] int size,
[FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonInvoice> categoryList = await _context.TegirmonInvoice
                .Where(p => p.active_status == true
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)
                && p.status_inv_type_name == INVOICE_BUGDOY_ZAXIRADAN_NARSALARGA_ALMASHTRISH)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonInvoice
                .Where(p => p.active_status == true
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)
                && p.status_inv_type_name == INVOICE_BUGDOY_ZAXIRADAN_NARSALARGA_ALMASHTRISH).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        // GET: api/TegirmonInvoice
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonInvoice>>> GetTegirmonInvoice()
        {
            return await _context.TegirmonInvoice.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonInvoice> categoryList = await _context.TegirmonInvoice
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonInvoice
                .Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TegirmonInvoice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonInvoice>> GetTegirmonInvoice(long id)
        {
            var tegirmonInvoice = await _context.TegirmonInvoice.FindAsync(id);

            if (tegirmonInvoice == null)
            {
                return NotFound();
            }

            return tegirmonInvoice;
        }

        [HttpGet("deAcceptpostInvoiceBugdoyniClientniRegistratsiyaQilmasdanNarsalargaAlmashtribYuborishByInvoiecId")]
        public async Task<ActionResult<TegirmonInvoice>> deAcceptpostInvoiceBugdoyniClientniRegistratsiyaQilmasdanNarsalargaAlmashtribYuborishByInvoiecId([FromQuery]long invoice_id)
        {
            var tegirmonInvoice = await _context.TegirmonInvoice
                  .Include(p => p.product)
                  .Include(p => p.client)
                  .Include(p => p.contragent)
                  .Include(p => p.item_list)
                  .ThenInclude(p => p.product)
                  .Include(p => p.auth)
                  .ThenInclude(p => p.user)
                  .Where(p => p.id == invoice_id).ToListAsync();

            if (tegirmonInvoice == null || tegirmonInvoice.Count == 0)
            {
                return NotFound();
            }

            return await deAcceptpostInvoiceBugdoyniClientniRegistratsiyaQilmasdanNarsalargaAlmashtribYuborish(tegirmonInvoice.First());

            
        }

        [HttpGet("deleteNoTestedAcceptpostInvoiceBugdoyniClientniRegistratsiyaQilmasdanNarsalargaAlmashtribYuborishbyInvoiceId")]
        public async Task<ActionResult<TegirmonInvoice>> deleteNoTestedAcceptpostInvoiceBugdoyniClientniRegistratsiyaQilmasdanNarsalargaAlmashtribYuborishbyInvoiceId([FromQuery] long invoice_id)
        {
            var tegirmonInvoice = await _context.TegirmonInvoice
                  .Include(p => p.product)
                  .Include(p => p.client)
                  .Include(p => p.contragent)
                  .Include(p => p.item_list)
                  .ThenInclude(p => p.product)
                  .Include(p => p.auth)
                  .ThenInclude(p => p.user)
                  .Where(p => p.id == invoice_id).ToListAsync();

            if (tegirmonInvoice == null || tegirmonInvoice.Count == 0)
            {
                return NotFound();
            }

            return await deleteNoTestedAcceptpostInvoiceBugdoyniClientniRegistratsiyaQilmasdanNarsalargaAlmashtribYuborish(tegirmonInvoice.First());


        }

        // GET: api/TegirmonInvoice/5
        [HttpGet("getAnyInvoiceFullInfoById")]
        public async Task<ActionResult<TegirmonInvoice>> getAnyInvoiceFullInfoById([FromQuery]long invoice_id)
        {
            var tegirmonInvoice = await _context.TegirmonInvoice
                .Include(p => p.product)
                .Include(p => p.client)
                .Include(p => p.contragent)
                .Include(p =>p.item_list)
                .ThenInclude(p =>p.product)
                .Include(p => p.auth)
                .ThenInclude(p => p.user)
                .Where(p =>p.id == invoice_id).ToListAsync();

            if (tegirmonInvoice == null || tegirmonInvoice.Count == 0)
            {
                return NotFound();
            }

            return tegirmonInvoice.First();
        }

        // PUT: api/TegirmonInvoice/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonInvoice(long id, TegirmonInvoice tegirmonInvoice)
        {
            if (id != tegirmonInvoice.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonInvoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonInvoiceExists(id))
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

        // POST: api/TegirmonInvoice
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonInvoice>> PostTegirmonInvoice(TegirmonInvoice tegirmonInvoice)
        {
            _context.TegirmonInvoice.Update(tegirmonInvoice);
            await _context.SaveChangesAsync();

            return tegirmonInvoice;
        }

        // DELETE: api/TegirmonInvoice/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonInvoice>> DeleteTegirmonInvoice(long id)
        {
            var tegirmonInvoice = await _context.TegirmonInvoice.FindAsync(id);
            if (tegirmonInvoice == null)
            {
                return NotFound();
            }

            _context.TegirmonInvoice.Remove(tegirmonInvoice);
            await _context.SaveChangesAsync();

            return tegirmonInvoice;
        }

        private bool TegirmonInvoiceExists(long id)
        {
            return _context.TegirmonInvoice.Any(e => e.id == id);
        }
    }
}
