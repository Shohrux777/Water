using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tegirmon;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tegirmon
{
    [ApiExplorerSettings(GroupName = "v7")]
    [Route("api/[controller]")]
    [ApiController]
    public class TegirmonTelegramBotMessagesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TegirmonTelegramBotMessagesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TegirmonTelegramBotMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TegirmonTelegramBotMessages>>> GetTegirmonTelegramBotMessages()
        {
            return await _context.TegirmonTelegramBotMessages.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TegirmonTelegramBotMessages> categoryList = await _context.TegirmonTelegramBotMessages
                .Where(p => p.active_status == true)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TegirmonTelegramBotMessages>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TegirmonTelegramBotMessages.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }
        // GET: api/TegirmonTelegramBotMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TegirmonTelegramBotMessages>> GetTegirmonTelegramBotMessages(long id)
        {
            var tegirmonTelegramBotMessages = await _context.TegirmonTelegramBotMessages.FindAsync(id);

            if (tegirmonTelegramBotMessages == null)
            {
                return NotFound();
            }

            return tegirmonTelegramBotMessages;
        }

        // PUT: api/TegirmonTelegramBotMessages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTegirmonTelegramBotMessages(long id, TegirmonTelegramBotMessages tegirmonTelegramBotMessages)
        {
            if (id != tegirmonTelegramBotMessages.id)
            {
                return BadRequest();
            }

            _context.Entry(tegirmonTelegramBotMessages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TegirmonTelegramBotMessagesExists(id))
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

        // POST: api/TegirmonTelegramBotMessages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TegirmonTelegramBotMessages>> PostTegirmonTelegramBotMessages(TegirmonTelegramBotMessages tegirmonTelegramBotMessages)
        {
            _context.TegirmonTelegramBotMessages.Update(tegirmonTelegramBotMessages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTegirmonTelegramBotMessages", new { id = tegirmonTelegramBotMessages.id }, tegirmonTelegramBotMessages);
        }

        // DELETE: api/TegirmonTelegramBotMessages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TegirmonTelegramBotMessages>> DeleteTegirmonTelegramBotMessages(long id)
        {
            var tegirmonTelegramBotMessages = await _context.TegirmonTelegramBotMessages.FindAsync(id);
            if (tegirmonTelegramBotMessages == null)
            {
                return NotFound();
            }

            _context.TegirmonTelegramBotMessages.Remove(tegirmonTelegramBotMessages);
            await _context.SaveChangesAsync();

            return tegirmonTelegramBotMessages;
        }

        private bool TegirmonTelegramBotMessagesExists(long id)
        {
            return _context.TegirmonTelegramBotMessages.Any(e => e.id == id);
        }
    }
}
