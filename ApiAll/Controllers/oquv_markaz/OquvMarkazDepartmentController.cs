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
    public class OquvMarkazDepartmentController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazDepartmentController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazDepartment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazDepartment>>> GetOquvMarkazDepartment()
        {
            return await _context.OquvMarkazDepartment.ToListAsync();
        }



        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazDepartment> categoryList = await _context.OquvMarkazDepartment.Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazDepartment>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazDepartment.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/OquvMarkazDepartment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazDepartment>> GetOquvMarkazDepartment(long id)
        {
            var oquvMarkazDepartment = await _context.OquvMarkazDepartment.FindAsync(id);

            if (oquvMarkazDepartment == null)
            {
                return NotFound();
            }

            return oquvMarkazDepartment;
        }

        // PUT: api/OquvMarkazDepartment/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazDepartment(long id, OquvMarkazDepartment oquvMarkazDepartment)
        {
            if (id != oquvMarkazDepartment.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazDepartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazDepartmentExists(id))
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

        // POST: api/OquvMarkazDepartment
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazDepartment>> PostOquvMarkazDepartment(OquvMarkazDepartment oquvMarkazDepartment)
        {
            _context.OquvMarkazDepartment.Update(oquvMarkazDepartment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazDepartment", new { id = oquvMarkazDepartment.id }, oquvMarkazDepartment);
        }

        // DELETE: api/OquvMarkazDepartment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazDepartment>> DeleteOquvMarkazDepartment(long id)
        {
            var oquvMarkazDepartment = await _context.OquvMarkazDepartment.FindAsync(id);
            if (oquvMarkazDepartment == null)
            {
                return NotFound();
            }

            _context.OquvMarkazDepartment.Remove(oquvMarkazDepartment);
            await _context.SaveChangesAsync();

            return oquvMarkazDepartment;
        }

        private bool OquvMarkazDepartmentExists(long id)
        {
            return _context.OquvMarkazDepartment.Any(e => e.id == id);
        }
    }
}
