using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPITest.Entityes;

namespace WebAPITest.Models
{
    public class User
    {

        public int IdUser { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Sale { get; set; }
        public int Type { get; set; }

        public User (Users users)
        {


            IdUser = users.IdUser;
            FName = users.FName;
            LName = users.LName;    
            Sale = users.Sale;
            Type = users.Type;
        }
    }
    

       
    

    

}