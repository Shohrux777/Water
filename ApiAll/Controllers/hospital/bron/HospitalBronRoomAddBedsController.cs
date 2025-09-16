using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital.analiz;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.hospital.bron
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalBronRoomAddBedsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalBronRoomAddBedsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalBronRoomAddBeds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalBronRoomAddBeds>>> GetHospitalBronRoomAddBeds()
        {
            return await _context.HospitalBronRoomAddBeds.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalBronRoomAddBeds> itemList = await _context.HospitalBronRoomAddBeds
                .OrderByDescending(p => p.id)
                .Include(p => p.bed)
                .Include(p => p.room)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalBronRoomAddBeds>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalBronRoomAddBeds.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByRoomId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByRoomId([FromQuery] int page, [FromQuery] int size,[FromQuery] long room_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalBronRoomAddBeds> itemList = await _context.HospitalBronRoomAddBeds
                .OrderByDescending(p => p.id)
                .Include(p => p.bed)
                .Include(p => p.room)
                .Where(p => p.HospitalBronRoomsid == room_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalBronRoomAddBeds>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalBronRoomAddBeds.Where(p => p.HospitalBronRoomsid == room_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalBronRoomAddBeds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalBronRoomAddBeds>> GetHospitalBronRoomAddBeds(long id)
        {
            var hospitalBronRoomAddBeds = await _context.HospitalBronRoomAddBeds.FindAsync(id);

            if (hospitalBronRoomAddBeds == null)
            {
                return NotFound();
            }

            return hospitalBronRoomAddBeds;
        }

        // PUT: api/HospitalBronRoomAddBeds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalBronRoomAddBeds(long id, HospitalBronRoomAddBeds hospitalBronRoomAddBeds)
        {
            if (id != hospitalBronRoomAddBeds.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalBronRoomAddBeds).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalBronRoomAddBedsExists(id))
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

        // POST: api/HospitalBronRoomAddBeds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalBronRoomAddBeds>> PostHospitalBronRoomAddBeds(HospitalBronRoomAddBeds hospitalBronRoomAddBeds)
        {
            _context.HospitalBronRoomAddBeds.Update(hospitalBronRoomAddBeds);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalBronRoomAddBeds", new { id = hospitalBronRoomAddBeds.id }, hospitalBronRoomAddBeds);
        }

        // DELETE: api/HospitalBronRoomAddBeds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalBronRoomAddBeds>> DeleteHospitalBronRoomAddBeds(long id)
        {
            var hospitalBronRoomAddBeds = await _context.HospitalBronRoomAddBeds.FindAsync(id);
            if (hospitalBronRoomAddBeds == null)
            {
                return NotFound();
            }

            _context.HospitalBronRoomAddBeds.Remove(hospitalBronRoomAddBeds);
            await _context.SaveChangesAsync();

            return hospitalBronRoomAddBeds;
        }

        private bool HospitalBronRoomAddBedsExists(long id)
        {
            return _context.HospitalBronRoomAddBeds.Any(e => e.id == id);
        }
    }
}
