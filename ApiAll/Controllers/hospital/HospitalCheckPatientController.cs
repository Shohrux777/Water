using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;
using ApiAll.Model;

namespace ApiAll.Controllers.hospital
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalCheckPatientController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalCheckPatientController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalCheckPatient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalCheckPatient>>> GetHospitalCheckPatient()
        {
            return await _context.HospitalCheckPatient.ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalCheckPatient> itemList = await _context.HospitalCheckPatient
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalCheckPatient>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalCheckPatient.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByDateTime")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByDateTime([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime begin_date, [FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalCheckPatient> itemList = await _context.HospitalCheckPatient
                .Where(p => p.active_status == true && (p.created_date_time >= begin_date && p.created_date_time <= end_date))
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalCheckPatient>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalCheckPatient
                .Where(p => p.active_status == true && (p.created_date_time >= begin_date && p.created_date_time <= end_date)).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }



        [HttpGet("getPaginationByDateTimeAndPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByDateTimeAndPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime begin_date, [FromQuery] DateTime end_date, [FromQuery]long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalCheckPatient> itemList = await _context.HospitalCheckPatient
                .Where(p => p.active_status == true && p.PatientsId == patient_id && (p.created_date_time >= begin_date && p.created_date_time <= end_date))
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalCheckPatient>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalCheckPatient
                .Where(p => p.active_status == true && p.PatientsId == patient_id && (p.created_date_time >= begin_date && p.created_date_time <= end_date)).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByDateTimeAndDoctorAuthId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByDateTimeAndDoctorAuthId([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime begin_date, [FromQuery] DateTime end_date, [FromQuery] long auth_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalCheckPatient> itemList = await _context.HospitalCheckPatient
                .Where(p => p.active_status == true && p.auth_id == auth_id && (p.created_date_time >= begin_date && p.created_date_time <= end_date))
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalCheckPatient>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalCheckPatient
                .Where(p => p.active_status == true && p.auth_id == auth_id && (p.created_date_time >= begin_date && p.created_date_time <= end_date)).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalCheckPatient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalCheckPatient>> GetHospitalCheckPatient(long id)
        {
            var hospitalCheckPatient = await _context.HospitalCheckPatient.FindAsync(id);

            if (hospitalCheckPatient == null)
            {
                return NotFound();
            }

            List<long> payments_ids_list = hospitalCheckPatient.payments_ids_list;
            List<Payments> payed = new List<Payments>();
            List<Payments> unpayed = new List<Payments>();
            List<Payments> allunorpayed = new List<Payments>();
            foreach (long payment_id in payments_ids_list) { 
               Payments payments = await _context.payments.FindAsync(payment_id);
                if (payments != null) {
                    if (payments.FinishPayment == true)
                    {
                        payed.Add(payments);
                    }
                    else {
                        unpayed.Add(payments);
                    }
                    allunorpayed.Add(payments);

                }

            }

            hospitalCheckPatient.payed_paymnets= payed;
            hospitalCheckPatient.unpayed_paymnets= unpayed;
            hospitalCheckPatient.allpayed_paymnets = allunorpayed;


            return hospitalCheckPatient;
        }

        // PUT: api/HospitalCheckPatient/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalCheckPatient(long id, HospitalCheckPatient hospitalCheckPatient)
        {
            if (id != hospitalCheckPatient.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalCheckPatient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalCheckPatientExists(id))
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

        // POST: api/HospitalCheckPatient
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalCheckPatient>> PostHospitalCheckPatient(HospitalCheckPatient hospitalCheckPatient)
        {
            _context.HospitalCheckPatient.Update(hospitalCheckPatient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalCheckPatient", new { id = hospitalCheckPatient.id }, hospitalCheckPatient);
        }

        // DELETE: api/HospitalCheckPatient/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalCheckPatient>> DeleteHospitalCheckPatient(long id)
        {
            var hospitalCheckPatient = await _context.HospitalCheckPatient.FindAsync(id);
            if (hospitalCheckPatient == null)
            {
                return NotFound();
            }

            _context.HospitalCheckPatient.Remove(hospitalCheckPatient);
            await _context.SaveChangesAsync();

            return hospitalCheckPatient;
        }

        private bool HospitalCheckPatientExists(long id)
        {
            return _context.HospitalCheckPatient.Any(e => e.id == id);
        }
    }
}
