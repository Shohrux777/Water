using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil.planning;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tekistil.planning
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexProductAndSubDetailController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexProductAndSubDetailController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexProductAndSubDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexProductAndSubDetail>>> GetTexProductAndSubDetail()
        {
            return await _context.TexProductAndSubDetail.ToListAsync();
        }
        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexProductAndSubDetail> categoryList = await _context.TexProductAndSubDetail.Where(p => p.active_status == true)
                .Include(p => p.texProduct)
                .Include(p => p.texSubProduct)
                
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TexProductAndSubDetail>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TexProductAndSubDetail.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByProductId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByProductId([FromQuery] int page,
            [FromQuery] int size,[FromQuery] long tex_product_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexProductAndSubDetail> categoryList = await _context.TexProductAndSubDetail
                .Where(p => p.active_status == true && p.TexProductid == tex_product_id)
                .Include(p => p.texProduct)
                .Include(p => p.texSubProduct)
                
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TexProductAndSubDetail>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TexProductAndSubDetail
                .Where(p => p.active_status == true && p.TexProductid == tex_product_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TexProductAndSubDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexProductAndSubDetail>> GetTexProductAndSubDetail(long id)
        {
            var texProductAndSubDetail = await _context.TexProductAndSubDetail
                .Include(p => p.texProduct)
                .Include(p => p.texSubProduct)
                
                .Where(p =>p.id == id).ToListAsync();

            if (texProductAndSubDetail == null || texProductAndSubDetail.Count == 0)
            {
                return NotFound();
            }


            return texProductAndSubDetail.First();
        }

        // PUT: api/TexProductAndSubDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexProductAndSubDetail(long id, TexProductAndSubDetail texProductAndSubDetail)
        {
            if (id != texProductAndSubDetail.id)
            {
                return BadRequest();
            }

            _context.Entry(texProductAndSubDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexProductAndSubDetailExists(id))
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

        // POST: api/TexProductAndSubDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexProductAndSubDetail>> PostTexProductAndSubDetail(TexProductAndSubDetail texProductAndSubDetail)
        {
            _context.TexProductAndSubDetail.Update(texProductAndSubDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexProductAndSubDetail", new { id = texProductAndSubDetail.id }, texProductAndSubDetail);
        }

        // DELETE: api/TexProductAndSubDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexProductAndSubDetail>> DeleteTexProductAndSubDetail(long id)
        {
            var texProductAndSubDetail = await _context.TexProductAndSubDetail.FindAsync(id);
            if (texProductAndSubDetail == null)
            {
                return NotFound();
            }

            _context.TexProductAndSubDetail.Remove(texProductAndSubDetail);
            await _context.SaveChangesAsync();

            return texProductAndSubDetail;
        }

        private bool TexProductAndSubDetailExists(long id)
        {
            return _context.TexProductAndSubDetail.Any(e => e.id == id);
        }
    }
}
