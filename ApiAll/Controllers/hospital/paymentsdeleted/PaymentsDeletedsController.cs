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
using ApiAll.Model;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.hospital.paymentsdeleted
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsDeletedsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PaymentsDeletedsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PaymentsDeleteds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentsDeleted>>> GetPaymentsDeleted()
        {
            return await _context.PaymentsDeleted.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PaymentsDeleted> itemList = await _context.PaymentsDeleted
                .Include(p => p.patients)
                .Include(p => p.serviceType)
                .Include(p => p.authorization)
                .Include(p => p.contragent)
                .OrderByDescending(p => p.Id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PaymentsDeleted>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PaymentsDeleted.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByDateTime")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByDateTime([FromQuery] int page, [FromQuery] int size,
            [FromQuery] DateTime beginDate, [FromQuery] DateTime endDate)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PaymentsDeleted> itemList = await _context.PaymentsDeleted
                .Where(p =>p.deleted_date_time >= beginDate && p.deleted_date_time <= endDate)
                .Include(p => p.patients)
                .Include(p => p.serviceType)
                .Include(p => p.authorization)
                .Include(p => p.contragent)
                .OrderByDescending(p => p.Id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PaymentsDeleted>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PaymentsDeleted.Where(p => p.deleted_date_time >= beginDate && p.deleted_date_time <= endDate).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByAuthId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByAuthId([FromQuery] int page, [FromQuery] int size, [FromQuery] long AuthorizationId)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PaymentsDeleted> itemList = await _context.PaymentsDeleted.Where(p=>p.AuthorizationId == AuthorizationId)
                .Include(p => p.patients)
                .Include(p => p.serviceType)
                .Include(p => p.authorization)
                .Include(p => p.contragent)
                .OrderByDescending(p => p.Id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PaymentsDeleted>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PaymentsDeleted.Where(p => p.AuthorizationId == AuthorizationId).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/PaymentsDeleteds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentsDeleted>> GetPaymentsDeleted(long id)
        {
            var paymentsDeleted = await _context.PaymentsDeleted.FindAsync(id);

            if (paymentsDeleted == null)
            {
                return NotFound();
            }

            return paymentsDeleted;
        }

        // PUT: api/PaymentsDeleteds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentsDeleted(long id, PaymentsDeleted paymentsDeleted)
        {
            if (id != paymentsDeleted.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentsDeleted).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentsDeletedExists(id))
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

        // POST: api/PaymentsDeleteds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PaymentsDeleted>> PostPaymentsDeleted(PaymentsDeleted paymentsDeleted)
        {
            _context.PaymentsDeleted.Update(paymentsDeleted);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentsDeleted", new { id = paymentsDeleted.Id }, paymentsDeleted);
        }

        // DELETE: api/PaymentsDeleteds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentsDeleted>> DeletePaymentsDeleted(long id)
        {
            var paymentsDeleted = await _context.PaymentsDeleted.FindAsync(id);
            if (paymentsDeleted == null)
            {
                return NotFound();
            }

            _context.PaymentsDeleted.Remove(paymentsDeleted);
            await _context.SaveChangesAsync();

            return paymentsDeleted;
        }

        private bool PaymentsDeletedExists(long id)
        {
            return _context.PaymentsDeleted.Any(e => e.Id == id);
        }
    }
}
