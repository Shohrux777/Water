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
    public class HospitalAnaliz_23Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_23Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_23
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_23>>> GetHospitalAnaliz_23()
        {
            return await _context.HospitalAnaliz_23.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_23>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_23
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
            List<HospitalAnaliz_23> itemList = await _context.HospitalAnaliz_23
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_23>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_23.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_23> itemList = await _context.HospitalAnaliz_23
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_23>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_23
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_23/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_23>> GetHospitalAnaliz_23(long id)
        {
            var hospitalAnaliz_23 = await _context.HospitalAnaliz_23.FindAsync(id);

            if (hospitalAnaliz_23 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_23;
        }

        // PUT: api/HospitalAnaliz_23/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_23(long id, HospitalAnaliz_23 hospitalAnaliz_23)
        {
            if (id != hospitalAnaliz_23.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_23).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_23Exists(id))
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

        // POST: api/HospitalAnaliz_23
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_23>> PostHospitalAnaliz_23(HospitalAnaliz_23 hospitalAnaliz_23)
        {
            _context.HospitalAnaliz_23.Update(hospitalAnaliz_23);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_23", new { id = hospitalAnaliz_23.id }, hospitalAnaliz_23);
        }

        // DELETE: api/HospitalAnaliz_23/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_23>> DeleteHospitalAnaliz_23(long id)
        {
            var hospitalAnaliz_23 = await _context.HospitalAnaliz_23.FindAsync(id);
            if (hospitalAnaliz_23 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_23.Remove(hospitalAnaliz_23);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_23;
        }

        private bool HospitalAnaliz_23Exists(long id)
        {
            return _context.HospitalAnaliz_23.Any(e => e.id == id);
        }
    }
}
