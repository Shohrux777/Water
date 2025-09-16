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
    public class ParkingPlaceController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ParkingPlaceController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ParkingPlace
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingPlace>>> GetParkingPlace()
        {
            return await _context.ParkingPlace.ToListAsync();
        }

        // GET: api/ParkingPlace/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingPlace>> GetParkingPlace(long id)
        {
            var parkingPlace = await _context.ParkingPlace.FindAsync(id);

            if (parkingPlace == null)
            {
                return NotFound();
            }

            return parkingPlace;
        }

        // PUT: api/ParkingPlace/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParkingPlace(long id, ParkingPlace parkingPlace)
        {
            if (id != parkingPlace.id)
            {
                return BadRequest();
            }

            _context.Entry(parkingPlace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingPlaceExists(id))
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

        // POST: api/ParkingPlace
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ParkingPlace>> PostParkingPlace(ParkingPlace parkingPlace)
        {
            _context.ParkingPlace.Update(parkingPlace);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParkingPlace", new { id = parkingPlace.id }, parkingPlace);
        }

        // DELETE: api/ParkingPlace/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ParkingPlace>> DeleteParkingPlace(long id)
        {
            var parkingPlace = await _context.ParkingPlace.FindAsync(id);
            if (parkingPlace == null)
            {
                return NotFound();
            }

            _context.ParkingPlace.Remove(parkingPlace);
            await _context.SaveChangesAsync();

            return parkingPlace;
        }

        private bool ParkingPlaceExists(long id)
        {
            return _context.ParkingPlace.Any(e => e.id == id);
        }
    }
}
