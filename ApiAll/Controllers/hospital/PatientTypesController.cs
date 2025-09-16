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
    public class PatientTypesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PatientTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PatientTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientType>>> GetpatientTypes()
        {
            return await _context.patientTypes.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/PatientTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientType>> GetPatientType(long id)
        {
            var patientType = await _context.patientTypes.FindAsync(id);

            if (patientType == null)
            {
                return NotFound();
            }

            return patientType;
        }

        // PUT: api/PatientTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientType(long id, PatientType patientType)
        {
            if (id != patientType.Id)
            {
                return BadRequest();
            }

            _context.Entry(patientType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientTypeExists(id))
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

        // POST: api/PatientTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PatientType>> PostPatientType(PatientType patientType)
        {
            _context.patientTypes.Add(patientType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatientType", new { id = patientType.Id }, patientType);
        }

        [HttpGet("addPatientType")]
        public async Task<ActionResult<PatientType>> addPatientType([FromQuery]long Id,[FromQuery] String Name)
        {
            PatientType patientType = new PatientType();
            patientType.ActiveStatus = true;
            patientType.Id = Id;
            patientType.Name = Name;
            _context.patientTypes.Update(patientType);
            await _context.SaveChangesAsync();

            return patientType;
        }

        // DELETE: api/PatientTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PatientType>> DeletePatientType(long id)
        {
            var patientType = await _context.patientTypes.FindAsync(id);
            if (patientType == null)
            {
                return NotFound();
            }

            _context.patientTypes.Remove(patientType);
            await _context.SaveChangesAsync();

            return patientType;
        }

        private bool PatientTypeExists(long id)
        {
            return _context.patientTypes.Any(e => e.Id == id);
        }
    }
}
