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
    public class HospitalQondagiGarmonlarController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalQondagiGarmonlarController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalQondagiGarmonlar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalQondagiGarmonlar>>> GetHospitalQondagiGarmonlar()
        {
            return await _context.HospitalQondagiGarmonlar.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalQondagiGarmonlar>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalQondagiGarmonlar
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
            List<HospitalQondagiGarmonlar> itemList = await _context.HospitalQondagiGarmonlar
                .OrderByDescending(p => p.id)
                 .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalQondagiGarmonlar>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalQondagiGarmonlar.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalQondagiGarmonlar> itemList = await _context.HospitalQondagiGarmonlar
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalQondagiGarmonlar>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalQondagiGarmonlar
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalQondagiGarmonlar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalQondagiGarmonlar>> GetHospitalQondagiGarmonlar(long id)
        {
            var hospitalQondagiGarmonlar = await _context.HospitalQondagiGarmonlar.FindAsync(id);

            if (hospitalQondagiGarmonlar == null)
            {
                return NotFound();
            }

            hospitalQondagiGarmonlar.patients = await _context.Patients.FindAsync(hospitalQondagiGarmonlar.PatientsId);

            return hospitalQondagiGarmonlar;
        }

        // PUT: api/HospitalQondagiGarmonlar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalQondagiGarmonlar(long id, HospitalQondagiGarmonlar hospitalQondagiGarmonlar)
        {
            if (id != hospitalQondagiGarmonlar.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalQondagiGarmonlar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalQondagiGarmonlarExists(id))
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

        // POST: api/HospitalQondagiGarmonlar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalQondagiGarmonlar>> PostHospitalQondagiGarmonlar(HospitalQondagiGarmonlar hospitalQondagiGarmonlar)
        {
            _context.HospitalQondagiGarmonlar.Update(hospitalQondagiGarmonlar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalQondagiGarmonlar", new { id = hospitalQondagiGarmonlar.id }, hospitalQondagiGarmonlar);
        }

        // DELETE: api/HospitalQondagiGarmonlar/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalQondagiGarmonlar>> DeleteHospitalQondagiGarmonlar(long id)
        {
            var hospitalQondagiGarmonlar = await _context.HospitalQondagiGarmonlar.FindAsync(id);
            if (hospitalQondagiGarmonlar == null)
            {
                return NotFound();
            }

            _context.HospitalQondagiGarmonlar.Remove(hospitalQondagiGarmonlar);
            await _context.SaveChangesAsync();

            return hospitalQondagiGarmonlar;
        }

        private bool HospitalQondagiGarmonlarExists(long id)
        {
            return _context.HospitalQondagiGarmonlar.Any(e => e.id == id);
        }
    }
}
