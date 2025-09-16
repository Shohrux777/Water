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
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomColectionInformationsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public RoomColectionInformationsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/RoomColectionInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomColectionInformations>>> GetroomColectionInformations()
        {
            return await _context.roomColectionInformations.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/RoomColectionInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomColectionInformations>> GetRoomColectionInformations(long id)
        {
            var roomColectionInformations = await _context.roomColectionInformations.FindAsync(id);

            if (roomColectionInformations == null)
            {
                return NotFound();
            }

            return roomColectionInformations;
        }

        // PUT: api/RoomColectionInformations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomColectionInformations(long id, RoomColectionInformations roomColectionInformations)
        {
            if (id != roomColectionInformations.Id)
            {
                return BadRequest();
            }

            _context.Entry(roomColectionInformations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomColectionInformationsExists(id))
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

        // POST: api/RoomColectionInformations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RoomColectionInformations>> PostRoomColectionInformations(RoomColectionInformations roomColectionInformations)
        {
            _context.roomColectionInformations.Add(roomColectionInformations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomColectionInformations", new { id = roomColectionInformations.Id }, roomColectionInformations);
        }

        [HttpGet("addRoomColectionInformations")]
        public async Task<ActionResult<RoomColectionInformations>> addRoomColectionInformations([FromQuery] long Id, [FromQuery] String numberStr, [FromQuery]  String name, [FromQuery]  String note, [FromQuery]  long count)
        {
            RoomColectionInformations roomColectionInformations = new RoomColectionInformations();
            roomColectionInformations.ActiveStatus = true;
            roomColectionInformations.Id = Id;
            roomColectionInformations.count = count;
            roomColectionInformations.number = numberStr;
            roomColectionInformations.name = name;
            roomColectionInformations.note = note;
            _context.roomColectionInformations.Update(roomColectionInformations);
            await _context.SaveChangesAsync();

            return roomColectionInformations;
        }

        // DELETE: api/RoomColectionInformations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoomColectionInformations>> DeleteRoomColectionInformations(long id)
        {
            var roomColectionInformations = await _context.roomColectionInformations.FindAsync(id);
            if (roomColectionInformations == null)
            {
                return NotFound();
            }

            _context.roomColectionInformations.Remove(roomColectionInformations);
            await _context.SaveChangesAsync();

            return roomColectionInformations;
        }

        private bool RoomColectionInformationsExists(long id)
        {
            return _context.roomColectionInformations.Any(e => e.Id == id);
        }
    }
}
