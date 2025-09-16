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
    public class HospitalAnaliz_13Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_13Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_13
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_13>>> GetHospitalAnaliz_13()
        {
            return await _context.HospitalAnaliz_13.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_13>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_13
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
            List<HospitalAnaliz_13> itemList = await _context.HospitalAnaliz_13
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_13>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_13.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_13> itemList = await _context.HospitalAnaliz_13
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_13>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_13
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_13/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_13>> GetHospitalAnaliz_13(long id)
        {
            var hospitalAnaliz_13 = await _context.HospitalAnaliz_13.FindAsync(id);

            if (hospitalAnaliz_13 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_13;
        }

        // PUT: api/HospitalAnaliz_13/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_13(long id, HospitalAnaliz_13 hospitalAnaliz_13)
        {
            if (id != hospitalAnaliz_13.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_13).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_13Exists(id))
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

        // POST: api/HospitalAnaliz_13
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_13>> PostHospitalAnaliz_13(HospitalAnaliz_13 hospitalAnaliz_13)
        {
            _context.HospitalAnaliz_13.Update(hospitalAnaliz_13);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_13", new { id = hospitalAnaliz_13.id }, hospitalAnaliz_13);
        }

        // DELETE: api/HospitalAnaliz_13/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_13>> DeleteHospitalAnaliz_13(long id)
        {
            var hospitalAnaliz_13 = await _context.HospitalAnaliz_13.FindAsync(id);
            if (hospitalAnaliz_13 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_13.Remove(hospitalAnaliz_13);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_13;
        }

        private bool HospitalAnaliz_13Exists(long id)
        {
            return _context.HospitalAnaliz_13.Any(e => e.id == id);
        }
    }
}
