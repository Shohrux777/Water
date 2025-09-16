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
    public class HospitalAnaliz_22Controller : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnaliz_22Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnaliz_22
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnaliz_22>>> GetHospitalAnaliz_22()
        {
            return await _context.HospitalAnaliz_22.ToListAsync();
        }
        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnaliz_22>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnaliz_22
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
            List<HospitalAnaliz_22> itemList = await _context.HospitalAnaliz_22
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_22>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_22.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnaliz_22> itemList = await _context.HospitalAnaliz_22
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnaliz_22>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnaliz_22
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // GET: api/HospitalAnaliz_22/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnaliz_22>> GetHospitalAnaliz_22(long id)
        {
            var hospitalAnaliz_22 = await _context.HospitalAnaliz_22.FindAsync(id);

            if (hospitalAnaliz_22 == null)
            {
                return NotFound();
            }

            return hospitalAnaliz_22;
        }

        // PUT: api/HospitalAnaliz_22/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnaliz_22(long id, HospitalAnaliz_22 hospitalAnaliz_22)
        {
            if (id != hospitalAnaliz_22.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnaliz_22).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnaliz_22Exists(id))
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

        // POST: api/HospitalAnaliz_22
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnaliz_22>> PostHospitalAnaliz_22(HospitalAnaliz_22 hospitalAnaliz_22)
        {
            _context.HospitalAnaliz_22.Update(hospitalAnaliz_22);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnaliz_22", new { id = hospitalAnaliz_22.id }, hospitalAnaliz_22);
        }

        // DELETE: api/HospitalAnaliz_22/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnaliz_22>> DeleteHospitalAnaliz_22(long id)
        {
            var hospitalAnaliz_22 = await _context.HospitalAnaliz_22.FindAsync(id);
            if (hospitalAnaliz_22 == null)
            {
                return NotFound();
            }

            _context.HospitalAnaliz_22.Remove(hospitalAnaliz_22);
            await _context.SaveChangesAsync();

            return hospitalAnaliz_22;
        }

        private bool HospitalAnaliz_22Exists(long id)
        {
            return _context.HospitalAnaliz_22.Any(e => e.id == id);
        }
    }
}
