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
    public class HospitalAnaliz_50Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_50Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_50
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_50>>> GetHospitalAnaliz_50()
        {
            return await _context.HospitalAnaliz_50.ToListAsync();
        }

        // GET: api/HospitalAnaliz_50/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_50>> GetHospitalAnaliz_50(long id)
        {
            var hospitalAnaliz_50 = await _context.HospitalAnaliz_50.FindAsync(id);

            if (hospitalAnaliz_50 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_50;
        }

        // PUT: api/HospitalAnaliz_50/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_50(long id, HospitalAnaliz_50 hospitalAnaliz_50)
        {
            if (id != hospitalAnaliz_50.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_50).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_50Exists(id))
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

        // POST: api/HospitalAnaliz_50
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_50>> PostHospitalAnaliz_50(HospitalAnaliz_50 hospitalAnaliz_50)
        {
            _context.HospitalAnaliz_50.Update(hospitalAnaliz_50);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_50", new { id = hospitalAnaliz_50.id }, hospitalAnaliz_50);
        }
        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_50>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_50
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
            List<HospitalAnaliz_50> itemList = await _context.HospitalAnaliz_50
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_50>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_50.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_50> itemList = await _context.HospitalAnaliz_50
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_50>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_50
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // DELETE: api/HospitalAnaliz_50/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_50>> DeleteHospitalAnaliz_50(long id)
        {
            var hospitalAnaliz_50 = await _context.HospitalAnaliz_50.FindAsync(id);
            if (hospitalAnaliz_50 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_50.Remove(hospitalAnaliz_50);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_50;
        }

        private bool HospitalAnaliz_50Exists(long id)
        {
            return _context.HospitalAnaliz_50.Any(e => e.id == id);
        }
    }
}
