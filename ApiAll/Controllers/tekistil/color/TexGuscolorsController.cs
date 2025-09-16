using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;

namespace ApiAll.Controllers.tekistil
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexGuscolorsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexGuscolorsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexGuscolors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexGuscolor>>> GetTexGuscolor()
        {
            return await _context.TexGuscolor.Where( p =>p.active_status == true).OrderByDescending( p=>p.id).ToListAsync();
        }

        // GET: api/TexGuscolors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexGuscolor>> GetTexGuscolor(long id)
        {
            var texGuscolor = await _context.TexGuscolor.FindAsync(id);

            if (texGuscolor == null)
            {
                return NotFound();
            }

            return texGuscolor;
        }

        // PUT: api/TexGuscolors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexGuscolor(long id, TexGuscolor texGuscolor)
        {
            if (id != texGuscolor.id)
            {
                return BadRequest();
            }

            _context.Entry(texGuscolor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexGuscolorExists(id))
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

        // POST: api/TexGuscolors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexGuscolor>> PostTexGuscolor(TexGuscolor texGuscolor)
        {



            try
            {
            _context.TexGuscolor.Update(texGuscolor);
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

            return CreatedAtAction("GetTexGuscolor", new { id = texGuscolor.id }, texGuscolor);
        }

        // DELETE: api/TexGuscolors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexGuscolor>> DeleteTexGuscolor(long id)
        {
            var texGuscolor = await _context.TexGuscolor.FindAsync(id);
            if (texGuscolor == null)
            {
                return NotFound();
            }
            texGuscolor.active_status = true;
            _context.TexGuscolor.Update(texGuscolor);
            await _context.SaveChangesAsync();

            return texGuscolor;
        }

        private bool TexGuscolorExists(long id)
        {
            return _context.TexGuscolor.Any(e => e.id == id);
        }
    }
}
