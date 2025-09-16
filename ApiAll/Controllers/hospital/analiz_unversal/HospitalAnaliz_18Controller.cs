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
    public class HospitalAnaliz_18Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_18Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_18
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_18>>> GetHospitalAnaliz_18()
        {
            return await _context.HospitalAnaliz_18.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_18>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_18
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
            List<HospitalAnaliz_18> itemList = await _context.HospitalAnaliz_18
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_18>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_18.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_18> itemList = await _context.HospitalAnaliz_18
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_18>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_18
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_18/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_18>> GetHospitalAnaliz_18(long id)
        {
            var hospitalAnaliz_18 = await _context.HospitalAnaliz_18.FindAsync(id);

            if (hospitalAnaliz_18 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_18;
        }

        // PUT: api/HospitalAnaliz_18/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_18(long id, HospitalAnaliz_18 hospitalAnaliz_18)
        {
            if (id != hospitalAnaliz_18.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_18).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_18Exists(id))
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

        // POST: api/HospitalAnaliz_18
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_18>> PostHospitalAnaliz_18(HospitalAnaliz_18 hospitalAnaliz_18)
        {
            _context.HospitalAnaliz_18.Update(hospitalAnaliz_18);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_18", new { id = hospitalAnaliz_18.id }, hospitalAnaliz_18);
        }

        // DELETE: api/HospitalAnaliz_18/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_18>> DeleteHospitalAnaliz_18(long id)
        {
            var hospitalAnaliz_18 = await _context.HospitalAnaliz_18.FindAsync(id);
            if (hospitalAnaliz_18 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_18.Remove(hospitalAnaliz_18);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_18;
        }

        private bool HospitalAnaliz_18Exists(long id)
        {
            return _context.HospitalAnaliz_18.Any(e => e.id == id);
        }
    }
}
