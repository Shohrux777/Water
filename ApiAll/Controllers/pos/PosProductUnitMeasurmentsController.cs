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
    public class PosProductUnitMeasurmentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosProductUnitMeasurmentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PosProductUnitMeasurments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosProductUnitMeasurment>>> GetPosProductUnitMeasurment()
        {
            return await _context.PosProductUnitMeasurment.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<PosProductUnitMeasurment> itemList = await _context.PosProductUnitMeasurment
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<PosProductUnitMeasurment>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.PosProductUnitMeasurment.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/PosProductUnitMeasurments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosProductUnitMeasurment>> GetPosProductUnitMeasurment(long id)
        {
            var posProductUnitMeasurment = await _context.PosProductUnitMeasurment.FindAsync(id);

            if (posProductUnitMeasurment == null)
            {
                return NotFound();
            }

            return posProductUnitMeasurment;
        }

        // PUT: api/PosProductUnitMeasurments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosProductUnitMeasurment(long id, PosProductUnitMeasurment posProductUnitMeasurment)
        {
            if (id != posProductUnitMeasurment.id)
            {
                return BadRequest();
            }

            _context.Entry(posProductUnitMeasurment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosProductUnitMeasurmentExists(id))
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

        // POST: api/PosProductUnitMeasurments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PosProductUnitMeasurment>> PostPosProductUnitMeasurment(PosProductUnitMeasurment posProductUnitMeasurment)
        {

            try
            {
            _context.PosProductUnitMeasurment.Update(posProductUnitMeasurment);
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

            return CreatedAtAction("GetPosProductUnitMeasurment", new { id = posProductUnitMeasurment.id }, posProductUnitMeasurment);
        }

        // DELETE: api/PosProductUnitMeasurments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PosProductUnitMeasurment>> DeletePosProductUnitMeasurment(long id)
        {
            var posProductUnitMeasurment = await _context.PosProductUnitMeasurment.FindAsync(id);
            if (posProductUnitMeasurment == null)
            {
                return NotFound();
            }

            _context.PosProductUnitMeasurment.Remove(posProductUnitMeasurment);
            await _context.SaveChangesAsync();

            return posProductUnitMeasurment;
        }

        private bool PosProductUnitMeasurmentExists(long id)
        {
            return _context.PosProductUnitMeasurment.Any(e => e.id == id);
        }
    }
}
