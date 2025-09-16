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
    public class PatientsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PatientsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patients>>> GetPatients()
        {
            return await _context.Patients.OrderByDescending(p => p.Id).ToListAsync();
        }


        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<Patients> itemList = await _context.Patients
                .Include(p =>p.districts)
                .OrderByDescending(p => p.Id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<Patients>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.Patients.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getLastPatientsList")]
        public async Task<ActionResult<IEnumerable<Patients>>> getLastPatientsList()
        {
            return await _context.Patients.OrderByDescending(p => p.Id).Include(p => p.districts).Take(100).ToListAsync();
        }

        [HttpGet("getPatientLastRegistrationsList")]
        public async Task<ActionResult<IEnumerable<Patients>>> getPatientLastRegistrationsList()
        {
            return await _context.Patients.OrderByDescending(p => p.Id).Include( p=>p.districts).Take(100).ToListAsync();
        }

        [HttpGet("searchPatientsByFioList")]
        public async Task<ActionResult<IEnumerable<Patients>>> searchPatientsByFioList([FromQuery] String FIO)
        {
            if (FIO ==null || FIO.Trim().Length == 0) {
                return new List<Patients>();
            }
            return await _context.Patients.Where(p => p.FIO.ToLower().Contains(FIO.ToLower())).OrderByDescending(p => p.Id).Include( p => p.districts).Take(100).ToListAsync();
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patients>> GetPatients(long id)
        {
            var patients = await _context.Patients.
                Where(p => p.Id == id)
                .Include(p => p.districts)
                .ToListAsync();

            if (patients == null || patients.Count == 0)
            {
                return NotFound("Bemor topilmadi");
            }

            return patients.First();
        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatients(long id, Patients patients)
        {
            if (id != patients.Id)
            {
                return BadRequest();
            }

            _context.Entry(patients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientsExists(id))
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

        // POST: api/Patients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Patients>> PostPatients(Patients patients)
        {
            _context.Patients.Update(patients);
            await _context.SaveChangesAsync();

            return patients;
        }

        [HttpGet("addPatients")]
        public async Task<ActionResult<Patients>> addPatients(
                [FromQuery] long Id,
                [FromQuery] String FIO,
                [FromQuery] String PassportSerialNumber,
                [FromQuery] String PhoneNumber,
                [FromQuery] int PolType,
                [FromQuery] long DistrictsId,
                [FromQuery] String Address,
                [FromQuery] String WorkAddress,
                [FromQuery] DateTime UnregistratedDate,
                [FromQuery] DateTime BornDate,
                [FromQuery] String TreatmentPlaces,
                [FromQuery] String TreatmentPlacesCurrentPlaces,
                [FromQuery] String TreatmentPlacesOtherPlaces)
        {
            PhoneNumber = PhoneNumber.Trim();
            if (!PhoneNumber.Contains("+")) {
                PhoneNumber = "+" + PhoneNumber;
            }
            PhoneNumber = PhoneNumber.Trim();


            Patients patients = new Patients();
            patients.Id = Id;
            patients.ActiveStatus = true;
            patients.RegistratedDate = DateTime.Now;
            patients.FIO = FIO;
            patients.PassportSerialNumber = PassportSerialNumber;
            patients.PhoneNumber = PhoneNumber;
            patients.PolType = PolType;
            patients.Address = Address;
            patients.WorkAddress = WorkAddress;
            patients.TreatmentPlaces = TreatmentPlaces;
            patients.TreatmentPlacesCurrentPlaces = TreatmentPlacesCurrentPlaces;
            patients.TreatmentPlacesOtherPlaces = TreatmentPlacesOtherPlaces;
            patients.UnregistratedDate = UnregistratedDate;
            patients.BornDate = BornDate;
            patients.DistrictsId = DistrictsId;
            _context.Patients.Update(patients);
            await _context.SaveChangesAsync();

       
            return patients;
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patients>> DeletePatients(long id)
        {
            var patients = await _context.Patients.FindAsync(id);
            if (patients == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patients);
            await _context.SaveChangesAsync();

            return patients;
        }

        private bool PatientsExists(long id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }
    }
}
