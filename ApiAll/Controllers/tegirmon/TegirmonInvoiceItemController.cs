using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tegirmon;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tegirmon
{
    [ApiExplorerSettings(GroupName = "v7")]
    [Route("api/[controller]")]
    [ApiController]
    public class TegirmonInvoiceItemController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonInvoiceItemController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonInvoiceItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonInvoiceItem>>> GetTegirmonInvoiceItem()
        {
            return await _context.TegirmonInvoiceItem.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonInvoiceItem> categoryList = await _context.TegirmonInvoiceItem
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonInvoiceItem>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonInvoiceItem
                .Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TegirmonInvoiceItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonInvoiceItem>> GetTegirmonInvoiceItem(long id)
        {
            var tegirmonInvoiceItem = await _context.TegirmonInvoiceItem.FindAsync(id);

            if (tegirmonInvoiceItem == null)
            {
                return NotFound();
            }

            return tegirmonInvoiceItem;
        }

        // PUT: api/TegirmonInvoiceItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonInvoiceItem(long id, TegirmonInvoiceItem tegirmonInvoiceItem)
        {
            if (id != tegirmonInvoiceItem.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonInvoiceItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonInvoiceItemExists(id))
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

        // POST: api/TegirmonInvoiceItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonInvoiceItem>> PostTegirmonInvoiceItem(TegirmonInvoiceItem tegirmonInvoiceItem)
        {
            _context.TegirmonInvoiceItem.Update(tegirmonInvoiceItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonInvoiceItem", new { id = tegirmonInvoiceItem.id }, tegirmonInvoiceItem);
        }

        // DELETE: api/TegirmonInvoiceItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonInvoiceItem>> DeleteTegirmonInvoiceItem(long id)
        {
            var tegirmonInvoiceItem = await _context.TegirmonInvoiceItem.FindAsync(id);
            if (tegirmonInvoiceItem == null)
            {
                return NotFound();
            }

            _context.TegirmonInvoiceItem.Remove(tegirmonInvoiceItem);
            await _context.SaveChangesAsync();

            return tegirmonInvoiceItem;
        }

        private bool TegirmonInvoiceItemExists(long id)
        {
            return _context.TegirmonInvoiceItem.Any(e => e.id == id);
        }
    }
}
