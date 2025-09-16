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
    public class OquvMarkazBookAndGroupsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazBookAndGroupsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazBookAndGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazBookAndGroup>>> GetOquvMarkazBookAndGroup()
        {
            return await _context.OquvMarkazBookAndGroup.ToListAsync();
        }


        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazBookAndGroup> categoryList = await _context.OquvMarkazBookAndGroup
                .Include(p => p.group)
                .Include(p => p.book)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazBookAndGroup>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazBookAndGroup
                .Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByGroupId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByGroupId([FromQuery] int page, [FromQuery] int size,[FromQuery] long group_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazBookAndGroup> categoryList = await _context.OquvMarkazBookAndGroup
                .Include(p => p.group)
                .Include(p => p.book)
                .Where(p => p.active_status == true && p.OquvMarkazPupilGroupsid == group_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazBookAndGroup>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazBookAndGroup
                .Where(p => p.active_status == true && p.OquvMarkazPupilGroupsid == group_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/OquvMarkazBookAndGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazBookAndGroup>> GetOquvMarkazBookAndGroup(long id)
        {
            var oquvMarkazBookAndGroup = await _context.OquvMarkazBookAndGroup.FindAsync(id);

            if (oquvMarkazBookAndGroup == null)
            {
                return NotFound();
            }

            return oquvMarkazBookAndGroup;
        }

        // PUT: api/OquvMarkazBookAndGroups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazBookAndGroup(long id, OquvMarkazBookAndGroup oquvMarkazBookAndGroup)
        {
            if (id != oquvMarkazBookAndGroup.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazBookAndGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazBookAndGroupExists(id))
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

        // POST: api/OquvMarkazBookAndGroups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazBookAndGroup>> PostOquvMarkazBookAndGroup(OquvMarkazBookAndGroup oquvMarkazBookAndGroup)
        {
            _context.OquvMarkazBookAndGroup.Update(oquvMarkazBookAndGroup);
            await _context.SaveChangesAsync();

            return oquvMarkazBookAndGroup;
        }

        [HttpPost("addBooksToGroupAutoWithitems")]
        public async Task<ActionResult<OquvMarkazBookAndGroup>> addBooksToGroupAutoWithitems(OquvMarkazBookAndGroup oquvMarkazBookAndGroup)
        {
            _context.OquvMarkazBookAndGroup.Update(oquvMarkazBookAndGroup);
            await _context.SaveChangesAsync();

            List<OquvMarkazBookAndGroupDetil> detailList = new List<OquvMarkazBookAndGroupDetil>();
            List<OquvMarkazBookUnit> units = await _context.OquvMarkazBookUnit.Where( p=> p.OquvMarkazBookid == oquvMarkazBookAndGroup.OquvMarkazBookid).ToListAsync();
            if (units != null && units.Count > 0) {

                foreach (OquvMarkazBookUnit it in units) {
                    OquvMarkazBookAndGroupDetil item = new OquvMarkazBookAndGroupDetil();
                    item.active_status = true;
                    item.OquvMarkazBookUnitid = it.id;
                    item.OquvMarkazBookAndGroupid = oquvMarkazBookAndGroup.id;
                    item.readed = false;
                    detailList.Add(item);
                }

                _context.OquvMarkazBookAndGroupDetil.UpdateRange(detailList);
                await _context.SaveChangesAsync();

            }

            return oquvMarkazBookAndGroup;
        }

        // DELETE: api/OquvMarkazBookAndGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazBookAndGroup>> DeleteOquvMarkazBookAndGroup(long id)
        {
            var oquvMarkazBookAndGroup = await _context.OquvMarkazBookAndGroup.FindAsync(id);
            if (oquvMarkazBookAndGroup == null)
            {
                return NotFound();
            }

            _context.OquvMarkazBookAndGroup.Remove(oquvMarkazBookAndGroup);
            await _context.SaveChangesAsync();

            return oquvMarkazBookAndGroup;
        }

        private bool OquvMarkazBookAndGroupExists(long id)
        {
            return _context.OquvMarkazBookAndGroup.Any(e => e.id == id);
        }
    }
}
