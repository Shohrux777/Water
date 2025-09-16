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
    public class TegirmonTortilganBugdoyRoyxatiGroupsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonTortilganBugdoyRoyxatiGroupsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonTortilganBugdoyRoyxatiGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonTortilganBugdoyRoyxatiGroup>>> GetTegirmonTortilganBugdoyRoyxatiGroup()
        {
            return await _context.TegirmonTortilganBugdoyRoyxatiGroup.ToListAsync();
        }

        // GET: api/TegirmonTortilganBugdoyRoyxatiGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonTortilganBugdoyRoyxatiGroup>> GetTegirmonTortilganBugdoyRoyxatiGroup(long id)
        {
            var tegirmonTortilganBugdoyRoyxatiGroup = await _context.TegirmonTortilganBugdoyRoyxatiGroup.FindAsync(id);

            if (tegirmonTortilganBugdoyRoyxatiGroup == null)
            {
                return NotFound();
            }

            return tegirmonTortilganBugdoyRoyxatiGroup;
        }

        [HttpGet("acceptTegirmonTortilganBugdoyRoyxatiGroup")]
        public async Task<ActionResult<TegirmonTortilganBugdoyRoyxatiGroup>> acceptTegirmonTortilganBugdoyRoyxatiGroup([FromQuery]long id)
        {
            var tegirmonTortilganBugdoyRoyxatiGroup = await _context.TegirmonTortilganBugdoyRoyxatiGroup.FindAsync(id);

            if (tegirmonTortilganBugdoyRoyxatiGroup == null)
            {
                return NotFound();
            }

            tegirmonTortilganBugdoyRoyxatiGroup.accepted_status = true;

            List<TegirmonTortilganBugdoyRoyxatiGroupDetail> detail_list = await _context.TegirmonTortilganBugdoyRoyxatiGroupDetail
                .Include(p =>p.royxati)
                .Include(p => p.invoice)
                .Where(p => p.TegirmonTortilganBugdoyRoyxatiGroupid == id)
                .ToListAsync();


            //details for accepted and invoice
            if (detail_list != null && detail_list.Count > 0) {

                foreach (TegirmonTortilganBugdoyRoyxatiGroupDetail item in detail_list) {
                    item.royxati.accepted_get_value = true;
                    item.invoice.inv_accepted_status = true;
                }

                //update
                _context.TegirmonTortilganBugdoyRoyxatiGroupDetail.UpdateRange(detail_list);
                await _context.SaveChangesAsync();

            }

          



            //update
            _context.TegirmonTortilganBugdoyRoyxatiGroup.Update(tegirmonTortilganBugdoyRoyxatiGroup);
            await _context.SaveChangesAsync();

            return tegirmonTortilganBugdoyRoyxatiGroup;
        }

        [HttpGet("getPaginationOnlyNotAccepted")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationOnlyNotAccepted([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonTortilganBugdoyRoyxatiGroup> categoryList = await _context.TegirmonTortilganBugdoyRoyxatiGroup
                .Where(p => p.active_status == true && p.accepted_status == false)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonTortilganBugdoyRoyxatiGroup>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonTortilganBugdoyRoyxatiGroup
                .Where(p => p.active_status == true && p.accepted_status == false).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationOnlyAcceptedByDate")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationOnlyAcceptedByDate([FromQuery] int page, [FromQuery] int size,[FromQuery] DateTime begin_date,[FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonTortilganBugdoyRoyxatiGroup> categoryList = await _context.TegirmonTortilganBugdoyRoyxatiGroup
                .Where(p => p.active_status == true
                && p.accepted_status == true
                && (p.date_time >= begin_date && p.date_time <= end_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonTortilganBugdoyRoyxatiGroup>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonTortilganBugdoyRoyxatiGroup
                .Where(p => p.active_status == true
                && p.accepted_status == true
                && (p.date_time >= begin_date && p.date_time <= end_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationAll")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationAll([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonTortilganBugdoyRoyxatiGroup> categoryList = await _context.TegirmonTortilganBugdoyRoyxatiGroup
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonTortilganBugdoyRoyxatiGroup>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonTortilganBugdoyRoyxatiGroup
                .Where(p => p.active_status == true ).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationSearchByNameOrCarNumber")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationSearchByNameOrCarNumber([FromQuery] int page, [FromQuery] int size,[FromQuery] String name)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonTortilganBugdoyRoyxatiGroup> categoryList = await _context.TegirmonTortilganBugdoyRoyxatiGroup
                .Where(p => p.active_status == true 
                && (p.name.ToLower().Contains(name.ToLower()) 
                || p.car_number.ToLower().Contains(name.ToLower())))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonTortilganBugdoyRoyxatiGroup>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonTortilganBugdoyRoyxatiGroup
                .Where(p => p.active_status == true
                && (p.name.ToLower().Contains(name.ToLower())
                || p.car_number.ToLower().Contains(name.ToLower()))).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/TegirmonTortilganBugdoyRoyxatiGroups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonTortilganBugdoyRoyxatiGroup(long id, TegirmonTortilganBugdoyRoyxatiGroup tegirmonTortilganBugdoyRoyxatiGroup)
        {
            if (id != tegirmonTortilganBugdoyRoyxatiGroup.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonTortilganBugdoyRoyxatiGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonTortilganBugdoyRoyxatiGroupExists(id))
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

        // POST: api/TegirmonTortilganBugdoyRoyxatiGroups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonTortilganBugdoyRoyxatiGroup>> PostTegirmonTortilganBugdoyRoyxatiGroup(TegirmonTortilganBugdoyRoyxatiGroup tegirmonTortilganBugdoyRoyxatiGroup)
        {
            _context.TegirmonTortilganBugdoyRoyxatiGroup.Update(tegirmonTortilganBugdoyRoyxatiGroup);
            await _context.SaveChangesAsync();

            return tegirmonTortilganBugdoyRoyxatiGroup;
        }

        // DELETE: api/TegirmonTortilganBugdoyRoyxatiGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonTortilganBugdoyRoyxatiGroup>> DeleteTegirmonTortilganBugdoyRoyxatiGroup(long id)
        {
            var tegirmonTortilganBugdoyRoyxatiGroup = await _context.TegirmonTortilganBugdoyRoyxatiGroup.FindAsync(id);
            if (tegirmonTortilganBugdoyRoyxatiGroup == null)
            {
                return NotFound();
            }

            _context.TegirmonTortilganBugdoyRoyxatiGroup.Remove(tegirmonTortilganBugdoyRoyxatiGroup);
            await _context.SaveChangesAsync();

            return tegirmonTortilganBugdoyRoyxatiGroup;
        }

        private bool TegirmonTortilganBugdoyRoyxatiGroupExists(long id)
        {
            return _context.TegirmonTortilganBugdoyRoyxatiGroup.Any(e => e.id == id);
        }
    }
}
