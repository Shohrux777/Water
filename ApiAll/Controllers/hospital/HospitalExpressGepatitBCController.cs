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

namespace ApiAll.Controllers.hospital
{

    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalExpressGepatitBCController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalExpressGepatitBCController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalExpressGepatitBC
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalExpressGepatitBC>>> GetHospitalExpressGepatitBC()
        {
            return await _context.HospitalExpressGepatitBC.ToListAsync();
        }


        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalExpressGepatitBC>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalExpressGepatitBC
                .Include(p => p.patients)
                .Where(p => p.id == id).ToListAsync();

            if (item == null || item.Count() == 0)
            {
                return NotFound();
            }

            return item.First();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalExpressGepatitBC> itemList = await _context.HospitalExpressGepatitBC
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalExpressGepatitBC>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalExpressGepatitBC.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalExpressGepatitBC> itemList = await _context.HospitalExpressGepatitBC
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalExpressGepatitBC>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalExpressGepatitBC
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalExpressGepatitBC/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalExpressGepatitBC>> GetHospitalExpressGepatitBC(long id)
        {
            var hospitalExpressGepatitBC = await _context.HospitalExpressGepatitBC.FindAsync(id);

            if (hospitalExpressGepatitBC == null)
            {
                return NotFound();
            }

            hospitalExpressGepatitBC.patients = await _context.Patients.FindAsync(hospitalExpressGepatitBC.PatientsId);

            return hospitalExpressGepatitBC;
        }

        // PUT: api/HospitalExpressGepatitBC/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalExpressGepatitBC(long id, HospitalExpressGepatitBC hospitalExpressGepatitBC)
        {
            if (id != hospitalExpressGepatitBC.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalExpressGepatitBC).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalExpressGepatitBCExists(id))
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

        // POST: api/HospitalExpressGepatitBC
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalExpressGepatitBC>> PostHospitalExpressGepatitBC(HospitalExpressGepatitBC hospitalExpressGepatitBC)
        {
            _context.HospitalExpressGepatitBC.Update(hospitalExpressGepatitBC);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalExpressGepatitBC", new { id = hospitalExpressGepatitBC.id }, hospitalExpressGepatitBC);
        }

        // DELETE: api/HospitalExpressGepatitBC/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalExpressGepatitBC>> DeleteHospitalExpressGepatitBC(long id)
        {
            var hospitalExpressGepatitBC = await _context.HospitalExpressGepatitBC.FindAsync(id);
            if (hospitalExpressGepatitBC == null)
            {
                return NotFound();
            }

            _context.HospitalExpressGepatitBC.Remove(hospitalExpressGepatitBC);
            await _context.SaveChangesAsync();

            return hospitalExpressGepatitBC;
        }

        private bool HospitalExpressGepatitBCExists(long id)
        {
            return _context.HospitalExpressGepatitBC.Any(e => e.id == id);
        }
    }
}
