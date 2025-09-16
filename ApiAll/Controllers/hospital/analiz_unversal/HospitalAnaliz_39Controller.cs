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
    public class HospitalAnaliz_39Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_39Controller(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_39>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_39
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
            List<HospitalAnaliz_39> itemList = await _context.HospitalAnaliz_39
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_39>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_39.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_39> itemList = await _context.HospitalAnaliz_39
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_39>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_39
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // GET: api/HospitalAnaliz_39
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_39>>> GetHospitalAnaliz_39()
        {
            return await _context.HospitalAnaliz_39.ToListAsync();
        }

        // GET: api/HospitalAnaliz_39/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_39>> GetHospitalAnaliz_39(long id)
        {
            var hospitalAnaliz_39 = await _context.HospitalAnaliz_39.FindAsync(id);

            if (hospitalAnaliz_39 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_39;
        }

        // PUT: api/HospitalAnaliz_39/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_39(long id, HospitalAnaliz_39 hospitalAnaliz_39)
        {
            if (id != hospitalAnaliz_39.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_39).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_39Exists(id))
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

        // POST: api/HospitalAnaliz_39
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_39>> PostHospitalAnaliz_39(HospitalAnaliz_39 hospitalAnaliz_39)
        {
            _context.HospitalAnaliz_39.Update(hospitalAnaliz_39);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_39", new { id = hospitalAnaliz_39.id }, hospitalAnaliz_39);
        }

        // DELETE: api/HospitalAnaliz_39/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_39>> DeleteHospitalAnaliz_39(long id)
        {
            var hospitalAnaliz_39 = await _context.HospitalAnaliz_39.FindAsync(id);
            if (hospitalAnaliz_39 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_39.Remove(hospitalAnaliz_39);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_39;
        }

        private bool HospitalAnaliz_39Exists(long id)
        {
            return _context.HospitalAnaliz_39.Any(e => e.id == id);
        }
    }
}
