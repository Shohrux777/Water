using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PositionsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Positions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>> Getpositions()
        {
            return await _context.positions.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/Positions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Position>> GetPosition(long id)
        {
            var position = await _context.positions.FindAsync(id);

            if (position == null)
            {
                return NotFound();
            }

            return position;
        }

        // PUT: api/Positions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosition(long id, Position position)
        {
            if (id != position.Id)
            {
                return BadRequest();
            }

            _context.Entry(position).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionExists(id))
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

        // POST: api/Positions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Position>> PostPosition(Position position)
        {
            _context.positions.Add(position);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosition", new { id = position.Id }, position);
        }

        [HttpGet("addPosition")]
        public async Task<ActionResult<Position>> addPosition(
            [FromQuery] long Id,
            [FromQuery] String Name,
            [FromQuery] String Code)
        {
            Position position = new Position();
            position.ActiveStatus = true;
            position.Id = Id;
            position.Name = Name;
            position.Code = Code;

            _context.positions.Update(position);
            await _context.SaveChangesAsync();

            return position;
        }

        // DELETE: api/Positions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Position>> DeletePosition(long id)
        {
            var position = await _context.positions.FindAsync(id);
            if (position == null)
            {
                return NotFound();
            }

            List<Users> users = await _context.Users.Where(p => p.PositionId == id).ToListAsync();
            if (users != null && users.Count() > 0) {
                return NotFound("User connected to this object(User boglangan ochirolmisz)");
            }

            _context.positions.Remove(position);
            await _context.SaveChangesAsync();

            return position;
        }

        private bool PositionExists(long id)
        {
            return _context.positions.Any(e => e.Id == id);
        }
    }
}
