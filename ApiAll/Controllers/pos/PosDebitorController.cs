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
    public class PosDebitorController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosDebitorController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosDebitor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosDebitor>>> GetPosDebitor()
        {
            return await _context.PosDebitor.ToListAsync();
        }

        [HttpGet("getDebitorListByPaginationAndSearchResult")]
        public async Task<ActionResult<TexPaginationModel>> getDebitorListByPaginationAndSearchResult([FromQuery] int page, [FromQuery] int size,[FromQuery] String client_name)
        {
         

            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosDebitor> itemList = new List<PosDebitor>();
            if (client_name != null && client_name.Trim().Length > 0)
            {
                itemList = await _context.PosDebitor
                .Include(p => p.client)
                .Where(p => p.real_debitor_price > 0 && p.client.name.ToLower().Contains(client_name.ToLower()))
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            }
            else {
                itemList = await _context.PosDebitor
                    .Include(p => p.client)
                    .Where(p => p.real_debitor_price > 0)
                    .OrderByDescending(p => p.id)
                    .Skip(size * page).Take(size)
                    .ToListAsync();
            }

            
            if (itemList == null)
            {
                itemList = new List<PosDebitor>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            if (client_name != null && client_name.Trim().Length > 0)
            {
                paginationModel.items_count = await _context.PosDebitor
                .Include(p => p.client)
                .Where(p => p.real_debitor_price > 0 && p.client.name.ToLower().Contains(client_name.ToLower()))
                .CountAsync();
            }
            else {
                paginationModel.items_count = await _context.PosDebitor.Where(p => p.real_debitor_price > 0).CountAsync();
            }

            
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/PosDebitor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosDebitor>> GetPosDebitor(long id)
        {
            var posDebitor = await _context.PosDebitor.FindAsync(id);

            if (posDebitor == null)
            {
                return NotFound();
            }

            return posDebitor;
        }

        // PUT: api/PosDebitor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosDebitor(long id, PosDebitor posDebitor)
        {
            if (id != posDebitor.id)
            {
                return BadRequest();
            }

            _context.Entry(posDebitor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosDebitorExists(id))
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

        // POST: api/PosDebitor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosDebitor>> PostPosDebitor(PosDebitor posDebitor)
        {
            _context.PosDebitor.Update(posDebitor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosDebitor", new { id = posDebitor.id }, posDebitor);
        }

        // DELETE: api/PosDebitor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosDebitor>> DeletePosDebitor(long id)
        {
            var posDebitor = await _context.PosDebitor.FindAsync(id);
            if (posDebitor == null)
            {
                return NotFound();
            }

            _context.PosDebitor.Remove(posDebitor);
            await _context.SaveChangesAsync();

            return posDebitor;
        }

        private bool PosDebitorExists(long id)
        {
            return _context.PosDebitor.Any(e => e.id == id);
        }
    }
}
