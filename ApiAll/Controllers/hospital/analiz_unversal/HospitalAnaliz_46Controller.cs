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
    public class HospitalAnaliz_46Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_46Controller(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_46>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_46
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
            List<HospitalAnaliz_46> itemList = await _context.HospitalAnaliz_46
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_46>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_46.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_46> itemList = await _context.HospitalAnaliz_46
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_46>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_46
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // GET: api/HospitalAnaliz_46
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_46>>> GetHospitalAnaliz_46()
        {
            return await _context.HospitalAnaliz_46.ToListAsync();
        }

        // GET: api/HospitalAnaliz_46/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_46>> GetHospitalAnaliz_46(long id)
        {
            var hospitalAnaliz_46 = await _context.HospitalAnaliz_46.FindAsync(id);

            if (hospitalAnaliz_46 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_46;
        }

        // PUT: api/HospitalAnaliz_46/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_46(long id, HospitalAnaliz_46 hospitalAnaliz_46)
        {
            if (id != hospitalAnaliz_46.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_46).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_46Exists(id))
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

        // POST: api/HospitalAnaliz_46
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_46>> PostHospitalAnaliz_46(HospitalAnaliz_46 hospitalAnaliz_46)
        {
            _context.HospitalAnaliz_46.Update(hospitalAnaliz_46);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_46", new { id = hospitalAnaliz_46.id }, hospitalAnaliz_46);
        }

        // DELETE: api/HospitalAnaliz_46/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_46>> DeleteHospitalAnaliz_46(long id)
        {
            var hospitalAnaliz_46 = await _context.HospitalAnaliz_46.FindAsync(id);
            if (hospitalAnaliz_46 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_46.Remove(hospitalAnaliz_46);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_46;
        }

        private bool HospitalAnaliz_46Exists(long id)
        {
            return _context.HospitalAnaliz_46.Any(e => e.id == id);
        }
    }
}
