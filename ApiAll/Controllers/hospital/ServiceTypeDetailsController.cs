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
    public class ServiceTypeDetailsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ServiceTypeDetailsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ServiceTypeDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceTypeDetail>>> GetServiceTypeDetail()
        {
            return await _context.ServiceTypeDetail.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/ServiceTypeDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceTypeDetail>> GetServiceTypeDetail(long id)
        {
            var serviceTypeDetail = await _context.ServiceTypeDetail.FindAsync(id);

            if (serviceTypeDetail == null)
            {
                return NotFound();
            }

            return serviceTypeDetail;
        }

        [HttpGet("getServiceTypeDetailByUserId")]
        public async Task<ActionResult<IEnumerable<ServiceTypeDetail>>> getServiceTypeDetailByUserId([FromQuery]long UserId)
        {
            var serviceTypeDetail = await _context.ServiceTypeDetail
                .Where(s=>s.UsersId == UserId)
                .Include(s=>s.serviceType)
                .OrderBy(s =>s.serviceType.Name)
                .ToListAsync();

            if (serviceTypeDetail == null)
            {
                return NotFound();
            }

            return serviceTypeDetail;
        }

        // PUT: api/ServiceTypeDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceTypeDetail(long id, ServiceTypeDetail serviceTypeDetail)
        {
            if (id != serviceTypeDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceTypeDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeDetailExists(id))
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

        // POST: api/ServiceTypeDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ServiceTypeDetail>> PostServiceTypeDetail(ServiceTypeDetail serviceTypeDetail)
        {
            _context.ServiceTypeDetail.Update(serviceTypeDetail);
            await _context.SaveChangesAsync();

            return serviceTypeDetail;
        }

        [HttpGet("addServiceTypeDetail")]
        public async Task<ActionResult<ServiceTypeDetail>> addServiceTypeDetail([FromQuery] long Id,[FromQuery] long UserId, [FromQuery] long ServiceTypeId)
        {
            ServiceTypeDetail serviceTypeDetail = new ServiceTypeDetail();
            serviceTypeDetail.ActiveStatus = true;
            serviceTypeDetail.Id = Id;
            serviceTypeDetail.UsersId = UserId;
            serviceTypeDetail.ServiceTypeId = ServiceTypeId;
            _context.ServiceTypeDetail.Update(serviceTypeDetail);
            await _context.SaveChangesAsync();

            return serviceTypeDetail;
        }

        // DELETE: api/ServiceTypeDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceTypeDetail>> DeleteServiceTypeDetail(long id)
        {
            var serviceTypeDetail = await _context.ServiceTypeDetail.FindAsync(id);
            if (serviceTypeDetail == null)
            {
                return NotFound();
            }

            _context.ServiceTypeDetail.Remove(serviceTypeDetail);
            await _context.SaveChangesAsync();

            return serviceTypeDetail;
        }

        private bool ServiceTypeDetailExists(long id)
        {
            return _context.ServiceTypeDetail.Any(e => e.Id == id);
        }
    }
}
