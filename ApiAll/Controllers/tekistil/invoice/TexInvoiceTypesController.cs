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
    public class TexInvoiceTypesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexInvoiceTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexInvoiceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexInvoiceType>>> GetTexInvoiceType()
        {
            return await _context.TexInvoiceType.ToListAsync();
        }

        // GET: api/TexInvoiceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexInvoiceType>> GetTexInvoiceType(long id)
        {
            var texInvoiceType = await _context.TexInvoiceType.FindAsync(id);

            if (texInvoiceType == null)
            {
                return NotFound();
            }

            return texInvoiceType;
        }

        // PUT: api/TexInvoiceTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexInvoiceType(long id, TexInvoiceType texInvoiceType)
        {
            if (id != texInvoiceType.id)
            {
                return BadRequest();
            }

            _context.Entry(texInvoiceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexInvoiceTypeExists(id))
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

        // POST: api/TexInvoiceTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexInvoiceType>> PostTexInvoiceType(TexInvoiceType texInvoiceType)
        {



            try
            {
            _context.TexInvoiceType.Update(texInvoiceType);
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

            return CreatedAtAction("GetTexInvoiceType", new { id = texInvoiceType.id }, texInvoiceType);
        }

        // DELETE: api/TexInvoiceTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexInvoiceType>> DeleteTexInvoiceType(long id)
        {
            var texInvoiceType = await _context.TexInvoiceType.FindAsync(id);
            if (texInvoiceType == null)
            {
                return NotFound();
            }

            _context.TexInvoiceType.Remove(texInvoiceType);
            await _context.SaveChangesAsync();

            return texInvoiceType;
        }

        private bool TexInvoiceTypeExists(long id)
        {
            return _context.TexInvoiceType.Any(e => e.id == id);
        }
    }
}
