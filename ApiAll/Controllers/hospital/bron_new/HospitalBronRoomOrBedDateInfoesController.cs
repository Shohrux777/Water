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
    public class HospitalBronRoomOrBedDateInfoesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalBronRoomOrBedDateInfoesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalBronRoomOrBedDateInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalBronRoomOrBedDateInfo>>> GetHospitalBronRoomOrBedDateInfo()
        {
            return await _context.HospitalBronRoomOrBedDateInfo.ToListAsync();
        }

        // GET: api/HospitalBronRoomOrBedDateInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalBronRoomOrBedDateInfo>> GetHospitalBronRoomOrBedDateInfo(long id)
        {
            var hospitalBronRoomOrBedDateInfo = await _context.HospitalBronRoomOrBedDateInfo.FindAsync(id);

            if (hospitalBronRoomOrBedDateInfo == null)
            {
                return NotFound();
            }

            return hospitalBronRoomOrBedDateInfo;
        }

        // PUT: api/HospitalBronRoomOrBedDateInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalBronRoomOrBedDateInfo(long id, HospitalBronRoomOrBedDateInfo hospitalBronRoomOrBedDateInfo)
        {
            if (id != hospitalBronRoomOrBedDateInfo.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalBronRoomOrBedDateInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalBronRoomOrBedDateInfoExists(id))
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

        // POST: api/HospitalBronRoomOrBedDateInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalBronRoomOrBedDateInfo>> PostHospitalBronRoomOrBedDateInfo(HospitalBronRoomOrBedDateInfo hospitalBronRoomOrBedDateInfo)
        {
            _context.HospitalBronRoomOrBedDateInfo.Update(hospitalBronRoomOrBedDateInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalBronRoomOrBedDateInfo", new { id = hospitalBronRoomOrBedDateInfo.id }, hospitalBronRoomOrBedDateInfo);
        }

        // DELETE: api/HospitalBronRoomOrBedDateInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalBronRoomOrBedDateInfo>> DeleteHospitalBronRoomOrBedDateInfo(long id)
        {
            var hospitalBronRoomOrBedDateInfo = await _context.HospitalBronRoomOrBedDateInfo.FindAsync(id);
            if (hospitalBronRoomOrBedDateInfo == null)
            {
                return NotFound();
            }

            _context.HospitalBronRoomOrBedDateInfo.Remove(hospitalBronRoomOrBedDateInfo);
            await _context.SaveChangesAsync();

            return hospitalBronRoomOrBedDateInfo;
        }

        private bool HospitalBronRoomOrBedDateInfoExists(long id)
        {
            return _context.HospitalBronRoomOrBedDateInfo.Any(e => e.id == id);
        }
    }
}
