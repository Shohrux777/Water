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
    public class TexColorGroupsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexColorGroupsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexColorGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexColorGroup>>> GetTexColorGroup()
        {
            return await _context.TexColorGroup.Where(p => p.active_status == true).OrderByDescending(p =>p.id).ToListAsync();
        }


        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexColorGroup> itemList = await _context.TexColorGroup.OrderByDescending(p => p.id).Where(p => p.active_status == true).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexColorGroup>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexColorGroup.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TexColorGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexColorGroup>> GetTexColorGroup(long id)
        {
            var texColorGroup = await _context.TexColorGroup.FindAsync(id);

            if (texColorGroup == null)
            {
                return NotFound();
            }

            return texColorGroup;
        }

        // PUT: api/TexColorGroups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexColorGroup(long id, TexColorGroup texColorGroup)
        {
            if (id != texColorGroup.id)
            {
                return BadRequest();
            }

            _context.Entry(texColorGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexColorGroupExists(id))
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

        // POST: api/TexColorGroups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexColorGroup>> PostTexColorGroup(TexColorGroup texColorGroup)
        {
            try { 
            _context.TexColorGroup.Update(texColorGroup);
            await _context.SaveChangesAsync();
                 }
            catch (DbUpdateException e) {
                return NotFound(e?.InnerException?.Message );

                   }
            catch (Exception e) {
                 return NotFound(e?.InnerException?.Message );
                 }
return CreatedAtAction("GetTexColorGroup", new { id = texColorGroup.id }, texColorGroup);
        }

        // DELETE: api/TexColorGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexColorGroup>> DeleteTexColorGroup(long id)
        {
            var texColorGroup = await _context.TexColorGroup.FindAsync(id);
            if (texColorGroup == null)
            {
                return NotFound();
            }
            texColorGroup.active_status = false;

            _context.TexColorGroup.Update(texColorGroup);
            await _context.SaveChangesAsync();

            return texColorGroup;
        }

        private bool TexColorGroupExists(long id)
        {
            return _context.TexColorGroup.Any(e => e.id == id);
        }
    }
}
