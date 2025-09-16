using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model.hospital.bron;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers.hospital.bron
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalOchredsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalOchredsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalOchreds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalOchred>>> GetHospitalOchred()
        {
            return await _context.HospitalOchred.ToListAsync();
        }
        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalOchred> categoryList = await _context.HospitalOchred.Where(p => p.active_status == true)
                .Include(p => p.users)
                .Include(p => p.patients)
                .Include(p => p.authorization)
                .Skip(page * size).Take(size).OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<HospitalOchred>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.HospitalOchred.Where(p => p.active_status == true).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByDoctorList")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByDoctorList(
            [FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime begin_date, [FromQuery] DateTime end_date)
        {
            String beginDateStr = begin_date.ToString("yyyy-MM-dd hh:mm:ss");
            String endDateStr = end_date.ToString("yyyy-MM-dd hh:mm:ss");
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalOchredByDocotors> categoryList = await _context.HospitalOchredByDocotors
                .FromSqlRaw("  " +
                "SELECT  \"UsersId\"   "+
                  "FROM public.hospital_ochred  " +
                  "WHERE accepted_status = false AND " +
                  "reg_date_ochred BETWEEN '"+ beginDateStr + "' AND '"+ endDateStr + "'  "+
                  "GROUP BY \"UsersId\" ORDER BY \"UsersId\" ASC")
                .Skip(page * size).Take(size).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<HospitalOchredByDocotors>();
            }

            foreach (HospitalOchredByDocotors item in categoryList) {
                item.users = await _context.Users.FindAsync(item.UsersId);
                item.ochred_list = await _context.HospitalOchred
                    .Where( p=> p.accepted_status == false &&
                    (p.reg_date_ochred >= begin_date && p.reg_date_ochred <= end_date) && p.UsersId == item.UsersId)
                    .Include(p => p.users)
                    .Include(p => p.patients)
                    .Include(p => p.authorization)
                    .OrderBy(p => p.id)
                    .ToListAsync();
            }

            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = categoryList.Count();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("acceptGetPaginationByDoktorIdAndPatientIdDates")]
        public async Task<ActionResult<TexPaginationModel>> acceptGetPaginationByDoktorIdAndPatientIdDates(
        [FromQuery] int page,
        [FromQuery] int size,
        [FromQuery] long user_id,
        [FromQuery] long patient_id,
        [FromQuery] DateTime b_date,
        [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalOchred> categoryList = await _context.HospitalOchred
                .Where(p => p.active_status == true && p.PatientsId == patient_id && p.accepted_status == false && p.UsersId == user_id && (p.reg_date_ochred >= b_date && p.reg_date_ochred <= e_date))
                .Include(p => p.users)
                .Include(p => p.patients)
                .Include(p => p.authorization)
                .Skip(page * size).Take(size).OrderBy(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<HospitalOchred>();
            }

            foreach (HospitalOchred item in categoryList) {
                item.accepted_status = true;
            }

            _context.HospitalOchred.UpdateRange(categoryList);
            await _context.SaveChangesAsync();


            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.HospitalOchred.Where(p => p.active_status == true && p.PatientsId == patient_id && p.accepted_status == false && p.UsersId == user_id && (p.reg_date_ochred >= b_date && p.reg_date_ochred <= e_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationByDoktorIdAndPatientIdDates")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByDoktorIdAndPatientIdDates(
        [FromQuery] int page,
        [FromQuery] int size,
        [FromQuery] long user_id,
        [FromQuery] long patient_id,
        [FromQuery] DateTime b_date,
        [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalOchred> categoryList = await _context.HospitalOchred
                .Where(p => p.active_status == true && p.PatientsId == patient_id && p.accepted_status == false && p.UsersId == user_id && (p.reg_date_ochred >= b_date && p.reg_date_ochred <= e_date))
                .Include(p => p.users)
                .Include(p => p.patients)
                .Include(p => p.authorization)
                .Skip(page * size).Take(size).OrderBy(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<HospitalOchred>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.HospitalOchred.Where(p => p.active_status == true && p.PatientsId == patient_id && p.accepted_status == false && p.UsersId == user_id && (p.reg_date_ochred >= b_date && p.reg_date_ochred <= e_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByDoktorIdAndDates")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByDoktorIdAndDates(
            [FromQuery] int page,
            [FromQuery] int size,
            [FromQuery] long user_id,
            [FromQuery] DateTime b_date,
            [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalOchred> categoryList = await _context.HospitalOchred
                .Where(p => p.active_status == true && p.accepted_status == false && p.UsersId == user_id && (p.reg_date_ochred >= b_date && p.reg_date_ochred <= e_date))
                .Include(p => p.users)
                .Include(p => p.patients)
                .Include(p => p.authorization)
                .Skip(page * size).Take(size).OrderBy(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<HospitalOchred>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.HospitalOchred.Where(p => p.active_status == true && p.accepted_status == false && p.UsersId == user_id && (p.reg_date_ochred >= b_date && p.reg_date_ochred <= e_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByDoktorIdAndDatesAll")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByDoktorIdAndDatesAll(
            [FromQuery] int page,
            [FromQuery] int size,
            [FromQuery] long user_id,
            [FromQuery] long doctor_auth_id,
            [FromQuery] DateTime b_date,
            [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalOchred> categoryList = await _context.HospitalOchred
                .Where(p => p.active_status == true  && p.UsersId == user_id && (p.reg_date_ochred >= b_date && p.reg_date_ochred <= e_date))
                .Include(p => p.users)
                .Include(p => p.patients)
                .Include(p => p.authorization)
                .Skip(page * size).Take(size).OrderBy(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<HospitalOchred>();
            }

            foreach (HospitalOchred it in categoryList) {

                //tolanmaganlar
                it.payments_list = await _context.payments.Where(
                p => p.AuthorizationId == doctor_auth_id
                && p.FinishPayment == false
                && p.PatientsId == it.PatientsId
                && (p.PayedDate >= b_date && p.PayedDate <= e_date)).ToListAsync();

                //tolanganalr
                it.payments_list_payed = await _context.payments.Where(
                p => p.AuthorizationId == doctor_auth_id
                && p.FinishPayment == true
                && p.PatientsId == it.PatientsId
                && (p.PayedDate >= b_date && p.PayedDate <= e_date)).ToListAsync();


                //xammasi
                it.payments_list_all = await _context.payments.Where(
                p => p.AuthorizationId == doctor_auth_id
                && p.PatientsId == it.PatientsId
                && (p.PayedDate >= b_date && p.PayedDate <= e_date)).ToListAsync();

            }

            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.HospitalOchred.Where(p => p.active_status == true  && p.UsersId == user_id && (p.reg_date_ochred >= b_date && p.reg_date_ochred <= e_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByDoktorIdAndDatesOxirgisiniOlish")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByDoktorIdAndDatesOxirgisiniOlish(
        [FromQuery] long user_id,
        [FromQuery] DateTime b_date,
        [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalOchred> categoryList = await _context.HospitalOchred
                .Where(p => p.active_status == true  && p.UsersId == user_id && (p.reg_date_ochred >= b_date && p.reg_date_ochred <= e_date))
                .Include(p => p.users)
                .Include(p => p.patients)
                .Include(p => p.authorization)
                .OrderByDescending(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<HospitalOchred>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.HospitalOchred.Where(p => p.active_status == true  && p.UsersId == user_id && (p.reg_date_ochred >= b_date && p.reg_date_ochred <= e_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = 1;
            return paginationModel;
        }
        [HttpGet("getPaginationByDoktorIdAndDatesBirinchisiniOlish")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByDoktorIdAndDatesBirinchisiniOlish(
        [FromQuery] long user_id,
        [FromQuery] DateTime b_date,
        [FromQuery] DateTime e_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalOchred> categoryList = await _context.HospitalOchred
                .Where(p => p.active_status == true && p.accepted_status == false && p.UsersId == user_id && (p.reg_date_ochred >= b_date && p.reg_date_ochred <= e_date))
                .Include(p => p.users)
                .Include(p => p.patients)
                .Include(p => p.authorization)
                .OrderBy(p => p.id).ToListAsync();
            if (categoryList == null)
            {
                categoryList = new List<HospitalOchred>();
            }
            paginationModel.items_list = JArray.FromObject(categoryList);
            paginationModel.items_count = await _context.HospitalOchred.Where(p => p.active_status == true && p.accepted_status == false && p.UsersId == user_id && (p.reg_date_ochred >= b_date && p.reg_date_ochred <= e_date)).CountAsync();
            paginationModel.current_item_count = categoryList.Count();
            paginationModel.current_page = 1;
            return paginationModel;
        }

        // GET: api/HospitalOchreds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalOchred>> GetHospitalOchred(long id)
        {
            var hospitalOchred = await _context.HospitalOchred.FindAsync(id);

            if (hospitalOchred == null)
            {
                return NotFound();
            }

            return hospitalOchred;
        }

        [HttpGet("acceptKorilganBemordi")]
        public async Task<ActionResult<HospitalOchred>> acceptKorilganBemordi([FromQuery]long id)
        {
            var hospitalOchred = await _context.HospitalOchred.FindAsync(id);

            if (hospitalOchred == null)
            {
                return NotFound();
            }
            hospitalOchred.accepted_status = true;
            _context.HospitalOchred.Update(hospitalOchred);
            await _context.SaveChangesAsync();

            return hospitalOchred;
        }

        // PUT: api/HospitalOchreds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalOchred(long id, HospitalOchred hospitalOchred)
        {
            if (id != hospitalOchred.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalOchred).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalOchredExists(id))
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

        // POST: api/HospitalOchreds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalOchred>> PostHospitalOchred(HospitalOchred hospitalOchred)
        {
            _context.HospitalOchred.Update(hospitalOchred);
            await _context.SaveChangesAsync();

            hospitalOchred.authorization = await _context.authorizations.FindAsync(hospitalOchred.AuthorizationId);
            hospitalOchred.patients = await _context.Patients.FindAsync(hospitalOchred.PatientsId);
            hospitalOchred.users = await _context.Users.FindAsync(hospitalOchred.UsersId);

            return hospitalOchred;
        }

        // DELETE: api/HospitalOchreds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalOchred>> DeleteHospitalOchred(long id)
        {
            var hospitalOchred = await _context.HospitalOchred.FindAsync(id);
            if (hospitalOchred == null)
            {
                return NotFound();
            }

            _context.HospitalOchred.Remove(hospitalOchred);
            await _context.SaveChangesAsync();

            return hospitalOchred;
        }

        private bool HospitalOchredExists(long id)
        {
            return _context.HospitalOchred.Any(e => e.id == id);
        }
    }
}
