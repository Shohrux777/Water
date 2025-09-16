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
    public class TexColorVariantRecipesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexColorVariantRecipesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexColorVariantRecipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexColorVariantRecipe>>> GetTexColorVariantRecipe()
        {
            return await _context.TexColorVariantRecipe.Where( p=>p.active_status == true).OrderByDescending( p => p.id).Include( p =>p.product).Include( p=>p.unitmeasurment).Include( p =>p.colorvariant).Include( p => p.colorproccess).ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexColorVariantRecipe> itemList = await _context.TexColorVariantRecipe.Where(p => p.active_status == true).OrderByDescending(p => p.id).Include(p => p.product).Include(p => p.unitmeasurment).Include(p => p.colorvariant).Include(p => p.colorproccess).ToListAsync();
            if (itemList == null)
            {
                itemList = new List<TexColorVariantRecipe>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.TexColorVariantRecipe.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TexColorVariantRecipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexColorVariantRecipe>> GetTexColorVariantRecipe(long id)
        {
            var texColorVariantRecipe = await _context.TexColorVariantRecipe.FindAsync(id);

            if (texColorVariantRecipe == null)
            {
                return NotFound();
            }

            return texColorVariantRecipe;
        }

        // PUT: api/TexColorVariantRecipes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexColorVariantRecipe(long id, TexColorVariantRecipe texColorVariantRecipe)
        {
            if (id != texColorVariantRecipe.id)
            {
                return BadRequest();
            }

            _context.Entry(texColorVariantRecipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexColorVariantRecipeExists(id))
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

        // POST: api/TexColorVariantRecipes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexColorVariantRecipe>> PostTexColorVariantRecipe(TexColorVariantRecipe texColorVariantRecipe)
        {


            try
            {
            _context.TexColorVariantRecipe.Add(texColorVariantRecipe);
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
            return CreatedAtAction("GetTexColorVariantRecipe", new { id = texColorVariantRecipe.id }, texColorVariantRecipe);
        }

        // DELETE: api/TexColorVariantRecipes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexColorVariantRecipe>> DeleteTexColorVariantRecipe(long id)
        {
            var texColorVariantRecipe = await _context.TexColorVariantRecipe.FindAsync(id);
            if (texColorVariantRecipe == null)
            {
                return NotFound();
            }

            _context.TexColorVariantRecipe.Remove(texColorVariantRecipe);
            await _context.SaveChangesAsync();

            return texColorVariantRecipe;
        }

        private bool TexColorVariantRecipeExists(long id)
        {
            return _context.TexColorVariantRecipe.Any(e => e.id == id);
        }
    }
}
