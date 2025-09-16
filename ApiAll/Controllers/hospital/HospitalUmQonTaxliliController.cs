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
    public class HospitalUmQonTaxliliController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalUmQonTaxliliController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalUmQonTaxlili
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalUmQonTaxlili>>> GetHospitalUmQonTaxlili()
        {
            return await _context.HospitalUmQonTaxlili.ToListAsync();
        }


        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalUmQonTaxlili>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalUmQonTaxlili
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
            List<HospitalUmQonTaxlili> itemList = await _context.HospitalUmQonTaxlili
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalUmQonTaxlili>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalUmQonTaxlili.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalUmQonTaxlili> itemList = await _context.HospitalUmQonTaxlili
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalUmQonTaxlili>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalUmQonTaxlili
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalUmQonTaxlili/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalUmQonTaxlili>> GetHospitalUmQonTaxlili(long id)
        {
            var hospitalUmQonTaxlili = await _context.HospitalUmQonTaxlili.FindAsync(id);

            if (hospitalUmQonTaxlili == null)
            {
                return NotFound();
            }

            hospitalUmQonTaxlili.patients = await _context.Patients.FindAsync(hospitalUmQonTaxlili.PatientsId);



            return hospitalUmQonTaxlili;
        }

        // PUT: api/HospitalUmQonTaxlili/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalUmQonTaxlili(long id, HospitalUmQonTaxlili hospitalUmQonTaxlili)
        {
            if (id != hospitalUmQonTaxlili.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalUmQonTaxlili).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalUmQonTaxliliExists(id))
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

        // POST: api/HospitalUmQonTaxlili
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalUmQonTaxlili>> PostHospitalUmQonTaxlili(HospitalUmQonTaxlili hospitalUmQonTaxlili)
        {
            _context.HospitalUmQonTaxlili.Update(hospitalUmQonTaxlili);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalUmQonTaxlili", new { id = hospitalUmQonTaxlili.id }, hospitalUmQonTaxlili);
        }

        // DELETE: api/HospitalUmQonTaxlili/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalUmQonTaxlili>> DeleteHospitalUmQonTaxlili(long id)
        {
            var hospitalUmQonTaxlili = await _context.HospitalUmQonTaxlili.FindAsync(id);
            if (hospitalUmQonTaxlili == null)
            {
                return NotFound();
            }

            _context.HospitalUmQonTaxlili.Remove(hospitalUmQonTaxlili);
            await _context.SaveChangesAsync();

            return hospitalUmQonTaxlili;
        }

        private bool HospitalUmQonTaxliliExists(long id)
        {
            return _context.HospitalUmQonTaxlili.Any(e => e.id == id);
        }
    }
}
