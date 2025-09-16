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
    public class HospitalTorchController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalTorchController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalTorch
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalTorch>>> GetHospitalTorch()
        {
            return await _context.HospitalTorch.ToListAsync();
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalTorch>> getFullInfoById([FromQuery] long id)
        {
            var item = await _context
                .HospitalTorch
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
            List<HospitalTorch> itemList = await _context.HospitalTorch
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalTorch>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalTorch.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalTorch> itemList = await _context.HospitalTorch
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalTorch>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalTorch
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalTorch/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalTorch>> GetHospitalTorch(long id)
        {
            var hospitalTorch = await _context.HospitalTorch.FindAsync(id);

            if (hospitalTorch == null)
            {
                return NotFound();
            }
            hospitalTorch.patients = await _context.Patients.FindAsync(hospitalTorch.PatientsId);



            return hospitalTorch;
        }

        // PUT: api/HospitalTorch/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalTorch(long id, HospitalTorch hospitalTorch)
        {
            if (id != hospitalTorch.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalTorch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalTorchExists(id))
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

        // POST: api/HospitalTorch
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalTorch>> PostHospitalTorch(HospitalTorch hospitalTorch)
        {
            _context.HospitalTorch.Update(hospitalTorch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalTorch", new { id = hospitalTorch.id }, hospitalTorch);
        }

        // DELETE: api/HospitalTorch/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalTorch>> DeleteHospitalTorch(long id)
        {
            var hospitalTorch = await _context.HospitalTorch.FindAsync(id);
            if (hospitalTorch == null)
            {
                return NotFound();
            }

            _context.HospitalTorch.Remove(hospitalTorch);
            await _context.SaveChangesAsync();

            return hospitalTorch;
        }

        private bool HospitalTorchExists(long id)
        {
            return _context.HospitalTorch.Any(e => e.id == id);
        }
    }
}
