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
    public class TegirmonInvoiceTypeController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonInvoiceTypeController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonInvoiceType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonInvoiceType>>> GetTegirmonInvoiceType()
        {
            return await _context.TegirmonInvoiceType.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonInvoiceType> categoryList = await _context.TegirmonInvoiceType
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonInvoiceType>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonInvoiceType
                .Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // GET: api/TegirmonInvoiceType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonInvoiceType>> GetTegirmonInvoiceType(long id)
        {
            var tegirmonInvoiceType = await _context.TegirmonInvoiceType.FindAsync(id);

            if (tegirmonInvoiceType == null)
            {
                return NotFound();
            }

            return tegirmonInvoiceType;
        }

        // PUT: api/TegirmonInvoiceType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonInvoiceType(long id, TegirmonInvoiceType tegirmonInvoiceType)
        {
            if (id != tegirmonInvoiceType.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonInvoiceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonInvoiceTypeExists(id))
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

        // POST: api/TegirmonInvoiceType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonInvoiceType>> PostTegirmonInvoiceType(TegirmonInvoiceType tegirmonInvoiceType)
        {
            _context.TegirmonInvoiceType.Update(tegirmonInvoiceType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonInvoiceType", new { id = tegirmonInvoiceType.id }, tegirmonInvoiceType);
        }

        // DELETE: api/TegirmonInvoiceType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonInvoiceType>> DeleteTegirmonInvoiceType(long id)
        {
            var tegirmonInvoiceType = await _context.TegirmonInvoiceType.FindAsync(id);
            if (tegirmonInvoiceType == null)
            {
                return NotFound();
            }

            _context.TegirmonInvoiceType.Remove(tegirmonInvoiceType);
            await _context.SaveChangesAsync();

            return tegirmonInvoiceType;
        }

        private bool TegirmonInvoiceTypeExists(long id)
        {
            return _context.TegirmonInvoiceType.Any(e => e.id == id);
        }
    }
}
