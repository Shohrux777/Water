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
    public class ArchiveRoomDatchikDetailController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ArchiveRoomDatchikDetailController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ArchiveRoomDatchikDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveRoomDatchikDetail>>> GetArchiveRoomDatchikDetail()
        {
            return await _context.ArchiveRoomDatchikDetail.ToListAsync();
        }

        [HttpGet("demoDatchikAdder")]
        public async Task<ActionResult<IEnumerable<ArchiveRoomDatchikDetail>>> demoDatchikDataAdder()
        {
            List<ArchiveRoomDetail> roomDetailList = await _context.ArchiveRoomDetail.Include(p => p.datchik).ToListAsync();
            Random random = new Random();
            List<ArchiveRoomDatchikDetail> roomDatchiksList = new List<ArchiveRoomDatchikDetail>();
            foreach (ArchiveRoomDetail item in roomDetailList)
             {
                ArchiveRoomDatchikDetail element = new ArchiveRoomDatchikDetail();
                element.active_status = true;
                element.created_date_time = DateTime.Now;
                element.date = DateTime.Now;
                element.date_time = DateTime.Now;
                element.updated_date_time = DateTime.Now;
                if (item.datchik.company_id == 0)
                {
                    element.value = 0;
                }
                else {
                    element.value = random.NextDouble() * ((item.datchik.company_id + 2) - (item.datchik.company_id - 2)) + (item.datchik.company_id - 2);
                }

                element.datchik_number = item.datchik.code;
                roomDatchiksList.Add(element);
             }
            _context.ArchiveRoomDatchikDetail.UpdateRange(roomDatchiksList);
            await _context.SaveChangesAsync();
            return roomDatchiksList;
        }

        [HttpGet("getRoomDatchikDataListByRoomIdForReport")]
        public async Task<ActionResult<IEnumerable<ArchiveRoomDatchikDetail>>> getRoomDatchikDataListByRoomIdForReport([FromQuery] long room_id,[FromQuery] DateTime b_date,[FromQuery] DateTime e_date)
        {
            List<ArchiveRoomDatchikDetail> listDatchikDetail = new List<ArchiveRoomDatchikDetail>();

            List<ArchiveRoomDetail> roomDetailList = await _context.ArchiveRoomDetail.Include(p => p.datchik).Where(p => p.ArchiveRoomid == room_id).ToListAsync();
            if (roomDetailList != null && roomDetailList.Count > 0) {
                List<String> datchik_codes = new List<String>();
                foreach (ArchiveRoomDetail item in roomDetailList) {
                    datchik_codes.Add(item.datchik.code);
                }

                listDatchikDetail = await _context.ArchiveRoomDatchikDetail.Where(p => p.date >= b_date && p.date <= e_date).Where(p => datchik_codes.Contains(p.datchik_number)).OrderBy(p => p.id).ToListAsync();
            }
            //datchiklardi nominixam qoshib qoydik
            if (listDatchikDetail != null && listDatchikDetail.Count > 0) {
                foreach (ArchiveRoomDatchikDetail itms in listDatchikDetail) {
                    List<ArchiveDatchik> archiveDatchikList = await _context.ArchiveDatchik.Where(p => p.code == itms.datchik_number).ToListAsync();
                    if (archiveDatchikList != null && archiveDatchikList.Count > 0) {
                        itms.datchik_name = archiveDatchikList.First().name;
                    }

                }

            }

            return listDatchikDetail;
        }


        [HttpGet("getRoomDatchikDataListByRoomId")]
        public async Task<ActionResult<IEnumerable<ArchiveRoomDatchikDetail>>> getRoomDatchikDataListByRoomId([FromQuery] long room_id)
        {
            List<ArchiveRoomDetail> roomDatchiksList = await _context.ArchiveRoomDetail.Include(p => p.datchik).Where(p => p.ArchiveRoomid == room_id).ToListAsync();
            //umuman datchik topilmadi bu xona uchun
            if (roomDatchiksList == null || roomDatchiksList.Count == 0) {
                return NotFound("Datchik umuman topilmadi bu xona uchun");
            }

            //for test begin 
            Random random = new Random();
            List<ArchiveRoomDatchikDetail> listDatchikDetail = new List<ArchiveRoomDatchikDetail>();
            foreach (ArchiveRoomDetail item in roomDatchiksList) {
                ArchiveRoomDatchikDetail element = new ArchiveRoomDatchikDetail();
                element.active_status = true;
                element.created_date_time = DateTime.Now;
                element.date = DateTime.Now;
                element.date_time = DateTime.Now;
                element.updated_date_time = DateTime.Now;
                element.value = random.NextDouble() * (20.5 - 4.2) + 4.2;
                element.datchik_number = item.datchik.code;
                listDatchikDetail.Add(element);
            }
            _context.ArchiveRoomDatchikDetail.UpdateRange(listDatchikDetail);
            await _context.SaveChangesAsync();
            //for test end
          return listDatchikDetail;
        }

        [HttpGet("getRoomDatchikDataListForAllRooms")]
        public async Task<ActionResult<IEnumerable<ArchiveRoom>>> getRoomDatchikDataListForAllRooms()
        {
            //test begin
            await demoDatchikDataAdder();
            //test end
            List<ArchiveRoom> roomList = await _context.ArchiveRoom.ToListAsync();

            foreach (ArchiveRoom room in roomList) { 
            List<ArchiveRoomDetail> roomDatchiksList = await _context.ArchiveRoomDetail.Include(p => p.datchik).Where(p => p.ArchiveRoomid == room.id).ToListAsync();
            
                if (roomDatchiksList == null || roomDatchiksList.Count == 0)
                {
                    room.datchikDataList = new List<ArchiveRoomDatchikDetail>();
                }
                else {

                    List<ArchiveRoomDatchikDetail> selectedDataList = new List<ArchiveRoomDatchikDetail>();
                    List<String> datchikCodesList = new List<String>();
                    foreach (ArchiveRoomDetail item in roomDatchiksList) {
                        List<ArchiveRoomDatchikDetail> datchikDetailSt = await _context.ArchiveRoomDatchikDetail.Where(p => p.datchik_number == item.datchik.code).OrderByDescending(p =>p.id).Take(1).ToListAsync();
                        if (datchikDetailSt != null && datchikDetailSt.Count > 0) {
                            datchikDetailSt.First().min_value = item.datchik.min_value;
                            datchikDetailSt.First().max_value = item.datchik.max_value;
                            datchikDetailSt.First().datchik_name = item.datchik.name;
                            selectedDataList.Add(datchikDetailSt.First());
                            
                        }
                    }
                    room.datchikDataList = selectedDataList;

                }

            }


            return roomList;
        }

        // GET: api/ArchiveRoomDatchikDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchiveRoomDatchikDetail>> GetArchiveRoomDatchikDetail(long id)
        {
            var archiveRoomDatchikDetail = await _context.ArchiveRoomDatchikDetail.FindAsync(id);

            if (archiveRoomDatchikDetail == null)
            {
                return NotFound();
            }

            return archiveRoomDatchikDetail;
        }

        // PUT: api/ArchiveRoomDatchikDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchiveRoomDatchikDetail(long id, ArchiveRoomDatchikDetail archiveRoomDatchikDetail)
        {
            if (id != archiveRoomDatchikDetail.id)
            {
                return BadRequest();
            }

            _context.Entry(archiveRoomDatchikDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveRoomDatchikDetailExists(id))
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

        // POST: api/ArchiveRoomDatchikDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArchiveRoomDatchikDetail>> PostArchiveRoomDatchikDetail(ArchiveRoomDatchikDetail archiveRoomDatchikDetail)
        {
            

            try
            {
                _context.ArchiveRoomDatchikDetail.Update(archiveRoomDatchikDetail);
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

            return CreatedAtAction("GetArchiveRoomDatchikDetail", new { id = archiveRoomDatchikDetail.id }, archiveRoomDatchikDetail);
        }

        // DELETE: api/ArchiveRoomDatchikDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchiveRoomDatchikDetail>> DeleteArchiveRoomDatchikDetail(long id)
        {
            var archiveRoomDatchikDetail = await _context.ArchiveRoomDatchikDetail.FindAsync(id);
            if (archiveRoomDatchikDetail == null)
            {
                return NotFound();
            }

            _context.ArchiveRoomDatchikDetail.Remove(archiveRoomDatchikDetail);
            await _context.SaveChangesAsync();

            return archiveRoomDatchikDetail;
        }

        private bool ArchiveRoomDatchikDetailExists(long id)
        {
            return _context.ArchiveRoomDatchikDetail.Any(e => e.id == id);
        }
    }
}
