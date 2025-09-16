using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.oquv_markaz;
using Newtonsoft.Json.Linq;
using ApiAll.Model.tekistil;

namespace ApiAll.Controllers.oquv_markaz
{
    [ApiExplorerSettings(GroupName = "v8")]
    [Route("api/[controller]")]
    [ApiController]
    public class OquvMarkazProbniyDarslarController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazProbniyDarslarController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazProbniyDarslar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazProbniyDarslar>>> GetOquvMarkazProbniyDarslar()
        {
            return await _context.OquvMarkazProbniyDarslar.ToListAsync();
        }

        // GET: api/OquvMarkazProbniyDarslar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazProbniyDarslar>> GetOquvMarkazProbniyDarslar(long id)
        {
            var oquvMarkazProbniyDarslar = await _context.OquvMarkazProbniyDarslar.FindAsync(id);

            if (oquvMarkazProbniyDarslar == null)
            {
                return NotFound();
            }

            return oquvMarkazProbniyDarslar;
        }

        [HttpGet("getFinishProbniyDarsById")]
        public async Task<ActionResult<OquvMarkazProbniyDarslar>> getFinishProbniyDarsById([FromQuery]long id)
        {
            var oquvMarkazProbniyDarslar = await _context.OquvMarkazProbniyDarslar.FindAsync(id);

            if (oquvMarkazProbniyDarslar == null)
            {
                return NotFound();
            }
            oquvMarkazProbniyDarslar.finish_group = true;
            _context.OquvMarkazProbniyDarslar.Update(oquvMarkazProbniyDarslar);
            await _context.SaveChangesAsync();

            return oquvMarkazProbniyDarslar;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazProbniyDarslar> categoryList = await _context.OquvMarkazProbniyDarslar.Where(p => p.active_status == true && p.finish_group == false)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazProbniyDarslar>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazProbniyDarslar.Where(p => p.active_status == true && p.finish_group == false).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/OquvMarkazProbniyDarslar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazProbniyDarslar(long id, OquvMarkazProbniyDarslar oquvMarkazProbniyDarslar)
        {
            if (id != oquvMarkazProbniyDarslar.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazProbniyDarslar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazProbniyDarslarExists(id))
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

        // POST: api/OquvMarkazProbniyDarslar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazProbniyDarslar>> PostOquvMarkazProbniyDarslar(OquvMarkazProbniyDarslar oquvMarkazProbniyDarslar)
        {
            _context.OquvMarkazProbniyDarslar.Update(oquvMarkazProbniyDarslar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazProbniyDarslar", new { id = oquvMarkazProbniyDarslar.id }, oquvMarkazProbniyDarslar);
        }

        // DELETE: api/OquvMarkazProbniyDarslar/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazProbniyDarslar>> DeleteOquvMarkazProbniyDarslar(long id)
        {
            var oquvMarkazProbniyDarslar = await _context.OquvMarkazProbniyDarslar.FindAsync(id);
            if (oquvMarkazProbniyDarslar == null)
            {
                return NotFound();
            }

            _context.OquvMarkazProbniyDarslar.Remove(oquvMarkazProbniyDarslar);
            await _context.SaveChangesAsync();

            return oquvMarkazProbniyDarslar;
        }

        private bool OquvMarkazProbniyDarslarExists(long id)
        {
            return _context.OquvMarkazProbniyDarslar.Any(e => e.id == id);
        }
    }
}
