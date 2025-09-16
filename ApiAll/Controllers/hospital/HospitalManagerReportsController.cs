using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalManagerReportsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalManagerReportsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalManagerReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalManagerReport>>> GetHospitalManagerReport()
        {
            return await _context.HospitalManagerReport.Include( p =>p.authorization).ThenInclude( a => a.users).ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalManagerReport> itemList = await _context.HospitalManagerReport
                .Include(p => p.authorization)
                .OrderByDescending(p => p.Id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalManagerReport>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalManagerReport.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getHospitalManagerListByAuthIdAndDateForKassir")]
        public async Task<ActionResult<IEnumerable<HospitalManagerReport>>> getHospitalManagerListByAuthIdForKassir([FromQuery] long AuthId,[FromQuery] DateTime dateTimeCur)
        {
            return await _context.HospitalManagerReport.Where( p => p.AuthorizationId == AuthId && p.createdDateTime == dateTimeCur).Include(p => p.authorization).ThenInclude(a => a.users).ToListAsync();
        }

        [HttpGet("getHospitalManagerListByDateForAdmin")]
        public async Task<ActionResult<IEnumerable<HospitalManagerReport>>> getHospitalManagerListByDateForAdmin( [FromQuery] DateTime dateTimeCur)
        {
            return await _context.HospitalManagerReport.Where(p => p.createdDateTime == dateTimeCur).Include( p=>p.authorization).ThenInclude(a => a.users).ToListAsync();
        }

        // GET: api/HospitalManagerReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalManagerReport>> GetHospitalManagerReport(long id)
        {
            var hospitalManagerReport = await _context.HospitalManagerReport.FindAsync(id);

            if (hospitalManagerReport == null)
            {
                return NotFound();
            }

            return hospitalManagerReport;
        }

        // PUT: api/HospitalManagerReports/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalManagerReport(long id, HospitalManagerReport hospitalManagerReport)
        {
            if (id != hospitalManagerReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalManagerReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalManagerReportExists(id))
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

        // POST: api/HospitalManagerReports
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalManagerReport>> PostHospitalManagerReport(HospitalManagerReport hospitalManagerReport)
        {
            _context.HospitalManagerReport.Update(hospitalManagerReport);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetHospitalManagerReport", new { id = hospitalManagerReport.Id }, hospitalManagerReport);
        }

        // DELETE: api/HospitalManagerReports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalManagerReport>> DeleteHospitalManagerReport(long id)
        {
            var hospitalManagerReport = await _context.HospitalManagerReport.FindAsync(id);
            if (hospitalManagerReport == null)
            {
                return NotFound();
            }

            _context.HospitalManagerReport.Remove(hospitalManagerReport);
            await _context.SaveChangesAsync();

            return hospitalManagerReport;
        }

        private bool HospitalManagerReportExists(long id)
        {
            return _context.HospitalManagerReport.Any(e => e.Id == id);
        }
    }
}
