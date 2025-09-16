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
    public class TexSewOrderController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexSewOrderController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexSewOrder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexSewOrder>>> GetTexSewOrder()
        {
            return await _context.TexSewOrder.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexSewOrder> categoryList = await _context.TexSewOrder.Where(p => p.active_status == true)
                .Include(p => p.contragent)
                .Include(p => p.authorization)
                .Include(p => p.texPlanning)
                .Include(p => p.texInvoice)
                .Include(p => p.raskladki)
                 .Include(p => p.orderItemList)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TexSewOrder>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TexSewOrder.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationKechikyotganZakazlarListi")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationKechikyotganZakazlarListi([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexSewOrder> categoryList = await _context.TexSewOrder.Where(p => p.active_status == true
            && p.finish_status == false
            && p.rejalashtrilgan_tugash_vaqti_date_time <= DateTime.Now)
                .Include(p => p.contragent)
                .Include(p => p.authorization)
                .Include(p => p.texPlanning)
                .Include(p => p.texInvoice)
                .Include(p => p.raskladki)
                 .Include(p => p.orderItemList)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TexSewOrder>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TexSewOrder.Where(p => p.active_status == true
            && p.finish_status == false
            && p.rejalashtrilgan_tugash_vaqti_date_time <= DateTime.Now).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationFinishedSewOrder")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationFinishedSewOrder([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexSewOrder> categoryList = await _context.TexSewOrder.Where(p => p.active_status == true
            && p.finish_status == true)
                .Include(p => p.contragent)
                .Include(p => p.authorization)
                .Include(p => p.texPlanning)
                .Include(p => p.texInvoice)
                .Include(p => p.raskladki)
                 .Include(p => p.orderItemList)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TexSewOrder>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TexSewOrder.Where(p => p.active_status == true && p.finish_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationNotFinishedSewOrder")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationNotFinishedSewOrder([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexSewOrder> categoryList = await _context.TexSewOrder.Where(p => p.active_status == true
            && p.finish_status == false)
                .Include(p => p.contragent)
                .Include(p => p.authorization)
                .Include(p => p.texPlanning)
                .Include(p => p.texInvoice)
                .Include(p => p.raskladki)
                 .Include(p => p.orderItemList)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TexSewOrder>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TexSewOrder.Where(p => p.active_status == true && p.finish_status == false).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationByContragentId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByContragentId([FromQuery] int page,
            [FromQuery] int size,[FromQuery] long contragent_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexSewOrder> categoryList = await _context.TexSewOrder.Where(p => p.active_status == true
            && p.TexContragentid == contragent_id)
                .Include(p => p.contragent)
                .Include(p => p.authorization)
                .Include(p => p.texPlanning)
                .Include(p => p.texInvoice)
                .Include(p => p.raskladki)
                .Include(p =>p.orderItemList)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TexSewOrder>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TexSewOrder.Where(p => p.active_status == true && p.TexContragentid == contragent_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TexSewOrder/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexSewOrder>> GetTexSewOrder(long id)
        {
            var texSewOrder = await _context.TexSewOrder.FindAsync(id);

            if (texSewOrder == null)
            {
                return NotFound();
            }

            return texSewOrder;
        }

        [HttpGet("getsewOrderFullInfoById")]
        public async Task<ActionResult<TexSewOrder>> getsewOrderFullInfoById([FromQuery]long sew_order_id)
        {
            var texSewOrder = await _context.TexSewOrder
                .Where(p => p.id == sew_order_id)
                .Include(p => p.contragent)
                .Include(p => p.authorization)
                .Include(p => p.texPlanning)
                .Include(p => p.texInvoice)
                .Include(p => p.raskladki)
                .Include(p => p.orderItemList)
                .ThenInclude(p => p.product)
                .ToListAsync();

            if (texSewOrder == null || texSewOrder.Count == 0)
            {
                return NotFound();
            }

            return texSewOrder.First();
        }

        [HttpGet("finishSewOrderById")]
        public async Task<ActionResult<TexSewOrder>> finishSewOrderById([FromQuery]long id)
        {
            var texSewOrder = await _context.TexSewOrder.FindAsync(id);

            if (texSewOrder == null)
            {
                return NotFound();
            }
            texSewOrder.finish_status = true;
            _context.TexSewOrder.Update(texSewOrder);
            await _context.SaveChangesAsync();

            return texSewOrder;
        }

        // PUT: api/TexSewOrder/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexSewOrder(long id, TexSewOrder texSewOrder)
        {
            if (id != texSewOrder.id)
            {
                return BadRequest();
            }

            _context.Entry(texSewOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexSewOrderExists(id))
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

        // POST: api/TexSewOrder
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexSewOrder>> PostTexSewOrder(TexSewOrder texSewOrder)
        {
            _context.TexSewOrder.Update(texSewOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexSewOrder", new { id = texSewOrder.id }, texSewOrder);
        }

        // DELETE: api/TexSewOrder/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexSewOrder>> DeleteTexSewOrder(long id)
        {
            var texSewOrder = await _context.TexSewOrder.FindAsync(id);
            if (texSewOrder == null)
            {
                return NotFound();
            }

            if (texSewOrder.finish_status) {
                return NotFound("Yopilgan zakazdi ochirib bolmaydi");
            }

            _context.TexSewOrder.Remove(texSewOrder);
            await _context.SaveChangesAsync();

            return texSewOrder;
        }

        private bool TexSewOrderExists(long id)
        {
            return _context.TexSewOrder.Any(e => e.id == id);
        }
    }
}
