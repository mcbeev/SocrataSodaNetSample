using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {

        }

        public string SiteName { get; set; }

        public string SiteSubText { get; set; }

        public PageMetaMeta Meta { get; set; }

        public string AbsoluteUrl { get; set; }

        public string FooterCopyrightYear { get; set; }

        public string FooterContent { get; set; }

        public string ViewName { get; set; }
    }
}