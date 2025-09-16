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
    public class HospitalKoagulogrammaController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalKoagulogrammaController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalKoagulogramma
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalKoagulogramma>>> GetHospitalKoagulogramma()
        {
            return await _context.HospitalKoagulogramma.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalKoagulogramma> itemList = await _context.HospitalKoagulogramma
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalKoagulogramma>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalKoagulogramma.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalKoagulogramma>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalKoagulogramma
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
            List<HospitalKoagulogramma> itemList = await _context.HospitalKoagulogramma
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalKoagulogramma>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalKoagulogramma
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalKoagulogramma/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalKoagulogramma>> GetHospitalKoagulogramma(long id)
        {
            var hospitalKoagulogramma = await _context.HospitalKoagulogramma.FindAsync(id);

            if (hospitalKoagulogramma == null)
            {
                return NotFound();
            }

            hospitalKoagulogramma.patients = await _context.Patients.FindAsync(hospitalKoagulogramma.PatientsId);



            return hospitalKoagulogramma;
        }

        // PUT: api/HospitalKoagulogramma/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalKoagulogramma(long id, HospitalKoagulogramma hospitalKoagulogramma)
        {
            if (id != hospitalKoagulogramma.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalKoagulogramma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalKoagulogrammaExists(id))
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

        // POST: api/HospitalKoagulogramma
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalKoagulogramma>> PostHospitalKoagulogramma(HospitalKoagulogramma hospitalKoagulogramma)
        {
            _context.HospitalKoagulogramma.Update(hospitalKoagulogramma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalKoagulogramma", new { id = hospitalKoagulogramma.id }, hospitalKoagulogramma);
        }

        // DELETE: api/HospitalKoagulogramma/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalKoagulogramma>> DeleteHospitalKoagulogramma(long id)
        {
            var hospitalKoagulogramma = await _context.HospitalKoagulogramma.FindAsync(id);
            if (hospitalKoagulogramma == null)
            {
                return NotFound();
            }

            _context.HospitalKoagulogramma.Remove(hospitalKoagulogramma);
            await _context.SaveChangesAsync();

            return hospitalKoagulogramma;
        }

        private bool HospitalKoagulogrammaExists(long id)
        {
            return _context.HospitalKoagulogramma.Any(e => e.id == id);
        }
    }
}
