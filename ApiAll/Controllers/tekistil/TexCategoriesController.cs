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
using System.Data.Entity.Validation;

namespace ApiAll.Controllers.tekistil
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexCategoriesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexCategoriesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexCategory>>> GetTexCategory()
        {
            return await _context.TexCategory.Where(p => p.active_status == true).OrderByDescending(p => p.id).Include( p => p.typeProduct).Include(p => p.measurmentType).ToListAsync();
        }


        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexCategory>  categoryList = await _context.TexCategory.Where(p => p.active_status == true)
                .Include(p => p.measurmentType)
                .Include(p => p.typeProduct)
                .Include(p => p.created_auth)
                .Include(p => p.updated_user)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null) {
                categoryList = new List<TexCategory>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TexCategory.Where(p =>p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        // GET: api/TexCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexCategory>> GetTexCategory(long id)
        {
            var texCategory = await _context.TexCategory
                .Include(p => p.measurmentType)
                .Include(p => p.typeProduct)
                .Include(p => p.created_auth)
                .Include(p => p.updated_user)
                .Where(p =>p.id == id).ToListAsync();

            if (texCategory == null || texCategory.Count == 0)
            {
                return NotFound();
            }
            List<TexXarakteristika> xarakteristikaList = await _context.TexXarakteristika
               .Where(p => texCategory.First()
               .xarakteristika_id.Contains(p.id)).ToListAsync();

            texCategory.First().texXarakteristikaList = xarakteristikaList;

            return texCategory.First();
        }

        [HttpGet("getCategoryDetailWithXarakteristikaList")]
        public async Task<ActionResult<TexCategory>> getCategoryDetailWithXarakteristikaList([FromQuery]long categoryId)
        {
            var texCategory = await _context.TexCategory.FindAsync(categoryId);

            if (texCategory == null)
            {
                return NotFound();
            }
            texCategory.typeProduct = await _context.TexTypeProduct.FindAsync(texCategory.producttype_id);
            texCategory.measurmentType = await _context.TexMeasurmentType.FindAsync(texCategory.measurment_type_id);

            List<long> xarakteristikaList = texCategory.xarakteristika_id;
            List<TexXarakteristika> texXarakteristikaList = new List<TexXarakteristika>();

            if (xarakteristikaList != null && xarakteristikaList.Count > 0) {
                foreach (long item_id in xarakteristikaList) {
                    TexXarakteristika xarakteristika = await _context.TexXarakteristika.FindAsync(item_id);
                    if (xarakteristika != null && xarakteristika.id > 0) {
                        List<TexXarakteristikaTool> xarakteristikaToolList = await _context.TexXarakteristikaTool.Where(p =>p.xarakteristika_id == xarakteristika.id).ToListAsync();
                        xarakteristika.xarakteristikaToolList = xarakteristikaToolList;
                        texXarakteristikaList.Add(xarakteristika);

                    }
                }

            }
            texCategory.texXarakteristikaList = texXarakteristikaList;
            return texCategory;
        }

        // PUT: api/TexCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexCategory(long id, TexCategory texCategory)
        {
            if (id != texCategory.id)
            {
                return BadRequest();
            }

            _context.Entry(texCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexCategoryExists(id))
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

        // POST: api/TexCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexCategory>> PostTexCategory(TexCategory texCategory)
        {
            try
            {
                _context.TexCategory.Update(texCategory);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException e) {
                return NotFound( e?.InnerException?.Message );
                
            }
            catch (Exception e) {
                 return NotFound( e?.InnerException?.Message );
            }


            return CreatedAtAction("GetTexCategory", new { id = texCategory.id }, texCategory);
        }

        // DELETE: api/TexCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexCategory>> DeleteTexCategory(long id)
        {
            var texCategory = await _context.TexCategory.FindAsync(id);
            if (texCategory == null)
            {
                return NotFound();
            }
            texCategory.active_status = false;

            _context.TexCategory.Update(texCategory);
            await _context.SaveChangesAsync();

            return texCategory;
        }

        private bool TexCategoryExists(long id)
        {
            return _context.TexCategory.Any(e => e.id == id);
        }
    }
}
