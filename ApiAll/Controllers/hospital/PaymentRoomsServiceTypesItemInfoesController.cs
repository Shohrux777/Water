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
    public class PaymentRoomsServiceTypesItemInfoesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PaymentRoomsServiceTypesItemInfoesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PaymentRoomsServiceTypesItemInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentRoomsServiceTypesItemInfo>>> GetPaymentRoomsServiceTypesItemInfo()
        {
            return await _context.PaymentRoomsServiceTypesItemInfo.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/PaymentRoomsServiceTypesItemInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentRoomsServiceTypesItemInfo>> GetPaymentRoomsServiceTypesItemInfo(long id)
        {
            var paymentRoomsServiceTypesItemInfo = await _context.PaymentRoomsServiceTypesItemInfo.FindAsync(id);

            if (paymentRoomsServiceTypesItemInfo == null)
            {
                return NotFound();
            }

            return paymentRoomsServiceTypesItemInfo;
        }

        // PUT: api/PaymentRoomsServiceTypesItemInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentRoomsServiceTypesItemInfo(long id, PaymentRoomsServiceTypesItemInfo paymentRoomsServiceTypesItemInfo)
        {
            if (id != paymentRoomsServiceTypesItemInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentRoomsServiceTypesItemInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentRoomsServiceTypesItemInfoExists(id))
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

        // POST: api/PaymentRoomsServiceTypesItemInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PaymentRoomsServiceTypesItemInfo>> PostPaymentRoomsServiceTypesItemInfo(PaymentRoomsServiceTypesItemInfo paymentRoomsServiceTypesItemInfo)
        {
            _context.PaymentRoomsServiceTypesItemInfo.Add(paymentRoomsServiceTypesItemInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentRoomsServiceTypesItemInfo", new { id = paymentRoomsServiceTypesItemInfo.Id }, paymentRoomsServiceTypesItemInfo);
        }

        // DELETE: api/PaymentRoomsServiceTypesItemInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentRoomsServiceTypesItemInfo>> DeletePaymentRoomsServiceTypesItemInfo(long id)
        {
            var paymentRoomsServiceTypesItemInfo = await _context.PaymentRoomsServiceTypesItemInfo.FindAsync(id);
            if (paymentRoomsServiceTypesItemInfo == null)
            {
                return NotFound();
            }

            _context.PaymentRoomsServiceTypesItemInfo.Remove(paymentRoomsServiceTypesItemInfo);
            await _context.SaveChangesAsync();

            return paymentRoomsServiceTypesItemInfo;
        }

        private bool PaymentRoomsServiceTypesItemInfoExists(long id)
        {
            return _context.PaymentRoomsServiceTypesItemInfo.Any(e => e.Id == id);
        }
    }
}
