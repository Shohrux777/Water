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
    public class TexColorVariantTypesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexColorVariantTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexColorVariantTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexColorVariantType>>> GetTexColorVariantType()
        {
            return await _context.TexColorVariantType.OrderByDescending(p =>p.id).ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexColorVariantType> itemList = await _context.TexColorVariantType.OrderByDescending(p => p.id).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexColorVariantType>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexColorVariantType.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TexColorVariantTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexColorVariantType>> GetTexColorVariantType(long id)
        {
            var texColorVariantType = await _context.TexColorVariantType.FindAsync(id);

            if (texColorVariantType == null)
            {
                return NotFound();
            }

            return texColorVariantType;
        }

        // PUT: api/TexColorVariantTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexColorVariantType(long id, TexColorVariantType texColorVariantType)
        {
            if (id != texColorVariantType.id)
            {
                return BadRequest();
            }

            _context.Entry(texColorVariantType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexColorVariantTypeExists(id))
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

        // POST: api/TexColorVariantTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexColorVariantType>> PostTexColorVariantType(TexColorVariantType texColorVariantType)
        {



            try
            {
            _context.TexColorVariantType.Update(texColorVariantType);
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

            return CreatedAtAction("GetTexColorVariantType", new { id = texColorVariantType.id }, texColorVariantType);
        }

        // DELETE: api/TexColorVariantTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexColorVariantType>> DeleteTexColorVariantType(long id)
        {
            var texColorVariantType = await _context.TexColorVariantType.FindAsync(id);
            if (texColorVariantType == null)
            {
                return NotFound();
            }

            _context.TexColorVariantType.Remove(texColorVariantType);
            await _context.SaveChangesAsync();

            return texColorVariantType;
        }

        private bool TexColorVariantTypeExists(long id)
        {
            return _context.TexColorVariantType.Any(e => e.id == id);
        }
    }
}
