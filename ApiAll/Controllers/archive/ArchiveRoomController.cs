using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.archive;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.archive
{
    [ApiExplorerSettings(GroupName = "v6")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArchiveRoomController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ArchiveRoomController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<ArchiveRoom> categoryList = await _context.ArchiveRoom
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<ArchiveRoom>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.ArchiveRoom.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/ArchiveRoom
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveRoom>>> GetArchiveRoom()
        {
            List<ArchiveRoom>  roomList  = await _context.ArchiveRoom.Include(p => p.roomDetails).ThenInclude(p => p.datchik).ToListAsync();
           
            return roomList;


        }

        // GET: api/ArchiveRoom/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchiveRoom>> GetArchiveRoom(long id)
        {
            var archiveRoom = await _context.ArchiveRoom.FindAsync(id);

            if (archiveRoom == null)
            {
                return NotFound();
            }

            return archiveRoom;
        }

        // PUT: api/ArchiveRoom/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchiveRoom(long id, ArchiveRoom archiveRoom)
        {
            if (id != archiveRoom.id)
            {
                return BadRequest();
            }

            _context.Entry(archiveRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveRoomExists(id))
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

        // POST: api/ArchiveRoom
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArchiveRoom>> PostArchiveRoom(ArchiveRoom archiveRoom)
        {

            try
            {
            _context.ArchiveRoom.Update(archiveRoom);
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

            return CreatedAtAction("GetArchiveRoom", new { id = archiveRoom.id }, archiveRoom);
        }

        // DELETE: api/ArchiveRoom/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchiveRoom>> DeleteArchiveRoom(long id)
        {
            var archiveRoom = await _context.ArchiveRoom.FindAsync(id);
            if (archiveRoom == null)
            {
                return NotFound();
            }

            _context.ArchiveRoom.Remove(archiveRoom);
            await _context.SaveChangesAsync();

            return archiveRoom;
        }

        private bool ArchiveRoomExists(long id)
        {
            return _context.ArchiveRoom.Any(e => e.id == id);
        }
    }
}
