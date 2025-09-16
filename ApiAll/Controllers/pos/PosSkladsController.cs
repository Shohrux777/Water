using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.pos;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.pos
{
    [ApiExplorerSettings(GroupName = "v5")]
    [Route("api/[controller]")]
    [ApiController]
    public class PosSkladsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosSkladsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosSklads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosSklad>>> GetPosSklad()
        {
            return await _context.PosSklad.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosSklad> itemList = await _context.PosSklad
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosSklad>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosSklad.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/PosSklads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosSklad>> GetPosSklad(long id)
        {
            var posSklad = await _context.PosSklad.FindAsync(id);

            if (posSklad == null)
            {
                return NotFound();
            }

            return posSklad;
        }

        // PUT: api/PosSklads/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosSklad(long id, PosSklad posSklad)
        {
            if (id != posSklad.id)
            {
                return BadRequest();
            }

            _context.Entry(posSklad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosSkladExists(id))
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

        // POST: api/PosSklads
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosSklad>> PostPosSklad(PosSklad posSklad)
        {


            try
            {
                _context.PosSklad.Update(posSklad);
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

            return CreatedAtAction("GetPosSklad", new { id = posSklad.id }, posSklad);
        }

        // DELETE: api/PosSklads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosSklad>> DeletePosSklad(long id)
        {
            var posSklad = await _context.PosSklad.FindAsync(id);
            if (posSklad == null)
            {
                return NotFound();
            }

            _context.PosSklad.Remove(posSklad);
            await _context.SaveChangesAsync();

            return posSklad;
        }

        private bool PosSkladExists(long id)
        {
            return _context.PosSklad.Any(e => e.id == id);
        }
    }
}
