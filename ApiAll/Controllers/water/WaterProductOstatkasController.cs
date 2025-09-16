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
    public class WaterProductOstatkasController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public WaterProductOstatkasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/WaterProductOstatkas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterProductOstatka>>> GetWaterProductOstatka()
        {
            return await _context.WaterProductOstatka.ToListAsync();
        }

        // GET: api/WaterProductOstatkas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterProductOstatka>> GetWaterProductOstatka(long id)
        {
            var waterProductOstatka = await _context.WaterProductOstatka.FindAsync(id);

            if (waterProductOstatka == null)
            {
                return NotFound();
            }

            return waterProductOstatka;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterProductOstatka> categoryList = await _context.WaterProductOstatka
                .Include(p => p.product)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterProductOstatka>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterProductOstatka.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/WaterProductOstatkas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterProductOstatka(long id, WaterProductOstatka waterProductOstatka)
        {
            if (id != waterProductOstatka.id)
            {
                return BadRequest();
            }

            _context.Entry(waterProductOstatka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterProductOstatkaExists(id))
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

        // POST: api/WaterProductOstatkas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WaterProductOstatka>> PostWaterProductOstatka(WaterProductOstatka waterProductOstatka)
        {
            _context.WaterProductOstatka.Update(waterProductOstatka);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaterProductOstatka", new { id = waterProductOstatka.id }, waterProductOstatka);
        }

        // DELETE: api/WaterProductOstatkas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WaterProductOstatka>> DeleteWaterProductOstatka(long id)
        {
            var waterProductOstatka = await _context.WaterProductOstatka.FindAsync(id);
            if (waterProductOstatka == null)
            {
                return NotFound();
            }

            _context.WaterProductOstatka.Remove(waterProductOstatka);
            await _context.SaveChangesAsync();

            return waterProductOstatka;
        }

        private bool WaterProductOstatkaExists(long id)
        {
            return _context.WaterProductOstatka.Any(e => e.id == id);
        }
    }
}
