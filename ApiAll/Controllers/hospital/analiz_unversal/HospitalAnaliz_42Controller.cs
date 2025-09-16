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
    public class HospitalAnaliz_42Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_42Controller(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_42>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_42
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
            List<HospitalAnaliz_42> itemList = await _context.HospitalAnaliz_42
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_42>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_42.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_42> itemList = await _context.HospitalAnaliz_42
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_42>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_42
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_42
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_42>>> GetHospitalAnaliz_42()
        {
            return await _context.HospitalAnaliz_42.ToListAsync();
        }

        // GET: api/HospitalAnaliz_42/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_42>> GetHospitalAnaliz_42(long id)
        {
            var hospitalAnaliz_42 = await _context.HospitalAnaliz_42.FindAsync(id);

            if (hospitalAnaliz_42 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_42;
        }

        // PUT: api/HospitalAnaliz_42/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_42(long id, HospitalAnaliz_42 hospitalAnaliz_42)
        {
            if (id != hospitalAnaliz_42.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_42).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_42Exists(id))
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

        // POST: api/HospitalAnaliz_42
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_42>> PostHospitalAnaliz_42(HospitalAnaliz_42 hospitalAnaliz_42)
        {
            _context.HospitalAnaliz_42.Update(hospitalAnaliz_42);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_42", new { id = hospitalAnaliz_42.id }, hospitalAnaliz_42);
        }

        // DELETE: api/HospitalAnaliz_42/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_42>> DeleteHospitalAnaliz_42(long id)
        {
            var hospitalAnaliz_42 = await _context.HospitalAnaliz_42.FindAsync(id);
            if (hospitalAnaliz_42 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_42.Remove(hospitalAnaliz_42);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_42;
        }

        private bool HospitalAnaliz_42Exists(long id)
        {
            return _context.HospitalAnaliz_42.Any(e => e.id == id);
        }
    }
}
