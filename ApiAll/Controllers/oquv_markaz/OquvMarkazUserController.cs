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
    public class OquvMarkazUserController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazUserController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazUser>>> GetOquvMarkazUser()
        {
            return await _context.OquvMarkazUser.ToListAsync();
        }

        // GET: api/OquvMarkazUser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazUser>> GetOquvMarkazUser(long id)
        {
            var oquvMarkazUser = await _context.OquvMarkazUser.FindAsync(id);

            if (oquvMarkazUser == null)
            {
                return NotFound();
            }

            return oquvMarkazUser;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazUser> categoryList = await _context.OquvMarkazUser.Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazUser>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazUser.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/OquvMarkazUser/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazUser(long id, OquvMarkazUser oquvMarkazUser)
        {
            if (id != oquvMarkazUser.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazUserExists(id))
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

        // POST: api/OquvMarkazUser
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazUser>> PostOquvMarkazUser(OquvMarkazUser oquvMarkazUser)
        {
            _context.OquvMarkazUser.Update(oquvMarkazUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazUser", new { id = oquvMarkazUser.id }, oquvMarkazUser);
        }

        // DELETE: api/OquvMarkazUser/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazUser>> DeleteOquvMarkazUser(long id)
        {
            var oquvMarkazUser = await _context.OquvMarkazUser.FindAsync(id);
            if (oquvMarkazUser == null)
            {
                return NotFound();
            }

            _context.OquvMarkazUser.Remove(oquvMarkazUser);
            await _context.SaveChangesAsync();

            return oquvMarkazUser;
        }

        private bool OquvMarkazUserExists(long id)
        {
            return _context.OquvMarkazUser.Any(e => e.id == id);
        }
    }
}
