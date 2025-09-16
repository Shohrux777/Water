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
    public class RoomsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public RoomsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rooms>>> Getrooms()
        {
            List<Rooms> roomsList = await _context.rooms.OrderByDescending(p => p.Id).ToListAsync();
            foreach (Rooms rooms in roomsList) {
                Department department = await _context.departments.FindAsync(rooms.DepartmentId);
                rooms.department = department;
            }
            return roomsList;
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rooms>> GetRooms(long id)
        {
            var rooms = await _context.rooms.FindAsync(id);

            if (rooms == null)
            {
                return NotFound();
            }

            return rooms;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRooms(long id, Rooms rooms)
        {
            if (id != rooms.Id)
            {
                return BadRequest();
            }

            _context.Entry(rooms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomsExists(id))
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

        // POST: api/Rooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Rooms>> PostRooms(Rooms rooms)
        {
            _context.rooms.Add(rooms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRooms", new { id = rooms.Id }, rooms);
        }

        [HttpGet("addRoom")]
        public async Task<ActionResult<Rooms>> addRoom([FromQuery] long Id, [FromQuery] String name, [FromQuery] long departmentId, [FromQuery] String roomNumber, [FromQuery] int roomType,[FromQuery] int bedsCout)
        {
            Rooms rooms = new Rooms();
            rooms.ActiveStatus = true;
            rooms.Id = Id;
            rooms.Type = roomType;
            rooms.Name = name;
            rooms.Number = roomNumber;
            rooms.BedsCount = bedsCout;
            rooms.DepartmentId = departmentId;
            _context.rooms.Update(rooms);
            await _context.SaveChangesAsync();

            return rooms;
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rooms>> DeleteRooms(long id)
        {
            var rooms = await _context.rooms.FindAsync(id);
            if (rooms == null)
            {
                return NotFound();
            }

            List<Users> users = await _context.Users.Where(p => p.RoomId == id).ToListAsync();
            if (users != null && users.Count() > 0)
            {
                return NotFound("User connected to this object(User boglangan ochirolmisz)");
            }

            _context.rooms.Remove(rooms);
            await _context.SaveChangesAsync();

            return rooms;
        }

        private bool RoomsExists(long id)
        {
            return _context.rooms.Any(e => e.Id == id);
        }
    }
}
