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
    public class OquvMarkazOstatkaController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazOstatkaController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazOstatka
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazOstatka>>> GetOquvMarkazOstatka()
        {
            return await _context.OquvMarkazOstatka.ToListAsync();
        }

        // GET: api/OquvMarkazOstatka/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazOstatka>> GetOquvMarkazOstatka(long id)
        {
            var oquvMarkazOstatka = await _context.OquvMarkazOstatka.FindAsync(id);

            if (oquvMarkazOstatka == null)
            {
                return NotFound();
            }

            return oquvMarkazOstatka;
        }

        [HttpGet("getRasxodProductsForUser")]
        public async Task<ActionResult<OquvMarkazOstatka>> getRasxodProductsForUser([FromQuery]long ostatka_id,[FromQuery] long user_id, [FromQuery] double qty)
        {
            var oquvMarkazOstatka = await _context.OquvMarkazOstatka.FindAsync(ostatka_id);

            if (oquvMarkazOstatka == null)
            {
                return NotFound();
            }

            OquvMarkazOstatkaRasxodInfo rasxodInfo = new OquvMarkazOstatkaRasxodInfo();
            rasxodInfo.active_status = true;
            rasxodInfo.OquvMarkazProductid = oquvMarkazOstatka.OquvMarkazProductid;
            rasxodInfo.OquvMarkazUserid = user_id;
            rasxodInfo.qty = qty;


            _context.OquvMarkazOstatkaRasxodInfo.Update(rasxodInfo);
            await _context.SaveChangesAsync();


            oquvMarkazOstatka.real_qty = oquvMarkazOstatka.real_qty - qty;
            _context.OquvMarkazOstatka.Update(oquvMarkazOstatka);
            await _context.SaveChangesAsync();

            return oquvMarkazOstatka;
        }

        [HttpGet("getPaginationRasxodList")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationRasxodList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazOstatkaRasxodInfo> categoryList = await _context.OquvMarkazOstatkaRasxodInfo.Where(p => p.active_status == true)
                .Include(p => p.product)
                .Include(p =>p.user)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazOstatkaRasxodInfo>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazOstatkaRasxodInfo.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazOstatka> categoryList = await _context.OquvMarkazOstatka.Where(p => p.active_status == true)
                .Include(p => p.product)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazOstatka>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazOstatka.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/OquvMarkazOstatka/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazOstatka(long id, OquvMarkazOstatka oquvMarkazOstatka)
        {
            if (id != oquvMarkazOstatka.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazOstatka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazOstatkaExists(id))
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

        // POST: api/OquvMarkazOstatka
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazOstatka>> PostOquvMarkazOstatka(OquvMarkazOstatka oquvMarkazOstatka)
        {
            _context.OquvMarkazOstatka.Update(oquvMarkazOstatka);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazOstatka", new { id = oquvMarkazOstatka.id }, oquvMarkazOstatka);
        }

        // DELETE: api/OquvMarkazOstatka/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazOstatka>> DeleteOquvMarkazOstatka(long id)
        {
            var oquvMarkazOstatka = await _context.OquvMarkazOstatka.FindAsync(id);
            if (oquvMarkazOstatka == null)
            {
                return NotFound();
            }

            _context.OquvMarkazOstatka.Remove(oquvMarkazOstatka);
            await _context.SaveChangesAsync();

            return oquvMarkazOstatka;
        }

        private bool OquvMarkazOstatkaExists(long id)
        {
            return _context.OquvMarkazOstatka.Any(e => e.id == id);
        }
    }
}
