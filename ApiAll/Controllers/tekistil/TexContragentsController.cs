using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tekistil
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexContragentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexContragentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexContragents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexContragent>>> GetTexContragent()
        {
            return await _context.TexContragent.Where(p =>p.active_status == true).OrderByDescending(p => p.id).ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexContragent> itemList = await _context.TexContragent.Where(p => p.active_status == true).OrderByDescending(p => p.id).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexContragent>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexContragent.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("client_list")]
        public async Task<ActionResult<IEnumerable<TexContragent>>> getClientList()
        {
            return await _context.TexContragent.Where(p => p.active_status == true).OrderByDescending(p => p.id).Where(p => p.type_client == true).ToListAsync();
        }
        [HttpGet("postavshik_list")]
        public async Task<ActionResult<IEnumerable<TexContragent>>> getPostavshikList()
        {
            return await _context.TexContragent.Where(p => p.active_status == true).OrderByDescending(p => p.id).Where(p => p.type_postavshik == true).ToListAsync();
        }

        [HttpGet("company_list")]
        public async Task<ActionResult<IEnumerable<TexContragent>>> getMainCompanyList()
        {
            return await _context.TexContragent.Where(p => p.active_status == true).OrderByDescending(p => p.id).Where(p => p.type_maincompany == true).ToListAsync();
        }

        // GET: api/TexContragents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexContragent>> GetTexContragent(long id)
        {
            var texContragent = await _context.TexContragent.FindAsync(id);

            if (texContragent == null)
            {
                return NotFound();
            }

            return texContragent;
        }

        // PUT: api/TexContragents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexContragent(long id, TexContragent texContragent)
        {
            if (id != texContragent.id)
            {
                return BadRequest();
            }

            _context.Entry(texContragent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexContragentExists(id))
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

        // POST: api/TexContragents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexContragent>> PostTexContragent(TexContragent texContragent)
        {



            try
            {
            _context.TexContragent.Update(texContragent);
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

            return CreatedAtAction("GetTexContragent", new { id = texContragent.id }, texContragent);
        }

        // DELETE: api/TexContragents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexContragent>> DeleteTexContragent(long id)
        {
            var texContragent = await _context.TexContragent.FindAsync(id);
            if (texContragent == null)
            {
                return NotFound();
            }

            texContragent.active_status = true;
            _context.TexContragent.Update(texContragent);
            await _context.SaveChangesAsync();

            return texContragent;
        }

        private bool TexContragentExists(long id)
        {
            return _context.TexContragent.Any(e => e.id == id);
        }
    }
}
