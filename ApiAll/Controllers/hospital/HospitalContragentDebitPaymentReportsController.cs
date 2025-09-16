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
    public class HospitalContragentDebitPaymentReportsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalContragentDebitPaymentReportsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalContragentDebitPaymentReport>>> GetHospitalContragentDebitPaymentReport()
        {
            return await _context.HospitalContragentDebitPaymentReport.ToListAsync();
        }


        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalContragentDebitPaymentReport> itemList = await _context.HospitalContragentDebitPaymentReport
                .Include(p => p.contragent)
                .Include(p => p.districts)
                .OrderByDescending(p => p.Id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalContragentDebitPaymentReport>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalContragentDebitPaymentReport.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpPost("getContragentCustomReportForMoney")]
        public async Task<ActionResult<IEnumerable<CustomContragentReport>>> getContragentCustomReportForMoney(ReportContragentsMoney contragentsMoney)
        {
            try
            {
                String beginDateStr = contragentsMoney.beginDate.ToString("yyyy-MM-dd");
                String endDateStr = contragentsMoney.endDate.ToString("yyyy-MM-dd");
                var result = await _context.customContragentReports.FromSqlRaw("select h.\"contragentName\" as fio, h.\"contragentPhoneNumber\" as phone, h.\"createdDate\" as datereg," +
                    "(select count(*) from \"HospitalContragentDebitPaymentReport\" where h.\"createdDate\" = \"createdDate\"and \"serviceGroupName\" = 'MRT' and  h.\"contragentId\" = \"contragentId\") as mrt," +
                    "(select count(*) from \"HospitalContragentDebitPaymentReport\" where h.\"createdDate\" = \"createdDate\"and \"serviceGroupName\" = 'MSKT' and  h.\"contragentId\" = \"contragentId\") as mskt," +
                    "(select sum(summa) from \"HospitalContragentDebitPaymentReport\" where h.\"createdDate\" = \"createdDate\"and   h.\"contragentId\" = \"contragentId\" and  (\"serviceGroupName\" = 'MRT' or \"serviceGroupName\" = 'MSKT' )),h.\"regionName\",h.\"contragentId\" from \"HospitalContragentDebitPaymentReport\" h where h.\"districtsId\" = " + contragentsMoney.districtId+" and ( h.\"createdDate\" between '" + beginDateStr + "' and '" + endDateStr + "' )  and (\"serviceGroupName\" = 'MRT' or \"serviceGroupName\" = 'MSKT' ) group by h.\"createdDate\",h.\"contragentName\",h.\"contragentPhoneNumber\",h.\"contragentId\",h.\"regionName\"; ").ToListAsync();

                String nameContragent = "";
                if (result != null && result.Count > 0)
                {
                    foreach (CustomContragentReport item in result)
                    {
                        item.creditSumm = 0;
                        item.debitSumm = 0;
                        item.payedSumm = 0;
                        item.finishStatus = false;
                        if (String.Equals(nameContragent, item.fio))
                        {
                            item.fio = String.Empty;
                            item.phone = String.Empty;
                        }
                        else
                        {
                            nameContragent = item.fio;
                        }
                    }
                }

                return result;
            }
            catch(Exception ) {
                return new List<CustomContragentReport>();
            }

        }


        [HttpPost("getContragentCustomReportForMoneyUziAndLabaratoriya")]
        public async Task<ActionResult<IEnumerable<CustomContragentReport>>> getContragentCustomReportForMoneyUziAndLabaratoriya(ReportContragentsMoney contragentsMoney)
        {
            try
            {
                String beginDateStr = contragentsMoney.beginDate.ToString("yyyy-MM-dd");
                String endDateStr = contragentsMoney.endDate.ToString("yyyy-MM-dd");
                var result = await _context.customContragentReports.FromSqlRaw("select h.\"contragentName\" as fio, h.\"contragentPhoneNumber\" as phone, h.\"createdDate\" as datereg," +
                    "(select count(*) from \"HospitalContragentDebitPaymentReport\" where h.\"createdDate\" = \"createdDate\"and \"serviceGroupName\" = 'UZI' and  h.\"contragentId\" = \"contragentId\") as mrt," +
                    "(select count(*) from \"HospitalContragentDebitPaymentReport\" where h.\"createdDate\" = \"createdDate\"and \"serviceGroupName\" = 'LABARATORIYA' and  h.\"contragentId\" = \"contragentId\") as mskt," +
                    "(select sum(summa) from \"HospitalContragentDebitPaymentReport\" where h.\"createdDate\" = \"createdDate\"and   h.\"contragentId\" = \"contragentId\" and (\"serviceGroupName\" = 'UZI' or \"serviceGroupName\" = 'LABARATORIYA' )),h.\"regionName\",h.\"contragentId\" from \"HospitalContragentDebitPaymentReport\" h where h.\"districtsId\" = " + contragentsMoney.districtId + " and ( h.\"createdDate\" between '" + beginDateStr + "' and '" + endDateStr + "' ) and (\"serviceGroupName\" = 'UZI' or \"serviceGroupName\" = 'LABARATORIYA' ) group by h.\"createdDate\",h.\"contragentName\",h.\"contragentPhoneNumber\",h.\"contragentId\",h.\"regionName\"; ").ToListAsync();

                String nameContragent = "";
                if (result != null && result.Count > 0) {
                    foreach (CustomContragentReport item in result) {
                        item.creditSumm = 0;
                        item.debitSumm = 0;
                        item.payedSumm = 0;
                        item.finishStatus = false;
                        if (String.Equals(nameContragent, item.fio))
                        {
                            item.fio = String.Empty;
                            item.phone = String.Empty;
                        }
                        else {
                            nameContragent = item.fio;

                        }
                    }
                }
                
                
                return result;
            }
            catch (Exception)
            {
                return new List<CustomContragentReport>();
            }

        }

        // GET: api/HospitalContragentDebitPaymentReports
        [HttpGet("getContragentPaymentsByDate")]
        public async Task<ActionResult<IEnumerable<HospitalContragentDebitPaymentReport>>> getContragentPaymentsByDate([FromQuery] DateTime begindate,[FromQuery] DateTime endDate)
        {
            return await _context.HospitalContragentDebitPaymentReport.Where(p => p.createdDate >= begindate && p.createdDate <= endDate).OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/HospitalContragentDebitPaymentReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalContragentDebitPaymentReport>> GetHospitalContragentDebitPaymentReport(long id)
        {
            var hospitalContragentDebitPaymentReport = await _context.HospitalContragentDebitPaymentReport.FindAsync(id);

            if (hospitalContragentDebitPaymentReport == null)
            {
                return NotFound();
            }

            return hospitalContragentDebitPaymentReport;
        }

        // PUT: api/HospitalContragentDebitPaymentReports/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalContragentDebitPaymentReport(long id, HospitalContragentDebitPaymentReport hospitalContragentDebitPaymentReport)
        {
            if (id != hospitalContragentDebitPaymentReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalContragentDebitPaymentReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalContragentDebitPaymentReportExists(id))
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

        // POST: api/HospitalContragentDebitPaymentReports
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalContragentDebitPaymentReport>> PostHospitalContragentDebitPaymentReport(HospitalContragentDebitPaymentReport hospitalContragentDebitPaymentReport)
        {
            _context.HospitalContragentDebitPaymentReport.Update(hospitalContragentDebitPaymentReport);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetHospitalContragentDebitPaymentReport", new { id = hospitalContragentDebitPaymentReport.Id }, hospitalContragentDebitPaymentReport);
        }

        // DELETE: api/HospitalContragentDebitPaymentReports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalContragentDebitPaymentReport>> DeleteHospitalContragentDebitPaymentReport(long id)
        {
            var hospitalContragentDebitPaymentReport = await _context.HospitalContragentDebitPaymentReport.FindAsync(id);
            if (hospitalContragentDebitPaymentReport == null)
            {
                return NotFound();
            }

            _context.HospitalContragentDebitPaymentReport.Remove(hospitalContragentDebitPaymentReport);
            await _context.SaveChangesAsync();

            return hospitalContragentDebitPaymentReport;
        }

        private bool HospitalContragentDebitPaymentReportExists(long id)
        {
            return _context.HospitalContragentDebitPaymentReport.Any(e => e.Id == id);
        }
    }
}
