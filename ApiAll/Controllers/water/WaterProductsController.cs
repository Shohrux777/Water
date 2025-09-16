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
    public class WaterProductsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public WaterProductsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/WaterProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterProduct>>> GetWaterProduct()
        {
            return await _context.WaterProduct.ToListAsync();
        }

        // GET: api/WaterProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterProduct>> GetWaterProduct(long id)
        {
            var waterProduct = await _context.WaterProduct.FindAsync(id);

            if (waterProduct == null)
            {
                return NotFound();
            }

            return waterProduct;
        }


        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterProduct> categoryList = await _context.WaterProduct
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterProduct>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterProduct.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationMainProduct")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationMainProduct([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterProduct> categoryList = await _context.WaterProduct
                .Where(p => p.active_status == true
                && p.main_product == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterProduct>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterProduct.Where(p => p.active_status == true
            && p.main_product == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationSearchByName")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationSearchByName([FromQuery] int page, [FromQuery] int size,[FromQuery] String name)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterProduct> categoryList = await _context.WaterProduct
                .Where(p => p.active_status == true  && p.name.ToLower().Contains(name.ToLower()))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterProduct>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterProduct
                .Where(p => p.active_status == true && p.name.ToLower().Contains(name.ToLower()))
                .CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/WaterProducts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterProduct(long id, WaterProduct waterProduct)
        {
            if (id != waterProduct.id)
            {
                return BadRequest();
            }

            _context.Entry(waterProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterProductExists(id))
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

        // POST: api/WaterProducts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WaterProduct>> PostWaterProduct(WaterProduct waterProduct)
        {
            _context.WaterProduct.Update(waterProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaterProduct", new { id = waterProduct.id }, waterProduct);
        }

        // DELETE: api/WaterProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WaterProduct>> DeleteWaterProduct(long id)
        {
            var waterProduct = await _context.WaterProduct.FindAsync(id);
            if (waterProduct == null)
            {
                return NotFound();
            }

            _context.WaterProduct.Remove(waterProduct);
            await _context.SaveChangesAsync();

            return waterProduct;
        }

        private bool WaterProductExists(long id)
        {
            return _context.WaterProduct.Any(e => e.id == id);
        }
    }
}
