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
    public class AnalizRwsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AnalizRwsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/AnalizRws
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalizRw>>> GetanalizRws()
        {
            return await _context.analizRws.OrderByDescending(p => p.Id).ToListAsync();
        }

        [HttpGet("getByPatientsIDAnalizRws")]
        public async Task<ActionResult<IEnumerable<AnalizRw>>> getByPatientsIDAnalizRws([FromQuery] long PatientsId)
        {
            return await _context.analizRws.Where(a => a.PatientsId == PatientsId).ToListAsync();
        }

        // GET: api/AnalizRws/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalizRw>> GetAnalizRw(long id)
        {
            var analizRw = await _context.analizRws.FindAsync(id);

            if (analizRw == null)
            {
                return NotFound();
            }

            return analizRw;
        }

        // PUT: api/AnalizRws/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalizRw(long id, AnalizRw analizRw)
        {
            if (id != analizRw.Id)
            {
                return BadRequest();
            }

            _context.Entry(analizRw).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalizRwExists(id))
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

        // POST: api/AnalizRws
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnalizRw>> PostAnalizRw(AnalizRw analizRw)
        {
            analizRw.ActiveStatus = true;
            _context.analizRws.Update(analizRw);
            await _context.SaveChangesAsync();

            return analizRw;
        }

        // DELETE: api/AnalizRws/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnalizRw>> DeleteAnalizRw(long id)
        {
            var analizRw = await _context.analizRws.FindAsync(id);
            if (analizRw == null)
            {
                return NotFound();
            }

            _context.analizRws.Remove(analizRw);
            await _context.SaveChangesAsync();

            return analizRw;
        }

        private bool AnalizRwExists(long id)
        {
            return _context.analizRws.Any(e => e.Id == id);
        }
    }
}
