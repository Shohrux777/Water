using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil.seworder;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.tekistil.seworder
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexSewOrderItemStepController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexSewOrderItemStepController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexSewOrderItemStep
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexSewOrderItemStep>>> GetTexSewOrderItemStep()
        {
            return await _context.TexSewOrderItemStep.ToListAsync();
        }

        [HttpGet("getPaginationBySewOrderId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationBySewOrderId(
    [FromQuery] int page,
    [FromQuery] int size,
    [FromQuery] long order_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<TexSewOrderItem> categoryList = await _context.TexSewOrderItem.Where(p => p.active_status == true
            && p.TexSewOrderid == order_id)
                .Include(p => p.product)
                .Include(p => p.size)
                .Include(p => p.color)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<TexSewOrderItem>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.TexSewOrderItem.Where(p => p.active_status == true && p.TexSewOrderid == order_id).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/TexSewOrderItemStep/5
        [HttpGet("startSewOrderStepStartById")]
        public async Task<ActionResult<TexSewOrderItemStep>> startSewOrderStepStartById([FromQuery]long id)
        {
            var texSewOrderItemStep = await _context.TexSewOrderItemStep.FindAsync(id);


            if (texSewOrderItemStep == null)
            {
                return NotFound();
            }
            if (texSewOrderItemStep.start_status) {
                return NotFound("Start qilingan allaqachon");
            }

            texSewOrderItemStep.start_date = DateTime.Now;
            texSewOrderItemStep.start_status = true;

            return texSewOrderItemStep;
        }


        [HttpGet("stopSewOrderStepFinishById")]
        public async Task<ActionResult<TexSewOrderItemStep>> stopSewOrderStepFinishById([FromQuery] long id)
        {
            var texSewOrderItemStep = await _context.TexSewOrderItemStep.FindAsync(id);


            if (texSewOrderItemStep == null)
            {
                return NotFound();
            }
            if (texSewOrderItemStep.stop_status)
            {
                return NotFound("Stop  qilingan allaqachon");
            }

            texSewOrderItemStep.stop_date = DateTime.Now;
            texSewOrderItemStep.stop_status = true;

            return texSewOrderItemStep;
        }

        [HttpGet("finishSewOrderStepFinishById")]
        public async Task<ActionResult<TexSewOrderItemStep>> stopSewOrderStepStopById([FromQuery] long id)
        {
            var texSewOrderItemStep = await _context.TexSewOrderItemStep.FindAsync(id);


            if (texSewOrderItemStep == null)
            {
                return NotFound();
            }
            if (texSewOrderItemStep.finish_status)
            {
                return NotFound("Finish  qilingan allaqachon");
            }

            texSewOrderItemStep.finish_date = DateTime.Now;
            texSewOrderItemStep.finish_status = true;

            return texSewOrderItemStep;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TexSewOrderItemStep>> GetTexSewOrderItemStep(long id)
        {
            var texSewOrderItemStep = await _context.TexSewOrderItemStep.FindAsync(id);

            if (texSewOrderItemStep == null)
            {
                return NotFound();
            }

            return texSewOrderItemStep;
        }

        // PUT: api/TexSewOrderItemStep/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexSewOrderItemStep(long id, TexSewOrderItemStep texSewOrderItemStep)
        {
            if (id != texSewOrderItemStep.id)
            {
                return BadRequest();
            }

            _context.Entry(texSewOrderItemStep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexSewOrderItemStepExists(id))
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

        // POST: api/TexSewOrderItemStep
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexSewOrderItemStep>> PostTexSewOrderItemStep(TexSewOrderItemStep texSewOrderItemStep)
        {
            _context.TexSewOrderItemStep.Update(texSewOrderItemStep);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexSewOrderItemStep", new { id = texSewOrderItemStep.id }, texSewOrderItemStep);
        }

        // DELETE: api/TexSewOrderItemStep/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexSewOrderItemStep>> DeleteTexSewOrderItemStep(long id)
        {
            var texSewOrderItemStep = await _context.TexSewOrderItemStep.FindAsync(id);
            if (texSewOrderItemStep == null)
            {
                return NotFound();
            }

            _context.TexSewOrderItemStep.Remove(texSewOrderItemStep);
            await _context.SaveChangesAsync();

            return texSewOrderItemStep;
        }

        private bool TexSewOrderItemStepExists(long id)
        {
            return _context.TexSewOrderItemStep.Any(e => e.id == id);
        }
    }
}
