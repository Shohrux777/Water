using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil.order_item_steps;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tekistil.order_item
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexOrderItemSizeAndCountController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexOrderItemSizeAndCountController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("getPaginationByOrderItemIdBoyichaSizeVaCountOlish")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByOrderItemIdBoyichaSizeVaCountOlish([FromQuery] int page,
         [FromQuery] int size, [FromQuery] long order_item_id)
        {
            
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexOrderItemSizeAndCount> itemList = await _context.TexOrderItemSizeAndCount
                .Where(p => p.active_status == true && p.TexOrderItemid == order_item_id)
                .Include(p => p.size)
                .OrderByDescending(p => p.id).Skip(size * page).Take(size).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexOrderItemSizeAndCount>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexOrderItemSizeAndCount.Where(p => p.active_status == true
            && p.TexOrderItemid == order_item_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TexOrderItemSizeAndCount
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexOrderItemSizeAndCount>>> GetTexOrderItemSizeAndCount()
        {
            return await _context.TexOrderItemSizeAndCount.ToListAsync();
        }

        // GET: api/TexOrderItemSizeAndCount/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexOrderItemSizeAndCount>> GetTexOrderItemSizeAndCount(long id)
        {
            var texOrderItemSizeAndCount = await _context.TexOrderItemSizeAndCount.FindAsync(id);

            if (texOrderItemSizeAndCount == null)
            {
                return NotFound();
            }

            return texOrderItemSizeAndCount;
        }

        // PUT: api/TexOrderItemSizeAndCount/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexOrderItemSizeAndCount(long id, TexOrderItemSizeAndCount texOrderItemSizeAndCount)
        {
            if (id != texOrderItemSizeAndCount.id)
            {
                return BadRequest();
            }

            _context.Entry(texOrderItemSizeAndCount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexOrderItemSizeAndCountExists(id))
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

        // POST: api/TexOrderItemSizeAndCount
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexOrderItemSizeAndCount>> PostTexOrderItemSizeAndCount(TexOrderItemSizeAndCount texOrderItemSizeAndCount)
        {
            _context.TexOrderItemSizeAndCount.Update(texOrderItemSizeAndCount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexOrderItemSizeAndCount", new { id = texOrderItemSizeAndCount.id }, texOrderItemSizeAndCount);
        }

        // DELETE: api/TexOrderItemSizeAndCount/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexOrderItemSizeAndCount>> DeleteTexOrderItemSizeAndCount(long id)
        {
            var texOrderItemSizeAndCount = await _context.TexOrderItemSizeAndCount.FindAsync(id);
            if (texOrderItemSizeAndCount == null)
            {
                return NotFound();
            }

            _context.TexOrderItemSizeAndCount.Remove(texOrderItemSizeAndCount);
            await _context.SaveChangesAsync();

            return texOrderItemSizeAndCount;
        }

        private bool TexOrderItemSizeAndCountExists(long id)
        {
            return _context.TexOrderItemSizeAndCount.Any(e => e.id == id);
        }
    }
}
