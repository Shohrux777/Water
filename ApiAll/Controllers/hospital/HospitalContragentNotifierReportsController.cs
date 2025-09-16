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
    public class HospitalContragentNotifierReportsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalContragentNotifierReportsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalContragentNotifierReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalContragentNotifierReport>>> GetHospitalContragentNotifierReport()
        {
            return await _context.HospitalContragentNotifierReport.Include( p => p.contragent).ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalContragentNotifierReport> itemList = await _context.HospitalContragentNotifierReport
                .Include(p => p.contragent)
                .OrderByDescending(p => p.Id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalContragentNotifierReport>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalContragentNotifierReport.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalContragentNotifierReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalContragentNotifierReport>> GetHospitalContragentNotifierReport(long id)
        {
            var hospitalContragentNotifierReport = await _context.HospitalContragentNotifierReport.FindAsync(id);

            if (hospitalContragentNotifierReport == null)
            {
                return NotFound();
            }

            return hospitalContragentNotifierReport;
        }

        // PUT: api/HospitalContragentNotifierReports/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalContragentNotifierReport(long id, HospitalContragentNotifierReport hospitalContragentNotifierReport)
        {
            if (id != hospitalContragentNotifierReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalContragentNotifierReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalContragentNotifierReportExists(id))
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

        // POST: api/HospitalContragentNotifierReports
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalContragentNotifierReport>> PostHospitalContragentNotifierReport(HospitalContragentNotifierReport hospitalContragentNotifierReport)
        {
            _context.HospitalContragentNotifierReport.Update(hospitalContragentNotifierReport);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetHospitalContragentNotifierReport", new { id = hospitalContragentNotifierReport.Id }, hospitalContragentNotifierReport);
        }

        // DELETE: api/HospitalContragentNotifierReports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalContragentNotifierReport>> DeleteHospitalContragentNotifierReport(long id)
        {
            var hospitalContragentNotifierReport = await _context.HospitalContragentNotifierReport.FindAsync(id);
            if (hospitalContragentNotifierReport == null)
            {
                return NotFound();
            }

            _context.HospitalContragentNotifierReport.Remove(hospitalContragentNotifierReport);
            await _context.SaveChangesAsync();

            return hospitalContragentNotifierReport;
        }

        private bool HospitalContragentNotifierReportExists(long id)
        {
            return _context.HospitalContragentNotifierReport.Any(e => e.Id == id);
        }
    }
}
