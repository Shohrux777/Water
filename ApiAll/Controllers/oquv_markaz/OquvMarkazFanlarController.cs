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
    public class OquvMarkazFanlarController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazFanlarController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazFanlar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazFanlar>>> GetOquvMarkazFanlar()
        {
            return await _context.OquvMarkazFanlar.ToListAsync();
        }

        // GET: api/OquvMarkazFanlar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazFanlar>> GetOquvMarkazFanlar(long id)
        {
            var oquvMarkazFanlar = await _context.OquvMarkazFanlar.FindAsync(id);

            if (oquvMarkazFanlar == null)
            {
                return NotFound();
            }

            return oquvMarkazFanlar;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazFanlar> categoryList = await _context.OquvMarkazFanlar.Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazFanlar>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazFanlar.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/OquvMarkazFanlar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazFanlar(long id, OquvMarkazFanlar oquvMarkazFanlar)
        {
            if (id != oquvMarkazFanlar.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazFanlar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazFanlarExists(id))
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

        // POST: api/OquvMarkazFanlar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazFanlar>> PostOquvMarkazFanlar(OquvMarkazFanlar oquvMarkazFanlar)
        {
            _context.OquvMarkazFanlar.Update(oquvMarkazFanlar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazFanlar", new { id = oquvMarkazFanlar.id }, oquvMarkazFanlar);
        }

        // DELETE: api/OquvMarkazFanlar/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazFanlar>> DeleteOquvMarkazFanlar(long id)
        {
            var oquvMarkazFanlar = await _context.OquvMarkazFanlar.FindAsync(id);
            if (oquvMarkazFanlar == null)
            {
                return NotFound();
            }

            _context.OquvMarkazFanlar.Remove(oquvMarkazFanlar);
            await _context.SaveChangesAsync();

            return oquvMarkazFanlar;
        }

        private bool OquvMarkazFanlarExists(long id)
        {
            return _context.OquvMarkazFanlar.Any(e => e.id == id);
        }
    }
}
