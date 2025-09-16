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
    public class HospitalAnaliz_2Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_2Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_2>>> GetHospitalAnaliz_2()
        {
            return await _context.HospitalAnaliz_2.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_2>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_2
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
            List<HospitalAnaliz_2> itemList = await _context.HospitalAnaliz_2
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_2>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_2.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_2> itemList = await _context.HospitalAnaliz_2
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_2>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_2
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_2>> GetHospitalAnaliz_2(long id)
        {
            var hospitalAnaliz_2 = await _context.HospitalAnaliz_2.FindAsync(id);

            if (hospitalAnaliz_2 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_2;
        }

        // PUT: api/HospitalAnaliz_2/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_2(long id, HospitalAnaliz_2 hospitalAnaliz_2)
        {
            if (id != hospitalAnaliz_2.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_2Exists(id))
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

        // POST: api/HospitalAnaliz_2
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_2>> PostHospitalAnaliz_2(HospitalAnaliz_2 hospitalAnaliz_2)
        {
            _context.HospitalAnaliz_2.Update(hospitalAnaliz_2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_2", new { id = hospitalAnaliz_2.id }, hospitalAnaliz_2);
        }

        // DELETE: api/HospitalAnaliz_2/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_2>> DeleteHospitalAnaliz_2(long id)
        {
            var hospitalAnaliz_2 = await _context.HospitalAnaliz_2.FindAsync(id);
            if (hospitalAnaliz_2 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_2.Remove(hospitalAnaliz_2);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_2;
        }

        private bool HospitalAnaliz_2Exists(long id)
        {
            return _context.HospitalAnaliz_2.Any(e => e.id == id);
        }
    }
}
