using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public string Title { get; set; }

        public GenericPage Content { get; set; }

    }
}