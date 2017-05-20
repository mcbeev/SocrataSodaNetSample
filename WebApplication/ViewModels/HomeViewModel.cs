using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocrataSodaNet.Models;

namespace SocrataSodaNet.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public string Title { get; set; }

        public HomePage Content { get; set; }

        public PagedList<BusinessLocation> BusinessLocations { get; set; }

        public string CurrentFilter { get; set; }

        public string CurrentSort { get; set; }
        public string IssuedSortParm { get; set; }

        public string SortField { get; set; }

        public string NameSortParm { get; set; }

        public string DBASortParm { get; set; }

        public string ZipSortParm { get; set; }
    }
}