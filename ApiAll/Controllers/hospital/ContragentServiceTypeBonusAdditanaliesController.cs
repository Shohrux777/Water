using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContragentServiceTypeBonusAdditanaliesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ContragentServiceTypeBonusAdditanaliesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ContragentServiceTypeBonusAdditanalies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContragentServiceTypeBonusAdditanaly>>> GetContragentServiceTypeBonusAdditanaly()
        {
            return await _context.ContragentServiceTypeBonusAdditanaly.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<ContragentServiceTypeBonusAdditanaly> itemList = await _context.ContragentServiceTypeBonusAdditanaly
                .Include(p => p.contragent)
                .Include(p => p.serviceType)
                .OrderByDescending(p => p.Id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<ContragentServiceTypeBonusAdditanaly>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.ContragentServiceTypeBonusAdditanaly.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getAdditanilyBonusByContragentId")]
        public async Task<ActionResult<IEnumerable<ContragentServiceTypeBonusAdditanaly>>> getAdditanilyBonusByContragentId([FromQuery] long contragentId)
        {
            return await _context.ContragentServiceTypeBonusAdditanaly.Where( p => p.ContragentId == contragentId).Include(p => p.serviceType).OrderByDescending( p => p.Id).ToListAsync();
        }

        // GET: api/ContragentServiceTypeBonusAdditanalies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContragentServiceTypeBonusAdditanaly>> GetContragentServiceTypeBonusAdditanaly(long id)
        {
            var contragentServiceTypeBonusAdditanaly = await _context.ContragentServiceTypeBonusAdditanaly.FindAsync(id);

            if (contragentServiceTypeBonusAdditanaly == null)
            {
                return NotFound();
            }

            return contragentServiceTypeBonusAdditanaly;
        }

        // PUT: api/ContragentServiceTypeBonusAdditanalies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContragentServiceTypeBonusAdditanaly(long id, ContragentServiceTypeBonusAdditanaly contragentServiceTypeBonusAdditanaly)
        {
            if (id != contragentServiceTypeBonusAdditanaly.Id)
            {
                return BadRequest();
            }

            _context.Entry(contragentServiceTypeBonusAdditanaly).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContragentServiceTypeBonusAdditanalyExists(id))
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

        // POST: api/ContragentServiceTypeBonusAdditanalies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ContragentServiceTypeBonusAdditanaly>> PostContragentServiceTypeBonusAdditanaly(ContragentServiceTypeBonusAdditanaly contragentServiceTypeBonusAdditanaly)
        {
            _context.ContragentServiceTypeBonusAdditanaly.Update(contragentServiceTypeBonusAdditanaly);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetContragentServiceTypeBonusAdditanaly", new { id = contragentServiceTypeBonusAdditanaly.Id }, contragentServiceTypeBonusAdditanaly);
        }

        // DELETE: api/ContragentServiceTypeBonusAdditanalies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContragentServiceTypeBonusAdditanaly>> DeleteContragentServiceTypeBonusAdditanaly(long id)
        {
            var contragentServiceTypeBonusAdditanaly = await _context.ContragentServiceTypeBonusAdditanaly.FindAsync(id);
            if (contragentServiceTypeBonusAdditanaly == null)
            {
                return NotFound();
            }

            _context.ContragentServiceTypeBonusAdditanaly.Remove(contragentServiceTypeBonusAdditanaly);
            await _context.SaveChangesAsync();

            return contragentServiceTypeBonusAdditanaly;
        }

        private bool ContragentServiceTypeBonusAdditanalyExists(long id)
        {
            return _context.ContragentServiceTypeBonusAdditanaly.Any(e => e.Id == id);
        }
    }
}
