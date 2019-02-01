using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class OrderType
    {
        public int order_type_id { get; set; }
        public string order_type_name { get; set; }
        public Supplier supplier { get; set; }
        public List<Product> products { get; set; }
    }
}