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
    public class HospitalMazokController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalMazokController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalMazok
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalMazok>>> GetHospitalMazok()
        {
            return await _context.HospitalMazok.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalMazok> itemList = await _context.HospitalMazok
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalMazok>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalMazok.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalMazok>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalMazok
                .Include(p => p.patients)
                .Where(p => p.id == id).ToListAsync();

            if (item == null || item.Count() == 0)
            {
                return NotFound();
            }

            return item.First();
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalMazok> itemList = await _context.HospitalMazok
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalMazok>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalMazok
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalMazok/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalMazok>> GetHospitalMazok(long id)
        {
            var hospitalMazok = await _context.HospitalMazok.FindAsync(id);

            if (hospitalMazok == null)
            {
                return NotFound();
            }
            hospitalMazok.patients = await _context.Patients.FindAsync(hospitalMazok.PatientsId);


            return hospitalMazok;
        }

        // PUT: api/HospitalMazok/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalMazok(long id, HospitalMazok hospitalMazok)
        {
            if (id != hospitalMazok.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalMazok).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalMazokExists(id))
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

        // POST: api/HospitalMazok
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalMazok>> PostHospitalMazok(HospitalMazok hospitalMazok)
        {
            _context.HospitalMazok.Update(hospitalMazok);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalMazok", new { id = hospitalMazok.id }, hospitalMazok);
        }

        // DELETE: api/HospitalMazok/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalMazok>> DeleteHospitalMazok(long id)
        {
            var hospitalMazok = await _context.HospitalMazok.FindAsync(id);
            if (hospitalMazok == null)
            {
                return NotFound();
            }

            _context.HospitalMazok.Remove(hospitalMazok);
            await _context.SaveChangesAsync();

            return hospitalMazok;
        }

        private bool HospitalMazokExists(long id)
        {
            return _context.HospitalMazok.Any(e => e.id == id);
        }
    }
}
