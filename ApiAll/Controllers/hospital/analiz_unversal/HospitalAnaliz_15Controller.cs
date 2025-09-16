using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital.analiz;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.hospital.analiz_unversal
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalAnaliz_15Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_15Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_15
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_15>>> GetHospitalAnaliz_15()
        {
            return await _context.HospitalAnaliz_15.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_15>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_15
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
            List<HospitalAnaliz_15> itemList = await _context.HospitalAnaliz_15
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_15>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_15.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_15> itemList = await _context.HospitalAnaliz_15
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_15>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_15
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_15/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_15>> GetHospitalAnaliz_15(long id)
        {
            var hospitalAnaliz_15 = await _context.HospitalAnaliz_15.FindAsync(id);

            if (hospitalAnaliz_15 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_15;
        }

        // PUT: api/HospitalAnaliz_15/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_15(long id, HospitalAnaliz_15 hospitalAnaliz_15)
        {
            if (id != hospitalAnaliz_15.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_15).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_15Exists(id))
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

        // POST: api/HospitalAnaliz_15
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_15>> PostHospitalAnaliz_15(HospitalAnaliz_15 hospitalAnaliz_15)
        {
            _context.HospitalAnaliz_15.Update(hospitalAnaliz_15);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_15", new { id = hospitalAnaliz_15.id }, hospitalAnaliz_15);
        }

        // DELETE: api/HospitalAnaliz_15/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_15>> DeleteHospitalAnaliz_15(long id)
        {
            var hospitalAnaliz_15 = await _context.HospitalAnaliz_15.FindAsync(id);
            if (hospitalAnaliz_15 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_15.Remove(hospitalAnaliz_15);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_15;
        }

        private bool HospitalAnaliz_15Exists(long id)
        {
            return _context.HospitalAnaliz_15.Any(e => e.id == id);
        }
    }
}
