using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Login
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string Password { get; set; }
    }
}