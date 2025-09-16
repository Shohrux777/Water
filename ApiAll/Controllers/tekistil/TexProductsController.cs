using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tekistil
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexProductsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexProductsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexProduct>>> GetTexProduct()
        {
            return await _context.TexProduct.Where( p => p.active_status == true).OrderByDescending(p =>p.id).Include(p =>p.unitmeasurment).Include( p => p.unitmeasurment_2).Include( p => p.productionType).ToListAsync();
        }


        [HttpGet("searchProductByFilter")]
        public async Task<ActionResult<IEnumerable<TexProduct>>> searchProductByFilter([FromQuery] String name, [FromQuery] int size)
        {
            return await _context.TexProduct.Where(p => p.active_status == true && (p.name.ToLower().Contains(name.Trim().ToLower()) || p.code.ToLower().Contains(name.Trim().ToLower()) || p.code_2.ToLower().Contains(name.Trim().ToLower()) )).OrderByDescending(p => p.id).Include(p => p.unitmeasurment).Include(p => p.unitmeasurment_2).Include(p => p.productionType).Take(size).ToListAsync();
        }


        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexProduct> itemList = await _context.TexProduct.Where(p => p.active_status == true).Include( p => p.productionType)
                .Include(p => p.unitmeasurment)
                .Include(p => p.unitmeasurment_2)
                .Include(p => p.texProductAndRecipes)
                .OrderByDescending(p => p.id).Skip(size * page).Take(size).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexProduct>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexProduct.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByCategoryId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByCategoryId([FromQuery] int page,
            [FromQuery] int size,[FromQuery] long category_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexProduct> itemList = await _context.TexProduct
                .Where(p => p.active_status == true && p.category_id == category_id).Include(p => p.productionType)
                .Include(p => p.unitmeasurment)
                .Include(p => p.unitmeasurment_2)
                .Include(p => p.texProductAndRecipes)
                .OrderByDescending(p => p.id).Skip(size * page).Take(size).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexProduct>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexProduct.Where(p => p.active_status == true
            && p.category_id == category_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationTovarFarqi")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationTovarFarqi([FromQuery] int page,
            [FromQuery] int size, [FromQuery] long tovar_farqi)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexProduct> itemList = await _context.TexProduct.Where(p => p.active_status == true && p.tovarlar_farqi == tovar_farqi).Include(p => p.productionType)
                .Include(p => p.unitmeasurment)
                .Include(p => p.unitmeasurment_2)
                .Include(p => p.texProductAndRecipes)
                .OrderByDescending(p => p.id).Skip(size * page).Take(size).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexProduct>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexProduct.Where(p => p.active_status == true && p.tovarlar_farqi == tovar_farqi).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TexProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexProduct>> GetTexProduct(long id)
        {
            var texProduct = await _context.TexProduct
                .Include(p => p.unitmeasurment)
                .Include(p => p.unitmeasurment_2)
                .Include(p =>p.category)
                .Include(p =>p.productionType)
                .Include(p => p.texProductAndRecipes)
                .Where(p => p.id == id).ToListAsync();

            if (texProduct == null || texProduct.Count == 0)
            {
                return NotFound();
            }

            List<TexXarakteristika> xarakteristikaList = await _context.TexXarakteristika
                .Where(p => texProduct.First()
                .selected_xarakteristika_ids.Contains(p.id)).ToListAsync();

            texProduct.First().texXarakteristikaList = xarakteristikaList;

            List<TexXarakteristikaTool> xarakteristikaToolList = await _context.TexXarakteristikaTool
            .Where(p => texProduct.First()
            .selected_xarakteristika_ids.Contains(p.id)).Include(p =>p.xarakteristika).ToListAsync();

                    texProduct.First().texXarakteristikaToolList = xarakteristikaToolList;


            List<TexPlaningType> planniyTypeList = await _context.TexPlaningType
                .Where(p => texProduct.First()
                .planning_type_id.Contains(p.id)).ToListAsync();

            texProduct.First().texPlaningTypeList = planniyTypeList;


            return texProduct.First();
        }

        // PUT: api/TexProducts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexProduct(long id, TexProduct texProduct)
        {
            if (id != texProduct.id)
            {
                return BadRequest();
            }

            _context.Entry(texProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexProductExists(id))
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

        // POST: api/TexProducts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexProduct>> PostTexProduct(TexProduct texProduct)
        {
           
 
                try
                {
                    _context.TexProduct.Update(texProduct);
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


            return texProduct;
        }

        // DELETE: api/TexProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexProduct>> DeleteTexProduct(long id)
        {
            var texProduct = await _context.TexProduct.FindAsync(id);
            if (texProduct == null)
            {
                return NotFound();
            }

            _context.TexProduct.Remove(texProduct);
            await _context.SaveChangesAsync();

            return texProduct;
        }

        private bool TexProductExists(long id)
        {
            return _context.TexProduct.Any(e => e.id == id);
        }
    }
}
