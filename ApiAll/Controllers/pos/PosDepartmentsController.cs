using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.pos;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.pos
{
    [ApiExplorerSettings(GroupName = "v5")]
    [Route("api/[controller]")]
    [ApiController]
    public class PosDepartmentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosDepartmentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosDepartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosDepartment>>> GetPosDepartment()
        {
            return await _context.PosDepartment.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosDepartment> itemList = await _context.PosDepartment
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosDepartment>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosDepartment.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/PosDepartments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosDepartment>> GetPosDepartment(long id)
        {
            var posDepartment = await _context.PosDepartment.FindAsync(id);

            if (posDepartment == null)
            {
                return NotFound();
            }

            return posDepartment;
        }

        // PUT: api/PosDepartments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosDepartment(long id, PosDepartment posDepartment)
        {
            if (id != posDepartment.id)
            {
                return BadRequest();
            }

            _context.Entry(posDepartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosDepartmentExists(id))
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

        // POST: api/PosDepartments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosDepartment>> PostPosDepartment(PosDepartment posDepartment)
        {


            try
            {
                _context.PosDepartment.Update(posDepartment);
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

            return CreatedAtAction("GetPosDepartment", new { id = posDepartment.id }, posDepartment);
        }

        // DELETE: api/PosDepartments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosDepartment>> DeletePosDepartment(long id)
        {
            var posDepartment = await _context.PosDepartment.FindAsync(id);
            if (posDepartment == null)
            {
                return NotFound();
            }

            _context.PosDepartment.Remove(posDepartment);
            await _context.SaveChangesAsync();

            return posDepartment;
        }

        private bool PosDepartmentExists(long id)
        {
            return _context.PosDepartment.Any(e => e.id == id);
        }
    }
}
