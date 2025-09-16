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
    public class TegirmonCreditController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonCreditController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonCredit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonCredit>>> GetTegirmonCredit()
        {
            return await _context.TegirmonCredit.ToListAsync();
        }


        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonCredit> categoryList = await _context.TegirmonCredit
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonCredit>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonCredit
                .Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TegirmonCredit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonCredit>> GetTegirmonCredit(long id)
        {
            var tegirmonCredit = await _context.TegirmonCredit.FindAsync(id);

            if (tegirmonCredit == null)
            {
                return NotFound();
            }

            return tegirmonCredit;
        }

        // PUT: api/TegirmonCredit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonCredit(long id, TegirmonCredit tegirmonCredit)
        {
            if (id != tegirmonCredit.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonCredit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonCreditExists(id))
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

        // POST: api/TegirmonCredit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonCredit>> PostTegirmonCredit(TegirmonCredit tegirmonCredit)
        {
            _context.TegirmonCredit.Update(tegirmonCredit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonCredit", new { id = tegirmonCredit.id }, tegirmonCredit);
        }

        // DELETE: api/TegirmonCredit/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonCredit>> DeleteTegirmonCredit(long id)
        {
            var tegirmonCredit = await _context.TegirmonCredit.FindAsync(id);
            if (tegirmonCredit == null)
            {
                return NotFound();
            }

            _context.TegirmonCredit.Remove(tegirmonCredit);
            await _context.SaveChangesAsync();

            return tegirmonCredit;
        }

        private bool TegirmonCreditExists(long id)
        {
            return _context.TegirmonCredit.Any(e => e.id == id);
        }
    }
}
