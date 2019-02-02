using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Order
    {
        public int order_id { get; set; }
        public OrderType order_type { get; set; }
        public DateTime order_date { get; set; }
        public DateTime received_date { get; set; }
        public Boolean received { get; set; }
    }
}