using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.parking;

namespace ApiAll.Controllers.parking
{
    [ApiExplorerSettings(GroupName = "v10")]
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingPaymentController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ParkingPaymentController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ParkingPayment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingPayment>>> GetParkingPayment()
        {
            return await _context.ParkingPayment.ToListAsync();
        }

        // GET: api/ParkingPayment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingPayment>> GetParkingPayment(long id)
        {
            var parkingPayment = await _context.ParkingPayment.FindAsync(id);

            if (parkingPayment == null)
            {
                return NotFound();
            }

            return parkingPayment;
        }

        // PUT: api/ParkingPayment/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParkingPayment(long id, ParkingPayment parkingPayment)
        {
            if (id != parkingPayment.id)
            {
                return BadRequest();
            }

            _context.Entry(parkingPayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingPaymentExists(id))
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

        // POST: api/ParkingPayment
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ParkingPayment>> PostParkingPayment(ParkingPayment parkingPayment)
        {
            _context.ParkingPayment.Update(parkingPayment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParkingPayment", new { id = parkingPayment.id }, parkingPayment);
        }

        // DELETE: api/ParkingPayment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ParkingPayment>> DeleteParkingPayment(long id)
        {
            var parkingPayment = await _context.ParkingPayment.FindAsync(id);
            if (parkingPayment == null)
            {
                return NotFound();
            }

            _context.ParkingPayment.Remove(parkingPayment);
            await _context.SaveChangesAsync();

            return parkingPayment;
        }

        private bool ParkingPaymentExists(long id)
        {
            return _context.ParkingPayment.Any(e => e.id == id);
        }
    }
}
