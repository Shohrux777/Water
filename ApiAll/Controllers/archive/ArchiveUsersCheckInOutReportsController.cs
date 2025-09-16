using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.archive;

namespace ApiAll.Controllers.archive
{
    [ApiExplorerSettings(GroupName = "v6")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArchiveUsersCheckInOutReportsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ArchiveUsersCheckInOutReportsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ArchiveUsersCheckInOutReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveUsersCheckInOutReport>>> GetArchiveUsersCheckInOutReport()
        {
            return await _context.ArchiveUsersCheckInOutReport.ToListAsync();
        }

        [HttpGet("getCheckInOutListByDeviceIdAndDates")]
        public async Task<ActionResult<IEnumerable<ArchiveUsersCheckInOutReport>>> getCheckInOutListByDeviceIdAndDates([FromQuery] long device_id,[FromQuery] DateTime b_date,[FromQuery] DateTime e_date)
        {
            List<ArchiveUsersCheckInOutReport> archiveUsersCheckInOutReportList = new List<ArchiveUsersCheckInOutReport>();
            archiveUsersCheckInOutReportList =  await _context.ArchiveUsersCheckInOutReport.Where(p => p.date_time >= b_date && p.date_time <= e_date).Where(p => p.device_id == device_id).OrderByDescending(p => p.id).ToListAsync();
            if (archiveUsersCheckInOutReportList != null && archiveUsersCheckInOutReportList.Count > 0) {
                foreach (ArchiveUsersCheckInOutReport item in archiveUsersCheckInOutReportList) {
                    List<ArchiveUser> archiveUserList = await _context.ArchiveUser.Where(p => p.emp_number == item.emp_number).ToListAsync();
                    if (archiveUserList != null && archiveUserList.Count > 0) {
                        item.user_name = archiveUserList.First().fio;
                    }
                }
            }
            return archiveUsersCheckInOutReportList;
        }

        [HttpGet("getNotComeToWorkListByDateTimeAndDepartmentId")]
        public async Task<ActionResult<IEnumerable<ArchiveUser>>> getNotComeToWorkListByDateTimeAndDepartmentId([FromQuery] long department_id, [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            List<ArchiveUsersCheckInOutReport> archiveUsersCheckInOutReportList = new List<ArchiveUsersCheckInOutReport>();
            archiveUsersCheckInOutReportList = await _context.ArchiveUsersCheckInOutReport.Where(p => p.date_time >= b_date && p.date_time <= e_date).OrderByDescending(p => p.id).ToListAsync();
            List<int> empNumberList = new List<int>();
            
            if (archiveUsersCheckInOutReportList != null && archiveUsersCheckInOutReportList.Count > 0)
            {
                archiveUsersCheckInOutReportList.GroupBy(p => p.emp_number);
                foreach (ArchiveUsersCheckInOutReport item in archiveUsersCheckInOutReportList)
                {
                    empNumberList.Add(item.emp_number);
                }
            }
            if (department_id == 0)
            {
                return await _context.ArchiveUser.Where(p => !empNumberList.Contains(p.emp_number)).Include(p => p.department).ToListAsync();
            }
            else
            {
                return await _context.ArchiveUser.Where(p => p.ArchiveDepartmentid == department_id).Where(p => !empNumberList.Contains(p.emp_number)).Include(p => p.department).ToListAsync();
            }
            
        }

        [HttpGet("getWorkingHoursListByDateTimeAndDepartmentId")]
        public async Task<ActionResult<IEnumerable<ArchiveUser>>> getWorkingHoursListByDateTimeAndDepartmentId([FromQuery] long department_id, [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            List<ArchiveUser> userList = new List<ArchiveUser>();

            if (department_id == 0)
            {
                userList =  await _context.ArchiveUser.Include(p => p.department).ToListAsync();
            }
            else
            {
                userList =  await _context.ArchiveUser.Where(p => p.ArchiveDepartmentid == department_id).Include(p => p.department).ToListAsync();
            }

            //Date time listi
            List<DateTime> dateList = new List<DateTime>();
            for (var dt = b_date; dt <= e_date; dt = dt.AddDays(1)){
                dateList.Add(dt);
            }
            List<ArchiveUser> user_list = new List<ArchiveUser>();
            foreach (DateTime d_time in dateList) {
                foreach (ArchiveUser item in userList) {
                    ArchiveUser user = new ArchiveUser();
                    user.fio = item.fio;
                    user.department = item.department;
                    user.checked_date_str = d_time.ToString("yyyy-MM-dd");
          
                    List<ArchiveWorkingTime> listWorkingTime = await _context.ArchiveWorkingTime.FromSqlRaw("select working_time_without_gr("+item.emp_number+",'"+ d_time.ToString("yyyy-MM-dd") + "');").ToListAsync();
                    if (listWorkingTime!= null && listWorkingTime.Count > 0) {
                        user.working_time = listWorkingTime.First().working_time_without_gr != null ? listWorkingTime.First().working_time_without_gr : TimeSpan.Parse("00:00"); ;
                    }
                    user_list.Add(user);
                }

            }



            return user_list;

        }

        // GET: api/ArchiveUsersCheckInOutReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchiveUsersCheckInOutReport>> GetArchiveUsersCheckInOutReport(long id)
        {
            var archiveUsersCheckInOutReport = await _context.ArchiveUsersCheckInOutReport.FindAsync(id);

            if (archiveUsersCheckInOutReport == null)
            {
                return NotFound();
            }

            return archiveUsersCheckInOutReport;
        }

        // PUT: api/ArchiveUsersCheckInOutReports/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchiveUsersCheckInOutReport(long id, ArchiveUsersCheckInOutReport archiveUsersCheckInOutReport)
        {
            if (id != archiveUsersCheckInOutReport.id)
            {
                return BadRequest();
            }

            _context.Entry(archiveUsersCheckInOutReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveUsersCheckInOutReportExists(id))
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

        // POST: api/ArchiveUsersCheckInOutReports
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArchiveUsersCheckInOutReport>> PostArchiveUsersCheckInOutReport(ArchiveUsersCheckInOutReport archiveUsersCheckInOutReport)
        {
            _context.ArchiveUsersCheckInOutReport.Add(archiveUsersCheckInOutReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArchiveUsersCheckInOutReport", new { id = archiveUsersCheckInOutReport.id }, archiveUsersCheckInOutReport);
        }

        // DELETE: api/ArchiveUsersCheckInOutReports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchiveUsersCheckInOutReport>> DeleteArchiveUsersCheckInOutReport(long id)
        {
            var archiveUsersCheckInOutReport = await _context.ArchiveUsersCheckInOutReport.FindAsync(id);
            if (archiveUsersCheckInOutReport == null)
            {
                return NotFound();
            }

            _context.ArchiveUsersCheckInOutReport.Remove(archiveUsersCheckInOutReport);
            await _context.SaveChangesAsync();

            return archiveUsersCheckInOutReport;
        }

        private bool ArchiveUsersCheckInOutReportExists(long id)
        {
            return _context.ArchiveUsersCheckInOutReport.Any(e => e.id == id);
        }
    }
}
