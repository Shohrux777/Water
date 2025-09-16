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
    public class HospitalAnaliz_25Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_25Controller(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_25>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_25
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
            List<HospitalAnaliz_25> itemList = await _context.HospitalAnaliz_25
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_25>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_25.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_25> itemList = await _context.HospitalAnaliz_25
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_25>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_25
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // GET: api/HospitalAnaliz_25
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_25>>> GetHospitalAnaliz_25()
        {
            return await _context.HospitalAnaliz_25.ToListAsync();
        }

        // GET: api/HospitalAnaliz_25/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_25>> GetHospitalAnaliz_25(long id)
        {
            var hospitalAnaliz_25 = await _context.HospitalAnaliz_25.FindAsync(id);

            if (hospitalAnaliz_25 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_25;
        }

        // PUT: api/HospitalAnaliz_25/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_25(long id, HospitalAnaliz_25 hospitalAnaliz_25)
        {
            if (id != hospitalAnaliz_25.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_25).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_25Exists(id))
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

        // POST: api/HospitalAnaliz_25
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_25>> PostHospitalAnaliz_25(HospitalAnaliz_25 hospitalAnaliz_25)
        {
            _context.HospitalAnaliz_25.Update(hospitalAnaliz_25);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_25", new { id = hospitalAnaliz_25.id }, hospitalAnaliz_25);
        }

        // DELETE: api/HospitalAnaliz_25/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_25>> DeleteHospitalAnaliz_25(long id)
        {
            var hospitalAnaliz_25 = await _context.HospitalAnaliz_25.FindAsync(id);
            if (hospitalAnaliz_25 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_25.Remove(hospitalAnaliz_25);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_25;
        }

        private bool HospitalAnaliz_25Exists(long id)
        {
            return _context.HospitalAnaliz_25.Any(e => e.id == id);
        }
    }
}
