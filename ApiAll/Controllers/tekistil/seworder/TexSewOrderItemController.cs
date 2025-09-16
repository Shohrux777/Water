using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil.seworder;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tekistil.seworder
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexSewOrderItemController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexSewOrderItemController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexSewOrderItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexSewOrderItem>>> GetTexSewOrderItem()
        {
            return await _context.TexSewOrderItem.ToListAsync();
        }

        // GET: api/TexSewOrderItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexSewOrderItem>> GetTexSewOrderItem(long id)
        {
            var texSewOrderItem = await _context.TexSewOrderItem.FindAsync(id);

            if (texSewOrderItem == null)
            {
                return NotFound();
            }

            return texSewOrderItem;
        }

        [HttpGet("getSeworderitemFullInfo")]
        public async Task<ActionResult<TexSewOrderItem>> getSeworderitemFullInfo([FromQuery]long sew_order_item_id)
        {
            var texSewOrderItem = await _context.TexSewOrderItem
                .Where(p => p.id ==sew_order_item_id)
                .Include(p => p.product)
                .Include(p => p.size)
                .Include(p => p.color)
                .ToListAsync();

            if (texSewOrderItem == null || texSewOrderItem.Count == 0)
            {
                return NotFound();
            }

            return texSewOrderItem.FirstOrDefault();
        }

        // PUT: api/TexSewOrderItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexSewOrderItem(long id, TexSewOrderItem texSewOrderItem)
        {
            if (id != texSewOrderItem.id)
            {
                return BadRequest();
            }

            _context.Entry(texSewOrderItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexSewOrderItemExists(id))
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

        [HttpGet("getPaginationBySewOrderId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationBySewOrderId(
            [FromQuery] int page,
            [FromQuery] int size,
            [FromQuery] long order_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexSewOrderItem> categoryList = await _context.TexSewOrderItem.Where(p => p.active_status == true
            && p.TexSewOrderid == order_id)
                .Include(p => p.product)
                .Include(p => p.size)
                .Include(p => p.color)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TexSewOrderItem>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TexSewOrderItem.Where(p => p.active_status == true && p.TexSewOrderid == order_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // POST: api/TexSewOrderItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexSewOrderItem>> PostTexSewOrderItem(TexSewOrderItem texSewOrderItem)
        {
            _context.TexSewOrderItem.Update(texSewOrderItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexSewOrderItem", new { id = texSewOrderItem.id }, texSewOrderItem);
        }

        // DELETE: api/TexSewOrderItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexSewOrderItem>> DeleteTexSewOrderItem(long id)
        {
            var texSewOrderItem = await _context.TexSewOrderItem.FindAsync(id);
            if (texSewOrderItem == null)
            {
                return NotFound();
            }

            _context.TexSewOrderItem.Remove(texSewOrderItem);
            await _context.SaveChangesAsync();

            return texSewOrderItem;
        }

        private bool TexSewOrderItemExists(long id)
        {
            return _context.TexSewOrderItem.Any(e => e.id == id);
        }
    }
}
