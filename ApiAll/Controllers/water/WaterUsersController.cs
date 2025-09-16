using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.water;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.water
{
    [ApiExplorerSettings(GroupName = "v9")]
    [Route("api/[controller]")]
    [ApiController]
    public class WaterUsersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public WaterUsersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/WaterUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterUser>>> GetWaterUser()
        {
            List< WaterUser > users = await _context.WaterUser.ToListAsync();
            foreach (WaterUser it in users) {
                List<WaterAuth> waterAuths = await _context.WaterAuth.Where(p => p.WaterUserid == it.id).ToListAsync();
                if (waterAuths != null && waterAuths.Count > 0) {
                    it.auth = waterAuths.First();
                    it.auth_id = waterAuths.First().id;
                }

            }

            return users;
        }

        // GET: api/WaterUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterUser>> GetWaterUser(long id)
        {
            var waterUser = await _context.WaterUser.FindAsync(id);

            if (waterUser == null)
            {
                return NotFound();
            }

            return waterUser;
        }

        // PUT: api/WaterUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterUser(long id, WaterUser waterUser)
        {
            if (id != waterUser.id)
            {
                return BadRequest();
            }

            _context.Entry(waterUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterUserExists(id))
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

        // POST: api/WaterUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WaterUser>> PostWaterUser(WaterUser waterUser)
        {
            _context.WaterUser.Update(waterUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaterUser", new { id = waterUser.id }, waterUser);
        }


        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<WaterUser> categoryList = await _context.WaterUser
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<WaterUser>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.WaterUser.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // DELETE: api/WaterUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WaterUser>> DeleteWaterUser(long id)
        {
            var waterUser = await _context.WaterUser.FindAsync(id);
            if (waterUser == null)
            {
                return NotFound();
            }

            _context.WaterUser.Remove(waterUser);
            await _context.SaveChangesAsync();

            return waterUser;
        }

        private bool WaterUserExists(long id)
        {
            return _context.WaterUser.Any(e => e.id == id);
        }
    }
}
