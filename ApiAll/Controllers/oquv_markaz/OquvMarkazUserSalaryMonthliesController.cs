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
    public class OquvMarkazUserSalaryMonthliesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OquvMarkazUserSalaryMonthliesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OquvMarkazUserSalaryMonthlies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OquvMarkazUserSalaryMonthly>>> GetOquvMarkazUserSalaryMonthly()
        {
            return await _context.OquvMarkazUserSalaryMonthly.ToListAsync();
        }

        [HttpGet("getPaginationForPayedSlaryDetailInfo")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazUserSalaryMonthly> categoryList = await _context.OquvMarkazUserSalaryMonthly
                .Include(p => p.user)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazUserSalaryMonthly>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazUserSalaryMonthly.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationForPayedSlaryDetailInfoByUserId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationForPayedSlaryDetailInfoByUserId([FromQuery] int page, [FromQuery] int size,[FromQuery] long user_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<OquvMarkazUserSalaryMonthly> categoryList = await _context.OquvMarkazUserSalaryMonthly
                .Include(p => p.user)
                .Where(p => p.active_status == true && p.OquvMarkazUserid == user_id)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<OquvMarkazUserSalaryMonthly>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.OquvMarkazUserSalaryMonthly
                .Where(p => p.active_status == true && p.OquvMarkazUserid == user_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/OquvMarkazUserSalaryMonthlies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OquvMarkazUserSalaryMonthly>> GetOquvMarkazUserSalaryMonthly(long id)
        {
            var oquvMarkazUserSalaryMonthly = await _context.OquvMarkazUserSalaryMonthly.FindAsync(id);

            if (oquvMarkazUserSalaryMonthly == null)
            {
                return NotFound();
            }

            return oquvMarkazUserSalaryMonthly;
        }

        // PUT: api/OquvMarkazUserSalaryMonthlies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOquvMarkazUserSalaryMonthly(long id, OquvMarkazUserSalaryMonthly oquvMarkazUserSalaryMonthly)
        {
            if (id != oquvMarkazUserSalaryMonthly.id)
            {
                return BadRequest();
            }

            _context.Entry(oquvMarkazUserSalaryMonthly).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OquvMarkazUserSalaryMonthlyExists(id))
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

        // POST: api/OquvMarkazUserSalaryMonthlies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OquvMarkazUserSalaryMonthly>> PostOquvMarkazUserSalaryMonthly(OquvMarkazUserSalaryMonthly oquvMarkazUserSalaryMonthly)
        {
            _context.OquvMarkazUserSalaryMonthly.Add(oquvMarkazUserSalaryMonthly);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOquvMarkazUserSalaryMonthly", new { id = oquvMarkazUserSalaryMonthly.id }, oquvMarkazUserSalaryMonthly);
        }

        // DELETE: api/OquvMarkazUserSalaryMonthlies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OquvMarkazUserSalaryMonthly>> DeleteOquvMarkazUserSalaryMonthly(long id)
        {
            var oquvMarkazUserSalaryMonthly = await _context.OquvMarkazUserSalaryMonthly.FindAsync(id);
            if (oquvMarkazUserSalaryMonthly == null)
            {
                return NotFound();
            }

            _context.OquvMarkazUserSalaryMonthly.Remove(oquvMarkazUserSalaryMonthly);
            await _context.SaveChangesAsync();

            return oquvMarkazUserSalaryMonthly;
        }

        private bool OquvMarkazUserSalaryMonthlyExists(long id)
        {
            return _context.OquvMarkazUserSalaryMonthly.Any(e => e.id == id);
        }
    }
}
