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
        public Boolean house { get; set; }
        public Boolean car { get; set; }
        public Boolean debt { get; set; }
        public Boolean payChecks { get; set; }
        public Boolean bituahLeumi { get; set; }
        public Boolean bankAccount { get; set; }
        public Boolean creditCard { get; set; }
        public Boolean copyId { get; set; }
        public Boolean rentContract { get; set; }
    }
}