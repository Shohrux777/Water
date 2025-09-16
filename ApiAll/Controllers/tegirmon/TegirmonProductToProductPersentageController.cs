using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tegirmon;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tegirmon
{
    [ApiExplorerSettings(GroupName = "v7")]
    [Route("api/[controller]")]
    [ApiController]
    public class TegirmonProductToProductPersentageController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonProductToProductPersentageController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonProductToProductPersentage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonProductToProductPersentage>>> GetTegirmonProductToProductPersentage()
        {
            return await _context.TegirmonProductToProductPersentage.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonProductToProductPersentage> categoryList = await _context.TegirmonProductToProductPersentage
                .Include(p => p.product)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonProductToProductPersentage>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonProductToProductPersentage.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByProductId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByProductId([FromQuery] int page, [FromQuery] int size,[FromQuery] long product_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonProductToProductPersentage> categoryList = await _context.TegirmonProductToProductPersentage
                .Include(p => p.product)
                .ThenInclude(p =>p.unitMeasurment)
                .Include(p =>p.item_list)
                .ThenInclude(p => p.sub_product)
                .Where(p => p.active_status == true && p.TegirmonProductid == product_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonProductToProductPersentage>();
            }
            foreach (TegirmonProductToProductPersentage it in categoryList) {

                foreach (TegirmonProductToProductPersentageDetail item in it.item_list) {
                    if (item.sub_product != null) {
                        item.ostatkaList = await _context.TegirmonOstatka.Where(p => p.TegirmonProductid == item.sub_product.id).Include(p => p.product).ToListAsync();
                        item.sub_product.unitMeasurment = await _context.TegirmonUnitMeasurment
                            .FindAsync(item.sub_product.TegirmonUnitMeasurmentid);
                    }
                }

            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonProductToProductPersentage.Where(p => p.active_status == true && p.TegirmonProductid == product_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TegirmonProductToProductPersentage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonProductToProductPersentage>> GetTegirmonProductToProductPersentage(long id)
        {
            var tegirmonProductToProductPersentage = await _context.TegirmonProductToProductPersentage
                .Include(p =>p.product)
                .Include(p =>p.item_list)
                .ThenInclude(p => p.sub_product)
                .Where(p => p.id == id).ToListAsync();

            if (tegirmonProductToProductPersentage == null || tegirmonProductToProductPersentage.Count == 0)
            {
                return NotFound();
            }

            return tegirmonProductToProductPersentage.First(); ;
        }

        // PUT: api/TegirmonProductToProductPersentage/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonProductToProductPersentage(long id, TegirmonProductToProductPersentage tegirmonProductToProductPersentage)
        {
            if (id != tegirmonProductToProductPersentage.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonProductToProductPersentage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonProductToProductPersentageExists(id))
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

        // POST: api/TegirmonProductToProductPersentage
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonProductToProductPersentage>> PostTegirmonProductToProductPersentage(TegirmonProductToProductPersentage tegirmonProductToProductPersentage)
        {
            _context.TegirmonProductToProductPersentage.Update(tegirmonProductToProductPersentage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonProductToProductPersentage", new { id = tegirmonProductToProductPersentage.id }, tegirmonProductToProductPersentage);
        }

        // DELETE: api/TegirmonProductToProductPersentage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonProductToProductPersentage>> DeleteTegirmonProductToProductPersentage(long id)
        {
            var tegirmonProductToProductPersentage = await _context.TegirmonProductToProductPersentage.FindAsync(id);
            if (tegirmonProductToProductPersentage == null)
            {
                return NotFound();
            }

            _context.TegirmonProductToProductPersentage.Remove(tegirmonProductToProductPersentage);
            await _context.SaveChangesAsync();

            return tegirmonProductToProductPersentage;
        }

        private bool TegirmonProductToProductPersentageExists(long id)
        {
            return _context.TegirmonProductToProductPersentage.Any(e => e.id == id);
        }
    }
}
