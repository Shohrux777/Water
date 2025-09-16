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
    public class RoomBookingsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public RoomBookingsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/RoomBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomBooking>>> GetRoomBooking()
        {
            return await _context.RoomBooking.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/RoomBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomBooking>> GetRoomBooking(long id)
        {
            var roomBooking = await _context.RoomBooking.FindAsync(id);

            if (roomBooking == null)
            {
                return NotFound();
            }

            return roomBooking;
        }

        // PUT: api/RoomBookings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomBooking(long id, RoomBooking roomBooking)
        {
            if (id != roomBooking.Id)
            {
                return BadRequest();
            }

            _context.Entry(roomBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomBookingExists(id))
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

        // POST: api/RoomBookings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RoomBooking>> PostRoomBooking(RoomBooking roomBooking)
        {
            _context.RoomBooking.Add(roomBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomBooking", new { id = roomBooking.Id }, roomBooking);
        }

        // DELETE: api/RoomBookings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoomBooking>> DeleteRoomBooking(long id)
        {
            var roomBooking = await _context.RoomBooking.FindAsync(id);
            if (roomBooking == null)
            {
                return NotFound();
            }

            _context.RoomBooking.Remove(roomBooking);
            await _context.SaveChangesAsync();

            return roomBooking;
        }

        private bool RoomBookingExists(long id)
        {
            return _context.RoomBooking.Any(e => e.Id == id);
        }
    }
}
