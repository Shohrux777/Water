using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital.bron;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.hospital.bron
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalBedsTypeAndPricesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalBedsTypeAndPricesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalBedsTypeAndPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalBedsTypeAndPrice>>> GetHospitalBedsTypeAndPrice()
        {
            return await _context.HospitalBedsTypeAndPrice.ToListAsync();
        }

        [HttpGet("getPaginationNarxlar")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationNarxlar([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalBedsTypeAndPrice> itemList = await _context.HospitalBedsTypeAndPrice
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalBedsTypeAndPrice>();
            }

            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalBedsTypeAndPrice.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalBedsTypeAndPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalBedsTypeAndPrice>> GetHospitalBedsTypeAndPrice(long id)
        {
            var hospitalBedsTypeAndPrice = await _context.HospitalBedsTypeAndPrice.FindAsync(id);

            if (hospitalBedsTypeAndPrice == null)
            {
                return NotFound();
            }

            return hospitalBedsTypeAndPrice;
        }

        // PUT: api/HospitalBedsTypeAndPrices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalBedsTypeAndPrice(long id, HospitalBedsTypeAndPrice hospitalBedsTypeAndPrice)
        {
            if (id != hospitalBedsTypeAndPrice.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalBedsTypeAndPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalBedsTypeAndPriceExists(id))
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

        // POST: api/HospitalBedsTypeAndPrices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalBedsTypeAndPrice>> PostHospitalBedsTypeAndPrice(HospitalBedsTypeAndPrice hospitalBedsTypeAndPrice)
        {
            _context.HospitalBedsTypeAndPrice.Update(hospitalBedsTypeAndPrice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalBedsTypeAndPrice", new { id = hospitalBedsTypeAndPrice.id }, hospitalBedsTypeAndPrice);
        }

        // DELETE: api/HospitalBedsTypeAndPrices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalBedsTypeAndPrice>> DeleteHospitalBedsTypeAndPrice(long id)
        {
            var hospitalBedsTypeAndPrice = await _context.HospitalBedsTypeAndPrice.FindAsync(id);
            if (hospitalBedsTypeAndPrice == null)
            {
                return NotFound();
            }

            _context.HospitalBedsTypeAndPrice.Remove(hospitalBedsTypeAndPrice);
            await _context.SaveChangesAsync();

            return hospitalBedsTypeAndPrice;
        }

        private bool HospitalBedsTypeAndPriceExists(long id)
        {
            return _context.HospitalBedsTypeAndPrice.Any(e => e.id == id);
        }
    }
}
