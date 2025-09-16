using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAll.Contex;
using ApiAll.Model;
using ApiAll.Model.market;
using ApiAll.Model.tekistil;
using Newtonsoft.Json.Linq;

namespace ApiAll.Controllers
{
    [ApiExplorerSettings(GroupName = "v4")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UsersController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("getPagination")]
        public async Task<ActionResult<PaginationModel>> getPagination([FromQuery] int page, [FromQuery] int size)
        {

            List<Users> usersList = await _context.Users.OrderByDescending(p => p.Id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            foreach (Users user in usersList)
            {
                Department department = await _context.departments.FindAsync(user.DepartmenId);
                Rooms room = await _context.rooms.FindAsync(user.RoomId);
                Position position = await _context.positions.FindAsync(user.PositionId);
                List<Authorization> authorizationList = await _context.authorizations.Where(a => a.UsersId == user.Id).ToListAsync();
                if (authorizationList != null && authorizationList.Count() > 0)
                {
                    user.authorization = authorizationList.First();
                }
                user.department = department;
                user.position = position;
                user.rooms = room;

            }
            PaginationModel paginationModel = new PaginationModel();
            paginationModel.usersList = usersList;
            paginationModel.count = await _context.Users.CountAsync();
            return paginationModel;
        }

        [HttpGet("getPaginationUsers")]
        public async Task<ActionResult<TexPaginationModel>> getPaginationUsers([FromQuery] int page, [FromQuery] int size)
        {
            TexPaginationModel paginationModel = new TexPaginationModel();
            List<Users> itemList = await _context.Users
                .Include(p => p.department)
                .Include(p => p.position)
                .Include(p => p.rooms)
                .OrderByDescending(p => p.Id)
                .Skip(size * page).Take(size)
                .ToListAsync();
            if (itemList == null)
            {
                itemList = new List<Users>();
            }
            paginationModel.items_list = JArray.FromObject(itemList);
            paginationModel.items_count = await _context.Users.CountAsync();
            paginationModel.current_item_count = itemList.Count();
            paginationModel.current_page = page;
            return paginationModel;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            List<Users> usersList = await _context.Users.OrderByDescending(p => p.Id).Take(100).ToListAsync();
            foreach (Users user in usersList) {
                Department department = await _context.departments.FindAsync(user.DepartmenId);
                Rooms room = await _context.rooms.FindAsync(user.RoomId);
                Position position = await _context.positions.FindAsync(user.PositionId);
                List<Authorization> authorizationList = await _context.authorizations.Where( a => a.UsersId == user.Id).ToListAsync();
                if (authorizationList != null && authorizationList.Count() > 0) {
                    user.authorization = authorizationList.First();
                }

                user.department = department;
                user.position = position;
                user.rooms = room;

            }
            return usersList;
        }



        // GET: api/Users
        [HttpGet("searchUserByFIO")]
        public async Task<ActionResult<IEnumerable<Users>>> searchUserByFIO([FromQuery] String FIO,int countResult)
        {
            List<Users> usersList = await _context.Users.Where(p => p.FIO.ToLower().Contains(FIO.ToLower())).OrderByDescending(p => p.Id).Take(countResult).ToListAsync();
            foreach (Users user in usersList)
            {
                Department department = await _context.departments.FindAsync(user.DepartmenId);
                Rooms room = await _context.rooms.FindAsync(user.RoomId);
                Position position = await _context.positions.FindAsync(user.PositionId);
                List<Authorization> authorizationList = await _context.authorizations.Where(a => a.UsersId == user.Id).ToListAsync();
                if (authorizationList != null && authorizationList.Count() > 0)
                {
                    user.authorization = authorizationList.First();
                }

                user.department = department;
                user.position = position;
                user.rooms = room;

            }
            return usersList;
        }



        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(long id)
        {
            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // GET: api/Users/5
        [HttpGet("addLimitAllByDepartmentIdAndSumm")]
        public async Task<ActionResult<MarketLimitAddedInfo>> addLimitAllByDepartmentIdAndSumm([FromQuery] long departmentId, [FromQuery] double summ)
        {
            var beginDateTime = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1).Date;
            var endDateTIme = beginDateTime.AddMonths(1).AddDays(-1).Date.AddHours(23.9999);

            List<Users> usersList = await _context.Users.Where(p => p.DepartmenId == departmentId).OrderByDescending(p => p.Id).ToListAsync();
            foreach (Users user in usersList)
            {
                Department department = await _context.departments.FindAsync(user.DepartmenId);
                Rooms room = await _context.rooms.FindAsync(user.RoomId);
                Position position = await _context.positions.FindAsync(user.PositionId);
                List<Authorization> authorizationList = await _context.authorizations.Where(a => a.UsersId == user.Id).ToListAsync();
                if (authorizationList != null && authorizationList.Count() > 0)
                {
                    user.authorization = authorizationList.First();
                }
                user.department = department;
                user.position = position;
                user.rooms = room;

            }
            int countUpdatedUsers = 0;
            foreach (Users item in usersList) {
                if (item.authorization != null && item.authorization.Id > 0)
                {
                    countUpdatedUsers++;
                    List<MarketAuthLimitByMoney> limitByMoneyList = await _context.MarketAuthLimitByMoney.Where(p => p.AuthorizationId == item.authorization.Id).ToListAsync();
                    if (limitByMoneyList != null && limitByMoneyList.Count > 0) {
                        _context.MarketAuthLimitByMoney.RemoveRange(limitByMoneyList);
                        await _context.SaveChangesAsync();
                    }

                    MarketAuthLimitByMoney authLimitByMoney = new MarketAuthLimitByMoney();
                    authLimitByMoney.ActiveStatus = true;
                    authLimitByMoney.beginDateTime = beginDateTime;
                    authLimitByMoney.endDateTime = endDateTIme;
                    authLimitByMoney.AuthorizationId = item.authorization.Id;
                    authLimitByMoney.limitFinished = false;
                    authLimitByMoney.realSumm = summ;
                    authLimitByMoney.reservedSumm = summ;
                    _context.MarketAuthLimitByMoney.Update(authLimitByMoney);
                    await _context.SaveChangesAsync();
                }
            }
            MarketLimitAddedInfo info = new MarketLimitAddedInfo();
            info.beginDate = beginDateTime;
            info.endDate = endDateTIme;
            info.updatedUsersCount = countUpdatedUsers;


            return info;
        }

        [HttpGet("getUserByPhoneNumber")]
        public async Task<ActionResult<Users>> getUserByPhoneNumber([FromQuery] String phoneNumber)
        {
            List<Users> userList = await _context.Users.Where(u => u.PhoneNumber == phoneNumber).ToListAsync();
            if (userList != null && userList.Count > 0) {
                return userList.SingleOrDefault();
            }
            return new Users();
        }

        [HttpGet("getUserByChatId")]
        public async Task<ActionResult<Users>> getUserByChatId([FromQuery] long chatId)
        {
            List<Users> userList = await _context.Users.Where(u => u.userRegistratedBotId == chatId).ToListAsync();
            if (userList != null && userList.Count > 0)
            {
                return userList.SingleOrDefault();
            }
            return new Users();
        }

        [HttpGet("updateUserChatId")]
        public async Task<ActionResult<Users>> updateUserChatId([FromQuery] long userId, [FromQuery] long chatId)
        {
            Users users = await _context.Users.FindAsync(userId);
            users.userRegistratedBotId = chatId;
            _context.Users.Update(users);
            await _context.SaveChangesAsync();
            return users;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(long id, Users users)
        {
            if (id != users.Id)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            bool autoCreatePassword = false;
            if (users != null && users.Id  == 0 && users.jailPerson != null && users.jailPerson  == true) {
                //auto add auth 
                autoCreatePassword = true;
            }

            _context.Users.Update(users);
            await _context.SaveChangesAsync();

            if (autoCreatePassword) {
                Authorization authorization = new Authorization();
                Department department = await _context.departments.FindAsync(users.DepartmenId);
                authorization.CompanyId = department.CompanyId;
                authorization.UserType = 5;
                authorization.ActiveStatus = true;
                authorization.Login = users.FIO;
                String passwordStr = users.Id.ToString();
                String companyIdStr = department.CompanyId.ToString();
                String defaultStr = ""; 
                int lengtPass = passwordStr.Length + companyIdStr.Length;
                for (int j = 0; j < 4-lengtPass; j++) {
                    defaultStr = defaultStr + "0";
                }

                authorization.Password = department.CompanyId.ToString()+ defaultStr + passwordStr;
                authorization.UsersId = users.Id;
                _context.authorizations.Update(authorization);
                await _context.SaveChangesAsync();
                users.authorization = authorization;

            }

            return users;
        }

        [HttpGet("addUser")]
        public async Task<ActionResult<Users>> AddUser(
            [FromQuery] long Id,
            [FromQuery] String fio, 
            [FromQuery] String phoneNumber,
            [FromQuery] String image,
            [FromQuery] long roomId,
            [FromQuery] long departmentId,
            [FromQuery] int PolType,
            [FromQuery] long positionId)
        {

            Users users = new Users();
            users.ActiveStatus = true;
            users.Id = Id;
            users.FIO = fio;
            users.PhoneNumber = phoneNumber;
            users.Image = image;
            users.RoomId = roomId;
            users.DepartmenId = departmentId;
            users.PolType = PolType;
            users.PositionId = positionId;

            _context.Users.Update(users);
            await _context.SaveChangesAsync();

            return users;
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUsers(long id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return users;
        }

        private bool UsersExists(long id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
