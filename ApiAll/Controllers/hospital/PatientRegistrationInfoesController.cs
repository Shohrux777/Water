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
    public class PatientRegistrationInfoesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PatientRegistrationInfoesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PatientRegistrationInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientRegistrationInfo>>> GetpatientRegistrationInfos()
        {
            return await _context.patientRegistrationInfos.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/PatientRegistrationInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientRegistrationInfo>> GetPatientRegistrationInfo(long id)
        {
            var patientRegistrationInfo = await _context.patientRegistrationInfos.FindAsync(id);

            if (patientRegistrationInfo == null)
            {
                return NotFound();
            }

            return patientRegistrationInfo;
        }

        // PUT: api/PatientRegistrationInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientRegistrationInfo(long id, PatientRegistrationInfo patientRegistrationInfo)
        {
            if (id != patientRegistrationInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(patientRegistrationInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientRegistrationInfoExists(id))
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

        // POST: api/PatientRegistrationInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PatientRegistrationInfo>> PostPatientRegistrationInfo(PatientRegistrationInfo patientRegistrationInfo)
        {
            _context.patientRegistrationInfos.Add(patientRegistrationInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatientRegistrationInfo", new { id = patientRegistrationInfo.Id }, patientRegistrationInfo);
        }

        [HttpGet("addPatientRegistrationInfo")]
        public async Task<ActionResult<PatientRegistrationInfo>> addPatientRegistrationInfo([FromQuery] String ReasonPatient, [FromQuery] long PatientTypeId, [FromQuery] long PatientServiceTypeId,[FromQuery] long PatientsId)
        {
            PatientRegistrationInfo patientRegistrationInfo = new PatientRegistrationInfo();
            patientRegistrationInfo.ActiveStatus = true;
            patientRegistrationInfo.RegistrationDateTime = DateTime.Now;
            patientRegistrationInfo.PatientServiceTypeId = PatientServiceTypeId;
            patientRegistrationInfo.PatientTypeId = PatientTypeId;
            patientRegistrationInfo.PatientsId = PatientsId;
            patientRegistrationInfo.ReasonPatient = ReasonPatient;
            _context.patientRegistrationInfos.Add(patientRegistrationInfo);
            patientRegistrationInfo.patients = await _context.Patients.FindAsync(PatientsId);
            await _context.SaveChangesAsync();

            return patientRegistrationInfo;
        }

        // DELETE: api/PatientRegistrationInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PatientRegistrationInfo>> DeletePatientRegistrationInfo(long id)
        {
            var patientRegistrationInfo = await _context.patientRegistrationInfos.FindAsync(id);
            if (patientRegistrationInfo == null)
            {
                return NotFound();
            }

            _context.patientRegistrationInfos.Remove(patientRegistrationInfo);
            await _context.SaveChangesAsync();

            return patientRegistrationInfo;
        }

        private bool PatientRegistrationInfoExists(long id)
        {
            return _context.patientRegistrationInfos.Any(e => e.Id == id);
        }
    }
}
