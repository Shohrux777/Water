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

namespace ApiAll.Controllers.hospital
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalAnalizSpermaController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnalizSpermaController(ApplicationContext context)
        {
            _context = context;
        }



        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnalizSperma> itemList = await _context.HospitalAnalizSperma
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnalizSperma>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnalizSperma.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnalizSperma>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnalizSperma
                .Include(p => p.patients)
                .Where(p => p.id == id).ToListAsync();

            if (item == null || item.Count() == 0)
            {
                return NotFound();
            }

            return item.First();
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnalizSperma> itemList = await _context.HospitalAnalizSperma
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnalizSperma>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnalizSperma
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnalizSperma
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnalizSperma>>> GetHospitalAnalizSperma()
        {
            return await _context.HospitalAnalizSperma.ToListAsync();
        }

        // GET: api/HospitalAnalizSperma/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnalizSperma>> GetHospitalAnalizSperma(long id)
        {
            var hospitalAnalizSperma = await _context.HospitalAnalizSperma.FindAsync(id);

            if (hospitalAnalizSperma == null)
            {
                return NotFound();
            }

            return hospitalAnalizSperma;
        }

        // PUT: api/HospitalAnalizSperma/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnalizSperma(long id, HospitalAnalizSperma hospitalAnalizSperma)
        {
            if (id != hospitalAnalizSperma.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnalizSperma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnalizSpermaExists(id))
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

        // POST: api/HospitalAnalizSperma
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnalizSperma>> PostHospitalAnalizSperma(HospitalAnalizSperma hospitalAnalizSperma)
        {
            _context.HospitalAnalizSperma.Update(hospitalAnalizSperma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnalizSperma", new { id = hospitalAnalizSperma.id }, hospitalAnalizSperma);
        }

        // DELETE: api/HospitalAnalizSperma/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnalizSperma>> DeleteHospitalAnalizSperma(long id)
        {
            var hospitalAnalizSperma = await _context.HospitalAnalizSperma.FindAsync(id);
            if (hospitalAnalizSperma == null)
            {
                return NotFound();
            }

            _context.HospitalAnalizSperma.Remove(hospitalAnalizSperma);
            await _context.SaveChangesAsync();

            return hospitalAnalizSperma;
        }

        private bool HospitalAnalizSpermaExists(long id)
        {
            return _context.HospitalAnalizSperma.Any(e => e.id == id);
        }
    }
}
