using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital.bron_new;

namespace ApiAll.Controllers.hospital.bron_new
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalRoomTypesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalRoomTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalRoomTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalRoomType>>> GetHospitalRoomType()
        {
            return await _context.HospitalRoomType.ToListAsync();
        }

        // GET: api/HospitalRoomTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalRoomType>> GetHospitalRoomType(long id)
        {
            var hospitalRoomType = await _context.HospitalRoomType.FindAsync(id);

            if (hospitalRoomType == null)
            {
                return NotFound();
            }

            return hospitalRoomType;
        }

        // PUT: api/HospitalRoomTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalRoomType(long id, HospitalRoomType hospitalRoomType)
        {
            if (id != hospitalRoomType.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalRoomType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalRoomTypeExists(id))
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

        // POST: api/HospitalRoomTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalRoomType>> PostHospitalRoomType(HospitalRoomType hospitalRoomType)
        {
            _context.HospitalRoomType.Update(hospitalRoomType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalRoomType", new { id = hospitalRoomType.id }, hospitalRoomType);
        }

        // DELETE: api/HospitalRoomTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalRoomType>> DeleteHospitalRoomType(long id)
        {
            var hospitalRoomType = await _context.HospitalRoomType.FindAsync(id);
            if (hospitalRoomType == null)
            {
                return NotFound();
            }

            _context.HospitalRoomType.Remove(hospitalRoomType);
            await _context.SaveChangesAsync();

            return hospitalRoomType;
        }

        private bool HospitalRoomTypeExists(long id)
        {
            return _context.HospitalRoomType.Any(e => e.id == id);
        }
    }
}
