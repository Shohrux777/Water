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
    public class HospitalAnaliz_12Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_12Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_12
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_12>>> GetHospitalAnaliz_12()
        {
            return await _context.HospitalAnaliz_12.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_12>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_12
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
            List<HospitalAnaliz_12> itemList = await _context.HospitalAnaliz_12
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_12>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_12.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_12> itemList = await _context.HospitalAnaliz_12
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_12>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_12
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_12/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_12>> GetHospitalAnaliz_12(long id)
        {
            var hospitalAnaliz_12 = await _context.HospitalAnaliz_12.FindAsync(id);

            if (hospitalAnaliz_12 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_12;
        }

        // PUT: api/HospitalAnaliz_12/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_12(long id, HospitalAnaliz_12 hospitalAnaliz_12)
        {
            if (id != hospitalAnaliz_12.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_12).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_12Exists(id))
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

        // POST: api/HospitalAnaliz_12
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_12>> PostHospitalAnaliz_12(HospitalAnaliz_12 hospitalAnaliz_12)
        {
            _context.HospitalAnaliz_12.Update(hospitalAnaliz_12);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_12", new { id = hospitalAnaliz_12.id }, hospitalAnaliz_12);
        }

        // DELETE: api/HospitalAnaliz_12/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_12>> DeleteHospitalAnaliz_12(long id)
        {
            var hospitalAnaliz_12 = await _context.HospitalAnaliz_12.FindAsync(id);
            if (hospitalAnaliz_12 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_12.Remove(hospitalAnaliz_12);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_12;
        }

        private bool HospitalAnaliz_12Exists(long id)
        {
            return _context.HospitalAnaliz_12.Any(e => e.id == id);
        }
    }
}
