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
    public class HospitalCreditorItemController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalCreditorItemController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalCreditorItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalCreditorItem>>> GetHospitalCreditorItem()
        {
            return await _context.HospitalCreditorItem.ToListAsync();
        }

        // GET: api/HospitalCreditorItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalCreditorItem>> GetHospitalCreditorItem(long id)
        {
            var hospitalCreditorItem = await _context.HospitalCreditorItem.FindAsync(id);

            if (hospitalCreditorItem == null)
            {
                return NotFound();
            }
            hospitalCreditorItem.patients = await _context.Patients.FindAsync(hospitalCreditorItem.PatientsId);
            return hospitalCreditorItem;
        }

        // PUT: api/HospitalCreditorItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalCreditorItem(long id, HospitalCreditorItem hospitalCreditorItem)
        {
            if (id != hospitalCreditorItem.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalCreditorItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalCreditorItemExists(id))
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

        // POST: api/HospitalCreditorItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalCreditorItem>> PostHospitalCreditorItem(HospitalCreditorItem hospitalCreditorItem)
        {
            HospitalCreditor creditor = await _context.HospitalCreditor.FindAsync(hospitalCreditorItem.HospitalCreditorid);
            creditor.real_sum = creditor.real_sum - hospitalCreditorItem.summ;


            _context.HospitalCreditor.Update(creditor);
            await _context.SaveChangesAsync();

            _context.HospitalCreditorItem.Update(hospitalCreditorItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalCreditorItem", new { id = hospitalCreditorItem.id }, hospitalCreditorItem);
        }

        // DELETE: api/HospitalCreditorItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalCreditorItem>> DeleteHospitalCreditorItem(long id)
        {
            var hospitalCreditorItem = await _context.HospitalCreditorItem.FindAsync(id);
            if (hospitalCreditorItem == null)
            {
                return NotFound();
            }

            _context.HospitalCreditorItem.Remove(hospitalCreditorItem);
            await _context.SaveChangesAsync();

            return hospitalCreditorItem;
        }

        private bool HospitalCreditorItemExists(long id)
        {
            return _context.HospitalCreditorItem.Any(e => e.id == id);
        }
    }
}
