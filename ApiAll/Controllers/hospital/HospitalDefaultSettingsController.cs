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
    public class HospitalDefaultSettingsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalDefaultSettingsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalDefaultSettings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalDefaultSettings>>> GetHospitalDefaultSettings()
        {
            return await _context.HospitalDefaultSettings
                .Include(p => p.authorization)
                .Include(p => p.contragent)
                .Include(p => p.serviceType)
                .ToListAsync();
        }

        // GET: api/HospitalDefaultSettings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalDefaultSettings>> GetHospitalDefaultSettings(long id)
        {
            var hospitalDefaultSettings = await _context.HospitalDefaultSettings
                .Where(p =>p.id == id)
                .Include(p => p.authorization)
                .Include(p => p.contragent)
                .Include(p => p.serviceType)
                .ToListAsync();

            if (hospitalDefaultSettings == null || hospitalDefaultSettings.Count == 0)
            {
                return NotFound();
            }

            return hospitalDefaultSettings.First();
        }

        // PUT: api/HospitalDefaultSettings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalDefaultSettings(long id, HospitalDefaultSettings hospitalDefaultSettings)
        {
            if (id != hospitalDefaultSettings.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalDefaultSettings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalDefaultSettingsExists(id))
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

        // POST: api/HospitalDefaultSettings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalDefaultSettings>> PostHospitalDefaultSettings(HospitalDefaultSettings hospitalDefaultSettings)
        {
            _context.HospitalDefaultSettings.Update(hospitalDefaultSettings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalDefaultSettings", new { id = hospitalDefaultSettings.id }, hospitalDefaultSettings);
        }

        // DELETE: api/HospitalDefaultSettings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalDefaultSettings>> DeleteHospitalDefaultSettings(long id)
        {
            var hospitalDefaultSettings = await _context.HospitalDefaultSettings.FindAsync(id);
            if (hospitalDefaultSettings == null)
            {
                return NotFound();
            }

            _context.HospitalDefaultSettings.Remove(hospitalDefaultSettings);
            await _context.SaveChangesAsync();

            return hospitalDefaultSettings;
        }

        private bool HospitalDefaultSettingsExists(long id)
        {
            return _context.HospitalDefaultSettings.Any(e => e.id == id);
        }
    }
}
