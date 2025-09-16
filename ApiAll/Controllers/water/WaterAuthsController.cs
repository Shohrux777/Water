using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.water;

namespace ApiAll.Controllers.water
{
    [ApiExplorerSettings(GroupName = "v9")]
    [Route("api/[controller]")]
    [ApiController]
    public class WaterAuthsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public WaterAuthsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/WaterAuths
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterAuth>>> GetWaterAuth()
        {
            return await _context.WaterAuth.ToListAsync();
        }

        // GET: api/WaterAuths/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterAuth>> GetWaterAuth(long id)
        {
            var waterAuth = await _context.WaterAuth.FindAsync(id);

            if (waterAuth == null)
            {
                return NotFound();
            }

            return waterAuth;
        }

        [HttpGet("addOrderIdListForAuth")]
        public async Task<ActionResult<WaterAuth>> addOrderIdListForAuth([FromQuery]long auth_id,
            [FromQuery]String id_str_list)
        {
            var waterAuth = await _context.WaterAuth.FindAsync(auth_id);

            if (waterAuth == null)
            {
                return NotFound();
            }
            waterAuth.reserverd_note = id_str_list;
            _context.WaterAuth.Update(waterAuth);
            await _context.SaveChangesAsync();
            return waterAuth;
        }

        // GET: api/WaterAuths/5
        [HttpGet("checkAuth")]
        public async Task<ActionResult<WaterAuth>> checkAuth([FromQuery] String login,[FromQuery] String password)
        {
            var waterAuth = await _context.WaterAuth
                .Where(p => p.password == password && p.login == login)
                .ToListAsync();

            if (waterAuth == null || waterAuth.Count() == 0)
            {
                return NotFound();
            }

            return waterAuth.First();
        }



        // PUT: api/WaterAuths/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterAuth(long id, WaterAuth waterAuth)
        {
            if (id != waterAuth.id)
            {
                return BadRequest();
            }

            _context.Entry(waterAuth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterAuthExists(id))
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

        // POST: api/WaterAuths
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WaterAuth>> PostWaterAuth(WaterAuth waterAuth)
        {
            _context.WaterAuth.Update(waterAuth);
            await _context.SaveChangesAsync();
            return waterAuth;
        }

        // DELETE: api/WaterAuths/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WaterAuth>> DeleteWaterAuth(long id)
        {
            var waterAuth = await _context.WaterAuth.FindAsync(id);
            if (waterAuth == null)
            {
                return NotFound();
            }

            _context.WaterAuth.Remove(waterAuth);
            await _context.SaveChangesAsync();

            return waterAuth;
        }

        private bool WaterAuthExists(long id)
        {
            return _context.WaterAuth.Any(e => e.id == id);
        }
    }
}
