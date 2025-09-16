using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.pos;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.pos
{
    [ApiExplorerSettings(GroupName = "v5")]
    [Route("api/[controller]")]
    [ApiController]
    public class PosCreditorController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosCreditorController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosCreditor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosCreditor>>> GetPosCreditor()
        {
            return await _context.PosCreditor.ToListAsync();
        }

        [HttpGet("payForCreaditorCompany")]
        public async Task<ActionResult<PosCreditor>> payForCreaditorCompany([FromQuery]long pos_creaditor_id,double payment_summ)
        {
            var posCreditor = await _context.PosCreditor.FindAsync(pos_creaditor_id);

            if (posCreditor == null)
            {
                return NotFound("Not found creditor");
            }

            if (posCreditor.real_creditor_price < payment_summ) {
                return NotFound("Вы не можете заплатить больше, чем с кредита");
            }

            //yangi item qoshgani kerak bu
            PosCreditorItem item = new PosCreditorItem();
            item.active_status = true;
            item.real_company_id = 0;
            item.PosCreditorid = pos_creaditor_id;
            item.summ = payment_summ;
            _context.PosCreditorItem.Update(item);
            await _context.SaveChangesAsync();


            //bunda summasini update qilib qoyildi
            posCreditor.real_creditor_price = posCreditor.real_creditor_price - payment_summ;
            _context.PosCreditor.Update(posCreditor);
            await _context.SaveChangesAsync();


            return posCreditor;
        }



        [HttpGet("getPaginationPosCreditor")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationPosCreditor([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosCreditor> itemList = await _context.PosCreditor
                .Where(p => p.active_status == true && p.real_creditor_price > 0)
                .Include(p => p.invoice).ThenInclude(p => p.postavshik)
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosCreditor>();
            }

            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosCreditor
                .Where(p => p.active_status == true && p.real_creditor_price > 0).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationPosCreditorForReport")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationPosCreditorForReport([FromQuery] int page,
            [FromQuery] int size, [FromQuery] DateTime begin_date,[FromQuery] DateTime end_date,[FromQuery] long postavshik_company_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosCreditor> itemList = new List<PosCreditor>();
            if (postavshik_company_id == 0) {
                itemList = await _context.PosCreditor
                  .Where(p => p.active_status == true && p.real_creditor_price > 0 && (p.reg_date >= begin_date && p.reg_date <= end_date))
                  .Include(p => p.invoice).ThenInclude(p => p.postavshik)
                  .OrderByDescending(p => p.id)
                  .Skip(size * page).Take(size)
                  .ToListAsync();
            }
            else {
                itemList = await _context.PosCreditor
                  .Include(p => p.invoice).ThenInclude(p => p.postavshik)
                  .Where(p => p.active_status == true && p.real_creditor_price > 0 && (p.reg_date >= begin_date && p.reg_date <= end_date) && p.invoice.postavshik_id == postavshik_company_id)
                  .OrderByDescending(p => p.id)
                  .Skip(size * page).Take(size)
                  .ToListAsync();

            }


            if (itemList == null)
            {
                itemList = new List<PosCreditor>();
            }

            paginationModel.items_list = JArray.FromObject(itemList);
            if (postavshik_company_id == 0) {
                paginationModel.items_count = await _context.PosCreditor
                  .Include(p => p.invoice).ThenInclude(p => p.postavshik)
                  .Where(p => p.active_status == true && p.real_creditor_price > 0 && (p.reg_date >= begin_date && p.reg_date <= end_date) && p.invoice.postavshik_id != postavshik_company_id).CountAsync();
            }
            else {
                paginationModel.items_count = await _context.PosCreditor
                  .Include(p => p.invoice).ThenInclude(p => p.postavshik)
                  .Where(p => p.active_status == true && p.real_creditor_price > 0 && (p.reg_date >= begin_date && p.reg_date <= end_date) && p.invoice.postavshik_id == postavshik_company_id).CountAsync();
            }

            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/PosCreditor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosCreditor>> GetPosCreditor(long id)
        {
            var posCreditor = await _context.PosCreditor.FindAsync(id);

            if (posCreditor == null)
            {
                return NotFound();
            }

            return posCreditor;
        }

        // PUT: api/PosCreditor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosCreditor(long id, PosCreditor posCreditor)
        {
            if (id != posCreditor.id)
            {
                return BadRequest();
            }

            _context.Entry(posCreditor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosCreditorExists(id))
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

        // POST: api/PosCreditor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosCreditor>> PostPosCreditor(PosCreditor posCreditor)
        {
            _context.PosCreditor.Update(posCreditor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosCreditor", new { id = posCreditor.id }, posCreditor);
        }

        // DELETE: api/PosCreditor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosCreditor>> DeletePosCreditor(long id)
        {
            var posCreditor = await _context.PosCreditor.FindAsync(id);
            if (posCreditor == null)
            {
                return NotFound();
            }

            _context.PosCreditor.Remove(posCreditor);
            await _context.SaveChangesAsync();

            return posCreditor;
        }

        private bool PosCreditorExists(long id)
        {
            return _context.PosCreditor.Any(e => e.id == id);
        }
    }
}
