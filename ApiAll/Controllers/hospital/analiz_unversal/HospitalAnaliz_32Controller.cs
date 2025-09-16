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
    public class HospitalAnaliz_32Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_32Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_32
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_32>>> GetHospitalAnaliz_32()
        {
            return await _context.HospitalAnaliz_32.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_32>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_32
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
            List<HospitalAnaliz_32> itemList = await _context.HospitalAnaliz_32
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_32>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_32.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_32> itemList = await _context.HospitalAnaliz_32
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_32>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_32
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_32/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_32>> GetHospitalAnaliz_32(long id)
        {
            var hospitalAnaliz_32 = await _context.HospitalAnaliz_32.FindAsync(id);

            if (hospitalAnaliz_32 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_32;
        }

        // PUT: api/HospitalAnaliz_32/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_32(long id, HospitalAnaliz_32 hospitalAnaliz_32)
        {
            if (id != hospitalAnaliz_32.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_32).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_32Exists(id))
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

        // POST: api/HospitalAnaliz_32
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_32>> PostHospitalAnaliz_32(HospitalAnaliz_32 hospitalAnaliz_32)
        {
            _context.HospitalAnaliz_32.Update(hospitalAnaliz_32);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_32", new { id = hospitalAnaliz_32.id }, hospitalAnaliz_32);
        }

        // DELETE: api/HospitalAnaliz_32/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_32>> DeleteHospitalAnaliz_32(long id)
        {
            var hospitalAnaliz_32 = await _context.HospitalAnaliz_32.FindAsync(id);
            if (hospitalAnaliz_32 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_32.Remove(hospitalAnaliz_32);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_32;
        }

        private bool HospitalAnaliz_32Exists(long id)
        {
            return _context.HospitalAnaliz_32.Any(e => e.id == id);
        }
    }
}
