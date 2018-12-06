using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Volunteer
    {
        public int VolunteerId { get; set; }
        public string VolunteerFName { get; set; }
        public string VolunteerLName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string VolunteerType { get; set; }
    }
}