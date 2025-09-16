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
using ApiAll.Model.hospital.dolg;

namespace ApiAll.Controllers.hospital
{

    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalPatientDolgController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalPatientDolgController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalPatientDolg
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalPatientDolg>>> GetHospitalPatientDolg()
        {
            return await _context.HospitalPatientDolg.ToListAsync();
        }


        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalPatientDolg> itemList = await _context.HospitalPatientDolg
                .Where(p => p.real_qty > 0)
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalPatientDolg>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalPatientDolg.Where(p => p.real_qty > 0).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatientId")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatientId([FromQuery] int page, [FromQuery] int size,[FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalPatientDolg> itemList = await _context.HospitalPatientDolg
                .Where(p => p.real_qty > 0 && p.PatientsId == patient_id)
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalPatientDolg>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalPatientDolg.Where(p => p.real_qty > 0 && p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByBeatweenDateTime")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByBeatweenDateTime([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime begin_date_time, [FromQuery] DateTime end_date_time)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalPatientDolg> itemList = await _context.HospitalPatientDolg
                .Where(p => p.real_qty > 0 && (p.created_date_time >= begin_date_time && p.created_date_time <= end_date_time))
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalPatientDolg>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalPatientDolg.Where(p => p.real_qty > 0 && (p.created_date_time >= begin_date_time && p.created_date_time <= end_date_time)).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationPatientDolgPaymentsListByBeatweenDateTime")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationPatientDolgPaymentsListByBeatweenDateTime([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime begin_date_time, [FromQuery] DateTime end_date_time)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalPatientDolgPaymentsHistory> itemList = await _context.HospitalPatientDolgPaymentsHistory
                .Where(p => p.active_status == true && (p.created_date_time >= begin_date_time && p.created_date_time <= end_date_time))
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalPatientDolgPaymentsHistory>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalPatientDolgPaymentsHistory.Where(p => p.active_status == true && (p.created_date_time >= begin_date_time && p.created_date_time <= end_date_time)).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationByPatientFio")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatientFio([FromQuery] int page, [FromQuery] int size, [FromQuery] String patient_name)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalPatientDolg> itemList = await _context.HospitalPatientDolg
                .Include(p => p.patients)
                .Where(p => p.real_qty > 0 && p.patients.FIO.ToLower().Contains(patient_name.ToLower()))
                .OrderByDescending(p => p.id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalPatientDolg>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalPatientDolg.Include(p => p.patients)
                .Where(p => p.real_qty > 0 && p.patients.FIO.ToLower().Contains(patient_name.ToLower())).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalPatientDolg/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalPatientDolg>> GetHospitalPatientDolg(long id)
        {
            var hospitalPatientDolg = await _context.HospitalPatientDolg.FindAsync(id);

            if (hospitalPatientDolg == null)
            {
                return NotFound();
            }

            return hospitalPatientDolg;
        }


        [HttpGet("getHospitalPatientDolgFullInfoitemsList")]
        public async Task<ActionResult<IEnumerable<HospitalPatientDolgItem>>> getHospitalPatientDolgFullInfoitemsList([FromQuery]long hospital_dolg_id)
        {
            var hospitalPatientDolgItem = await _context.HospitalPatientDolgItem.
                Where(p => p.HospitalPatientDolgid == hospital_dolg_id)
                .Include(p =>p.patients)
                .Include(p => p.dolg)
                .ToListAsync();

            if (hospitalPatientDolgItem == null)
            {
                return NotFound();
            }

            return hospitalPatientDolgItem;
        }


        [HttpGet("payDolgByIdAndSumm")]
        public async Task<ActionResult<HospitalPatientDolg>> payDolgById([FromQuery]long hospital_patient_dolg_id,[FromQuery] long dolg_summ,[FromQuery] long auth_id,[FromQuery] bool card_status)
        {
            var hospitalPatientDolg = await _context.HospitalPatientDolg.FindAsync(hospital_patient_dolg_id);

            if (hospitalPatientDolg == null)
            {
                return NotFound();
            }
            Patients patients = await _context.Patients.FindAsync(hospitalPatientDolg.PatientsId);
            if (hospitalPatientDolg.real_qty < dolg_summ) {
                return NotFound("Сумма больше, чем кредит");
            }

            List<HospitalDefaultSettings> defaultSettingList = await _context.HospitalDefaultSettings
                .Include(p => p.contragent)
                .Include(p => p.serviceType)
                .ToListAsync();
            if (defaultSettingList == null || defaultSettingList.Count == 0)
            {
                return NotFound("Настройки не найдены");
            }

            HospitalDefaultSettings hospitalDefaultSettings = defaultSettingList.First();

            Payments payments = new Payments();
            payments.ActiveStatus = true;
            payments.Name = "Долг";
            payments.ServiceName = hospitalDefaultSettings.serviceType.Name;
            payments.PatientName = patients.FIO;
            payments.ServiceTypeId = hospitalDefaultSettings.ServiceTypeId;
            payments.Summ = dolg_summ;
            payments.ReserveSumm = dolg_summ;
            if (card_status) {
                payments.PaymentInCash = 0;
                payments.PaymentInCard = dolg_summ;
            }
            else {
                payments.PaymentInCash = dolg_summ;
                payments.PaymentInCard = 0;
            }

            payments.PatientsId = hospitalPatientDolg.PatientsId;

            payments.Finish = true;
            payments.AuthorizationId = auth_id;
            payments.ContragentId = hospitalDefaultSettings.ContragentId;
            payments.FinishPayment = true;
            payments.acceptanceDateTime = DateTime.Now;
            payments.creatorAuthId = auth_id;


            hospitalPatientDolg.real_qty = hospitalPatientDolg.real_qty - dolg_summ;

            //update dolg
            _context.HospitalPatientDolg.Update(hospitalPatientDolg);
            await _context.SaveChangesAsync();


            //add payment
            _context.payments.Update(payments);
            await _context.SaveChangesAsync();


            //create item for history
            HospitalPatientDolgPaymentsHistory dolgPaymentsHistory = new HospitalPatientDolgPaymentsHistory();
            dolgPaymentsHistory.active_status = true;
            dolgPaymentsHistory.AuthorizationId = auth_id;
            dolgPaymentsHistory.PatientsId = hospitalPatientDolg.PatientsId;
            dolgPaymentsHistory.card_or_credit = card_status;
            dolgPaymentsHistory.summ = dolg_summ;

            // add history
            _context.HospitalPatientDolgPaymentsHistory.Update(dolgPaymentsHistory);
            await _context.SaveChangesAsync();

            return hospitalPatientDolg;
        }

        // PUT: api/HospitalPatientDolg/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalPatientDolg(long id, HospitalPatientDolg hospitalPatientDolg)
        {
            if (id != hospitalPatientDolg.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalPatientDolg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalPatientDolgExists(id))
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

        // POST: api/HospitalPatientDolg
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalPatientDolg>> PostHospitalPatientDolg(HospitalPatientDolg hospitalPatientDolg)
        {
            _context.HospitalPatientDolg.Update(hospitalPatientDolg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalPatientDolg", new { id = hospitalPatientDolg.id }, hospitalPatientDolg);
        }

        // DELETE: api/HospitalPatientDolg/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalPatientDolg>> DeleteHospitalPatientDolg(long id)
        {
            var hospitalPatientDolg = await _context.HospitalPatientDolg.FindAsync(id);
            if (hospitalPatientDolg == null)
            {
                return NotFound();
            }

            _context.HospitalPatientDolg.Remove(hospitalPatientDolg);
            await _context.SaveChangesAsync();

            return hospitalPatientDolg;
        }

        private bool HospitalPatientDolgExists(long id)
        {
            return _context.HospitalPatientDolg.Any(e => e.id == id);
        }
    }
}
