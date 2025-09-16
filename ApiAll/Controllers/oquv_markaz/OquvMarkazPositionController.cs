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
    public class OquvMarkazPositionController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazPositionController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazPosition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazPosition>>> GetOquvMarkazPosition()
        {
            return await _context.OquvMarkazPosition.ToListAsync();
        }

        // GET: api/OquvMarkazPosition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazPosition>> GetOquvMarkazPosition(long id)
        {
            var oquvMarkazPosition = await _context.OquvMarkazPosition.FindAsync(id);

            if (oquvMarkazPosition == null)
            {
                return NotFound();
            }

            return oquvMarkazPosition;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazPosition> categoryList = await _context.OquvMarkazPosition.Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazPosition>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazPosition.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/OquvMarkazPosition/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazPosition(long id, OquvMarkazPosition oquvMarkazPosition)
        {
            if (id != oquvMarkazPosition.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazPosition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazPositionExists(id))
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

        // POST: api/OquvMarkazPosition
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazPosition>> PostOquvMarkazPosition(OquvMarkazPosition oquvMarkazPosition)
        {
            _context.OquvMarkazPosition.Update(oquvMarkazPosition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazPosition", new { id = oquvMarkazPosition.id }, oquvMarkazPosition);
        }

        // DELETE: api/OquvMarkazPosition/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazPosition>> DeleteOquvMarkazPosition(long id)
        {
            var oquvMarkazPosition = await _context.OquvMarkazPosition.FindAsync(id);
            if (oquvMarkazPosition == null)
            {
                return NotFound();
            }

            _context.OquvMarkazPosition.Remove(oquvMarkazPosition);
            await _context.SaveChangesAsync();

            return oquvMarkazPosition;
        }

        private bool OquvMarkazPositionExists(long id)
        {
            return _context.OquvMarkazPosition.Any(e => e.id == id);
        }
    }
}
