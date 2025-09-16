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
    public class TexBatchesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexBatchesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexBatches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexBatch>>> GetTexBatch()
        {
            return await _context.TexBatch.Include( p =>p.orderItem).ThenInclude(p =>p.order).ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexBatch> itemList = await _context.TexBatch.Where(p => p.active_status == true).Include(p => p.orderItem).ThenInclude(p => p.order).OrderByDescending(p => p.id).Skip(size * page).Take(size).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexBatch>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexBatch.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByOrderItemId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByOrderItemId([FromQuery] int page, [FromQuery] int size,[FromQuery] long order_item_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexBatch> itemList = await _context.TexBatch.Where(p => p.active_status == true && p.order_item_id == order_item_id).Include(p => p.orderItem).ThenInclude(p => p.order).OrderByDescending(p => p.id).Skip(size * page).Take(size).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexBatch>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexBatch.Where(p => p.active_status == true && p.order_item_id == order_item_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationByOrderId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByOrderId([FromQuery] int page, [FromQuery] int size, [FromQuery] long order_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexBatch> itemList = await _context.TexBatch.Include(p => p.orderItem).ThenInclude(p => p.order).Where(p => p.active_status == true && p.orderItem.order_id == order_id).OrderByDescending(p => p.id).Skip(size * page).Take(size).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexBatch>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexBatch.Include(p => p.orderItem).ThenInclude(p => p.order).Where(p => p.active_status == true && p.orderItem.order_id == order_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TexBatches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexBatch>> GetTexBatch(long id)
        {
            var texBatch = await _context.TexBatch.FindAsync(id);

            if (texBatch == null)
            {
                return NotFound();
            }

            return texBatch;
        }

        // PUT: api/TexBatches/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexBatch(long id, TexBatch texBatch)
        {
            if (id != texBatch.id)
            {
                return BadRequest();
            }

            _context.Entry(texBatch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexBatchExists(id))
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

        // POST: api/TexBatches
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexBatch>> PostTexBatch(TexBatch texBatch)
        {
            _context.TexBatch.Update(texBatch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexBatch", new { id = texBatch.id }, texBatch);
        }

        // DELETE: api/TexBatches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexBatch>> DeleteTexBatch(long id)
        {
            var texBatch = await _context.TexBatch.FindAsync(id);
            if (texBatch == null)
            {
                return NotFound();
            }

            _context.TexBatch.Remove(texBatch);
            await _context.SaveChangesAsync();

            return texBatch;
        }

        private bool TexBatchExists(long id)
        {
            return _context.TexBatch.Any(e => e.id == id);
        }
    }
}
