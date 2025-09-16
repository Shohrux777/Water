using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tekistil
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexMessagesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexMessagesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexMessage>>> GetTexMessage()
        {
            return await _context.TexMessage.ToListAsync();
        }
        [HttpGet("getSetReadedMessageStatusByOwnerAndFriendAuthId")]
        public async Task<ActionResult<IEnumerable<TexMessage>>> getSetReadedMessageStatusByOwnerAndFriendAuthId([FromQuery] long owner_auth_id, [FromQuery] long friend_auth_id)
        {
            List<TexMessage> messageList =  await _context.TexMessage.Where(p => p.owner_auth_id == owner_auth_id && p.friend_auth_id == friend_auth_id).ToListAsync();
            foreach (TexMessage message in messageList) {
                message.readed_status = true;
            }
            
            try
            {
                _context.TexMessage.UpdateRange(messageList);
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

            return messageList;

        }

        [HttpGet("getUnreadedMessageCounsList")]
        public async Task<ActionResult<IEnumerable<TexMessageUnreadedCountModel>>> getUnreadedMessageCounsList([FromQuery] long owner_auth_id)
        {
            List<TexMessageUnreadedCountModel> unreadedCountModels = new List<TexMessageUnreadedCountModel>();
            List<TexMessageGroup> texMessageGroups = await _context.TexMessageGroup.Where(p => p.owner_auth_id == owner_auth_id).ToListAsync();
            foreach (TexMessageGroup group in texMessageGroups) {
                TexMessageUnreadedCountModel modelUnreaded = new TexMessageUnreadedCountModel();
                modelUnreaded.authorization = (await _context.TexAuthorization.Where(p => p.id == group.friend_auth_id).Include( p =>p.user).ToListAsync()).First();
                modelUnreaded.friend_auth_id = group.friend_auth_id;
                modelUnreaded.owner_auth_id = group.owner_auth_id;
                modelUnreaded.count = await _context.TexMessage.Where( p =>p.owner_auth_id == owner_auth_id && p.friend_auth_id == group.friend_auth_id && p.readed_status == false).CountAsync();
                unreadedCountModels.Add(modelUnreaded);

            }
            return unreadedCountModels;
        }

        [HttpGet("getMessageListByFriendId")]
        public async Task<ActionResult<TexPaginationModel>> getMessageListByFriendId([FromQuery] long owner_auth_id,[FromQuery] long friend_auth_id,[FromQuery] int size,[FromQuery] int page)
        {
            List<TexMessage> messsageList =  await _context.TexMessage.Where( p => p.owner_auth_id == owner_auth_id && p.friend_auth_id == friend_auth_id).OrderByDescending( p => p.id).Skip(page * size).Take(size).ToListAsync();
            TexPaginationModel paginationModel = new TexPaginationModel();
            if (messsageList == null)
            {
                messsageList = new List<TexMessage>();
            }
            paginationModel.items_list = JArray.FromObject(messsageList);
            paginationModel.items_count = await _context.TexMessage.Where(p => p.owner_auth_id == owner_auth_id && p.friend_auth_id == friend_auth_id).CountAsync();
            paginationModel.current_item_count = messsageList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TexMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexMessage>> GetTexMessage(long id)
        {
            var texMessage = await _context.TexMessage.FindAsync(id);

            if (texMessage == null)
            {
                return NotFound();
            }

            return texMessage;
        }

        [HttpGet("sendMessageToUserWithAuthId")]
        public async Task<ActionResult<TexMessage>> sendMessageToUserWithAuthId([FromQuery]long owner_auth_id,[FromQuery] long friend_auth_id,[FromQuery]String message)
        {
            TexMessage sms = new TexMessage();
            sms.active_status = true;
            sms.owner_auth_id = owner_auth_id;
            sms.friend_auth_id = friend_auth_id;
            sms.sender_auth_id = owner_auth_id;
            sms.recevier_auth_id = friend_auth_id;
            sms.message = message;
            sms.readed_status = true;

            TexMessage sms1 = new TexMessage();
            sms1.active_status = true;
            sms1.owner_auth_id = friend_auth_id;
            sms1.friend_auth_id = owner_auth_id;
            sms1.sender_auth_id = owner_auth_id;
            sms1.recevier_auth_id = friend_auth_id;
            sms1.message = message;
            sms1.readed_status = false;



            try {
                _context.TexMessage.Update(sms);
                await _context.SaveChangesAsync();
                sms1.main_message_id = sms.id;
                _context.TexMessage.Update(sms1);
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

            return sms;
        }

        // PUT: api/TexMessages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexMessage(long id, TexMessage texMessage)
        {
            if (id != texMessage.id)
            {
                return BadRequest();
            }

            _context.Entry(texMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexMessageExists(id))
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

        // POST: api/TexMessages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexMessage>> PostTexMessage(TexMessage texMessage)
        {
            _context.TexMessage.Add(texMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexMessage", new { id = texMessage.id }, texMessage);
        }

        // DELETE: api/TexMessages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexMessage>> DeleteTexMessage(long id)
        {
            var texMessage = await _context.TexMessage.FindAsync(id);
            if (texMessage == null)
            {
                return NotFound();
            }

            _context.TexMessage.Remove(texMessage);
            await _context.SaveChangesAsync();

            return texMessage;
        }

        private bool TexMessageExists(long id)
        {
            return _context.TexMessage.Any(e => e.id == id);
        }
    }
}
