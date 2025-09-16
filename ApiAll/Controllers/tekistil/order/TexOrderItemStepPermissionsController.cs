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
    public class TexOrderItemStepPermissionsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexOrderItemStepPermissionsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexOrderItemStepPermissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexOrderItemStepPermissions>>> GetTexOrderItemStepPermissions()
        {
            return await _context.TexOrderItemStepPermissions.ToListAsync();
        }

        [HttpGet("getOrderStepsPermissionListByAuthId")]
        public async Task<ActionResult<IEnumerable<TexOrderItemStepPermissions>>> getOrderStepsPermissionListByAuthId([FromQuery] long auth_id)
        {
            return await _context.TexOrderItemStepPermissions.Where(p => p.auth_id == auth_id).Include( p => p.itemSteps).OrderByDescending( p =>p.id).ToListAsync();
        }

        // GET: api/TexOrderItemStepPermissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexOrderItemStepPermissions>> GetTexOrderItemStepPermissions(long id)
        {
            var texOrderItemStepPermissions = await _context.TexOrderItemStepPermissions.FindAsync(id);

            if (texOrderItemStepPermissions == null)
            {
                return NotFound();
            }

            return texOrderItemStepPermissions;
        }

        // PUT: api/TexOrderItemStepPermissions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexOrderItemStepPermissions(long id, TexOrderItemStepPermissions texOrderItemStepPermissions)
        {
            if (id != texOrderItemStepPermissions.id)
            {
                return BadRequest();
            }

            _context.Entry(texOrderItemStepPermissions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexOrderItemStepPermissionsExists(id))
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

        // POST: api/TexOrderItemStepPermissions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexOrderItemStepPermissions>> PostTexOrderItemStepPermissions(TexOrderItemStepPermissions texOrderItemStepPermissions)
        {
            try
            {
                _context.TexOrderItemStepPermissions.Update(texOrderItemStepPermissions);
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

            return CreatedAtAction("GetTexOrderItemStepPermissions", new { id = texOrderItemStepPermissions.id }, texOrderItemStepPermissions);
        }

        // DELETE: api/TexOrderItemStepPermissions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexOrderItemStepPermissions>> DeleteTexOrderItemStepPermissions(long id)
        {
            var texOrderItemStepPermissions = await _context.TexOrderItemStepPermissions.FindAsync(id);
            if (texOrderItemStepPermissions == null)
            {
                return NotFound();
            }

            _context.TexOrderItemStepPermissions.Remove(texOrderItemStepPermissions);
            await _context.SaveChangesAsync();

            return texOrderItemStepPermissions;
        }

        private bool TexOrderItemStepPermissionsExists(long id)
        {
            return _context.TexOrderItemStepPermissions.Any(e => e.id == id);
        }
    }
}
