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
    public class TexPaymentTypesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexPaymentTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexPaymentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexPaymentType>>> GetTexPaymentType()
        {
            return await _context.TexPaymentType.Where(p => p.active_status == true).OrderByDescending(p =>p.id).ToListAsync();
        }

        // GET: api/TexPaymentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexPaymentType>> GetTexPaymentType(long id)
        {
            var texPaymentType = await _context.TexPaymentType.FindAsync(id);

            if (texPaymentType == null)
            {
                return NotFound();
            }

            return texPaymentType;
        }

        // PUT: api/TexPaymentTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexPaymentType(long id, TexPaymentType texPaymentType)
        {
            if (id != texPaymentType.id)
            {
                return BadRequest();
            }

            _context.Entry(texPaymentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexPaymentTypeExists(id))
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

        // POST: api/TexPaymentTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexPaymentType>> PostTexPaymentType(TexPaymentType texPaymentType)
        {
           

            try
            {
 _context.TexPaymentType.Update(texPaymentType);
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
            return CreatedAtAction("GetTexPaymentType", new { id = texPaymentType.id }, texPaymentType);
        }

        // DELETE: api/TexPaymentTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexPaymentType>> DeleteTexPaymentType(long id)
        {
            var texPaymentType = await _context.TexPaymentType.FindAsync(id);
            if (texPaymentType == null)
            {
                return NotFound();
            }

            texPaymentType.active_status = false;

            _context.TexPaymentType.Update(texPaymentType);
            await _context.SaveChangesAsync();

            return texPaymentType;
        }

        private bool TexPaymentTypeExists(long id)
        {
            return _context.TexPaymentType.Any(e => e.id == id);
        }
    }
}
