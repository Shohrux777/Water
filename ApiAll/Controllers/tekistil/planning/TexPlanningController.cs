using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil.planning;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tekistil.planning
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexPlanningController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexPlanningController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexPlanning
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexPlanning>>> GetTexPlanning()
        {
            return await _context.TexPlanning.ToListAsync();
        }

        // GET: api/TexPlanning/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexPlanning>> GetTexPlanning(long id)
        {
            var texPlanning = await _context.TexPlanning.FindAsync(id);

            if (texPlanning == null)
            {
                return NotFound();
            }

            return texPlanning;
        }

        // PUT: api/TexPlanning/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexPlanning(long id, TexPlanning texPlanning)
        {
            if (id != texPlanning.id)
            {
                return BadRequest();
            }

            _context.Entry(texPlanning).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexPlanningExists(id))
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

        // POST: api/TexPlanning
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexPlanning>> PostTexPlanning(TexPlanning texPlanning)
        {
            _context.TexPlanning.Update(texPlanning);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexPlanning", new { id = texPlanning.id }, texPlanning);
        }



        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexPlanning> categoryList = await _context.TexPlanning.Where(p => p.active_status == true)
                .Include(p => p.raskladki)
                .Include(p => p.items_list)

                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TexPlanning>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TexPlanning.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // DELETE: api/TexPlanning/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexPlanning>> DeleteTexPlanning(long id)
        {
            var texPlanning = await _context.TexPlanning.FindAsync(id);
            if (texPlanning == null)
            {
                return NotFound();
            }

            _context.TexPlanning.Remove(texPlanning);
            await _context.SaveChangesAsync();

            return texPlanning;
        }

        private bool TexPlanningExists(long id)
        {
            return _context.TexPlanning.Any(e => e.id == id);
        }
    }
}
