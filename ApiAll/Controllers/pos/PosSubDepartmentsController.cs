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
    public class PosSubDepartmentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosSubDepartmentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosSubDepartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosSubDepartment>>> GetPosSubDepartment()
        {
            return await _context.PosSubDepartment.ToListAsync();
        }

        // GET: api/PosSubDepartments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosSubDepartment>> GetPosSubDepartment(long id)
        {
            var posSubDepartment = await _context.PosSubDepartment.FindAsync(id);

            if (posSubDepartment == null)
            {
                return NotFound();
            }

            return posSubDepartment;
        }

        // PUT: api/PosSubDepartments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosSubDepartment(long id, PosSubDepartment posSubDepartment)
        {
            if (id != posSubDepartment.id)
            {
                return BadRequest();
            }

            _context.Entry(posSubDepartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosSubDepartmentExists(id))
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

        // POST: api/PosSubDepartments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosSubDepartment>> PostPosSubDepartment(PosSubDepartment posSubDepartment)
        {
            try
            {
            _context.PosSubDepartment.Update(posSubDepartment);
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

            return CreatedAtAction("GetPosSubDepartment", new { id = posSubDepartment.id }, posSubDepartment);
        }

        // DELETE: api/PosSubDepartments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosSubDepartment>> DeletePosSubDepartment(long id)
        {
            var posSubDepartment = await _context.PosSubDepartment.FindAsync(id);
            if (posSubDepartment == null)
            {
                return NotFound();
            }

            _context.PosSubDepartment.Remove(posSubDepartment);
            await _context.SaveChangesAsync();

            return posSubDepartment;
        }

        private bool PosSubDepartmentExists(long id)
        {
            return _context.PosSubDepartment.Any(e => e.id == id);
        }
    }
}
