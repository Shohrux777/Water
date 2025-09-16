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
    public class TegirmonDebitController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonDebitController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonDebit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonDebit>>> GetTegirmonDebit()
        {
            return await _context.TegirmonDebit.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonDebit> categoryList = await _context.TegirmonDebit
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonDebit>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonDebit
                .Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TegirmonDebit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonDebit>> GetTegirmonDebit(long id)
        {
            var tegirmonDebit = await _context.TegirmonDebit.FindAsync(id);

            if (tegirmonDebit == null)
            {
                return NotFound();
            }

            return tegirmonDebit;
        }

        // PUT: api/TegirmonDebit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonDebit(long id, TegirmonDebit tegirmonDebit)
        {
            if (id != tegirmonDebit.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonDebit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonDebitExists(id))
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

        // POST: api/TegirmonDebit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonDebit>> PostTegirmonDebit(TegirmonDebit tegirmonDebit)
        {
            _context.TegirmonDebit.Update(tegirmonDebit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonDebit", new { id = tegirmonDebit.id }, tegirmonDebit);
        }

        // DELETE: api/TegirmonDebit/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonDebit>> DeleteTegirmonDebit(long id)
        {
            var tegirmonDebit = await _context.TegirmonDebit.FindAsync(id);
            if (tegirmonDebit == null)
            {
                return NotFound();
            }

            _context.TegirmonDebit.Remove(tegirmonDebit);
            await _context.SaveChangesAsync();

            return tegirmonDebit;
        }

        private bool TegirmonDebitExists(long id)
        {
            return _context.TegirmonDebit.Any(e => e.id == id);
        }
    }
}
