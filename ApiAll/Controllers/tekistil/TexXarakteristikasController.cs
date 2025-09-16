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

namespace ApiAll.Controllers.tekistil
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexXarakteristikasController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexXarakteristikasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexXarakteristikas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexXarakteristika>>> GetTexXarakteristika()
        {
            return await _context.TexXarakteristika.ToListAsync();
        }

        // GET: api/TexXarakteristikas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexXarakteristika>> GetTexXarakteristika(long id)
        {
            var texXarakteristika = await _context.TexXarakteristika.FindAsync(id);

            if (texXarakteristika == null)
            {
                return NotFound();
            }

            return texXarakteristika;
        }

        // PUT: api/TexXarakteristikas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexXarakteristika(long id, TexXarakteristika texXarakteristika)
        {
            if (id != texXarakteristika.id)
            {
                return BadRequest();
            }

            _context.Entry(texXarakteristika).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexXarakteristikaExists(id))
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

        [HttpGet("getPaginationTovarFarqi")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationTovarFarqi([FromQuery] int page,
    [FromQuery] int size, [FromQuery] long tovar_farqi)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexXarakteristika> itemList = await _context.TexXarakteristika.Where(p => p.active_status == true && p.tovarlar_farqi == tovar_farqi)
                .OrderByDescending(p => p.id).Skip(size * page).Take(size).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexXarakteristika>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexXarakteristika.Where(p => p.active_status == true && p.tovarlar_farqi == tovar_farqi).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // POST: api/TexXarakteristikas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexXarakteristika>> PostTexXarakteristika(TexXarakteristika texXarakteristika)
        {
        


            try
            {
    _context.TexXarakteristika.Update(texXarakteristika);
            await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                return NotFound(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFound(e?.InnerException?.Message);
            }

            return CreatedAtAction("GetTexXarakteristika", new { id = texXarakteristika.id }, texXarakteristika);
        }

        // DELETE: api/TexXarakteristikas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexXarakteristika>> DeleteTexXarakteristika(long id)
        {
            var texXarakteristika = await _context.TexXarakteristika.FindAsync(id);
            if (texXarakteristika == null)
            {
                return NotFound();
            }

            try { 
                    _context.TexXarakteristika.Remove(texXarakteristika);
                    await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                return NotFound(e?.InnerException?.Message);

            }
            catch (Exception e)
            {
                return NotFound(e?.InnerException?.Message);
            }

            return texXarakteristika;
        }

        private bool TexXarakteristikaExists(long id)
        {
            return _context.TexXarakteristika.Any(e => e.id == id);
        }
    }
}
