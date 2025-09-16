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
    public class TexDeviceSubProccessDetailsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexDeviceSubProccessDetailsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexDeviceSubProccessDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexDeviceSubProccessDetail>>> GetTexDeviceSubProccessDetail()
        {
            return await _context.TexDeviceSubProccessDetail.ToListAsync();
        }

        // GET: api/TexDeviceSubProccessDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexDeviceSubProccessDetail>> GetTexDeviceSubProccessDetail(long id)
        {
            var texDeviceSubProccessDetail = await _context.TexDeviceSubProccessDetail.FindAsync(id);

            if (texDeviceSubProccessDetail == null)
            {
                return NotFound();
            }

            return texDeviceSubProccessDetail;
        }

        // PUT: api/TexDeviceSubProccessDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexDeviceSubProccessDetail(long id, TexDeviceSubProccessDetail texDeviceSubProccessDetail)
        {
            if (id != texDeviceSubProccessDetail.id)
            {
                return BadRequest();
            }

            _context.Entry(texDeviceSubProccessDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexDeviceSubProccessDetailExists(id))
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

        // POST: api/TexDeviceSubProccessDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexDeviceSubProccessDetail>> PostTexDeviceSubProccessDetail(TexDeviceSubProccessDetail texDeviceSubProccessDetail)
        {
            _context.TexDeviceSubProccessDetail.Update(texDeviceSubProccessDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexDeviceSubProccessDetail", new { id = texDeviceSubProccessDetail.id }, texDeviceSubProccessDetail);
        }

        // DELETE: api/TexDeviceSubProccessDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexDeviceSubProccessDetail>> DeleteTexDeviceSubProccessDetail(long id)
        {
            var texDeviceSubProccessDetail = await _context.TexDeviceSubProccessDetail.FindAsync(id);
            if (texDeviceSubProccessDetail == null)
            {
                return NotFound();
            }

            _context.TexDeviceSubProccessDetail.Remove(texDeviceSubProccessDetail);
            await _context.SaveChangesAsync();

            return texDeviceSubProccessDetail;
        }

        private bool TexDeviceSubProccessDetailExists(long id)
        {
            return _context.TexDeviceSubProccessDetail.Any(e => e.id == id);
        }
    }
}
