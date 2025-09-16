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
    public class TexProductAndRecipeController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexProductAndRecipeController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexProductAndRecipe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexProductAndRecipe>>> GetTexProductAndRecipe()
        {
            return await _context.TexProductAndRecipe.ToListAsync();
        }

        // GET: api/TexProductAndRecipe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexProductAndRecipe>> GetTexProductAndRecipe(long id)
        {
            var texProductAndRecipe = await _context.TexProductAndRecipe.FindAsync(id);

            if (texProductAndRecipe == null)
            {
                return NotFound();
            }

            return texProductAndRecipe;
        }

        [HttpGet("getPaginationByProductIdBoyicha")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByProductIdBoyicha([FromQuery] int page,
          [FromQuery] int size, [FromQuery] long product_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexProductAndRecipe> itemList = await _context.TexProductAndRecipe
                .Where(p => p.active_status == true && p.TexProductid == product_id)
                .Include(p => p.size)
                .Include(p => p.color)
                .Include(p => p.unitmeasurment)
                .OrderByDescending(p => p.id).Skip(size * page).Take(size).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexProductAndRecipe>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexProductAndRecipe.Where(p => p.active_status == true
            && p.TexProductid == product_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByOrderItemIdBoyicha")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByOrderItemIdBoyicha([FromQuery] int page,
      [FromQuery] int size, [FromQuery] long order_item_id)
        {
            TexOrderItem orderItem = await _context.TexOrderItem.FindAsync(order_item_id);
            long product_id = (long)orderItem.product_id;
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexProductAndRecipe> itemList = await _context.TexProductAndRecipe
                .Where(p => p.active_status == true && p.TexProductid == product_id)
                .Include(p => p.size)
                .Include(p => p.color)
                .Include(p => p.unitmeasurment)
                .OrderByDescending(p => p.id).Skip(size * page).Take(size).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexProductAndRecipe>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexProductAndRecipe.Where(p => p.active_status == true
            && p.TexProductid == product_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // PUT: api/TexProductAndRecipe/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexProductAndRecipe(long id, TexProductAndRecipe texProductAndRecipe)
        {
            if (id != texProductAndRecipe.id)
            {
                return BadRequest();
            }

            _context.Entry(texProductAndRecipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexProductAndRecipeExists(id))
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

        // POST: api/TexProductAndRecipe
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexProductAndRecipe>> PostTexProductAndRecipe(TexProductAndRecipe texProductAndRecipe)
        {
            _context.TexProductAndRecipe.Update(texProductAndRecipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexProductAndRecipe", new { id = texProductAndRecipe.id }, texProductAndRecipe);
        }

        [HttpPost("TexProductAndRecipeListiniUpdateQilish")]
        public async Task<ActionResult<IEnumerable<TexProductAndRecipe>>> TexProductAndRecipeListiniUpdateQilish(List<TexProductAndRecipe> texProductAndRecipeList)
        {
            _context.TexProductAndRecipe.UpdateRange(texProductAndRecipeList);
            await _context.SaveChangesAsync();

            return texProductAndRecipeList;
        }

        // DELETE: api/TexProductAndRecipe/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexProductAndRecipe>> DeleteTexProductAndRecipe(long id)
        {
            var texProductAndRecipe = await _context.TexProductAndRecipe.FindAsync(id);
            if (texProductAndRecipe == null)
            {
                return NotFound();
            }

            _context.TexProductAndRecipe.Remove(texProductAndRecipe);
            await _context.SaveChangesAsync();

            return texProductAndRecipe;
        }

        private bool TexProductAndRecipeExists(long id)
        {
            return _context.TexProductAndRecipe.Any(e => e.id == id);
        }
    }
}
