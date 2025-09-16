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
    public class HospitalAnaliz_14Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_14Controller(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_14>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_14
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
            List<HospitalAnaliz_14> itemList = await _context.HospitalAnaliz_14
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_14>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_14.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_14> itemList = await _context.HospitalAnaliz_14
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_14>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_14
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_14
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_14>>> GetHospitalAnaliz_14()
        {
            return await _context.HospitalAnaliz_14.ToListAsync();
        }

        // GET: api/HospitalAnaliz_14/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_14>> GetHospitalAnaliz_14(long id)
        {
            var hospitalAnaliz_14 = await _context.HospitalAnaliz_14.FindAsync(id);

            if (hospitalAnaliz_14 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_14;
        }

        // PUT: api/HospitalAnaliz_14/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_14(long id, HospitalAnaliz_14 hospitalAnaliz_14)
        {
            if (id != hospitalAnaliz_14.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_14).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_14Exists(id))
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

        // POST: api/HospitalAnaliz_14
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_14>> PostHospitalAnaliz_14(HospitalAnaliz_14 hospitalAnaliz_14)
        {
            _context.HospitalAnaliz_14.Update(hospitalAnaliz_14);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_14", new { id = hospitalAnaliz_14.id }, hospitalAnaliz_14);
        }

        // DELETE: api/HospitalAnaliz_14/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_14>> DeleteHospitalAnaliz_14(long id)
        {
            var hospitalAnaliz_14 = await _context.HospitalAnaliz_14.FindAsync(id);
            if (hospitalAnaliz_14 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_14.Remove(hospitalAnaliz_14);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_14;
        }

        private bool HospitalAnaliz_14Exists(long id)
        {
            return _context.HospitalAnaliz_14.Any(e => e.id == id);
        }
    }
}
