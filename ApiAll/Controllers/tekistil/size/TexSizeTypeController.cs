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

namespace ApiAll.Controllers.tekistil.size
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexSizeTypeController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexSizeTypeController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexSizeType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexSizeType>>> GetTexSizeType()
        {
            return await _context.TexSizeType.ToListAsync();
        }

        [HttpGet("getSizeListBySizeTypeId")]
        public async Task<ActionResult<IEnumerable<TexSize>>> getSizeListBySizeTypeId([FromQuery] long size_tye_id)
        {
            return await _context.TexSize.Where(p => p.TexSizeTypeid == size_tye_id).ToListAsync();
        }

        // GET: api/TexSizeType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexSizeType>> GetTexSizeType(long id)
        {
            var texSizeType = await _context.TexSizeType
                .Include(p => p.size_iem_list)
                .Where(p => p.id==id).ToListAsync();

            if (texSizeType == null || texSizeType.Count == 0)
            {
                return NotFound();
            }

            return texSizeType.First();
        }


        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexSizeType> categoryList = await _context.TexSizeType.Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TexSizeType>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TexSizeType.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/TexSizeType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexSizeType(long id, TexSizeType texSizeType)
        {
            if (id != texSizeType.id)
            {
                return BadRequest();
            }

            _context.Entry(texSizeType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexSizeTypeExists(id))
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

        // POST: api/TexSizeType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexSizeType>> PostTexSizeType(TexSizeType texSizeType)
        {
            _context.TexSizeType.Update(texSizeType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexSizeType", new { id = texSizeType.id }, texSizeType);
        }

        // DELETE: api/TexSizeType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexSizeType>> DeleteTexSizeType(long id)
        {
            var texSizeType = await _context.TexSizeType.FindAsync(id);
            if (texSizeType == null)
            {
                return NotFound();
            }

            _context.TexSizeType.Remove(texSizeType);
            await _context.SaveChangesAsync();

            return texSizeType;
        }

        private bool TexSizeTypeExists(long id)
        {
            return _context.TexSizeType.Any(e => e.id == id);
        }
    }
}
