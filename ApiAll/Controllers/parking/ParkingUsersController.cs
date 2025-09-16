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
    public class ParkingUsersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ParkingUsersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ParkingUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingUsers>>> GetParkingUsers()
        {
            return await _context.ParkingUsers.ToListAsync();
        }

        // GET: api/ParkingUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingUsers>> GetParkingUsers(long id)
        {
            var parkingUsers = await _context.ParkingUsers.FindAsync(id);

            if (parkingUsers == null)
            {
                return NotFound();
            }

            return parkingUsers;
        }

        // PUT: api/ParkingUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParkingUsers(long id, ParkingUsers parkingUsers)
        {
            if (id != parkingUsers.id)
            {
                return BadRequest();
            }

            _context.Entry(parkingUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingUsersExists(id))
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

        // POST: api/ParkingUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ParkingUsers>> PostParkingUsers(ParkingUsers parkingUsers)
        {
            _context.ParkingUsers.Update(parkingUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParkingUsers", new { id = parkingUsers.id }, parkingUsers);
        }

        // DELETE: api/ParkingUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ParkingUsers>> DeleteParkingUsers(long id)
        {
            var parkingUsers = await _context.ParkingUsers.FindAsync(id);
            if (parkingUsers == null)
            {
                return NotFound();
            }

            _context.ParkingUsers.Remove(parkingUsers);
            await _context.SaveChangesAsync();

            return parkingUsers;
        }

        private bool ParkingUsersExists(long id)
        {
            return _context.ParkingUsers.Any(e => e.id == id);
        }
    }
}
