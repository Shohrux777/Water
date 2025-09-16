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
    public class OquvMarkazInvoiceItemController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazInvoiceItemController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazInvoiceItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazInvoiceItem>>> GetOquvMarkazInvoiceItem()
        {
            return await _context.OquvMarkazInvoiceItem.ToListAsync();
        }

        // GET: api/OquvMarkazInvoiceItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazInvoiceItem>> GetOquvMarkazInvoiceItem(long id)
        {
            var oquvMarkazInvoiceItem = await _context.OquvMarkazInvoiceItem.FindAsync(id);

            if (oquvMarkazInvoiceItem == null)
            {
                return NotFound();
            }

            return oquvMarkazInvoiceItem;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazInvoiceItem> categoryList = await _context.OquvMarkazInvoiceItem.Where(p => p.active_status == true)
                .Include(p =>p.product)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazInvoiceItem>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazInvoiceItem.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        // PUT: api/OquvMarkazInvoiceItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazInvoiceItem(long id, OquvMarkazInvoiceItem oquvMarkazInvoiceItem)
        {
            if (id != oquvMarkazInvoiceItem.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazInvoiceItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazInvoiceItemExists(id))
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

        // POST: api/OquvMarkazInvoiceItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazInvoiceItem>> PostOquvMarkazInvoiceItem(OquvMarkazInvoiceItem oquvMarkazInvoiceItem)
        {
            _context.OquvMarkazInvoiceItem.Update(oquvMarkazInvoiceItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazInvoiceItem", new { id = oquvMarkazInvoiceItem.id }, oquvMarkazInvoiceItem);
        }

        // DELETE: api/OquvMarkazInvoiceItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazInvoiceItem>> DeleteOquvMarkazInvoiceItem(long id)
        {
            var oquvMarkazInvoiceItem = await _context.OquvMarkazInvoiceItem.FindAsync(id);
            if (oquvMarkazInvoiceItem == null)
            {
                return NotFound();
            }

            _context.OquvMarkazInvoiceItem.Remove(oquvMarkazInvoiceItem);
            await _context.SaveChangesAsync();

            return oquvMarkazInvoiceItem;
        }

        private bool OquvMarkazInvoiceItemExists(long id)
        {
            return _context.OquvMarkazInvoiceItem.Any(e => e.id == id);
        }
    }
}
