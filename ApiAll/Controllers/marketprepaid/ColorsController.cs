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
    public class ColorsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ColorsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Colors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Color>>> Getcolors()
        {
            return await _context.colors.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/Colors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Color>> GetColor(long id)
        {
            var color = await _context.colors.FindAsync(id);

            if (color == null)
            {
                return NotFound();
            }

            return color;
        }

        // PUT: api/Colors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor(long id, Color color)
        {
            if (id != color.Id)
            {
                return BadRequest();
            }

            _context.Entry(color).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorExists(id))
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

        // POST: api/Colors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Color>> PostColor(Color color)
        {
            _context.colors.Add(color);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColor", new { id = color.Id }, color);
        }

        [HttpGet("addColor")]
        public async Task<ActionResult<Color>> addColor([FromQuery] long Id, [FromQuery] String name, [FromQuery] String value)
        {
            Color color = new Color();
            color.ActiveStatus = true;
            color.Id = Id;
            color.name = name;
            color.value = value;
            color.line = String.Empty;
            _context.colors.Update(color);
            await _context.SaveChangesAsync();

            return color;
        }

        // DELETE: api/Colors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Color>> DeleteColor(long id)
        {
            var color = await _context.colors.FindAsync(id);
            if (color == null)
            {
                return NotFound();
            }

            _context.colors.Remove(color);
            await _context.SaveChangesAsync();

            return color;
        }

        private bool ColorExists(long id)
        {
            return _context.colors.Any(e => e.Id == id);
        }
    }
}
