using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital.analiz;
using Newtonsoft.Json.Linq;
using ApiAll.Model.tekistil;

namespace ApiAll.Controllers.hospital.analiz_unversal
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalAnaliz_3Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_3Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_3
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_3>>> GetHospitalAnaliz_3()
        {
            return await _context.HospitalAnaliz_3.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_3>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_3
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
            List<HospitalAnaliz_3> itemList = await _context.HospitalAnaliz_3
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_3>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_3.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_3> itemList = await _context.HospitalAnaliz_3
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_3>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_3
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_3/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_3>> GetHospitalAnaliz_3(long id)
        {
            var hospitalAnaliz_3 = await _context.HospitalAnaliz_3.FindAsync(id);

            if (hospitalAnaliz_3 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_3;
        }

        // PUT: api/HospitalAnaliz_3/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_3(long id, HospitalAnaliz_3 hospitalAnaliz_3)
        {
            if (id != hospitalAnaliz_3.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_3).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_3Exists(id))
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

        // POST: api/HospitalAnaliz_3
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_3>> PostHospitalAnaliz_3(HospitalAnaliz_3 hospitalAnaliz_3)
        {
            _context.HospitalAnaliz_3.Update(hospitalAnaliz_3);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_3", new { id = hospitalAnaliz_3.id }, hospitalAnaliz_3);
        }

        // DELETE: api/HospitalAnaliz_3/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_3>> DeleteHospitalAnaliz_3(long id)
        {
            var hospitalAnaliz_3 = await _context.HospitalAnaliz_3.FindAsync(id);
            if (hospitalAnaliz_3 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_3.Remove(hospitalAnaliz_3);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_3;
        }

        private bool HospitalAnaliz_3Exists(long id)
        {
            return _context.HospitalAnaliz_3.Any(e => e.id == id);
        }
    }
}
