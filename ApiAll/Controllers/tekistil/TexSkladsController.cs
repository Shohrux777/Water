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
    public class TexSkladsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexSkladsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexSklads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexSklad>>> GetTexSklad()
        {
            return await _context.TexSklad.Include( p => p.department).OrderByDescending( p => p.id).ToListAsync();
        }

        // GET: api/TexSklads
        [HttpGet("getSkladByDepartmentId")]
        public async Task<ActionResult<IEnumerable<TexSklad>>> getSkladByDepartmentId([FromQuery] long department_id)
        {
            return await _context.TexSklad.Where( p => p.active_status == true && p.department_id == department_id).Include(p => p.department).OrderByDescending(p => p.id).ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexSklad> itemList = await _context.TexSklad.Where(p => p.active_status == true).Include(p => p.department).OrderByDescending(p => p.id).Skip(page * size).Take(size).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexSklad>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexSklad.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TexSklads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexSklad>> GetTexSklad(long id)
        {
            var texSklad = await _context.TexSklad.Include(p =>p.department).Include(p => p.sklad).Where(p => p.id == id).ToListAsync();

            if (texSklad == null)
            {
                return NotFound();
            }

            return texSklad.First();
        }

        // PUT: api/TexSklads/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexSklad(long id, TexSklad texSklad)
        {
            if (id != texSklad.id)
            {
                return BadRequest();
            }

            _context.Entry(texSklad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexSkladExists(id))
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

        // POST: api/TexSklads
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexSklad>> PostTexSklad(TexSklad texSklad)
        {
   

            try
            {
         _context.TexSklad.Update(texSklad);
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

            return CreatedAtAction("GetTexSklad", new { id = texSklad.id }, texSklad);
        }

        // DELETE: api/TexSklads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexSklad>> DeleteTexSklad(long id)
        {
            var texSklad = await _context.TexSklad.FindAsync(id);
            if (texSklad == null)
            {
                return NotFound();
            }

            _context.TexSklad.Remove(texSklad);
            await _context.SaveChangesAsync();

            return texSklad;
        }

        private bool TexSkladExists(long id)
        {
            return _context.TexSklad.Any(e => e.id == id);
        }
    }
}
