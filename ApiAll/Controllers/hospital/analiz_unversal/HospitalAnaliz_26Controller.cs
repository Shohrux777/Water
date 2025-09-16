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
    public class HospitalAnaliz_26Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_26Controller(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_26>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_26
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
            List<HospitalAnaliz_26> itemList = await _context.HospitalAnaliz_26
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_26>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_26.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_26> itemList = await _context.HospitalAnaliz_26
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_26>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_26
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_26
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_26>>> GetHospitalAnaliz_26()
        {
            return await _context.HospitalAnaliz_26.ToListAsync();
        }

        // GET: api/HospitalAnaliz_26/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_26>> GetHospitalAnaliz_26(long id)
        {
            var hospitalAnaliz_26 = await _context.HospitalAnaliz_26.FindAsync(id);

            if (hospitalAnaliz_26 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_26;
        }

        // PUT: api/HospitalAnaliz_26/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_26(long id, HospitalAnaliz_26 hospitalAnaliz_26)
        {
            if (id != hospitalAnaliz_26.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_26).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_26Exists(id))
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

        // POST: api/HospitalAnaliz_26
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_26>> PostHospitalAnaliz_26(HospitalAnaliz_26 hospitalAnaliz_26)
        {
            _context.HospitalAnaliz_26.Update(hospitalAnaliz_26);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_26", new { id = hospitalAnaliz_26.id }, hospitalAnaliz_26);
        }

        // DELETE: api/HospitalAnaliz_26/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_26>> DeleteHospitalAnaliz_26(long id)
        {
            var hospitalAnaliz_26 = await _context.HospitalAnaliz_26.FindAsync(id);
            if (hospitalAnaliz_26 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_26.Remove(hospitalAnaliz_26);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_26;
        }

        private bool HospitalAnaliz_26Exists(long id)
        {
            return _context.HospitalAnaliz_26.Any(e => e.id == id);
        }
    }
}
