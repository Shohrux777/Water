using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.water;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.water
{
    [ApiExplorerSettings(GroupName = "v9")]
    [Route("api/[controller]")]
    [ApiController]
    public class WaterViloyatsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public WaterViloyatsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/WaterViloyats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterViloyat>>> GetWaterViloyat()
        {
            return await _context.WaterViloyat.ToListAsync();
        }

        // GET: api/WaterViloyats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterViloyat>> GetWaterViloyat(long id)
        {
            var waterViloyat = await _context.WaterViloyat.FindAsync(id);

            if (waterViloyat == null)
            {
                return NotFound();
            }

            return waterViloyat;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterViloyat> categoryList = await _context.WaterViloyat
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterViloyat>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterViloyat.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/WaterViloyats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterViloyat(long id, WaterViloyat waterViloyat)
        {
            if (id != waterViloyat.id)
            {
                return BadRequest();
            }

            _context.Entry(waterViloyat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterViloyatExists(id))
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

        // POST: api/WaterViloyats
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WaterViloyat>> PostWaterViloyat(WaterViloyat waterViloyat)
        {
            _context.WaterViloyat.Update(waterViloyat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaterViloyat", new { id = waterViloyat.id }, waterViloyat);
        }

        // DELETE: api/WaterViloyats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WaterViloyat>> DeleteWaterViloyat(long id)
        {
            var waterViloyat = await _context.WaterViloyat.FindAsync(id);
            if (waterViloyat == null)
            {
                return NotFound();
            }

            _context.WaterViloyat.Remove(waterViloyat);
            await _context.SaveChangesAsync();

            return waterViloyat;
        }

        private bool WaterViloyatExists(long id)
        {
            return _context.WaterViloyat.Any(e => e.id == id);
        }
    }
}
