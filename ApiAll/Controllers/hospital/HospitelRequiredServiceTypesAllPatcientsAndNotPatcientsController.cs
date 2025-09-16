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
    public class HospitelRequiredServiceTypesAllPatcientsAndNotPatcientsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitelRequiredServiceTypesAllPatcientsAndNotPatcientsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitelRequiredServiceTypesAllPatcientsAndNotPatcients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitelRequiredServiceTypesAllPatcientsAndNotPatcients>>> GetHospitelRequiredServiceTypesAllPatcientsAndNotPatcients()
        {
            return await _context.HospitelRequiredServiceTypesAllPatcientsAndNotPatcients.Include( p => p.serviceType).OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/HospitelRequiredServiceTypesAllPatcientsAndNotPatcients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitelRequiredServiceTypesAllPatcientsAndNotPatcients>> GetHospitelRequiredServiceTypesAllPatcientsAndNotPatcients(long id)
        {
            var hospitelRequiredServiceTypesAllPatcientsAndNotPatcients = await _context.HospitelRequiredServiceTypesAllPatcientsAndNotPatcients.FindAsync(id);

            if (hospitelRequiredServiceTypesAllPatcientsAndNotPatcients == null)
            {
                return NotFound();
            }

            return hospitelRequiredServiceTypesAllPatcientsAndNotPatcients;
        }

        // PUT: api/HospitelRequiredServiceTypesAllPatcientsAndNotPatcients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitelRequiredServiceTypesAllPatcientsAndNotPatcients(long id, HospitelRequiredServiceTypesAllPatcientsAndNotPatcients hospitelRequiredServiceTypesAllPatcientsAndNotPatcients)
        {
            if (id != hospitelRequiredServiceTypesAllPatcientsAndNotPatcients.Id)
            {
                return BadRequest();
            }

            _context.Entry(hospitelRequiredServiceTypesAllPatcientsAndNotPatcients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitelRequiredServiceTypesAllPatcientsAndNotPatcientsExists(id))
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

        // POST: api/HospitelRequiredServiceTypesAllPatcientsAndNotPatcients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitelRequiredServiceTypesAllPatcientsAndNotPatcients>> PostHospitelRequiredServiceTypesAllPatcientsAndNotPatcients(HospitelRequiredServiceTypesAllPatcientsAndNotPatcients hospitelRequiredServiceTypesAllPatcientsAndNotPatcients)
        {
            _context.HospitelRequiredServiceTypesAllPatcientsAndNotPatcients.Update(hospitelRequiredServiceTypesAllPatcientsAndNotPatcients);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitelRequiredServiceTypesAllPatcientsAndNotPatcients", new { id = hospitelRequiredServiceTypesAllPatcientsAndNotPatcients.Id }, hospitelRequiredServiceTypesAllPatcientsAndNotPatcients);
        }

        // DELETE: api/HospitelRequiredServiceTypesAllPatcientsAndNotPatcients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitelRequiredServiceTypesAllPatcientsAndNotPatcients>> DeleteHospitelRequiredServiceTypesAllPatcientsAndNotPatcients(long id)
        {
            var hospitelRequiredServiceTypesAllPatcientsAndNotPatcients = await _context.HospitelRequiredServiceTypesAllPatcientsAndNotPatcients.FindAsync(id);
            if (hospitelRequiredServiceTypesAllPatcientsAndNotPatcients == null)
            {
                return NotFound();
            }

            _context.HospitelRequiredServiceTypesAllPatcientsAndNotPatcients.Remove(hospitelRequiredServiceTypesAllPatcientsAndNotPatcients);
            await _context.SaveChangesAsync();

            return hospitelRequiredServiceTypesAllPatcientsAndNotPatcients;
        }

        private bool HospitelRequiredServiceTypesAllPatcientsAndNotPatcientsExists(long id)
        {
            return _context.HospitelRequiredServiceTypesAllPatcientsAndNotPatcients.Any(e => e.Id == id);
        }
    }
}
