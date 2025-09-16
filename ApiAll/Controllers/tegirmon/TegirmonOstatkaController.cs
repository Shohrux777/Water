using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tegirmon;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tegirmon
{
    [ApiExplorerSettings(GroupName = "v7")]
    [Route("api/[controller]")]
    [ApiController]
    public class TegirmonOstatkaController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonOstatkaController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonOstatka
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonOstatka>>> GetTegirmonOstatka()
        {
            return await _context.TegirmonOstatka.ToListAsync();
        }

        // GET: api/TegirmonOstatka/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonOstatka>> GetTegirmonOstatka(long id)
        {
            var tegirmonOstatka = await _context.TegirmonOstatka.FindAsync(id);

            if (tegirmonOstatka == null)
            {
                return NotFound();
            }

            return tegirmonOstatka;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonOstatka> categoryList = await _context.TegirmonOstatka
                .Include(p => p.product)
                .ThenInclude(p =>p.unitMeasurment)
                .Where(p => p.active_status == true && p.real_qty != 0)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonOstatka>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonOstatka.Where(p => p.active_status == true && p.real_qty != 0).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }



        [HttpGet("getPaginationSearchProductByNameOrCodeOrShtrixCode")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationSearchProductByNameOrCodeOrShtrixCode([FromQuery] int page, [FromQuery] int size,[FromQuery] String name_o_code_or_shtrix)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonOstatka> categoryList = new List<TegirmonOstatka>();
            if (name_o_code_or_shtrix.Trim().Length > 0) {
                categoryList = await _context.TegirmonOstatka
               .Include(p => p.product)
               .Where(p => p.active_status == true && p.real_qty > 0
               && (p.product.name.ToLower().Contains(name_o_code_or_shtrix.ToLower())
               || p.product.code.ToLower().Contains(name_o_code_or_shtrix.ToLower())
               || p.product.shitrix_code.ToLower().Contains(name_o_code_or_shtrix.ToLower())))
               .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            }
            else {
                categoryList = await _context.TegirmonOstatka
                .Include(p => p.product)
                .Where(p => p.active_status == true && p.real_qty > 0)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            }


            if (categoryList == null)
            {
                categoryList = new List<TegirmonOstatka>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = categoryList.Count();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/TegirmonOstatka/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonOstatka(long id, TegirmonOstatka tegirmonOstatka)
        {
            if (id != tegirmonOstatka.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonOstatka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonOstatkaExists(id))
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

        // POST: api/TegirmonOstatka
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonOstatka>> PostTegirmonOstatka(TegirmonOstatka tegirmonOstatka)
        {
            _context.TegirmonOstatka.Update(tegirmonOstatka);
            await _context.SaveChangesAsync();

            return tegirmonOstatka;
        }

        // DELETE: api/TegirmonOstatka/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonOstatka>> DeleteTegirmonOstatka(long id)
        {
            var tegirmonOstatka = await _context.TegirmonOstatka.FindAsync(id);
            if (tegirmonOstatka == null)
            {
                return NotFound();
            }

            _context.TegirmonOstatka.Remove(tegirmonOstatka);
            await _context.SaveChangesAsync();

            return tegirmonOstatka;
        }

        private bool TegirmonOstatkaExists(long id)
        {
            return _context.TegirmonOstatka.Any(e => e.id == id);
        }
    }
}
