using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tegirmon;
using Newtonsoft.Json.Linq;
using ApiAll.Model.tekistil;

namespace ApiAll.Controllers.tegirmon
{
    [ApiExplorerSettings(GroupName = "v7")]
    [Route("api/[controller]")]
    [ApiController]
    public class TegirmonDebitProductDetailController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonDebitProductDetailController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonDebitProductDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonDebitProductDetail>>> GetTegirmonDebitProductDetail()
        {
            return await _context.TegirmonDebitProductDetail.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonDebitProductDetail> categoryList = await _context.TegirmonDebitProductDetail
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonDebitProductDetail>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonDebitProductDetail
                .Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TegirmonDebitProductDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonDebitProductDetail>> GetTegirmonDebitProductDetail(long id)
        {
            var tegirmonDebitProductDetail = await _context.TegirmonDebitProductDetail.FindAsync(id);

            if (tegirmonDebitProductDetail == null)
            {
                return NotFound();
            }

            return tegirmonDebitProductDetail;
        }

        // PUT: api/TegirmonDebitProductDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonDebitProductDetail(long id, TegirmonDebitProductDetail tegirmonDebitProductDetail)
        {
            if (id != tegirmonDebitProductDetail.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonDebitProductDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonDebitProductDetailExists(id))
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

        // POST: api/TegirmonDebitProductDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonDebitProductDetail>> PostTegirmonDebitProductDetail(TegirmonDebitProductDetail tegirmonDebitProductDetail)
        {
            _context.TegirmonDebitProductDetail.Update(tegirmonDebitProductDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonDebitProductDetail", new { id = tegirmonDebitProductDetail.id }, tegirmonDebitProductDetail);
        }

        // DELETE: api/TegirmonDebitProductDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonDebitProductDetail>> DeleteTegirmonDebitProductDetail(long id)
        {
            var tegirmonDebitProductDetail = await _context.TegirmonDebitProductDetail.FindAsync(id);
            if (tegirmonDebitProductDetail == null)
            {
                return NotFound();
            }

            _context.TegirmonDebitProductDetail.Remove(tegirmonDebitProductDetail);
            await _context.SaveChangesAsync();

            return tegirmonDebitProductDetail;
        }

        private bool TegirmonDebitProductDetailExists(long id)
        {
            return _context.TegirmonDebitProductDetail.Any(e => e.id == id);
        }
    }
}
