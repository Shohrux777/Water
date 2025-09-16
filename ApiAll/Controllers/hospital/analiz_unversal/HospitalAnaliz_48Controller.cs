using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital.analiz.analiz_unversal;
using ApiAll.Model.hospital.analiz;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.hospital.analiz_unversal
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalAnaliz_48Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_48Controller(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_48>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_48
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
            List<HospitalAnaliz_48> itemList = await _context.HospitalAnaliz_48
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_48>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_48.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {

            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_48> itemList = await _context.HospitalAnaliz_48
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_48>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_48
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // GET: api/HospitalAnaliz_48
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_48>>> GetHospitalAnaliz_48()
        {
            return await _context.HospitalAnaliz_48.ToListAsync();
        }

        // GET: api/HospitalAnaliz_48/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_48>> GetHospitalAnaliz_48(long id)
        {
            var hospitalAnaliz_48 = await _context.HospitalAnaliz_48.FindAsync(id);

            if (hospitalAnaliz_48 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_48;
        }

        // PUT: api/HospitalAnaliz_48/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_48(long id, HospitalAnaliz_48 hospitalAnaliz_48)
        {
            if (id != hospitalAnaliz_48.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_48).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_48Exists(id))
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

        // POST: api/HospitalAnaliz_48
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_48>> PostHospitalAnaliz_48(HospitalAnaliz_48 hospitalAnaliz_48)
        {
            _context.HospitalAnaliz_48.Update(hospitalAnaliz_48);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_48", new { id = hospitalAnaliz_48.id }, hospitalAnaliz_48);
        }

        // DELETE: api/HospitalAnaliz_48/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_48>> DeleteHospitalAnaliz_48(long id)
        {
            var hospitalAnaliz_48 = await _context.HospitalAnaliz_48.FindAsync(id);
            if (hospitalAnaliz_48 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_48.Remove(hospitalAnaliz_48);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_48;
        }

        private bool HospitalAnaliz_48Exists(long id)
        {
            return _context.HospitalAnaliz_48.Any(e => e.id == id);
        }
    }
}
