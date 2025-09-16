using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital;

namespace ApiAll.Controllers.hospital.bron
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalPatientBronBedsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalPatientBronBedsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalPatientBronBeds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalPatientBronBeds>>> GetHospitalPatientBronBeds()
        {
            return await _context.HospitalPatientBronBeds.ToListAsync();
        }

        // GET: api/HospitalPatientBronBeds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalPatientBronBeds>> GetHospitalPatientBronBeds(long id)
        {
            var hospitalPatientBronBeds = await _context.HospitalPatientBronBeds.FindAsync(id);

            if (hospitalPatientBronBeds == null)
            {
                return NotFound();
            }

            return hospitalPatientBronBeds;
        }

        // PUT: api/HospitalPatientBronBeds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalPatientBronBeds(long id, HospitalPatientBronBeds hospitalPatientBronBeds)
        {
            if (id != hospitalPatientBronBeds.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalPatientBronBeds).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalPatientBronBedsExists(id))
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

        // POST: api/HospitalPatientBronBeds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalPatientBronBeds>> PostHospitalPatientBronBeds(HospitalPatientBronBeds hospitalPatientBronBeds)
        {
            _context.HospitalPatientBronBeds.Update(hospitalPatientBronBeds);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalPatientBronBeds", new { id = hospitalPatientBronBeds.id }, hospitalPatientBronBeds);
        }

        // DELETE: api/HospitalPatientBronBeds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalPatientBronBeds>> DeleteHospitalPatientBronBeds(long id)
        {
            var hospitalPatientBronBeds = await _context.HospitalPatientBronBeds.FindAsync(id);
            if (hospitalPatientBronBeds == null)
            {
                return NotFound();
            }

            _context.HospitalPatientBronBeds.Remove(hospitalPatientBronBeds);
            await _context.SaveChangesAsync();

            return hospitalPatientBronBeds;
        }

        private bool HospitalPatientBronBedsExists(long id)
        {
            return _context.HospitalPatientBronBeds.Any(e => e.id == id);
        }
    }
}
