using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContragentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ContragentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Contragents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contragent>>> Getcontragents()
        {
            return await _context.contragents.Where( p => p.ActiveStatus == true).Include(c => c.districts).OrderByDescending(p => p.Id).ToListAsync();
        }
        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<Contragent> itemList = await _context.contragents
                .Include(p => p.districts)
                .OrderByDescending(p => p.Id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<Contragent>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.contragents.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/Contragents
        [HttpGet("getContragentListByDistrictId")]
        public async Task<ActionResult<IEnumerable<Contragent>>> getContragentListByDistrictId([FromQuery] long districtId)
        {
            return await _context.contragents.Where(p => p.DistrictsId == districtId).Include(c => c.districts).OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/Contragents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contragent>> GetContragent(long id)
        {
            var contragent = await _context.contragents.FindAsync(id);

            if (contragent == null)
            {
                return NotFound();
            }

            return contragent;
        }

        // PUT: api/Contragents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContragent(long id, Contragent contragent)
        {
            if (id != contragent.Id)
            {
                return BadRequest();
            }

            _context.Entry(contragent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContragentExists(id))
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

        // POST: api/Contragents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Contragent>> PostContragent(Contragent contragent)
        {
            _context.contragents.Update(contragent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContragent", new { id = contragent.Id }, contragent);
        }

        [HttpGet("addContragent")]
        public async Task<ActionResult<Contragent>> AddContragent([FromQuery] long Id, [FromQuery] String name, [FromQuery] String phoneNumber, [FromQuery] String address,[FromQuery] Boolean client,[FromQuery]Boolean supplier,[FromQuery] Boolean maincompany)
        {
            Contragent contragent = new Contragent();
            try
            {
                contragent.ActiveStatus = true;
                contragent.client = client;
                contragent.supplier = supplier;
                contragent.maincompany = maincompany;
                contragent.Id = Id;
                contragent.Note = String.Empty;
                contragent.Name = name;
                contragent.PhoneNumber = phoneNumber;
                contragent.Address = address;
                _context.contragents.Update(contragent);
                await _context.SaveChangesAsync();

    }
            catch (Exception) { 
            }

            return contragent;
        }

        // DELETE: api/Contragents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contragent>> DeleteContragent(long id)
        {
            var contragent = await _context.contragents.FindAsync(id);
            if (contragent == null)
            {
                return NotFound();
            }

            contragent.ActiveStatus = false;
            contragent.PhoneNumber = "";
            _context.contragents.Update(contragent);
            await _context.SaveChangesAsync();

            return contragent;
        }

        private bool ContragentExists(long id)
        {
            return _context.contragents.Any(e => e.Id == id);
        }
    }
}
