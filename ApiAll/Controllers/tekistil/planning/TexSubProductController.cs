using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil.planning;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tekistil.planning
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexSubProductController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexSubProductController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexSubProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexSubProduct>>> GetTexSubProduct()
        {
            return await _context.TexSubProduct.ToListAsync();
        }


        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexSubProduct> categoryList = await _context.TexSubProduct.Where(p => p.active_status == true)
              
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TexSubProduct>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TexSubProduct.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // GET: api/TexSubProduct/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexSubProduct>> GetTexSubProduct(long id)
        {
            var texSubProduct = await _context.TexSubProduct.FindAsync(id);

            if (texSubProduct == null)
            {
                return NotFound();
            }

            return texSubProduct;
        }

        // PUT: api/TexSubProduct/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexSubProduct(long id, TexSubProduct texSubProduct)
        {
            if (id != texSubProduct.id)
            {
                return BadRequest();
            }

            _context.Entry(texSubProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexSubProductExists(id))
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

        // POST: api/TexSubProduct
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexSubProduct>> PostTexSubProduct(TexSubProduct texSubProduct)
        {
            _context.TexSubProduct.Update(texSubProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexSubProduct", new { id = texSubProduct.id }, texSubProduct);
        }

        // DELETE: api/TexSubProduct/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexSubProduct>> DeleteTexSubProduct(long id)
        {
            var texSubProduct = await _context.TexSubProduct.FindAsync(id);
            if (texSubProduct == null)
            {
                return NotFound();
            }

            _context.TexSubProduct.Remove(texSubProduct);
            await _context.SaveChangesAsync();

            return texSubProduct;
        }

        private bool TexSubProductExists(long id)
        {
            return _context.TexSubProduct.Any(e => e.id == id);
        }
    }
}
