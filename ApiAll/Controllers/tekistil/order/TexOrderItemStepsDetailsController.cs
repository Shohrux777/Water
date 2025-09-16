using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.tekistil;

namespace ApiAll.Controllers.tekistil
{
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/[controller]")]
    [ApiController]
    public class TexOrderItemStepsDetailsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TexOrderItemStepsDetailsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TexOrderItemStepsDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TexOrderItemStepsDetail>>> GetTexOrderItemStepsDetail()
        {
            return await _context.TexOrderItemStepsDetail.ToListAsync();
        }

        [HttpGet("getOrderStepsByOrderItemId")]
        public async Task<ActionResult<IEnumerable<TexOrderItemStepsDetail>>> getOrderStepsByOrderItemId([FromQuery] long order_item_id)
        {
            return await _context.TexOrderItemStepsDetail.Include(p => p.orderItem).Include( p => p.orderItemSteps).OrderBy(p =>p.sort_number).ToListAsync();
        }

        // GET: api/TexOrderItemStepsDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TexOrderItemStepsDetail>> GetTexOrderItemStepsDetail(long id)
        {
            var texOrderItemStepsDetail = await _context.TexOrderItemStepsDetail.FindAsync(id);

            if (texOrderItemStepsDetail == null)
            {
                return NotFound();
            }

            return texOrderItemStepsDetail;
        }



        [HttpGet("getStartOrtderItemByOrderStepDetailId")]
        public async Task<ActionResult<TexOrderItemStepsDetail>> getStartOrtderItemByOrderStepDetailId([FromQuery] long order_step_detail_id, [FromQuery] bool start_all)
        {
            var texOrderItemStepsDetail = await _context.TexOrderItemStepsDetail.FindAsync(order_step_detail_id);

            if (texOrderItemStepsDetail == null)
            {
                return NotFound();
            }

            if (start_all)
            {
                if (texOrderItemStepsDetail.main_order_item_id == null)
                {

                    return NotFound("Вы не можете начать все.идентификатор основного элемента не найден");
                }

                List<TexOrderItemStepsDetail> texOrderItemStepsDetailList = await _context.TexOrderItemStepsDetail.Where(p => p.main_order_item_id == texOrderItemStepsDetail.main_order_item_id && p.sort_number == texOrderItemStepsDetail.sort_number).ToListAsync();
                foreach (TexOrderItemStepsDetail item in texOrderItemStepsDetailList)
                {
                    item.start = true;
                    item.start_time = DateTime.Now;
                }

                try
                {
                    _context.TexOrderItemStepsDetail.UpdateRange(texOrderItemStepsDetailList);
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




            }
            else
            {

                texOrderItemStepsDetail.start = true;
                texOrderItemStepsDetail.start_time = DateTime.Now;
                _context.TexOrderItemStepsDetail.Update(texOrderItemStepsDetail);
                await _context.SaveChangesAsync();



            }

            return texOrderItemStepsDetail;
        }

        [HttpGet("getStopOrtderItemByOrderStepDetailId")]
        public async Task<ActionResult<TexOrderItemStepsDetail>> getStopOrtderItemByOrderStepDetailId([FromQuery]long order_step_detail_id,[FromQuery] bool stop_all)
        {
            var texOrderItemStepsDetail = await _context.TexOrderItemStepsDetail.FindAsync(order_step_detail_id);

            if (texOrderItemStepsDetail == null)
            {
                return NotFound();
            }

            if (stop_all)
            {
                if (texOrderItemStepsDetail.main_order_item_id == null) {

                    return NotFound("Вы не можете начать все.идентификатор основного элемента не найден");
                }

                List<TexOrderItemStepsDetail> texOrderItemStepsDetailList = await _context.TexOrderItemStepsDetail.Where(p => p.main_order_item_id == texOrderItemStepsDetail.main_order_item_id && p.sort_number == texOrderItemStepsDetail.sort_number).ToListAsync();
                foreach (TexOrderItemStepsDetail item in texOrderItemStepsDetailList) {
                    item.stop = true;
                    item.stop_time = DateTime.Now;
                }

                try
                {
                    _context.TexOrderItemStepsDetail.UpdateRange(texOrderItemStepsDetailList);
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




            }
            else {

                texOrderItemStepsDetail.stop = true;
                texOrderItemStepsDetail.stop_time = DateTime.Now;
                _context.TexOrderItemStepsDetail.Update(texOrderItemStepsDetail);
                await _context.SaveChangesAsync();



            }

            return texOrderItemStepsDetail;
        }

        // PUT: api/TexOrderItemStepsDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexOrderItemStepsDetail(long id, TexOrderItemStepsDetail texOrderItemStepsDetail)
        {
            if (id != texOrderItemStepsDetail.id)
            {
                return BadRequest();
            }

            _context.Entry(texOrderItemStepsDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexOrderItemStepsDetailExists(id))
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

        // POST: api/TexOrderItemStepsDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TexOrderItemStepsDetail>> PostTexOrderItemStepsDetail(TexOrderItemStepsDetail texOrderItemStepsDetail)
        {
            try
            {
                _context.TexOrderItemStepsDetail.Update(texOrderItemStepsDetail);
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

            return CreatedAtAction("GetTexOrderItemStepsDetail", new { id = texOrderItemStepsDetail.id }, texOrderItemStepsDetail);
        }

        [HttpPost("addStepsToMainOrderItem")]
        public async Task<ActionResult<IEnumerable<TexOrderItemStepsDetail>>> addStepsToMainOrderItem( List<TexOrderItemStepsDetail> texOrderItemStepsDetailList)
        {
            try
            {
                _context.TexOrderItemStepsDetail.UpdateRange(texOrderItemStepsDetailList);
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

            return texOrderItemStepsDetailList;
        }

        // DELETE: api/TexOrderItemStepsDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TexOrderItemStepsDetail>> DeleteTexOrderItemStepsDetail(long id)
        {
            var texOrderItemStepsDetail = await _context.TexOrderItemStepsDetail.FindAsync(id);
            if (texOrderItemStepsDetail == null)
            {
                return NotFound();
            }

            _context.TexOrderItemStepsDetail.Remove(texOrderItemStepsDetail);
            await _context.SaveChangesAsync();

            return texOrderItemStepsDetail;
        }

        private bool TexOrderItemStepsDetailExists(long id)
        {
            return _context.TexOrderItemStepsDetail.Any(e => e.id == id);
        }
    }
}
