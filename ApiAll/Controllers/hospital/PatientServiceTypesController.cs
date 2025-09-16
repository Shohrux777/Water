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
    public class PatientServiceTypesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PatientServiceTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PatientServiceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientServiceType>>> GetpatientServiceTypes()
        {
            return await _context.patientServiceTypes.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/PatientServiceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientServiceType>> GetPatientServiceType(long id)
        {
            var patientServiceType = await _context.patientServiceTypes.FindAsync(id);

            if (patientServiceType == null)
            {
                return NotFound();
            }

            return patientServiceType;
        }

        // PUT: api/PatientServiceTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientServiceType(long id, PatientServiceType patientServiceType)
        {
            if (id != patientServiceType.Id)
            {
                return BadRequest();
            }

            _context.Entry(patientServiceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientServiceTypeExists(id))
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

        // POST: api/PatientServiceTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PatientServiceType>> PostPatientServiceType(PatientServiceType patientServiceType)
        {
            _context.patientServiceTypes.Add(patientServiceType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatientServiceType", new { id = patientServiceType.Id }, patientServiceType);
        }

        [HttpGet("addPatientServiceType")]
        public async Task<ActionResult<PatientServiceType>> addPatientServiceType([FromQuery] long Id,[FromQuery] String Name)
        {
            PatientServiceType patientServiceType = new PatientServiceType();
            patientServiceType.ActiveStatus = true;
            patientServiceType.Id = Id;
            patientServiceType.Name = Name;

            _context.patientServiceTypes.Update(patientServiceType);
            await _context.SaveChangesAsync();

            return patientServiceType;
        }

        // DELETE: api/PatientServiceTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PatientServiceType>> DeletePatientServiceType(long id)
        {
            var patientServiceType = await _context.patientServiceTypes.FindAsync(id);
            if (patientServiceType == null)
            {
                return NotFound();
            }

            _context.patientServiceTypes.Remove(patientServiceType);
            await _context.SaveChangesAsync();

            return patientServiceType;
        }

        private bool PatientServiceTypeExists(long id)
        {
            return _context.patientServiceTypes.Any(e => e.Id == id);
        }
    }
}
