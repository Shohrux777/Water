using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital.analiz;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.hospital
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalVSKController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalVSKController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalVSK
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalVSK>>> GetHospitalVSK()
        {
            return await _context.HospitalVSK.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalVSK>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalVSK
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
            List<HospitalVSK> itemList = await _context.HospitalVSK
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalVSK>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalVSK.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalVSK> itemList = await _context.HospitalVSK
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalVSK>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalVSK
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalVSK/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalVSK>> GetHospitalVSK(long id)
        {
            var hospitalVSK = await _context.HospitalVSK.FindAsync(id);

            if (hospitalVSK == null)
            {
                return NotFound();
            }

            hospitalVSK.patients = await _context.Patients.FindAsync(hospitalVSK.PatientsId);


            return hospitalVSK;
        }

        // PUT: api/HospitalVSK/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalVSK(long id, HospitalVSK hospitalVSK)
        {
            if (id != hospitalVSK.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalVSK).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalVSKExists(id))
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

        // POST: api/HospitalVSK
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalVSK>> PostHospitalVSK(HospitalVSK hospitalVSK)
        {
            _context.HospitalVSK.Update(hospitalVSK);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalVSK", new { id = hospitalVSK.id }, hospitalVSK);
        }

        // DELETE: api/HospitalVSK/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalVSK>> DeleteHospitalVSK(long id)
        {
            var hospitalVSK = await _context.HospitalVSK.FindAsync(id);
            if (hospitalVSK == null)
            {
                return NotFound();
            }

            _context.HospitalVSK.Remove(hospitalVSK);
            await _context.SaveChangesAsync();

            return hospitalVSK;
        }

        private bool HospitalVSKExists(long id)
        {
            return _context.HospitalVSK.Any(e => e.id == id);
        }
    }
}
