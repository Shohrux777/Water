using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.pos;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.pos
{
    [ApiExplorerSettings(GroupName = "v5")]
    [Route("api/[controller]")]
    [ApiController]
    public class PosClientsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosClientsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosClients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosClient>>> GetPosClient()
        {
            return await _context.PosClient.ToListAsync();
        }

        [HttpGet("getClientList")]
        public async Task<ActionResult<TexPaginationModel>> getClientList([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosClient> itemList = await _context.PosClient
                .Where(p => p.active_status == true)
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosClient>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosClient
                .Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/PosClients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosClient>> GetPosClient(long id)
        {
            var posClient = await _context.PosClient.FindAsync(id);

            if (posClient == null)
            {
                return NotFound();
            }

            return posClient;
        }

        // PUT: api/PosClients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosClient(long id, PosClient posClient)
        {
            if (id != posClient.id)
            {
                return BadRequest();
            }

            _context.Entry(posClient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosClientExists(id))
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

        // POST: api/PosClients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosClient>> PostPosClient(PosClient posClient)
        {
            try
            {
                 _context.PosClient.Update(posClient);
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

            return CreatedAtAction("GetPosClient", new { id = posClient.id }, posClient);
        }

        // DELETE: api/PosClients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosClient>> DeletePosClient(long id)
        {
            var posClient = await _context.PosClient.FindAsync(id);
            if (posClient == null)
            {
                return NotFound();
            }

            _context.PosClient.Remove(posClient);
            await _context.SaveChangesAsync();

            return posClient;
        }

        private bool PosClientExists(long id)
        {
            return _context.PosClient.Any(e => e.id == id);
        }
    }
}
