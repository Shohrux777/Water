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
    public class WaterClientBottleInfoDetailsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public WaterClientBottleInfoDetailsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/WaterClientBottleInfoDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterClientBottleInfoDetail>>> GetWaterClientBottleInfoDetail()
        {
            return await _context.WaterClientBottleInfoDetail.ToListAsync();
        }

        // GET: api/WaterClientBottleInfoDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterClientBottleInfoDetail>> GetWaterClientBottleInfoDetail(long id)
        {
            var waterClientBottleInfoDetail = await _context.WaterClientBottleInfoDetail.FindAsync(id);

            if (waterClientBottleInfoDetail == null)
            {
                return NotFound();
            }

            return waterClientBottleInfoDetail;
        }

        // PUT: api/WaterClientBottleInfoDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterClientBottleInfoDetail(long id, WaterClientBottleInfoDetail waterClientBottleInfoDetail)
        {
            if (id != waterClientBottleInfoDetail.id)
            {
                return BadRequest();
            }

            _context.Entry(waterClientBottleInfoDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterClientBottleInfoDetailExists(id))
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

        // POST: api/WaterClientBottleInfoDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WaterClientBottleInfoDetail>> PostWaterClientBottleInfoDetail(WaterClientBottleInfoDetail waterClientBottleInfoDetail)
        {
            _context.WaterClientBottleInfoDetail.Update(waterClientBottleInfoDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaterClientBottleInfoDetail", new { id = waterClientBottleInfoDetail.id }, waterClientBottleInfoDetail);
        }

        // DELETE: api/WaterClientBottleInfoDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WaterClientBottleInfoDetail>> DeleteWaterClientBottleInfoDetail(long id)
        {
            var waterClientBottleInfoDetail = await _context.WaterClientBottleInfoDetail.FindAsync(id);
            if (waterClientBottleInfoDetail == null)
            {
                return NotFound();
            }

            _context.WaterClientBottleInfoDetail.Remove(waterClientBottleInfoDetail);
            await _context.SaveChangesAsync();

            return waterClientBottleInfoDetail;
        }

        private bool WaterClientBottleInfoDetailExists(long id)
        {
            return _context.WaterClientBottleInfoDetail.Any(e => e.id == id);
        }
    }
}
