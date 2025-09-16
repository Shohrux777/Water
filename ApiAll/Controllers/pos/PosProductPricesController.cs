using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.pos;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.pos
{
    [ApiExplorerSettings(GroupName = "v5")]
    [Route("api/[controller]")]
    [ApiController]
    public class PosProductPricesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosProductPricesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosProductPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosProductPrice>>> GetPosProductPrice()
        {
            return await _context.PosProductPrice.ToListAsync();
        }

        [HttpGet("getRealFinanceCondition")]
        public async Task<ActionResult<PosRealSummOfAllProducts>> getRealFinanceCondition()
        {
            PosRealSummOfAllProducts posRealSummOfAllProducts = new PosRealSummOfAllProducts();
            List<PosRealSummOfAllProducts> realSummOfAllProductList =  await _context.PosRealSummOfAllProducts.FromSqlRaw("SELECT SUM(pp.price * pp.real_qty) buyed_summa, SUM(pp.buyed_price * pp.real_qty) saled_summa FROM public.pos_product_price pp ").ToListAsync();
            if (realSummOfAllProductList != null && realSummOfAllProductList.Count > 0) {
                posRealSummOfAllProducts = realSummOfAllProductList.First();
            }

            return posRealSummOfAllProducts;
            
        }
        [HttpGet("getRealNotLeftProductList")]
        public async Task<ActionResult<TexPaginationModel>> getRealNotLeftProductList([FromQuery] int page, [FromQuery] int size)
        {

            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosProductPrice> itemList = new List<PosProductPrice>();
                itemList = await _context.PosProductPrice
                .Where(p => p.active_status == true && p.real_qty <= 0)
                .Include(p => p.product).ThenInclude(p => p.measurment)
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            


            if (itemList == null)
            {
                itemList = new List<PosProductPrice>();
            }

            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosProductPrice
                .Where(p => p.active_status == true && p.real_qty <= 0).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getReportForMinQtyProductList")]
        public async Task<ActionResult<TexPaginationModel>> getReportForMinQtyProductList([FromQuery] int page, [FromQuery] int size)
        {

            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosProductPrice> itemList = new List<PosProductPrice>();
            itemList = await _context.PosProductPrice.Include(p => p.product).ThenInclude(p => p.measurment)
            .Where(p => p.active_status == true && p.real_qty <= p.product.min_qty )
            .OrderByDescending(p => p.id)
            .Skip(size * page).Take(size)
            .ToListAsync();



            if (itemList == null)
            {
                itemList = new List<PosProductPrice>();
            }

            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosProductPrice.Include(p => p.product).ThenInclude(p => p.measurment)
            .Where(p => p.active_status == true && p.real_qty <= p.product.min_qty ).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getRealCountProductList")]
        public async Task<ActionResult<TexPaginationModel>> getRealCountProductList([FromQuery] int page, [FromQuery] int size, [FromQuery] long product_id)
        {

            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosProductPrice> itemList = new List<PosProductPrice>();

            if (product_id > 0)
            {
                itemList = await _context.PosProductPrice
                 .Where(p => p.active_status == true && p.product_id == product_id && p.real_qty > 0)
                 .Include(p => p.product).ThenInclude(p => p.measurment)
                 .OrderByDescending(p => p.id)
                 .Skip(size * page).Take(size)
                 .ToListAsync();
            }
            else
            {
                itemList = await _context.PosProductPrice
                .Where(p => p.active_status == true && p.real_qty > 0)
                .Include(p => p.product).ThenInclude(p => p.measurment)
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            }


            if (itemList == null)
            {
                itemList = new List<PosProductPrice>();
            }

            paginationModel.items_list = JArray.FromObject(itemList);
            if (product_id > 0)
            {
                paginationModel.items_count = await _context.PosProductPrice
                .Where(p => p.active_status == true && p.product_id == product_id && p.real_qty > 0).CountAsync();
            }
            else
            {
                paginationModel.items_count = await _context.PosProductPrice
                .Where(p => p.active_status == true && p.real_qty > 0).CountAsync();
            }


            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getSrokForProductList")]
        public async Task<ActionResult<TexPaginationModel>> getSrokForProductList([FromQuery] int page, [FromQuery] int size,[FromQuery] DateTime srok_date_time)
        {

            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosProductPrice> itemList = new List<PosProductPrice>();
                itemList = await _context.PosProductPrice
                 .Where(p => p.active_status == true && p.updated_date_time <= srok_date_time)
                 .Include(p => p.product).ThenInclude(p => p.measurment)
                 .OrderByDescending(p => p.id)
                 .Skip(size * page).Take(size)
                 .ToListAsync();
            
            if (itemList == null)
            {
                itemList = new List<PosProductPrice>();
            }

            paginationModel.items_list = JArray.FromObject(itemList);
                paginationModel.items_count = await _context.PosProductPrice
                .Where(p => p.active_status == true && p.updated_date_time <=srok_date_time ).CountAsync();



            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/PosProductPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosProductPrice>> GetPosProductPrice(long id)
        {
            var posProductPrice = await _context.PosProductPrice.FindAsync(id);

            if (posProductPrice == null)
            {
                return NotFound();
            }

            return posProductPrice;
        }

        // PUT: api/PosProductPrices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosProductPrice(long id, PosProductPrice posProductPrice)
        {
            if (id != posProductPrice.id)
            {
                return BadRequest();
            }

            _context.Entry(posProductPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosProductPriceExists(id))
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

        // POST: api/PosProductPrices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosProductPrice>> PostPosProductPrice(PosProductPrice posProductPrice)
        {
            _context.PosProductPrice.Update(posProductPrice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosProductPrice", new { id = posProductPrice.id }, posProductPrice);
        }

        // DELETE: api/PosProductPrices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosProductPrice>> DeletePosProductPrice(long id)
        {
            var posProductPrice = await _context.PosProductPrice.FindAsync(id);
            if (posProductPrice == null)
            {
                return NotFound();
            }

            _context.PosProductPrice.Remove(posProductPrice);
            await _context.SaveChangesAsync();

            return posProductPrice;
        }

        private bool PosProductPriceExists(long id)
        {
            return _context.PosProductPrice.Any(e => e.id == id);
        }
    }
}
