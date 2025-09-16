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
    public class HospitalBronRoomNsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalBronRoomNsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalBronRoomNs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalBronRoomN>>> GetHospitalBronRoomN()
        {
            return await _context.HospitalBronRoomN.ToListAsync();
        }

        // GET: api/HospitalBronRoomNs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalBronRoomN>> GetHospitalBronRoomN(long id)
        {
            var hospitalBronRoomN = await _context.HospitalBronRoomN.FindAsync(id);

            if (hospitalBronRoomN == null)
            {
                return NotFound();
            }

            return hospitalBronRoomN;
        }

        // PUT: api/HospitalBronRoomNs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalBronRoomN(long id, HospitalBronRoomN hospitalBronRoomN)
        {
            if (id != hospitalBronRoomN.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalBronRoomN).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalBronRoomNExists(id))
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

        // POST: api/HospitalBronRoomNs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalBronRoomN>> PostHospitalBronRoomN(HospitalBronRoomN hospitalBronRoomN)
        {
            _context.HospitalBronRoomN.Add(hospitalBronRoomN);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalBronRoomN", new { id = hospitalBronRoomN.id }, hospitalBronRoomN);
        }

        // DELETE: api/HospitalBronRoomNs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalBronRoomN>> DeleteHospitalBronRoomN(long id)
        {
            var hospitalBronRoomN = await _context.HospitalBronRoomN.FindAsync(id);
            if (hospitalBronRoomN == null)
            {
                return NotFound();
            }

            _context.HospitalBronRoomN.Remove(hospitalBronRoomN);
            await _context.SaveChangesAsync();

            return hospitalBronRoomN;
        }

        private bool HospitalBronRoomNExists(long id)
        {
            return _context.HospitalBronRoomN.Any(e => e.id == id);
        }
    }
}
