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
    public class TegirmonDepartmentController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonDepartmentController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonDepartment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonDepartment>>> GetTegirmonDepartment()
        {
            return await _context.TegirmonDepartment.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonDepartment> categoryList = await _context.TegirmonDepartment
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonDepartment>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonDepartment
                .Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TegirmonDepartment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonDepartment>> GetTegirmonDepartment(long id)
        {
            var tegirmonDepartment = await _context.TegirmonDepartment.FindAsync(id);

            if (tegirmonDepartment == null)
            {
                return NotFound();
            }

            return tegirmonDepartment;
        }

        // PUT: api/TegirmonDepartment/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonDepartment(long id, TegirmonDepartment tegirmonDepartment)
        {
            if (id != tegirmonDepartment.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonDepartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonDepartmentExists(id))
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

        // POST: api/TegirmonDepartment
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonDepartment>> PostTegirmonDepartment(TegirmonDepartment tegirmonDepartment)
        {
            _context.TegirmonDepartment.Update(tegirmonDepartment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonDepartment", new { id = tegirmonDepartment.id }, tegirmonDepartment);
        }

        // DELETE: api/TegirmonDepartment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonDepartment>> DeleteTegirmonDepartment(long id)
        {
            var tegirmonDepartment = await _context.TegirmonDepartment.FindAsync(id);
            if (tegirmonDepartment == null)
            {
                return NotFound();
            }

            _context.TegirmonDepartment.Remove(tegirmonDepartment);
            await _context.SaveChangesAsync();

            return tegirmonDepartment;
        }

        private bool TegirmonDepartmentExists(long id)
        {
            return _context.TegirmonDepartment.Any(e => e.id == id);
        }
    }
}
