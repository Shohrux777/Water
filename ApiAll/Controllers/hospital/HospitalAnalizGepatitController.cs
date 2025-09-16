using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.hospital
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalAnalizGepatitController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnalizGepatitController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalAnalizGepatit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnalizGepatit>>> GetHospitalAnalizGepatit()
        {
            return await _context.HospitalAnalizGepatit.ToListAsync();
        }

        // GET: api/HospitalAnalizGepatit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnalizGepatit>> GetHospitalAnalizGepatit(long id)
        {
            var hospitalAnalizGepatit = await _context.HospitalAnalizGepatit.FindAsync(id);

            if (hospitalAnalizGepatit == null)
            {
                return NotFound();
            }

            return hospitalAnalizGepatit;
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnalizGepatit>> getFullInfoById([FromQuery]long id)
        {
            var item = await _context
                .HospitalAnalizGepatit
                .Include(p=>p.patients)
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
            List<HospitalAnalizGepatit> itemList = await _context.HospitalAnalizGepatit
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnalizGepatit>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnalizGepatit.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnalizGepatit> itemList = await _context.HospitalAnalizGepatit
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnalizGepatit>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnalizGepatit
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/HospitalAnalizGepatit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnalizGepatit(long id, HospitalAnalizGepatit hospitalAnalizGepatit)
        {
            if (id != hospitalAnalizGepatit.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnalizGepatit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnalizGepatitExists(id))
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

        // POST: api/HospitalAnalizGepatit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnalizGepatit>> PostHospitalAnalizGepatit(HospitalAnalizGepatit hospitalAnalizGepatit)
        {
            _context.HospitalAnalizGepatit.Update(hospitalAnalizGepatit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnalizGepatit", new { id = hospitalAnalizGepatit.id }, hospitalAnalizGepatit);
        }

        // DELETE: api/HospitalAnalizGepatit/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnalizGepatit>> DeleteHospitalAnalizGepatit(long id)
        {
            var hospitalAnalizGepatit = await _context.HospitalAnalizGepatit.FindAsync(id);
            if (hospitalAnalizGepatit == null)
            {
                return NotFound();
            }

            _context.HospitalAnalizGepatit.Remove(hospitalAnalizGepatit);
            await _context.SaveChangesAsync();

            return hospitalAnalizGepatit;
        }

        private bool HospitalAnalizGepatitExists(long id)
        {
            return _context.HospitalAnalizGepatit.Any(e => e.id == id);
        }
    }
}
