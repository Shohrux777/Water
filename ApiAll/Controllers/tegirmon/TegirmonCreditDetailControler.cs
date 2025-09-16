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
    public class TegirmonCreditDetailControler : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonCreditDetailControler(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonCreditDetailControler
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonCreditDetail>>> GetTegirmonCreditDetail()
        {
            return await _context.TegirmonCreditDetail.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonCreditDetail> categoryList = await _context.TegirmonCreditDetail
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonCreditDetail>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonCreditDetail
                .Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TegirmonCreditDetailControler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonCreditDetail>> GetTegirmonCreditDetail(long id)
        {
            var tegirmonCreditDetail = await _context.TegirmonCreditDetail.FindAsync(id);

            if (tegirmonCreditDetail == null)
            {
                return NotFound();
            }

            return tegirmonCreditDetail;
        }

        // PUT: api/TegirmonCreditDetailControler/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonCreditDetail(long id, TegirmonCreditDetail tegirmonCreditDetail)
        {
            if (id != tegirmonCreditDetail.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonCreditDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonCreditDetailExists(id))
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

        // POST: api/TegirmonCreditDetailControler
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonCreditDetail>> PostTegirmonCreditDetail(TegirmonCreditDetail tegirmonCreditDetail)
        {
            _context.TegirmonCreditDetail.Update(tegirmonCreditDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonCreditDetail", new { id = tegirmonCreditDetail.id }, tegirmonCreditDetail);
        }

        // DELETE: api/TegirmonCreditDetailControler/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonCreditDetail>> DeleteTegirmonCreditDetail(long id)
        {
            var tegirmonCreditDetail = await _context.TegirmonCreditDetail.FindAsync(id);
            if (tegirmonCreditDetail == null)
            {
                return NotFound();
            }

            _context.TegirmonCreditDetail.Remove(tegirmonCreditDetail);
            await _context.SaveChangesAsync();

            return tegirmonCreditDetail;
        }

        private bool TegirmonCreditDetailExists(long id)
        {
            return _context.TegirmonCreditDetail.Any(e => e.id == id);
        }
    }
}
