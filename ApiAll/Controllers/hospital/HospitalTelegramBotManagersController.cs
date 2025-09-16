using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model;
using Telegram.Bot;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalTelegramBotManagersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly TelegramBotClient botClient = new TelegramBotClient("1958356792:AAEDu2gEXvF9llHoU85IdXKg8j2X39JEvRg");

        public HospitalTelegramBotManagersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalTelegramBotManagers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalTelegramBotManager>>> GetHospitalTelegramBotManager()
        {
            return await _context.HospitalTelegramBotManager.ToListAsync();
        }

        // GET: api/HospitalTelegramBotManagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalTelegramBotManager>> GetHospitalTelegramBotManager(long id)
        {
            var hospitalTelegramBotManager = await _context.HospitalTelegramBotManager.FindAsync(id);

            if (hospitalTelegramBotManager == null)
            {
                return NotFound();
            }

            return hospitalTelegramBotManager;
        }

        // PUT: api/HospitalTelegramBotManagers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalTelegramBotManager(long id, HospitalTelegramBotManager hospitalTelegramBotManager)
        {
            if (id != hospitalTelegramBotManager.Id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalTelegramBotManager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalTelegramBotManagerExists(id))
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

        // POST: api/HospitalTelegramBotManagers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalTelegramBotManager>> PostHospitalTelegramBotManager(HospitalTelegramBotManager hospitalTelegramBotManager)
        {
            _context.HospitalTelegramBotManager.Update(hospitalTelegramBotManager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalTelegramBotManager", new { id = hospitalTelegramBotManager.Id }, hospitalTelegramBotManager);
        }

        [HttpPost("getSendMessageToSelectedContragentsUziAndLabaratoriya")]
        public async Task<ActionResult<HospitalTelegramBotManager>> getSendMessageToSelectedContragentsUziAndLabaratoriya(List<CustomContragentReport> customContragentReportList)
        {
            try
            {
                if (customContragentReportList != null && customContragentReportList.Count > 0)
                {
                    foreach (CustomContragentReport item in customContragentReportList)
                    {
                        if (item != null)
                        {
                            long contragentId = item.contragentId;
                            Contragent contragent = await _context.contragents.FindAsync(contragentId);
                            if (contragent != null && contragent.chatBotId != null)
                            {
                                String customMessage = " FIO:  " + contragent.Name + "  UZI: " + item.mrt + " LABARATORIYA: " + item.mskt + " Sana: " + item.datereg.ToString("yyyy-MM-dd");
                                await botClient.SendTextMessageAsync(contragent.chatBotId, customMessage);
                            }
                        }
                    }
                }

            }
            catch (Exception) { }
            return new HospitalTelegramBotManager();
        }

        [HttpPost("getSendMessageToSelectedContragentsMrtAndMskt")]
        public async Task<ActionResult<HospitalTelegramBotManager>> getSendMessageToSelectedContragentsMrtAndMskt( List<CustomContragentReport> customContragentReportList)
        {
            try
            {
                if (customContragentReportList != null && customContragentReportList.Count > 0) {
                    foreach (CustomContragentReport item in customContragentReportList) {
                        if (item != null) {
                            long contragentId = item.contragentId;
                            Contragent contragent = await _context.contragents.FindAsync(contragentId);
                            if (contragent != null && contragent.chatBotId != null) { 
                               String customMessage = "FIO:"+contragent.Name+"   MRT:  "+item.mrt+"  MSKT: "+item.mskt +" Sana:  "+item.datereg.ToString("yyyy-MM-dd");
                                await botClient.SendTextMessageAsync(contragent.chatBotId, customMessage);
                            }
                        }
                    }
                }

            }
            catch(Exception) { }
            return new HospitalTelegramBotManager();
        }

        // DELETE: api/HospitalTelegramBotManagers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalTelegramBotManager>> DeleteHospitalTelegramBotManager(long id)
        {
            var hospitalTelegramBotManager = await _context.HospitalTelegramBotManager.FindAsync(id);
            if (hospitalTelegramBotManager == null)
            {
                return NotFound();
            }

            _context.HospitalTelegramBotManager.Remove(hospitalTelegramBotManager);
            await _context.SaveChangesAsync();

            return hospitalTelegramBotManager;
        }

        private bool HospitalTelegramBotManagerExists(long id)
        {
            return _context.HospitalTelegramBotManager.Any(e => e.Id == id);
        }
    }
}
