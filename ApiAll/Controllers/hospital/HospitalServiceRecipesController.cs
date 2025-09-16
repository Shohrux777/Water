using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalServiceRecipesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalServiceRecipesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalServiceRecipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalServiceRecipe>>> GetHospitalServiceRecipe()
        {
            return await _context.HospitalServiceRecipe.ToListAsync();
        }

        // GET: api/HospitalServiceRecipes
        [HttpGet("getHospitalServiceByServiceTypeId")]
        public async Task<ActionResult<IEnumerable<HospitalServiceRecipe>>> getHospitalServiceByServiceTypeId([FromQuery] long serviceTypeId)
        {
            return await _context.HospitalServiceRecipe.Where( s => s.ServiceTypeId == serviceTypeId).Include(s =>s.marketProduct).ToListAsync();
        }

        // GET: api/HospitalServiceRecipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalServiceRecipe>> GetHospitalServiceRecipe(long id)
        {
            var hospitalServiceRecipe = await _context.HospitalServiceRecipe.FindAsync(id);

            if (hospitalServiceRecipe == null)
            {
                return NotFound();
            }


          

            return hospitalServiceRecipe;
        }

        // PUT: api/HospitalServiceRecipes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalServiceRecipe(long id, HospitalServiceRecipe hospitalServiceRecipe)
        {
            if (id != hospitalServiceRecipe.Id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalServiceRecipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalServiceRecipeExists(id))
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

        // POST: api/HospitalServiceRecipes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalServiceRecipe>> PostHospitalServiceRecipe(HospitalServiceRecipe hospitalServiceRecipe)
        {
            _context.HospitalServiceRecipe.Update(hospitalServiceRecipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalServiceRecipe", new { id = hospitalServiceRecipe.Id }, hospitalServiceRecipe);
        }

        // DELETE: api/HospitalServiceRecipes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalServiceRecipe>> DeleteHospitalServiceRecipe(long id)
        {
            var hospitalServiceRecipe = await _context.HospitalServiceRecipe.FindAsync(id);
            if (hospitalServiceRecipe == null)
            {
                return NotFound();
            }

            _context.HospitalServiceRecipe.Remove(hospitalServiceRecipe);
            await _context.SaveChangesAsync();

            return hospitalServiceRecipe;
        }

        private bool HospitalServiceRecipeExists(long id)
        {
            return _context.HospitalServiceRecipe.Any(e => e.Id == id);
        }
    }
}
