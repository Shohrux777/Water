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
    public class HospitalAnalizNumberMarkController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalAnalizNumberMarkController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalAnalizNumberMark> itemList = await _context.HospitalAnalizNumberMark
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnalizNumberMark>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnalizNumberMark.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalAnalizNumberMark>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalAnalizNumberMark
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
            List<HospitalAnalizNumberMark> itemList = await _context.HospitalAnalizNumberMark
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalAnalizNumberMark>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalAnalizNumberMark
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalAnalizNumberMark
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalAnalizNumberMark>>> GetHospitalAnalizNumberMark()
        {
            return await _context.HospitalAnalizNumberMark.ToListAsync();
        }

        // GET: api/HospitalAnalizNumberMark/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalAnalizNumberMark>> GetHospitalAnalizNumberMark(long id)
        {
            var hospitalAnalizNumberMark = await _context.HospitalAnalizNumberMark
                .Include(p => p.service)
                .Include(p => p.payments)
                .Include(p => p.patients)
                .Where(p =>p.id == id).ToListAsync();

            if (hospitalAnalizNumberMark == null || hospitalAnalizNumberMark.Count  == 0)
            {
                return NotFound();
            }

            return hospitalAnalizNumberMark.First();
        }

        // PUT: api/HospitalAnalizNumberMark/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalAnalizNumberMark(long id, HospitalAnalizNumberMark hospitalAnalizNumberMark)
        {
            if (id != hospitalAnalizNumberMark.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalAnalizNumberMark).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAnalizNumberMarkExists(id))
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

        // POST: api/HospitalAnalizNumberMark
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalAnalizNumberMark>> PostHospitalAnalizNumberMark(HospitalAnalizNumberMark hospitalAnalizNumberMark)
        {
            _context.HospitalAnalizNumberMark.Update(hospitalAnalizNumberMark);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalAnalizNumberMark", new { id = hospitalAnalizNumberMark.id }, hospitalAnalizNumberMark);
        }

        // DELETE: api/HospitalAnalizNumberMark/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalAnalizNumberMark>> DeleteHospitalAnalizNumberMark(long id)
        {
            var hospitalAnalizNumberMark = await _context.HospitalAnalizNumberMark.FindAsync(id);
            if (hospitalAnalizNumberMark == null)
            {
                return NotFound();
            }

            _context.HospitalAnalizNumberMark.Remove(hospitalAnalizNumberMark);
            await _context.SaveChangesAsync();

            return hospitalAnalizNumberMark;
        }

        private bool HospitalAnalizNumberMarkExists(long id)
        {
            return _context.HospitalAnalizNumberMark.Any(e => e.id == id);
        }
    }
}
