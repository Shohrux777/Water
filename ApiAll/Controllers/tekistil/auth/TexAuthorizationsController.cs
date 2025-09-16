using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tekistil
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexAuthorizationsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        

        public TexAuthorizationsController(ApplicationContext context)
        {
            _context = context;
           
        }

        // GET: api/TexAuthorizations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexAuthorization>>> GetTexAuthorization()
        {
            return await _context.TexAuthorization.Where( p => p.active_status == true).Include( p => p.user).Include(p =>p.company).ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexAuthorization> itemList = await _context.TexAuthorization.Where(p => p.active_status == true).Include(p => p.user).Include(p => p.company).Skip(page * size).Take(size).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexAuthorization>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexAuthorization.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TexAuthorizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexAuthorization>> GetTexAuthorization(long id)
        {
            var texAuthorization = await _context.TexAuthorization.FindAsync(id);

            if (texAuthorization == null)
            {
                return NotFound();
            }
            texAuthorization.company = await _context.TexContragent.FindAsync(texAuthorization.company_id);
            texAuthorization.user = await _context.TexUser.FindAsync(texAuthorization.user_id);

            return texAuthorization;
        }

        [HttpGet("checkAuthAsync")]
        public async Task<ActionResult<TexAuthorization>> checkAuthAsync([FromQuery] String password,[FromQuery] String login)
        {
            List<TexAuthorization> texAuthorizationList = await _context.TexAuthorization.Where( p => p.login == login && p.password == password).ToListAsync();

            if (texAuthorizationList == null || texAuthorizationList.Count == 0)
            {
                return NotFound("Login or Password incorrect");
            }

            TexAuthorization texAuthorization = texAuthorizationList.First();
            texAuthorization.company = await _context.TexContragent.FindAsync(texAuthorization.company_id);
            texAuthorization.user = await _context.TexUser.FindAsync(texAuthorization.user_id);

            return texAuthorization;
        }

        [HttpGet("checkAuth")]
        public async Task<ActionResult<TexAuthorization>> checkAuth([FromQuery] String login, [FromQuery] String password)
        {
            List<TexAuthorization> texAuthorizations = await _context.TexAuthorization.Where(p => p.login == login && p.password == password).ToListAsync();
            if (texAuthorizations != null && texAuthorizations.Count == 0) {
                return NotFound("Password or login incorrect");
            }
            return texAuthorizations.First();

        }

        // PUT: api/TexAuthorizations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexAuthorization(long id, TexAuthorization texAuthorization)
        {
            if (id != texAuthorization.id)
            {
                return BadRequest();
            }

            _context.Entry(texAuthorization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexAuthorizationExists(id))
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

        // POST: api/TexAuthorizations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexAuthorization>> PostTexAuthorization(TexAuthorization texAuthorization)
        {
            if (texAuthorization!= null ) {
                if (texAuthorization.id == 0)
                {
                    //new need to check for uniq
                    List<TexAuthorization> texAuthorizationList = await _context.TexAuthorization.Where( p =>p.login == texAuthorization.login || p.user_id == texAuthorization.user_id).ToListAsync();
                    if (texAuthorizationList != null && texAuthorizationList.Count > 0)
                    {
                        return NotFound();
                    }
                }
                else {
                    List<TexAuthorization> texAuthorizationList = await _context.TexAuthorization.Where(p => p.login == texAuthorization.login || p.user_id == texAuthorization.user_id).ToListAsync();
                    if (texAuthorizationList != null && texAuthorizationList.Count > 0)
                    {
                        TexAuthorization authorization = texAuthorizationList.First();
                        if (texAuthorization.id != authorization.id)
                        {
                            return NotFound();
                        }
                    }

                }

            }
            try { 
            _context.TexAuthorization.Update(texAuthorization);
            await _context.SaveChangesAsync();
              }
            catch (DbUpdateException e) {
                return NotFound(e?.InnerException?.Message );

                }
            catch (Exception e) {
                 return NotFound(e?.InnerException?.Message );
               }

return texAuthorization;
        }

        // DELETE: api/TexAuthorizations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexAuthorization>> DeleteTexAuthorization(long id)
        {
            var texAuthorization = await _context.TexAuthorization.FindAsync(id);
            if (texAuthorization == null)
            {
                return NotFound();
            }
            texAuthorization.active_status = false;
            _context.TexAuthorization.Update(texAuthorization);
            await _context.SaveChangesAsync();

            return texAuthorization;
        }

        private bool TexAuthorizationExists(long id)
        {
            return _context.TexAuthorization.Any(e => e.id == id);
        }
    }
}
