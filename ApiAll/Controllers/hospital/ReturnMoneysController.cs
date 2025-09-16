using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnMoneysController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ReturnMoneysController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ReturnMoneys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnMoney>>> GetreturnMoney()
        {
            return await _context.returnMoney.Include(p => p.user).Include( p => p.Authorization).ThenInclude( p => p.users).OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/ReturnMoneys
        [HttpGet("getReturnMoneyListBeatwenDateTimeAndKassirId")]
        public async Task<ActionResult<IEnumerable<ReturnMoney>>> getReturnMoneyListBeatwenDateTimeAndKassirId([FromQuery] DateTime beginDate ,[FromQuery] DateTime endDate,[FromQuery] long kassirId)
        {
            if (kassirId == 0)
            {
                return await _context.returnMoney.Where( p => p.RegistratedDate >= beginDate && p.RegistratedDate <= endDate).Include(p => p.user).Include(p => p.Authorization).ThenInclude(p => p.users).OrderByDescending(p => p.Id).ToListAsync();

            }
            else {
                return await _context.returnMoney.Where(p => p.RegistratedDate >= beginDate && p.RegistratedDate <= endDate && p.AuthorizationId == kassirId ).Include(p => p.user).Include(p => p.Authorization).ThenInclude(p => p.users).OrderByDescending(p => p.Id).ToListAsync();

            }

        }

        // GET: api/ReturnMoneys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnMoney>> GetReturnMoney(long id)
        {
            var returnMoney = await _context.returnMoney.FindAsync(id);

            if (returnMoney == null)
            {
                return NotFound();
            }

            return returnMoney;
        }

        // PUT: api/ReturnMoneys/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReturnMoney(long id, ReturnMoney returnMoney)
        {
            if (id != returnMoney.Id)
            {
                return BadRequest();
            }

            _context.Entry(returnMoney).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReturnMoneyExists(id))
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

        // POST: api/ReturnMoneys
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ReturnMoney>> PostReturnMoney(ReturnMoney returnMoney)
        {
            returnMoney.RegistratedDate = DateTime.Now;
            _context.returnMoney.Update(returnMoney);
            await _context.SaveChangesAsync();

            List<HospitalManagerReport> managerReports = await _context.HospitalManagerReport.Where(p => p.createdDateTime >= DateTime.Now.Date && p.HospitalServiceTypeGroupName == "RETURNED" && p.AuthorizationId == returnMoney.AuthorizationId).ToListAsync();
            if (managerReports != null && managerReports.Count > 0)
            {
                HospitalManagerReport hospitalManagerReport = managerReports.First();
                hospitalManagerReport.cashSumm = hospitalManagerReport.cashSumm + returnMoney.price;
                hospitalManagerReport.count = hospitalManagerReport.count + 1;
                _context.HospitalManagerReport.Update(hospitalManagerReport);
                await _context.SaveChangesAsync();
            }
            else
            {
                HospitalManagerReport hospitalManagerItem = new HospitalManagerReport();
                hospitalManagerItem.ActiveStatus = true;
                hospitalManagerItem.cashSumm = returnMoney.price;
                hospitalManagerItem.cardSumm = 0;
                hospitalManagerItem.status = 2;
                hospitalManagerItem.count = 1;
                hospitalManagerItem.createdDateTime = DateTime.Now;
                hospitalManagerItem.AuthorizationId = returnMoney.AuthorizationId;
                hospitalManagerItem.HospitalServiceTypeGroupName = "RETURNED";
                _context.HospitalManagerReport.Update(hospitalManagerItem);
                await _context.SaveChangesAsync();

            }


            return CreatedAtAction("GetReturnMoney", new { id = returnMoney.Id }, returnMoney);
        }

        [HttpGet("addReturnMoney")]
        public async Task<ActionResult<ReturnMoney>> addReturnMoney([FromQuery] long Id, [FromQuery] String Reason, [FromQuery] long price,[FromQuery] long userId,[FromQuery] long authId)
        {
            ReturnMoney returnMoney = new ReturnMoney();
            returnMoney.ActiveStatus = true;
            returnMoney.Id = Id;
            returnMoney.price = price;
            returnMoney.Reason = Reason;
            returnMoney.UsersId = userId;
            returnMoney.AuthorizationId = authId;
            _context.returnMoney.Update(returnMoney);
            await _context.SaveChangesAsync();


            return returnMoney;
        }
        // DELETE: api/ReturnMoneys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReturnMoney>> DeleteReturnMoney(long id)
        {
            var returnMoney = await _context.returnMoney.FindAsync(id);
            if (returnMoney == null)
            {
                return NotFound();
            }

            _context.returnMoney.Remove(returnMoney);
            await _context.SaveChangesAsync();

            return returnMoney;
        }

        private bool ReturnMoneyExists(long id)
        {
            return _context.returnMoney.Any(e => e.Id == id);
        }
    }
}
