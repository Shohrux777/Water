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
    public class HospitalAnaliz_10Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_10Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_10
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_10>>> GetHospitalAnaliz_10()
        {
            return await _context.HospitalAnaliz_10.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_10>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_10
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
            List<HospitalAnaliz_10> itemList = await _context.HospitalAnaliz_10
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_10>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_10.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_10> itemList = await _context.HospitalAnaliz_10
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_10>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_10
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_10/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_10>> GetHospitalAnaliz_10(long id)
        {
            var hospitalAnaliz_10 = await _context.HospitalAnaliz_10.FindAsync(id);

            if (hospitalAnaliz_10 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_10;
        }

        // PUT: api/HospitalAnaliz_10/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_10(long id, HospitalAnaliz_10 hospitalAnaliz_10)
        {
            if (id != hospitalAnaliz_10.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_10).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_10Exists(id))
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

        // POST: api/HospitalAnaliz_10
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_10>> PostHospitalAnaliz_10(HospitalAnaliz_10 hospitalAnaliz_10)
        {
            _context.HospitalAnaliz_10.Update(hospitalAnaliz_10);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_10", new { id = hospitalAnaliz_10.id }, hospitalAnaliz_10);
        }

        // DELETE: api/HospitalAnaliz_10/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_10>> DeleteHospitalAnaliz_10(long id)
        {
            var hospitalAnaliz_10 = await _context.HospitalAnaliz_10.FindAsync(id);
            if (hospitalAnaliz_10 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_10.Remove(hospitalAnaliz_10);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_10;
        }

        private bool HospitalAnaliz_10Exists(long id)
        {
            return _context.HospitalAnaliz_10.Any(e => e.id == id);
        }
    }
}
