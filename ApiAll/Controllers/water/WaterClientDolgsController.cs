 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.water;

namespace ApiAll.Controllers.water
{
    [ApiExplorerSettings(GroupName = "v9")]
    [Route("api/[controller]")]
    [ApiController]
    public class WaterClientDolgsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public WaterClientDolgsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/WaterClientDolgs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterClientDolg>>> GetWaterClientDolg()
        {
            return await _context.WaterClientDolg.ToListAsync();
        }

        // GET: api/WaterClientDolgs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterClientDolg>> GetWaterClientDolg(long id)
        {
            var waterClientDolg = await _context.WaterClientDolg.FindAsync(id);

            if (waterClientDolg == null)
            {
                return NotFound();
            }

            return waterClientDolg;
        }

        // PUT: api/WaterClientDolgs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterClientDolg(long id, WaterClientDolg waterClientDolg)
        {
            if (id != waterClientDolg.id)
            {
                return BadRequest();
            }

            _context.Entry(waterClientDolg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterClientDolgExists(id))
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

        // POST: api/WaterClientDolgs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WaterClientDolg>> PostWaterClientDolg(WaterClientDolg waterClientDolg)
        {
            _context.WaterClientDolg.Update(waterClientDolg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaterClientDolg", new { id = waterClientDolg.id }, waterClientDolg);
        }

        // DELETE: api/WaterClientDolgs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WaterClientDolg>> DeleteWaterClientDolg(long id)
        {
            var waterClientDolg = await _context.WaterClientDolg.FindAsync(id);
            if (waterClientDolg == null)
            {
                return NotFound();
            }

            _context.WaterClientDolg.Remove(waterClientDolg);
            await _context.SaveChangesAsync();

            return waterClientDolg;
        }

        private bool WaterClientDolgExists(long id)
        {
            return _context.WaterClientDolg.Any(e => e.id == id);
        }
    }
}
