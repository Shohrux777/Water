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
    public class HospitalAnaliz_21Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_21Controller(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_21>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_21
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
            List<HospitalAnaliz_21> itemList = await _context.HospitalAnaliz_21
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_21>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_21.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_21> itemList = await _context.HospitalAnaliz_21
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_21>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_21
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnaliz_21
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_21>>> GetHospitalAnaliz_21()
        {
            return await _context.HospitalAnaliz_21.ToListAsync();
        }

        // GET: api/HospitalAnaliz_21/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_21>> GetHospitalAnaliz_21(long id)
        {
            var hospitalAnaliz_21 = await _context.HospitalAnaliz_21.FindAsync(id);

            if (hospitalAnaliz_21 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_21;
        }

        // PUT: api/HospitalAnaliz_21/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_21(long id, HospitalAnaliz_21 hospitalAnaliz_21)
        {
            if (id != hospitalAnaliz_21.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_21).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_21Exists(id))
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

        // POST: api/HospitalAnaliz_21
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_21>> PostHospitalAnaliz_21(HospitalAnaliz_21 hospitalAnaliz_21)
        {
            _context.HospitalAnaliz_21.Update(hospitalAnaliz_21);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_21", new { id = hospitalAnaliz_21.id }, hospitalAnaliz_21);
        }

        // DELETE: api/HospitalAnaliz_21/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_21>> DeleteHospitalAnaliz_21(long id)
        {
            var hospitalAnaliz_21 = await _context.HospitalAnaliz_21.FindAsync(id);
            if (hospitalAnaliz_21 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_21.Remove(hospitalAnaliz_21);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_21;
        }

        private bool HospitalAnaliz_21Exists(long id)
        {
            return _context.HospitalAnaliz_21.Any(e => e.id == id);
        }
    }
}
