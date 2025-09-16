using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital.bron;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.hospital.bron
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalBedsBronPaymnetsInfoesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalBedsBronPaymnetsInfoesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalBedsBronPaymnetsInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalBedsBronPaymnetsInfo>>> GetHospitalBedsBronPaymnetsInfo()
        {
            return await _context.HospitalBedsBronPaymnetsInfo.ToListAsync();
        }

        // GET: api/HospitalBedsBronPaymnetsInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalBedsBronPaymnetsInfo>> GetHospitalBedsBronPaymnetsInfo(long id)
        {
            var hospitalBedsBronPaymnetsInfo = await _context.HospitalBedsBronPaymnetsInfo.FindAsync(id);

            if (hospitalBedsBronPaymnetsInfo == null)
            {
                return NotFound();
            }

            return hospitalBedsBronPaymnetsInfo;
        }


        // GET: api/HospitalBedsBronPaymnetsInfoes/5
        [HttpGet("xonaUchunTolash")]
        public async Task<ActionResult<HospitalBedsBronPaymnetsInfo>> xonaUchunTolash([FromQuery]long info_id,[FromQuery] double summ_for_pay)
        {
            var hospitalBedsBronPaymnetsInfo = await _context.HospitalBedsBronPaymnetsInfo.FindAsync(info_id);

            if (hospitalBedsBronPaymnetsInfo == null)
            {
                return NotFound();
            }
            hospitalBedsBronPaymnetsInfo.payed_summ = hospitalBedsBronPaymnetsInfo.payed_summ + summ_for_pay;

            _context.HospitalBedsBronPaymnetsInfo.Update(hospitalBedsBronPaymnetsInfo);
            await _context.SaveChangesAsync();


            return hospitalBedsBronPaymnetsInfo;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalBedsBronPaymnetsInfo> itemList = await _context.HospitalBedsBronPaymnetsInfo
                .OrderByDescending(p => p.id)
                .Include(p => p.bron)
                .ThenInclude(p =>p.patient)
                .Include(p =>p.bron)
                .ThenInclude(p =>p.bed)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalBedsBronPaymnetsInfo>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalBedsBronPaymnetsInfo.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationQarzdorlar")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationQarzdorlar([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalBedsBronPaymnetsInfo> itemList = await _context.HospitalBedsBronPaymnetsInfo
                .OrderByDescending(p => p.id)
                .Include(p => p.bron)
                .ThenInclude(p => p.patient)
                .Include(p => p.bron)
                .ThenInclude(p => p.bed)
                .Where( p=>p.active_status == true && p.real_summ != p.payed_summ)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalBedsBronPaymnetsInfo>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalBedsBronPaymnetsInfo.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/HospitalBedsBronPaymnetsInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalBedsBronPaymnetsInfo(long id, HospitalBedsBronPaymnetsInfo hospitalBedsBronPaymnetsInfo)
        {
            if (id != hospitalBedsBronPaymnetsInfo.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalBedsBronPaymnetsInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalBedsBronPaymnetsInfoExists(id))
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

        // POST: api/HospitalBedsBronPaymnetsInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalBedsBronPaymnetsInfo>> PostHospitalBedsBronPaymnetsInfo(HospitalBedsBronPaymnetsInfo hospitalBedsBronPaymnetsInfo)
        {
            _context.HospitalBedsBronPaymnetsInfo.Update(hospitalBedsBronPaymnetsInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalBedsBronPaymnetsInfo", new { id = hospitalBedsBronPaymnetsInfo.id }, hospitalBedsBronPaymnetsInfo);
        }

        // DELETE: api/HospitalBedsBronPaymnetsInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalBedsBronPaymnetsInfo>> DeleteHospitalBedsBronPaymnetsInfo(long id)
        {
            var hospitalBedsBronPaymnetsInfo = await _context.HospitalBedsBronPaymnetsInfo.FindAsync(id);
            if (hospitalBedsBronPaymnetsInfo == null)
            {
                return NotFound();
            }

            _context.HospitalBedsBronPaymnetsInfo.Remove(hospitalBedsBronPaymnetsInfo);
            await _context.SaveChangesAsync();

            return hospitalBedsBronPaymnetsInfo;
        }

        private bool HospitalBedsBronPaymnetsInfoExists(long id)
        {
            return _context.HospitalBedsBronPaymnetsInfo.Any(e => e.id == id);
        }
    }
}
