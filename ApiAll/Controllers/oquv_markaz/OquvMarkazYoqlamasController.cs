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
    public class OquvMarkazYoqlamasController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazYoqlamasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazYoqlamas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazYoqlama>>> GetOquvMarkazYoqlama()
        {
            return await _context.OquvMarkazYoqlama.ToListAsync();
        }



        [HttpGet("getPaginationYoqlamaListByGroupId")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size
            ,[FromQuery] DateTime begin_date, [FromQuery] DateTime end_date,[FromQuery] long group_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazYoqlama> categoryList = await _context.OquvMarkazYoqlama
                .Where(p => p.active_status == true
                && p.OquvMarkazPupilGroupsid == group_id && (p.created_date_time >= begin_date && p.created_date_time <= end_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazYoqlama>();
            }

            //category list

            if (categoryList.Count == 0) {

                List<OquvMarkazPupilGroupDetailInfo> oquvchi_list = await _context.OquvMarkazPupilGroupDetailInfo
                    .Include(p => p.oquvchi)
                    .Include(p => p.group)
                    .Where(p => p.OquvMarkazPupilGroupsid == group_id).ToListAsync();
                foreach (OquvMarkazPupilGroupDetailInfo oquvchi in oquvchi_list) {
                    OquvMarkazYoqlama yoqlama = new OquvMarkazYoqlama();
                    yoqlama.active_status = true;
                    yoqlama.client = oquvchi.oquvchi;
                    yoqlama.OquvMarkazClientid = oquvchi.id;
                    yoqlama.OquvMarkazPupilGroupsid = group_id;
                    _context.OquvMarkazYoqlama.Update(yoqlama);
                    await _context.SaveChangesAsync();

                    categoryList.Add(yoqlama);


                }


            }


            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count =  categoryList.Count();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/OquvMarkazYoqlamas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazYoqlama>> GetOquvMarkazYoqlama(long id)
        {
            var oquvMarkazYoqlama = await _context.OquvMarkazYoqlama.FindAsync(id);

            if (oquvMarkazYoqlama == null)
            {
                return NotFound();
            }

            return oquvMarkazYoqlama;
        }

        [HttpGet("changeYoqlamaKeldiKelmadiStatus")]
        public async Task<ActionResult<OquvMarkazYoqlama>> changeYoqlamaKeldiKelmadiStatus([FromQuery]long yoqlama_id,[FromQuery] bool status)
        {
            var oquvMarkazYoqlama = await _context.OquvMarkazYoqlama.FindAsync(yoqlama_id);

            if (oquvMarkazYoqlama == null)
            {
                return NotFound();
            }
            oquvMarkazYoqlama.status_keldi_ketdi = status;
            _context.OquvMarkazYoqlama.Update(oquvMarkazYoqlama);
            await _context.SaveChangesAsync();
            return oquvMarkazYoqlama;
        }

        // PUT: api/OquvMarkazYoqlamas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazYoqlama(long id, OquvMarkazYoqlama oquvMarkazYoqlama)
        {
            if (id != oquvMarkazYoqlama.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazYoqlama).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazYoqlamaExists(id))
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

        // POST: api/OquvMarkazYoqlamas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazYoqlama>> PostOquvMarkazYoqlama(OquvMarkazYoqlama oquvMarkazYoqlama)
        {
            _context.OquvMarkazYoqlama.Update(oquvMarkazYoqlama);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazYoqlama", new { id = oquvMarkazYoqlama.id }, oquvMarkazYoqlama);
        }

        [HttpPost("AddorUpdateYoqlamaList")]
        public async Task<ActionResult<IEnumerable<OquvMarkazYoqlama>>> AddorUpdateYoqlamaList(List<OquvMarkazYoqlama> oquvMarkazYoqlamaList)
        {
            _context.OquvMarkazYoqlama.UpdateRange(oquvMarkazYoqlamaList);
            await _context.SaveChangesAsync();

            return oquvMarkazYoqlamaList;
        }

        

        // DELETE: api/OquvMarkazYoqlamas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazYoqlama>> DeleteOquvMarkazYoqlama(long id)
        {
            var oquvMarkazYoqlama = await _context.OquvMarkazYoqlama.FindAsync(id);
            if (oquvMarkazYoqlama == null)
            {
                return NotFound();
            }

            _context.OquvMarkazYoqlama.Remove(oquvMarkazYoqlama);
            await _context.SaveChangesAsync();

            return oquvMarkazYoqlama;
        }

        private bool OquvMarkazYoqlamaExists(long id)
        {
            return _context.OquvMarkazYoqlama.Any(e => e.id == id);
        }
    }
}
