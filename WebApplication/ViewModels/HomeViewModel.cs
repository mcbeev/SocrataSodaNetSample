﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocrataSodaNet.Models;
using SocrataSodaNet.Helpers;

namespace SocrataSodaNet.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public string Title { get; set; }

        public HomePage Content { get; set; }

        public PagedList<BusinessLocation> BusinessLocations { get; set; }

        public string DataSetMetaInformation { get; set; }

        public SoQLQueryParams SoQLParams { get; set; }
    }
}