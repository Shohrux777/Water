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
    public class ServiceTypesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ServiceTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ServiceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceType>>> GetserviceTypes()
        {
            return await _context.serviceTypes.Include( p => p.hospitalServiceTypeGroup).OrderByDescending(p => p.HospitalServiceTypeGroupId).ToListAsync();
        }

        // GET: api/ServiceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceType>> GetServiceType(long id)
        {
            var serviceType = await _context.serviceTypes.FindAsync(id);

            if (serviceType == null)
            {
                return NotFound();
            }

            return serviceType;
        }

        // PUT: api/ServiceTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceType(long id, ServiceType serviceType)
        {
            if (id != serviceType.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeExists(id))
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

        // POST: api/ServiceTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ServiceType>> PostServiceType(ServiceType serviceType)
        {
            if (serviceType.paymentable == true && serviceType.calculateWithPersentage == true) {
                serviceType.contragentPrice = (serviceType.Price * serviceType.persantage) / 100;
            }
            _context.serviceTypes.Update(serviceType);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetServiceType", new { id = serviceType.Id }, serviceType);
        }

        [HttpGet("addServiceType")]
        public async Task<ActionResult<ServiceType>> addServiceType([FromQuery] long Id,[FromQuery]String Name, [FromQuery] long Price)
        {
            ServiceType serviceType = new ServiceType();
            serviceType.ActiveStatus = true;
            serviceType.Id = Id;
            serviceType.Name = Name;
            serviceType.Price = Price;
            _context.serviceTypes.Update(serviceType);
            await _context.SaveChangesAsync();

            return serviceType;
        }

        // DELETE: api/ServiceTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceType>> DeleteServiceType(long id)
        {
            var serviceType = await _context.serviceTypes.FindAsync(id);
            if (serviceType == null)
            {
                return NotFound();
            }

            _context.serviceTypes.Remove(serviceType);
            await _context.SaveChangesAsync();

            return serviceType;
        }

        private bool ServiceTypeExists(long id)
        {
            return _context.serviceTypes.Any(e => e.Id == id);
        }
    }
}
