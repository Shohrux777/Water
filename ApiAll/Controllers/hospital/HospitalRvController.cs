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
    public class HospitalRvController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalRvController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalRv
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalRv>>> GetHospitalRv()
        {
            return await _context.HospitalRv.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalRv>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalRv
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
            List<HospitalRv> itemList = await _context.HospitalRv
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalRv>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalRv.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalRv> itemList = await _context.HospitalRv
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalRv>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalRv
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalRv/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalRv>> GetHospitalRv(long id)
        {
            var hospitalRv = await _context.HospitalRv.FindAsync(id);

            if (hospitalRv == null)
            {
                return NotFound();
            }

            hospitalRv.patients = await _context.Patients.FindAsync(hospitalRv.PatientsId);


            return hospitalRv;
        }

        // PUT: api/HospitalRv/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalRv(long id, HospitalRv hospitalRv)
        {
            if (id != hospitalRv.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalRv).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalRvExists(id))
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

        // POST: api/HospitalRv
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalRv>> PostHospitalRv(HospitalRv hospitalRv)
        {
            _context.HospitalRv.Update(hospitalRv);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalRv", new { id = hospitalRv.id }, hospitalRv);
        }

        // DELETE: api/HospitalRv/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalRv>> DeleteHospitalRv(long id)
        {
            var hospitalRv = await _context.HospitalRv.FindAsync(id);
            if (hospitalRv == null)
            {
                return NotFound();
            }

            _context.HospitalRv.Remove(hospitalRv);
            await _context.SaveChangesAsync();

            return hospitalRv;
        }

        private bool HospitalRvExists(long id)
        {
            return _context.HospitalRv.Any(e => e.id == id);
        }
    }
}
