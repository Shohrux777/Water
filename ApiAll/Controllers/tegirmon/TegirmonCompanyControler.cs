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
    public class TegirmonCompanyControler : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonCompanyControler(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonCompanyControler
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonCompany>>> GetTegirmonCompany()
        {
            return await _context.TegirmonCompany.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonCompany> categoryList = await _context.TegirmonCompany
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonCompany>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonCompany.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TegirmonCompanyControler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonCompany>> GetTegirmonCompany(long id)
        {
            var tegirmonCompany = await _context.TegirmonCompany.FindAsync(id);

            if (tegirmonCompany == null)
            {
                return NotFound();
            }

            return tegirmonCompany;
        }

        // PUT: api/TegirmonCompanyControler/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonCompany(long id, TegirmonCompany tegirmonCompany)
        {
            if (id != tegirmonCompany.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonCompanyExists(id))
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

        // POST: api/TegirmonCompanyControler
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonCompany>> PostTegirmonCompany(TegirmonCompany tegirmonCompany)
        {
            _context.TegirmonCompany.Update(tegirmonCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonCompany", new { id = tegirmonCompany.id }, tegirmonCompany);
        }

        // DELETE: api/TegirmonCompanyControler/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonCompany>> DeleteTegirmonCompany(long id)
        {
            var tegirmonCompany = await _context.TegirmonCompany.FindAsync(id);
            if (tegirmonCompany == null)
            {
                return NotFound();
            }

            _context.TegirmonCompany.Remove(tegirmonCompany);
            await _context.SaveChangesAsync();

            return tegirmonCompany;
        }

        private bool TegirmonCompanyExists(long id)
        {
            return _context.TegirmonCompany.Any(e => e.id == id);
        }
    }
}
