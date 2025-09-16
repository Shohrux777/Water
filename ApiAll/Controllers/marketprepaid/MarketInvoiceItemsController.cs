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
    public class MarketInvoiceItemsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketInvoiceItemsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketInvoiceItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketInvoiceItem>>> GetMarketInvoiceItem()
        {
            return await _context.MarketInvoiceItem.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/MarketInvoiceItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketInvoiceItem>> GetMarketInvoiceItem(long id)
        {
            var marketInvoiceItem = await _context.MarketInvoiceItem.FindAsync(id);

            if (marketInvoiceItem == null)
            {
                return NotFound();
            }

            return marketInvoiceItem;
        }

        // PUT: api/MarketInvoiceItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketInvoiceItem(long id, MarketInvoiceItem marketInvoiceItem)
        {
            if (id != marketInvoiceItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketInvoiceItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketInvoiceItemExists(id))
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

        // POST: api/MarketInvoiceItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketInvoiceItem>> PostMarketInvoiceItem(MarketInvoiceItem marketInvoiceItem)
        {
            _context.MarketInvoiceItem.Add(marketInvoiceItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketInvoiceItem", new { id = marketInvoiceItem.Id }, marketInvoiceItem);
        }

        // DELETE: api/MarketInvoiceItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketInvoiceItem>> DeleteMarketInvoiceItem(long id)
        {
            var marketInvoiceItem = await _context.MarketInvoiceItem.FindAsync(id);
            if (marketInvoiceItem == null)
            {
                return NotFound();
            }

            _context.MarketInvoiceItem.Remove(marketInvoiceItem);
            await _context.SaveChangesAsync();

            return marketInvoiceItem;
        }

        private bool MarketInvoiceItemExists(long id)
        {
            return _context.MarketInvoiceItem.Any(e => e.Id == id);
        }
    }
}
