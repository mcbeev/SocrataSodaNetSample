using System;

namespace SocrataSodaNet.Models
{
    public class BusinessLocation
    {
        public string ID { get; set; }
        public string LegalName { get; set; }
        public string DBA { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip_Code { get; set; }
        public DateTime IssuedOn { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}