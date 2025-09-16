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
    public class OquvMarkazCompanyController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazCompanyController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazCompany
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazCompany>>> GetOquvMarkazCompany()
        {
            return await _context.OquvMarkazCompany.ToListAsync();
        }

        // GET: api/OquvMarkazCompany/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazCompany>> GetOquvMarkazCompany(long id)
        {
            var oquvMarkazCompany = await _context.OquvMarkazCompany.FindAsync(id);

            if (oquvMarkazCompany == null)
            {
                return NotFound();
            }

            return oquvMarkazCompany;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazCompany> categoryList = await _context.OquvMarkazCompany.Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazCompany>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazCompany.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/OquvMarkazCompany/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazCompany(long id, OquvMarkazCompany oquvMarkazCompany)
        {
            if (id != oquvMarkazCompany.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazCompanyExists(id))
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

        // POST: api/OquvMarkazCompany
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazCompany>> PostOquvMarkazCompany(OquvMarkazCompany oquvMarkazCompany)
        {
            _context.OquvMarkazCompany.Update(oquvMarkazCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazCompany", new { id = oquvMarkazCompany.id }, oquvMarkazCompany);
        }

        // DELETE: api/OquvMarkazCompany/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazCompany>> DeleteOquvMarkazCompany(long id)
        {
            var oquvMarkazCompany = await _context.OquvMarkazCompany.FindAsync(id);
            if (oquvMarkazCompany == null)
            {
                return NotFound();
            }

            _context.OquvMarkazCompany.Remove(oquvMarkazCompany);
            await _context.SaveChangesAsync();

            return oquvMarkazCompany;
        }

        private bool OquvMarkazCompanyExists(long id)
        {
            return _context.OquvMarkazCompany.Any(e => e.id == id);
        }
    }
}
