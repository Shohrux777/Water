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
    public class PaymentRoomsServiceTypesItemsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PaymentRoomsServiceTypesItemsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PaymentRoomsServiceTypesItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentRoomsServiceTypesItem>>> GetPaymentRoomsServiceTypesItem()
        {
            return await _context.PaymentRoomsServiceTypesItem.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/PaymentRoomsServiceTypesItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentRoomsServiceTypesItem>> GetPaymentRoomsServiceTypesItem(long id)
        {
            var paymentRoomsServiceTypesItem = await _context.PaymentRoomsServiceTypesItem.FindAsync(id);

            if (paymentRoomsServiceTypesItem == null)
            {
                return NotFound();
            }

            return paymentRoomsServiceTypesItem;
        }

        // PUT: api/PaymentRoomsServiceTypesItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentRoomsServiceTypesItem(long id, PaymentRoomsServiceTypesItem paymentRoomsServiceTypesItem)
        {
            if (id != paymentRoomsServiceTypesItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentRoomsServiceTypesItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentRoomsServiceTypesItemExists(id))
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

        // POST: api/PaymentRoomsServiceTypesItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PaymentRoomsServiceTypesItem>> PostPaymentRoomsServiceTypesItem(PaymentRoomsServiceTypesItem paymentRoomsServiceTypesItem)
        {
            _context.PaymentRoomsServiceTypesItem.Add(paymentRoomsServiceTypesItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentRoomsServiceTypesItem", new { id = paymentRoomsServiceTypesItem.Id }, paymentRoomsServiceTypesItem);
        }

        // DELETE: api/PaymentRoomsServiceTypesItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentRoomsServiceTypesItem>> DeletePaymentRoomsServiceTypesItem(long id)
        {
            var paymentRoomsServiceTypesItem = await _context.PaymentRoomsServiceTypesItem.FindAsync(id);
            if (paymentRoomsServiceTypesItem == null)
            {
                return NotFound();
            }

            _context.PaymentRoomsServiceTypesItem.Remove(paymentRoomsServiceTypesItem);
            await _context.SaveChangesAsync();

            return paymentRoomsServiceTypesItem;
        }

        private bool PaymentRoomsServiceTypesItemExists(long id)
        {
            return _context.PaymentRoomsServiceTypesItem.Any(e => e.Id == id);
        }
    }
}
