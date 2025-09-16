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
    public class HospitalAnaliz_30Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_30Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_30
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_30>>> GetHospitalAnaliz_30()
        {
            return await _context.HospitalAnaliz_30.ToListAsync();
        }
        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_30>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_30
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
            List<HospitalAnaliz_30> itemList = await _context.HospitalAnaliz_30
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_30>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_30.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_30> itemList = await _context.HospitalAnaliz_30
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_30>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_30
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // GET: api/HospitalAnaliz_30/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_30>> GetHospitalAnaliz_30(long id)
        {
            var hospitalAnaliz_30 = await _context.HospitalAnaliz_30.FindAsync(id);

            if (hospitalAnaliz_30 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_30;
        }

        // PUT: api/HospitalAnaliz_30/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_30(long id, HospitalAnaliz_30 hospitalAnaliz_30)
        {
            if (id != hospitalAnaliz_30.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_30).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_30Exists(id))
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

        // POST: api/HospitalAnaliz_30
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_30>> PostHospitalAnaliz_30(HospitalAnaliz_30 hospitalAnaliz_30)
        {
            _context.HospitalAnaliz_30.Update(hospitalAnaliz_30);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_30", new { id = hospitalAnaliz_30.id }, hospitalAnaliz_30);
        }

        // DELETE: api/HospitalAnaliz_30/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_30>> DeleteHospitalAnaliz_30(long id)
        {
            var hospitalAnaliz_30 = await _context.HospitalAnaliz_30.FindAsync(id);
            if (hospitalAnaliz_30 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_30.Remove(hospitalAnaliz_30);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_30;
        }

        private bool HospitalAnaliz_30Exists(long id)
        {
            return _context.HospitalAnaliz_30.Any(e => e.id == id);
        }
    }
}
