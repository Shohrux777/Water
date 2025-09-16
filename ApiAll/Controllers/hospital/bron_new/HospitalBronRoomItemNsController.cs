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
    public class HospitalBronRoomItemNsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalBronRoomItemNsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalBronRoomItemNs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalBronRoomItemN>>> GetHospitalBronRoomItemN()
        {
            return await _context.HospitalBronRoomItemN.ToListAsync();
        }

        // GET: api/HospitalBronRoomItemNs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalBronRoomItemN>> GetHospitalBronRoomItemN(long id)
        {
            var hospitalBronRoomItemN = await _context.HospitalBronRoomItemN.FindAsync(id);

            if (hospitalBronRoomItemN == null)
            {
                return NotFound();
            }

            return hospitalBronRoomItemN;
        }

        // PUT: api/HospitalBronRoomItemNs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalBronRoomItemN(long id, HospitalBronRoomItemN hospitalBronRoomItemN)
        {
            if (id != hospitalBronRoomItemN.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalBronRoomItemN).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalBronRoomItemNExists(id))
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

        // POST: api/HospitalBronRoomItemNs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalBronRoomItemN>> PostHospitalBronRoomItemN(HospitalBronRoomItemN hospitalBronRoomItemN)
        {
            _context.HospitalBronRoomItemN.Update(hospitalBronRoomItemN);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalBronRoomItemN", new { id = hospitalBronRoomItemN.id }, hospitalBronRoomItemN);
        }

        // DELETE: api/HospitalBronRoomItemNs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalBronRoomItemN>> DeleteHospitalBronRoomItemN(long id)
        {
            var hospitalBronRoomItemN = await _context.HospitalBronRoomItemN.FindAsync(id);
            if (hospitalBronRoomItemN == null)
            {
                return NotFound();
            }

            _context.HospitalBronRoomItemN.Remove(hospitalBronRoomItemN);
            await _context.SaveChangesAsync();

            return hospitalBronRoomItemN;
        }

        private bool HospitalBronRoomItemNExists(long id)
        {
            return _context.HospitalBronRoomItemN.Any(e => e.id == id);
        }
    }
}
