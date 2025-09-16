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

namespace ApiAll.Controllers.hospital
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalDoctorShablonsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalDoctorShablonsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalDoctorShablons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalDoctorShablons>>> GetHospitalDoctorShablons()
        {
            return await _context.HospitalDoctorShablons.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalDoctorShablons> itemList = await _context.HospitalDoctorShablons
                .OrderByDescending(p => p.id)
                .Include(p => p.authorization)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalDoctorShablons>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalDoctorShablons.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByAuthId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByAuthId([FromQuery] int page, [FromQuery] int size, [FromQuery] long auth_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalDoctorShablons> itemList = await _context.HospitalDoctorShablons
                .OrderByDescending(p => p.id)
                .Include(p => p.authorization)
                .Where(p => p.AuthorizationId == auth_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalDoctorShablons>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalDoctorShablons
                .Where(p => p.AuthorizationId == auth_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalDoctorShablons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalDoctorShablons>> GetHospitalDoctorShablons(long id)
        {
            var hospitalDoctorShablons = await _context.HospitalDoctorShablons.FindAsync(id);

            if (hospitalDoctorShablons == null)
            {
                return NotFound();
            }

            return hospitalDoctorShablons;
        }

        // PUT: api/HospitalDoctorShablons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalDoctorShablons(long id, HospitalDoctorShablons hospitalDoctorShablons)
        {
            if (id != hospitalDoctorShablons.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalDoctorShablons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalDoctorShablonsExists(id))
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

        // POST: api/HospitalDoctorShablons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalDoctorShablons>> PostHospitalDoctorShablons(HospitalDoctorShablons hospitalDoctorShablons)
        {
            _context.HospitalDoctorShablons.Update(hospitalDoctorShablons);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalDoctorShablons", new { id = hospitalDoctorShablons.id }, hospitalDoctorShablons);
        }

        // DELETE: api/HospitalDoctorShablons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalDoctorShablons>> DeleteHospitalDoctorShablons(long id)
        {
            var hospitalDoctorShablons = await _context.HospitalDoctorShablons.FindAsync(id);
            if (hospitalDoctorShablons == null)
            {
                return NotFound();
            }

            _context.HospitalDoctorShablons.Remove(hospitalDoctorShablons);
            await _context.SaveChangesAsync();

            return hospitalDoctorShablons;
        }

        private bool HospitalDoctorShablonsExists(long id)
        {
            return _context.HospitalDoctorShablons.Any(e => e.id == id);
        }
    }
}
