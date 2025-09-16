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
    public class HospitalAnaliz_31Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_31Controller(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_31>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_31
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
            List<HospitalAnaliz_31> itemList = await _context.HospitalAnaliz_31
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_31>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_31.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_31> itemList = await _context.HospitalAnaliz_31
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_31>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_31
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // GET: api/HospitalAnaliz_31
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_31>>> GetHospitalAnaliz_31()
        {
            return await _context.HospitalAnaliz_31.ToListAsync();
        }

        // GET: api/HospitalAnaliz_31/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_31>> GetHospitalAnaliz_31(long id)
        {
            var hospitalAnaliz_31 = await _context.HospitalAnaliz_31.FindAsync(id);

            if (hospitalAnaliz_31 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_31;
        }

        // PUT: api/HospitalAnaliz_31/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_31(long id, HospitalAnaliz_31 hospitalAnaliz_31)
        {
            if (id != hospitalAnaliz_31.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_31).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_31Exists(id))
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

        // POST: api/HospitalAnaliz_31
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_31>> PostHospitalAnaliz_31(HospitalAnaliz_31 hospitalAnaliz_31)
        {
            _context.HospitalAnaliz_31.Update(hospitalAnaliz_31);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_31", new { id = hospitalAnaliz_31.id }, hospitalAnaliz_31);
        }

        // DELETE: api/HospitalAnaliz_31/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_31>> DeleteHospitalAnaliz_31(long id)
        {
            var hospitalAnaliz_31 = await _context.HospitalAnaliz_31.FindAsync(id);
            if (hospitalAnaliz_31 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_31.Remove(hospitalAnaliz_31);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_31;
        }

        private bool HospitalAnaliz_31Exists(long id)
        {
            return _context.HospitalAnaliz_31.Any(e => e.id == id);
        }
    }
}
