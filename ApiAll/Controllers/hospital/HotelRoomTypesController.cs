using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hotel;

namespace ApiAll.Controllers.hospital
{

    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomTypesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HotelRoomTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HotelRoomTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoomType>>> GetHotelRoomType()
        {
            return await _context.HotelRoomType.ToListAsync();
        }

        // GET: api/HotelRoomTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelRoomType>> GetHotelRoomType(long id)
        {
            var hotelRoomType = await _context.HotelRoomType.FindAsync(id);

            if (hotelRoomType == null)
            {
                return NotFound();
            }

            return hotelRoomType;
        }

        // PUT: api/HotelRoomTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelRoomType(long id, HotelRoomType hotelRoomType)
        {
            if (id != hotelRoomType.id)
            {
                return BadRequest();
            }

            _context.Entry(hotelRoomType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelRoomTypeExists(id))
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

        // POST: api/HotelRoomTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HotelRoomType>> PostHotelRoomType(HotelRoomType hotelRoomType)
        {
            _context.HotelRoomType.Update(hotelRoomType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelRoomType", new { hotelRoomType.id }, hotelRoomType);
        }

        // DELETE: api/HotelRoomTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HotelRoomType>> DeleteHotelRoomType(long id)
        {
            var hotelRoomType = await _context.HotelRoomType.FindAsync(id);
            if (hotelRoomType == null)
            {
                return NotFound();
            }

            _context.HotelRoomType.Remove(hotelRoomType);
            await _context.SaveChangesAsync();

            return hotelRoomType;
        }

        private bool HotelRoomTypeExists(long id)
        {
            return _context.HotelRoomType.Any(e => e.id == id);
        }
    }
}
