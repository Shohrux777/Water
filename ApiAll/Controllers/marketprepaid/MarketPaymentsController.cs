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
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class MarketPaymentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MarketPaymentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/MarketPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketPayments>>> GetMarketPayments()
        {
            return await _context.MarketPayments.ToListAsync();
        }

        // GET: api/MarketPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketPayments>> GetMarketPayments(long id)
        {
            var marketPayments = await _context.MarketPayments.FindAsync(id);

            if (marketPayments == null)
            {
                return NotFound();
            }

            return marketPayments;
        }

        // PUT: api/MarketPayments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketPayments(long id, MarketPayments marketPayments)
        {
            if (id != marketPayments.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketPayments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketPaymentsExists(id))
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

        // POST: api/MarketPayments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketPayments>> PostMarketPayments(MarketPayments marketPayments)
        {
            _context.MarketPayments.Update(marketPayments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketPayments", new { id = marketPayments.Id }, marketPayments);
        }

        // DELETE: api/MarketPayments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketPayments>> DeleteMarketPayments(long id)
        {
            var marketPayments = await _context.MarketPayments.FindAsync(id);
            if (marketPayments == null)
            {
                return NotFound();
            }

            _context.MarketPayments.Remove(marketPayments);
            await _context.SaveChangesAsync();

            return marketPayments;
        }

        private bool MarketPaymentsExists(long id)
        {
            return _context.MarketPayments.Any(e => e.Id == id);
        }
    }
}
