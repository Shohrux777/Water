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
    public class HospitalCovidExpressController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalCovidExpressController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalCovidExpress
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalCovidExpress>>> GetHospitalCovidExpress()
        {
            return await _context.HospitalCovidExpress.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalCovidExpress> itemList = await _context.HospitalCovidExpress
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalCovidExpress>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalCovidExpress.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalCovidExpress>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalCovidExpress
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
            List<HospitalCovidExpress> itemList = await _context.HospitalCovidExpress
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalCovidExpress>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalCovidExpress
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalCovidExpress/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalCovidExpress>> GetHospitalCovidExpress(long id)
        {
            var hospitalCovidExpress = await _context.HospitalCovidExpress.FindAsync(id);

            if (hospitalCovidExpress == null)
            {
                return NotFound();
            }

            hospitalCovidExpress.patients = await _context.Patients.FindAsync(hospitalCovidExpress.PatientsId);

            return hospitalCovidExpress;
        }

        // PUT: api/HospitalCovidExpress/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalCovidExpress(long id, HospitalCovidExpress hospitalCovidExpress)
        {
            if (id != hospitalCovidExpress.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalCovidExpress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalCovidExpressExists(id))
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

        // POST: api/HospitalCovidExpress
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalCovidExpress>> PostHospitalCovidExpress(HospitalCovidExpress hospitalCovidExpress)
        {
            _context.HospitalCovidExpress.Update(hospitalCovidExpress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalCovidExpress", new { id = hospitalCovidExpress.id }, hospitalCovidExpress);
        }

        // DELETE: api/HospitalCovidExpress/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalCovidExpress>> DeleteHospitalCovidExpress(long id)
        {
            var hospitalCovidExpress = await _context.HospitalCovidExpress.FindAsync(id);
            if (hospitalCovidExpress == null)
            {
                return NotFound();
            }

            _context.HospitalCovidExpress.Remove(hospitalCovidExpress);
            await _context.SaveChangesAsync();

            return hospitalCovidExpress;
        }

        private bool HospitalCovidExpressExists(long id)
        {
            return _context.HospitalCovidExpress.Any(e => e.id == id);
        }
    }
}
