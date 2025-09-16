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
    public class HospitalAnaliz_17Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_17Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_17
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_17>>> GetHospitalAnaliz_17()
        {
            return await _context.HospitalAnaliz_17.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_17>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_17
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
            List<HospitalAnaliz_17> itemList = await _context.HospitalAnaliz_17
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_17>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_17.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_17> itemList = await _context.HospitalAnaliz_17
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_17>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_17
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_17/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_17>> GetHospitalAnaliz_17(long id)
        {
            var hospitalAnaliz_17 = await _context.HospitalAnaliz_17.FindAsync(id);

            if (hospitalAnaliz_17 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_17;
        }

        // PUT: api/HospitalAnaliz_17/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_17(long id, HospitalAnaliz_17 hospitalAnaliz_17)
        {
            if (id != hospitalAnaliz_17.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_17).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_17Exists(id))
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

        // POST: api/HospitalAnaliz_17
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_17>> PostHospitalAnaliz_17(HospitalAnaliz_17 hospitalAnaliz_17)
        {
            _context.HospitalAnaliz_17.Update(hospitalAnaliz_17);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_17", new { id = hospitalAnaliz_17.id }, hospitalAnaliz_17);
        }

        // DELETE: api/HospitalAnaliz_17/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_17>> DeleteHospitalAnaliz_17(long id)
        {
            var hospitalAnaliz_17 = await _context.HospitalAnaliz_17.FindAsync(id);
            if (hospitalAnaliz_17 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_17.Remove(hospitalAnaliz_17);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_17;
        }

        private bool HospitalAnaliz_17Exists(long id)
        {
            return _context.HospitalAnaliz_17.Any(e => e.id == id);
        }
    }
}
