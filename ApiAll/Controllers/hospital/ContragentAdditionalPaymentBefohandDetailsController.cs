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
    public class ContragentAdditionalPaymentBefohandDetailsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ContragentAdditionalPaymentBefohandDetailsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ContragentAdditionalPaymentBefohandDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContragentAdditionalPaymentBefohandDetail>>> GetContragentAdditionalPaymentBefohandDetail()
        {
            return await _context.ContragentAdditionalPaymentBefohandDetail.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<ContragentAdditionalPaymentBefohandDetail> itemList = await _context.ContragentAdditionalPaymentBefohandDetail
                .Include(p => p.contragent)
                .Include(p => p.serviceType)
                .Include(p => p.patients)
                .OrderByDescending(p => p.Id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<ContragentAdditionalPaymentBefohandDetail>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.ContragentAdditionalPaymentBefohandDetail.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/ContragentAdditionalPaymentBefohandDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContragentAdditionalPaymentBefohandDetail>> GetContragentAdditionalPaymentBefohandDetail(long id)
        {
            var contragentAdditionalPaymentBefohandDetail = await _context.ContragentAdditionalPaymentBefohandDetail.FindAsync(id);

            if (contragentAdditionalPaymentBefohandDetail == null)
            {
                return NotFound();
            }

            return contragentAdditionalPaymentBefohandDetail;
        }

        // PUT: api/ContragentAdditionalPaymentBefohandDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContragentAdditionalPaymentBefohandDetail(long id, ContragentAdditionalPaymentBefohandDetail contragentAdditionalPaymentBefohandDetail)
        {
            if (id != contragentAdditionalPaymentBefohandDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(contragentAdditionalPaymentBefohandDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContragentAdditionalPaymentBefohandDetailExists(id))
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

        // POST: api/ContragentAdditionalPaymentBefohandDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ContragentAdditionalPaymentBefohandDetail>> PostContragentAdditionalPaymentBefohandDetail(ContragentAdditionalPaymentBefohandDetail contragentAdditionalPaymentBefohandDetail)
        {
            _context.ContragentAdditionalPaymentBefohandDetail.Update(contragentAdditionalPaymentBefohandDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContragentAdditionalPaymentBefohandDetail", new { id = contragentAdditionalPaymentBefohandDetail.Id }, contragentAdditionalPaymentBefohandDetail);
        }

        // DELETE: api/ContragentAdditionalPaymentBefohandDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContragentAdditionalPaymentBefohandDetail>> DeleteContragentAdditionalPaymentBefohandDetail(long id)
        {
            var contragentAdditionalPaymentBefohandDetail = await _context.ContragentAdditionalPaymentBefohandDetail.FindAsync(id);
            if (contragentAdditionalPaymentBefohandDetail == null)
            {
                return NotFound();
            }

            _context.ContragentAdditionalPaymentBefohandDetail.Remove(contragentAdditionalPaymentBefohandDetail);
            await _context.SaveChangesAsync();

            return contragentAdditionalPaymentBefohandDetail;
        }

        private bool ContragentAdditionalPaymentBefohandDetailExists(long id)
        {
            return _context.ContragentAdditionalPaymentBefohandDetail.Any(e => e.Id == id);
        }
    }
}
