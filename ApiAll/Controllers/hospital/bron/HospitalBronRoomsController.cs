using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital;
using ApiAll.Model.hospital.bron;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.hospital.bron
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalBronRoomsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalBronRoomsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalBronRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalBronRooms>>> GetHospitalBronRooms()
        {
            return await _context.HospitalBronRooms.ToListAsync();
        }

        // GET: api/HospitalBronRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalBronRooms>> GetHospitalBronRooms(long id)
        {
            var hospitalBronRooms = await _context.HospitalBronRooms.FindAsync(id);

            if (hospitalBronRooms == null)
            {
                return NotFound();
            }

            return hospitalBronRooms;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalBronRooms> itemList = await _context.HospitalBronRooms
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalBronRooms>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalBronRooms.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/HospitalBronRooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalBronRooms(long id, HospitalBronRooms hospitalBronRooms)
        {
            if (id != hospitalBronRooms.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalBronRooms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalBronRoomsExists(id))
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

        // POST: api/HospitalBronRooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalBronRooms>> PostHospitalBronRooms(HospitalBronRooms hospitalBronRooms)
        {
            _context.HospitalBronRooms.Update(hospitalBronRooms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalBronRooms", new { id = hospitalBronRooms.id }, hospitalBronRooms);
        }

        [HttpPost("AddHospitalBedsTypeAndPrice")]
        public async Task<ActionResult<HospitalBedsTypeAndPrice>> AddHospitalBedsTypeAndPrice(HospitalBedsTypeAndPrice bron)
        {
            _context.HospitalBedsTypeAndPrice.Update(bron);
            await _context.SaveChangesAsync();

            return bron;
        }
        [HttpDelete("deleteHospitalBedsTypeAndPrice")]
        public async Task<ActionResult<HospitalBedsTypeAndPrice>> HospitalBedsTypeAndPrice([FromQuery] long id)
        {
            var hospitalBronRooms = await _context.HospitalBedsTypeAndPrice.FindAsync(id);
            if (hospitalBronRooms == null)
            {
                return NotFound();
            }

            _context.HospitalBedsTypeAndPrice.Remove(hospitalBronRooms);
            await _context.SaveChangesAsync();

            return hospitalBronRooms;
        }

        [HttpGet("getPaginationHospitalBedsTypeAndPrice")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationHospitalBedsTypeAndPrice([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalBedsTypeAndPrice> categoryList = await _context.HospitalBedsTypeAndPrice.Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<HospitalBedsTypeAndPrice>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.HospitalBedsTypeAndPrice.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // DELETE: api/HospitalBronRooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalBronRooms>> DeleteHospitalBronRooms(long id)
        {
            var hospitalBronRooms = await _context.HospitalBronRooms.FindAsync(id);
            if (hospitalBronRooms == null)
            {
                return NotFound();
            }

            _context.HospitalBronRooms.Remove(hospitalBronRooms);
            await _context.SaveChangesAsync();

            return hospitalBronRooms;
        }



        private bool HospitalBronRoomsExists(long id)
        {
            return _context.HospitalBronRooms.Any(e => e.id == id);
        }








        [HttpPost("AddHospitalBedsBronPaymnetsInfo")]
        public async Task<ActionResult<HospitalBedsBronPaymnetsInfo>> AddHospitalBedsBronPaymnetsInfo(HospitalBedsBronPaymnetsInfo bron)
        {
            _context.HospitalBedsBronPaymnetsInfo.Update(bron);
            await _context.SaveChangesAsync();

            return bron;
        }
        [HttpDelete("deleteHospitalBedsBronPaymnetsInfo")]
        public async Task<ActionResult<HospitalBedsBronPaymnetsInfo>> deleteHospitalBedsBronPaymnetsInfo([FromQuery] long id)
        {
            var hospitalBronRooms = await _context.HospitalBedsBronPaymnetsInfo.FindAsync(id);
            if (hospitalBronRooms == null)
            {
                return NotFound();
            }

            _context.HospitalBedsBronPaymnetsInfo.Remove(hospitalBronRooms);
            await _context.SaveChangesAsync();

            return hospitalBronRooms;
        }

        [HttpDelete("payHospitalBedsBronPaymnetsInfo")]
        public async Task<ActionResult<HospitalBedsBronPaymnetsInfo>> payHospitalBedsBronPaymnetsInfo([FromQuery] long id,[FromQuery] double summ)
        {
            var hospitalBronRooms = await _context.HospitalBedsBronPaymnetsInfo.FindAsync(id);
            if (hospitalBronRooms == null)
            {
                return NotFound();
            }
            hospitalBronRooms.payed_summ = hospitalBronRooms.payed_summ + summ;


            _context.HospitalBedsBronPaymnetsInfo.Update(hospitalBronRooms);
            await _context.SaveChangesAsync();

            return hospitalBronRooms;
        }

        [HttpGet("getPaginationHospitalBedsBronPaymnetsInfo")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationHospitalBedsBronPaymnetsInfo([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalBedsBronPaymnetsInfo> categoryList = await _context.HospitalBedsBronPaymnetsInfo.Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<HospitalBedsBronPaymnetsInfo>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.HospitalBedsBronPaymnetsInfo.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }



    }
}
