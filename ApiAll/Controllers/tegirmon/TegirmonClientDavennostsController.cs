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
    public class TegirmonClientDavennostsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonClientDavennostsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonClientDavennosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonClientDavennost>>> GetTegirmonClientDavennost()
        {
            return await _context.TegirmonClientDavennost.ToListAsync();
        }


        [HttpGet("getPaginationBySearchByFio")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationBySearchByFio([FromQuery] int page, [FromQuery] int size, [FromQuery] String fio_str)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonClientDavennost> categoryList = await _context.TegirmonClientDavennost
                .Include(p => p.client)
                .Where(p => p.active_status == true
                && p.fio.ToLower().Contains(fio_str.ToLower()))

                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonClientDavennost>();
            }


            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonClientDavennost.Where(p => p.active_status == true
            && p.fio.ToLower().Contains(fio_str.ToLower())).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonClientDavennost> categoryList = await _context.TegirmonClientDavennost
                .Include(p => p.client)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonClientDavennost>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonClientDavennost.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByClientId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByClientId([FromQuery] int page, [FromQuery] int size,[FromQuery] long client_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonClientDavennost> categoryList = await _context.TegirmonClientDavennost
                .Include(p => p.client)
                .Where(p => p.active_status == true && p.TegirmonClientid == client_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonClientDavennost>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonClientDavennost
                .Where(p => p.active_status == true && p.TegirmonClientid == client_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TegirmonClientDavennosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonClientDavennost>> GetTegirmonClientDavennost(long id)
        {
            var tegirmonClientDavennost = await _context.TegirmonClientDavennost.FindAsync(id);

            if (tegirmonClientDavennost == null)
            {
                return NotFound();
            }

            return tegirmonClientDavennost;
        }

        // PUT: api/TegirmonClientDavennosts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonClientDavennost(long id, TegirmonClientDavennost tegirmonClientDavennost)
        {
            if (id != tegirmonClientDavennost.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonClientDavennost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonClientDavennostExists(id))
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

        // POST: api/TegirmonClientDavennosts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonClientDavennost>> PostTegirmonClientDavennost(TegirmonClientDavennost tegirmonClientDavennost)
        {
            _context.TegirmonClientDavennost.Update(tegirmonClientDavennost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonClientDavennost", new { id = tegirmonClientDavennost.id }, tegirmonClientDavennost);
        }

        // DELETE: api/TegirmonClientDavennosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonClientDavennost>> DeleteTegirmonClientDavennost(long id)
        {
            var tegirmonClientDavennost = await _context.TegirmonClientDavennost.FindAsync(id);
            if (tegirmonClientDavennost == null)
            {
                return NotFound();
            }

            _context.TegirmonClientDavennost.Remove(tegirmonClientDavennost);
            await _context.SaveChangesAsync();

            return tegirmonClientDavennost;
        }

        private bool TegirmonClientDavennostExists(long id)
        {
            return _context.TegirmonClientDavennost.Any(e => e.id == id);
        }
    }
}
