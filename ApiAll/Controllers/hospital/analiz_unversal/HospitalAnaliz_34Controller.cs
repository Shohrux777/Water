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
    public class HospitalAnaliz_34Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_34Controller(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_34>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_34
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
            List<HospitalAnaliz_34> itemList = await _context.HospitalAnaliz_34
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_34>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_34.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_34> itemList = await _context.HospitalAnaliz_34
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_34>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_34
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_34
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_34>>> GetHospitalAnaliz_34()
        {
            return await _context.HospitalAnaliz_34.ToListAsync();
        }

        // GET: api/HospitalAnaliz_34/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_34>> GetHospitalAnaliz_34(long id)
        {
            var hospitalAnaliz_34 = await _context.HospitalAnaliz_34.FindAsync(id);

            if (hospitalAnaliz_34 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_34;
        }

        // PUT: api/HospitalAnaliz_34/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_34(long id, HospitalAnaliz_34 hospitalAnaliz_34)
        {
            if (id != hospitalAnaliz_34.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_34).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_34Exists(id))
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

        // POST: api/HospitalAnaliz_34
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_34>> PostHospitalAnaliz_34(HospitalAnaliz_34 hospitalAnaliz_34)
        {
            _context.HospitalAnaliz_34.Update(hospitalAnaliz_34);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_34", new { id = hospitalAnaliz_34.id }, hospitalAnaliz_34);
        }

        // DELETE: api/HospitalAnaliz_34/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_34>> DeleteHospitalAnaliz_34(long id)
        {
            var hospitalAnaliz_34 = await _context.HospitalAnaliz_34.FindAsync(id);
            if (hospitalAnaliz_34 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_34.Remove(hospitalAnaliz_34);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_34;
        }

        private bool HospitalAnaliz_34Exists(long id)
        {
            return _context.HospitalAnaliz_34.Any(e => e.id == id);
        }
    }
}
