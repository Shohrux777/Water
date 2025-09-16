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
    public class TegirmonTortilganBugdoyRoyxatiGroupDetailsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonTortilganBugdoyRoyxatiGroupDetailsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonTortilganBugdoyRoyxatiGroupDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonTortilganBugdoyRoyxatiGroupDetail>>> GetTegirmonTortilganBugdoyRoyxatiGroupDetail()
        {
            return await _context.TegirmonTortilganBugdoyRoyxatiGroupDetail.ToListAsync();
        }



        // GET: api/TegirmonTortilganBugdoyRoyxatiGroupDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonTortilganBugdoyRoyxatiGroupDetail>> GetTegirmonTortilganBugdoyRoyxatiGroupDetail(long id)
        {
            var tegirmonTortilganBugdoyRoyxatiGroupDetail = await _context.TegirmonTortilganBugdoyRoyxatiGroupDetail.FindAsync(id);

            if (tegirmonTortilganBugdoyRoyxatiGroupDetail == null)
            {
                return NotFound();
            }

            return tegirmonTortilganBugdoyRoyxatiGroupDetail;
        }


        [HttpGet("getPaginationByGroupId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByGroupId([FromQuery] int page, [FromQuery] int size,[FromQuery] long group_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonTortilganBugdoyRoyxatiGroupDetail> categoryList = 
                await _context.TegirmonTortilganBugdoyRoyxatiGroupDetail
                .Include(p =>p.royxati)
                .ThenInclude(p =>p.product)
                .Include(p =>p.invoice)
                .ThenInclude(p =>p.item_list).ThenInclude(p =>p.product)
                .Where(p => p.active_status == true && p.TegirmonTortilganBugdoyRoyxatiGroupid == group_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonTortilganBugdoyRoyxatiGroupDetail>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonTortilganBugdoyRoyxatiGroupDetail
                .Where(p => p.active_status == true && p.TegirmonTortilganBugdoyRoyxatiGroupid == group_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/TegirmonTortilganBugdoyRoyxatiGroupDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonTortilganBugdoyRoyxatiGroupDetail(long id, TegirmonTortilganBugdoyRoyxatiGroupDetail tegirmonTortilganBugdoyRoyxatiGroupDetail)
        {
            if (id != tegirmonTortilganBugdoyRoyxatiGroupDetail.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonTortilganBugdoyRoyxatiGroupDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonTortilganBugdoyRoyxatiGroupDetailExists(id))
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

        // POST: api/TegirmonTortilganBugdoyRoyxatiGroupDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonTortilganBugdoyRoyxatiGroupDetail>> PostTegirmonTortilganBugdoyRoyxatiGroupDetail(TegirmonTortilganBugdoyRoyxatiGroupDetail tegirmonTortilganBugdoyRoyxatiGroupDetail)
        {
            _context.TegirmonTortilganBugdoyRoyxatiGroupDetail.Update(tegirmonTortilganBugdoyRoyxatiGroupDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonTortilganBugdoyRoyxatiGroupDetail", new { id = tegirmonTortilganBugdoyRoyxatiGroupDetail.id }, tegirmonTortilganBugdoyRoyxatiGroupDetail);
        }

        // DELETE: api/TegirmonTortilganBugdoyRoyxatiGroupDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonTortilganBugdoyRoyxatiGroupDetail>> DeleteTegirmonTortilganBugdoyRoyxatiGroupDetail(long id)
        {
            var tegirmonTortilganBugdoyRoyxatiGroupDetail = await _context.TegirmonTortilganBugdoyRoyxatiGroupDetail.FindAsync(id);
            if (tegirmonTortilganBugdoyRoyxatiGroupDetail == null)
            {
                return NotFound();
            }

            _context.TegirmonTortilganBugdoyRoyxatiGroupDetail.Remove(tegirmonTortilganBugdoyRoyxatiGroupDetail);
            await _context.SaveChangesAsync();

            return tegirmonTortilganBugdoyRoyxatiGroupDetail;
        }

        private bool TegirmonTortilganBugdoyRoyxatiGroupDetailExists(long id)
        {
            return _context.TegirmonTortilganBugdoyRoyxatiGroupDetail.Any(e => e.id == id);
        }
    }
}
