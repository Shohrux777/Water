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

namespace ApiAll.Controllers.hospital.analiz_unversal
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalAnaliz_19Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_19Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_19
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_19>>> GetHospitalAnaliz_19()
        {
            return await _context.HospitalAnaliz_19.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_19>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_19
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
            List<HospitalAnaliz_19> itemList = await _context.HospitalAnaliz_19
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_19>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_19.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_19> itemList = await _context.HospitalAnaliz_19
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_19>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_19
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_19/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_19>> GetHospitalAnaliz_19(long id)
        {
            var hospitalAnaliz_19 = await _context.HospitalAnaliz_19.FindAsync(id);

            if (hospitalAnaliz_19 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_19;
        }

        // PUT: api/HospitalAnaliz_19/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_19(long id, HospitalAnaliz_19 hospitalAnaliz_19)
        {
            if (id != hospitalAnaliz_19.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_19).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_19Exists(id))
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

        // POST: api/HospitalAnaliz_19
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_19>> PostHospitalAnaliz_19(HospitalAnaliz_19 hospitalAnaliz_19)
        {
            _context.HospitalAnaliz_19.Update(hospitalAnaliz_19);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_19", new { id = hospitalAnaliz_19.id }, hospitalAnaliz_19);
        }

        // DELETE: api/HospitalAnaliz_19/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_19>> DeleteHospitalAnaliz_19(long id)
        {
            var hospitalAnaliz_19 = await _context.HospitalAnaliz_19.FindAsync(id);
            if (hospitalAnaliz_19 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_19.Remove(hospitalAnaliz_19);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_19;
        }

        private bool HospitalAnaliz_19Exists(long id)
        {
            return _context.HospitalAnaliz_19.Any(e => e.id == id);
        }
    }
}
