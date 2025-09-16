using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentRoomsItemsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PaymentRoomsItemsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PaymentRoomsItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentRoomsItem>>> GetPaymentRoomsItem()
        {
            return await _context.PaymentRoomsItem.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/PaymentRoomsItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentRoomsItem>> GetPaymentRoomsItem(long id)
        {
            var paymentRoomsItem = await _context.PaymentRoomsItem.FindAsync(id);

            if (paymentRoomsItem == null)
            {
                return NotFound();
            }

            return paymentRoomsItem;
        }

        // PUT: api/PaymentRoomsItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentRoomsItem(long id, PaymentRoomsItem paymentRoomsItem)
        {
            if (id != paymentRoomsItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentRoomsItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentRoomsItemExists(id))
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

        // POST: api/PaymentRoomsItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PaymentRoomsItem>> PostPaymentRoomsItem(PaymentRoomsItem paymentRoomsItem)
        {
            _context.PaymentRoomsItem.Add(paymentRoomsItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentRoomsItem", new { id = paymentRoomsItem.Id }, paymentRoomsItem);
        }

        // DELETE: api/PaymentRoomsItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentRoomsItem>> DeletePaymentRoomsItem(long id)
        {
            var paymentRoomsItem = await _context.PaymentRoomsItem.FindAsync(id);
            if (paymentRoomsItem == null)
            {
                return NotFound();
            }

            _context.PaymentRoomsItem.Remove(paymentRoomsItem);
            await _context.SaveChangesAsync();

            return paymentRoomsItem;
        }

        private bool PaymentRoomsItemExists(long id)
        {
            return _context.PaymentRoomsItem.Any(e => e.Id == id);
        }
    }
}
