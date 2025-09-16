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
    public class OquvMarkazPaymentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazPaymentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazPayments>>> GetOquvMarkazPayments()
        {
            return await _context.OquvMarkazPayments.ToListAsync();
        }

        // GET: api/OquvMarkazPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazPayments>> GetOquvMarkazPayments(long id)
        {
            var oquvMarkazPayments = await _context.OquvMarkazPayments.FindAsync(id);

            if (oquvMarkazPayments == null)
            {
                return NotFound();
            }

            return oquvMarkazPayments;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazPayments> categoryList = await _context.OquvMarkazPayments.Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazPayments>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazPayments.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/OquvMarkazPayments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazPayments(long id, OquvMarkazPayments oquvMarkazPayments)
        {
            if (id != oquvMarkazPayments.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazPayments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazPaymentsExists(id))
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

        // POST: api/OquvMarkazPayments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazPayments>> PostOquvMarkazPayments(OquvMarkazPayments oquvMarkazPayments)
        {
            _context.OquvMarkazPayments.Update(oquvMarkazPayments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazPayments", new { id = oquvMarkazPayments.id }, oquvMarkazPayments);
        }

        // DELETE: api/OquvMarkazPayments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazPayments>> DeleteOquvMarkazPayments(long id)
        {
            var oquvMarkazPayments = await _context.OquvMarkazPayments.FindAsync(id);
            if (oquvMarkazPayments == null)
            {
                return NotFound();
            }

            _context.OquvMarkazPayments.Remove(oquvMarkazPayments);
            await _context.SaveChangesAsync();

            return oquvMarkazPayments;
        }

        private bool OquvMarkazPaymentsExists(long id)
        {
            return _context.OquvMarkazPayments.Any(e => e.id == id);
        }
    }
}
