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
    public class HospitalAnaliz_36Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_36Controller(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_36>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_36
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
            List<HospitalAnaliz_36> itemList = await _context.HospitalAnaliz_36
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_36>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_36.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_36> itemList = await _context.HospitalAnaliz_36
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_36>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_36
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // GET: api/HospitalAnaliz_36
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_36>>> GetHospitalAnaliz_36()
        {
            return await _context.HospitalAnaliz_36.ToListAsync();
        }

        // GET: api/HospitalAnaliz_36/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_36>> GetHospitalAnaliz_36(long id)
        {
            var hospitalAnaliz_36 = await _context.HospitalAnaliz_36.FindAsync(id);

            if (hospitalAnaliz_36 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_36;
        }

        // PUT: api/HospitalAnaliz_36/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_36(long id, HospitalAnaliz_36 hospitalAnaliz_36)
        {
            if (id != hospitalAnaliz_36.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_36).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_36Exists(id))
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

        // POST: api/HospitalAnaliz_36
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_36>> PostHospitalAnaliz_36(HospitalAnaliz_36 hospitalAnaliz_36)
        {
            _context.HospitalAnaliz_36.Update(hospitalAnaliz_36);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_36", new { id = hospitalAnaliz_36.id }, hospitalAnaliz_36);
        }

        // DELETE: api/HospitalAnaliz_36/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_36>> DeleteHospitalAnaliz_36(long id)
        {
            var hospitalAnaliz_36 = await _context.HospitalAnaliz_36.FindAsync(id);
            if (hospitalAnaliz_36 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_36.Remove(hospitalAnaliz_36);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_36;
        }

        private bool HospitalAnaliz_36Exists(long id)
        {
            return _context.HospitalAnaliz_36.Any(e => e.id == id);
        }
    }
}
