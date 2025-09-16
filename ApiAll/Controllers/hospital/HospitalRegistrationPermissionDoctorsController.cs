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
    public class HospitalRegistrationPermissionDoctorsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HospitalRegistrationPermissionDoctorsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HospitalRegistrationPermissionDoctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalRegistrationPermissionDoctors>>> GetHospitalRegistrationPermissionDoctors()
        {
            return await _context.HospitalRegistrationPermissionDoctors.OrderByDescending( p=> p.Id).ToListAsync();
        }
        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<HospitalRegistrationPermissionDoctors> itemList = await _context.HospitalRegistrationPermissionDoctors
                .Include(p => p.registraterAuth)
                .Include(p => p.doctorAuth)
                .OrderByDescending(p => p.Id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<HospitalRegistrationPermissionDoctors>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.HospitalRegistrationPermissionDoctors.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/HospitalRegistrationPermissionDoctors
        [HttpGet("getDoctorListByRegistratorAuthId")]
        public async Task<ActionResult<IEnumerable<HospitalRegistrationPermissionDoctors>>> getDoctorListByRegistratorAuthId([FromQuery] long registratorAuthId)
        {
            List< HospitalRegistrationPermissionDoctors > permissionDoctors = await _context.HospitalRegistrationPermissionDoctors
                .Where(p => p.registraterAuthId == registratorAuthId)
                .Include(p => p.doctorAuth).ThenInclude(a => a.users)
                .OrderByDescending(p => p.Id).ToListAsync();

            if (permissionDoctors != null && permissionDoctors.Count > 0) {

                foreach (HospitalRegistrationPermissionDoctors hospitalRegistration in permissionDoctors) {
                    Users users = await _context.Users.FindAsync(hospitalRegistration.doctorAuth.UsersId);
                    if (users != null) {
                        hospitalRegistration.user_name = users.FIO;
                        Position position = await _context.positions.FindAsync(users.PositionId);
                        if (position != null) {
                            hospitalRegistration.position_name = position.Name;
                        }
                        Department department = await _context.departments.FindAsync(users.DepartmenId);
                        if (department != null) {
                            hospitalRegistration.department_name = department.Name;
                        }
                    }

                }

            }
            return permissionDoctors;
        }

        // GET: api/HospitalRegistrationPermissionDoctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalRegistrationPermissionDoctors>> GetHospitalRegistrationPermissionDoctors(long id)
        {
            var hospitalRegistrationPermissionDoctors = await _context.HospitalRegistrationPermissionDoctors.FindAsync(id);

            if (hospitalRegistrationPermissionDoctors == null)
            {
                return NotFound();
            }

            return hospitalRegistrationPermissionDoctors;
        }

        // PUT: api/HospitalRegistrationPermissionDoctors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalRegistrationPermissionDoctors(long id, HospitalRegistrationPermissionDoctors hospitalRegistrationPermissionDoctors)
        {
            if (id != hospitalRegistrationPermissionDoctors.Id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalRegistrationPermissionDoctors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalRegistrationPermissionDoctorsExists(id))
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

        // POST: api/HospitalRegistrationPermissionDoctors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HospitalRegistrationPermissionDoctors>> PostHospitalRegistrationPermissionDoctors(HospitalRegistrationPermissionDoctors hospitalRegistrationPermissionDoctors)
        {
            _context.HospitalRegistrationPermissionDoctors.Update(hospitalRegistrationPermissionDoctors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalRegistrationPermissionDoctors", new { id = hospitalRegistrationPermissionDoctors.Id }, hospitalRegistrationPermissionDoctors);
        }

        // DELETE: api/HospitalRegistrationPermissionDoctors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalRegistrationPermissionDoctors>> DeleteHospitalRegistrationPermissionDoctors(long id)
        {
            var hospitalRegistrationPermissionDoctors = await _context.HospitalRegistrationPermissionDoctors.FindAsync(id);
            if (hospitalRegistrationPermissionDoctors == null)
            {
                return NotFound();
            }

            _context.HospitalRegistrationPermissionDoctors.Remove(hospitalRegistrationPermissionDoctors);
            await _context.SaveChangesAsync();

            return hospitalRegistrationPermissionDoctors;
        }

        private bool HospitalRegistrationPermissionDoctorsExists(long id)
        {
            return _context.HospitalRegistrationPermissionDoctors.Any(e => e.Id == id);
        }
    }
}
