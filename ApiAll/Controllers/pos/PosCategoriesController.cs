using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.pos;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.pos
{
    [ApiExplorerSettings(GroupName = "v5")]
    [Route("api/[controller]")]
    [ApiController]
    public class PosCategoriesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosCategoriesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosCategory>>> GetPosCategory()
        {
            return await _context.PosCategory.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosCategory> itemList = await _context.PosCategory
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosCategory>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count =  await _context.PosCategory.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getProductListBycategoryId")]
        public async Task<ActionResult<IEnumerable<PosProduct>>> getProductListBycategoryId([FromQuery] long category_id)
        {
            return await _context.PosProduct.Include(p =>p.measurment).Where(p => p.category_id == category_id).OrderByDescending(p =>p.id).ToListAsync();
        }

        [HttpGet("getProductListBycategoryIdPagination")]
        public async Task<ActionResult<TexPaginationModel>> getProductListBycategoryIdPagination([FromQuery] int page, [FromQuery] int size, [FromQuery] long category_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosProduct> itemList = await _context.PosProduct.Include(p => p.measurment)
                .Where(p => p.category_id == category_id)
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosProduct>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosProduct
                .Where(p => p.category_id == category_id)
                .CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/PosCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosCategory>> GetPosCategory(long id)
        {
            var posCategory = await _context.PosCategory.FindAsync(id);

            if (posCategory == null)
            {
                return NotFound();
            }

            return posCategory;
        }

        // PUT: api/PosCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosCategory(long id, PosCategory posCategory)
        {
            if (id != posCategory.id)
            {
                return BadRequest();
            }

            _context.Entry(posCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosCategoryExists(id))
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

        // POST: api/PosCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosCategory>> PostPosCategory(PosCategory posCategory)
        {
            try
            {
                _context.PosCategory.Update(posCategory);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                return NotFound(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFound(e?.InnerException?.Message);
            }

            return CreatedAtAction("GetPosCategory", new { id = posCategory.id }, posCategory);
        }

        // DELETE: api/PosCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosCategory>> DeletePosCategory(long id)
        {
            var posCategory = await _context.PosCategory.FindAsync(id);
            if (posCategory == null)
            {
                return NotFound();
            }

            _context.PosCategory.Remove(posCategory);
            await _context.SaveChangesAsync();

            return posCategory;
        }

        private bool PosCategoryExists(long id)
        {
            return _context.PosCategory.Any(e => e.id == id);
        }
    }
}
