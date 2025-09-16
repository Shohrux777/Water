using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Model.hospital.analiz
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalRemaprobaController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalRemaprobaController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalRemaproba
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalRemaproba>>> GetHospitalRemaproba()
        {
            return await _context.HospitalRemaproba.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalRemaproba>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalRemaproba
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
            List<HospitalRemaproba> itemList = await _context.HospitalRemaproba
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalRemaproba>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalRemaproba.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalRemaproba> itemList = await _context.HospitalRemaproba
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalRemaproba>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalRemaproba
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalRemaproba/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalRemaproba>> GetHospitalRemaproba(long id)
        {
            var hospitalRemaproba = await _context.HospitalRemaproba.FindAsync(id);

            if (hospitalRemaproba == null)
            {
                return NotFound();
            }
            hospitalRemaproba.patients = await _context.Patients.FindAsync(hospitalRemaproba.PatientsId);


            return hospitalRemaproba;
        }

        // PUT: api/HospitalRemaproba/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalRemaproba(long id, HospitalRemaproba hospitalRemaproba)
        {
            if (id != hospitalRemaproba.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalRemaproba).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalRemaprobaExists(id))
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

        // POST: api/HospitalRemaproba
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalRemaproba>> PostHospitalRemaproba(HospitalRemaproba hospitalRemaproba)
        {
            _context.HospitalRemaproba.Update(hospitalRemaproba);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalRemaproba", new { id = hospitalRemaproba.id }, hospitalRemaproba);
        }

        // DELETE: api/HospitalRemaproba/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalRemaproba>> DeleteHospitalRemaproba(long id)
        {
            var hospitalRemaproba = await _context.HospitalRemaproba.FindAsync(id);
            if (hospitalRemaproba == null)
            {
                return NotFound();
            }

            _context.HospitalRemaproba.Remove(hospitalRemaproba);
            await _context.SaveChangesAsync();

            return hospitalRemaproba;
        }

        private bool HospitalRemaprobaExists(long id)
        {
            return _context.HospitalRemaproba.Any(e => e.id == id);
        }
    }
}
