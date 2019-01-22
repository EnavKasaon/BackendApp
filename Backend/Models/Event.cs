using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Event
    {
        public int event_id { get; set; }
        public string event_desc { get; set; }
        public DateTime start_date  { get; set; }
        public DateTime end_date { get; set; }
        public string color { get; set; }
    }
}