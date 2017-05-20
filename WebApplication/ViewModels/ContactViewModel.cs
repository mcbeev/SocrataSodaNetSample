using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocrataSodaNet.Models;

namespace SocrataSodaNet.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        public string Title { get; set; }

        public GenericPage Content { get; set; }

    }
}