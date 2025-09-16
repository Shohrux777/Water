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
    public class HospitalServiceTypeGroupsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalServiceTypeGroupsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalServiceTypeGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalServiceTypeGroup>>> GetHospitalServiceTypeGroup()
        {
            return await _context.HospitalServiceTypeGroup.ToListAsync();
        }

        // GET: api/HospitalServiceTypeGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalServiceTypeGroup>> GetHospitalServiceTypeGroup(long id)
        {
            var hospitalServiceTypeGroup = await _context.HospitalServiceTypeGroup.FindAsync(id);

            if (hospitalServiceTypeGroup == null)
            {
                return NotFound();
            }

            return hospitalServiceTypeGroup;
        }

        // PUT: api/HospitalServiceTypeGroups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalServiceTypeGroup(long id, HospitalServiceTypeGroup hospitalServiceTypeGroup)
        {
            if (id != hospitalServiceTypeGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalServiceTypeGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalServiceTypeGroupExists(id))
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

        // POST: api/HospitalServiceTypeGroups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalServiceTypeGroup>> PostHospitalServiceTypeGroup(HospitalServiceTypeGroup hospitalServiceTypeGroup)
        {
            _context.HospitalServiceTypeGroup.Update(hospitalServiceTypeGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalServiceTypeGroup", new { id = hospitalServiceTypeGroup.Id }, hospitalServiceTypeGroup);
        }

        // DELETE: api/HospitalServiceTypeGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalServiceTypeGroup>> DeleteHospitalServiceTypeGroup(long id)
        {
            var hospitalServiceTypeGroup = await _context.HospitalServiceTypeGroup.FindAsync(id);
            if (hospitalServiceTypeGroup == null)
            {
                return NotFound();
            }

            _context.HospitalServiceTypeGroup.Remove(hospitalServiceTypeGroup);
            await _context.SaveChangesAsync();

            return hospitalServiceTypeGroup;
        }

        private bool HospitalServiceTypeGroupExists(long id)
        {
            return _context.HospitalServiceTypeGroup.Any(e => e.Id == id);
        }
    }
}
