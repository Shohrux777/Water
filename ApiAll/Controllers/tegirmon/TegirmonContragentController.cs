using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tegirmon;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tegirmon
{
    [ApiExplorerSettings(GroupName = "v7")]
    [Route("api/[controller]")]
    [ApiController]
    public class TegirmonContragentController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonContragentController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonContragent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonContragent>>> GetTegirmonContragent()
        {
            return await _context.TegirmonContragent.ToListAsync();
        }
        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonContragent> categoryList = await _context.TegirmonContragent
                .Include(p => p.district)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonContragent>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonContragent.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TegirmonContragent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonContragent>> GetTegirmonContragent(long id)
        {
            var tegirmonContragent = await _context.TegirmonContragent.FindAsync(id);

            if (tegirmonContragent == null)
            {
                return NotFound();
            }

            return tegirmonContragent;
        }

        // PUT: api/TegirmonContragent/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonContragent(long id, TegirmonContragent tegirmonContragent)
        {
            if (id != tegirmonContragent.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonContragent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonContragentExists(id))
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

        // POST: api/TegirmonContragent
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonContragent>> PostTegirmonContragent(TegirmonContragent tegirmonContragent)
        {
            _context.TegirmonContragent.Update(tegirmonContragent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonContragent", new { id = tegirmonContragent.id }, tegirmonContragent);
        }

        // DELETE: api/TegirmonContragent/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonContragent>> DeleteTegirmonContragent(long id)
        {
            var tegirmonContragent = await _context.TegirmonContragent.FindAsync(id);
            if (tegirmonContragent == null)
            {
                return NotFound();
            }

            _context.TegirmonContragent.Remove(tegirmonContragent);
            await _context.SaveChangesAsync();

            return tegirmonContragent;
        }

        private bool TegirmonContragentExists(long id)
        {
            return _context.TegirmonContragent.Any(e => e.id == id);
        }
    }
}
