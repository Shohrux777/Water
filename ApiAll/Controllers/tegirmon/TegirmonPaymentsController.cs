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
    public class TegirmonPaymentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonPaymentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonPayments>>> GetTegirmonPayments()
        {
            return await _context.TegirmonPayments.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonPayments> categoryList = await _context.TegirmonPayments
                .Include(p =>p.product)
                .ThenInclude(p => p.unitMeasurment)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonPayments>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonPayments
                .Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TegirmonPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonPayments>> GetTegirmonPayments(long id)
        {
            var tegirmonPayments = await _context.TegirmonPayments.FindAsync(id);

            if (tegirmonPayments == null)
            {
                return NotFound();
            }

            return tegirmonPayments;
        }

        // PUT: api/TegirmonPayments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonPayments(long id, TegirmonPayments tegirmonPayments)
        {
            if (id != tegirmonPayments.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonPayments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonPaymentsExists(id))
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

        // POST: api/TegirmonPayments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonPayments>> PostTegirmonPayments(TegirmonPayments tegirmonPayments)
        {
            _context.TegirmonPayments.Update(tegirmonPayments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonPayments", new { id = tegirmonPayments.id }, tegirmonPayments);
        }

        // DELETE: api/TegirmonPayments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonPayments>> DeleteTegirmonPayments(long id)
        {
            var tegirmonPayments = await _context.TegirmonPayments.FindAsync(id);
            if (tegirmonPayments == null)
            {
                return NotFound();
            }

            _context.TegirmonPayments.Remove(tegirmonPayments);
            await _context.SaveChangesAsync();

            return tegirmonPayments;
        }

        private bool TegirmonPaymentsExists(long id)
        {
            return _context.TegirmonPayments.Any(e => e.id == id);
        }
    }
}
