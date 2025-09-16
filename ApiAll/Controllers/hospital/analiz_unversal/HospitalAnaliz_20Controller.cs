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
    public class HospitalAnaliz_20Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_20Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_20
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_20>>> GetHospitalAnaliz_20()
        {
            return await _context.HospitalAnaliz_20.ToListAsync();
        }
        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_20>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_20
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
            List<HospitalAnaliz_20> itemList = await _context.HospitalAnaliz_20
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_20>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_20.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_20> itemList = await _context.HospitalAnaliz_20
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_20>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_20
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // GET: api/HospitalAnaliz_20/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_20>> GetHospitalAnaliz_20(long id)
        {
            var hospitalAnaliz_20 = await _context.HospitalAnaliz_20.FindAsync(id);

            if (hospitalAnaliz_20 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_20;
        }

        // PUT: api/HospitalAnaliz_20/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_20(long id, HospitalAnaliz_20 hospitalAnaliz_20)
        {
            if (id != hospitalAnaliz_20.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_20).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_20Exists(id))
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

        // POST: api/HospitalAnaliz_20
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_20>> PostHospitalAnaliz_20(HospitalAnaliz_20 hospitalAnaliz_20)
        {
            _context.HospitalAnaliz_20.Update(hospitalAnaliz_20);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_20", new { id = hospitalAnaliz_20.id }, hospitalAnaliz_20);
        }

        // DELETE: api/HospitalAnaliz_20/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_20>> DeleteHospitalAnaliz_20(long id)
        {
            var hospitalAnaliz_20 = await _context.HospitalAnaliz_20.FindAsync(id);
            if (hospitalAnaliz_20 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_20.Remove(hospitalAnaliz_20);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_20;
        }

        private bool HospitalAnaliz_20Exists(long id)
        {
            return _context.HospitalAnaliz_20.Any(e => e.id == id);
        }
    }
}
