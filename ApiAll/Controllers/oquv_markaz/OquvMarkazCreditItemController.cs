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
    public class OquvMarkazCreditItemController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazCreditItemController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazCreditItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazCreditItem>>> GetOquvMarkazCreditItem()
        {
            return await _context.OquvMarkazCreditItem.ToListAsync();
        }

        // GET: api/OquvMarkazCreditItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazCreditItem>> GetOquvMarkazCreditItem(long id)
        {
            var oquvMarkazCreditItem = await _context.OquvMarkazCreditItem.FindAsync(id);

            if (oquvMarkazCreditItem == null)
            {
                return NotFound();
            }

            return oquvMarkazCreditItem;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazCreditItem> categoryList = await _context.OquvMarkazCreditItem.Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazCreditItem>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazCreditItem.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/OquvMarkazCreditItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazCreditItem(long id, OquvMarkazCreditItem oquvMarkazCreditItem)
        {
            if (id != oquvMarkazCreditItem.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazCreditItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazCreditItemExists(id))
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

        // POST: api/OquvMarkazCreditItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazCreditItem>> PostOquvMarkazCreditItem(OquvMarkazCreditItem oquvMarkazCreditItem)
        {
            _context.OquvMarkazCreditItem.Update(oquvMarkazCreditItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazCreditItem", new { id = oquvMarkazCreditItem.id }, oquvMarkazCreditItem);
        }

        // DELETE: api/OquvMarkazCreditItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazCreditItem>> DeleteOquvMarkazCreditItem(long id)
        {
            var oquvMarkazCreditItem = await _context.OquvMarkazCreditItem.FindAsync(id);
            if (oquvMarkazCreditItem == null)
            {
                return NotFound();
            }

            _context.OquvMarkazCreditItem.Remove(oquvMarkazCreditItem);
            await _context.SaveChangesAsync();

            return oquvMarkazCreditItem;
        }

        private bool OquvMarkazCreditItemExists(long id)
        {
            return _context.OquvMarkazCreditItem.Any(e => e.id == id);
        }
    }
}
