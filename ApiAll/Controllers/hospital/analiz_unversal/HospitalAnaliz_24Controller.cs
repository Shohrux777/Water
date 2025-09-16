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
    public class HospitalAnaliz_24Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_24Controller(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_24>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_24
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
            List<HospitalAnaliz_24> itemList = await _context.HospitalAnaliz_24
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_24>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_24.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_24> itemList = await _context.HospitalAnaliz_24
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_24>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_24
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // GET: api/HospitalAnaliz_24
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_24>>> GetHospitalAnaliz_24()
        {
            return await _context.HospitalAnaliz_24.ToListAsync();
        }

        // GET: api/HospitalAnaliz_24/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_24>> GetHospitalAnaliz_24(long id)
        {
            var hospitalAnaliz_24 = await _context.HospitalAnaliz_24.FindAsync(id);

            if (hospitalAnaliz_24 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_24;
        }

        // PUT: api/HospitalAnaliz_24/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_24(long id, HospitalAnaliz_24 hospitalAnaliz_24)
        {
            if (id != hospitalAnaliz_24.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_24).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_24Exists(id))
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

        // POST: api/HospitalAnaliz_24
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_24>> PostHospitalAnaliz_24(HospitalAnaliz_24 hospitalAnaliz_24)
        {
            _context.HospitalAnaliz_24.Update(hospitalAnaliz_24);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_24", new { id = hospitalAnaliz_24.id }, hospitalAnaliz_24);
        }

        // DELETE: api/HospitalAnaliz_24/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_24>> DeleteHospitalAnaliz_24(long id)
        {
            var hospitalAnaliz_24 = await _context.HospitalAnaliz_24.FindAsync(id);
            if (hospitalAnaliz_24 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_24.Remove(hospitalAnaliz_24);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_24;
        }

        private bool HospitalAnaliz_24Exists(long id)
        {
            return _context.HospitalAnaliz_24.Any(e => e.id == id);
        }
    }
}
