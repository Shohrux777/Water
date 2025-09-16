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
    public class HospitalAnaliz_47Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_47Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_47
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_47>>> GetHospitalAnaliz_47()
        {
            return await _context.HospitalAnaliz_47.ToListAsync();
        }

        // GET: api/HospitalAnaliz_47/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_47>> GetHospitalAnaliz_47(long id)
        {
            var hospitalAnaliz_47 = await _context.HospitalAnaliz_47.FindAsync(id);

            if (hospitalAnaliz_47 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_47;
        }
        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_47>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_47
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
            List<HospitalAnaliz_47> itemList = await _context.HospitalAnaliz_47
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_47>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_47.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_47> itemList = await _context.HospitalAnaliz_47
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_47>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_47
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // PUT: api/HospitalAnaliz_47/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_47(long id, HospitalAnaliz_47 hospitalAnaliz_47)
        {
            if (id != hospitalAnaliz_47.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_47).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_47Exists(id))
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

        // POST: api/HospitalAnaliz_47
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_47>> PostHospitalAnaliz_47(HospitalAnaliz_47 hospitalAnaliz_47)
        {
            _context.HospitalAnaliz_47.Update(hospitalAnaliz_47);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_47", new { id = hospitalAnaliz_47.id }, hospitalAnaliz_47);
        }

        // DELETE: api/HospitalAnaliz_47/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_47>> DeleteHospitalAnaliz_47(long id)
        {
            var hospitalAnaliz_47 = await _context.HospitalAnaliz_47.FindAsync(id);
            if (hospitalAnaliz_47 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_47.Remove(hospitalAnaliz_47);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_47;
        }

        private bool HospitalAnaliz_47Exists(long id)
        {
            return _context.HospitalAnaliz_47.Any(e => e.id == id);
        }
    }
}
