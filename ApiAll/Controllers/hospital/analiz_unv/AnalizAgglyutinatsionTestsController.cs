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
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class AnalizAgglyutinatsionTestsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AnalizAgglyutinatsionTestsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/AnalizAgglyutinatsionTests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalizAgglyutinatsionTest>>> GetAnalizAgglyutinatsionTest()
        {
            return await _context.AnalizAgglyutinatsionTest.Include(p => p.patients).OrderByDescending(p => p.Id).ToListAsync();
        }


        [HttpGet("getAnalizAgglyutinatsionTestByPatientId")]
        public async Task<ActionResult<IEnumerable<AnalizAgglyutinatsionTest>>> getAnalizAgglyutinatsionTestByPatientId([FromQuery] long patientId)
        {
            return await _context.AnalizAgglyutinatsionTest.Where( p => p.PatientsId == patientId).Include(p => p.patients).OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/AnalizAgglyutinatsionTests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalizAgglyutinatsionTest>> GetAnalizAgglyutinatsionTest(long id)
        {
            var analizAgglyutinatsionTest = await _context.AnalizAgglyutinatsionTest.FindAsync(id);

            if (analizAgglyutinatsionTest == null)
            {
                return NotFound();
            }

            return analizAgglyutinatsionTest;
        }

        // PUT: api/AnalizAgglyutinatsionTests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalizAgglyutinatsionTest(long id, AnalizAgglyutinatsionTest analizAgglyutinatsionTest)
        {
            if (id != analizAgglyutinatsionTest.Id)
            {
                return BadRequest();
            }

            _context.Entry(analizAgglyutinatsionTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalizAgglyutinatsionTestExists(id))
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

        // POST: api/AnalizAgglyutinatsionTests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnalizAgglyutinatsionTest>> PostAnalizAgglyutinatsionTest(AnalizAgglyutinatsionTest analizAgglyutinatsionTest)
        {
            _context.AnalizAgglyutinatsionTest.Update(analizAgglyutinatsionTest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalizAgglyutinatsionTest", new { id = analizAgglyutinatsionTest.Id }, analizAgglyutinatsionTest);
        }

        // DELETE: api/AnalizAgglyutinatsionTests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnalizAgglyutinatsionTest>> DeleteAnalizAgglyutinatsionTest(long id)
        {
            var analizAgglyutinatsionTest = await _context.AnalizAgglyutinatsionTest.FindAsync(id);
            if (analizAgglyutinatsionTest == null)
            {
                return NotFound();
            }

            _context.AnalizAgglyutinatsionTest.Remove(analizAgglyutinatsionTest);
            await _context.SaveChangesAsync();

            return analizAgglyutinatsionTest;
        }

        private bool AnalizAgglyutinatsionTestExists(long id)
        {
            return _context.AnalizAgglyutinatsionTest.Any(e => e.Id == id);
        }
    }
}
