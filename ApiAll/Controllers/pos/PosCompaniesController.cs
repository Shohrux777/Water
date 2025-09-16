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
    public class PosCompaniesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosCompaniesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosCompany>>> GetPosCompany()
        {
            return await _context.PosCompany.ToListAsync();
        }


        [HttpGet("getCompanyList")]
        public async Task<ActionResult<IEnumerable<PosCompany>>> getCompanyList()
        {
            return await _context.PosCompany.Where(p => p.pastavshik_status == false).ToListAsync();
        }
        [HttpGet("getPostavshikList")]
        public async Task<ActionResult<IEnumerable<PosCompany>>> getPostavshikList()
        {
            return await _context.PosCompany.Where(p => p.pastavshik_status == true).ToListAsync();
        }

        [HttpGet("getClientList")]
        public async Task<ActionResult<IEnumerable<PosCompany>>> getClientList()
        {
            return await _context.PosCompany.Where(p => p.client_status == true).OrderBy(p => p.name).ToListAsync();
        }


        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosCompany> itemList = await _context.PosCompany
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosCompany>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosCompany.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/PosCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosCompany>> GetPosCompany(long id)
        {
            var posCompany = await _context.PosCompany.FindAsync(id);

            if (posCompany == null)
            {
                return NotFound();
            }

            return posCompany;
        }

        // PUT: api/PosCompanies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosCompany(long id, PosCompany posCompany)
        {
            if (id != posCompany.id)
            {
                return BadRequest();
            }

            _context.Entry(posCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosCompanyExists(id))
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

        // POST: api/PosCompanies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosCompany>> PostPosCompany(PosCompany posCompany)
        {


            try
            {
                _context.PosCompany.Update(posCompany);
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

            return CreatedAtAction("GetPosCompany", new { id = posCompany.id }, posCompany);
        }

        // DELETE: api/PosCompanies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosCompany>> DeletePosCompany(long id)
        {
            var posCompany = await _context.PosCompany.FindAsync(id);
            if (posCompany == null)
            {
                return NotFound();
            }

            _context.PosCompany.Remove(posCompany);
            await _context.SaveChangesAsync();

            return posCompany;
        }

        private bool PosCompanyExists(long id)
        {
            return _context.PosCompany.Any(e => e.id == id);
        }
    }
}
