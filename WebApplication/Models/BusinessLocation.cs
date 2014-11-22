using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class BusinessLocation
    {
        public string ID { get; set; }
        public string Legal_Name { get; set; }
        public string Doing_Business_As_Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip_Code { get; set; }
        public DateTime Date_Issued { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}