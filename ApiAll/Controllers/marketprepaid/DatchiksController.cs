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
    public class DatchiksController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public DatchiksController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Datchiks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Datchik>>> Getdatchiks()
        {
            return await _context.datchiks.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/Datchiks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Datchik>> GetDatchik(long id)
        {
            var datchik = await _context.datchiks.FindAsync(id);

            if (datchik == null)
            {
                return NotFound();
            }

            return datchik;
        }

        // PUT: api/Datchiks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDatchik(long id, Datchik datchik)
        {
            if (id != datchik.Id)
            {
                return BadRequest();
            }

            _context.Entry(datchik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatchikExists(id))
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

        // POST: api/Datchiks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Datchik>> PostDatchik(Datchik datchik)
        {
            _context.datchiks.Add(datchik);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDatchik", new { id = datchik.Id }, datchik);
        }

        [HttpGet("addDatchik")]
        public async Task<ActionResult<Datchik>> addDatchik([FromQuery] long Id, [FromQuery] String name, [FromQuery] String serialNumber,[FromQuery]String note,[FromQuery] double min, [FromQuery] double max)
        {
            Datchik datchik = new Datchik();
            datchik.ActiveStatus = true;
            datchik.Id = Id;
            datchik.name = name;
            datchik.note = note;
            datchik.serialNumber = serialNumber;
            datchik.min = min;
            datchik.max = max;

            _context.datchiks.Update(datchik);
            await _context.SaveChangesAsync();

            return datchik;
        }
        // DELETE: api/Datchiks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Datchik>> DeleteDatchik(long id)
        {
            var datchik = await _context.datchiks.FindAsync(id);
            if (datchik == null)
            {
                return NotFound();
            }

            _context.datchiks.Remove(datchik);
            await _context.SaveChangesAsync();

            return datchik;
        }

        private bool DatchikExists(long id)
        {
            return _context.datchiks.Any(e => e.Id == id);
        }
    }
}
