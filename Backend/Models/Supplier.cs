using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Supplier
    {
        public int ID { get; set; }
        public string companyName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string GoodsType { get; set; }
        public string Address { get; set; }

        // public enumTypeSupplier SupplierType { get; set; }
        public string SupplierType { get; set; }


    }

}