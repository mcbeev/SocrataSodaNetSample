using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocrataSodaNet.Helpers
{
    public class SoQLQueryParams
    {
        public string CurrentFilter { get; set; }

        public string CurrentSort { get; set; }

        public int? CurrentPage { get; set; }

        public string IssuedSortParm { get; set; }

        public string SortField { get; set; }

        public string NameSortParm { get; set; }

        public string DBASortParm { get; set; }

        public string ZipSortParm { get; set; }

        public string SortOrder { get; set; }

        public string SearchQuery { get; set; }

        public SoQLQueryParams()
        {
            NameSortParm = "legal_name";
            DBASortParm = "doing_business_as_name";
            ZipSortParm = "zip_code";
            IssuedSortParm = "date_issued";

            SortOrder = "desc";

            SortField = "date_issued";
        }
    }
}