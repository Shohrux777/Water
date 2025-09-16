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
    public class TexLanguagesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexLanguagesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexLanguages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexLanguage>>> GetTexLanguage()
        {
            return await _context.TexLanguage.Where( p =>p.active_status == true).OrderByDescending(p => p.id).ToListAsync();
        }

        // GET: api/TexLanguages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexLanguage>> GetTexLanguage(long id)
        {
            var texLanguage = await _context.TexLanguage.FindAsync(id);

            if (texLanguage == null)
            {
                return NotFound();
            }

            return texLanguage;
        }

        [HttpGet("getCurrentUserLanguageByAuthId")]
        public async Task<ActionResult<TexLanguage>> getCurrentUserLanguage([FromQuery]long user_auth_id)
        {
            List<TexLanguage> texLanguageList = await _context.TexLanguage.Where( p => p.user_auth_id == user_auth_id).Include(p => p.user_auth).ToListAsync();

            if (texLanguageList == null || texLanguageList.Count == 0)
            {
                return NotFound("Language not found");
            }

            return texLanguageList.First();
        }

        // PUT: api/TexLanguages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexLanguage(long id, TexLanguage texLanguage)
        {
            if (id != texLanguage.id)
            {
                return BadRequest();
            }

            _context.Entry(texLanguage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexLanguageExists(id))
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

        // POST: api/TexLanguages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexLanguage>> PostTexLanguage(TexLanguage texLanguage)
        {
            try
            {
             _context.TexLanguage.Update(texLanguage);
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

            return CreatedAtAction("GetTexLanguage", new { id = texLanguage.id }, texLanguage);
        }

        // DELETE: api/TexLanguages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexLanguage>> DeleteTexLanguage(long id)
        {
            var texLanguage = await _context.TexLanguage.FindAsync(id);
            if (texLanguage == null)
            {
                return NotFound();
            }
            texLanguage.active_status = false;
            _context.TexLanguage.Update(texLanguage);
            await _context.SaveChangesAsync();

            return texLanguage;
        }

        private bool TexLanguageExists(long id)
        {
            return _context.TexLanguage.Any(e => e.id == id);
        }
    }
}
