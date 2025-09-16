using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.hospital.bron
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalBronRoomBedsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalBronRoomBedsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalBronRoomBeds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalBronRoomBeds>>> GetHospitalBronRoomBeds()
        {
            return await _context.HospitalBronRoomBeds.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalBronRoomBeds> itemList = await _context.HospitalBronRoomBeds
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalBronRoomBeds>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalBronRoomBeds.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalBronRoomBeds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalBronRoomBeds>> GetHospitalBronRoomBeds(long id)
        {
            var hospitalBronRoomBeds = await _context.HospitalBronRoomBeds.FindAsync(id);

            if (hospitalBronRoomBeds == null)
            {
                return NotFound();
            }

            return hospitalBronRoomBeds;
        }

        // PUT: api/HospitalBronRoomBeds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalBronRoomBeds(long id, HospitalBronRoomBeds hospitalBronRoomBeds)
        {
            if (id != hospitalBronRoomBeds.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalBronRoomBeds).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalBronRoomBedsExists(id))
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

        // POST: api/HospitalBronRoomBeds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalBronRoomBeds>> PostHospitalBronRoomBeds(HospitalBronRoomBeds hospitalBronRoomBeds)
        {
            _context.HospitalBronRoomBeds.Update(hospitalBronRoomBeds);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalBronRoomBeds", new { id = hospitalBronRoomBeds.id }, hospitalBronRoomBeds);
        }

        // DELETE: api/HospitalBronRoomBeds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalBronRoomBeds>> DeleteHospitalBronRoomBeds(long id)
        {
            var hospitalBronRoomBeds = await _context.HospitalBronRoomBeds.FindAsync(id);
            if (hospitalBronRoomBeds == null)
            {
                return NotFound();
            }

            _context.HospitalBronRoomBeds.Remove(hospitalBronRoomBeds);
            await _context.SaveChangesAsync();

            return hospitalBronRoomBeds;
        }

        private bool HospitalBronRoomBedsExists(long id)
        {
            return _context.HospitalBronRoomBeds.Any(e => e.id == id);
        }
    }
}
