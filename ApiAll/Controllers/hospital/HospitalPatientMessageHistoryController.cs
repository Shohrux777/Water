using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital;

namespace ApiAll.Controllers.hospital
{

    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalPatientMessageHistoryController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalPatientMessageHistoryController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalPatientMessageHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalPatientMessageHistory>>> GetHospitalPatientMessageHistory()
        {
            return await _context.HospitalPatientMessageHistory.ToListAsync();
        }

        // GET: api/HospitalPatientMessageHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalPatientMessageHistory>> GetHospitalPatientMessageHistory(long id)
        {
            var hospitalPatientMessageHistory = await _context.HospitalPatientMessageHistory.FindAsync(id);

            if (hospitalPatientMessageHistory == null)
            {
                return NotFound();
            }

            return hospitalPatientMessageHistory;
        }

        // PUT: api/HospitalPatientMessageHistory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalPatientMessageHistory(long id, HospitalPatientMessageHistory hospitalPatientMessageHistory)
        {
            if (id != hospitalPatientMessageHistory.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalPatientMessageHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalPatientMessageHistoryExists(id))
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

        // POST: api/HospitalPatientMessageHistory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalPatientMessageHistory>> PostHospitalPatientMessageHistory(HospitalPatientMessageHistory hospitalPatientMessageHistory)
        {
            _context.HospitalPatientMessageHistory.Update(hospitalPatientMessageHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalPatientMessageHistory", new { id = hospitalPatientMessageHistory.id }, hospitalPatientMessageHistory);
        }

        // DELETE: api/HospitalPatientMessageHistory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalPatientMessageHistory>> DeleteHospitalPatientMessageHistory(long id)
        {
            var hospitalPatientMessageHistory = await _context.HospitalPatientMessageHistory.FindAsync(id);
            if (hospitalPatientMessageHistory == null)
            {
                return NotFound();
            }

            _context.HospitalPatientMessageHistory.Remove(hospitalPatientMessageHistory);
            await _context.SaveChangesAsync();

            return hospitalPatientMessageHistory;
        }

        private bool HospitalPatientMessageHistoryExists(long id)
        {
            return _context.HospitalPatientMessageHistory.Any(e => e.id == id);
        }
    }
}
