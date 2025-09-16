using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model;
using Newtonsoft.Json.Linq;
using ApiAll.Model.tekistil;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalMrtSorovNomasController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalMrtSorovNomasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalMrtSorovNomas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalMrtSorovNoma>>> GetHospitalMrtSorovNoma()
        {
            return await _context.HospitalMrtSorovNoma.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalMrtSorovNoma> itemList = await _context.HospitalMrtSorovNoma
                .Include(p => p.patients)
                .Include(p => p.contragent)
                .OrderByDescending(p => p.Id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalMrtSorovNoma>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalMrtSorovNoma.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getSorovnomaListByPatientId")]
        public async Task<ActionResult<IEnumerable<HospitalMrtSorovNoma>>> getSorovnomaListByPatientId([FromQuery] long patientId)
        {
            return await _context.HospitalMrtSorovNoma.Include(p => p.PatientsId == patientId).ToListAsync();
        }

        [HttpGet("getSorovnomaListByContragentId")]
        public async Task<ActionResult<IEnumerable<HospitalMrtSorovNoma>>> getSorovnomaListByContragentId([FromQuery] long contragentId)
        {
            return await _context.HospitalMrtSorovNoma.Include(p => p.ContragentId == contragentId).ToListAsync();
        }

        // GET: api/HospitalMrtSorovNomas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalMrtSorovNoma>> GetHospitalMrtSorovNoma(long id)
        {
            var hospitalMrtSorovNoma = await _context.HospitalMrtSorovNoma.FindAsync(id);

            if (hospitalMrtSorovNoma == null)
            {
                return NotFound();
            }

            return hospitalMrtSorovNoma;
        }

        // PUT: api/HospitalMrtSorovNomas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalMrtSorovNoma(long id, HospitalMrtSorovNoma hospitalMrtSorovNoma)
        {
            if (id != hospitalMrtSorovNoma.Id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalMrtSorovNoma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalMrtSorovNomaExists(id))
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

        // POST: api/HospitalMrtSorovNomas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalMrtSorovNoma>> PostHospitalMrtSorovNoma(HospitalMrtSorovNoma hospitalMrtSorovNoma)
        {
            _context.HospitalMrtSorovNoma.Update(hospitalMrtSorovNoma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalMrtSorovNoma", new { id = hospitalMrtSorovNoma.Id }, hospitalMrtSorovNoma);
        }

        // DELETE: api/HospitalMrtSorovNomas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalMrtSorovNoma>> DeleteHospitalMrtSorovNoma(long id)
        {
            var hospitalMrtSorovNoma = await _context.HospitalMrtSorovNoma.FindAsync(id);
            if (hospitalMrtSorovNoma == null)
            {
                return NotFound();
            }

            _context.HospitalMrtSorovNoma.Remove(hospitalMrtSorovNoma);
            await _context.SaveChangesAsync();

            return hospitalMrtSorovNoma;
        }

        private bool HospitalMrtSorovNomaExists(long id)
        {
            return _context.HospitalMrtSorovNoma.Any(e => e.Id == id);
        }
    }
}
