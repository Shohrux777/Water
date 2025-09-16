using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital.analiz.analiz_unversal;
using ApiAll.Model.hospital.analiz;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.hospital.analiz_unversal
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalAnaliz_37Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_37Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_37
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_37>>> GetHospitalAnaliz_37()
        {
            return await _context.HospitalAnaliz_37.ToListAsync();
        }
        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_37>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_37
                .Include(p => p.patients)
                .Where(p => p.id == id).ToListAsync();

            if (item == null || item.Count() == 0)
            {
                return NotFound();
            }

            return item.First();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_37> itemList = await _context.HospitalAnaliz_37
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_37>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_37.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_37> itemList = await _context.HospitalAnaliz_37
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_37>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_37
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_37/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_37>> GetHospitalAnaliz_37(long id)
        {
            var hospitalAnaliz_37 = await _context.HospitalAnaliz_37.FindAsync(id);

            if (hospitalAnaliz_37 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_37;
        }

        // PUT: api/HospitalAnaliz_37/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_37(long id, HospitalAnaliz_37 hospitalAnaliz_37)
        {
            if (id != hospitalAnaliz_37.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_37).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_37Exists(id))
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

        // POST: api/HospitalAnaliz_37
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_37>> PostHospitalAnaliz_37(HospitalAnaliz_37 hospitalAnaliz_37)
        {
            _context.HospitalAnaliz_37.Update(hospitalAnaliz_37);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_37", new { id = hospitalAnaliz_37.id }, hospitalAnaliz_37);
        }

        // DELETE: api/HospitalAnaliz_37/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_37>> DeleteHospitalAnaliz_37(long id)
        {
            var hospitalAnaliz_37 = await _context.HospitalAnaliz_37.FindAsync(id);
            if (hospitalAnaliz_37 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_37.Remove(hospitalAnaliz_37);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_37;
        }

        private bool HospitalAnaliz_37Exists(long id)
        {
            return _context.HospitalAnaliz_37.Any(e => e.id == id);
        }
    }
}
