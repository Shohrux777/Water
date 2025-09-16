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
    public class ContragentAdditionalPaymentBefohandFullInfoesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ContragentAdditionalPaymentBefohandFullInfoesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ContragentAdditionalPaymentBefohandFullInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContragentAdditionalPaymentBefohandFullInfo>>> GetContragentAdditionalPaymentBefohandFullInfo()
        {
            return await _context.ContragentAdditionalPaymentBefohandFullInfo.Include( p => p.contragent).OrderByDescending( p => p.Id).ToListAsync();
        }

        // GET: api/ContragentAdditionalPaymentBefohandFullInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContragentAdditionalPaymentBefohandFullInfo>> GetContragentAdditionalPaymentBefohandFullInfo(long id)
        {
            var contragentAdditionalPaymentBefohandFullInfo = await _context.ContragentAdditionalPaymentBefohandFullInfo.FindAsync(id);

            if (contragentAdditionalPaymentBefohandFullInfo == null)
            {
                return NotFound();
            }

            return contragentAdditionalPaymentBefohandFullInfo;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<ContragentAdditionalPaymentBefohandFullInfo> itemList = await _context.ContragentAdditionalPaymentBefohandFullInfo
                .Include(p => p.contragent)
                .OrderByDescending(p => p.Id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<ContragentAdditionalPaymentBefohandFullInfo>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.ContragentAdditionalPaymentBefohandFullInfo.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/ContragentAdditionalPaymentBefohandFullInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContragentAdditionalPaymentBefohandFullInfo(long id, ContragentAdditionalPaymentBefohandFullInfo contragentAdditionalPaymentBefohandFullInfo)
        {
            if (id != contragentAdditionalPaymentBefohandFullInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(contragentAdditionalPaymentBefohandFullInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContragentAdditionalPaymentBefohandFullInfoExists(id))
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

        // POST: api/ContragentAdditionalPaymentBefohandFullInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ContragentAdditionalPaymentBefohandFullInfo>> PostContragentAdditionalPaymentBefohandFullInfo(ContragentAdditionalPaymentBefohandFullInfo contragentAdditionalPaymentBefohandFullInfo)
        {
            _context.ContragentAdditionalPaymentBefohandFullInfo.Update(contragentAdditionalPaymentBefohandFullInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContragentAdditionalPaymentBefohandFullInfo", new { id = contragentAdditionalPaymentBefohandFullInfo.Id }, contragentAdditionalPaymentBefohandFullInfo);
        }

        // DELETE: api/ContragentAdditionalPaymentBefohandFullInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContragentAdditionalPaymentBefohandFullInfo>> DeleteContragentAdditionalPaymentBefohandFullInfo(long id)
        {
            var contragentAdditionalPaymentBefohandFullInfo = await _context.ContragentAdditionalPaymentBefohandFullInfo.FindAsync(id);
            if (contragentAdditionalPaymentBefohandFullInfo == null)
            {
                return NotFound();
            }

            _context.ContragentAdditionalPaymentBefohandFullInfo.Remove(contragentAdditionalPaymentBefohandFullInfo);
            await _context.SaveChangesAsync();

            return contragentAdditionalPaymentBefohandFullInfo;
        }

        private bool ContragentAdditionalPaymentBefohandFullInfoExists(long id)
        {
            return _context.ContragentAdditionalPaymentBefohandFullInfo.Any(e => e.Id == id);
        }
    }
}
