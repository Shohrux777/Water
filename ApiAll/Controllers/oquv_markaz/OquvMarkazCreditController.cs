using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.oquv_markaz;
using Newtonsoft.Json.Linq;
using ApiAll.Model.tekistil;

namespace ApiAll.Controllers.oquv_markaz
{
    [ApiExplorerSettings(GroupName = "v8")]
    [Route("api/[controller]")]
    [ApiController]
    public class OquvMarkazCreditController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazCreditController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazCredit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazCredit>>> GetOquvMarkazCredit()
        {
            return await _context.OquvMarkazCredit.ToListAsync();
        }

        // GET: api/OquvMarkazCredit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazCredit>> GetOquvMarkazCredit(long id)
        {
            var oquvMarkazCredit = await _context.OquvMarkazCredit.FindAsync(id);

            if (oquvMarkazCredit == null)
            {
                return NotFound();
            }

            return oquvMarkazCredit;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazCredit> categoryList = await _context.OquvMarkazCredit.Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazCredit>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazCredit.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/OquvMarkazCredit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazCredit(long id, OquvMarkazCredit oquvMarkazCredit)
        {
            if (id != oquvMarkazCredit.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazCredit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazCreditExists(id))
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

        // POST: api/OquvMarkazCredit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazCredit>> PostOquvMarkazCredit(OquvMarkazCredit oquvMarkazCredit)
        {
            _context.OquvMarkazCredit.Update(oquvMarkazCredit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazCredit", new { id = oquvMarkazCredit.id }, oquvMarkazCredit);
        }

        // DELETE: api/OquvMarkazCredit/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazCredit>> DeleteOquvMarkazCredit(long id)
        {
            var oquvMarkazCredit = await _context.OquvMarkazCredit.FindAsync(id);
            if (oquvMarkazCredit == null)
            {
                return NotFound();
            }

            _context.OquvMarkazCredit.Remove(oquvMarkazCredit);
            await _context.SaveChangesAsync();

            return oquvMarkazCredit;
        }

        private bool OquvMarkazCreditExists(long id)
        {
            return _context.OquvMarkazCredit.Any(e => e.id == id);
        }
    }
}
