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
    public class HospitalAnaliz_6Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_6Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_6
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_6>>> GetHospitalAnaliz_6()
        {
            return await _context.HospitalAnaliz_6.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_6>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_6
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
            List<HospitalAnaliz_6> itemList = await _context.HospitalAnaliz_6
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_6>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_6.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_6> itemList = await _context.HospitalAnaliz_6
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_6>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_6
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_6/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_6>> GetHospitalAnaliz_6(long id)
        {
            var hospitalAnaliz_6 = await _context.HospitalAnaliz_6.FindAsync(id);

            if (hospitalAnaliz_6 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_6;
        }

        // PUT: api/HospitalAnaliz_6/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_6(long id, HospitalAnaliz_6 hospitalAnaliz_6)
        {
            if (id != hospitalAnaliz_6.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_6).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_6Exists(id))
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

        // POST: api/HospitalAnaliz_6
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_6>> PostHospitalAnaliz_6(HospitalAnaliz_6 hospitalAnaliz_6)
        {
            _context.HospitalAnaliz_6.Update(hospitalAnaliz_6);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_6", new { id = hospitalAnaliz_6.id }, hospitalAnaliz_6);
        }

        // DELETE: api/HospitalAnaliz_6/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_6>> DeleteHospitalAnaliz_6(long id)
        {
            var hospitalAnaliz_6 = await _context.HospitalAnaliz_6.FindAsync(id);
            if (hospitalAnaliz_6 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_6.Remove(hospitalAnaliz_6);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_6;
        }

        private bool HospitalAnaliz_6Exists(long id)
        {
            return _context.HospitalAnaliz_6.Any(e => e.id == id);
        }
    }
}
