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
    public class WaterClientTypesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public WaterClientTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/WaterClientTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterClientType>>> GetWaterClientType()
        {
            return await _context.WaterClientType.ToListAsync();
        }

        // GET: api/WaterClientTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterClientType>> GetWaterClientType(long id)
        {
            var waterClientType = await _context.WaterClientType.FindAsync(id);

            if (waterClientType == null)
            {
                return NotFound();
            }

            return waterClientType;
        }

        // PUT: api/WaterClientTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterClientType(long id, WaterClientType waterClientType)
        {
            if (id != waterClientType.id)
            {
                return BadRequest();
            }

            _context.Entry(waterClientType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterClientTypeExists(id))
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

        // POST: api/WaterClientTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WaterClientType>> PostWaterClientType(WaterClientType waterClientType)
        {
            _context.WaterClientType.Update(waterClientType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaterClientType", new { id = waterClientType.id }, waterClientType);
        }

        // DELETE: api/WaterClientTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WaterClientType>> DeleteWaterClientType(long id)
        {
            var waterClientType = await _context.WaterClientType.FindAsync(id);
            if (waterClientType == null)
            {
                return NotFound();
            }

            _context.WaterClientType.Remove(waterClientType);
            await _context.SaveChangesAsync();

            return waterClientType;
        }

        private bool WaterClientTypeExists(long id)
        {
            return _context.WaterClientType.Any(e => e.id == id);
        }
    }
}
