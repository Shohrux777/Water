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
    public class HospitalAnaliz_4Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_4Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_4
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_4>>> GetHospitalAnaliz_4()
        {
            return await _context.HospitalAnaliz_4.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_4>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_4
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
            List<HospitalAnaliz_4> itemList = await _context.HospitalAnaliz_4
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_4>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_4.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_4> itemList = await _context.HospitalAnaliz_4
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_4>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_4
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_4/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_4>> GetHospitalAnaliz_4(long id)
        {
            var hospitalAnaliz_4 = await _context.HospitalAnaliz_4.FindAsync(id);

            if (hospitalAnaliz_4 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_4;
        }

        // PUT: api/HospitalAnaliz_4/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_4(long id, HospitalAnaliz_4 hospitalAnaliz_4)
        {
            if (id != hospitalAnaliz_4.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_4).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_4Exists(id))
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

        // POST: api/HospitalAnaliz_4
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_4>> PostHospitalAnaliz_4(HospitalAnaliz_4 hospitalAnaliz_4)
        {
            _context.HospitalAnaliz_4.Update(hospitalAnaliz_4);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_4", new { id = hospitalAnaliz_4.id }, hospitalAnaliz_4);
        }

        // DELETE: api/HospitalAnaliz_4/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_4>> DeleteHospitalAnaliz_4(long id)
        {
            var hospitalAnaliz_4 = await _context.HospitalAnaliz_4.FindAsync(id);
            if (hospitalAnaliz_4 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_4.Remove(hospitalAnaliz_4);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_4;
        }

        private bool HospitalAnaliz_4Exists(long id)
        {
            return _context.HospitalAnaliz_4.Any(e => e.id == id);
        }
    }
}
