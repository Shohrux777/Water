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
    public class HospitalOnkomarkerController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalOnkomarkerController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalOnkomarker
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalOnkomarker>>> GetHospitalOnkomarker()
        {
            return await _context.HospitalOnkomarker.ToListAsync();
        }


        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalOnkomarker>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalOnkomarker
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
            List<HospitalOnkomarker> itemList = await _context.HospitalOnkomarker
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalOnkomarker>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalOnkomarker.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalOnkomarker> itemList = await _context.HospitalOnkomarker
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalOnkomarker>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalOnkomarker
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalOnkomarker/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalOnkomarker>> GetHospitalOnkomarker(long id)
        {
            var hospitalOnkomarker = await _context.HospitalOnkomarker.FindAsync(id);

            if (hospitalOnkomarker == null)
            {
                return NotFound();
            }

            hospitalOnkomarker.patients = await _context.Patients.FindAsync(hospitalOnkomarker.PatientsId);


            return hospitalOnkomarker;
        }

        // PUT: api/HospitalOnkomarker/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalOnkomarker(long id, HospitalOnkomarker hospitalOnkomarker)
        {
            if (id != hospitalOnkomarker.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalOnkomarker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalOnkomarkerExists(id))
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

        // POST: api/HospitalOnkomarker
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalOnkomarker>> PostHospitalOnkomarker(HospitalOnkomarker hospitalOnkomarker)
        {
            _context.HospitalOnkomarker.Update(hospitalOnkomarker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalOnkomarker", new { id = hospitalOnkomarker.id }, hospitalOnkomarker);
        }

        // DELETE: api/HospitalOnkomarker/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalOnkomarker>> DeleteHospitalOnkomarker(long id)
        {
            var hospitalOnkomarker = await _context.HospitalOnkomarker.FindAsync(id);
            if (hospitalOnkomarker == null)
            {
                return NotFound();
            }

            _context.HospitalOnkomarker.Remove(hospitalOnkomarker);
            await _context.SaveChangesAsync();

            return hospitalOnkomarker;
        }

        private bool HospitalOnkomarkerExists(long id)
        {
            return _context.HospitalOnkomarker.Any(e => e.id == id);
        }
    }
}
