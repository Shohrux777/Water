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
    public class HospitalAnaliz_43Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_43Controller(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_43>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_43
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
            List<HospitalAnaliz_43> itemList = await _context.HospitalAnaliz_43
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_43>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_43.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_43> itemList = await _context.HospitalAnaliz_43
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_43>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_43
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // GET: api/HospitalAnaliz_43
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_43>>> GetHospitalAnaliz_43()
        {
            return await _context.HospitalAnaliz_43.ToListAsync();
        }

        // GET: api/HospitalAnaliz_43/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_43>> GetHospitalAnaliz_43(long id)
        {
            var hospitalAnaliz_43 = await _context.HospitalAnaliz_43.FindAsync(id);

            if (hospitalAnaliz_43 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_43;
        }

        // PUT: api/HospitalAnaliz_43/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_43(long id, HospitalAnaliz_43 hospitalAnaliz_43)
        {
            if (id != hospitalAnaliz_43.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_43).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_43Exists(id))
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

        // POST: api/HospitalAnaliz_43
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_43>> PostHospitalAnaliz_43(HospitalAnaliz_43 hospitalAnaliz_43)
        {
            _context.HospitalAnaliz_43.Update(hospitalAnaliz_43);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_43", new { id = hospitalAnaliz_43.id }, hospitalAnaliz_43);
        }

        // DELETE: api/HospitalAnaliz_43/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_43>> DeleteHospitalAnaliz_43(long id)
        {
            var hospitalAnaliz_43 = await _context.HospitalAnaliz_43.FindAsync(id);
            if (hospitalAnaliz_43 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_43.Remove(hospitalAnaliz_43);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_43;
        }

        private bool HospitalAnaliz_43Exists(long id)
        {
            return _context.HospitalAnaliz_43.Any(e => e.id == id);
        }
    }
}
