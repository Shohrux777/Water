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
    public class TegirmonDebitDetailController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonDebitDetailController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonDebitDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonDebitDetail>>> GetTegirmonDebitDetail()
        {
            return await _context.TegirmonDebitDetail.ToListAsync();
        }
        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonDebitDetail> categoryList = await _context.TegirmonDebitDetail
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonDebitDetail>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonDebitDetail
                .Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // GET: api/TegirmonDebitDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonDebitDetail>> GetTegirmonDebitDetail(long id)
        {
            var tegirmonDebitDetail = await _context.TegirmonDebitDetail.FindAsync(id);

            if (tegirmonDebitDetail == null)
            {
                return NotFound();
            }

            return tegirmonDebitDetail;
        }

        // PUT: api/TegirmonDebitDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonDebitDetail(long id, TegirmonDebitDetail tegirmonDebitDetail)
        {
            if (id != tegirmonDebitDetail.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonDebitDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonDebitDetailExists(id))
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

        // POST: api/TegirmonDebitDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonDebitDetail>> PostTegirmonDebitDetail(TegirmonDebitDetail tegirmonDebitDetail)
        {
            _context.TegirmonDebitDetail.Update(tegirmonDebitDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonDebitDetail", new { id = tegirmonDebitDetail.id }, tegirmonDebitDetail);
        }

        // DELETE: api/TegirmonDebitDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonDebitDetail>> DeleteTegirmonDebitDetail(long id)
        {
            var tegirmonDebitDetail = await _context.TegirmonDebitDetail.FindAsync(id);
            if (tegirmonDebitDetail == null)
            {
                return NotFound();
            }

            _context.TegirmonDebitDetail.Remove(tegirmonDebitDetail);
            await _context.SaveChangesAsync();

            return tegirmonDebitDetail;
        }

        private bool TegirmonDebitDetailExists(long id)
        {
            return _context.TegirmonDebitDetail.Any(e => e.id == id);
        }
    }
}
