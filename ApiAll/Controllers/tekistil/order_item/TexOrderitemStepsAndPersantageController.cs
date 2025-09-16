using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil.order_item_steps;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tekistil.order_item
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexOrderitemStepsAndPersantageController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexOrderitemStepsAndPersantageController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexOrderitemStepsAndPersantage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexOrderitemStepsAndPersantage>>> GetTexOrderitemStepsAndPersantage()
        {
            return await _context.TexOrderitemStepsAndPersantage.ToListAsync();
        }

        // GET: api/TexOrderitemStepsAndPersantage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexOrderitemStepsAndPersantage>> GetTexOrderitemStepsAndPersantage(long id)
        {
            var texOrderitemStepsAndPersantage = await _context.TexOrderitemStepsAndPersantage.FindAsync(id);

            if (texOrderitemStepsAndPersantage == null)
            {
                return NotFound();
            }

            return texOrderitemStepsAndPersantage;
        }

        // PUT: api/TexOrderitemStepsAndPersantage/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexOrderitemStepsAndPersantage(long id, TexOrderitemStepsAndPersantage texOrderitemStepsAndPersantage)
        {
            if (id != texOrderitemStepsAndPersantage.id)
            {
                return BadRequest();
            }

            _context.Entry(texOrderitemStepsAndPersantage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexOrderitemStepsAndPersantageExists(id))
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

        // POST: api/TexOrderitemStepsAndPersantage
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexOrderitemStepsAndPersantage>> PostTexOrderitemStepsAndPersantage(TexOrderitemStepsAndPersantage texOrderitemStepsAndPersantage)
        {
            _context.TexOrderitemStepsAndPersantage.Update(texOrderitemStepsAndPersantage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexOrderitemStepsAndPersantage", new { id = texOrderitemStepsAndPersantage.id }, texOrderitemStepsAndPersantage);
        }

        [HttpGet("getPaginationByOrderItemIdBoyichaStepvaPersantageOlish")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByOrderItemIdBoyichaStepvaPersantageOlish([FromQuery] int page,
         [FromQuery] int size, [FromQuery] long order_item_id)
        {

            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexOrderitemStepsAndPersantage> itemList = await _context.TexOrderitemStepsAndPersantage
                .Where(p => p.active_status == true && p.TexOrderItemid == order_item_id)
                .Include(p => p.texOrderItemSteps)
                .OrderByDescending(p => p.id).Skip(size * page).Take(size).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexOrderitemStepsAndPersantage>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexOrderitemStepsAndPersantage.Where(p => p.active_status == true
            && p.TexOrderItemid == order_item_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // DELETE: api/TexOrderitemStepsAndPersantage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexOrderitemStepsAndPersantage>> DeleteTexOrderitemStepsAndPersantage(long id)
        {
            var texOrderitemStepsAndPersantage = await _context.TexOrderitemStepsAndPersantage.FindAsync(id);
            if (texOrderitemStepsAndPersantage == null)
            {
                return NotFound();
            }

            _context.TexOrderitemStepsAndPersantage.Remove(texOrderitemStepsAndPersantage);
            await _context.SaveChangesAsync();

            return texOrderitemStepsAndPersantage;
        }

        private bool TexOrderitemStepsAndPersantageExists(long id)
        {
            return _context.TexOrderitemStepsAndPersantage.Any(e => e.id == id);
        }
    }
}
