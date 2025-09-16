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
    public class OquvMarkazPupilGroupsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazPupilGroupsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazPupilGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazPupilGroups>>> GetOquvMarkazPupilGroups()
        {
            return await _context.OquvMarkazPupilGroups.ToListAsync();
        }

        // GET: api/OquvMarkazPupilGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazPupilGroups>> GetOquvMarkazPupilGroups(long id)
        {
            var oquvMarkazPupilGroups = await _context.OquvMarkazPupilGroups
                .Include(p => p.fan)
                .Include(p => p.user)
                .Where(p =>p.id == id)
                .ToListAsync();

            if (oquvMarkazPupilGroups == null && oquvMarkazPupilGroups.Count == 0)
            {
                return NotFound();
            }

            return oquvMarkazPupilGroups.First();
        }

        [HttpGet("getOpenOrCloseGroupByidAndStatus")]
        public async Task<ActionResult<OquvMarkazPupilGroups>> getOpenOrCloseGroupByidAndStatus([FromQuery]long group_id,[FromQuery] bool status)
        {
            var oquvMarkazPupilGroups = await _context.OquvMarkazPupilGroups.FindAsync(group_id);
            
            if (oquvMarkazPupilGroups == null)
            {
                return NotFound();
            }
            oquvMarkazPupilGroups.opened_group_status = status;
            _context.OquvMarkazPupilGroups.Update(oquvMarkazPupilGroups);
            await _context.SaveChangesAsync();

            return oquvMarkazPupilGroups;
        }



        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazPupilGroups> categoryList = await _context.OquvMarkazPupilGroups
                 .Include(p => p.user)
                .Include(p => p.fan)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazPupilGroups>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazPupilGroups.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationByUserId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByUserId([FromQuery] int page, [FromQuery] int size,[FromQuery] long user_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazPupilGroups> categoryList = await _context.OquvMarkazPupilGroups
                 .Include(p => p.user)
                .Include(p => p.fan)
                .Where(p => p.active_status == true && p.OquvMarkazUserid == user_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazPupilGroups>();
            }

            foreach (OquvMarkazPupilGroups it in categoryList) {

                it.oquvchi_soni = await _context.OquvMarkazPupilGroupDetailInfo
                    .Where(p =>p.OquvMarkazPupilGroupsid == it.id && p.active_status == true)
                    .CountAsync();

            }

            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazPupilGroups
                .Where(p => p.active_status == true && p.OquvMarkazUserid == user_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }



        [HttpGet("getPaginationByFanId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByFanId([FromQuery] int page, [FromQuery] int size,[FromQuery] long fan_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazPupilGroups> categoryList = await _context.OquvMarkazPupilGroups
                .Include(p => p.user)
                .Include(p => p.fan)
                .Where(p => p.active_status == true && p.OquvMarkazFanlarid == fan_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazPupilGroups>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazPupilGroups
                .Where(p => p.active_status == true && p.OquvMarkazFanlarid == fan_id)
                .CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByOqituvchiId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByOqituvchiId([FromQuery] int page, [FromQuery] int size,[FromQuery] long oqituvchi_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazPupilGroups> categoryList = await _context.OquvMarkazPupilGroups
                .Include(p => p.user)
                .Include(p => p.fan)
                .Where(p => p.active_status == true && p.OquvMarkazUserid == oqituvchi_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazPupilGroups>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazPupilGroups
                .Where(p => p.active_status == true && p.OquvMarkazUserid == oqituvchi_id)
                .CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/OquvMarkazPupilGroups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazPupilGroups(long id, OquvMarkazPupilGroups oquvMarkazPupilGroups)
        {
            if (id != oquvMarkazPupilGroups.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazPupilGroups).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazPupilGroupsExists(id))
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

        // POST: api/OquvMarkazPupilGroups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazPupilGroups>> PostOquvMarkazPupilGroups(OquvMarkazPupilGroups oquvMarkazPupilGroups)
        {
            _context.OquvMarkazPupilGroups.Update(oquvMarkazPupilGroups);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazPupilGroups", new { id = oquvMarkazPupilGroups.id }, oquvMarkazPupilGroups);
        }

        // DELETE: api/OquvMarkazPupilGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazPupilGroups>> DeleteOquvMarkazPupilGroups(long id)
        {
            var oquvMarkazPupilGroups = await _context.OquvMarkazPupilGroups.FindAsync(id);
            if (oquvMarkazPupilGroups == null)
            {
                return NotFound();
            }

            _context.OquvMarkazPupilGroups.Remove(oquvMarkazPupilGroups);
            await _context.SaveChangesAsync();

            return oquvMarkazPupilGroups;
        }

        private bool OquvMarkazPupilGroupsExists(long id)
        {
            return _context.OquvMarkazPupilGroups.Any(e => e.id == id);
        }
    }
}
