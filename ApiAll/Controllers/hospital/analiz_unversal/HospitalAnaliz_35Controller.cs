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
    public class HospitalAnaliz_35Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_35Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_35
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_35>>> GetHospitalAnaliz_35()
        {
            return await _context.HospitalAnaliz_35.ToListAsync();
        }
        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_35>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_35
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
            List<HospitalAnaliz_35> itemList = await _context.HospitalAnaliz_35
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_35>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_35.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_35> itemList = await _context.HospitalAnaliz_35
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_35>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_35
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // GET: api/HospitalAnaliz_35/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_35>> GetHospitalAnaliz_35(long id)
        {
            var hospitalAnaliz_35 = await _context.HospitalAnaliz_35.FindAsync(id);

            if (hospitalAnaliz_35 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_35;
        }

        // PUT: api/HospitalAnaliz_35/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_35(long id, HospitalAnaliz_35 hospitalAnaliz_35)
        {
            if (id != hospitalAnaliz_35.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_35).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_35Exists(id))
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

        // POST: api/HospitalAnaliz_35
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_35>> PostHospitalAnaliz_35(HospitalAnaliz_35 hospitalAnaliz_35)
        {
            _context.HospitalAnaliz_35.Update(hospitalAnaliz_35);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_35", new { id = hospitalAnaliz_35.id }, hospitalAnaliz_35);
        }

        // DELETE: api/HospitalAnaliz_35/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_35>> DeleteHospitalAnaliz_35(long id)
        {
            var hospitalAnaliz_35 = await _context.HospitalAnaliz_35.FindAsync(id);
            if (hospitalAnaliz_35 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_35.Remove(hospitalAnaliz_35);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_35;
        }

        private bool HospitalAnaliz_35Exists(long id)
        {
            return _context.HospitalAnaliz_35.Any(e => e.id == id);
        }
    }
}
