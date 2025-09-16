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
    public class HospitalBioximyaKrovController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalBioximyaKrovController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalBioximyaKrov
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalBioximyaKrov>>> GetHospitalBioximyaKrov()
        {
            return await _context.HospitalBioximyaKrov.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalBioximyaKrov> itemList = await _context.HospitalBioximyaKrov
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalBioximyaKrov>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalBioximyaKrov.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalBioximyaKrov>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalBioximyaKrov
                .Include(p => p.patients)
                .Where(p => p.id == id).ToListAsync();

            if (item == null || item.Count() == 0)
            {
                return NotFound();
            }

            return item.First();
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size,[FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalBioximyaKrov> itemList = await _context.HospitalBioximyaKrov
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p =>p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalBioximyaKrov>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalBioximyaKrov
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalBioximyaKrov/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalBioximyaKrov>> GetHospitalBioximyaKrov(long id)
        {
            var hospitalBioximyaKrov = await _context.HospitalBioximyaKrov.FindAsync(id);

            if (hospitalBioximyaKrov == null)
            {
                return NotFound();
            }
            hospitalBioximyaKrov.patients = await _context.Patients.FindAsync(hospitalBioximyaKrov.PatientsId);

            return hospitalBioximyaKrov;
        }

        // PUT: api/HospitalBioximyaKrov/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalBioximyaKrov(long id, HospitalBioximyaKrov hospitalBioximyaKrov)
        {
            if (id != hospitalBioximyaKrov.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalBioximyaKrov).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalBioximyaKrovExists(id))
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

        // POST: api/HospitalBioximyaKrov
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalBioximyaKrov>> PostHospitalBioximyaKrov(HospitalBioximyaKrov hospitalBioximyaKrov)
        {
            _context.HospitalBioximyaKrov.Update(hospitalBioximyaKrov);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalBioximyaKrov", new { id = hospitalBioximyaKrov.id }, hospitalBioximyaKrov);
        }

        // DELETE: api/HospitalBioximyaKrov/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalBioximyaKrov>> DeleteHospitalBioximyaKrov(long id)
        {
            var hospitalBioximyaKrov = await _context.HospitalBioximyaKrov.FindAsync(id);
            if (hospitalBioximyaKrov == null)
            {
                return NotFound();
            }

            _context.HospitalBioximyaKrov.Remove(hospitalBioximyaKrov);
            await _context.SaveChangesAsync();

            return hospitalBioximyaKrov;
        }

        private bool HospitalBioximyaKrovExists(long id)
        {
            return _context.HospitalBioximyaKrov.Any(e => e.id == id);
        }
    }
}
