using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public DistrictsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Districts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Districts>>> Getdistricts()
        {
            List<Districts> districtList = await _context.districts.OrderByDescending(p => p.Id).ToListAsync();
            foreach (Districts district in districtList) {
                Province province = await _context.provinces.FindAsync(district.ProvinceId);
                district.province = province;
            }
            return districtList;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<Districts> itemList = await _context.districts
                .Include(p => p.province)
                .OrderByDescending(p => p.Id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<Districts>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.districts.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/Districts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Districts>> GetDistricts(long id)
        {
            var districts = await _context.districts.FindAsync(id);

            if (districts == null)
            {
                return NotFound();
            }

            return districts;
        }

        // PUT: api/Districts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistricts(long id, Districts districts)
        {
            if (id != districts.Id)
            {
                return BadRequest();
            }

            _context.Entry(districts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistrictsExists(id))
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

        // POST: api/Districts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Districts>> PostDistricts(Districts districts)
        {
            _context.districts.Add(districts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDistricts", new { id = districts.Id }, districts);
        }

        [HttpGet("addDistricts")]
        public async Task<ActionResult<Districts>> addDistricts([FromQuery] long Id, [FromQuery] String Name, [FromQuery] long provinceId/*viloyatId*/)
        {
            Districts districts = new Districts();
            districts.ActiveStatus = true;
            districts.Name = Name;
            districts.ProvinceId = provinceId;
            _context.districts.Update(districts);
            await _context.SaveChangesAsync();

            return districts;
        }

        // DELETE: api/Districts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Districts>> DeleteDistricts(long id)
        {
            var districts = await _context.districts.FindAsync(id);
            if (districts == null)
            {
                return NotFound();
            }

            _context.districts.Remove(districts);
            await _context.SaveChangesAsync();

            return districts;
        }

        private bool DistrictsExists(long id)
        {
            return _context.districts.Any(e => e.Id == id);
        }
    }
}
