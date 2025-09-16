using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.pos;

namespace ApiAll.Controllers.pos
{
    [ApiExplorerSettings(GroupName = "v5")]
    [Route("api/[controller]")]
    [ApiController]
    public class PosMessageGroupsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosMessageGroupsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosMessageGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosMessageGroup>>> GetPosMessageGroup()
        {
            return await _context.PosMessageGroup.ToListAsync();
        }

        // GET: api/PosMessageGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosMessageGroup>> GetPosMessageGroup(long id)
        {
            var posMessageGroup = await _context.PosMessageGroup.FindAsync(id);

            if (posMessageGroup == null)
            {
                return NotFound();
            }

            return posMessageGroup;
        }

        // PUT: api/PosMessageGroups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosMessageGroup(long id, PosMessageGroup posMessageGroup)
        {
            if (id != posMessageGroup.id)
            {
                return BadRequest();
            }

            _context.Entry(posMessageGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosMessageGroupExists(id))
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

        // POST: api/PosMessageGroups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosMessageGroup>> PostPosMessageGroup(PosMessageGroup posMessageGroup)
        {


            try
            {
            _context.PosMessageGroup.Update(posMessageGroup);
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

            return CreatedAtAction("GetPosMessageGroup", new { id = posMessageGroup.id }, posMessageGroup);
        }

        // DELETE: api/PosMessageGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosMessageGroup>> DeletePosMessageGroup(long id)
        {
            var posMessageGroup = await _context.PosMessageGroup.FindAsync(id);
            if (posMessageGroup == null)
            {
                return NotFound();
            }

            _context.PosMessageGroup.Remove(posMessageGroup);
            await _context.SaveChangesAsync();

            return posMessageGroup;
        }

        private bool PosMessageGroupExists(long id)
        {
            return _context.PosMessageGroup.Any(e => e.id == id);
        }
    }
}
