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
    public class OquvMarkazDebitItemController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazDebitItemController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazDebitItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazDebitItem>>> GetOquvMarkazDebitItem()
        {
            return await _context.OquvMarkazDebitItem.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazDebitItem> categoryList = await _context.OquvMarkazDebitItem
                .Include(p =>p.check)
                .ThenInclude(p => p.client)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazDebitItem>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazDebitItem.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationDebitItemInfoList")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationDebitItemInfoList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazDebitItem> categoryList = await _context.OquvMarkazDebitItem
                .Include(p => p.check)
                .ThenInclude(p => p.client)
                .Where(p => p.active_status == true && p.summ < 0)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazDebitItem>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazDebitItem
                 .Where(p => p.active_status == true && p.summ < 0).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/OquvMarkazDebitItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazDebitItem>> GetOquvMarkazDebitItem(long id)
        {
            var oquvMarkazDebitItem = await _context.OquvMarkazDebitItem.FindAsync(id);

            if (oquvMarkazDebitItem == null)
            {
                return NotFound();
            }

            return oquvMarkazDebitItem;
        }

        // PUT: api/OquvMarkazDebitItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazDebitItem(long id, OquvMarkazDebitItem oquvMarkazDebitItem)
        {
            if (id != oquvMarkazDebitItem.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazDebitItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazDebitItemExists(id))
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

        // POST: api/OquvMarkazDebitItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazDebitItem>> PostOquvMarkazDebitItem(OquvMarkazDebitItem oquvMarkazDebitItem)
        {
            _context.OquvMarkazDebitItem.Update(oquvMarkazDebitItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazDebitItem", new { id = oquvMarkazDebitItem.id }, oquvMarkazDebitItem);
        }

        // DELETE: api/OquvMarkazDebitItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazDebitItem>> DeleteOquvMarkazDebitItem(long id)
        {
            var oquvMarkazDebitItem = await _context.OquvMarkazDebitItem.FindAsync(id);
            if (oquvMarkazDebitItem == null)
            {
                return NotFound();
            }

            _context.OquvMarkazDebitItem.Remove(oquvMarkazDebitItem);
            await _context.SaveChangesAsync();

            return oquvMarkazDebitItem;
        }

        private bool OquvMarkazDebitItemExists(long id)
        {
            return _context.OquvMarkazDebitItem.Any(e => e.id == id);
        }
    }
}
