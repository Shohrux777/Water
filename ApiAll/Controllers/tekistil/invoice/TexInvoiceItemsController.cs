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
    public class TexInvoiceItemsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexInvoiceItemsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexInvoiceItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexInvoiceItem>>> GetTexInvoiceItem()
        {
            return await _context.TexInvoiceItem.ToListAsync();
        }

        [HttpGet("getRealProductListPagination")]
        public async Task<ActionResult<TexPaginationModel>> getRealProductListPagination( [FromQuery] int size, [FromQuery] int page, [FromQuery] String filter)
        {
            List<TexRealProductRemain>  realProductList = await _context.TexRealProductRemains.FromSqlRaw("" +
                "  select i.id as invoice_item_id, p.name || '- '|| text(inv.date) as product_name,p.id as product_id,i.ostatka as ostatka,c.name as color_name,c.id as color_id, " +
                "  e.name as unitmeasurment_name, e.id as unitmeasurment_id, i.price as price, sv.name as suroviy_vid_name, sv.id as suroviy_vid_id, p.name as real_product_name, text(inv.date) as date_str, " +
                "  gc.name as guscolor_name, gc.id as guscolor_id, ew.name as extra_work_name, ew.id as extra_work_id, mp.name as main_proccess_name, mp.id as main_proccess_id, u.name as upakovka_name, u.id as upakovka_id, s.name as sort_name, s.id as sort_id" +
                "  from tex_unit_measurment e, tex_product p left join tex_category ct on p.category_id = ct.id," +
                "  tex_invoice inv left join tex_sklad sk on sk.id = inv.sklad_id," +
                "  tex_invoice_item i  left JOIN tex_color c ON c.id = i.color_id left JOIN tex_guscolor gc ON gc.id = i.gus_color_id left join  tex_suroviy_vid sv on" +
                "  sv.id = i.suroviy_vid_id left join tex_main_prossess mp on mp.id = i.main_proccess_id left join tex_extra_work ew on ew.id = i.extra_work_id" +
                "  left join tex_sort s on s.id = i.sort_id left join tex_upakovka u on u.id = i.upakovka_id" +
                "  where p.id = i.product_id and i.status_type_name = 'BUY' and inv.id = i.invoice_id and i.ostatka > 0 and e.id = p.unitmeasurment_id and lower(p.name) like '%%' " + filter + "order by i.id desc limit  " + size + "" +
                " ").Skip(page * size ).Take(size).ToListAsync();

            TexPaginationModel paginationModel = new TexPaginationModel();
            if (realProductList == null)
            {
                realProductList = new List<TexRealProductRemain>();
            }
            paginationModel.items_list = JArray.FromObject(realProductList);
            paginationModel.items_count = await _context.TexRealProductRemains.FromSqlRaw("" +
                "  select i.id as invoice_item_id, p.name || '- '|| text(inv.date) as product_name,p.id as product_id,i.ostatka as ostatka,c.name as color_name,c.id as color_id, " +
                "  e.name as unitmeasurment_name, e.id as unitmeasurment_id, i.price as price, sv.name as suroviy_vid_name, sv.id as suroviy_vid_id, p.name as real_product_name, text(inv.date) as date_str, " +
                "  gc.name as guscolor_name, gc.id as guscolor_id, ew.name as extra_work_name, ew.id as extra_work_id, mp.name as main_proccess_name, mp.id as main_proccess_id, u.name as upakovka_name, u.id as upakovka_id, s.name as sort_name, s.id as sort_id" +
                "  from tex_unit_measurment e, tex_product p left join tex_category ct on p.category_id = ct.id," +
                "  tex_invoice inv left join tex_sklad sk on sk.id = inv.sklad_id," +
                "  tex_invoice_item i  left JOIN tex_color c ON c.id = i.color_id left JOIN tex_guscolor gc ON gc.id = i.gus_color_id left join  tex_suroviy_vid sv on" +
                "  sv.id = i.suroviy_vid_id left join tex_main_prossess mp on mp.id = i.main_proccess_id left join tex_extra_work ew on ew.id = i.extra_work_id" +
                "  left join tex_sort s on s.id = i.sort_id left join tex_upakovka u on u.id = i.upakovka_id" +
                "  where p.id = i.product_id and i.status_type_name = 'BUY' and inv.id = i.invoice_id and i.ostatka > 0 and e.id = p.unitmeasurment_id and lower(p.name) like '%%' " + filter + "order by i.id desc limit  " + size + "" +
                " ").CountAsync();
            paginationModel.current_item_count = realProductList.Count();
            paginationModel.current_page = page;
            return paginationModel;

          
        }

        [HttpGet("getSearchRealProductListForOrder")]
        public async Task<ActionResult<IEnumerable<TexRealProductRemain>>> getSearchRealProductListForOrder([FromQuery] String name, [FromQuery] int result_count, [FromQuery] String filter,[FromQuery] long sklad_id,[FromQuery] long company_id)
        {
            String sql_filter = "";
            if (name != null)
            {
                name = name.ToLower();
            }
            if (sklad_id > 0 && company_id > 0) {
                sql_filter = " and inv.sklad_id = " + sklad_id + " and (inv.filial_id = "+company_id+ " || inv.contraget_id = "+company_id+ " || inv.main_company_id ="+company_id+")  ";
            }

            if (sklad_id > 0 && company_id == 0)
            {
                sql_filter = "and inv.sklad_id = " + sklad_id;
            }

            try
            {
                List< TexRealProductRemain > item_list = await _context.TexRealProductRemains.FromSqlRaw("" +
                "  select i.id as invoice_item_id, p.name || '- '|| text(inv.date) as product_name,p.id as product_id,i.ostatka as ostatka,c.name as color_name,c.id as color_id, " +
                "  e.name as unitmeasurment_name, e.id as unitmeasurment_id, i.price as price, sv.name as suroviy_vid_name, sv.id as suroviy_vid_id, p.name as real_product_name, text(inv.date) as date_str, " +
                "  gc.name as guscolor_name, gc.id as guscolor_id, ew.name as extra_work_name, ew.id as extra_work_id, mp.name as main_proccess_name, mp.id as main_proccess_id, u.name as upakovka_name, u.id as upakovka_id, s.name as sort_name, s.id as sort_id" +
                "  from tex_unit_measurment e, tex_product p left join tex_category ct on p.category_id = ct.id," +
                "  tex_invoice inv left join tex_sklad sk on sk.id = inv.sklad_id," +
                "  tex_invoice_item i  left JOIN tex_color c ON c.id = i.color_id left JOIN tex_guscolor gc ON gc.id = i.gus_color_id left join  tex_suroviy_vid sv on" +
                "  sv.id = i.suroviy_vid_id left join tex_main_prossess mp on mp.id = i.main_proccess_id left join tex_extra_work ew on ew.id = i.extra_work_id" +
                "  left join tex_sort s on s.id = i.sort_id left join tex_upakovka u on u.id = i.upakovka_id" +
                "  where p.id = i.product_id and i.status_type_name = 'BUY' and inv.id = i.invoice_id and i.ostatka > 0 and e.id = p.unitmeasurment_id and lower(p.name) like '%" + name.Trim() + "%' " + sql_filter + "  " + filter + " order by i.id desc limit  " + result_count + "" +
                " ").ToListAsync();

                if (item_list != null && item_list.Count() > 0) {
                    foreach (TexRealProductRemain it in item_list) {
                        it.invoiceItem_fake = await _context.TexInvoiceItem.FindAsync(it.invoice_item_id);
                        if (it.invoiceItem_fake != null && it.invoiceItem_fake.id > 0) {
                            it.invoiceItem_fake.product = await _context.TexProduct.FindAsync(it.invoiceItem_fake.product_id);
                        }
                    }


                }

                return item_list;
            }
            catch (DbUpdateException e)
            {
                return NotFound(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFound(e?.InnerException?.Message);
            }
        }


        [HttpGet("getSearchRealProductList")]
        public async Task<ActionResult<IEnumerable<TexRealProductRemain>>> getSearchRealProductList([FromQuery] String name,[FromQuery] int result_count,[FromQuery] String filter)
        {
            if (name == null) {
                name = "";
            }

            if (name != null) {
                name = name.ToLower();
            }
            if (name.Trim().Equals("null")) {
                name = "";
            }

            return await _context.TexRealProductRemains.FromSqlRaw("" +
                "  select i.id as invoice_item_id, p.name || '- '|| text(inv.date) as product_name,p.id as product_id,i.ostatka as ostatka,c.name as color_name,c.id as color_id, " +
                "  e.name as unitmeasurment_name, e.id as unitmeasurment_id, i.price as price, sv.name as suroviy_vid_name, sv.id as suroviy_vid_id, p.name as real_product_name, text(inv.date) as date_str, " +
                "  gc.name as guscolor_name, gc.id as guscolor_id, ew.name as extra_work_name, ew.id as extra_work_id, mp.name as main_proccess_name, mp.id as main_proccess_id, u.name as upakovka_name, u.id as upakovka_id, s.name as sort_name, s.id as sort_id" +
                "  from tex_unit_measurment e, tex_product p left join tex_category ct on p.category_id = ct.id," +
                "  tex_invoice inv left join tex_sklad sk on sk.id = inv.sklad_id," +
                "  tex_invoice_item i  left JOIN tex_color c ON c.id = i.color_id left JOIN tex_guscolor gc ON gc.id = i.gus_color_id left join  tex_suroviy_vid sv on" +
                "  sv.id = i.suroviy_vid_id left join tex_main_prossess mp on mp.id = i.main_proccess_id left join tex_extra_work ew on ew.id = i.extra_work_id" +
                "  left join tex_sort s on s.id = i.sort_id left join tex_upakovka u on u.id = i.upakovka_id" +
                "  where p.id = i.product_id and i.status_type_name = 'BUY' and inv.id = i.invoice_id and i.ostatka > 0 and e.id = p.unitmeasurment_id and lower(p.name) like '%"+ name.Trim() + "%' " + filter + " order by i.id desc limit  " + result_count + "" +
                " ").ToListAsync();
        }

        // GET: api/TexInvoiceItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexInvoiceItem>> GetTexInvoiceItem(long id)
        {
            var texInvoiceItem = await _context.TexInvoiceItem.FindAsync(id);

            if (texInvoiceItem == null)
            {
                return NotFound();
            }

            return texInvoiceItem;
        }

        [HttpGet("getFullInfoSimpleProductionInvoice")]
        public async Task<ActionResult<TexInvoice>> getFullInfoSimpleProductionInvoice([FromQuery]long invoice_id)
        {
            var texInvoiceList = await _context.TexInvoice
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
                .Where(p=>p.id==invoice_id).ToListAsync();

            if (texInvoiceList == null && texInvoiceList.Count == 0)
            {
                return NotFound("Счет не найден");
            }
            TexInvoice texInvoice = texInvoiceList.First();
            List<TexInvoiceItem> texInvoiceItems = await _context.TexInvoiceItem
                .Where(p => p.invoice_id == texInvoice.id && p.main_item_id > 0)
                .Include(p => p.color)
                .Include(p => p.colorvariant)
                .Include(p => p.extrawork)
                .Include(p => p.guscolor)
                .Include(p => p.invoiceType)
                .Include(p => p.mainProccess)
                .Include(p => p.product)
                .Include(p => p.sort)
                .Include(p => p.status)
                .Include(p => p.suroviyVid)
                .Include(p => p.upakovka)
                .ToListAsync();
            texInvoice.invoiceItemList = texInvoiceItems;

            List<TexInvoiceItem> simple_production_inv_item = await _context.TexInvoiceItem
                .Where(p => p.invoice_id == texInvoice.id && p.main_item_id == null)
                .Include(p => p.color)
                .Include(p => p.colorvariant)
                .Include(p => p.extrawork)
                .Include(p => p.guscolor)
                .Include(p => p.invoiceType)
                .Include(p => p.mainProccess)
                .Include(p => p.product)
                .Include(p => p.sort)
                .Include(p => p.status)
                .Include(p => p.suroviyVid)
                .Include(p => p.upakovka)
                .ToListAsync();

            if (simple_production_inv_item != null && simple_production_inv_item.Count > 0) {
                texInvoice.simple_production_item = simple_production_inv_item.First();
            }



            return texInvoiceList.First();
        }

        // PUT: api/TexInvoiceItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexInvoiceItem(long id, TexInvoiceItem texInvoiceItem)
        {
            if (id != texInvoiceItem.id)
            {
                return BadRequest();
            }

            _context.Entry(texInvoiceItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexInvoiceItemExists(id))
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

        // POST: api/TexInvoiceItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexInvoiceItem>> PostTexInvoiceItem(TexInvoiceItem texInvoiceItem)
        {
            try
            {
            _context.TexInvoiceItem.Update(texInvoiceItem);
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

            return CreatedAtAction("GetTexInvoiceItem", new { id = texInvoiceItem.id }, texInvoiceItem);
        }

        [HttpGet("applyOrDisableSaleInvoiceByInvoiceIdAndStatus")]
        public async Task<ActionResult<TexInvoice>> applyOrDisableSaleInvoiceByInvoiceIdAndStatus([FromQuery] long invoice_id,[FromQuery] bool applayment_status)
        {
            List<TexInvoice> invoicesList = await _context.TexInvoice.Where(p => p.id == invoice_id).ToListAsync();

            if (invoicesList == null || invoicesList.Count == 0) {
                return NotFound("Invoice not found");
            }

            try
            {
                if (invoicesList.First().accepted_user == applayment_status) {
                    return NotFound("Пожалуйста, обновите свою страницу");

                }

                List<TexInvoiceItem> texInvoiceItemList = await _context.TexInvoiceItem
                    .Where(p => p.invoice_id == invoicesList.First().id && p.main_item_id > 0).ToListAsync();

                List<TexInvoiceItem> invoiceItemUpdated = new List<TexInvoiceItem>();

                invoicesList.First().accepted_user = applayment_status;
                if (applayment_status == true)
                {

                   
                    foreach (TexInvoiceItem item in texInvoiceItemList) {
                        TexInvoiceItem itemMain = await _context.TexInvoiceItem.FindAsync(item.main_item_id);
                        itemMain.ostatka = itemMain.ostatka - item.qty;
                        invoiceItemUpdated.Add(itemMain);

                    }

                }
                else {
                    foreach (TexInvoiceItem item in texInvoiceItemList)
                    {
                        TexInvoiceItem itemMain = await _context.TexInvoiceItem.FindAsync(item.main_item_id);
                        itemMain.ostatka = itemMain.ostatka + item.qty;
                        invoiceItemUpdated.Add(itemMain);

                    }

                }

                //update invoice current items
                _context.TexInvoiceItem.UpdateRange(texInvoiceItemList);
                await _context.SaveChangesAsync();

                //update invice main items 
                _context.TexInvoiceItem.UpdateRange(invoiceItemUpdated);
                await _context.SaveChangesAsync();

                //update invoice
                _context.TexInvoice.Update(invoicesList.First());
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

            return invoicesList.First();
        }

        // DELETE: api/TexInvoiceItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexInvoiceItem>> DeleteTexInvoiceItem(long id)
        {
            var texInvoiceItem = await _context.TexInvoiceItem.FindAsync(id);
            if (texInvoiceItem == null)
            {
                return NotFound();
            }

            _context.TexInvoiceItem.Remove(texInvoiceItem);
            await _context.SaveChangesAsync();

            return texInvoiceItem;
        }

        private bool TexInvoiceItemExists(long id)
        {
            return _context.TexInvoiceItem.Any(e => e.id == id);
        }
    }
}
