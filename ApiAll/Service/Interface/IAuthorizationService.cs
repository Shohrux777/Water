using ApiAll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Service.Interface
{
    public interface IAuthorizationService
    {
        public  Authorization checkLoginAndPassword(String login, String password);
        public Authorization checkJailPassword( String password);

    }
}
