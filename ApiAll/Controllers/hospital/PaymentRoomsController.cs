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
    public class PaymentRoomsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PaymentRoomsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PaymentRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentRooms>>> GetPaymentRooms()
        {
            return await _context.PaymentRooms.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/PaymentRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentRooms>> GetPaymentRooms(long id)
        {
            var paymentRooms = await _context.PaymentRooms.FindAsync(id);

            if (paymentRooms == null)
            {
                return NotFound();
            }

            return paymentRooms;
        }

        // PUT: api/PaymentRooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentRooms(long id, PaymentRooms paymentRooms)
        {
            if (id != paymentRooms.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentRooms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentRoomsExists(id))
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

        // POST: api/PaymentRooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PaymentRooms>> PostPaymentRooms(PaymentRooms paymentRooms)
        {
            _context.PaymentRooms.Add(paymentRooms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentRooms", new { id = paymentRooms.Id }, paymentRooms);
        }

        // DELETE: api/PaymentRooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentRooms>> DeletePaymentRooms(long id)
        {



            var paymentRooms = await _context.PaymentRooms.FindAsync(id);
            if (paymentRooms == null)
            {
                return NotFound();
            }

       
            

            _context.PaymentRooms.Remove(paymentRooms);
            await _context.SaveChangesAsync();

            return paymentRooms;
        }

        private bool PaymentRoomsExists(long id)
        {
            return _context.PaymentRooms.Any(e => e.Id == id);
        }
    }
}
