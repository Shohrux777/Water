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
    public class HospitalAnaliz_16Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_16Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_16
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_16>>> GetHospitalAnaliz_16()
        {
            return await _context.HospitalAnaliz_16.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_16>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_16
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
            List<HospitalAnaliz_16> itemList = await _context.HospitalAnaliz_16
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_16>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_16.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_16> itemList = await _context.HospitalAnaliz_16
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_16>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_16
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_16/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_16>> GetHospitalAnaliz_16(long id)
        {
            var hospitalAnaliz_16 = await _context.HospitalAnaliz_16.FindAsync(id);

            if (hospitalAnaliz_16 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_16;
        }

        // PUT: api/HospitalAnaliz_16/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_16(long id, HospitalAnaliz_16 hospitalAnaliz_16)
        {
            if (id != hospitalAnaliz_16.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_16).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_16Exists(id))
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

        // POST: api/HospitalAnaliz_16
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_16>> PostHospitalAnaliz_16(HospitalAnaliz_16 hospitalAnaliz_16)
        {
            _context.HospitalAnaliz_16.Update(hospitalAnaliz_16);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_16", new { id = hospitalAnaliz_16.id }, hospitalAnaliz_16);
        }

        // DELETE: api/HospitalAnaliz_16/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_16>> DeleteHospitalAnaliz_16(long id)
        {
            var hospitalAnaliz_16 = await _context.HospitalAnaliz_16.FindAsync(id);
            if (hospitalAnaliz_16 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_16.Remove(hospitalAnaliz_16);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_16;
        }

        private bool HospitalAnaliz_16Exists(long id)
        {
            return _context.HospitalAnaliz_16.Any(e => e.id == id);
        }
    }
}
