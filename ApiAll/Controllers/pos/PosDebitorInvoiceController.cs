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
    public class PosDebitorInvoiceController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosDebitorInvoiceController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosDebitorInvoice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosDebitorInvoice>>> GetPosDebitorInvoice()
        {
            return await _context.PosDebitorInvoice.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosDebitorInvoice> itemList = await _context.PosDebitorInvoice
                .Include(p =>p.department)
                .Include(p =>p.sklad)
                .Include(p =>p.postavshik)
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosDebitorInvoice>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosDebitorInvoice.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/PosDebitorInvoice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosDebitorInvoice>> GetPosDebitorInvoice(long id)
        {
            var posDebitorInvoice = await _context.PosDebitorInvoice.FindAsync(id);

            if (posDebitorInvoice == null)
            {
                return NotFound();
            }

            return posDebitorInvoice;
        }
        [HttpGet("applyOrDisableDebitorPosDebitorInvoice")]
        public async Task<ActionResult<PosDebitorInvoice>> applyOrDisableDebitorPosDebitorInvoice([FromQuery]long pos_debitor_inv_id,[FromQuery] bool apply_status,[FromQuery] long pos_auth_id)
        {
            var posDebitorInvoice = await _context.PosDebitorInvoice
                .Include(p =>p.itms).ThenInclude(p => p.item)
                .Where(p => p.id==pos_debitor_inv_id).ToListAsync();

            if (posDebitorInvoice == null || posDebitorInvoice.Count == 0)
            {
                return NotFound();
            }

            if (posDebitorInvoice.First().applyment_status == apply_status) {
                return NotFound("Пожалуйста, обновите страницу");
            }

            if (apply_status)
            {
                //rasxod qilish kerak tovarlardi
                if (posDebitorInvoice.First().itms == null || posDebitorInvoice.First().itms.Count == 0) {
                    return NotFound("Ни один элемент не найден");
                }

                //check resultatov ozi bormi yoqmi digan narsa skladdagi
                foreach (PosDebitorInvoiceItem item in posDebitorInvoice.First().itms) {
                    PosInvoiceItem invoiceItem = await _context.PosInvoiceItem.FindAsync(item.id);
                    if (item.qty > invoiceItem.real_qty) {
                        return NotFound("Недостаточно товаров на складе");
                    }
                }

                //rasxod qilish yani sklatdan ayrish kerak

            }
            else {
                //qayta prixod qilish kerak tovarlardi



            }


            return posDebitorInvoice.First();
        }

        // PUT: api/PosDebitorInvoice/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosDebitorInvoice(long id, PosDebitorInvoice posDebitorInvoice)
        {
            if (id != posDebitorInvoice.id)
            {
                return BadRequest();
            }

            _context.Entry(posDebitorInvoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosDebitorInvoiceExists(id))
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

        // POST: api/PosDebitorInvoice
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosDebitorInvoice>> PostPosDebitorInvoice(PosDebitorInvoice posDebitorInvoice)
        {
            _context.PosDebitorInvoice.Update(posDebitorInvoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosDebitorInvoice", new { id = posDebitorInvoice.id }, posDebitorInvoice);
        }

        // DELETE: api/PosDebitorInvoice/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosDebitorInvoice>> DeletePosDebitorInvoice(long id)
        {
            var posDebitorInvoice = await _context.PosDebitorInvoice.FindAsync(id);
            if (posDebitorInvoice == null)
            {
                return NotFound();
            }

            _context.PosDebitorInvoice.Remove(posDebitorInvoice);
            await _context.SaveChangesAsync();

            return posDebitorInvoice;
        }

        private bool PosDebitorInvoiceExists(long id)
        {
            return _context.PosDebitorInvoice.Any(e => e.id == id);
        }
    }
}
