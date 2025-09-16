using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.archive;

namespace ApiAll.Controllers.archive
{
    [ApiExplorerSettings(GroupName = "v6")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArchiveRoomDetailController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ArchiveRoomDetailController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ArchiveRoomDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveRoomDetail>>> GetArchiveRoomDetail()
        {
            return await _context.ArchiveRoomDetail.Include(p => p.room).Include(p => p.datchik).ToListAsync();
        }

        [HttpGet("getRoomDetailByRoomId")]
        public async Task<ActionResult<IEnumerable<ArchiveRoomDetail>>> getRoomDetailByRoomId([FromQuery] long room_id)
        {
            return await _context.ArchiveRoomDetail.Where(p => p.ArchiveRoomid == room_id).Include(p => p.room).Include(p => p.datchik).OrderByDescending(p => p.id).ToListAsync();
        }

        // GET: api/ArchiveRoomDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchiveRoomDetail>> GetArchiveRoomDetail(long id)
        {
            var archiveRoomDetail = await _context.ArchiveRoomDetail.FindAsync(id);

            if (archiveRoomDetail == null)
            {
                return NotFound();
            }

            return archiveRoomDetail;
        }

        // PUT: api/ArchiveRoomDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchiveRoomDetail(long id, ArchiveRoomDetail archiveRoomDetail)
        {
            if (id != archiveRoomDetail.id)
            {
                return BadRequest();
            }

            _context.Entry(archiveRoomDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveRoomDetailExists(id))
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

        // POST: api/ArchiveRoomDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArchiveRoomDetail>> PostArchiveRoomDetail(ArchiveRoomDetail archiveRoomDetail)
        {


            try
            {
            _context.ArchiveRoomDetail.Update(archiveRoomDetail);
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

            return CreatedAtAction("GetArchiveRoomDetail", new { id = archiveRoomDetail.id }, archiveRoomDetail);
        }

        // DELETE: api/ArchiveRoomDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchiveRoomDetail>> DeleteArchiveRoomDetail(long id)
        {
            var archiveRoomDetail = await _context.ArchiveRoomDetail.FindAsync(id);
            if (archiveRoomDetail == null)
            {
                return NotFound();
            }

            _context.ArchiveRoomDetail.Remove(archiveRoomDetail);
            await _context.SaveChangesAsync();

            return archiveRoomDetail;
        }

        private bool ArchiveRoomDetailExists(long id)
        {
            return _context.ArchiveRoomDetail.Any(e => e.id == id);
        }
    }
}
