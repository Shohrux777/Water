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
    public class VozvratAlreadyPaidPaymentListsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public VozvratAlreadyPaidPaymentListsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/VozvratAlreadyPaidPaymentLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VozvratAlreadyPaidPaymentList>>> GetVozvratAlreadyPaidPaymentList()
        {
            return await _context.VozvratAlreadyPaidPaymentList.ToListAsync();
        }

        [HttpGet("getVozvratByDateTimeAsList")]
        public async Task<ActionResult<IEnumerable<VozvratAlreadyPaidPaymentList>>> getVozvratByDateTimeAsList([FromQuery] DateTime beginDate,[FromQuery] DateTime endDate)
        {
            return await _context.VozvratAlreadyPaidPaymentList.Where( p =>  p.dateTime >= beginDate && p.dateTime <= endDate).ToListAsync();
        }

        // GET: api/VozvratAlreadyPaidPaymentLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VozvratAlreadyPaidPaymentList>> GetVozvratAlreadyPaidPaymentList(long id)
        {
            var vozvratAlreadyPaidPaymentList = await _context.VozvratAlreadyPaidPaymentList.FindAsync(id);

            if (vozvratAlreadyPaidPaymentList == null)
            {
                return NotFound();
            }

            return vozvratAlreadyPaidPaymentList;
        }

        // PUT: api/VozvratAlreadyPaidPaymentLists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVozvratAlreadyPaidPaymentList(long id, VozvratAlreadyPaidPaymentList vozvratAlreadyPaidPaymentList)
        {
            if (id != vozvratAlreadyPaidPaymentList.Id)
            {
                return BadRequest();
            }

            _context.Entry(vozvratAlreadyPaidPaymentList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VozvratAlreadyPaidPaymentListExists(id))
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

        // POST: api/VozvratAlreadyPaidPaymentLists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VozvratAlreadyPaidPaymentList>> PostVozvratAlreadyPaidPaymentList(VozvratAlreadyPaidPaymentList vozvratAlreadyPaidPaymentList)
        {
            _context.VozvratAlreadyPaidPaymentList.Update(vozvratAlreadyPaidPaymentList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVozvratAlreadyPaidPaymentList", new { id = vozvratAlreadyPaidPaymentList.Id }, vozvratAlreadyPaidPaymentList);
        }

        // DELETE: api/VozvratAlreadyPaidPaymentLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VozvratAlreadyPaidPaymentList>> DeleteVozvratAlreadyPaidPaymentList(long id)
        {
            var vozvratAlreadyPaidPaymentList = await _context.VozvratAlreadyPaidPaymentList.FindAsync(id);
            if (vozvratAlreadyPaidPaymentList == null)
            {
                return NotFound();
            }

            _context.VozvratAlreadyPaidPaymentList.Remove(vozvratAlreadyPaidPaymentList);
            await _context.SaveChangesAsync();

            return vozvratAlreadyPaidPaymentList;
        }

        private bool VozvratAlreadyPaidPaymentListExists(long id)
        {
            return _context.VozvratAlreadyPaidPaymentList.Any(e => e.Id == id);
        }
    }
}
