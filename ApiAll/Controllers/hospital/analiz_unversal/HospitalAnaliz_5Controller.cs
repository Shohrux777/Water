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
    public class HospitalAnaliz_5Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_5Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_5>>> GetHospitalAnaliz_5()
        {
            return await _context.HospitalAnaliz_5.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_5>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_5
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
            List<HospitalAnaliz_5> itemList = await _context.HospitalAnaliz_5
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_5>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_5.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_5> itemList = await _context.HospitalAnaliz_5
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_5>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_5
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_5/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_5>> GetHospitalAnaliz_5(long id)
        {
            var hospitalAnaliz_5 = await _context.HospitalAnaliz_5.FindAsync(id);

            if (hospitalAnaliz_5 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_5;
        }

        // PUT: api/HospitalAnaliz_5/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_5(long id, HospitalAnaliz_5 hospitalAnaliz_5)
        {
            if (id != hospitalAnaliz_5.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_5).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_5Exists(id))
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

        // POST: api/HospitalAnaliz_5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_5>> PostHospitalAnaliz_5(HospitalAnaliz_5 hospitalAnaliz_5)
        {
            _context.HospitalAnaliz_5.Update(hospitalAnaliz_5);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_5", new { id = hospitalAnaliz_5.id }, hospitalAnaliz_5);
        }

        // DELETE: api/HospitalAnaliz_5/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_5>> DeleteHospitalAnaliz_5(long id)
        {
            var hospitalAnaliz_5 = await _context.HospitalAnaliz_5.FindAsync(id);
            if (hospitalAnaliz_5 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_5.Remove(hospitalAnaliz_5);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_5;
        }

        private bool HospitalAnaliz_5Exists(long id)
        {
            return _context.HospitalAnaliz_5.Any(e => e.id == id);
        }
    }
}
