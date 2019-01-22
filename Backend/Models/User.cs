using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Backend.Models {
    public class User {
        public int userID { get; set; }
        public string userName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}