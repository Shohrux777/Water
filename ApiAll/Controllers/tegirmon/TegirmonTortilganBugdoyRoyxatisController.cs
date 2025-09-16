using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tegirmon
{
    [ApiExplorerSettings(GroupName = "v7")]
    [Route("api/[controller]")]
    [ApiController]
    public class TegirmonTortilganBugdoyRoyxatisController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonTortilganBugdoyRoyxatisController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonTortilganBugdoyRoyxatis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonTortilganBugdoyRoyxati>>> GetTegirmonTortilganBugdoyRoyxati()
        {
            return await _context.TegirmonTortilganBugdoyRoyxati.ToListAsync();
        }



        [HttpGet("getPaginationNotAcceptedBugdoyList")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationNotAcceptedBugdoyList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonTortilganBugdoyRoyxati> categoryList = await _context.TegirmonTortilganBugdoyRoyxati
                .Include(p => p.client)
                .Include(p => p.product)
                .Where(p => p.active_status == true && p.accepted_get_value == false)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonTortilganBugdoyRoyxati>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonTortilganBugdoyRoyxati
            .Where(p => p.active_status == true && p.accepted_get_value == false).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationAllList")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationAllList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonTortilganBugdoyRoyxati> categoryList = await _context.TegirmonTortilganBugdoyRoyxati
                .Include(p => p.client)
                .Include(p => p.product)
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonTortilganBugdoyRoyxati>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonTortilganBugdoyRoyxati
            .Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationAllListByBeatweenDates")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationAllListByBeatweenDates([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime b_date, [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonTortilganBugdoyRoyxati> categoryList = await _context.TegirmonTortilganBugdoyRoyxati
                .Include(p => p.client)
                .Include(p => p.product)
                .Where(p => p.active_status == true
                 && (p.created_date_time >= b_date && p.created_date_time <= e_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonTortilganBugdoyRoyxati>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonTortilganBugdoyRoyxati
            .Where(p => p.active_status == true
                 && (p.created_date_time >= b_date && p.created_date_time <= e_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationAllListByBeatweenDatesAndClientId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationAllListByBeatweenDatesAndClientId([FromQuery] int page, [FromQuery] int size, 
            [FromQuery] DateTime b_date, [FromQuery] DateTime e_date,[FromQuery] long client_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonTortilganBugdoyRoyxati> categoryList = await _context.TegirmonTortilganBugdoyRoyxati
                .Include(p => p.client)
                .Include(p => p.product)
                .Where(p => p.active_status == true
                 && p.TegirmonClientid == client_id
                 && (p.created_date_time >= b_date && p.created_date_time <= e_date))
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonTortilganBugdoyRoyxati>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonTortilganBugdoyRoyxati
            .Where(p => p.active_status == true
                 && p.TegirmonClientid == client_id
                 && (p.created_date_time >= b_date && p.created_date_time <= e_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("acceptTortilganBugdoylar")]
        public async Task<ActionResult<TegirmonTortilganBugdoyRoyxati>> acceptTortilganBugdoylar([FromQuery]long id,[FromQuery] long auth_id)
        {
            var tegirmonTortilganBugdoyRoyxati = await _context.TegirmonTortilganBugdoyRoyxati.FindAsync(id);

            if (tegirmonTortilganBugdoyRoyxati == null)
            {
                return NotFound();
            }

            tegirmonTortilganBugdoyRoyxati.accepted_get_value = true;
            tegirmonTortilganBugdoyRoyxati.TegirmonAuthid = auth_id;

            _context.TegirmonTortilganBugdoyRoyxati.Update(tegirmonTortilganBugdoyRoyxati);
            await _context.SaveChangesAsync();

            return tegirmonTortilganBugdoyRoyxati;
        }

        // GET: api/TegirmonTortilganBugdoyRoyxatis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonTortilganBugdoyRoyxati>> GetTegirmonTortilganBugdoyRoyxati(long id)
        {
            var tegirmonTortilganBugdoyRoyxati = await _context.TegirmonTortilganBugdoyRoyxati.FindAsync(id);

            if (tegirmonTortilganBugdoyRoyxati == null)
            {
                return NotFound();
            }

            return tegirmonTortilganBugdoyRoyxati;
        }

        // PUT: api/TegirmonTortilganBugdoyRoyxatis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonTortilganBugdoyRoyxati(long id, TegirmonTortilganBugdoyRoyxati tegirmonTortilganBugdoyRoyxati)
        {
            if (id != tegirmonTortilganBugdoyRoyxati.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonTortilganBugdoyRoyxati).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonTortilganBugdoyRoyxatiExists(id))
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

        // POST: api/TegirmonTortilganBugdoyRoyxatis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonTortilganBugdoyRoyxati>> PostTegirmonTortilganBugdoyRoyxati(TegirmonTortilganBugdoyRoyxati tegirmonTortilganBugdoyRoyxati)
        {
            _context.TegirmonTortilganBugdoyRoyxati.Update(tegirmonTortilganBugdoyRoyxati);
            await _context.SaveChangesAsync();

            return tegirmonTortilganBugdoyRoyxati;
        }

        // DELETE: api/TegirmonTortilganBugdoyRoyxatis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonTortilganBugdoyRoyxati>> DeleteTegirmonTortilganBugdoyRoyxati(long id)
        {
            var tegirmonTortilganBugdoyRoyxati = await _context.TegirmonTortilganBugdoyRoyxati.FindAsync(id);
            if (tegirmonTortilganBugdoyRoyxati == null)
            {
                return NotFound();
            }

            _context.TegirmonTortilganBugdoyRoyxati.Remove(tegirmonTortilganBugdoyRoyxati);
            await _context.SaveChangesAsync();

            return tegirmonTortilganBugdoyRoyxati;
        }

        private bool TegirmonTortilganBugdoyRoyxatiExists(long id)
        {
            return _context.TegirmonTortilganBugdoyRoyxati.Any(e => e.id == id);
        }
    }
}
