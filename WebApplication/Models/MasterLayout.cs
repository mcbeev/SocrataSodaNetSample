// This code was generated by a cloud-generators-net tool 
// (see https://github.com/Kentico/cloud-generators-net).
// 
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
// For further modifications of the class, create a separate file with the partial class.

using System;
using System.Collections.Generic;
using KenticoCloud.Delivery;

namespace SocrataSodaNet.Models
{
    public partial class MasterLayout
    {
        public IEnumerable<Asset> SiteLogo { get; set; }
        public string SiteLogoText { get; set; }
        public string FooterContent { get; set; }
        public string CopyrightLocationPoweredBy { get; set; }
        public ContentItemSystemAttributes System { get; set; }
    }
}