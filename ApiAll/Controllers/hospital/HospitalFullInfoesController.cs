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
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalFullInfoesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalFullInfoesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalFullInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalFullInfo>>> GetHospitalFullInfo()
        {
            return await _context.HospitalFullInfo.ToListAsync();
        }

        // GET: api/HospitalFullInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalFullInfo>> GetHospitalFullInfo(long id)
        {
            var hospitalFullInfo = await _context.HospitalFullInfo.FindAsync(id);

            if (hospitalFullInfo == null)
            {
                return NotFound();
            }

            
            return hospitalFullInfo;
        }

        // PUT: api/HospitalFullInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalFullInfo(long id, HospitalFullInfo hospitalFullInfo)
        {
            if (id != hospitalFullInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalFullInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalFullInfoExists(id))
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

        // POST: api/HospitalFullInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalFullInfo>> PostHospitalFullInfo(HospitalFullInfo hospitalFullInfo)
        {
            if(hospitalFullInfo.Id == 0){

                List<HospitalFullInfo> hospitalFullInfoList = await _context.HospitalFullInfo.ToListAsync();
                foreach (HospitalFullInfo item in hospitalFullInfoList)
                {
                    try
                    {
                        _context.HospitalFullInfo.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception)
                    {
                      
                    }
                }

            }


            _context.HospitalFullInfo.Update(hospitalFullInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalFullInfo", new { id = hospitalFullInfo.Id }, hospitalFullInfo);
        }

        // DELETE: api/HospitalFullInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalFullInfo>> DeleteHospitalFullInfo(long id)
        {
            var hospitalFullInfo = await _context.HospitalFullInfo.FindAsync(id);
            if (hospitalFullInfo == null)
            {
                return NotFound();
            }

            _context.HospitalFullInfo.Remove(hospitalFullInfo);
            await _context.SaveChangesAsync();

            return hospitalFullInfo;
        }

        private bool HospitalFullInfoExists(long id)
        {
            return _context.HospitalFullInfo.Any(e => e.Id == id);
        }
    }
}
