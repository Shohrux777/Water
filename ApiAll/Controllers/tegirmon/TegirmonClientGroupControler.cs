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
    public class TegirmonClientGroupControler : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonClientGroupControler(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonClientGroupControler
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonClientGroup>>> GetTegirmonClientGroup()
        {
            return await _context.TegirmonClientGroup.ToListAsync();

    
        }

        [HttpGet("changeAllStatusForFalseOrTrue")]
        public async Task<ActionResult<IEnumerable<TegirmonClientGroup>>> changeAllStatusForFalseOrTrue([FromQuery] bool status)
        {
            List<TegirmonClientGroup> items = await _context.TegirmonClientGroup.ToListAsync();
            foreach (TegirmonClientGroup it in items)
            {
                it.active_status = status;
            }

            _context.TegirmonClientGroup.UpdateRange(items);
            await _context.SaveChangesAsync();

            return new List<TegirmonClientGroup>();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonClientGroup> categoryList = await _context.TegirmonClientGroup
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonClientGroup>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonClientGroup.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TegirmonClientGroupControler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonClientGroup>> GetTegirmonClientGroup(long id)
        {
            var tegirmonClientGroup = await _context.TegirmonClientGroup.FindAsync(id);

            if (tegirmonClientGroup == null)
            {
                return NotFound();
            }

            return tegirmonClientGroup;
        }

        [HttpGet("disableGroupNotPublic")]
        public async Task<ActionResult<TegirmonClientGroup>> disableGroupNotPublic([FromQuery]long id)
        {
            var tegirmonClientGroup = await _context.TegirmonClientGroup.FindAsync(id);

            if (tegirmonClientGroup == null)
            {
                return NotFound();
            }
            tegirmonClientGroup.active_status = false;
            _context.TegirmonClientGroup.Update(tegirmonClientGroup);
            await _context.SaveChangesAsync();

            return tegirmonClientGroup;
        }

        // PUT: api/TegirmonClientGroupControler/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonClientGroup(long id, TegirmonClientGroup tegirmonClientGroup)
        {
            if (id != tegirmonClientGroup.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonClientGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonClientGroupExists(id))
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

        // POST: api/TegirmonClientGroupControler
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonClientGroup>> PostTegirmonClientGroup(TegirmonClientGroup tegirmonClientGroup)
        {
            _context.TegirmonClientGroup.Update(tegirmonClientGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonClientGroup", new { id = tegirmonClientGroup.id }, tegirmonClientGroup);
        }

        // DELETE: api/TegirmonClientGroupControler/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonClientGroup>> DeleteTegirmonClientGroup(long id)
        {
            var tegirmonClientGroup = await _context.TegirmonClientGroup.FindAsync(id);
            if (tegirmonClientGroup == null)
            {
                return NotFound();
            }

            _context.TegirmonClientGroup.Remove(tegirmonClientGroup);
            await _context.SaveChangesAsync();

            return tegirmonClientGroup;
        }

        private bool TegirmonClientGroupExists(long id)
        {
            return _context.TegirmonClientGroup.Any(e => e.id == id);
        }
    }
}
