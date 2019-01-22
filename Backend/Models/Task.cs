using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Task
    {
        public int task_id { get; set; }
        public string task_desc { get; set; }
        public Boolean task_status { get; set; }
    }
}