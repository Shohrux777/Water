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
    public class ParkingAuthController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ParkingAuthController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ParkingAuth
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingAuth>>> GetParkingAuth()
        {
            return await _context.ParkingAuth.ToListAsync();
        }

        // GET: api/ParkingAuth/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingAuth>> GetParkingAuth(long id)
        {
            var parkingAuth = await _context.ParkingAuth.FindAsync(id);

            if (parkingAuth == null)
            {
                return NotFound();
            }

            return parkingAuth;
        }

        // PUT: api/ParkingAuth/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParkingAuth(long id, ParkingAuth parkingAuth)
        {
            if (id != parkingAuth.id)
            {
                return BadRequest();
            }

            _context.Entry(parkingAuth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingAuthExists(id))
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

        // POST: api/ParkingAuth
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ParkingAuth>> PostParkingAuth(ParkingAuth parkingAuth)
        {
            _context.ParkingAuth.Update(parkingAuth);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParkingAuth", new { id = parkingAuth.id }, parkingAuth);
        }

        // DELETE: api/ParkingAuth/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ParkingAuth>> DeleteParkingAuth(long id)
        {
            var parkingAuth = await _context.ParkingAuth.FindAsync(id);
            if (parkingAuth == null)
            {
                return NotFound();
            }

            _context.ParkingAuth.Remove(parkingAuth);
            await _context.SaveChangesAsync();

            return parkingAuth;
        }

        private bool ParkingAuthExists(long id)
        {
            return _context.ParkingAuth.Any(e => e.id == id);
        }
    }
}
