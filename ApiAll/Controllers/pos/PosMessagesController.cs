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
    public class PosMessagesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosMessagesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosMessage>>> GetPosMessage()
        {
            return await _context.PosMessage.ToListAsync();
        }

        // GET: api/PosMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosMessage>> GetPosMessage(long id)
        {
            var posMessage = await _context.PosMessage.FindAsync(id);

            if (posMessage == null)
            {
                return NotFound();
            }

            return posMessage;
        }

        // PUT: api/PosMessages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosMessage(long id, PosMessage posMessage)
        {
            if (id != posMessage.id)
            {
                return BadRequest();
            }

            _context.Entry(posMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosMessageExists(id))
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

        // POST: api/PosMessages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosMessage>> PostPosMessage(PosMessage posMessage)
        {

            try
            {
                _context.PosMessage.Update(posMessage);
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

            return CreatedAtAction("GetPosMessage", new { id = posMessage.id }, posMessage);
        }

        // DELETE: api/PosMessages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosMessage>> DeletePosMessage(long id)
        {
            var posMessage = await _context.PosMessage.FindAsync(id);
            if (posMessage == null)
            {
                return NotFound();
            }

            _context.PosMessage.Remove(posMessage);
            await _context.SaveChangesAsync();

            return posMessage;
        }

        private bool PosMessageExists(long id)
        {
            return _context.PosMessage.Any(e => e.id == id);
        }
    }
}
