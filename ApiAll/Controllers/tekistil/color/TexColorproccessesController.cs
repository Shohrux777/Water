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
    public class TexColorproccessesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexColorproccessesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexColorproccesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexColorproccess>>> GetTexColorproccess()
        {
            return await _context.TexColorproccess.Where( p => p.active_status == true).OrderByDescending( p => p.id).ToListAsync();
        }


        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexColorproccess> itemList = await _context.TexColorproccess.OrderByDescending(p => p.id).Where(p => p.active_status == true).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexColorproccess>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexColorproccess.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TexColorproccesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexColorproccess>> GetTexColorproccess(long id)
        {
            var texColorproccess = await _context.TexColorproccess.FindAsync(id);

            if (texColorproccess == null)
            {
                return NotFound();
            }

            return texColorproccess;
        }

        // PUT: api/TexColorproccesses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexColorproccess(long id, TexColorproccess texColorproccess)
        {
            if (id != texColorproccess.id)
            {
                return BadRequest();
            }

            _context.Entry(texColorproccess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexColorproccessExists(id))
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

        // POST: api/TexColorproccesses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexColorproccess>> PostTexColorproccess(TexColorproccess texColorproccess)
        {
    

            try
            {
                _context.TexColorproccess.Update(texColorproccess);
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

            return CreatedAtAction("GetTexColorproccess", new { id = texColorproccess.id }, texColorproccess);
        }

        // DELETE: api/TexColorproccesses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexColorproccess>> DeleteTexColorproccess(long id)
        {
            var texColorproccess = await _context.TexColorproccess.FindAsync(id);
            if (texColorproccess == null)
            {
                return NotFound();
            }
            texColorproccess.active_status = false;
            _context.TexColorproccess.Update(texColorproccess);
            await _context.SaveChangesAsync();

            return texColorproccess;
        }

        private bool TexColorproccessExists(long id)
        {
            return _context.TexColorproccess.Any(e => e.id == id);
        }
    }
}
