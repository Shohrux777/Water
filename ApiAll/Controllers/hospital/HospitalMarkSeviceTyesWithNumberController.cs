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
    public class HospitalMarkSeviceTyesWithNumberController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalMarkSeviceTyesWithNumberController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalMarkSeviceTyesWithNumber> itemList = await _context.HospitalMarkSeviceTyesWithNumber
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalMarkSeviceTyesWithNumber>();
            }

            foreach (HospitalMarkSeviceTyesWithNumber item_main in itemList)
            {
                List<Payments> payments_list_fake = new List<Payments>();

                List<ServiceType> serviece_types_fake = new List<ServiceType>();

                foreach (long paymnets_id in item_main.payments_list)
                {
                    var item = await _context.payments.FindAsync(paymnets_id);
                    if (item != null)
                    {
                        payments_list_fake.Add(item);
                    }

                }

                foreach (long service_type_id in item_main.serviece_types)
                {
                    var item = await _context.serviceTypes.FindAsync(service_type_id);
                    if (item != null)
                    {
                        serviece_types_fake.Add(item);
                    }

                }

                item_main.payments_list_fake = payments_list_fake;
                item_main.serviece_types_fake = serviece_types_fake;
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalMarkSeviceTyesWithNumber.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationWithBeginEndTime")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationWithBeginEndTime([FromQuery] int page, [FromQuery] int size,[FromQuery] DateTime begin_date, [FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalMarkSeviceTyesWithNumber> itemList = await _context.HospitalMarkSeviceTyesWithNumber
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.created_date_time >= begin_date && p.created_date_time <= end_date)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalMarkSeviceTyesWithNumber>();
            }

            foreach (HospitalMarkSeviceTyesWithNumber item_main in itemList)
            {
                List<Payments> payments_list_fake = new List<Payments>();

                List<ServiceType> serviece_types_fake = new List<ServiceType>();

                foreach (long paymnets_id in item_main.payments_list)
                {
                    var item = await _context.payments.FindAsync(paymnets_id);
                    if (item != null)
                    {
                        payments_list_fake.Add(item);
                    }

                }

                foreach (long service_type_id in item_main.serviece_types)
                {
                    var item = await _context.serviceTypes.FindAsync(service_type_id);
                    if (item != null)
                    {
                        serviece_types_fake.Add(item);
                    }

                }

                item_main.payments_list_fake = payments_list_fake;
                item_main.serviece_types_fake = serviece_types_fake;
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalMarkSeviceTyesWithNumber.Where(p => p.created_date_time >= begin_date && p.created_date_time <= end_date).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationNotFinishedWithBeginAndEndTime")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationNotFinished([FromQuery] int page, [FromQuery] int size, [FromQuery] DateTime begin_date, [FromQuery] DateTime end_date)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalMarkSeviceTyesWithNumber> itemList = await _context.HospitalMarkSeviceTyesWithNumber
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.finish_all_chekings == false && (p.created_date_time >= begin_date && p.created_date_time <= end_date))
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalMarkSeviceTyesWithNumber>();
            }

            foreach (HospitalMarkSeviceTyesWithNumber item_main in itemList) {
                List<Payments> payments_list_fake = new List<Payments>();

                List<ServiceType> serviece_types_fake = new List<ServiceType>();

                foreach (long paymnets_id in item_main.payments_list)
                {
                    var item = await _context.payments.FindAsync(paymnets_id);
                    if (item != null)
                    {
                        payments_list_fake.Add(item);
                    }

                }

                foreach (long service_type_id in item_main.serviece_types)
                {
                    var item = await _context.serviceTypes.FindAsync(service_type_id);
                    if (item != null)
                    {
                        serviece_types_fake.Add(item);
                    }

                }

                item_main.payments_list_fake = payments_list_fake;
                item_main.serviece_types_fake = serviece_types_fake;
            }



            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalMarkSeviceTyesWithNumber.Where(p => p.finish_all_chekings == false && (p.created_date_time >= begin_date && p.created_date_time <= end_date)).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatient")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatient([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalMarkSeviceTyesWithNumber> itemList = await _context.HospitalMarkSeviceTyesWithNumber
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalMarkSeviceTyesWithNumber>();
            }

            foreach (HospitalMarkSeviceTyesWithNumber item_main in itemList)
            {
                List<Payments> payments_list_fake = new List<Payments>();

                List<ServiceType> serviece_types_fake = new List<ServiceType>();

                foreach (long paymnets_id in item_main.payments_list)
                {
                    var item = await _context.payments.FindAsync(paymnets_id);
                    if (item != null)
                    {
                        payments_list_fake.Add(item);
                    }

                }

                foreach (long service_type_id in item_main.serviece_types)
                {
                    var item = await _context.serviceTypes.FindAsync(service_type_id);
                    if (item != null)
                    {
                        serviece_types_fake.Add(item);
                    }

                }

                item_main.payments_list_fake = payments_list_fake;
                item_main.serviece_types_fake = serviece_types_fake;
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalMarkSeviceTyesWithNumber
                .Where(p => p.PatientsId == patient_id).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }


        [HttpGet("getPaginationNotFinished")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationNotFinished([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalMarkSeviceTyesWithNumber> itemList = await _context.HospitalMarkSeviceTyesWithNumber
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.finish_all_chekings == false)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalMarkSeviceTyesWithNumber>();
            }

            foreach (HospitalMarkSeviceTyesWithNumber item_main in itemList)
            {
                List<Payments> payments_list_fake = new List<Payments>();

                List<ServiceType> serviece_types_fake = new List<ServiceType>();

                foreach (long paymnets_id in item_main.payments_list)
                {
                    var item = await _context.payments.FindAsync(paymnets_id);
                    if (item != null)
                    {
                        payments_list_fake.Add(item);
                    }

                }

                foreach (long service_type_id in item_main.serviece_types)
                {
                    var item = await _context.serviceTypes.FindAsync(service_type_id);
                    if (item != null)
                    {
                        serviece_types_fake.Add(item);
                    }

                }

                item_main.payments_list_fake = payments_list_fake;
                item_main.serviece_types_fake = serviece_types_fake;
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalMarkSeviceTyesWithNumber.Where(p => p.finish_all_chekings == false).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getPaginationByPatientNotFinished")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationByPatientNotFinished([FromQuery] int page, [FromQuery] int size, [FromQuery] long patient_id)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalMarkSeviceTyesWithNumber> itemList = await _context.HospitalMarkSeviceTyesWithNumber
                .OrderByDescending(p => p.id)
                .Include(p => p.patients)
                .Where(p => p.PatientsId == patient_id && p.finish_all_chekings == false)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalMarkSeviceTyesWithNumber>();
            }
            foreach (HospitalMarkSeviceTyesWithNumber item_main in itemList)
            {
                List<Payments> payments_list_fake = new List<Payments>();

                List<ServiceType> serviece_types_fake = new List<ServiceType>();

                foreach (long paymnets_id in item_main.payments_list)
                {
                    var item = await _context.payments.FindAsync(paymnets_id);
                    if (item != null)
                    {
                        payments_list_fake.Add(item);
                    }

                }

                foreach (long service_type_id in item_main.serviece_types)
                {
                    var item = await _context.serviceTypes.FindAsync(service_type_id);
                    if (item != null)
                    {
                        serviece_types_fake.Add(item);
                    }

                }

                item_main.payments_list_fake = payments_list_fake;
                item_main.serviece_types_fake = serviece_types_fake;
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalMarkSeviceTyesWithNumber
                .Where(p => p.PatientsId == patient_id && p.finish_all_chekings == false).CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalMarkSeviceTyesWithNumber
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalMarkSeviceTyesWithNumber>>> GetHospitalMarkSeviceTyesWithNumber()
        {
            return await _context.HospitalMarkSeviceTyesWithNumber.ToListAsync();
        }

        // GET: api/HospitalMarkSeviceTyesWithNumber/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalMarkSeviceTyesWithNumber>> GetHospitalMarkSeviceTyesWithNumber(long id)
        {
            var hospitalMarkSeviceTyesWithNumber = await _context.HospitalMarkSeviceTyesWithNumber.FindAsync(id);

            if (hospitalMarkSeviceTyesWithNumber == null)
            {
                return NotFound();
            }

            return hospitalMarkSeviceTyesWithNumber;
        }

        [HttpGet("getFullInfoById")]
        public async Task<ActionResult<HospitalMarkSeviceTyesWithNumber>> getFullInfoById([FromQuery]long id)
        {
            var hospitalMarkSeviceTyesWithNumber = await _context.HospitalMarkSeviceTyesWithNumber
                .Include(p => p.patients)
                .Where(p => p.id == id).ToListAsync();

            if (hospitalMarkSeviceTyesWithNumber == null || hospitalMarkSeviceTyesWithNumber.Count == 0)
            {
                return NotFound();
            }



             List<Payments> payments_list_fake = new List<Payments>();

             List<ServiceType> serviece_types_fake = new List<ServiceType>();

            foreach (long paymnets_id in hospitalMarkSeviceTyesWithNumber.First().payments_list) {
                var item = await _context.payments.FindAsync(paymnets_id);
                if (item != null) {
                    payments_list_fake.Add(item);
                }
                
            }

            foreach (long service_type_id in hospitalMarkSeviceTyesWithNumber.First().serviece_types)
            {
                var item = await _context.serviceTypes.FindAsync(service_type_id);
                if (item != null)
                {
                    serviece_types_fake.Add(item);
                }

            }

            hospitalMarkSeviceTyesWithNumber.First().payments_list_fake = payments_list_fake;
            hospitalMarkSeviceTyesWithNumber.First().serviece_types_fake = serviece_types_fake;

            return hospitalMarkSeviceTyesWithNumber.First();
        }

        [HttpGet("getCheckedStatusAnaliz")]
        public async Task<ActionResult<HospitalMarkSeviceTyesWithNumber>> getCheckedStatusAnaliz([FromQuery]long id)
        {
            var hospitalMarkSeviceTyesWithNumber = await _context.HospitalMarkSeviceTyesWithNumber.FindAsync(id);

            if (hospitalMarkSeviceTyesWithNumber == null)
            {
                return NotFound();
            }
            hospitalMarkSeviceTyesWithNumber.finish_all_chekings = true;

            _context.HospitalMarkSeviceTyesWithNumber.Update(hospitalMarkSeviceTyesWithNumber);
            await _context.SaveChangesAsync();

            return hospitalMarkSeviceTyesWithNumber;
        }

        // PUT: api/HospitalMarkSeviceTyesWithNumber/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalMarkSeviceTyesWithNumber(long id, HospitalMarkSeviceTyesWithNumber hospitalMarkSeviceTyesWithNumber)
        {
            if (id != hospitalMarkSeviceTyesWithNumber.id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalMarkSeviceTyesWithNumber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalMarkSeviceTyesWithNumberExists(id))
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

        // POST: api/HospitalMarkSeviceTyesWithNumber
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalMarkSeviceTyesWithNumber>> PostHospitalMarkSeviceTyesWithNumber(HospitalMarkSeviceTyesWithNumber hospitalMarkSeviceTyesWithNumber)
        {
            _context.HospitalMarkSeviceTyesWithNumber.Update(hospitalMarkSeviceTyesWithNumber);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalMarkSeviceTyesWithNumber", new { id = hospitalMarkSeviceTyesWithNumber.id }, hospitalMarkSeviceTyesWithNumber);
        }

        // DELETE: api/HospitalMarkSeviceTyesWithNumber/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalMarkSeviceTyesWithNumber>> DeleteHospitalMarkSeviceTyesWithNumber(long id)
        {
            var hospitalMarkSeviceTyesWithNumber = await _context.HospitalMarkSeviceTyesWithNumber.FindAsync(id);
            if (hospitalMarkSeviceTyesWithNumber == null)
            {
                return NotFound();
            }

            _context.HospitalMarkSeviceTyesWithNumber.Remove(hospitalMarkSeviceTyesWithNumber);
            await _context.SaveChangesAsync();

            return hospitalMarkSeviceTyesWithNumber;
        }

        private bool HospitalMarkSeviceTyesWithNumberExists(long id)
        {
            return _context.HospitalMarkSeviceTyesWithNumber.Any(e => e.id == id);
        }
    }
}
