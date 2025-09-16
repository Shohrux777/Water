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
    public class PosInvoicesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosInvoicesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosInvoices
        [HttpGet("getInvoiceFullInfoById")]
        public async Task<ActionResult<PosInvoice>> getInvoiceFullInfoById([FromQuery] long invoice_id)
        {
            List<PosInvoice> posInvoiceList =  await _context.PosInvoice
                .Where(p => p.id == invoice_id)
                 .Include(p => p.postavshik)
                .Include(p => p.sklad)
                .Include(p => p.department)
                .ToListAsync();
            if (posInvoiceList == null || posInvoiceList.Count == 0) {
                return NotFound("Invoice not found");
            }
            foreach (PosInvoice item in posInvoiceList)
            {
                item.invoiceItems = await _context.PosInvoiceItem
                    .Include(p => p.product).ThenInclude(p => p.measurment)
                    .Where(p => p.PosInvoiceid == item.id).OrderByDescending(p => p.id).ToListAsync();
            }

            return posInvoiceList.First();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosInvoice> itemList = await _context.PosInvoice
                .Where(p => p.active_status == true )
                .Include(p => p.postavshik)
                .Include(p => p.sklad)
                .Include(p => p.department)
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosInvoice>();
            }
            /*foreach (PosInvoice item in itemList) {
                item.invoiceItems = await _context.PosInvoiceItem
                    .Include(p => p.product).ThenInclude( p => p.measurment)
                    .Where(p => p.PosInvoiceid == item.id).OrderByDescending(p =>p.id).ToListAsync();
            }*/

            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosInvoice
                .Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/PosInvoices/5
        [HttpGet("applyOrDisableBuyedProductListByInvoiceId")]
        public async Task<ActionResult<PosInvoice>> applyOrDisableBuyedProductListByInvoiceId([FromQuery]long invoice_id,[FromQuery] bool apply_status)
        {
            var posInvoice = await _context.PosInvoice.FindAsync(invoice_id);

            if (posInvoice == null)
            {
                return NotFound("Invoice not found");
            }
            List<PosInvoiceItem> posInvoiceItemList = await _context.PosInvoiceItem.Where(p => p.PosInvoiceid == invoice_id).ToListAsync();
            if (apply_status)
            {
                //qabul qilish

                //creadit summasi yozib qoyildi 
                if (posInvoice.credit_sum > 0) {
                    PosCreditor posCreditor = new PosCreditor();
                    posCreditor.active_status = true;
                    posCreditor.real_company_id = 0;
                    posCreditor.PosInvoiceid = invoice_id;
                    posCreditor.creditor_price = posInvoice.credit_sum;
                    posCreditor.real_creditor_price = posInvoice.credit_sum; 
                    _context.PosCreditor.Update(posCreditor);
                    await _context.SaveChangesAsync();
                }



                if (posInvoiceItemList != null && posInvoiceItemList.Count > 0) {
                    foreach (PosInvoiceItem item in posInvoiceItemList) {
                        List<PosProductPrice> priceList = await _context.PosProductPrice.Where(p => p.product_id == item.product_id).ToListAsync();
                        if (priceList != null && priceList.Count > 0) {
                            PosProductPrice priceProduct = priceList.First();
                            priceProduct.real_qty = priceProduct.real_qty + item.qty;
                            priceProduct.qty = priceProduct.qty + item.qty;
                            priceProduct.qty_in_pack = priceProduct.qty_in_pack + item.qty_in_pack;
                            if (item.change_price_status) {
                                PosProduct product = await _context.PosProduct.FindAsync(item.product_id);

                                product.price = item.unit_buyed_price;
                                product.buyed_price = item.unit_saled_price; 


                                product.percentage = item.persantage;


                                priceProduct.price = item.unit_saled_price;
                                priceProduct.buyed_price = item.unit_buyed_price;
                                priceProduct.percantage = item.persantage;
                                _context.PosProduct.Update(product);
                                await _context.SaveChangesAsync();
                            }
                            _context.PosProductPrice.Update(priceProduct);
                            await _context.SaveChangesAsync();
                        }
                        else {
                            PosProductPrice priceProduct = new PosProductPrice();
                            PosProduct product = await _context.PosProduct.FindAsync(item.product_id);
                            priceProduct.active_status = true;
                            priceProduct.product_id = product.id;
                            priceProduct.real_qty = item.qty;
                            priceProduct.qty = item.qty;
                            priceProduct.price = product.price;
                            priceProduct.buyed_price = product.buyed_price;
                            priceProduct.percantage = product.percentage;
                            priceProduct.qty_in_pack = item.qty_in_pack;
                            if (item.change_price_status)
                            {
                                product.price = item.unit_buyed_price;
                                product.buyed_price = item.unit_saled_price;
                                product.percentage = item.persantage;
                                priceProduct.price = item.unit_saled_price;
                                priceProduct.buyed_price = item.unit_buyed_price;
                                priceProduct.percantage = item.persantage;
                                _context.PosProduct.Update(product);
                                await _context.SaveChangesAsync();
                            }
                            _context.PosProductPrice.Update(priceProduct);
                            await _context.SaveChangesAsync();

                        }

                         
                    }

                }


            }
            else 
            {
                //barca creditlardi udalit qilish uchun kerak boladi
                List<PosCreditor> posCreditorList = await _context.PosCreditor.Where(p => p.PosInvoiceid == invoice_id).ToListAsync();
                if (posCreditorList != null && posCreditorList.Count > 0) {
                    foreach (PosCreditor ps in posCreditorList) {
                        if (ps.creditor_price != ps.real_creditor_price) {
                            return NotFound("Вы уже заплатили сумму, вы не можете ее изменить");
                        }
                    }
                    _context.PosCreditor.RemoveRange(posCreditorList);
                    await _context.SaveChangesAsync();
                }

                //oldin sotilgan sotilmaganini tekshirish uchun kerak boladi
                foreach (PosInvoiceItem item in posInvoiceItemList)
                {
                    if (item.qty != item.real_qty) {
                        //uji bundan sotilgan ozgartrib bolmaydi
                        return NotFound("Уже некоторые товары проданы, вы не можете изменить");
                    }

                }

                    //otmen qilish
                    foreach (PosInvoiceItem item in posInvoiceItemList) {
                    List<PosProductPrice> priceList = await _context.PosProductPrice.Where(p => p.product_id == item.product_id).ToListAsync();
                    if (priceList != null && priceList.Count > 0)
                    {
                        PosProductPrice productPrice = priceList.First();
                        productPrice.qty = productPrice.qty - item.qty;
                        productPrice.real_qty = productPrice.real_qty - item.qty;
                        productPrice.qty_in_pack = productPrice.qty_in_pack - item.qty_in_pack;
                        _context.PosProductPrice.Update(productPrice);
                        await _context.SaveChangesAsync();
                    }
                }

            }
            posInvoice.applyment_status = apply_status;
             _context.PosInvoice.Update(posInvoice);
            await _context.SaveChangesAsync();

            return posInvoice;
        }

        // PUT: api/PosInvoices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosInvoice(long id, PosInvoice posInvoice)
        {
            if (id != posInvoice.id)
            {
                return BadRequest();
            }

            _context.Entry(posInvoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosInvoiceExists(id))
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

        // POST: api/PosInvoices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosInvoice>> PostPosInvoice(PosInvoice posInvoice)
        {
            try
            {
                _context.PosInvoice.Update(posInvoice);
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

            return posInvoice;
        }

        // DELETE: api/PosInvoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosInvoice>> DeletePosInvoice(long id)
        {
            var posInvoice = await _context.PosInvoice.FindAsync(id);
            if (posInvoice == null)
            {
                return NotFound();
            }

            _context.PosInvoice.Remove(posInvoice);
            await _context.SaveChangesAsync();

            return posInvoice;
        }

        private bool PosInvoiceExists(long id)
        {
            return _context.PosInvoice.Any(e => e.id == id);
        }
    }
}
