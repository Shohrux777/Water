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
    public class OquvMarkazDebitController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazDebitController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazDebit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazDebit>>> GetOquvMarkazDebit()
        {
            return await _context.OquvMarkazDebit.ToListAsync();
        }

        // GET: api/OquvMarkazDebit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazDebit>> GetOquvMarkazDebit(long id)
        {
            var oquvMarkazDebit = await _context.OquvMarkazDebit.FindAsync(id);

            if (oquvMarkazDebit == null)
            {
                return NotFound();
            }

            return oquvMarkazDebit;
        }

        [HttpGet("getDebitByClientId")]
        public async Task<ActionResult<OquvMarkazDebit>> getDebitByClientId([FromQuery]long client_id)
        {
            var oquvMarkazDebit = await _context.OquvMarkazDebit
                .Include(p =>p.client)
                .Include(p => p.items)
                .ThenInclude(p =>p.check)
                .Where(p => p.OquvMarkazClientid == client_id).ToListAsync();

            if (oquvMarkazDebit == null && oquvMarkazDebit.Count == 0)
            {
                return NotFound();
            }

            return oquvMarkazDebit.First();
        }

        [HttpGet("getPayDebitClientSumm")]
        public async Task<ActionResult<OquvMarkazDebit>> getPayDebitClientSumm([FromQuery]long debit_id, [FromQuery] double summ, [FromQuery] bool card_or_cash)
        {
            var oquvMarkazDebit = await _context.OquvMarkazDebit.FindAsync(debit_id);
            
            if (oquvMarkazDebit == null)
            {
                return NotFound();
            }

            oquvMarkazDebit.real_summ = oquvMarkazDebit.real_summ - summ;
            _context.OquvMarkazDebit.Update(oquvMarkazDebit);
            await _context.SaveChangesAsync();

            OquvMarkazCheck check = new OquvMarkazCheck();
            check.active_status = true;
            check.OquvMarkazClientid = oquvMarkazDebit.OquvMarkazClientid;
            if (card_or_cash) {

                check.cash = summ;

            }
            else {
               
                check.card = summ;
            }

            _context.OquvMarkazCheck.Update(check);
            await _context.SaveChangesAsync();


            OquvMarkazDebitItem item = new OquvMarkazDebitItem();
            item.active_status = true;
            item.OquvMarkazCheckid = check.id;
            item.OquvMarkazDebitid = oquvMarkazDebit.id;
            item.summ =  -1 * summ;

            _context.OquvMarkazDebitItem.Update(item);
            await _context.SaveChangesAsync();


            return oquvMarkazDebit;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazDebit> categoryList = await _context.OquvMarkazDebit
                .Include(p => p.client)
                .Include(p => p.items)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazDebit>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazDebit.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationFullWithClient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationFullWithClient([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazDebit> categoryList = await _context.OquvMarkazDebit
                .Include(p => p.client)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazDebit>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazDebit.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // PUT: api/OquvMarkazDebit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazDebit(long id, OquvMarkazDebit oquvMarkazDebit)
        {
            if (id != oquvMarkazDebit.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazDebit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazDebitExists(id))
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

        // POST: api/OquvMarkazDebit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazDebit>> PostOquvMarkazDebit(OquvMarkazDebit oquvMarkazDebit)
        {
            _context.OquvMarkazDebit.Update(oquvMarkazDebit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazDebit", new { id = oquvMarkazDebit.id }, oquvMarkazDebit);
        }

        // DELETE: api/OquvMarkazDebit/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazDebit>> DeleteOquvMarkazDebit(long id)
        {
            var oquvMarkazDebit = await _context.OquvMarkazDebit.FindAsync(id);
            if (oquvMarkazDebit == null)
            {
                return NotFound();
            }

            _context.OquvMarkazDebit.Remove(oquvMarkazDebit);
            await _context.SaveChangesAsync();

            return oquvMarkazDebit;
        }



        private bool OquvMarkazDebitExists(long id)
        {
            return _context.OquvMarkazDebit.Any(e => e.id == id);
        }
    }
}
