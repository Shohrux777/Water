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
    public class PosInvoiceItemsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosInvoiceItemsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosInvoiceItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosInvoiceItem>>> GetPosInvoiceItem()
        {
            return await _context.PosInvoiceItem.ToListAsync();
        }

        [HttpGet("getNotLeftProductsList")]
        public async Task<ActionResult<TexPaginationModel>> getNotLeftProductsList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosInvoiceItem> itemList = await _context.PosInvoiceItem
                .Where(p => p.active_status == true && p.qty_in_pack <= 0 )
                .Include(p => p.product)
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosInvoiceItem>();
            }

            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosInvoiceItem
                .Where(p => p.active_status == true && p.qty_in_pack <= 0).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getExpiredDateLeftProductsList")]
        public async Task<ActionResult<TexPaginationModel>> getExpiredDateLeftProductsList([FromQuery] int page, [FromQuery] int size)
        {
           
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosInvoiceItem> itemList = await _context.PosInvoiceItem
                .Where(p => p.active_status == true && (p.qty_in_pack > 0 || p.qty > 0) && p.expired_date <= DateTime.Now)
                .Include(p => p.product)
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosInvoiceItem>();
            }

            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosInvoiceItem
                .Where(p => p.active_status == true && (p.qty_in_pack > 0 || p.qty > 0) && p.expired_date <= DateTime.Now).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getOstatkaExpiredDateProductsList")]
        public async Task<ActionResult<TexPaginationModel>> getOstatkaExpiredDateProductsList([FromQuery] int page, [FromQuery] int size)
        {

            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosInvoiceItem> itemList = await _context.PosInvoiceItem
                .Where(p => p.active_status == true && (p.qty_in_pack > 0 || p.real_qty > 0) )
                .Include(p => p.product)
                .OrderBy(p =>p.expired_date)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosInvoiceItem>();
            }

            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosInvoiceItem
                .Where(p => p.active_status == true && (p.qty_in_pack > 0 || p.real_qty > 0)).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getProductListByExpratedWithDateForReport")]
        public async Task<ActionResult<TexPaginationModel>> getProductListByExpratedWithDateForReport([FromQuery] int page, [FromQuery] int size,[FromQuery] DateTime exp_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosInvoiceItem> itemList = await _context.PosInvoiceItem
                .Include(p => p.invoice)
                .Where(p => p.invoice.applyment_status == true && p.expired_date <= exp_date)
                .Include(p => p.product)
                .OrderBy(p => p.expired_date)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosInvoiceItem>();
            }

            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosInvoiceItem
                .Include(p => p.invoice)
                .Where(p => p.invoice.applyment_status == true && p.expired_date <= exp_date).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getProductListByExpratedDate")]
        public async Task<ActionResult<TexPaginationModel>> getProductListByExpratedDate([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosInvoiceItem> itemList = await _context.PosInvoiceItem
                .Include(p => p.invoice)
                .Where(p => p.invoice.applyment_status == true)
                .Include(p => p.product)
                .OrderBy(p => p.expired_date)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosInvoiceItem>();
            }

            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosInvoiceItem
                .Include(p => p.invoice)
                .Where(p => p.invoice.applyment_status == true).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getProductListForSaleByItemSearchByName")]
        public async Task<ActionResult<IEnumerable<PosInvoiceItem>>> getProductListForSaleByItemSearchByName([FromQuery] String name,[FromQuery] int res_count )
        {
            return await _context.PosInvoiceItem.Include(p => p.invoice).Include(p => p.product).Where(p => p.qty_in_pack > 0 && p.invoice.applyment_status == true && p.product.name.ToLower().Contains(name.ToLower())).OrderBy(p => p.expired_date).Take(res_count).ToListAsync();
        }

        [HttpGet("getProductListForSaleByItemSearchByNameAndContragentId")]
        public async Task<ActionResult<IEnumerable<PosInvoiceItem>>> getProductListForSaleByItemSearchByNameAndContragentId([FromQuery] String name, [FromQuery] int res_count,[FromQuery] long pos_company_id)
        {
            return await _context.PosInvoiceItem.Include(p => p.invoice).Include(p => p.product).Where(p => p.qty_in_pack > 0 && p.invoice.applyment_status == true && p.invoice.postavshik_id == pos_company_id && p.product.name.ToLower().Contains(name.ToLower())).OrderBy(p => p.expired_date).Take(res_count).ToListAsync();
        }

        [HttpGet("getProductListForSaleByItemSearchByBarcode")]
        public async Task<ActionResult<IEnumerable<PosInvoiceItem>>> getProductListForSaleByItemSearchByBarcode([FromQuery] String barcode, [FromQuery] int res_count)
        {
            List<PosProductCode> barcode_list = await _context.PosProductCode.Where(p => p.barcode == barcode).ToListAsync();
            if (barcode_list == null || barcode_list.Count == 0) {
                return NotFound("Товар не найден");
            } 
            return await _context.PosInvoiceItem.Include(p => p.invoice).Include(p => p.product).Where(p => p.qty_in_pack > 0 && p.invoice.applyment_status == true && p.product_id == barcode_list.First().product_id).OrderBy(p => p.expired_date).Take(res_count).ToListAsync();
        }

        [HttpGet("getProductListForSaleByItemSearchByBarcodeAndContragentId")]
        public async Task<ActionResult<IEnumerable<PosInvoiceItem>>> getProductListForSaleByItemSearchByBarcodeAndContragentId([FromQuery] String barcode, [FromQuery] int res_count,[FromQuery] long pos_company_id)
        {
            List<PosProductCode> barcode_list = await _context.PosProductCode.Where(p => p.barcode == barcode).ToListAsync();
            if (barcode_list == null || barcode_list.Count == 0)
            {
                return NotFound("Товар не найден");
            }
            return await _context.PosInvoiceItem.Include(p => p.invoice).Include(p => p.product).Where(p => p.qty_in_pack > 0 && p.invoice.postavshik_id == pos_company_id && p.invoice.applyment_status == true && p.product_id == barcode_list.First().product_id).OrderBy(p => p.expired_date).Take(res_count).ToListAsync();
        }


        // GET: api/PosInvoiceItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosInvoiceItem>> GetPosInvoiceItem(long id)
        {
            var posInvoiceItem = await _context.PosInvoiceItem.FindAsync(id);

            if (posInvoiceItem == null)
            {
                return NotFound();
            }

            return posInvoiceItem;
        }

        // PUT: api/PosInvoiceItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosInvoiceItem(long id, PosInvoiceItem posInvoiceItem)
        {
            if (id != posInvoiceItem.id)
            {
                return BadRequest();
            }

            _context.Entry(posInvoiceItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosInvoiceItemExists(id))
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

        // POST: api/PosInvoiceItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosInvoiceItem>> PostPosInvoiceItem(PosInvoiceItem posInvoiceItem)
        {


            try
            {
            _context.PosInvoiceItem.Update(posInvoiceItem);
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

            return CreatedAtAction("GetPosInvoiceItem", new { id = posInvoiceItem.id }, posInvoiceItem);
        }

        // DELETE: api/PosInvoiceItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosInvoiceItem>> DeletePosInvoiceItem(long id)
        {
            var posInvoiceItem = await _context.PosInvoiceItem.FindAsync(id);
            if (posInvoiceItem == null)
            {
                return NotFound();
            }

            _context.PosInvoiceItem.Remove(posInvoiceItem);
            await _context.SaveChangesAsync();

            return posInvoiceItem;
        }

        private bool PosInvoiceItemExists(long id)
        {
            return _context.PosInvoiceItem.Any(e => e.id == id);
        }
    }
}
