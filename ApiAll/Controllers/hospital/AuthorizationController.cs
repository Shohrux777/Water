using ApiAll.Contex;
using ApiAll.Model;
using ApiAll.Repository.Interface;
using ApiAll.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiAll.Model.market;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private IBaseRepository<Authorization> auth { get; set; }
        private IAuthorizationService authorizationService { get; set; }
        private readonly ApplicationContext _context;
        public AuthorizationController(ApplicationContext context, IBaseRepository<Authorization> _auth,IAuthorizationService _authorizationService)
        {
            _context = context;
            auth = _auth;
            authorizationService = _authorizationService;

        }

        // GET: api/<AuthorizationController>
        [HttpGet]
        public  List<Authorization> GetAsync() {
            List<Authorization> authorizations = new List<Authorization>();
            try {
                authorizations = auth.GetAll();
                foreach (Authorization authorization in authorizations) {
                    Users users =  _context.Users.Find(authorization.UsersId);
                    Position position = _context.positions.Find(users.PositionId);
                    users.position = position;
                    authorization.users = users;

                }
                //authorizations = _context.authorizations.Select().ToList();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            return authorizations;
        }
        [HttpGet("getClientList")]
        public async Task<ActionResult<IEnumerable<Authorization>>> getClientList() {
            List<Authorization> authorizationList =  await _context.authorizations.Where( a => a.company.client == true).Include( a =>a.company).ToListAsync();
            if (authorizationList != null && authorizationList.Count > 0)
            {
                foreach (Authorization item in authorizationList) {
                    List<MarketClientInfo> marketClientInfoList = await _context.MarketClientInfo.Where(m => m.AuthorizationId == item.Id).ToListAsync();
                    if (marketClientInfoList != null && marketClientInfoList.Count > 0) {
                        item.ClientInfo = marketClientInfoList.First();
                    }
                }

            }
            return authorizationList;
        }


        [HttpGet("checkuser")]
        public Authorization Get([FromQuery] String password, [FromQuery] String login) {
            try
            {
                return authorizationService.checkLoginAndPassword(login, password);
            }
            catch(InvalidCastException)
            {
                return new Authorization();
            }
        }

        [HttpGet("checkJailuser")]
        public Authorization checkJailuser([FromQuery] String password)
        {
            try
            {
                return authorizationService.checkJailPassword( password);
            }
            catch (InvalidCastException)
            {
                return new Authorization();
            }
        }

        [HttpGet("addAuth")]
        public async Task<ActionResult<Authorization>> addAuth(
            [FromQuery] long Id,
            [FromQuery] String Login,
            [FromQuery] String Password,
            [FromQuery] long companyId,
            [FromQuery] long UsersId,
            [FromQuery] int UserType)
        {
            Authorization authorization = new Authorization();
            if (Id != 0) {
                authorization = await _context.authorizations.FindAsync(Id);
            }
            authorization.ActiveStatus = true;
            authorization.Id = Id;
            authorization.CompanyId = companyId;
            authorization.Password = Password; 
            authorization.Login = Login;
            authorization.UsersId = UsersId;
            authorization.UserType = UserType;
            List<Authorization> authorizationList = await _context.authorizations.Where(a => a.UsersId == UsersId).ToListAsync();
            if (Id == 0) { 
                if (authorizationList != null && authorizationList.Count > 0 )
                {
                    return new Authorization();
                }
            
            }
            _context.authorizations.Update(authorization);
            await _context.SaveChangesAsync();

            return authorization;
        }

        // GET api/<AuthorizationController>/5
        [HttpGet("{id}")]
        public Authorization Get(long id)
        {
            return auth.Get(id);
        }

        // POST api/<AuthorizationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<AuthorizationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthorizationController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            auth.Delete(id);
        }
    }
}
