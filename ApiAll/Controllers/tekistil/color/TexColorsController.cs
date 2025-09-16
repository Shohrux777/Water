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
    public class TexColorsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexColorsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexColors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexColor>>> GetTexColor()
        {
            return await _context.TexColor.Where(p =>p.active_status == true).OrderByDescending(p => p.id).Include(p =>p.contragent).Include( p =>p.colorgroup).ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexColor> itemList = await _context.TexColor.Where(p => p.active_status == true).OrderByDescending(p => p.id).Include(p => p.contragent).Include(p => p.colorgroup).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexColor>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexColor.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getByCompanyId")]
        public async Task<ActionResult<IEnumerable<TexColor>>> getByCompanyId([FromQuery] long company_id)
        {
            return await _context.TexColor.Where(p => p.active_status == true && p.contraget_id == company_id).OrderByDescending(p => p.id).Include(p => p.contragent).Include(p => p.colorgroup).ToListAsync();
        }

        [HttpGet("getByColorGroupId")]
        public async Task<ActionResult<IEnumerable<TexColor>>> getByColorGroupId([FromQuery] long company_id)
        {
            return await _context.TexColor.Where(p => p.active_status == true && p.contraget_id == company_id).OrderByDescending(p => p.id).Include(p => p.contragent).Include(p => p.colorgroup).ToListAsync();
        }

        // GET: api/TexColors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexColor>> GetTexColor(long id)
        {
            var texColor = await _context.TexColor.FindAsync(id);

            if (texColor == null)
            {
                return NotFound();
            }
            texColor.contragent = await _context.TexContragent.FindAsync(texColor.contraget_id);
            texColor.colorgroup = await _context.TexColorGroup.FindAsync(texColor.color_group_id);
            List<TexColorvariant> texColorvariantList = await _context.TexColorvariant.Where(p => p.color_id == texColor.id && p.active_status == true).OrderByDescending(p => p.id).Include(p => p.parent_colorvariant).Include(p => p.texColor).Include(p => p.texGuscolor).Include(p => p.product).Include(p => p.colorVariantType).Include(p => p.batchprocess).ToListAsync();
            texColor.texColorvariantsList = texColorvariantList;

            return texColor;
        }

        // PUT: api/TexColors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexColor(long id, TexColor texColor)
        {
            if (id != texColor.id)
            {
                return BadRequest();
            }

            _context.Entry(texColor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexColorExists(id))
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

        // POST: api/TexColors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexColor>> PostTexColor(TexColor texColor)
        {



            try
            {
            _context.TexColor.Update(texColor);
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

            return CreatedAtAction("GetTexColor", new { id = texColor.id }, texColor);
        }

        // DELETE: api/TexColors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexColor>> DeleteTexColor(long id)
        {
            var texColor = await _context.TexColor.FindAsync(id);
            if (texColor == null)
            {
                return NotFound();
            }
            texColor.active_status = false;
            _context.TexColor.Update(texColor);
            await _context.SaveChangesAsync();

            return texColor;
        }

        private bool TexColorExists(long id)
        {
            return _context.TexColor.Any(e => e.id == id);
        }
    }
}
