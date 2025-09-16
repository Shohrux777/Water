using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.oquv_markaz;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.oquv_markaz
{
    [ApiExplorerSettings(GroupName = "v8")]
    [Route("api/[controller]")]
    [ApiController]
    public class OquvMarkazBookUnitsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazBookUnitsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazBookUnits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazBookUnit>>> GetOquvMarkazBookUnit()
        {
            return await _context.OquvMarkazBookUnit.ToListAsync();
        }

        [HttpGet("getPaginationByBookId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByBookId([FromQuery] int page, [FromQuery] int size,[FromQuery] long book_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazBookUnit> categoryList = await _context.OquvMarkazBookUnit
                .Include(p =>p.book)
                .Where(p => p.active_status == true && p.OquvMarkazBookid == book_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazBookUnit>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazBookUnit
                .Where(p => p.active_status == true && p.OquvMarkazBookid == book_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/OquvMarkazBookUnits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazBookUnit>> GetOquvMarkazBookUnit(long id)
        {
            var oquvMarkazBookUnit = await _context.OquvMarkazBookUnit.FindAsync(id);

            if (oquvMarkazBookUnit == null)
            {
                return NotFound();
            }

            return oquvMarkazBookUnit;
        }

        // PUT: api/OquvMarkazBookUnits/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazBookUnit(long id, OquvMarkazBookUnit oquvMarkazBookUnit)
        {
            if (id != oquvMarkazBookUnit.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazBookUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazBookUnitExists(id))
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

        // POST: api/OquvMarkazBookUnits
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazBookUnit>> PostOquvMarkazBookUnit(OquvMarkazBookUnit oquvMarkazBookUnit)
        {
            _context.OquvMarkazBookUnit.Update(oquvMarkazBookUnit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazBookUnit", new { id = oquvMarkazBookUnit.id }, oquvMarkazBookUnit);
        }

        // DELETE: api/OquvMarkazBookUnits/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazBookUnit>> DeleteOquvMarkazBookUnit(long id)
        {
            var oquvMarkazBookUnit = await _context.OquvMarkazBookUnit.FindAsync(id);
            if (oquvMarkazBookUnit == null)
            {
                return NotFound();
            }

            _context.OquvMarkazBookUnit.Remove(oquvMarkazBookUnit);
            await _context.SaveChangesAsync();

            return oquvMarkazBookUnit;
        }

        private bool OquvMarkazBookUnitExists(long id)
        {
            return _context.OquvMarkazBookUnit.Any(e => e.id == id);
        }
    }
}
