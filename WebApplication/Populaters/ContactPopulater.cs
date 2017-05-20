using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using SocrataSodaNet.Models;
using SocrataSodaNet.ViewModels;
using KenticoCloud.Delivery;
using System.Configuration;
using SocrataSodaNet.Helpers;

namespace SocrataSodaNet.Populaters
{
    public class ContactPopulater : BasePopulater<ContactViewModel>
    {
        public async Task<ContactViewModel> PopulateContent()
        {
           base.Populate();

            //Call Kentico Cloud Deliver API to get main home page content
            var response = await DeliverClient.GetItemAsync<GenericPage>("contact");

            ViewModel.Content = response.Item;

            ViewModel.Meta = ViewModel.Content.Meta.Cast<PageMetaMeta>().First();
            
            return ViewModel;
        }

    }
}