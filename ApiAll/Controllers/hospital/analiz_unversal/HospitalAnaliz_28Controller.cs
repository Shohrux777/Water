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
    public class HospitalAnaliz_28Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_28Controller(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_28>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_28
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
            List<HospitalAnaliz_28> itemList = await _context.HospitalAnaliz_28
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_28>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_28.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_28> itemList = await _context.HospitalAnaliz_28
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_28>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_28
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_28
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_28>>> GetHospitalAnaliz_28()
        {
            return await _context.HospitalAnaliz_28.ToListAsync();
        }

        // GET: api/HospitalAnaliz_28/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_28>> GetHospitalAnaliz_28(long id)
        {
            var hospitalAnaliz_28 = await _context.HospitalAnaliz_28.FindAsync(id);

            if (hospitalAnaliz_28 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_28;
        }

        // PUT: api/HospitalAnaliz_28/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_28(long id, HospitalAnaliz_28 hospitalAnaliz_28)
        {
            if (id != hospitalAnaliz_28.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_28).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_28Exists(id))
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

        // POST: api/HospitalAnaliz_28
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_28>> PostHospitalAnaliz_28(HospitalAnaliz_28 hospitalAnaliz_28)
        {
            _context.HospitalAnaliz_28.Update(hospitalAnaliz_28);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_28", new { id = hospitalAnaliz_28.id }, hospitalAnaliz_28);
        }

        // DELETE: api/HospitalAnaliz_28/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_28>> DeleteHospitalAnaliz_28(long id)
        {
            var hospitalAnaliz_28 = await _context.HospitalAnaliz_28.FindAsync(id);
            if (hospitalAnaliz_28 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_28.Remove(hospitalAnaliz_28);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_28;
        }

        private bool HospitalAnaliz_28Exists(long id)
        {
            return _context.HospitalAnaliz_28.Any(e => e.id == id);
        }
    }
}
