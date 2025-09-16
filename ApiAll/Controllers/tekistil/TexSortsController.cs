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
    public class TexSortsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexSortsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexSorts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexSort>>> GetTexSort()
        {
            return await _context.TexSort.ToListAsync();
        }

        // GET: api/TexSorts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexSort>> GetTexSort(long id)
        {
            var texSort = await _context.TexSort.FindAsync(id);

            if (texSort == null)
            {
                return NotFound();
            }

            return texSort;
        }

        // PUT: api/TexSorts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexSort(long id, TexSort texSort)
        {
            if (id != texSort.id)
            {
                return BadRequest();
            }

            _context.Entry(texSort).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexSortExists(id))
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

        // POST: api/TexSorts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexSort>> PostTexSort(TexSort texSort)
        {
            try
            {
                 _context.TexSort.Update(texSort);
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

            return CreatedAtAction("GetTexSort", new { id = texSort.id }, texSort);
        }

        // DELETE: api/TexSorts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexSort>> DeleteTexSort(long id)
        {
            var texSort = await _context.TexSort.FindAsync(id);
            if (texSort == null)
            {
                return NotFound();
            }

            _context.TexSort.Remove(texSort);
            await _context.SaveChangesAsync();

            return texSort;
        }

        private bool TexSortExists(long id)
        {
            return _context.TexSort.Any(e => e.id == id);
        }
    }
}
