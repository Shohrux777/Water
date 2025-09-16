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
    public class TexCalcTypesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexCalcTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexCalcTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexCalcType>>> GetTexCalcType()
        {
            return await _context.TexCalcType.OrderByDescending( p => p.id).Where(p =>p.active_status == true).ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexCalcType> itemList = await _context.TexCalcType.OrderByDescending(p => p.id).Where(p => p.active_status == true).Skip(page * size).Take(size).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexCalcType>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexCalcType.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TexCalcTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexCalcType>> GetTexCalcType(long id)
        {
            var texCalcType = await _context.TexCalcType.FindAsync(id);

            if (texCalcType == null)
            {
                return NotFound();
            }

            return texCalcType;
        }

        // PUT: api/TexCalcTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexCalcType(long id, TexCalcType texCalcType)
        {
            if (id != texCalcType.id)
            {
                return BadRequest();
            }

            _context.Entry(texCalcType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexCalcTypeExists(id))
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

        // POST: api/TexCalcTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexCalcType>> PostTexCalcType(TexCalcType texCalcType)
        {
            try { 
            _context.TexCalcType.Update(texCalcType);
            await _context.SaveChangesAsync();
        }
            catch (DbUpdateException e) {
                return NotFound(e?.InnerException?.Message );

    }
            catch (Exception e) {
                 return NotFound(e?.InnerException?.Message );
}

return CreatedAtAction("GetTexCalcType", new { id = texCalcType.id }, texCalcType);
        }

        // DELETE: api/TexCalcTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexCalcType>> DeleteTexCalcType(long id)
        {
            var texCalcType = await _context.TexCalcType.FindAsync(id);
            if (texCalcType == null)
            {
                return NotFound();
            }
            texCalcType.active_status = false;
            _context.TexCalcType.Update(texCalcType);
            await _context.SaveChangesAsync();

            return texCalcType;
        }

        private bool TexCalcTypeExists(long id)
        {
            return _context.TexCalcType.Any(e => e.id == id);
        }
    }
}
