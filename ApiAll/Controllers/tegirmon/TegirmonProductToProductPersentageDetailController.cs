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
    public class TegirmonProductToProductPersentageDetailController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonProductToProductPersentageDetailController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonProductToProductPersentageDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonProductToProductPersentageDetail>>> GetTegirmonProductToProductPersentageDetail()
        {
            return await _context.TegirmonProductToProductPersentageDetail.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonProductToProductPersentageDetail> categoryList = await _context.TegirmonProductToProductPersentageDetail
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonProductToProductPersentageDetail>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonProductToProductPersentageDetail.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TegirmonProductToProductPersentageDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonProductToProductPersentageDetail>> GetTegirmonProductToProductPersentageDetail(long id)
        {
            var tegirmonProductToProductPersentageDetail = await _context.TegirmonProductToProductPersentageDetail.FindAsync(id);

            if (tegirmonProductToProductPersentageDetail == null)
            {
                return NotFound();
            }

            return tegirmonProductToProductPersentageDetail;
        }

        // PUT: api/TegirmonProductToProductPersentageDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonProductToProductPersentageDetail(long id, TegirmonProductToProductPersentageDetail tegirmonProductToProductPersentageDetail)
        {
            if (id != tegirmonProductToProductPersentageDetail.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonProductToProductPersentageDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonProductToProductPersentageDetailExists(id))
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

        // POST: api/TegirmonProductToProductPersentageDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonProductToProductPersentageDetail>> PostTegirmonProductToProductPersentageDetail(TegirmonProductToProductPersentageDetail tegirmonProductToProductPersentageDetail)
        {
            _context.TegirmonProductToProductPersentageDetail.Update(tegirmonProductToProductPersentageDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonProductToProductPersentageDetail", new { id = tegirmonProductToProductPersentageDetail.id }, tegirmonProductToProductPersentageDetail);
        }

        // DELETE: api/TegirmonProductToProductPersentageDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonProductToProductPersentageDetail>> DeleteTegirmonProductToProductPersentageDetail(long id)
        {
            var tegirmonProductToProductPersentageDetail = await _context.TegirmonProductToProductPersentageDetail.FindAsync(id);
            if (tegirmonProductToProductPersentageDetail == null)
            {
                return NotFound();
            }

            _context.TegirmonProductToProductPersentageDetail.Remove(tegirmonProductToProductPersentageDetail);
            await _context.SaveChangesAsync();

            return tegirmonProductToProductPersentageDetail;
        }

        private bool TegirmonProductToProductPersentageDetailExists(long id)
        {
            return _context.TegirmonProductToProductPersentageDetail.Any(e => e.id == id);
        }
    }
}
