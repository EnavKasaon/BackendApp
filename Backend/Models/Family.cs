using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Family  {

        public int familyId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string street { get; set; }
        public string houseNum { get; set; }
        public int floor { get; set; }
        public int phone { get; set; }
        public int peopleNumber { get; set; }
        public string notes { get; set; }
        public string howDidYouHear { get; set; }
        public string reasonForReferral { get; set; }
        public DateTime joinDate { get; set; }
        public string familyType { get; set; }
        public string basketType { get; set; }
        public bool house { get; set; } 
        public bool car { get; set; }
        public bool debt { get; set; }
        public bool payChecks { get; set; }
        public bool bituahLeumi { get; set; }
        public bool bankAccount { get; set; }
        public bool creditCard { get; set; }
        public bool copyId { get; set; }
        public bool rentContract { get; set; }
    }
}