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
    public class TexInvoicesController : ControllerBase
    {
        private readonly ApplicationContext _context;
        //private TIInvoiceService invoiceService { get; set; }

        public TexInvoicesController(ApplicationContext context)
        {
            _context = context;
            //invoiceService = _invoiceService;
        }

        // GET: api/TexInvoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexInvoice>>> GetTexInvoice()
        {
            return await _context.TexInvoice.ToListAsync();
        }

        [HttpGet("getBuyInvoiceList")]
        public async Task<ActionResult<TexPaginationModel>> getBuyInvoiceList([FromQuery] int page, [FromQuery] int size)
        {
            TexInvoiceType texInvoiceType = await getInvoiceTypeMetod("BUY");
            int count  = await _context.TexInvoice.Where(p => p.invoice_type_id == texInvoiceType.id).CountAsync();
            var InvoiceList = await getInvoiceListByTypeId(texInvoiceType.id,page,size);
            TexPaginationModel paginationModel = new TexPaginationModel();
            if (InvoiceList == null)
            {
                InvoiceList = new List<TexInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(InvoiceList);
            paginationModel.items_count = count;
            paginationModel.current_item_count = InvoiceList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getSaleInvoiceList")]
        public async Task<ActionResult<TexPaginationModel>> getSaleInvoiceList([FromQuery] int page, [FromQuery] int size)
        {
            TexInvoiceType texInvoiceType = await getInvoiceTypeMetod("SALE");
            int count = await _context.TexInvoice.Where(p => p.invoice_type_id == texInvoiceType.id).CountAsync();
            var InvoiceList = await getInvoiceListByTypeId(texInvoiceType.id, page, size);
            TexPaginationModel paginationModel = new TexPaginationModel();
            if (InvoiceList == null)
            {
                InvoiceList = new List<TexInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(InvoiceList);
            paginationModel.items_count = count;
            paginationModel.current_item_count = InvoiceList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getRasxodInvoiceList")]
        public async Task<ActionResult<TexPaginationModel>> getRasxodInvoiceList([FromQuery] int page, [FromQuery] int size)
        {
            TexInvoiceType texInvoiceType = await getInvoiceTypeMetod("RASXOD_FOR_MODEL");
            int count = await _context.TexInvoice.Where(p => p.invoice_type_id == texInvoiceType.id).CountAsync();
            var InvoiceList = await getInvoiceListByTypeId(texInvoiceType.id, page, size);
            TexPaginationModel paginationModel = new TexPaginationModel();
            if (InvoiceList == null)
            {
                InvoiceList = new List<TexInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(InvoiceList);
            paginationModel.items_count = count;
            paginationModel.current_item_count = InvoiceList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        [HttpGet("getMovementInvoiceList")]
        public async Task<ActionResult<TexPaginationModel>> getMovementInvoiceList([FromQuery] int page, [FromQuery] int size)
        {
            TexInvoiceType texInvoiceType = await getInvoiceTypeMetod("MOVEMENT");
            int count = await _context.TexInvoice.Where(p => p.invoice_type_id == texInvoiceType.id).CountAsync();
            var InvoiceList = await getInvoiceListByTypeId(texInvoiceType.id, page, size);
            TexPaginationModel paginationModel = new TexPaginationModel();
            if (InvoiceList == null)
            {
                InvoiceList = new List<TexInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(InvoiceList);
            paginationModel.items_count = count;
            paginationModel.current_item_count = InvoiceList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }      
        
        [HttpGet("getMovementInvoiceNotRecevedList")]
        public async Task<ActionResult<TexPaginationModel>> getMovementInvoiceNotRecevedList([FromQuery] int page, [FromQuery] int size)
        {
            TexInvoiceType texInvoiceType = await getInvoiceTypeMetod("MOVEMENT");
             

            int count = await _context.TexInvoice.Where(p => p.invoice_type_id == texInvoiceType.id && p.invoice_filter_status == "SEND").CountAsync();
            var InvoiceList =  await getInvoiceListByTypeIdAndInvoiceStatus(texInvoiceType.id, "SEND", page, size);
            TexPaginationModel paginationModel = new TexPaginationModel();
            if (InvoiceList == null)
            {
                InvoiceList = new List<TexInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(InvoiceList);
            paginationModel.items_count = count;
            paginationModel.current_item_count = InvoiceList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }     
        
        [HttpGet("getMovementInvoiceRecevedList")]
        public async Task<ActionResult<TexPaginationModel>> getMovementInvoiceRecevedList([FromQuery] int page, [FromQuery] int size)
        {
            TexInvoiceType texInvoiceType = await getInvoiceTypeMetod("MOVEMENT");
            int count = await _context.TexInvoice.Where(p => p.invoice_type_id == texInvoiceType.id && p.invoice_filter_status == "RECEVIE").CountAsync();
            var InvoiceList = await getInvoiceListByTypeIdAndInvoiceStatus(texInvoiceType.id, "RECEVIE", page, size);
            TexPaginationModel paginationModel = new TexPaginationModel();
            if (InvoiceList == null)
            {
                InvoiceList = new List<TexInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(InvoiceList);
            paginationModel.items_count = count;
            paginationModel.current_item_count = InvoiceList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }      
        
        [HttpGet("getMovementInvoiceRejectedList")]
        public async Task<ActionResult<TexPaginationModel>> getMovementInvoiceRejectedList([FromQuery] int page, [FromQuery] int size)
        {
            TexInvoiceType texInvoiceType = await getInvoiceTypeMetod("MOVEMENT");
            int count = await _context.TexInvoice.Where(p => p.invoice_type_id == texInvoiceType.id && p.invoice_filter_status == "REJECTED").CountAsync();
            var InvoiceList = await getInvoiceListByTypeIdAndInvoiceStatus(texInvoiceType.id, "REJECTED", page, size);
            TexPaginationModel paginationModel = new TexPaginationModel();
            if (InvoiceList == null)
            {
                InvoiceList = new List<TexInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(InvoiceList);
            paginationModel.items_count = count;
            paginationModel.current_item_count = InvoiceList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        [HttpGet("getSimpleProductionInvoiceList")]
        public async Task<ActionResult<TexPaginationModel>> getSimpleProductionInvoiceList([FromQuery] int page, [FromQuery] int size)
        {
            TexInvoiceType texInvoiceType = await getInvoiceTypeMetod("SIMPLE_PRODUCTION");
            int count = await _context.TexInvoice.Where(p => p.invoice_type_id == texInvoiceType.id).CountAsync();
            var InvoiceList = await getInvoiceListByTypeId(texInvoiceType.id, page, size);
            TexPaginationModel paginationModel = new TexPaginationModel();
            if (InvoiceList == null)
            {
                InvoiceList = new List<TexInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(InvoiceList);
            paginationModel.items_count = count;
            paginationModel.current_item_count = InvoiceList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getForServiceInvoiceList")]
        public async Task<ActionResult<TexPaginationModel>> getForServiceInvoiceList([FromQuery] int page, [FromQuery] int size)
        {
            TexInvoiceType texInvoiceType = await getInvoiceTypeMetod("FOR_SERVICE");
            int count = await _context.TexInvoice.Where(p => p.invoice_type_id == texInvoiceType.id).CountAsync();
            var InvoiceList = await getInvoiceListByTypeId(texInvoiceType.id, page, size);
            TexPaginationModel paginationModel = new TexPaginationModel();
            if (InvoiceList == null)
            {
                InvoiceList = new List<TexInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(InvoiceList);
            paginationModel.items_count = count;
            paginationModel.current_item_count = InvoiceList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        
        private async Task<List<TexInvoice>> getInvoiceListByTypeId( [FromQuery] long invoice_type_id,[FromQuery] int page, [FromQuery] int size )
        {
            return await _context.TexInvoice
                .Where(   p => p.invoice_type_id == invoice_type_id)
                .Include( p => p.sklad)
                .Include( p => p.contragent)
                .Include( p => p.department)
                .Include( p => p.filial)
                .Include( p => p.invoiceType)
                .Include( p => p.maincompany)
                .Include( p => p.maindepartment)
                .Include( p => p.mainSklad)
                .Include( p => p.paymentType)
                .Include( p => p.serviceType)
                .Include( p => p.calcType)
                .Include( p => p.valyuta)
                .Include( p => p.order)
                .Include( p => p.user)
                .Include( p => p.product)
                .OrderByDescending( p => p.id).Skip(page * size).Take(size).ToListAsync();
        }

        
        private async Task<List<TexInvoice>> getInvoiceListByTypeIdAndInvoiceStatus([FromQuery] long invoice_type_id,[FromQuery] String status_name, [FromQuery] int page, [FromQuery] int size)
        {
            return await _context.TexInvoice
                .Where(p => p.invoice_type_id == invoice_type_id && p.invoice_filter_status == status_name)
                .Include(p => p.sklad)
                .Include(p => p.contragent)
                .Include(p => p.department)
                .Include(p => p.filial)
                .Include(p => p.invoiceType)
                .Include(p => p.maincompany)
                .Include(p => p.maindepartment)
                .Include(p => p.mainSklad)
                .Include(p => p.paymentType)
                .Include(p => p.serviceType)
                .Include(p => p.calcType)
                .Include(p => p.valyuta)
                .Include(p => p.order)
                .OrderByDescending(p => p.id).Skip(page * size).Take(size).ToListAsync();
        }

        // GET: api/TexInvoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexInvoice>> GetTexInvoice(long id)
        {
            var texInvoice = await _context.TexInvoice.FindAsync(id);

            if (texInvoice == null)
            {
                return NotFound();
            }

            return texInvoice;
        }

        [HttpGet("getInvoiceByIdForView")]
        public async Task<ActionResult<TexInvoice>> getInvoiceByIdForView([FromQuery]long invoiceId)
        {
            List<TexInvoice> texInvoiceList = await _context.TexInvoice
                .Where(p => p.id == invoiceId)
                .Include(p => p.sklad)
                .Include(p => p.contragent)
                .Include(p => p.department)
                .Include(p => p.filial)
                .Include(p => p.invoiceType)
                .Include(p => p.maincompany)
                .Include(p => p.maindepartment)
                .Include(p => p.mainSklad)
                .Include(p => p.paymentType)
                .Include(p => p.serviceType)
                .Include(p => p.calcType)
                .Include(p => p.valyuta)
                .Include(p => p.order)
                .Include(p => p.receved_auth)
                .Include(p => p.product)
                .Include(p => p.user)
                .ToListAsync();

            if (texInvoiceList == null || texInvoiceList.Count == 0)
            {
                return NotFound("Счет-фактура пуст");
            }
            TexInvoice texInvoice = texInvoiceList.First();
            List<TexInvoiceItem> texInvoiceItems = await _context.TexInvoiceItem
                .Where(p => p.invoice_id == texInvoice.id)
                .Include( p => p.color)
                .Include( p =>p.colorvariant)
                .Include(p => p.extrawork)
                .Include( p => p.guscolor)
                .Include( p => p.invoiceType)
                .Include( p => p.mainProccess)
                .Include( p => p.product)
                .Include( p =>p.sort)
                .Include( p => p.status)
                .Include( p => p.suroviyVid)
                .Include( p => p.upakovka)
                
                .ToListAsync();
            texInvoice.invoiceItemList = texInvoiceItems;
            return texInvoice;
        }

        [HttpGet("getReciveMovementInvoiceById")]
        public async Task<ActionResult<TexInvoice>> getReciveMovementInvoiceById([FromQuery]long invoice_id,[FromQuery] long auth_id)
        {
            var texInvoice = await _context.TexInvoice.FindAsync(invoice_id);

            if (texInvoice.inv_accepted_status == false) {
                return NotFound("Not accepted invoice");
            }

            if (texInvoice == null)
            {
                return NotFound("Invoice not found");
            }
            try
            {
                texInvoice.invoice_filter_status = "RECEVIE";
                texInvoice.receved_auth_id = auth_id;
                texInvoice.accepted_user = true;
                _context.TexInvoice.Update(texInvoice);
                await _context.SaveChangesAsync();

                TexStatus texStatus = await getInvoiceStatusByNameMetod("MOVEMENT_RECIVE");
                TexInvoiceType texInvoiceType = await getInvoiceTypeMetod("MOVEMENT_RECIVE");

                TexInvoice inv_new = texInvoice;
                inv_new.id = 0;
                inv_new.invoiceType = texInvoiceType;
                inv_new.invoice_type_id = texInvoiceType.id;
                inv_new.invoiceItemList = new List<TexInvoiceItem>();

                _context.TexInvoice.Update(inv_new);
                await _context.SaveChangesAsync();

                List<TexInvoiceItem> items_new = await _context.TexInvoiceItem.Where(p => p.invoice_id == invoice_id).ToListAsync();
                foreach (TexInvoiceItem item in items_new) {
                    item.id = 0;
                    item.invoice = inv_new;
                    item.invoice_id = inv_new.id;
                    item.invoiceType = texInvoiceType;
                    item.invoice_type_id = texInvoiceType.id;
                    item.status = texStatus;
                    item.status_type_name = texStatus.name;
                    item.item_status_id = texStatus.id;
                    item.ostatka = item.qty;
                }
                _context.TexInvoiceItem.UpdateRange(items_new);
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

            return texInvoice;
        }

        [HttpGet("getRejectMovementInvoiceById")]
        public async Task<ActionResult<TexInvoice>> getRejectMovementInvoiceById([FromQuery] long invoice_id, [FromQuery] long auth_id)
        {
            var texInvoice = await _context.TexInvoice.FindAsync(invoice_id);

            if (texInvoice == null)
            {
                return NotFound("Invoice not found");
            }
            try
            {
                texInvoice.invoice_filter_status = "REJECTED";
                texInvoice.receved_auth_id = auth_id;
                _context.TexInvoice.Update(texInvoice);
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

            return texInvoice;
        }

        // PUT: api/TexInvoices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexInvoice(long id, TexInvoice texInvoice)
        {
            if (id != texInvoice.id)
            {
                return BadRequest();
            }

            _context.Entry(texInvoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexInvoiceExists(id))
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

        // POST: api/TexInvoices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexInvoice>> PostTexInvoice(TexInvoice texInvoice)
        {

            try
            {
            _context.TexInvoice.Update(texInvoice);
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

            return CreatedAtAction("GetTexInvoice", new { id = texInvoice.id }, texInvoice);
        }

        [HttpPost("addBuyInvoice")]
        public async Task<ActionResult<TexInvoice>> addBuyInvoice(TexInvoice texInvoice)
        {
            //check invoice 


            try
            {
                return await addBuyInvoiceMetod(texInvoice);
            }
            catch (Exception e) {
                return NotFound(e?.InnerException?.Message);
            }
        }


        [HttpPost("addSaleInvoice")]
        public async Task<ActionResult<TexInvoice>> addSaleInvoice(TexInvoice texInvoice)
        {
            try { 
                return await addSaleInvoiceMetod(texInvoice);
             }
            catch (Exception e) {
                return NotFound(e?.InnerException?.Message);
              }
}

        [HttpPost("addModelRasxodInvoice")]
        public async Task<ActionResult<TexInvoice>> addModelRasxodInvoice(TexInvoice texInvoice)
        {
            try
            {
                return await addRasxodModelInvoiceMetod(texInvoice);
            }
            catch (Exception e)
            {
                return NotFound(e?.InnerException?.Message);
            }
        }

        [HttpPost("addForServiceInvoice")]
        public async Task<ActionResult<TexInvoice>> addForServiceInvoice(TexInvoice texInvoice)
        {
            try
            {
              return await addForServiceInvoiceMetod(texInvoice);
            }
            catch (Exception e)
            {
                return NotFound(e?.InnerException?.Message);
            }
        }

        [HttpGet("addAcceptedOrDisableMovementInvoiceSend")]
        public async Task<ActionResult<TexInvoice>> addAcceptedOrDisableMovementInvoiceSend([FromQuery] long inv_id,[FromQuery] bool accepted_status)
        {
            

            TexInvoice texInvoice = await _context.TexInvoice.FindAsync(inv_id);

            List<TexInvoiceItem> texInvoiceItems = await _context.TexInvoiceItem.Where(p => p.invoice_id == inv_id).ToListAsync();
            if (texInvoice.inv_accepted_status == accepted_status) {
                return NotFound("Please, update and retry again");
            }

            if (texInvoice.accepted_user == true)
            {
                return NotFound("You can not change, already accepted");
            }


            texInvoice.inv_accepted_status = accepted_status;

            if (accepted_status == false) {

                List<TexInvoiceItem> upd_itm = new List<TexInvoiceItem>();

                foreach (TexInvoiceItem itm in texInvoiceItems) {
                    TexInvoiceItem g_itm = await _context.TexInvoiceItem.FindAsync(itm.main_item_id);
                    g_itm.ostatka = g_itm.ostatka + itm.qty;
                    upd_itm.Add(g_itm);

                }

                //update invoice item
                _context.TexInvoiceItem.UpdateRange(upd_itm);
                await _context.SaveChangesAsync();

                //update invoice 
                _context.TexInvoice.Update(texInvoice);
                await _context.SaveChangesAsync();


                return texInvoice;
            }



            try
            {

                if (texInvoiceItems != null && texInvoiceItems.Count > 0)
                {
                    List<TexInvoiceItem> item_list_updated = new List<TexInvoiceItem>();

                    foreach (TexInvoiceItem item in texInvoiceItems) {

                        TexInvoiceItem g_itm = await _context.TexInvoiceItem.FindAsync(item.main_item_id);
                        if (g_itm.ostatka < item.qty)
                        {
                            return NotFound("Not enought product");
                        }
                        g_itm.ostatka = g_itm.ostatka - item.qty;
                        item_list_updated.Add(g_itm);
                    }

                    //update invoice item
                    _context.TexInvoiceItem.UpdateRange(item_list_updated);
                    await _context.SaveChangesAsync();

                    //update invoice 
                    _context.TexInvoice.Update(texInvoice);
                    await _context.SaveChangesAsync();


                    return texInvoice;
                }
                else {

                    return NotFound("Not enought product or item not exits");
                }


            }
            catch (Exception e)
            {
                return NotFound(e?.InnerException?.Message);
            }
        }


        [HttpPost("addMovementInvoiceSend")]
        public async Task<ActionResult<TexInvoice>> addMovementInvoiceSend(TexInvoice texInvoice)
        {
            try
            {
                 return await addMovementInvoiceSendMetod(texInvoice);
            }
            catch (Exception e)
            {
                return NotFound(e?.InnerException?.Message);
            }
        }  
        
        [HttpPost("addOrderItemRecipeItems")]
        public async Task<ActionResult<List<TexInvoiceItem>>> addOrderItemRecipeItems(List<TexInvoiceItem> invoiceItemList)
        {
            try
            {
                return await addReserveOrderItemRecipesMetod(invoiceItemList);
            }
            catch (Exception e)
            {
                return NotFound(e?.InnerException?.Message);
            }
        }

        [HttpPost("addSimpleProductionInvoice")]
        public async Task<ActionResult<TexInvoice>> addSimpleProductionInvoice(TexInvoice texInvoice)
        {
            try
            {
                return await addSimpleProductionInvoiceMetod(texInvoice);
            }
            catch (Exception e)
            {
                return NotFound(e?.InnerException?.Message);
            }
        }

        // DELETE: api/TexInvoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexInvoice>> DeleteTexInvoice(long id)
        {
            var texInvoice = await _context.TexInvoice.FindAsync(id);
            if (texInvoice == null)
            {
                return NotFound();
            }

            _context.TexInvoice.Remove(texInvoice);
            await _context.SaveChangesAsync();

            return texInvoice;
        }

        private bool TexInvoiceExists(long id)
        {
            return _context.TexInvoice.Any(e => e.id == id);
        }






        //invoice
        private async Task<TexStatus> getInvoiceStatusByNameMetod(string name)
        {
            if (name.Equals("SAVE"))
            {
                List<TexStatus> texInvoiceTypeList = _context.TexStatus.Where(p => p.name == name).ToList();
                if (texInvoiceTypeList != null && texInvoiceTypeList.Count > 0)
                {
                    return texInvoiceTypeList.First();
                }

                TexStatus invoiceType = new TexStatus();
                invoiceType.active_status = true;
                invoiceType.name = "SAVE";
                _context.TexStatus.Update(invoiceType);
                await _context.SaveChangesAsync();
                return invoiceType;

            }
            else if (name.Equals("SEND"))
            {
                List<TexStatus> texInvoiceTypeList = _context.TexStatus.Where(p => p.name == name).ToList();
                if (texInvoiceTypeList != null && texInvoiceTypeList.Count > 0)
                {
                    return texInvoiceTypeList.First();
                }

                TexStatus invoiceType = new TexStatus();
                invoiceType.active_status = true;
                invoiceType.name = "SEND";
                _context.TexStatus.Update(invoiceType);
                await _context.SaveChangesAsync();
                return invoiceType;

            }

            else if (name.Equals("RASXOD"))
            {
                List<TexStatus> texInvoiceTypeList = _context.TexStatus.Where(p => p.name == name).ToList();
                if (texInvoiceTypeList != null && texInvoiceTypeList.Count > 0)
                {
                    return texInvoiceTypeList.First();
                }

                TexStatus invoiceType = new TexStatus();
                invoiceType.active_status = true;
                invoiceType.name = "RASXOD";
                _context.TexStatus.Update(invoiceType);
                await _context.SaveChangesAsync();
                return invoiceType;

            }
            else if (name.Equals("MOVEMENT_RECIVE"))
            {
                List<TexStatus> texInvoiceTypeList = _context.TexStatus.Where(p => p.name == name).ToList();
                if (texInvoiceTypeList != null && texInvoiceTypeList.Count > 0)
                {
                    return texInvoiceTypeList.First();
                }

                TexStatus invoiceType = new TexStatus();
                invoiceType.active_status = true;
                invoiceType.name = "MOVEMENT_RECIVE";
                _context.TexStatus.Update(invoiceType);
                await _context.SaveChangesAsync();
                return invoiceType;

            }
            else if (name.Equals("ORDER_ITEM_RECIPE"))
            {
                List<TexStatus> texInvoiceTypeList = _context.TexStatus.Where(p => p.name == name).ToList();
                if (texInvoiceTypeList != null && texInvoiceTypeList.Count > 0)
                {
                    return texInvoiceTypeList.First();
                }

                TexStatus invoiceType = new TexStatus();
                invoiceType.active_status = true;
                invoiceType.name = "ORDER_ITEM_RECIPE";
                _context.TexStatus.Update(invoiceType);
                await _context.SaveChangesAsync();
                return invoiceType;

            }
            else if (name.Equals("RECIVE"))
            {
                List<TexStatus> texInvoiceTypeList = _context.TexStatus.Where(p => p.name == name).ToList();
                if (texInvoiceTypeList != null && texInvoiceTypeList.Count > 0)
                {
                    return texInvoiceTypeList.First();
                }

                TexStatus invoiceType = new TexStatus();
                invoiceType.active_status = true;
                invoiceType.name = "RECIVE";
                _context.TexStatus.Update(invoiceType);
                await _context.SaveChangesAsync();
                return invoiceType;

            }
            else if (name.Equals("SIMPLE_PRODUCTION_PRODUCT"))
            {
                List<TexStatus> texInvoiceTypeList = _context.TexStatus.Where(p => p.name == name).ToList();
                if (texInvoiceTypeList != null && texInvoiceTypeList.Count > 0)
                {
                    return texInvoiceTypeList.First();
                }

                TexStatus invoiceType = new TexStatus();
                invoiceType.active_status = true;
                invoiceType.name = "SIMPLE_PRODUCTION_PRODUCT";
                _context.TexStatus.Update(invoiceType);
                await _context.SaveChangesAsync();
                return invoiceType;

            }
            else if (name.Equals("SIMPLE_PRODUCTION_PRODUCT_RESERVE"))
            {
                List<TexStatus> texInvoiceTypeList = _context.TexStatus.Where(p => p.name == name).ToList();
                if (texInvoiceTypeList != null && texInvoiceTypeList.Count > 0)
                {
                    return texInvoiceTypeList.First();
                }

                TexStatus invoiceType = new TexStatus();
                invoiceType.active_status = true;
                invoiceType.name = "SIMPLE_PRODUCTION_PRODUCT_RESERVE";
                _context.TexStatus.Update(invoiceType);
                await _context.SaveChangesAsync();
                return invoiceType;

            }
            else if (name.Equals("FOR_SERVICE_PRODUCT_RESERVE"))
            {
                List<TexStatus> texInvoiceTypeList = _context.TexStatus.Where(p => p.name == name).ToList();
                if (texInvoiceTypeList != null && texInvoiceTypeList.Count > 0)
                {
                    return texInvoiceTypeList.First();
                }

                TexStatus invoiceType = new TexStatus();
                invoiceType.active_status = true;
                invoiceType.name = "FOR_SERVICE_PRODUCT_RESERVE";
                _context.TexStatus.Update(invoiceType);
                await _context.SaveChangesAsync();
                return invoiceType;

            }
            else if (name.Equals("FOR_SERVICE_PRODUCT"))
            {
                List<TexStatus> texInvoiceTypeList = _context.TexStatus.Where(p => p.name == name).ToList();
                if (texInvoiceTypeList != null && texInvoiceTypeList.Count > 0)
                {
                    return texInvoiceTypeList.First();
                }

                TexStatus invoiceType = new TexStatus();
                invoiceType.active_status = true;
                invoiceType.name = "FOR_SERVICE_PRODUCT";
                _context.TexStatus.Update(invoiceType);
                await _context.SaveChangesAsync();
                return invoiceType;

            }
            return new TexStatus();
        }

        private async Task<TexInvoiceType> getInvoiceTypeMetod(string name)
        {
            if (name.Equals("BUY"))
            {
                List<TexInvoiceType> texInvoiceTypeList = _context.TexInvoiceType.Where(p => p.name == name).ToList();
                if (texInvoiceTypeList != null && texInvoiceTypeList.Count > 0)
                {
                    return texInvoiceTypeList.First();
                }

                TexInvoiceType invoiceType = new TexInvoiceType();
                invoiceType.active_status = true;
                invoiceType.name = "BUY";
                _context.TexInvoiceType.Update(invoiceType);
                await _context.SaveChangesAsync();
                return invoiceType;

            }
            else if (name.Equals("SALE"))
            {
                List<TexInvoiceType> texInvoiceTypeList = _context.TexInvoiceType.Where(p => p.name == name).ToList();
                if (texInvoiceTypeList != null && texInvoiceTypeList.Count > 0)
                {
                    return texInvoiceTypeList.First();
                }

                TexInvoiceType invoiceType = new TexInvoiceType();
                invoiceType.active_status = true;
                invoiceType.name = "SALE";
                _context.TexInvoiceType.Update(invoiceType);
                await _context.SaveChangesAsync();
                return invoiceType;
            }
            else if (name.Equals("RASXOD_FOR_MODEL"))
            {
                List<TexInvoiceType> texInvoiceTypeList = _context.TexInvoiceType.Where(p => p.name == name).ToList();
                if (texInvoiceTypeList != null && texInvoiceTypeList.Count > 0)
                {
                    return texInvoiceTypeList.First();
                }

                TexInvoiceType invoiceType = new TexInvoiceType();
                invoiceType.active_status = true;
                invoiceType.name = "RASXOD_FOR_MODEL";
                _context.TexInvoiceType.Update(invoiceType);
                await _context.SaveChangesAsync();
                return invoiceType;
            }
            else if (name.Equals("ORDER_ITEM_RECIPE_WITHOUT_INVOICE"))
            {
                List<TexInvoiceType> texInvoiceTypeList = _context.TexInvoiceType.Where(p => p.name == name).ToList();
                if (texInvoiceTypeList != null && texInvoiceTypeList.Count > 0)
                {
                    return texInvoiceTypeList.First();
                }

                TexInvoiceType invoiceType = new TexInvoiceType();
                invoiceType.active_status = true;
                invoiceType.name = "ORDER_ITEM_RECIPE_WITHOUT_INVOICE";
                _context.TexInvoiceType.Update(invoiceType);
                await _context.SaveChangesAsync();
                return invoiceType;
            }
            else if (name.Equals("MOVEMENT"))
            {

                List<TexInvoiceType> texInvoiceTypeList = _context.TexInvoiceType.Where(p => p.name == name).ToList();
                if (texInvoiceTypeList != null && texInvoiceTypeList.Count > 0)
                {
                    return texInvoiceTypeList.First();
                }

                TexInvoiceType invoiceType = new TexInvoiceType();
                invoiceType.active_status = true;
                invoiceType.name = "MOVEMENT";
                _context.TexInvoiceType.Update(invoiceType);
                await _context.SaveChangesAsync();
                return invoiceType;
            }
            else if (name.Equals("MOVEMENT_RECIVE"))
            {

                List<TexInvoiceType> texInvoiceTypeList = _context.TexInvoiceType.Where(p => p.name == name).ToList();
                if (texInvoiceTypeList != null && texInvoiceTypeList.Count > 0)
                {
                    return texInvoiceTypeList.First();
                }

                TexInvoiceType invoiceType = new TexInvoiceType();
                invoiceType.active_status = true;
                invoiceType.name = "MOVEMENT_RECIVE";
                _context.TexInvoiceType.Update(invoiceType);
                await _context.SaveChangesAsync();
                return invoiceType;
            }
            else if (name.Equals("SIMPLE_PRODUCTION"))
            {
                List<TexInvoiceType> texInvoiceTypeList = _context.TexInvoiceType.Where(p => p.name == name).ToList();
                if (texInvoiceTypeList != null && texInvoiceTypeList.Count > 0)
                {
                    return texInvoiceTypeList.First();
                }

                TexInvoiceType invoiceType = new TexInvoiceType();
                invoiceType.active_status = true;
                invoiceType.name = "SIMPLE_PRODUCTION";
                _context.TexInvoiceType.Update(invoiceType);
                await _context.SaveChangesAsync();
                return invoiceType;
            }
            else if (name.Equals("FOR_SERVICE"))
            {
                List<TexInvoiceType> texInvoiceTypeList = _context.TexInvoiceType.Where(p => p.name == name).ToList();
                if (texInvoiceTypeList != null && texInvoiceTypeList.Count > 0)
                {
                    return texInvoiceTypeList.First();
                }

                TexInvoiceType invoiceType = new TexInvoiceType();
                invoiceType.active_status = true;
                invoiceType.name = "FOR_SERVICE";
                _context.TexInvoiceType.Update(invoiceType);
                await _context.SaveChangesAsync();
                return invoiceType;
            }

            return new TexInvoiceType();
        }

        private async Task<TexInvoice> addForServiceInvoiceMetod(TexInvoice invoice)
        {
            if (invoice.invoiceItemList == null || invoice.invoiceItemList.Count == 0)
            {
                return NotFoundMetod("Any product not reserved");
            }
            TexInvoiceItem productItem = invoice.simple_production_item;
            if (productItem == null)
            {
                return NotFoundMetod("Any product not reserved");
            }
            try
            {
                if (invoice != null)
                {
                    List<TexInvoiceItem> texInvoiceItemList = invoice.invoiceItemList;
                    invoice.active_status = true;
                    TexInvoiceType invoiceType = await getInvoiceTypeMetod("FOR_SERVICE");
                    if (invoiceType == null)
                    {
                        return NotFoundMetod("Invoice type not found");
                    }
                    invoice.invoiceType = invoiceType;
                    invoice.invoice_type_id = invoiceType.id;
                    invoice.status_type_name = invoiceType.name;

                    //invoice  created 
                    try
                    {
                        _context.TexInvoice.Update(invoice);
                        await _context.SaveChangesAsync();
                    }
                    catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
                    {
                        if (invoice.id > 0)
                        {
                            _context.TexInvoice.Remove(invoice);
                            await _context.SaveChangesAsync();
                        }
                        return NotFoundMetod(e?.InnerException?.Message);

                    }
                    catch (Exception e)
                    {
                        return NotFoundMetod(e?.InnerException?.Message);
                    }

                    TexStatus item_status = await getInvoiceStatusByNameMetod("FOR_SERVICE_PRODUCT_RESERVE");
                    TexStatus main_product_status = await getInvoiceStatusByNameMetod("FOR_SERVICE_PRODUCT");


                    foreach (TexInvoiceItem item in texInvoiceItemList)
                    {
                        item.invoiceType = invoiceType;
                        item.invoice_type_id = invoiceType.id;
                        item.status_type_name = invoiceType.name;
                        item.invoice = invoice;
                        item.invoice_id = invoice.id;
                        item.item_status_id = item_status.id;
                    }
                    // add product
                    productItem.invoiceType = invoiceType;
                    productItem.invoice_type_id = invoiceType.id;
                    productItem.status_type_name = invoiceType.name;
                    productItem.invoice = invoice;
                    productItem.invoice_id = invoice.id;
                    productItem.item_status_id = main_product_status.id;
                    texInvoiceItemList.Add(productItem);

                    //need to create invoice 
                    try
                    {
                        _context.TexInvoiceItem.UpdateRange(texInvoiceItemList);
                        await _context.SaveChangesAsync();

                    }
                    catch (DbUpdateException e)
                    {
                        if (invoice.id > 0)
                        {
                            _context.TexInvoice.Remove(invoice);
                            await _context.SaveChangesAsync();
                        }
                        return NotFoundMetod(e?.InnerException?.Message);

                    }
                    catch (Exception e)
                    {
                        return NotFoundMetod(e?.InnerException?.Message);
                    }

                    return invoice;

                }
            }
            catch (DbUpdateException e)
            {
                if (invoice.id > 0)
                {
                    _context.TexInvoice.Remove(invoice);
                    await _context.SaveChangesAsync();
                }
                return NotFoundMetod(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFoundMetod(e?.InnerException?.Message);
            }


            return new TexInvoice();
        }

        private TexInvoice NotFoundMetod(string v)
        {
            throw new NullReferenceException(v);
        }

        private List<TexInvoiceItem> NotFound_itemMetod(string v)
        {
            throw new NullReferenceException(v);
        }

        private async Task<TexInvoice> addSimpleProductionInvoiceMetod(TexInvoice invoice)
        {

            invoice.accepted_user = true;
            if (invoice.invoiceItemList == null || invoice.invoiceItemList.Count == 0)
            {
                return NotFoundMetod("Товары не зарезервированы");
            }
            TexInvoiceItem productItem = invoice.simple_production_item;
            if (productItem == null)
            {
                return NotFoundMetod("Товары не зарезервированы");
            }
            try
            {
                if (invoice != null)
                {
                    List<TexInvoiceItem> texInvoiceItemList = invoice.invoiceItemList;
                    invoice.active_status = true;
                    TexInvoiceType invoiceType = await getInvoiceTypeMetod("SIMPLE_PRODUCTION");
                    invoice.invoiceType = invoiceType;
                    invoice.invoice_type_id = invoiceType.id;
                    invoice.status_type_name = invoiceType.name;

                    //invoice  created 
                    try
                    {
                        _context.TexInvoice.Update(invoice);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException e)
                    {
                        if (invoice.id > 0)
                        {
                            _context.TexInvoice.Remove(invoice);
                            await _context.SaveChangesAsync();
                        }
                        return NotFoundMetod(e?.InnerException?.Message);

                    }
                    catch (Exception e)
                    {
                        return NotFoundMetod(e?.InnerException?.Message);
                    }

                    TexStatus item_status = await getInvoiceStatusByNameMetod("SIMPLE_PRODUCTION_PRODUCT_RESERVE");
                    TexStatus main_product_status = await getInvoiceStatusByNameMetod("SIMPLE_PRODUCTION_PRODUCT");

                    List<TexInvoiceItem> used_invoice_item_list = new List<TexInvoiceItem>();

                    foreach (TexInvoiceItem item in texInvoiceItemList)
                    {
                        item.invoiceType = invoiceType;
                        item.invoice_type_id = invoiceType.id;
                        item.status_type_name = "SIMPLE_PRODUCTION_PRODUCT_RESERVE";
                        item.invoice = invoice;
                        item.invoice_id = invoice.id;
                        item.item_status_id = item_status.id;
                        item.ostatka = item.qty;
                        if (item.main_item_id != null)
                        {
                            long main_item_id = item.main_item_id.GetValueOrDefault();
                            TexInvoiceItem texInvoiceItem = await _context.TexInvoiceItem.FindAsync(main_item_id);
                            if (texInvoiceItem != null)
                            {
                                if (texInvoiceItem.ostatka >= item.qty)
                                {
                                    texInvoiceItem.ostatka = texInvoiceItem.ostatka - item.qty;
                                    used_invoice_item_list.Add(texInvoiceItem);

                                }
                                else
                                {
                                    await removeInvoiceWithItemsMetod(invoice.id);
                                    return NotFoundMetod("Недостаточно продукта");
                                }
                            }
                            else
                            {
                                await removeInvoiceWithItemsMetod(invoice.id);
                                return NotFoundMetod("Основной продукт не найден");
                            }

                        }
                        else
                        {
                            await removeInvoiceWithItemsMetod(invoice.id);
                            return NotFoundMetod("Основной продукт не найден");

                        }
                    }
                    // add product
                    productItem.invoiceType = invoiceType;
                    productItem.invoice_type_id = invoiceType.id;
                    productItem.status_type_name = invoiceType.name;
                    productItem.invoice = invoice;
                    productItem.invoice_id = invoice.id;
                    productItem.ostatka = productItem.qty;
                    productItem.item_status_id = main_product_status.id;
                    texInvoiceItemList.Add(productItem);

                    //need to create invoice 
                    try
                    {
                        _context.TexInvoiceItem.UpdateRange(texInvoiceItemList);
                        await _context.SaveChangesAsync();

                    }
                    catch (DbUpdateException e)
                    {
                        if (invoice.id > 0)
                        {
                            _context.TexInvoice.Remove(invoice);
                            await _context.SaveChangesAsync();
                        }
                        return NotFoundMetod(e?.InnerException?.Message);

                    }
                    catch (Exception e)
                    {
                        return NotFoundMetod(e?.InnerException?.Message);
                    }


                    //all is success need to remove all
                    try
                    {
                        _context.TexInvoiceItem.UpdateRange(used_invoice_item_list);
                        await _context.SaveChangesAsync();

                    }
                    catch (DbUpdateException e)
                    {
                        await removeInvoiceWithItemsMetod(invoice.id);
                        return NotFoundMetod(e?.InnerException?.Message);

                    }
                    catch (Exception e)
                    {
                        await removeInvoiceWithItemsMetod(invoice.id);
                        return NotFoundMetod(e?.InnerException?.Message);
                    }

                    return invoice;

                }
            }
            catch (DbUpdateException e)
            {
                if (invoice.id > 0)
                {
                    _context.TexInvoice.Remove(invoice);
                    await _context.SaveChangesAsync();
                }
                return NotFoundMetod(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFoundMetod(e?.InnerException?.Message);
            }


            return new TexInvoice();
        }
        private async Task<TexInvoice> addMovementInvoiceSendMetod(TexInvoice invoice)
        {
            if (invoice.invoiceItemList == null || invoice.invoiceItemList.Count == 0)
            {
                return NotFoundMetod("Any product not reserved");
            }
            try
            {
                if (invoice != null)
                {
                    List<TexInvoiceItem> texInvoiceItemList = invoice.invoiceItemList;
                    invoice.active_status = true;
                    TexInvoiceType invoiceType = await getInvoiceTypeMetod("MOVEMENT");
                    invoice.invoiceType = invoiceType;
                    invoice.invoice_type_id = invoiceType.id;
                    invoice.status_type_name = invoiceType.name;
                    invoice.invoice_filter_status = "SEND";

                    //invoice  created 
                    try
                    {
                        _context.TexInvoice.Update(invoice);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException e)
                    {
                        if (invoice.id > 0)
                        {
                            _context.TexInvoice.Remove(invoice);
                            await _context.SaveChangesAsync();
                        }
                        return NotFoundMetod(e?.InnerException?.Message);

                    }
                    catch (Exception e)
                    {
                        return NotFoundMetod(e?.InnerException?.Message);
                    }
                    TexStatus item_status = await getInvoiceStatusByNameMetod("SEND");

                    foreach (TexInvoiceItem item in texInvoiceItemList)
                    {
                        item.invoiceType = invoiceType;
                        item.invoice_type_id = invoiceType.id;
                        item.status_type_name = invoiceType.name;
                        item.invoice = invoice;
                        item.invoice_id = invoice.id;
                        item.item_status_id = item_status.id;
                    }

                    //need to create invoice 
                    try
                    {
                        _context.TexInvoiceItem.UpdateRange(texInvoiceItemList);
                        await _context.SaveChangesAsync();

                    }
                    catch (DbUpdateException e)
                    {
                        if (invoice.id > 0)
                        {
                            _context.TexInvoice.Remove(invoice);
                            await _context.SaveChangesAsync();
                        }
                        return NotFoundMetod(e?.InnerException?.Message);

                    }
                    catch (Exception e)
                    {
                        return NotFoundMetod(e?.InnerException?.Message);
                    }

                    return invoice;

                }
            }
            catch (DbUpdateException e)
            {
                if (invoice.id > 0)
                {
                    _context.TexInvoice.Remove(invoice);
                    await _context.SaveChangesAsync();
                }
                return NotFoundMetod(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFoundMetod(e?.InnerException?.Message);
            }


            return new TexInvoice();
        }
        private async Task<TexInvoice> addBuyInvoiceMetod(TexInvoice invoice)
        {

            if (invoice.invoiceItemList == null || invoice.invoiceItemList.Count == 0)
            {
                return NotFoundMetod("Ни один элемент не найден");
            }
            try
            {
                if (invoice != null)
                {
                    List<TexInvoiceItem> texInvoiceItemList = invoice.invoiceItemList;
                    invoice.active_status = true;
                    TexInvoiceType invoiceType = await getInvoiceTypeMetod("BUY");
                    invoice.invoiceType = invoiceType;
                    invoice.invoice_type_id = invoiceType.id;
                    invoice.status_type_name = invoiceType.name;

                    //invoice  created 
                    try
                    {
                        _context.TexInvoice.Update(invoice);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException e)
                    {
                        if (invoice.id > 0)
                        {
                            _context.TexInvoice.Remove(invoice);
                            await _context.SaveChangesAsync();
                        }
                        return NotFoundMetod(e?.InnerException?.Message);

                    }
                    catch (Exception e)
                    {
                        return NotFoundMetod(e?.InnerException?.Message);
                    }
                    TexStatus item_status = await getInvoiceStatusByNameMetod("SAVE");

                    foreach (TexInvoiceItem item in texInvoiceItemList)
                    {
                        item.invoiceType = invoiceType;
                        item.invoice_type_id = invoiceType.id;
                        item.status_type_name = invoiceType.name;
                        item.invoice = invoice;
                        item.invoice_id = invoice.id;
                        item.item_status_id = item_status.id;
                    }

                    //need to create invoice 
                    try
                    {
                        _context.TexInvoiceItem.UpdateRange(texInvoiceItemList);
                        await _context.SaveChangesAsync();

                    }
                    catch (DbUpdateException e)
                    {
                        if (invoice.id > 0)
                        {
                            _context.TexInvoice.Remove(invoice);
                            await _context.SaveChangesAsync();
                        }
                        return NotFoundMetod(e?.InnerException?.Message);

                    }
                    catch (Exception e)
                    {
                        return NotFoundMetod(e?.InnerException?.Message);
                    }

                    return invoice;

                }
            }
            catch (DbUpdateException e)
            {
                if (invoice.id > 0)
                {
                    _context.TexInvoice.Remove(invoice);
                    await _context.SaveChangesAsync();
                }
                return NotFoundMetod(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFoundMetod(e?.InnerException?.Message);
            }


            return new TexInvoice();

        }



        private async Task<TexInvoice> addRasxodModelInvoiceMetod(TexInvoice invoice)
        {
            invoice.accepted_user = true;
            if (invoice.invoiceItemList == null || invoice.invoiceItemList.Count == 0)
            {
                return NotFoundMetod("Any product not reserved");
            }
            try
            {
                if (invoice != null)
                {
                    List<TexInvoiceItem> texInvoiceItemList = invoice.invoiceItemList;
                    invoice.active_status = true;
                    TexInvoiceType invoiceType = await getInvoiceTypeMetod("RASXOD_FOR_MODEL");
                    invoice.invoiceType = invoiceType;
                    invoice.invoice_type_id = invoiceType.id;
                    invoice.status_type_name = invoiceType.name;

                    //invoice  created 
                    try
                    {
                        _context.TexInvoice.Update(invoice);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException e)
                    {
                        if (invoice.id > 0)
                        {
                            _context.TexInvoice.Remove(invoice);
                            await _context.SaveChangesAsync();
                        }
                        return NotFoundMetod(e?.InnerException?.Message);

                    }
                    catch (Exception e)
                    {
                        return NotFoundMetod(e?.InnerException?.Message);
                    }
                    TexStatus item_status = await getInvoiceStatusByNameMetod("RASXOD");

                    List<TexInvoiceItem> used_invoice_item_list = new List<TexInvoiceItem>();

                    foreach (TexInvoiceItem item in texInvoiceItemList)
                    {
                        item.invoiceType = invoiceType;
                        item.invoice_type_id = invoiceType.id;
                        item.status_type_name = invoiceType.name;
                        item.invoice = invoice;
                        item.invoice_id = invoice.id;
                        item.item_status_id = item_status.id;
                        item.ostatka = item.qty;
                        if (item.main_item_id != null)
                        {
                            long main_item_id = item.main_item_id.GetValueOrDefault();
                            TexInvoiceItem texInvoiceItem = await _context.TexInvoiceItem.FindAsync(main_item_id);
                            if (texInvoiceItem != null)
                            {
                                if (texInvoiceItem.ostatka >= item.qty)
                                {
                                    texInvoiceItem.ostatka = texInvoiceItem.ostatka - item.qty;
                                    used_invoice_item_list.Add(texInvoiceItem);

                                }
                                else
                                {
                                    await removeInvoiceWithItemsMetod(invoice.id);
                                    return NotFoundMetod("Not enought product");
                                }
                            }
                            else
                            {
                                await removeInvoiceWithItemsMetod(invoice.id);
                                return NotFoundMetod("Main item not selected");
                            }

                        }
                        else
                        {
                            await removeInvoiceWithItemsMetod(invoice.id);
                            return NotFoundMetod("Main item not selected");

                        }
                    }




                    //need to create invoice 
                    try
                    {
                        _context.TexInvoiceItem.UpdateRange(texInvoiceItemList);
                        await _context.SaveChangesAsync();

                    }
                    catch (DbUpdateException e)
                    {
                        await removeInvoiceWithItemsMetod(invoice.id);
                        return NotFoundMetod(e?.InnerException?.Message);

                    }
                    catch (Exception e)
                    {
                        await removeInvoiceWithItemsMetod(invoice.id);
                        return NotFoundMetod(e?.InnerException?.Message);
                    }

                    //all is success need to remove all
                    try
                    {
                        _context.TexInvoiceItem.UpdateRange(used_invoice_item_list);
                        await _context.SaveChangesAsync();

                    }
                    catch (DbUpdateException e)
                    {
                        await removeInvoiceWithItemsMetod(invoice.id);
                        return NotFoundMetod(e?.InnerException?.Message);

                    }
                    catch (Exception e)
                    {
                        await removeInvoiceWithItemsMetod(invoice.id);
                        return NotFoundMetod(e?.InnerException?.Message);
                    }


                    return invoice;

                }
            }
            catch (DbUpdateException e)
            {
                if (invoice.id > 0)
                {
                    _context.TexInvoice.Remove(invoice);
                    await _context.SaveChangesAsync();
                }
                return NotFoundMetod(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFoundMetod(e?.InnerException?.Message);
            }


            return new TexInvoice();
        }

        private async Task<TexInvoice> addSaleInvoiceMetod(TexInvoice invoice)
        {
            invoice.accepted_user = true;
            if (invoice.invoiceItemList == null || invoice.invoiceItemList.Count == 0)
            {
                return NotFoundMetod("Any product not reserved");
            }
            try
            {
                if (invoice != null)
                {
                    List<TexInvoiceItem> texInvoiceItemList = invoice.invoiceItemList;
                    invoice.active_status = true;
                    TexInvoiceType invoiceType = await getInvoiceTypeMetod("SALE");
                    invoice.invoiceType = invoiceType;
                    invoice.invoice_type_id = invoiceType.id;
                    invoice.status_type_name = invoiceType.name;

                    //invoice  created 
                    try
                    {
                        _context.TexInvoice.Update(invoice);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException e)
                    {
                        if (invoice.id > 0)
                        {
                            _context.TexInvoice.Remove(invoice);
                            await _context.SaveChangesAsync();
                        }
                        return NotFoundMetod(e?.InnerException?.Message);

                    }
                    catch (Exception e)
                    {
                        return NotFoundMetod(e?.InnerException?.Message);
                    }
                    TexStatus item_status = await getInvoiceStatusByNameMetod("SAVE");

                    List<TexInvoiceItem> used_invoice_item_list = new List<TexInvoiceItem>();

                    foreach (TexInvoiceItem item in texInvoiceItemList)
                    {
                        item.invoiceType = invoiceType;
                        item.invoice_type_id = invoiceType.id;
                        item.status_type_name = invoiceType.name;
                        item.invoice = invoice;
                        item.invoice_id = invoice.id;
                        item.item_status_id = item_status.id;
                        item.ostatka = item.qty;
                        if (item.main_item_id != null)
                        {
                            long main_item_id = item.main_item_id.GetValueOrDefault();
                            TexInvoiceItem texInvoiceItem = await _context.TexInvoiceItem.FindAsync(main_item_id);
                            if (texInvoiceItem != null)
                            {
                                if (texInvoiceItem.ostatka >= item.qty)
                                {
                                    texInvoiceItem.ostatka = texInvoiceItem.ostatka - item.qty;
                                    used_invoice_item_list.Add(texInvoiceItem);

                                }
                                else
                                {
                                    await removeInvoiceWithItemsMetod(invoice.id);
                                    return NotFoundMetod("Not enought product");
                                }
                            }
                            else
                            {
                                await removeInvoiceWithItemsMetod(invoice.id);
                                return NotFoundMetod("Main item not selected");
                            }

                        }
                        else
                        {
                            await removeInvoiceWithItemsMetod(invoice.id);
                            return NotFoundMetod("Main item not selected");

                        }
                    }




                    //need to create invoice 
                    try
                    {
                        _context.TexInvoiceItem.UpdateRange(texInvoiceItemList);
                        await _context.SaveChangesAsync();

                    }
                    catch (DbUpdateException e)
                    {
                        await removeInvoiceWithItemsMetod(invoice.id);
                        return NotFoundMetod(e?.InnerException?.Message);

                    }
                    catch (Exception e)
                    {
                        await removeInvoiceWithItemsMetod(invoice.id);
                        return NotFoundMetod(e?.InnerException?.Message);
                    }

                    //all is success need to remove all
                    try
                    {
                        _context.TexInvoiceItem.UpdateRange(used_invoice_item_list);
                        await _context.SaveChangesAsync();

                    }
                    catch (DbUpdateException e)
                    {
                        await removeInvoiceWithItemsMetod(invoice.id);
                        return NotFoundMetod(e?.InnerException?.Message);

                    }
                    catch (Exception e)
                    {
                        await removeInvoiceWithItemsMetod(invoice.id);
                        return NotFoundMetod(e?.InnerException?.Message);
                    }


                    return invoice;

                }
            }
            catch (DbUpdateException e)
            {
                if (invoice.id > 0)
                {
                    _context.TexInvoice.Remove(invoice);
                    await _context.SaveChangesAsync();
                }
                return NotFoundMetod(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFoundMetod(e?.InnerException?.Message);
            }


            return new TexInvoice();
        }

        private async Task<List<TexInvoiceItem>> addReserveOrderItemRecipesMetod(List<TexInvoiceItem> texInvoiceItemList)
        {
            try
            {

                TexStatus item_status = await getInvoiceStatusByNameMetod("ORDER_ITEM_RECIPE");
                TexInvoiceType invoiceType = await getInvoiceTypeMetod("ORDER_ITEM_RECIPE_WITHOUT_INVOICE");

                foreach (TexInvoiceItem item in texInvoiceItemList)
                {
                    item.invoiceType = invoiceType;
                    item.invoice_type_id = invoiceType.id;
                    item.status_type_name = invoiceType.name;
                    item.item_status_id = item_status.id;
                }

                _context.TexInvoiceItem.UpdateRange(texInvoiceItemList);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException e)
            {

                return NotFound_itemMetod(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFound_itemMetod(e?.InnerException?.Message);
            }

            return texInvoiceItemList;
        }

        private async Task<bool> removeInvoiceWithItemsMetod(long invoice_id)

        {
            try
            {
                List<TexInvoiceItem> texInvoiceItems = await _context.TexInvoiceItem.Where(p => p.invoice_id == invoice_id).ToListAsync();
                if (texInvoiceItems != null && texInvoiceItems.Count > 0)
                {
                    _context.TexInvoiceItem.RemoveRange(texInvoiceItems);
                    await _context.SaveChangesAsync();
                }
                TexInvoice texInvoice = await _context.TexInvoice.FindAsync(invoice_id);
                if (texInvoice != null)
                {
                    _context.TexInvoice.Remove(texInvoice);
                    await _context.SaveChangesAsync();
                }

            }
            catch (DbUpdateException e)
            {

                throw new NullReferenceException(e?.InnerException?.Message);


            }
            catch (Exception e)
            {
                throw new NullReferenceException(e?.InnerException?.Message);
            }

            return true;
        }
    }
}
