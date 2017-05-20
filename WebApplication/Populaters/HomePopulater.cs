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
using System.Text.RegularExpressions;

namespace SocrataSodaNet.Populaters
{
    public class HomePopulater : BasePopulater<HomeViewModel>
    {

        public async Task<HomeViewModel> PopulateContent(SoQLQueryParams Params)
        {
            base.Populate();

            //Fill in the editable areas of the page
            await PopulateHtmlContent();

            //Fill in the main open data for grid
            PopulateOpenDataSet(Params);

            return ViewModel;
        }

        private async Task PopulateHtmlContent()
        {
            //Call Kentico Cloud Deliver API to get main home page content
            var response = await DeliverClient.GetItemAsync<HomePage>("home");

            ViewModel.Content = response.Item;

            ViewModel.Meta = ViewModel.Content.HomeMeta.Cast<PageMetaMeta>().First();
        }

        private void PopulateOpenDataSet(SoQLQueryParams Params)
        {
            //Handle Paging
            int pageSize = 20;
            int pageNumber = (Params.CurrentPage ?? 1);

            //Set the original values of the SoQL call and grid state
            ViewModel.SoQLParams = Params;

            //Handle Sorting by Column
            if (string.IsNullOrEmpty(Params.SortOrder))
            {
                Params.SortOrder = "";
            }

            //Now start updating to the new values and new grid state
            //Handle Sort field and Sort Direction
            ViewModel.SoQLParams.CurrentSort = Params.SortOrder;

            //Populate the UI Grid field header labels
            ViewModel.SoQLParams.NameSortParm = (Params.SortOrder == "legal_name") ? "legal_name_desc" : "legal_name";
            ViewModel.SoQLParams.DBASortParm = (Params.SortOrder == "doing_business_as_name") ? "doing_business_as_name_desc" : "doing_business_as_name";
            ViewModel.SoQLParams.ZipSortParm = (Params.SortOrder == "zip_code") ? "zip_code_desc" : "zip_code";
            ViewModel.SoQLParams.IssuedSortParm = (Params.SortOrder == "date_issued") ? "date_issued_desc" : "date_issued";

            //Switch Sort Direction
            bool sortAsc = (!Params.SortOrder.Contains("_desc")) ? true : false;

            //Handle Filtering         
            if (!string.IsNullOrEmpty(Params.SearchQuery))
            {
                //Reset paging
                ViewModel.SoQLParams.CurrentPage = 1;

                //Sanitize the input
                Params.SearchQuery = Params.SearchQuery.ToUpper().Trim();
                ViewModel.SoQLParams.SearchQuery = Regex.Replace(Params.SearchQuery, "[^A-Z a-z0-9$]", "");

                //Add back in the value of the Filter textbox
                ViewModel.SoQLParams.CurrentFilter = ViewModel.SoQLParams.SearchQuery;
            }

            //Catt out to OpenData API for meta info
            ViewModel.DataSetMetaInformation = SODAHelper.GetMeta();

            //Call out to OpenData API for the acutal data
            ViewModel.BusinessLocations = SODAHelper.GetBusinessLocations(ViewModel.SoQLParams.SearchQuery, pageNumber, pageSize, Params.SortOrder.Replace("_desc", ""), sortAsc);
        }

    }
}