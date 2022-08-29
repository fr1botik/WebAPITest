using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPITest.Entityes;

namespace WebAPITest.Models
{
    public class Sale
    {
        public Sale(Sales sales)
        {
            IdSale = sales.IdSale;
            Salee = sales.Sale;
        }

        public int IdSale { get; set; }
        public string Salee { get; set; }
    }
}