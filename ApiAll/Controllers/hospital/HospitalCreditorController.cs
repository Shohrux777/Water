using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.hospital
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalCreditorController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalCreditorController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalCreditor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalCreditor>>> GetHospitalCreditor()
        {
            return await _context.HospitalCreditor.ToListAsync();
        }

        // GET: api/HospitalCreditor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalCreditor>> GetHospitalCreditor(long id)
        {
            var hospitalCreditor = await _context.HospitalCreditor
                .Where(p => p.id == id)
                .Include(p => p.patients)
                .Include(p =>p.item_list)
                .ToListAsync();

            if (hospitalCreditor == null || hospitalCreditor.Count > 0)
            {
                return NotFound();
            }

            

            return hospitalCreditor.First();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalCreditor> itemList = await _context.HospitalCreditor
                .Where(p => p.real_sum > 0)
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalCreditor>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalCreditor.Where(p => p.real_sum > 0).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/HospitalCreditor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalCreditor(long id, HospitalCreditor hospitalCreditor)
        {
            if (id != hospitalCreditor.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalCreditor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalCreditorExists(id))
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

        // POST: api/HospitalCreditor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalCreditor>> PostHospitalCreditor(HospitalCreditor hospitalCreditor)
        {
            _context.HospitalCreditor.Update(hospitalCreditor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalCreditor", new { id = hospitalCreditor.id }, hospitalCreditor);
        }

        // DELETE: api/HospitalCreditor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalCreditor>> DeleteHospitalCreditor(long id)
        {
            var hospitalCreditor = await _context.HospitalCreditor.FindAsync(id);
            if (hospitalCreditor == null)
            {
                return NotFound();
            }

            _context.HospitalCreditor.Remove(hospitalCreditor);
            await _context.SaveChangesAsync();

            return hospitalCreditor;
        }

        private bool HospitalCreditorExists(long id)
        {
            return _context.HospitalCreditor.Any(e => e.id == id);
        }
    }
}
