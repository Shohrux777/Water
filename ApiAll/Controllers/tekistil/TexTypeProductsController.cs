using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;

namespace ApiAll.Controllers.tekistil
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexTypeProductsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexTypeProductsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexTypeProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexTypeProduct>>> GetTexTypeProduct()
        {
            return await _context.TexTypeProduct.ToListAsync();
        }

        // GET: api/TexTypeProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexTypeProduct>> GetTexTypeProduct(long id)
        {
            var texTypeProduct = await _context.TexTypeProduct.FindAsync(id);

            if (texTypeProduct == null)
            {
                return NotFound();
            }

            return texTypeProduct;
        }

        // PUT: api/TexTypeProducts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexTypeProduct(long id, TexTypeProduct texTypeProduct)
        {
            if (id != texTypeProduct.id)
            {
                return BadRequest();
            }

            _context.Entry(texTypeProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexTypeProductExists(id))
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

        // POST: api/TexTypeProducts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexTypeProduct>> PostTexTypeProduct(TexTypeProduct texTypeProduct)
        {
          

            try
            {
  _context.TexTypeProduct.Update(texTypeProduct);
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

            return CreatedAtAction("GetTexTypeProduct", new { id = texTypeProduct.id }, texTypeProduct);
        }

        // DELETE: api/TexTypeProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexTypeProduct>> DeleteTexTypeProduct(long id)
        {
            var texTypeProduct = await _context.TexTypeProduct.FindAsync(id);
            if (texTypeProduct == null)
            {
                return NotFound();
            }
            try { 

            _context.TexTypeProduct.Remove(texTypeProduct);
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

return texTypeProduct;
        }

        private bool TexTypeProductExists(long id)
        {
            return _context.TexTypeProduct.Any(e => e.id == id);
        }
    }
}
