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
    public class TexColorvariantsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexColorvariantsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexColorvariants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexColorvariant>>> GetTexColorvariant()
        {
            return await _context.TexColorvariant.Where(p => p.active_status == true).OrderByDescending(p => p.id).Include( p => p.parent_colorvariant).Include( p =>p.texColor).Include( p=>p.texGuscolor).Include( p=>p.product).Include(p => p.colorVariantType).Include( p=>p.batchprocess).ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexColorvariant> itemList = await _context.TexColorvariant.Where(p => p.active_status == true).OrderByDescending(p => p.id).Include(p => p.colorVariantType).Include(p => p.product).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexColorvariant>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexColorvariant.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TexColorvariants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexColorvariant>> GetTexColorvariant(long id)
        {
            var texColorvariant = await _context.TexColorvariant.FindAsync(id);

            if (texColorvariant == null)
            {
                return NotFound();
            }

            return texColorvariant;
        }

        // PUT: api/TexColorvariants/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexColorvariant(long id, TexColorvariant texColorvariant)
        {
            if (id != texColorvariant.id)
            {
                return BadRequest();
            }

            _context.Entry(texColorvariant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexColorvariantExists(id))
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

        // POST: api/TexColorvariants
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexColorvariant>> PostTexColorvariant(TexColorvariant texColorvariant)
        {


            try
            {
            _context.TexColorvariant.Update(texColorvariant);
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

            return CreatedAtAction("GetTexColorvariant", new { id = texColorvariant.id }, texColorvariant);
        }

        // DELETE: api/TexColorvariants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexColorvariant>> DeleteTexColorvariant(long id)
        {
            var texColorvariant = await _context.TexColorvariant.FindAsync(id);
            if (texColorvariant == null)
            {
                return NotFound();
            }

            _context.TexColorvariant.Remove(texColorvariant);
            await _context.SaveChangesAsync();

            return texColorvariant;
        }

        private bool TexColorvariantExists(long id)
        {
            return _context.TexColorvariant.Any(e => e.id == id);
        }
    }
}
