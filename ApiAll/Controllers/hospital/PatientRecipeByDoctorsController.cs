using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientRecipeByDoctorsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PatientRecipeByDoctorsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PatientRecipeByDoctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientRecipeByDoctor>>> GetPatientRecipeByDoctor()
        {
            return await _context.PatientRecipeByDoctor.ToListAsync();
        }

        [HttpGet("getPatientRecipeByDoctorAndPatientId")]
        public async Task<ActionResult<IEnumerable<PatientRecipeByDoctor>>> getPatientRecipeByDoctorAndPatientId([FromQuery] long patientid,[FromQuery] long doctorId)
        {
            return await _context.PatientRecipeByDoctor.Where(p => p.DoctorId == doctorId && p.PatientsId == patientid).Include(p => p.patients).Include(p => p.users).ToListAsync();
        }      
        
        [HttpGet("getPatientRecipeByPatientId")]
        public async Task<ActionResult<IEnumerable<PatientRecipeByDoctor>>> getPatientRecipeByPatientId([FromQuery] long patientid)
        {
            return await _context.PatientRecipeByDoctor.Where(p => p.PatientsId  ==  patientid).Include(p => p.patients).Include(p => p.users).ToListAsync();
        }

        // GET: api/PatientRecipeByDoctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientRecipeByDoctor>> GetPatientRecipeByDoctor(long id)
        {
            var patientRecipeByDoctor = await _context.PatientRecipeByDoctor.FindAsync(id);

            if (patientRecipeByDoctor == null)
            {
                return NotFound();
            }

            return patientRecipeByDoctor;
        }

        // PUT: api/PatientRecipeByDoctors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientRecipeByDoctor(long id, PatientRecipeByDoctor patientRecipeByDoctor)
        {
            if (id != patientRecipeByDoctor.Id)
            {
                return BadRequest();
            }

            _context.Entry(patientRecipeByDoctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientRecipeByDoctorExists(id))
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

        // POST: api/PatientRecipeByDoctors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PatientRecipeByDoctor>> PostPatientRecipeByDoctor(PatientRecipeByDoctor patientRecipeByDoctor)
        {
            _context.PatientRecipeByDoctor.Update(patientRecipeByDoctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatientRecipeByDoctor", new { id = patientRecipeByDoctor.Id }, patientRecipeByDoctor);
        }

        // DELETE: api/PatientRecipeByDoctors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PatientRecipeByDoctor>> DeletePatientRecipeByDoctor(long id)
        {
            var patientRecipeByDoctor = await _context.PatientRecipeByDoctor.FindAsync(id);
            if (patientRecipeByDoctor == null)
            {
                return NotFound();
            }

            _context.PatientRecipeByDoctor.Remove(patientRecipeByDoctor);
            await _context.SaveChangesAsync();

            return patientRecipeByDoctor;
        }

        private bool PatientRecipeByDoctorExists(long id)
        {
            return _context.PatientRecipeByDoctor.Any(e => e.Id == id);
        }
    }
}
