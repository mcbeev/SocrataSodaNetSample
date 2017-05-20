using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.ViewModels;
using KenticoCloud.Delivery;
using System.Configuration;
using WebApplication.Helpers;

namespace WebApplication.Populaters
{
    public class AboutPopulater : BasePopulater<AboutViewModel>
    {
        public async Task<AboutViewModel> PopulateContent()
        {
           base.Populate();

            //Call Kentico Cloud Deliver API to get main home page content
            var response = await DeliverClient.GetItemAsync<GenericPage>("about");

            ViewModel.Content = response.Item;

            ViewModel.Meta = ViewModel.Content.Meta.Cast<PageMetaMeta>().First();
            
            return ViewModel;
        }

    }
}