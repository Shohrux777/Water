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
    public class TegirmonUserController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonUserController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonUser>>> GetTegirmonUser()
        {
            return await _context.TegirmonUser.ToListAsync();
        }


        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonUser> categoryList = await _context.TegirmonUser
                .Include(p => p.department)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonUser>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonUser.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TegirmonUser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonUser>> GetTegirmonUser(long id)
        {
            var tegirmonUser = await _context.TegirmonUser.FindAsync(id);

            if (tegirmonUser == null)
            {
                return NotFound();
            }

            return tegirmonUser;
        }

        // PUT: api/TegirmonUser/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonUser(long id, TegirmonUser tegirmonUser)
        {
            if (id != tegirmonUser.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonUserExists(id))
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

        // POST: api/TegirmonUser
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonUser>> PostTegirmonUser(TegirmonUser tegirmonUser)
        {
            _context.TegirmonUser.Update(tegirmonUser);
            await _context.SaveChangesAsync();
            return tegirmonUser;
        }

        // DELETE: api/TegirmonUser/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonUser>> DeleteTegirmonUser(long id)
        {
            var tegirmonUser = await _context.TegirmonUser.FindAsync(id);
            if (tegirmonUser == null)
            {
                return NotFound();
            }

            _context.TegirmonUser.Remove(tegirmonUser);
            await _context.SaveChangesAsync();

            return tegirmonUser;
        }

        private bool TegirmonUserExists(long id)
        {
            return _context.TegirmonUser.Any(e => e.id == id);
        }
    }
}
