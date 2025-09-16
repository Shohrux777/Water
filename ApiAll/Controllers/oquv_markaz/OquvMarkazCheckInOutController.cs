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
    public class OquvMarkazCheckInOutController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazCheckInOutController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazCheckInOut
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazCheckInOut>>> GetOquvMarkazCheckInOut()
        {
            return await _context.OquvMarkazCheckInOut.ToListAsync();
        }



        // GET: api/OquvMarkazCheckInOut/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazCheckInOut>> GetOquvMarkazCheckInOut(long id)
        {
            var oquvMarkazCheckInOut = await _context.OquvMarkazCheckInOut.FindAsync(id);

            if (oquvMarkazCheckInOut == null)
            {
                return NotFound();
            }

            return oquvMarkazCheckInOut;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazCheckInOut> categoryList = await _context.OquvMarkazCheckInOut.Where(p => p.active_status == true)
                .Include(p =>p.client)
                .Include(p =>p.user)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazCheckInOut>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazCheckInOut.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/OquvMarkazCheckInOut/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazCheckInOut(long id, OquvMarkazCheckInOut oquvMarkazCheckInOut)
        {
            if (id != oquvMarkazCheckInOut.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazCheckInOut).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazCheckInOutExists(id))
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

        // POST: api/OquvMarkazCheckInOut
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazCheckInOut>> PostOquvMarkazCheckInOut(OquvMarkazCheckInOut oquvMarkazCheckInOut)
        {
            _context.OquvMarkazCheckInOut.Update(oquvMarkazCheckInOut);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazCheckInOut", new { id = oquvMarkazCheckInOut.id }, oquvMarkazCheckInOut);
        }

        // DELETE: api/OquvMarkazCheckInOut/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazCheckInOut>> DeleteOquvMarkazCheckInOut(long id)
        {
            var oquvMarkazCheckInOut = await _context.OquvMarkazCheckInOut.FindAsync(id);
            if (oquvMarkazCheckInOut == null)
            {
                return NotFound();
            }

            _context.OquvMarkazCheckInOut.Remove(oquvMarkazCheckInOut);
            await _context.SaveChangesAsync();

            return oquvMarkazCheckInOut;
        }

        private bool OquvMarkazCheckInOutExists(long id)
        {
            return _context.OquvMarkazCheckInOut.Any(e => e.id == id);
        }
    }
}
