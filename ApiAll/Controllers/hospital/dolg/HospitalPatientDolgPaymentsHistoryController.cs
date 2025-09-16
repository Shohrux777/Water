using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital.dolg;

namespace ApiAll.Controllers.hospital.dolg
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalPatientDolgPaymentsHistoryController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalPatientDolgPaymentsHistoryController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalPatientDolgPaymentsHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalPatientDolgPaymentsHistory>>> GetHospitalPatientDolgPaymentsHistory()
        {
            return await _context.HospitalPatientDolgPaymentsHistory.ToListAsync();
        }

        // GET: api/HospitalPatientDolgPaymentsHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalPatientDolgPaymentsHistory>> GetHospitalPatientDolgPaymentsHistory(long id)
        {
            var hospitalPatientDolgPaymentsHistory = await _context.HospitalPatientDolgPaymentsHistory.FindAsync(id);

            if (hospitalPatientDolgPaymentsHistory == null)
            {
                return NotFound();
            }

            return hospitalPatientDolgPaymentsHistory;
        }

        // PUT: api/HospitalPatientDolgPaymentsHistory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalPatientDolgPaymentsHistory(long id, HospitalPatientDolgPaymentsHistory hospitalPatientDolgPaymentsHistory)
        {
            if (id != hospitalPatientDolgPaymentsHistory.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalPatientDolgPaymentsHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalPatientDolgPaymentsHistoryExists(id))
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

        // POST: api/HospitalPatientDolgPaymentsHistory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalPatientDolgPaymentsHistory>> PostHospitalPatientDolgPaymentsHistory(HospitalPatientDolgPaymentsHistory hospitalPatientDolgPaymentsHistory)
        {
            _context.HospitalPatientDolgPaymentsHistory.Update(hospitalPatientDolgPaymentsHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalPatientDolgPaymentsHistory", new { id = hospitalPatientDolgPaymentsHistory.id }, hospitalPatientDolgPaymentsHistory);
        }

        // DELETE: api/HospitalPatientDolgPaymentsHistory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalPatientDolgPaymentsHistory>> DeleteHospitalPatientDolgPaymentsHistory(long id)
        {
            var hospitalPatientDolgPaymentsHistory = await _context.HospitalPatientDolgPaymentsHistory.FindAsync(id);
            if (hospitalPatientDolgPaymentsHistory == null)
            {
                return NotFound();
            }

            _context.HospitalPatientDolgPaymentsHistory.Remove(hospitalPatientDolgPaymentsHistory);
            await _context.SaveChangesAsync();

            return hospitalPatientDolgPaymentsHistory;
        }

        private bool HospitalPatientDolgPaymentsHistoryExists(long id)
        {
            return _context.HospitalPatientDolgPaymentsHistory.Any(e => e.id == id);
        }
    }
}
