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
    public class WaterTumenController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public WaterTumenController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/WaterTumen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterTuman>>> GetWaterTuman()
        {
            return await _context.WaterTuman.ToListAsync();
        }

        // GET: api/WaterTumen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterTuman>> GetWaterTuman(long id)
        {
            var waterTuman = await _context.WaterTuman.FindAsync(id);

            if (waterTuman == null)
            {
                return NotFound();
            }

            return waterTuman;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterTuman> categoryList = await _context.WaterTuman
                .Include(p => p.viloyat)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterTuman>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterTuman.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/WaterTumen/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterTuman(long id, WaterTuman waterTuman)
        {
            if (id != waterTuman.id)
            {
                return BadRequest();
            }

            _context.Entry(waterTuman).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterTumanExists(id))
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

        // POST: api/WaterTumen
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WaterTuman>> PostWaterTuman(WaterTuman waterTuman)
        {
            _context.WaterTuman.Update(waterTuman);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaterTuman", new { id = waterTuman.id }, waterTuman);
        }

        // DELETE: api/WaterTumen/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WaterTuman>> DeleteWaterTuman(long id)
        {
            var waterTuman = await _context.WaterTuman.FindAsync(id);
            if (waterTuman == null)
            {
                return NotFound();
            }

            _context.WaterTuman.Remove(waterTuman);
            await _context.SaveChangesAsync();

            return waterTuman;
        }

        private bool WaterTumanExists(long id)
        {
            return _context.WaterTuman.Any(e => e.id == id);
        }
    }
}
