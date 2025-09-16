using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;

namespace ApiAll.Controllers.tekistil
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexDevicesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexDevicesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexDevices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexDevice>>> GetTexDevice()
        {
            return await _context.TexDevice.Where(p => p.active_status == true).Include( p =>p.department).Include( p =>p.deviceType).Include(p =>p.texSubProccessList).OrderByDescending( p => p.id).ToListAsync();
        }

        // GET: api/TexDevices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexDevice>> GetTexDevice(long id)
        {
            List<TexDevice> texDeviceList = await _context.TexDevice
                .Where(p => p.active_status == true && p.id == id)
                .Include(p => p.department)
                .Include(p => p.deviceType)
                .Include(p => p.texSubProccessList)
                .ThenInclude(p => p.subProccess)
                .OrderByDescending(p => p.id).ToListAsync();

            if (texDeviceList == null || texDeviceList.Count == 0)
            {
                return NotFound();
            }
            

            return texDeviceList.First();
        }

        // PUT: api/TexDevices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexDevice(long id, TexDevice texDevice)
        {
            if (id != texDevice.id)
            {
                return BadRequest();
            }

            _context.Entry(texDevice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexDeviceExists(id))
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

        // POST: api/TexDevices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexDevice>> PostTexDevice(TexDevice texDevice)
        {

            try
            {
            _context.TexDevice.Update(texDevice);
            await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                return NotFound(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFound(e?.InnerException?.Message);
            }

            return texDevice;
        }

        // DELETE: api/TexDevices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexDevice>> DeleteTexDevice(long id)
        {
            var texDevice = await _context.TexDevice.FindAsync(id);
            if (texDevice == null)
            {
                return NotFound();
            }

            texDevice.active_status = false;
            _context.TexDevice.Update(texDevice);
            await _context.SaveChangesAsync();

            return texDevice;
        }

        private bool TexDeviceExists(long id)
        {
            return _context.TexDevice.Any(e => e.id == id);
        }
    }
}
