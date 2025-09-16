using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContragentAdditionalPaymentBefohandsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ContragentAdditionalPaymentBefohandsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ContragentAdditionalPaymentBefohands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContragentAdditionalPaymentBefohand>>> GetContragentAdditionalPaymentBefohand()
        {
            return await _context.ContragentAdditionalPaymentBefohand.Include( p => p.contragent).Include( p => p.authorization).OrderByDescending(p => p.Id).ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<ContragentAdditionalPaymentBefohand> itemList = await _context.ContragentAdditionalPaymentBefohand
                .Include(p => p.contragent)
                .Include(p => p.authorization)
                .OrderByDescending(p => p.Id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<ContragentAdditionalPaymentBefohand>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.ContragentAdditionalPaymentBefohand.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/ContragentAdditionalPaymentBefohands
        [HttpGet("getContragentAdditionalPaymentBefohandByContragentId")]
        public async Task<ActionResult<IEnumerable<ContragentAdditionalPaymentBefohand>>> getContragentAdditionalPaymentBefohandByContragentId([FromQuery] long contragentId)
        {
            return await _context.ContragentAdditionalPaymentBefohand.Where( p => p.ContragentId == contragentId).Include(p => p.contragent).Include(p => p.authorization).OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/ContragentAdditionalPaymentBefohands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContragentAdditionalPaymentBefohand>> GetContragentAdditionalPaymentBefohand(long id)
        {
            var contragentAdditionalPaymentBefohand = await _context.ContragentAdditionalPaymentBefohand.FindAsync(id);

            if (contragentAdditionalPaymentBefohand == null)
            {
                return NotFound();
            }

            return contragentAdditionalPaymentBefohand;
        }

        // PUT: api/ContragentAdditionalPaymentBefohands/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContragentAdditionalPaymentBefohand(long id, ContragentAdditionalPaymentBefohand contragentAdditionalPaymentBefohand)
        {
            if (id != contragentAdditionalPaymentBefohand.Id)
            {
                return BadRequest();
            }

            _context.Entry(contragentAdditionalPaymentBefohand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContragentAdditionalPaymentBefohandExists(id))
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

        // POST: api/ContragentAdditionalPaymentBefohands
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ContragentAdditionalPaymentBefohand>> PostContragentAdditionalPaymentBefohand(ContragentAdditionalPaymentBefohand contragentAdditionalPaymentBefohand)
        {
            _context.ContragentAdditionalPaymentBefohand.Update(contragentAdditionalPaymentBefohand);
            await _context.SaveChangesAsync();

            if (contragentAdditionalPaymentBefohand != null) {
                List<ContragentAdditionalPaymentBefohandFullInfo> befohandFullInfo = await _context.ContragentAdditionalPaymentBefohandFullInfo.Where(p => p.ContragentId == contragentAdditionalPaymentBefohand.ContragentId).ToListAsync();

                if (befohandFullInfo != null && befohandFullInfo.Count > 0)
                {
                    ContragentAdditionalPaymentBefohandFullInfo fullInfo = befohandFullInfo.First();
                    double qtySumNew = fullInfo.qtySumm + contragentAdditionalPaymentBefohand.summa;
                    double realSummQty = fullInfo.realQty + contragentAdditionalPaymentBefohand.summa;
                    fullInfo.qtySumm = qtySumNew;
                    fullInfo.realQty = realSummQty;
                    _context.ContragentAdditionalPaymentBefohandFullInfo.Update(fullInfo);
                    await _context.SaveChangesAsync();
                }
                else {
                    ContragentAdditionalPaymentBefohandFullInfo paymentBefohandFullInfo = new ContragentAdditionalPaymentBefohandFullInfo();
                    paymentBefohandFullInfo.ActiveStatus = true;
                    paymentBefohandFullInfo.ContragentId = contragentAdditionalPaymentBefohand.ContragentId;
                    paymentBefohandFullInfo.qtySumm = contragentAdditionalPaymentBefohand.summa;
                    paymentBefohandFullInfo.realQty = contragentAdditionalPaymentBefohand.summa;
                    _context.ContragentAdditionalPaymentBefohandFullInfo.Update(paymentBefohandFullInfo);
                    await _context.SaveChangesAsync();
                }
            }

            return CreatedAtAction("GetContragentAdditionalPaymentBefohand", new { id = contragentAdditionalPaymentBefohand.Id }, contragentAdditionalPaymentBefohand);
        }

        // DELETE: api/ContragentAdditionalPaymentBefohands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContragentAdditionalPaymentBefohand>> DeleteContragentAdditionalPaymentBefohand(long id)
        {
            var contragentAdditionalPaymentBefohand = await _context.ContragentAdditionalPaymentBefohand.FindAsync(id);
            if (contragentAdditionalPaymentBefohand == null)
            {
                return NotFound();
            }

            _context.ContragentAdditionalPaymentBefohand.Remove(contragentAdditionalPaymentBefohand);
            await _context.SaveChangesAsync();

            return contragentAdditionalPaymentBefohand;
        }

        private bool ContragentAdditionalPaymentBefohandExists(long id)
        {
            return _context.ContragentAdditionalPaymentBefohand.Any(e => e.Id == id);
        }
    }
}
