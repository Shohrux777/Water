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
    public class CompaniesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CompaniesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> Getcompanies()
        {
            return await _context.companies.OrderByDescending(p => p.Id).ToListAsync();
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<TexPaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<Company> itemList = await _context.companies
                .OrderByDescending(p => p.Id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<Company>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.companies.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        [HttpGet("getClientCompanyList")]
        public async Task<ActionResult<IEnumerable<Company>>> getClientCompanyList()
        {
            return await _context.companies.Where(c => c.client == true).ToListAsync();
        }

        [HttpGet("getPostafshikCompanyList")]
        public async Task<ActionResult<IEnumerable<Company>>> getPostafshikCompanyList()
        {
            return await _context.companies.Where(c => c.supplier == true).ToListAsync();
        }

        [HttpGet("getFilialCompanyList")]
        public async Task<ActionResult<IEnumerable<Company>>> getFilialCompanyList()
        {
            return await _context.companies.Where(c => c.maincompany == true).ToListAsync();
        }

        [HttpGet("getMainCompanyList")]
        public async Task<ActionResult<IEnumerable<Company>>> getMainCompanyList()
        {
            return await _context.companies.Where(c => c.maincompany == false && c.supplier == false && c.client == false).ToListAsync();
        }


        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(long id)
        {
            var company = await _context.companies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(long id, Company company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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

        // POST: api/Companies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
       [HttpGet("addUpdateCompany")]
        public async Task<ActionResult<Company>> AddOrUpdateCompany([FromQuery] long Id, [FromQuery] String companyName, [FromQuery] String phoneNumber, [FromQuery] String address, [FromQuery] Boolean client, [FromQuery] Boolean supplier, [FromQuery] Boolean maincompany)
        {
            
            Company company = new Company();
            try
            {
                company.ActiveStatus = true;
                company.Id = Id;
                company.Name = companyName;
                company.client = client;
                company.supplier = supplier;
                company.maincompany = maincompany;
                company.Note = String.Empty;
                company.PhoneNumber = phoneNumber;
                company.Address = address;
                _context.companies.Update(company);
                await _context.SaveChangesAsync();

            }
            catch (Exception) { 
            }
            return company;
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Company>> DeleteCompany(long id)
        {
            var company = await _context.companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.companies.Remove(company);
            await _context.SaveChangesAsync();

            return company;
        }

        private bool CompanyExists(long id)
        {
            return _context.companies.Any(e => e.Id == id);
        }
    }
}
