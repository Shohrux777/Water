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
    public class WaterContragentTypesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public WaterContragentTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/WaterContragentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterContragentType>>> GetWaterContragentType()
        {
            return await _context.WaterContragentType.ToListAsync();
        }

        // GET: api/WaterContragentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterContragentType>> GetWaterContragentType(long id)
        {
            var waterContragentType = await _context.WaterContragentType.FindAsync(id);

            if (waterContragentType == null)
            {
                return NotFound();
            }

            return waterContragentType;
        }

        // PUT: api/WaterContragentTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterContragentType(long id, WaterContragentType waterContragentType)
        {
            if (id != waterContragentType.id)
            {
                return BadRequest();
            }

            _context.Entry(waterContragentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterContragentTypeExists(id))
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

        // POST: api/WaterContragentTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WaterContragentType>> PostWaterContragentType(WaterContragentType waterContragentType)
        {
            _context.WaterContragentType.Update(waterContragentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaterContragentType", new { id = waterContragentType.id }, waterContragentType);
        }

        // DELETE: api/WaterContragentTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WaterContragentType>> DeleteWaterContragentType(long id)
        {
            var waterContragentType = await _context.WaterContragentType.FindAsync(id);
            if (waterContragentType == null)
            {
                return NotFound();
            }

            _context.WaterContragentType.Remove(waterContragentType);
            await _context.SaveChangesAsync();

            return waterContragentType;
        }

        private bool WaterContragentTypeExists(long id)
        {
            return _context.WaterContragentType.Any(e => e.id == id);
        }
    }
}
