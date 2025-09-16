using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.pos;

namespace ApiAll.Controllers.pos
{
    [ApiExplorerSettings(GroupName = "v5")]
    [Route("api/[controller]")]
    [ApiController]
    public class PosCardDetailsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosCardDetailsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosCardDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosCardDetail>>> GetPosCardDetail()
        {
            return await _context.PosCardDetail.ToListAsync();
        }

        // GET: api/PosCardDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosCardDetail>> GetPosCardDetail(long id)
        {
            var posCardDetail = await _context.PosCardDetail.FindAsync(id);

            if (posCardDetail == null)
            {
                return NotFound();
            }

            return posCardDetail;
        }

        // PUT: api/PosCardDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosCardDetail(long id, PosCardDetail posCardDetail)
        {
            if (id != posCardDetail.id)
            {
                return BadRequest();
            }

            _context.Entry(posCardDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosCardDetailExists(id))
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

        // POST: api/PosCardDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosCardDetail>> PostPosCardDetail(PosCardDetail posCardDetail)
        {
           

            try
            {
             _context.PosCardDetail.Update(posCardDetail);
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

            return CreatedAtAction("GetPosCardDetail", new { id = posCardDetail.id }, posCardDetail);
        }

        // DELETE: api/PosCardDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosCardDetail>> DeletePosCardDetail(long id)
        {
            var posCardDetail = await _context.PosCardDetail.FindAsync(id);
            if (posCardDetail == null)
            {
                return NotFound();
            }

            _context.PosCardDetail.Remove(posCardDetail);
            await _context.SaveChangesAsync();

            return posCardDetail;
        }

        private bool PosCardDetailExists(long id)
        {
            return _context.PosCardDetail.Any(e => e.id == id);
        }
    }
}
