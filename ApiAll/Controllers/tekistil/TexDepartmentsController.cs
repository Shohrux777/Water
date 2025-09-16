using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tekistil
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexDepartmentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexDepartmentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexDepartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexDepartment>>> GetTexDepartment()
        {
            return await _context.TexDepartment.Where(p => p.active_status == true).Include(p =>p.contragent).OrderByDescending( p => p.id).ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexDepartment> itemList = await _context.TexDepartment.Where(p => p.active_status == true).Include(p => p.contragent).Include( p => p.department).OrderByDescending(p => p.id).Skip(page * size).Take(size).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexDepartment>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexDepartment.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getDepatmentListByCompanyId")]
        public async Task<ActionResult<IEnumerable<TexDepartment>>> getDepatmentListByCompanyId([FromQuery] long company_id)
        {
            return await _context.TexDepartment.Where(p => p.active_status == true && p.company_id == company_id).Include(p => p.contragent).OrderByDescending(p => p.id).ToListAsync();
        }

        // GET: api/TexDepartments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexDepartment>> GetTexDepartment(long id)
        {
            var texDepartment = await _context.TexDepartment.FindAsync(id);

            if (texDepartment == null)
            {
                return NotFound();
            }
            texDepartment.contragent = await _context.TexContragent.FindAsync(texDepartment.company_id);
            texDepartment.department = await _context.TexDepartment.FindAsync(texDepartment.main_department_id);


            return texDepartment;
        }

        // PUT: api/TexDepartments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexDepartment(long id, TexDepartment texDepartment)
        {
            if (id != texDepartment.id)
            {
                return BadRequest();
            }

            _context.Entry(texDepartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexDepartmentExists(id))
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

        // POST: api/TexDepartments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexDepartment>> PostTexDepartment(TexDepartment texDepartment)
        {



            try
            {
            _context.TexDepartment.Update(texDepartment);
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


            return CreatedAtAction("GetTexDepartment", new { id = texDepartment.id }, texDepartment);
        }

        // DELETE: api/TexDepartments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexDepartment>> DeleteTexDepartment(long id)
        {
            var texDepartment = await _context.TexDepartment.FindAsync(id);
            if (texDepartment == null)
            {
                return NotFound();
            }
            texDepartment.active_status = false;
            _context.TexDepartment.Update(texDepartment);
            await _context.SaveChangesAsync();

            return texDepartment;
        }

        private bool TexDepartmentExists(long id)
        {
            return _context.TexDepartment.Any(e => e.id == id);
        }
    }
}
