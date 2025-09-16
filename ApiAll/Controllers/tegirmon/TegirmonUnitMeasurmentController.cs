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
    public class TegirmonUnitMeasurmentController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonUnitMeasurmentController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonUnitMeasurment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonUnitMeasurment>>> GetTegirmonUnitMeasurment()
        {
            return await _context.TegirmonUnitMeasurment.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonUnitMeasurment> categoryList = await _context.TegirmonUnitMeasurment
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonUnitMeasurment>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonUnitMeasurment.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TegirmonUnitMeasurment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonUnitMeasurment>> GetTegirmonUnitMeasurment(long id)
        {
            var tegirmonUnitMeasurment = await _context.TegirmonUnitMeasurment.FindAsync(id);

            if (tegirmonUnitMeasurment == null)
            {
                return NotFound();
            }

            return tegirmonUnitMeasurment;
        }

        // PUT: api/TegirmonUnitMeasurment/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonUnitMeasurment(long id, TegirmonUnitMeasurment tegirmonUnitMeasurment)
        {
            if (id != tegirmonUnitMeasurment.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonUnitMeasurment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonUnitMeasurmentExists(id))
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

        // POST: api/TegirmonUnitMeasurment
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonUnitMeasurment>> PostTegirmonUnitMeasurment(TegirmonUnitMeasurment tegirmonUnitMeasurment)
        {
            _context.TegirmonUnitMeasurment.Update(tegirmonUnitMeasurment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonUnitMeasurment", new { id = tegirmonUnitMeasurment.id }, tegirmonUnitMeasurment);
        }

        // DELETE: api/TegirmonUnitMeasurment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonUnitMeasurment>> DeleteTegirmonUnitMeasurment(long id)
        {
            var tegirmonUnitMeasurment = await _context.TegirmonUnitMeasurment.FindAsync(id);
            if (tegirmonUnitMeasurment == null)
            {
                return NotFound();
            }

            _context.TegirmonUnitMeasurment.Remove(tegirmonUnitMeasurment);
            await _context.SaveChangesAsync();

            return tegirmonUnitMeasurment;
        }

        private bool TegirmonUnitMeasurmentExists(long id)
        {
            return _context.TegirmonUnitMeasurment.Any(e => e.id == id);
        }
    }
}
