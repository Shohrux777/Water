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
    public class HospitalAnaliz_1Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_1Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_1>>> GetHospitalAnaliz_1()
        {
            return await _context.HospitalAnaliz_1.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_1>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_1
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
            List<HospitalAnaliz_1> itemList = await _context.HospitalAnaliz_1
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_1>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_1.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_1> itemList = await _context.HospitalAnaliz_1
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_1>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_1
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_1>> GetHospitalAnaliz_1(long id)
        {
            var hospitalAnaliz_1 = await _context.HospitalAnaliz_1.FindAsync(id);

            if (hospitalAnaliz_1 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_1;
        }

        // PUT: api/HospitalAnaliz_1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_1(long id, HospitalAnaliz_1 hospitalAnaliz_1)
        {
            if (id != hospitalAnaliz_1.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_1Exists(id))
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

        // POST: api/HospitalAnaliz_1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_1>> PostHospitalAnaliz_1(HospitalAnaliz_1 hospitalAnaliz_1)
        {
            _context.HospitalAnaliz_1.Update(hospitalAnaliz_1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_1", new { id = hospitalAnaliz_1.id }, hospitalAnaliz_1);
        }

        // DELETE: api/HospitalAnaliz_1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_1>> DeleteHospitalAnaliz_1(long id)
        {
            var hospitalAnaliz_1 = await _context.HospitalAnaliz_1.FindAsync(id);
            if (hospitalAnaliz_1 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_1.Remove(hospitalAnaliz_1);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_1;
        }

        private bool HospitalAnaliz_1Exists(long id)
        {
            return _context.HospitalAnaliz_1.Any(e => e.id == id);
        }
    }
}
