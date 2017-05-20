using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using SocrataSodaNet.Models;
using SocrataSodaNet.ViewModels;
using KenticoCloud.Delivery;
using System.Configuration;
using System.Net;

namespace SocrataSodaNet.Populaters
{
 
    public class BasePopulater<TViewModel> where TViewModel : BaseViewModel, new()
    {
        public TViewModel ViewModel { get; set; }

        public IDeliveryClient DeliverClient { get; set; }

        public BasePopulater()
        {
            ViewModel = new TViewModel();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            DeliverClient = new DeliveryClient(ConfigurationManager.AppSettings["KenticoCloudProjectID"])
            {
                CodeFirstModelProvider = { TypeProvider = new CustomTypeProvider() }
            };
        }

        public TViewModel Populate()
        {

            PopulateSiteLayout();

            return ViewModel;
        }

        protected void PopulateSiteLayout()
        {
            Task<DeliveryItemResponse<MasterLayout>> response = Task.Run<DeliveryItemResponse<MasterLayout>>(async () => await DeliverClient.GetItemAsync<MasterLayout>("master"));
            
            var layout = response.Result.Item;
          
            //Main site logo
            //ViewModel.SiteLogo = new Image
            //{
            //    Url = layout.SiteLogo.First().Url,
            //    AltText = layout.SiteLogoText
            //};

            ViewModel.SiteName = layout.SiteLogoText;

            ViewModel.SiteSubText = layout.SiteLogoText;

            PopulateMainMenu(layout);
            PopulateFooter(layout);
        }

        protected virtual void PopulateFooter(MasterLayout Layout)
        {
            //ViewModel.FooterTitle = Layout.FooterContent;
            ViewModel.FooterContent = Layout.FooterContent;

            //ViewModel.FooterContactTitle = Layout.ContactTitle;
            //ViewModel.FooterContactText = Layout.PhoneNumberAddress;

            ViewModel.FooterCopyrightYear = Layout.CopyrightLocationPoweredBy;

            if (ViewModel.FooterCopyrightYear.Contains("[year]"))
            {
                ViewModel.FooterCopyrightYear = ViewModel.FooterCopyrightYear.Replace("[year]", DateTime.Now.Year.ToString());
            }
        }

        protected virtual void PopulateMainMenu(MasterLayout Layout)
        {
            //ViewModel.MenuItems = new List<MenuItem>();
        }
    }
}