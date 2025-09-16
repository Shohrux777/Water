using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.oquv_markaz;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.oquv_markaz
{
    [ApiExplorerSettings(GroupName = "v8")]
    [Route("api/[controller]")]
    [ApiController]
    public class OquvMarkazProductController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazProductController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazProduct>>> GetOquvMarkazProduct()
        {
            return await _context.OquvMarkazProduct.ToListAsync();
        }

        // GET: api/OquvMarkazProduct/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazProduct>> GetOquvMarkazProduct(long id)
        {
            var oquvMarkazProduct = await _context.OquvMarkazProduct.FindAsync(id);

            if (oquvMarkazProduct == null)
            {
                return NotFound();
            }

            return oquvMarkazProduct;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazProduct> categoryList = await _context.OquvMarkazProduct.Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazProduct>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazProduct.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/OquvMarkazProduct/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazProduct(long id, OquvMarkazProduct oquvMarkazProduct)
        {
            if (id != oquvMarkazProduct.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazProductExists(id))
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

        // POST: api/OquvMarkazProduct
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazProduct>> PostOquvMarkazProduct(OquvMarkazProduct oquvMarkazProduct)
        {
            _context.OquvMarkazProduct.Update(oquvMarkazProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazProduct", new { id = oquvMarkazProduct.id }, oquvMarkazProduct);
        }

        // DELETE: api/OquvMarkazProduct/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazProduct>> DeleteOquvMarkazProduct(long id)
        {
            var oquvMarkazProduct = await _context.OquvMarkazProduct.FindAsync(id);
            if (oquvMarkazProduct == null)
            {
                return NotFound();
            }

            _context.OquvMarkazProduct.Remove(oquvMarkazProduct);
            await _context.SaveChangesAsync();

            return oquvMarkazProduct;
        }

        private bool OquvMarkazProductExists(long id)
        {
            return _context.OquvMarkazProduct.Any(e => e.id == id);
        }
    }
}
