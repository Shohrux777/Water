using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.pos;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.pos
{
    [ApiExplorerSettings(GroupName = "v5")]
    [Route("api/[controller]")]
    [ApiController]
    public class PosUsersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosUsersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosUser>>> GetPosUser()
        {
            List<PosUser> users = await _context.PosUser.ToListAsync();

            if (users != null && users.Count > 0) {
                foreach (PosUser it in users) {
                    List<PosAuthorization> authorizationList =
                        await _context.PosAuthorization.Include(p => p.company).Where(p => p.user_id == it.id).ToListAsync();

                    if (authorizationList != null && authorizationList.Count > 0) {
                        it.authorization = authorizationList.First();
                    }

                }


            }

            return users;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosUser> itemList = await _context.PosUser
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosUser>();
            }


            foreach (PosUser it in itemList)
            {
                List<PosAuthorization> authorizationList =
                    await _context.PosAuthorization.Include(p => p.company).Where(p => p.user_id == it.id).ToListAsync();

                if (authorizationList != null && authorizationList.Count > 0)
                {
                    it.authorization = authorizationList.First();
                }

            }

            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosUser.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/PosUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosUser>> GetPosUser(long id)
        {
            var posUser = await _context.PosUser.FindAsync(id);

            if (posUser == null)
            {
                return NotFound();
            }

            List<PosAuthorization> authorizationList =
                 await _context.PosAuthorization.Include(p => p.company).Where(p => p.user_id == posUser.id).ToListAsync();

            if (authorizationList != null && authorizationList.Count > 0)
            {
                posUser.authorization = authorizationList.First();
            }

            return posUser;
        }

        // PUT: api/PosUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosUser(long id, PosUser posUser)
        {
            if (id != posUser.id)
            {
                return BadRequest();
            }

            _context.Entry(posUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosUserExists(id))
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

        // POST: api/PosUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosUser>> PostPosUser(PosUser posUser)
        {


            try
            {
                _context.PosUser.Update(posUser);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                return NotFound(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFound(e?.InnerException?.Message);
            }

            return CreatedAtAction("GetPosUser", new { id = posUser.id }, posUser);
        }

        // DELETE: api/PosUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosUser>> DeletePosUser(long id)
        {
            var posUser = await _context.PosUser.FindAsync(id);
            if (posUser == null)
            {
                return NotFound();
            }

            _context.PosUser.Remove(posUser);
            await _context.SaveChangesAsync();

            return posUser;
        }

        private bool PosUserExists(long id)
        {
            return _context.PosUser.Any(e => e.id == id);
        }
    }
}
