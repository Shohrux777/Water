using ApiAll.Contex;
using ApiAll.Model;
using ApiAll.Repository.Interface;
using ApiAll.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Service
{
    public class AuthorizationService : IAuthorizationService
    {
        private IBaseRepository<Authorization> auth { get; set; }
        private readonly ApplicationContext _context;
        public AuthorizationService(ApplicationContext context, IBaseRepository<Authorization> _auth)
        {
            _context = context;
            auth = _auth;

        }
        public Authorization checkLoginAndPassword(string login, string password)
        {
            try
            {
                var auth = _context.authorizations.Where(a => a.Login == login && a.Password == password).FirstOrDefault();
                if (auth == null) {
                    return new Authorization();
                }
                auth.users = _context.Users.Find(auth.UsersId);
                return auth;
            }
            catch (InvalidCastException)
            {
                return new Authorization();
            }
        }

        public Authorization checkJailPassword(String password)
        {
            try
            {
                var auth = _context.authorizations.Where(a => a.Password == password).FirstOrDefault();
                if (auth == null)
                {
                    return new Authorization();
                }
                auth.users = _context.Users.Find(auth.UsersId);
                return auth;
            }
            catch (InvalidCastException)
            {
                return new Authorization();
            }
        }

    }
}
