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
    public class HospitalBronRoomPaymentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalBronRoomPaymentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalBronRoomPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalBronRoomPayments>>> GetHospitalBronRoomPayments()
        {
            return await _context.HospitalBronRoomPayments.ToListAsync();
        }

        // GET: api/HospitalBronRoomPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalBronRoomPayments>> GetHospitalBronRoomPayments(long id)
        {
            var hospitalBronRoomPayments = await _context.HospitalBronRoomPayments.FindAsync(id);

            if (hospitalBronRoomPayments == null)
            {
                return NotFound();
            }

            return hospitalBronRoomPayments;
        }

        // PUT: api/HospitalBronRoomPayments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalBronRoomPayments(long id, HospitalBronRoomPayments hospitalBronRoomPayments)
        {
            if (id != hospitalBronRoomPayments.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalBronRoomPayments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalBronRoomPaymentsExists(id))
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

        // POST: api/HospitalBronRoomPayments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalBronRoomPayments>> PostHospitalBronRoomPayments(HospitalBronRoomPayments hospitalBronRoomPayments)
        {
            _context.HospitalBronRoomPayments.Update(hospitalBronRoomPayments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalBronRoomPayments", new { id = hospitalBronRoomPayments.id }, hospitalBronRoomPayments);
        }

        // DELETE: api/HospitalBronRoomPayments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalBronRoomPayments>> DeleteHospitalBronRoomPayments(long id)
        {
            var hospitalBronRoomPayments = await _context.HospitalBronRoomPayments.FindAsync(id);
            if (hospitalBronRoomPayments == null)
            {
                return NotFound();
            }

            _context.HospitalBronRoomPayments.Remove(hospitalBronRoomPayments);
            await _context.SaveChangesAsync();

            return hospitalBronRoomPayments;
        }

        private bool HospitalBronRoomPaymentsExists(long id)
        {
            return _context.HospitalBronRoomPayments.Any(e => e.id == id);
        }
    }
}
