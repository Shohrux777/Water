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
    public class HospitalAnaliz_11Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_11Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_11
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_11>>> GetHospitalAnaliz_11()
        {
            return await _context.HospitalAnaliz_11.ToListAsync();
        }
        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_11>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_11
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
            List<HospitalAnaliz_11> itemList = await _context.HospitalAnaliz_11
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_11>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_11.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_11> itemList = await _context.HospitalAnaliz_11
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_11>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_11
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_11/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_11>> GetHospitalAnaliz_11(long id)
        {
            var hospitalAnaliz_11 = await _context.HospitalAnaliz_11.FindAsync(id);

            if (hospitalAnaliz_11 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_11;
        }

        // PUT: api/HospitalAnaliz_11/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_11(long id, HospitalAnaliz_11 hospitalAnaliz_11)
        {
            if (id != hospitalAnaliz_11.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_11).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_11Exists(id))
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

        // POST: api/HospitalAnaliz_11
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_11>> PostHospitalAnaliz_11(HospitalAnaliz_11 hospitalAnaliz_11)
        {
            _context.HospitalAnaliz_11.Update(hospitalAnaliz_11);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_11", new { id = hospitalAnaliz_11.id }, hospitalAnaliz_11);
        }

        // DELETE: api/HospitalAnaliz_11/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_11>> DeleteHospitalAnaliz_11(long id)
        {
            var hospitalAnaliz_11 = await _context.HospitalAnaliz_11.FindAsync(id);
            if (hospitalAnaliz_11 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_11.Remove(hospitalAnaliz_11);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_11;
        }

        private bool HospitalAnaliz_11Exists(long id)
        {
            return _context.HospitalAnaliz_11.Any(e => e.id == id);
        }
    }
}
