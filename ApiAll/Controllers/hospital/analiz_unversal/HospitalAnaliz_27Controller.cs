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
    public class HospitalAnaliz_27Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_27Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_27
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_27>>> GetHospitalAnaliz_27()
        {
            return await _context.HospitalAnaliz_27.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_27>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_27
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
            List<HospitalAnaliz_27> itemList = await _context.HospitalAnaliz_27
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_27>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_27.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_27> itemList = await _context.HospitalAnaliz_27
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_27>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_27
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_27/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_27>> GetHospitalAnaliz_27(long id)
        {
            var hospitalAnaliz_27 = await _context.HospitalAnaliz_27.FindAsync(id);

            if (hospitalAnaliz_27 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_27;
        }

        // PUT: api/HospitalAnaliz_27/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_27(long id, HospitalAnaliz_27 hospitalAnaliz_27)
        {
            if (id != hospitalAnaliz_27.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_27).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_27Exists(id))
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

        // POST: api/HospitalAnaliz_27
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_27>> PostHospitalAnaliz_27(HospitalAnaliz_27 hospitalAnaliz_27)
        {
            _context.HospitalAnaliz_27.Update(hospitalAnaliz_27);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_27", new { id = hospitalAnaliz_27.id }, hospitalAnaliz_27);
        }

        // DELETE: api/HospitalAnaliz_27/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_27>> DeleteHospitalAnaliz_27(long id)
        {
            var hospitalAnaliz_27 = await _context.HospitalAnaliz_27.FindAsync(id);
            if (hospitalAnaliz_27 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_27.Remove(hospitalAnaliz_27);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_27;
        }

        private bool HospitalAnaliz_27Exists(long id)
        {
            return _context.HospitalAnaliz_27.Any(e => e.id == id);
        }
    }
}
