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
    public class TegirmonProductController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonProductController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonProduct>>> GetTegirmonProduct()
        {
            return await _context.TegirmonProduct.ToListAsync();
        }
        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonProduct> categoryList = await _context.TegirmonProduct
                .Where(p => p.active_status == true )
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonProduct>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonProduct
                .Where(p => p.active_status == true ).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TegirmonProduct/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonProduct>> GetTegirmonProduct(long id)
        {
            var tegirmonProduct = await _context.TegirmonProduct.FindAsync(id);

            if (tegirmonProduct == null)
            {
                return NotFound();
            }

            return tegirmonProduct;
        }

        // PUT: api/TegirmonProduct/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonProduct(long id, TegirmonProduct tegirmonProduct)
        {
            if (id != tegirmonProduct.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonProductExists(id))
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

        // POST: api/TegirmonProduct
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonProduct>> PostTegirmonProduct(TegirmonProduct tegirmonProduct)
        {
            _context.TegirmonProduct.Update(tegirmonProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonProduct", new { id = tegirmonProduct.id }, tegirmonProduct);
        }

        // DELETE: api/TegirmonProduct/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonProduct>> DeleteTegirmonProduct(long id)
        {
            var tegirmonProduct = await _context.TegirmonProduct.FindAsync(id);
            if (tegirmonProduct == null)
            {
                return NotFound();
            }

            _context.TegirmonProduct.Remove(tegirmonProduct);
            await _context.SaveChangesAsync();

            return tegirmonProduct;
        }

        private bool TegirmonProductExists(long id)
        {
            return _context.TegirmonProduct.Any(e => e.id == id);
        }
    }
}
