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
    public class HospitalAnaliz_7Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_7Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_7
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_7>>> GetHospitalAnaliz_7()
        {
            return await _context.HospitalAnaliz_7.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_7>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_7
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
            List<HospitalAnaliz_7> itemList = await _context.HospitalAnaliz_7
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_7>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_7.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_7> itemList = await _context.HospitalAnaliz_7
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_7>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_7
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_7/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_7>> GetHospitalAnaliz_7(long id)
        {
            var hospitalAnaliz_7 = await _context.HospitalAnaliz_7.FindAsync(id);

            if (hospitalAnaliz_7 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_7;
        }

        // PUT: api/HospitalAnaliz_7/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_7(long id, HospitalAnaliz_7 hospitalAnaliz_7)
        {
            if (id != hospitalAnaliz_7.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_7).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_7Exists(id))
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

        // POST: api/HospitalAnaliz_7
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_7>> PostHospitalAnaliz_7(HospitalAnaliz_7 hospitalAnaliz_7)
        {
            _context.HospitalAnaliz_7.Update(hospitalAnaliz_7);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_7", new { id = hospitalAnaliz_7.id }, hospitalAnaliz_7);
        }

        // DELETE: api/HospitalAnaliz_7/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_7>> DeleteHospitalAnaliz_7(long id)
        {
            var hospitalAnaliz_7 = await _context.HospitalAnaliz_7.FindAsync(id);
            if (hospitalAnaliz_7 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_7.Remove(hospitalAnaliz_7);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_7;
        }

        private bool HospitalAnaliz_7Exists(long id)
        {
            return _context.HospitalAnaliz_7.Any(e => e.id == id);
        }
    }
}
