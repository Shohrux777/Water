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
    public class TegirmonCheckInCheckOutDetailController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonCheckInCheckOutDetailController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonCheckInCheckOutDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonCheckInCheckOutDetail>>> GetTegirmonCheckInCheckOutDetail()
        {
            return await _context.TegirmonCheckInCheckOutDetail.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonCheckInCheckOutDetail> categoryList = await _context.TegirmonCheckInCheckOutDetail.Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonCheckInCheckOutDetail>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonCheckInCheckOutDetail.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TegirmonCheckInCheckOutDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonCheckInCheckOutDetail>> GetTegirmonCheckInCheckOutDetail(long id)
        {
            var tegirmonCheckInCheckOutDetail = await _context.TegirmonCheckInCheckOutDetail.FindAsync(id);

            if (tegirmonCheckInCheckOutDetail == null)
            {
                return NotFound();
            }

            return tegirmonCheckInCheckOutDetail;
        }

        // PUT: api/TegirmonCheckInCheckOutDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonCheckInCheckOutDetail(long id, TegirmonCheckInCheckOutDetail tegirmonCheckInCheckOutDetail)
        {
            if (id != tegirmonCheckInCheckOutDetail.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonCheckInCheckOutDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonCheckInCheckOutDetailExists(id))
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

        // POST: api/TegirmonCheckInCheckOutDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonCheckInCheckOutDetail>> PostTegirmonCheckInCheckOutDetail(TegirmonCheckInCheckOutDetail tegirmonCheckInCheckOutDetail)
        {
            _context.TegirmonCheckInCheckOutDetail.Update(tegirmonCheckInCheckOutDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonCheckInCheckOutDetail", new { id = tegirmonCheckInCheckOutDetail.id }, tegirmonCheckInCheckOutDetail);
        }

        // DELETE: api/TegirmonCheckInCheckOutDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonCheckInCheckOutDetail>> DeleteTegirmonCheckInCheckOutDetail(long id)
        {
            var tegirmonCheckInCheckOutDetail = await _context.TegirmonCheckInCheckOutDetail.FindAsync(id);
            if (tegirmonCheckInCheckOutDetail == null)
            {
                return NotFound();
            }

            _context.TegirmonCheckInCheckOutDetail.Remove(tegirmonCheckInCheckOutDetail);
            await _context.SaveChangesAsync();

            return tegirmonCheckInCheckOutDetail;
        }

        private bool TegirmonCheckInCheckOutDetailExists(long id)
        {
            return _context.TegirmonCheckInCheckOutDetail.Any(e => e.id == id);
        }
    }
}
