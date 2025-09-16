using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;

namespace ApiAll.Controllers.tekistil
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexMessageGroupsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexMessageGroupsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexMessageGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexMessageGroup>>> GetTexMessageGroup()
        {
            return await _context.TexMessageGroup.ToListAsync();
        }

        // GET: api/TexMessageGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexMessageGroup>> GetTexMessageGroup(long id)
        {
            var texMessageGroup = await _context.TexMessageGroup.FindAsync(id);

            if (texMessageGroup == null)
            {
                return NotFound();
            }

            return texMessageGroup;
        }

        // PUT: api/TexMessageGroups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexMessageGroup(long id, TexMessageGroup texMessageGroup)
        {
            if (id != texMessageGroup.id)
            {
                return BadRequest();
            }

            _context.Entry(texMessageGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexMessageGroupExists(id))
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

        // POST: api/TexMessageGroups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexMessageGroup>> PostTexMessageGroup(TexMessageGroup texMessageGroup)
        {
            try { 

            _context.TexMessageGroup.Add(texMessageGroup);
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

            return CreatedAtAction("GetTexMessageGroup", new { id = texMessageGroup.id }, texMessageGroup);
        }

        [HttpGet("addToContactNewUser")]
        public async Task<ActionResult<TexMessageGroup>> addToContactNewUser([FromQuery] long owner_auth_id,[FromQuery] long friend_auth_id)
        {
            try
            {
                List<TexMessageGroup> texMessageGroupList = await _context.TexMessageGroup.Where(p => p.owner_auth_id == owner_auth_id && p.friend_auth_id == friend_auth_id).ToListAsync();
                if (texMessageGroupList == null || texMessageGroupList.Count == 0)
                {
                    
                    //first
                    TexMessageGroup texMessageGroup = new TexMessageGroup();
                    texMessageGroup.active_status = true;
                    texMessageGroup.owner_auth_id = owner_auth_id;
                    texMessageGroup.friend_auth_id = friend_auth_id;


                    _context.TexMessageGroup.Update(texMessageGroup);
                    await _context.SaveChangesAsync();

                    //first
                    TexMessageGroup texMessageGroup1 = new TexMessageGroup();
                    texMessageGroup1.active_status = true;
                    texMessageGroup1.friend_auth_id = owner_auth_id;
                    texMessageGroup1.owner_auth_id = friend_auth_id;


                    _context.TexMessageGroup.Update(texMessageGroup1);
                    await _context.SaveChangesAsync();

                    return texMessageGroup;
                }
                else {
                    return NotFound("User already exit");
                }

              

            }
            catch (DbUpdateException e)
            {
                return NotFound(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFound(e?.InnerException?.Message);
            }

           
        }

        // DELETE: api/TexMessageGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexMessageGroup>> DeleteTexMessageGroup(long id)
        {
            var texMessageGroup = await _context.TexMessageGroup.FindAsync(id);
            if (texMessageGroup == null)
            {
                return NotFound();
            }

            try { 
                _context.TexMessageGroup.Remove(texMessageGroup);
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

return texMessageGroup;
        }

        private bool TexMessageGroupExists(long id)
        {
            return _context.TexMessageGroup.Any(e => e.id == id);
        }
    }
}
