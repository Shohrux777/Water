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
    public class HospitalAnaliz_38Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_38Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_38
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_38>>> GetHospitalAnaliz_38()
        {
            return await _context.HospitalAnaliz_38.ToListAsync();
        }

        // GET: api/HospitalAnaliz_38/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_38>> GetHospitalAnaliz_38(long id)
        {
            var hospitalAnaliz_38 = await _context.HospitalAnaliz_38.FindAsync(id);

            if (hospitalAnaliz_38 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_38;
        }

        // PUT: api/HospitalAnaliz_38/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_38(long id, HospitalAnaliz_38 hospitalAnaliz_38)
        {
            if (id != hospitalAnaliz_38.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_38).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_38Exists(id))
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
        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_38>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_38
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
            List<HospitalAnaliz_38> itemList = await _context.HospitalAnaliz_38
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_38>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_38.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_38> itemList = await _context.HospitalAnaliz_38
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_38>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_38
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // POST: api/HospitalAnaliz_38
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_38>> PostHospitalAnaliz_38(HospitalAnaliz_38 hospitalAnaliz_38)
        {
            _context.HospitalAnaliz_38.Update(hospitalAnaliz_38);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_38", new { id = hospitalAnaliz_38.id }, hospitalAnaliz_38);
        }

        // DELETE: api/HospitalAnaliz_38/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_38>> DeleteHospitalAnaliz_38(long id)
        {
            var hospitalAnaliz_38 = await _context.HospitalAnaliz_38.FindAsync(id);
            if (hospitalAnaliz_38 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_38.Remove(hospitalAnaliz_38);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_38;
        }

        private bool HospitalAnaliz_38Exists(long id)
        {
            return _context.HospitalAnaliz_38.Any(e => e.id == id);
        }
    }
}
