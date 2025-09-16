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
    public class HospitalAnaliz_33Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_33Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_33
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_33>>> GetHospitalAnaliz_33()
        {
            return await _context.HospitalAnaliz_33.ToListAsync();
        }

        // GET: api/HospitalAnaliz_33/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_33>> GetHospitalAnaliz_33(long id)
        {
            var hospitalAnaliz_33 = await _context.HospitalAnaliz_33.FindAsync(id);

            if (hospitalAnaliz_33 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_33;
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_33>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_33
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
            List<HospitalAnaliz_33> itemList = await _context.HospitalAnaliz_33
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_33>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_33.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_33> itemList = await _context.HospitalAnaliz_33
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_33>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_33
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/HospitalAnaliz_33/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_33(long id, HospitalAnaliz_33 hospitalAnaliz_33)
        {
            if (id != hospitalAnaliz_33.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_33).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_33Exists(id))
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

        // POST: api/HospitalAnaliz_33
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_33>> PostHospitalAnaliz_33(HospitalAnaliz_33 hospitalAnaliz_33)
        {
            _context.HospitalAnaliz_33.Update(hospitalAnaliz_33);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_33", new { id = hospitalAnaliz_33.id }, hospitalAnaliz_33);
        }

        // DELETE: api/HospitalAnaliz_33/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_33>> DeleteHospitalAnaliz_33(long id)
        {
            var hospitalAnaliz_33 = await _context.HospitalAnaliz_33.FindAsync(id);
            if (hospitalAnaliz_33 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_33.Remove(hospitalAnaliz_33);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_33;
        }

        private bool HospitalAnaliz_33Exists(long id)
        {
            return _context.HospitalAnaliz_33.Any(e => e.id == id);
        }
    }
}
