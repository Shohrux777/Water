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
    public class PosOrdersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosOrdersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosOrder>>> GetPosOrder()
        {
            return await _context.PosOrder.ToListAsync();
        }

        // GET: api/PosOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosOrder>> GetPosOrder(long id)
        {
            var posOrder = await _context.PosOrder.FindAsync(id);

            if (posOrder == null)
            {
                return NotFound();
            }

            return posOrder;
        }

        // PUT: api/PosOrders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosOrder(long id, PosOrder posOrder)
        {
            if (id != posOrder.id)
            {
                return BadRequest();
            }

            _context.Entry(posOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosOrderExists(id))
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

        // POST: api/PosOrders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosOrder>> PostPosOrder(PosOrder posOrder)
        {


            try
            {
                _context.PosOrder.Update(posOrder);
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

            return CreatedAtAction("GetPosOrder", new { id = posOrder.id }, posOrder);
        }

        // DELETE: api/PosOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosOrder>> DeletePosOrder(long id)
        {
            var posOrder = await _context.PosOrder.FindAsync(id);
            if (posOrder == null)
            {
                return NotFound();
            }

            _context.PosOrder.Remove(posOrder);
            await _context.SaveChangesAsync();

            return posOrder;
        }

        private bool PosOrderExists(long id)
        {
            return _context.PosOrder.Any(e => e.id == id);
        }
    }
}
