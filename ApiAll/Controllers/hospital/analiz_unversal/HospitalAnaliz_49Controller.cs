using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital.analiz.analiz_unversal;
using ApiAll.Model.hospital.analiz;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.hospital.analiz_unversal
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalAnaliz_49Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_49Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_49
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_49>>> GetHospitalAnaliz_49()
        {
            return await _context.HospitalAnaliz_49.ToListAsync();
        }
        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_49>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_49
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
            List<HospitalAnaliz_49> itemList = await _context.HospitalAnaliz_49
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_49>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_49.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_49> itemList = await _context.HospitalAnaliz_49
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_49>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_49
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // GET: api/HospitalAnaliz_49/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_49>> GetHospitalAnaliz_49(long id)
        {
            var hospitalAnaliz_49 = await _context.HospitalAnaliz_49.FindAsync(id);

            if (hospitalAnaliz_49 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_49;
        }

        // PUT: api/HospitalAnaliz_49/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_49(long id, HospitalAnaliz_49 hospitalAnaliz_49)
        {
            if (id != hospitalAnaliz_49.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_49).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_49Exists(id))
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

        // POST: api/HospitalAnaliz_49
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_49>> PostHospitalAnaliz_49(HospitalAnaliz_49 hospitalAnaliz_49)
        {
            _context.HospitalAnaliz_49.Update(hospitalAnaliz_49);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_49", new { id = hospitalAnaliz_49.id }, hospitalAnaliz_49);
        }

        // DELETE: api/HospitalAnaliz_49/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_49>> DeleteHospitalAnaliz_49(long id)
        {
            var hospitalAnaliz_49 = await _context.HospitalAnaliz_49.FindAsync(id);
            if (hospitalAnaliz_49 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_49.Remove(hospitalAnaliz_49);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_49;
        }

        private bool HospitalAnaliz_49Exists(long id)
        {
            return _context.HospitalAnaliz_49.Any(e => e.id == id);
        }
    }
}
