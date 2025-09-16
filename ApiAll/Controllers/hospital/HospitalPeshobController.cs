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
    public class HospitalPeshobController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalPeshobController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalPeshob
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalPeshob>>> GetHospitalPeshob()
        {
            return await _context.HospitalPeshob.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalPeshob>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalPeshob
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
            List<HospitalPeshob> itemList = await _context.HospitalPeshob
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalPeshob>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalPeshob.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalPeshob> itemList = await _context.HospitalPeshob
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalPeshob>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalPeshob
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalPeshob/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalPeshob>> GetHospitalPeshob(long id)
        {
            var hospitalPeshob = await _context.HospitalPeshob.FindAsync(id);

            if (hospitalPeshob == null)
            {
                return NotFound();
            }

            hospitalPeshob.patients = await _context.Patients.FindAsync(hospitalPeshob.PatientsId);


            return hospitalPeshob;
        }

        // PUT: api/HospitalPeshob/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalPeshob(long id, HospitalPeshob hospitalPeshob)
        {
            if (id != hospitalPeshob.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalPeshob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalPeshobExists(id))
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

        // POST: api/HospitalPeshob
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalPeshob>> PostHospitalPeshob(HospitalPeshob hospitalPeshob)
        {
            _context.HospitalPeshob.Update(hospitalPeshob);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalPeshob", new { id = hospitalPeshob.id }, hospitalPeshob);
        }

        // DELETE: api/HospitalPeshob/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalPeshob>> DeleteHospitalPeshob(long id)
        {
            var hospitalPeshob = await _context.HospitalPeshob.FindAsync(id);
            if (hospitalPeshob == null)
            {
                return NotFound();
            }

            _context.HospitalPeshob.Remove(hospitalPeshob);
            await _context.SaveChangesAsync();

            return hospitalPeshob;
        }

        private bool HospitalPeshobExists(long id)
        {
            return _context.HospitalPeshob.Any(e => e.id == id);
        }
    }
}
