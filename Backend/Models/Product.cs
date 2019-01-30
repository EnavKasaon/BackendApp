using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Product
    {
        public int order_type_id { get; set; }
        public string product_name { get; set; }
        public int amount { get; set; }
        public string comments { get; set; }
    }
}