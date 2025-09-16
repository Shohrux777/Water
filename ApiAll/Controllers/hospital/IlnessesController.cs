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
    public class IlnessesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public IlnessesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Ilnesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ilness>>> Getilnesses()
        {
            return await _context.ilnesses.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/Ilnesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ilness>> GetIlness(long id)
        {
            var ilness = await _context.ilnesses.FindAsync(id);

            if (ilness == null)
            {
                return NotFound();
            }

            return ilness;
        }

        // PUT: api/Ilnesses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIlness(long id, Ilness ilness)
        {
            if (id != ilness.Id)
            {
                return BadRequest();
            }

            _context.Entry(ilness).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IlnessExists(id))
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

        // POST: api/Ilnesses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ilness>> PostIlness(Ilness ilness)
        {
            _context.ilnesses.Add(ilness);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIlness", new { id = ilness.Id }, ilness);
        }

        [HttpGet("addIllness")]
        public async Task<ActionResult<Ilness>> AddIllness([FromQuery] long Id, [FromQuery] String name)
        {
            Ilness ilness = new Ilness();
            ilness.ActiveStatus = true;
            ilness.Id = Id;
            ilness.Note = String.Empty;
            ilness.Name = name;

            _context.ilnesses.Update(ilness);
            await _context.SaveChangesAsync();

            return ilness;
        }

        // DELETE: api/Ilnesses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ilness>> DeleteIlness(long id)
        {
            var ilness = await _context.ilnesses.FindAsync(id);
            if (ilness == null)
            {
                return NotFound();
            }

            _context.ilnesses.Remove(ilness);
            await _context.SaveChangesAsync();

            return ilness;
        }

        private bool IlnessExists(long id)
        {
            return _context.ilnesses.Any(e => e.Id == id);
        }
    }
}
