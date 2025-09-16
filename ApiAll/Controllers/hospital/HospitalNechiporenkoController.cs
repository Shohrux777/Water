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
    public class HospitalNechiporenkoController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalNechiporenkoController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalNechiporenko
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalNechiporenko>>> GetHospitalNechiporenko()
        {
            return await _context.HospitalNechiporenko.ToListAsync();
        }


        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalNechiporenko> itemList = await _context.HospitalNechiporenko
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalNechiporenko>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalNechiporenko.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalNechiporenko> itemList = await _context.HospitalNechiporenko
                .OrderByDescending(p => p.id)
                .Include(p => p.patients).Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalNechiporenko>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalNechiporenko
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalNechiporenko/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalNechiporenko>> GetHospitalNechiporenko(long id)
        {
            var hospitalNechiporenko = await _context.HospitalNechiporenko.FindAsync(id);

            if (hospitalNechiporenko == null)
            {
                return NotFound();
            }

            hospitalNechiporenko.patients = await _context.Patients.FindAsync(hospitalNechiporenko.PatientsId);


            return hospitalNechiporenko;
        }

        // PUT: api/HospitalNechiporenko/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalNechiporenko(long id, HospitalNechiporenko hospitalNechiporenko)
        {
            if (id != hospitalNechiporenko.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalNechiporenko).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalNechiporenkoExists(id))
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

        // POST: api/HospitalNechiporenko
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalNechiporenko>> PostHospitalNechiporenko(HospitalNechiporenko hospitalNechiporenko)
        {
            _context.HospitalNechiporenko.Update(hospitalNechiporenko);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalNechiporenko", new { id = hospitalNechiporenko.id }, hospitalNechiporenko);
        }

        // DELETE: api/HospitalNechiporenko/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalNechiporenko>> DeleteHospitalNechiporenko(long id)
        {
            var hospitalNechiporenko = await _context.HospitalNechiporenko.FindAsync(id);
            if (hospitalNechiporenko == null)
            {
                return NotFound();
            }

            _context.HospitalNechiporenko.Remove(hospitalNechiporenko);
            await _context.SaveChangesAsync();

            return hospitalNechiporenko;
        }

        private bool HospitalNechiporenkoExists(long id)
        {
            return _context.HospitalNechiporenko.Any(e => e.id == id);
        }
    }
}
