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
    public class TexSizesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexSizesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexSizes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexSize>>> GetTexSize()
        {
            return await _context.TexSize.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexSize> categoryList = await _context.TexSize.Where(p => p.active_status == true)
               
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TexSize>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TexSize.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TexSizes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexSize>> GetTexSize(long id)
        {
            var texSize = await _context.TexSize.FindAsync(id);

            if (texSize == null)
            {
                return NotFound();
            }
            

            return texSize;
        }

        // PUT: api/TexSizes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexSize(long id, TexSize texSize)
        {
            if (id != texSize.id)
            {
                return BadRequest();
            }

            _context.Entry(texSize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexSizeExists(id))
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

        // POST: api/TexSizes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexSize>> PostTexSize(TexSize texSize)
        {
            try { 
            _context.TexSize.Update(texSize);
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

return CreatedAtAction("GetTexSize", new { id = texSize.id }, texSize);
        }

        // DELETE: api/TexSizes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexSize>> DeleteTexSize(long id)
        {
            var texSize = await _context.TexSize.FindAsync(id);
            if (texSize == null)
            {
                return NotFound();
            }
            try { 
            _context.TexSize.Remove(texSize);
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

return texSize;
        }

        private bool TexSizeExists(long id)
        {
            return _context.TexSize.Any(e => e.id == id);
        }
    }
}
