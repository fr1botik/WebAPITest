using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPITest.Entityes;

namespace WebAPITest.Models
{
    public class Login
    {
        public Login(Logins logins)
        {
            IdUser = logins.IdUser;
            Loginn = logins.Login;
            Password = logins.Password;
        }
        public int IdUser { get; set; }
        public string Loginn { get; set; }
        public string Password { get; set; }
    }
}