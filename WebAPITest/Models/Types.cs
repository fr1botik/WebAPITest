using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPITest.Entityes;

namespace WebAPITest.Models
{
    public class Types
    {
        public Types(Entityes.Type type) {

            IdType = type.IdType;
            Type = type.Type1;
        
        
        }
        public int IdType { get; set; }
        public string Type { get; set; }
    }
}