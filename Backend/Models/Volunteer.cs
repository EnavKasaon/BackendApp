using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Volunteer
    {
        internal DateTime b;

        public int VolunteerId { get; set; }
        public string VolunteerFName { get; set; }
        public string VolunteerLName { get; set; }
        public string vPhone { get; set; }
        public DateTime BirthDate { get; set; }
        public string VolunteerType { get; set; }
        public string IdNum { get; set; }


    }
}