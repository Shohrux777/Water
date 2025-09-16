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
    public class ArchiveDevicesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ArchiveDevicesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ArchiveDevices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveDevice>>> GetArchiveDevice()
        {
            return await _context.ArchiveDevice.ToListAsync();
        }

        // GET: api/ArchiveDevices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchiveDevice>> GetArchiveDevice(long id)
        {
            var archiveDevice = await _context.ArchiveDevice.FindAsync(id);

            if (archiveDevice == null)
            {
                return NotFound();
            }

            return archiveDevice;
        }

        // PUT: api/ArchiveDevices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchiveDevice(long id, ArchiveDevice archiveDevice)
        {
            if (id != archiveDevice.id)
            {
                return BadRequest();
            }

            _context.Entry(archiveDevice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveDeviceExists(id))
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

        // POST: api/ArchiveDevices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArchiveDevice>> PostArchiveDevice(ArchiveDevice archiveDevice)
        {
            _context.ArchiveDevice.Update(archiveDevice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArchiveDevice", new { id = archiveDevice.id }, archiveDevice);
        }

        // DELETE: api/ArchiveDevices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchiveDevice>> DeleteArchiveDevice(long id)
        {
            var archiveDevice = await _context.ArchiveDevice.FindAsync(id);
            if (archiveDevice == null)
            {
                return NotFound();
            }

            _context.ArchiveDevice.Remove(archiveDevice);
            await _context.SaveChangesAsync();

            return archiveDevice;
        }

        private bool ArchiveDeviceExists(long id)
        {
            return _context.ArchiveDevice.Any(e => e.id == id);
        }
    }
}
