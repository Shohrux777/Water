using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital;
using Newtonsoft.Json.Linq;
using ApiAll.Model.tekistil;

namespace ApiAll.Controllers.hospital
{

    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalPatientDolgItemController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalPatientDolgItemController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalPatientDolgItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalPatientDolgItem>>> GetHospitalPatientDolgItem()
        {
            return await _context.HospitalPatientDolgItem.ToListAsync();
        }

        // GET: api/HospitalPatientDolgItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalPatientDolgItem>> GetHospitalPatientDolgItem(long id)
        {
            var hospitalPatientDolgItem = await _context.HospitalPatientDolgItem.FindAsync(id);

            if (hospitalPatientDolgItem == null)
            {
                return NotFound();
            }

            return hospitalPatientDolgItem;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalPatientDolgItem> itemList = await _context.HospitalPatientDolgItem
                .Where(p => p.real_qty > 0)
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalPatientDolgItem>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalPatientDolgItem.Where(p => p.real_qty > 0).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/HospitalPatientDolgItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalPatientDolgItem(long id, HospitalPatientDolgItem hospitalPatientDolgItem)
        {
            if (id != hospitalPatientDolgItem.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalPatientDolgItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalPatientDolgItemExists(id))
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

        // POST: api/HospitalPatientDolgItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalPatientDolgItem>> PostHospitalPatientDolgItem(HospitalPatientDolgItem hospitalPatientDolgItem)
        {
            _context.HospitalPatientDolgItem.Update(hospitalPatientDolgItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalPatientDolgItem", new { id = hospitalPatientDolgItem.id }, hospitalPatientDolgItem);
        }

        // DELETE: api/HospitalPatientDolgItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalPatientDolgItem>> DeleteHospitalPatientDolgItem(long id)
        {
            var hospitalPatientDolgItem = await _context.HospitalPatientDolgItem.FindAsync(id);
            if (hospitalPatientDolgItem == null)
            {
                return NotFound();
            }

            _context.HospitalPatientDolgItem.Remove(hospitalPatientDolgItem);
            await _context.SaveChangesAsync();

            return hospitalPatientDolgItem;
        }

        private bool HospitalPatientDolgItemExists(long id)
        {
            return _context.HospitalPatientDolgItem.Any(e => e.id == id);
        }
    }
}
