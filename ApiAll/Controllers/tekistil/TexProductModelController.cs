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
    public class TexProductModelController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexProductModelController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexProductModel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexProductModel>>> GetTexProductModel()
        {
            return await _context.TexProductModel.OrderByDescending(p =>p.id).ToListAsync();
        }

        // GET: api/TexProductModel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexProductModel>> GetTexProductModel(long id)
        {
            var texProductModel = await _context.TexProductModel.FindAsync(id);

            if (texProductModel == null)
            {
                return NotFound();
            }

            return texProductModel;
        }

        // PUT: api/TexProductModel/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexProductModel(long id, TexProductModel texProductModel)
        {
            if (id != texProductModel.id)
            {
                return BadRequest();
            }

            _context.Entry(texProductModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexProductModelExists(id))
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

        // POST: api/TexProductModel
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexProductModel>> PostTexProductModel(TexProductModel texProductModel)
        {
            _context.TexProductModel.Update(texProductModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexProductModel", new { id = texProductModel.id }, texProductModel);
        }

        // DELETE: api/TexProductModel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexProductModel>> DeleteTexProductModel(long id)
        {
            var texProductModel = await _context.TexProductModel.FindAsync(id);
            if (texProductModel == null)
            {
                return NotFound();
            }

            _context.TexProductModel.Remove(texProductModel);
            await _context.SaveChangesAsync();

            return texProductModel;
        }

        private bool TexProductModelExists(long id)
        {
            return _context.TexProductModel.Any(e => e.id == id);
        }
    }
}
