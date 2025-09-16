using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.oquv_markaz;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.oquv_markaz
{
    [ApiExplorerSettings(GroupName = "v8")]
    [Route("api/[controller]")]
    [ApiController]
    public class OquvMarkazClientController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazClientController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazClient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazClient>>> GetOquvMarkazClient()
        {
            return await _context.OquvMarkazClient.ToListAsync();
        }

        // GET: api/OquvMarkazClient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazClient>> GetOquvMarkazClient(long id)
        {
            var oquvMarkazClient = await _context.OquvMarkazClient
                .Include(p => p.contragent)
                .Include(p => p.client_type)
                .Where(p=> p.id == id).ToListAsync();

            if (oquvMarkazClient == null || oquvMarkazClient.Count == 0)
            {
                return NotFound();
            }

            return oquvMarkazClient.First();
        }

        [HttpGet("disableOrEnableWaitingStatusoquvmarkazClient")]
        public async Task<ActionResult<OquvMarkazClient>> disableOrEnableWaitingStatusoquvmarkazClient([FromQuery]long clinet_id,[FromQuery] bool status)
        {
            var oquvMarkazClient = await _context.OquvMarkazClient
                .Include(p => p.contragent)
                .Include(p => p.client_type)
                .Where(p => p.id == clinet_id).ToListAsync();

            if (oquvMarkazClient == null || oquvMarkazClient.Count == 0)
            {
                return NotFound();
            }

            oquvMarkazClient.First().waiting_status = status;
            _context.OquvMarkazClient.Update(oquvMarkazClient.First());
            await _context.SaveChangesAsync();

            return oquvMarkazClient.First();
        }

        [HttpGet("getOquvMarkazClientTypePagination")]
        public async Task<ActionResult<TexPaginationModel>> getOquvMarkazClientTypePagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazClientType> categoryList = await _context.OquvMarkazClientType.Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazClientType>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazClientType.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getOquvMarkazTestPagination")]
        public async Task<ActionResult<TexPaginationModel>> getOquvMarkazTestPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazTest> categoryList = await _context.OquvMarkazTest.Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazTest>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazTest.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getOquvMarkazTestResultsByGroupIdPagination")]
        public async Task<ActionResult<TexPaginationModel>> getOquvMarkazTestResultsByGroupIdPagination([FromQuery] int page, [FromQuery] int size,[FromQuery] long group_id,[FromQuery] DateTime b_date,[FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazTestResult> categoryList = await _context.OquvMarkazTestResult
                .Include(p =>p.oquvchi)
                .Include(p => p.test)
                .Include(p => p.group)
                .Where(p => p.active_status == true
                && p.OquvMarkazPupilGroupsid == group_id
                && (p.created_date_time >= b_date && p.created_date_time <= e_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazTestResult>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazTestResult
               .Where(p => p.active_status == true
                && p.OquvMarkazPupilGroupsid == group_id
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getOquvMarkazTestResultsByClientIdPagination")]
        public async Task<ActionResult<TexPaginationModel>> getOquvMarkazTestResultsByClientIdPagination([FromQuery] int page, [FromQuery] int size, [FromQuery] long client_id, [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazTestResult> categoryList = await _context.OquvMarkazTestResult
                .Include(p => p.oquvchi)
                .Include(p => p.test)
                .Include(p => p.group)
                .Where(p => p.active_status == true
                && p.OquvMarkazClientid == client_id
                && (p.created_date_time >= b_date && p.created_date_time <= e_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazTestResult>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazTestResult
               .Where(p => p.active_status == true
                && p.OquvMarkazClientid == client_id
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getOquvMarkazTestResultsByClientIdAndGroupIdPagination")]
        public async Task<ActionResult<TexPaginationModel>> getOquvMarkazTestResultsByClientIdAndGroupIdPagination([FromQuery] int page, [FromQuery] int size, [FromQuery] long client_id, [FromQuery] long group_id,  [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazTestResult> categoryList = await _context.OquvMarkazTestResult
                .Include(p => p.oquvchi)
                .Include(p => p.test)
                .Include(p => p.group)
                .Where(p => p.active_status == true
                && p.OquvMarkazClientid == client_id && p.OquvMarkazPupilGroupsid == group_id
                && (p.created_date_time >= b_date && p.created_date_time <= e_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazTestResult>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazTestResult
               .Where(p => p.active_status == true
                && p.OquvMarkazClientid == client_id && p.OquvMarkazPupilGroupsid == group_id
                && (p.created_date_time >= b_date && p.created_date_time <= e_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getOquvMarkazContragentPagination")]
        public async Task<ActionResult<TexPaginationModel>> getOquvMarkazContragentPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazContragent> categoryList = await _context.OquvMarkazContragent.Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazContragent>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazContragent.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getTestResultsByClientIdPagination")]
        public async Task<ActionResult<TexPaginationModel>> getTestResultsByClientIdPagination([FromQuery] int page, [FromQuery] int size,[FromQuery] long client_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazTestResult> categoryList = await _context.OquvMarkazTestResult
                .Where(p => p.active_status == true && p.OquvMarkazClientid == client_id)
                .Include(p =>p.test)
                .Include(p =>p.oquvchi)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazTestResult>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazTestResult.Where(p => p.active_status == true && p.OquvMarkazClientid == client_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getTestResultsByClientIdAndDatesPagination")]
        public async Task<ActionResult<TexPaginationModel>> getTestResultsByClientIdAndDatesPagination([FromQuery] int page, [FromQuery] int size, [FromQuery] long client_id,[FromQuery] DateTime begin_date, [FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazTestResult> categoryList = await _context.OquvMarkazTestResult
                .Where(p => p.active_status == true && p.OquvMarkazClientid == client_id && (p.created_date_time >= begin_date && p.created_date_time <= end_date))
                .Include(p => p.test)
                .Include(p => p.oquvchi)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazTestResult>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazTestResult
                .Where(p => p.active_status == true && p.OquvMarkazClientid == client_id && (p.created_date_time >= begin_date && p.created_date_time <= end_date))
                .CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getTestResultsByClientIdAndDatesAndGroupIdPagination")]
        public async Task<ActionResult<TexPaginationModel>> getTestResultsByClientIdAndDatesAndGroupIdPagination([FromQuery] int page, [FromQuery] int size, [FromQuery] long group_id, [FromQuery] long client_id, [FromQuery] DateTime begin_date, [FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazTestResult> categoryList = await _context.OquvMarkazTestResult
                .Where(p => p.active_status == true && p.OquvMarkazPupilGroupsid == group_id && p.OquvMarkazClientid == client_id && (p.created_date_time >= begin_date && p.created_date_time <= end_date))
                .Include(p => p.test)
                .Include(p => p.oquvchi)
                .Include(p => p.group)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazTestResult>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazTestResult
                .Where(p => p.active_status == true && p.OquvMarkazClientid == client_id  && p.OquvMarkazPupilGroupsid == group_id && (p.created_date_time >= begin_date && p.created_date_time <= end_date))
                .CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getOquvMarkazTestById")]
        public async Task<ActionResult<OquvMarkazTest>> getOquvMarkazTestById([FromQuery]long id)
        {
            var oquvMarkazClient = await _context.OquvMarkazTest.FindAsync(id);

            if (oquvMarkazClient == null)
            {
                return NotFound();
            }

            return oquvMarkazClient;
        }

        [HttpGet("getOquvMarkazContragentById")]
        public async Task<ActionResult<OquvMarkazContragent>> getOquvMarkazContragentById([FromQuery] long id)
        {
            var oquvMarkazClient = await _context.OquvMarkazContragent.FindAsync(id);

            if (oquvMarkazClient == null)
            {
                return NotFound();
            }

            return oquvMarkazClient;
        }

        [HttpGet("getOquvMarkazClientTypeById")]
        public async Task<ActionResult<OquvMarkazClientType>> getOquvMarkazClientTypeById([FromQuery] long id)
        {
            var oquvMarkazClient = await _context.OquvMarkazClientType.FindAsync(id);

            if (oquvMarkazClient == null)
            {
                return NotFound();
            }

            return oquvMarkazClient;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazClient> categoryList = await _context.OquvMarkazClient
                .Include(p => p.contragent)
                .Include(p => p.client_type)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazClient>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazClient.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getTolovPaginationByOquvchiEndGroupId")]
        public async Task<ActionResult<TexPaginationModel>> getTolovPaginationByOquvchiEndGroupId([FromQuery] int page, [FromQuery] int size,[FromQuery] long oquvchi_id, [FromQuery] long group_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazGruppagaTolov> categoryList = await _context.OquvMarkazGruppagaTolov
                .Include(p => p.oquvchi)
                .Include(p => p.group)
                .Where(p => p.active_status == true && p.OquvMarkazClientid == oquvchi_id && p.OquvMarkazPupilGroupsid == group_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazGruppagaTolov>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazGruppagaTolov
                .Where(p => p.active_status == true && p.OquvMarkazClientid == oquvchi_id && p.OquvMarkazPupilGroupsid == group_id)
                .CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getTolovPaginationByGroupIdAndDate")]
        public async Task<ActionResult<TexPaginationModel>> getTolovPaginationByGroupIdAndDate([FromQuery] int page, [FromQuery] int size, [FromQuery] long oquvchi_id, [FromQuery] long group_id, [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazGruppagaTolov> categoryList = await _context.OquvMarkazGruppagaTolov
                .Include(p => p.oquvchi)
                .Include(p => p.group)
                .Where(p => p.active_status == true
                && p.OquvMarkazClientid == oquvchi_id
                && p.OquvMarkazPupilGroupsid == group_id && ( p.created_date_time >= b_date && p.created_date_time <= e_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazGruppagaTolov>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazGruppagaTolov
                .Where(p => p.active_status == true
                && p.OquvMarkazClientid == oquvchi_id
                && p.OquvMarkazPupilGroupsid == group_id && ( p.created_date_time >= b_date && p.created_date_time <= e_date))
                .CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationByDateTime")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByDateTime([FromQuery] int page, [FromQuery] int size,[FromQuery] DateTime b_date,[FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazClient> categoryList = await _context.OquvMarkazClient
                .Include(p => p.contragent)
                .Include(p => p.client_type)
                .Where(p => p.active_status == true && p.created_date_time >= b_date && p.created_date_time <= e_date)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazClient>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazClient.Where(p => p.active_status == true && p.created_date_time >= b_date && p.created_date_time <= e_date).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationNotWaiting")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationNotWaiting([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazClient> categoryList = await _context.OquvMarkazClient
                .Include(p =>p.contragent)
                .Include(p =>p.client_type)
                .Where(p => p.waiting_status == false)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazClient>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazClient.Where(p => p.waiting_status == false).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationWaitingByDate")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationWaitingByDate([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazClient> categoryList = await _context.OquvMarkazClient
                .Include(p => p.contragent)
                .Include(p => p.client_type)
                .Where(p => p.waiting_status == true && p.created_date_time >= b_date && p.created_date_time <= e_date)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazClient>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazClient
            .Where(p => p.waiting_status == true && p.created_date_time >= b_date && p.created_date_time <= e_date)
            .CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationWaiting")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationWaiting([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazClient> categoryList = await _context.OquvMarkazClient
                .Include(p => p.contragent)
                .Include(p => p.client_type)
                .Where(p => p.waiting_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazClient>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazClient.Where(p => p.waiting_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationNotWaitingByLevelId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationNotWaitingByLevelId([FromQuery] int page, [FromQuery] int size, [FromQuery] long client_type_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazClient> categoryList = await _context.OquvMarkazClient
                .Include(p => p.contragent)
                .Include(p => p.client_type)
                .Where(p => p.waiting_status == false && p.OquvMarkazClientTypeid == client_type_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazClient>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazClient
                .Where(p => p.waiting_status == false && p.OquvMarkazClientTypeid == client_type_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationWaitingByLevelId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationWaitingByLevelId([FromQuery] int page, [FromQuery] int size, [FromQuery] long client_type_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazClient> categoryList = await _context.OquvMarkazClient
                .Include(p => p.contragent)
                .Include(p => p.client_type)
                .Where(p => p.waiting_status == true && p.OquvMarkazClientTypeid== client_type_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazClient>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazClient
                .Where(p => p.waiting_status == true && p.OquvMarkazClientTypeid == client_type_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByClientName")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByClientName([FromQuery] int page, [FromQuery] int size,[FromQuery] String fio)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazClient> categoryList = new List<OquvMarkazClient>();

            if (fio == null || fio.Trim().Length == 0)
            {
                categoryList = await _context.OquvMarkazClient
  .Where(p => p.active_status == true )
  .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            }
            else {
                categoryList = await _context.OquvMarkazClient
  .Where(p => p.active_status == true && p.fio.ToLower().Contains(fio.ToLower()))
  .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            }



            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazClient>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);

            if (fio == null || fio.Trim().Length == 0)
            {
                paginationModel.items_count = await _context.OquvMarkazClient
    .Where(p => p.active_status == true)
    .CountAsync();
            }
            else {
                paginationModel.items_count = await _context.OquvMarkazClient
    .Where(p => p.active_status == true && p.fio.ToLower().Contains(fio.ToLower()))
    .CountAsync();

            }



            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/OquvMarkazClient/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazClient(long id, OquvMarkazClient oquvMarkazClient)
        {
            if (id != oquvMarkazClient.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazClient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazClientExists(id))
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

        // POST: api/OquvMarkazClient
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazClient>> PostOquvMarkazClient(OquvMarkazClient oquvMarkazClient)
        {
            _context.OquvMarkazClient.Update(oquvMarkazClient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazClient", new { id = oquvMarkazClient.id }, oquvMarkazClient);
        }

        [HttpPost("addOquvMarkazTest")]
        public async Task<ActionResult<OquvMarkazTest>> addOquvMarkazTest(OquvMarkazTest item)
        {
            _context.OquvMarkazTest.Update(item);
            await _context.SaveChangesAsync();

            return item;
        }



        [HttpPost("addOquvMarkazTolov")]
        public async Task<ActionResult<OquvMarkazGruppagaTolov>> addOquvMarkazTolov(OquvMarkazGruppagaTolov item)
        {
            _context.OquvMarkazGruppagaTolov.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        [HttpDelete("deleteOquvMarkazTest")]
        public async Task<ActionResult<OquvMarkazTest>> deleteOquvMarkazTest([FromQuery] long id)
        {
            var oquvMarkazClient = await _context.OquvMarkazTest.FindAsync(id);
            if (oquvMarkazClient == null)
            {
                return NotFound();
            }
            _context.OquvMarkazTest.Remove(oquvMarkazClient);
            await _context.SaveChangesAsync();

            return oquvMarkazClient;
        }

        [HttpPost("addOquvMarkazTestResult")]
        public async Task<ActionResult<OquvMarkazTestResult>> addOquvMarkazTestResult(OquvMarkazTestResult item)
        {
            _context.OquvMarkazTestResult.Update(item);
            await _context.SaveChangesAsync();

            return item;
        }

        [HttpPost("addOquvMarkazTestResultList")]
        public async Task<ActionResult<IEnumerable<OquvMarkazTestResult>>> addOquvMarkazTestResultList(List<OquvMarkazTestResult> item)
        {
            _context.OquvMarkazTestResult.UpdateRange(item);
            await _context.SaveChangesAsync();

            return item;
        }

        [HttpDelete("deleteOquvMarkazTestResult")]
        public async Task<ActionResult<OquvMarkazTestResult>> deleteOquvMarkazTestResult([FromQuery] long id)
        {
            var oquvMarkazClient = await _context.OquvMarkazTestResult.FindAsync(id);
            if (oquvMarkazClient == null)
            {
                return NotFound();
            }
            _context.OquvMarkazTestResult.Remove(oquvMarkazClient);
            await _context.SaveChangesAsync();

            return oquvMarkazClient;
        }


        [HttpPost("addOquvMarkazContragent")]
        public async Task<ActionResult<OquvMarkazContragent>> addOquvMarkazContragent(OquvMarkazContragent item)
        {
            _context.OquvMarkazContragent.Update(item);
            await _context.SaveChangesAsync();

            return item;
        }

        [HttpDelete("deleteOquvMarkazContragent")]
        public async Task<ActionResult<OquvMarkazContragent>> deleteOquvMarkazContragent([FromQuery] long id)
        {
            var oquvMarkazClient = await _context.OquvMarkazContragent.FindAsync(id);
            if (oquvMarkazClient == null)
            {
                return NotFound();
            }
            _context.OquvMarkazContragent.Remove(oquvMarkazClient);
            await _context.SaveChangesAsync();

            return oquvMarkazClient;
        }

        [HttpPost("addOquvMarkazClientType")]
        public async Task<ActionResult<OquvMarkazClientType>> addOquvMarkazClientType(OquvMarkazClientType item)
        {
            _context.OquvMarkazClientType.Update(item);
            await _context.SaveChangesAsync();

            return item;
        }


        [HttpDelete("deleteOquvMarkazClientType")]
        public async Task<ActionResult<OquvMarkazClientType>> deleteOquvMarkazClientType([FromQuery] long id)
        {
            var oquvMarkazClient = await _context.OquvMarkazClientType.FindAsync(id);
            if (oquvMarkazClient == null)
            {
                return NotFound();
            }
            _context.OquvMarkazClientType.Remove(oquvMarkazClient);
            await _context.SaveChangesAsync();

            return oquvMarkazClient;
        }

        // DELETE: api/OquvMarkazClient/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazClient>> DeleteOquvMarkazClient(long id)
        {
            var oquvMarkazClient = await _context.OquvMarkazClient.FindAsync(id);
            if (oquvMarkazClient == null)
            {
                return NotFound();
            }

            _context.OquvMarkazClient.Remove(oquvMarkazClient);
            await _context.SaveChangesAsync();

            return oquvMarkazClient;
        }

        private bool OquvMarkazClientExists(long id)
        {
            return _context.OquvMarkazClient.Any(e => e.id == id);
        }
    }
}
