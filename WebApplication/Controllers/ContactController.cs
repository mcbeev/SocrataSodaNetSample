﻿using System.Web.Mvc;
using SocrataSodaNet.Helpers;
using KenticoCloud.Delivery;
using System.Threading.Tasks;
using SocrataSodaNet.Populaters;

namespace SocrataSodaNet.Controllers
{
    public class ContactController : BaseController
    {

        public async Task<ViewResult> Index()
        {
            return View(await new ContactPopulater().PopulateContent());
        }
        
    }
}