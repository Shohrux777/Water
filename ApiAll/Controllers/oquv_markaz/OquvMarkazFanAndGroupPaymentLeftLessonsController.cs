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
    public class OquvMarkazFanAndGroupPaymentLeftLessonsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazFanAndGroupPaymentLeftLessonsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazFanAndGroupPaymentLeftLessons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazFanAndGroupPaymentLeftLessons>>> GetOquvMarkazFanAndGroupPaymentLeftLessons()
        {
            return await _context.OquvMarkazFanAndGroupPaymentLeftLessons.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazFanAndGroupPaymentLeftLessons> categoryList = await _context.OquvMarkazFanAndGroupPaymentLeftLessons
                .Where(p => p.active_status == true)
                .Include(p => p.client)
                .Include(p => p.group)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazFanAndGroupPaymentLeftLessons>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazFanAndGroupPaymentLeftLessons.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationTolovQilishiKerakList")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationTolovQilishiKerakList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazFanAndGroupPaymentLeftLessons> categoryList = await _context.OquvMarkazFanAndGroupPaymentLeftLessons
                .Where(p => p.active_status == true && p.left_real_lessons_count  <= 0 )
                .Include(p => p.client)
                .Include(p => p.group)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazFanAndGroupPaymentLeftLessons>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazFanAndGroupPaymentLeftLessons
                .Where(p => p.active_status == true && p.left_real_lessons_count <= 0).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/OquvMarkazFanAndGroupPaymentLeftLessons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazFanAndGroupPaymentLeftLessons>> GetOquvMarkazFanAndGroupPaymentLeftLessons(long id)
        {
            var oquvMarkazFanAndGroupPaymentLeftLessons = await _context.OquvMarkazFanAndGroupPaymentLeftLessons.FindAsync(id);

            if (oquvMarkazFanAndGroupPaymentLeftLessons == null)
            {
                return NotFound();
            }

            return oquvMarkazFanAndGroupPaymentLeftLessons;
        }

        // PUT: api/OquvMarkazFanAndGroupPaymentLeftLessons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazFanAndGroupPaymentLeftLessons(long id, OquvMarkazFanAndGroupPaymentLeftLessons oquvMarkazFanAndGroupPaymentLeftLessons)
        {
            if (id != oquvMarkazFanAndGroupPaymentLeftLessons.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazFanAndGroupPaymentLeftLessons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazFanAndGroupPaymentLeftLessonsExists(id))
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

        // POST: api/OquvMarkazFanAndGroupPaymentLeftLessons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazFanAndGroupPaymentLeftLessons>> PostOquvMarkazFanAndGroupPaymentLeftLessons(OquvMarkazFanAndGroupPaymentLeftLessons oquvMarkazFanAndGroupPaymentLeftLessons)
        {
            _context.OquvMarkazFanAndGroupPaymentLeftLessons.Update(oquvMarkazFanAndGroupPaymentLeftLessons);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazFanAndGroupPaymentLeftLessons", new { id = oquvMarkazFanAndGroupPaymentLeftLessons.id }, oquvMarkazFanAndGroupPaymentLeftLessons);
        }



        // DELETE: api/OquvMarkazFanAndGroupPaymentLeftLessons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazFanAndGroupPaymentLeftLessons>> DeleteOquvMarkazFanAndGroupPaymentLeftLessons(long id)
        {
            var oquvMarkazFanAndGroupPaymentLeftLessons = await _context.OquvMarkazFanAndGroupPaymentLeftLessons.FindAsync(id);
            if (oquvMarkazFanAndGroupPaymentLeftLessons == null)
            {
                return NotFound();
            }

            _context.OquvMarkazFanAndGroupPaymentLeftLessons.Remove(oquvMarkazFanAndGroupPaymentLeftLessons);
            await _context.SaveChangesAsync();

            return oquvMarkazFanAndGroupPaymentLeftLessons;
        }

        private bool OquvMarkazFanAndGroupPaymentLeftLessonsExists(long id)
        {
            return _context.OquvMarkazFanAndGroupPaymentLeftLessons.Any(e => e.id == id);
        }
    }
}
