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
    public class HospitalServiceTypeByGroupPermissionsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalServiceTypeByGroupPermissionsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalServiceTypeByGroupPermissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalServiceTypeByGroupPermission>>> GetHospitalServiceTypeByGroupPermission()
        {
            return await _context.HospitalServiceTypeByGroupPermission.Include( p => p.ServiceTypeGroup).ToListAsync();
        }

        // GET: api/HospitalServiceTypeByGroupPermissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalServiceTypeByGroupPermission>> GetHospitalServiceTypeByGroupPermission(long id)
        {
            var hospitalServiceTypeByGroupPermission = await _context.HospitalServiceTypeByGroupPermission.FindAsync(id);

            if (hospitalServiceTypeByGroupPermission == null)
            {
                return NotFound();
            }

            return hospitalServiceTypeByGroupPermission;
        }

        // PUT: api/HospitalServiceTypeByGroupPermissions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalServiceTypeByGroupPermission(long id, HospitalServiceTypeByGroupPermission hospitalServiceTypeByGroupPermission)
        {
            if (id != hospitalServiceTypeByGroupPermission.Id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalServiceTypeByGroupPermission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalServiceTypeByGroupPermissionExists(id))
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

        // POST: api/HospitalServiceTypeByGroupPermissions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalServiceTypeByGroupPermission>> PostHospitalServiceTypeByGroupPermission(HospitalServiceTypeByGroupPermission hospitalServiceTypeByGroupPermission)
        {
            _context.HospitalServiceTypeByGroupPermission.Update(hospitalServiceTypeByGroupPermission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalServiceTypeByGroupPermission", new { id = hospitalServiceTypeByGroupPermission.Id }, hospitalServiceTypeByGroupPermission);
        }

        // DELETE: api/HospitalServiceTypeByGroupPermissions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalServiceTypeByGroupPermission>> DeleteHospitalServiceTypeByGroupPermission(long id)
        {
            var hospitalServiceTypeByGroupPermission = await _context.HospitalServiceTypeByGroupPermission.FindAsync(id);
            if (hospitalServiceTypeByGroupPermission == null)
            {
                return NotFound();
            }

            _context.HospitalServiceTypeByGroupPermission.Remove(hospitalServiceTypeByGroupPermission);
            await _context.SaveChangesAsync();

            return hospitalServiceTypeByGroupPermission;
        }

        private bool HospitalServiceTypeByGroupPermissionExists(long id)
        {
            return _context.HospitalServiceTypeByGroupPermission.Any(e => e.Id == id);
        }
    }
}
