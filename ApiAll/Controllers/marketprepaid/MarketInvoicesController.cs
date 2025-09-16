using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.market;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class MarketInvoicesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketInvoicesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketInvoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketInvoice>>> GetMarketInvoice()
        {
            return await _context.MarketInvoice.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/MarketInvoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketInvoice>> GetMarketInvoice(long id)
        {
            var marketInvoice = await _context.MarketInvoice.FindAsync(id);

            if (marketInvoice == null)
            {
                return NotFound();
            }

            return marketInvoice;
        }

        // PUT: api/MarketInvoices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketInvoice(long id, MarketInvoice marketInvoice)
        {
            if (id != marketInvoice.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketInvoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketInvoiceExists(id))
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

        // POST: api/MarketInvoices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketInvoice>> PostMarketInvoice(MarketInvoice marketInvoice)
        {
            _context.MarketInvoice.Add(marketInvoice);
            await _context.SaveChangesAsync();

            List<MarketInvoiceItem> marketInvoiceItems = marketInvoice.marketInvoiceItems;
            foreach (MarketInvoiceItem item in marketInvoiceItems) {
                List<MarketProductRealQty> marketProductRealQtyList = await _context.MarketProductRealQty.Where(mp => mp.MarketProductId == item.MarketProductId).ToListAsync();
                MarketProductRealQty productRealQty = null;
                if (marketProductRealQtyList !=null && marketProductRealQtyList.Count > 0) {
                    productRealQty = marketProductRealQtyList.SingleOrDefault();
                }
                if (productRealQty == null) {
                    productRealQty = new MarketProductRealQty();
                    productRealQty.qty = 0;
                    productRealQty.realQty = 0;
                    productRealQty.MarketProductId = item.MarketProductId;
                }
                double qty = productRealQty.qty + item.qty;
                double realQty = productRealQty.realQty + item.qty;
                productRealQty.qty = qty;
                productRealQty.realQty = realQty;
                productRealQty.ActiveStatus = true;
                _context.MarketProductRealQty.Update(productRealQty);
                await _context.SaveChangesAsync();
            }


            return marketInvoice;
        }

        // DELETE: api/MarketInvoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketInvoice>> DeleteMarketInvoice(long id)
        {
            var marketInvoice = await _context.MarketInvoice.FindAsync(id);
            if (marketInvoice == null)
            {
                return NotFound();
            }

            _context.MarketInvoice.Remove(marketInvoice);
            await _context.SaveChangesAsync();

            return marketInvoice;
        }

        private bool MarketInvoiceExists(long id)
        {
            return _context.MarketInvoice.Any(e => e.Id == id);
        }
    }
}
