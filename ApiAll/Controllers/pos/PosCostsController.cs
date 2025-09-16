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
    public class PosCostsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosCostsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosCosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosCosts>>> GetPosCosts()
        {
            return await _context.PosCosts.ToListAsync();
        }

        [HttpGet("getCostsListByPagination")]
        public async Task<ActionResult<TexPaginationModel>> getCostsListByPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosCosts> itemList = await _context.PosCosts.Include(p =>p.auth)
                .ThenInclude(p =>p.user)
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosCosts>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosCosts.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/PosCosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosCosts>> GetPosCosts(long id)
        {
            var posCosts = await _context.PosCosts.FindAsync(id);

            if (posCosts == null)
            {
                return NotFound();
            }

            return posCosts;
        }

        // PUT: api/PosCosts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosCosts(long id, PosCosts posCosts)
        {
            if (id != posCosts.id)
            {
                return BadRequest();
            }

            _context.Entry(posCosts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosCostsExists(id))
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

        // POST: api/PosCosts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosCosts>> PostPosCosts(PosCosts posCosts)
        {
            _context.PosCosts.Update(posCosts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosCosts", new { id = posCosts.id }, posCosts);
        }

        // DELETE: api/PosCosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosCosts>> DeletePosCosts(long id)
        {
            var posCosts = await _context.PosCosts.FindAsync(id);
            if (posCosts == null)
            {
                return NotFound();
            }

            _context.PosCosts.Remove(posCosts);
            await _context.SaveChangesAsync();

            return posCosts;
        }

        private bool PosCostsExists(long id)
        {
            return _context.PosCosts.Any(e => e.id == id);
        }
    }
}
