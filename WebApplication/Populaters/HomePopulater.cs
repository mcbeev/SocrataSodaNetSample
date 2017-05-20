﻿using System;
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
    public class HomePopulater : BasePopulater<HomeViewModel>
    {
        public async Task<HomeViewModel> PopulateContent(string SortOrder, string CurrentFilter, string SearchQuery, int? CurrentPage)
        {
           base.Populate();

            //Call Kentico Cloud Deliver API to get main home page content
            var response = await DeliverClient.GetItemAsync<HomePage>("home");

            ViewModel.Content = response.Item;

            ViewModel.Meta = ViewModel.Content.HomeMeta.Cast<PageMetaMeta>().First();


            //Handle Paging
            int pageSize = 20;
            int pageNumber = (CurrentPage ?? 1);

            //Handle Sorting by Column
            if (string.IsNullOrEmpty(SortOrder))
            {
                SortOrder = "";
            }

            ViewModel.CurrentSort = SortOrder;

            ViewModel.NameSortParm = (SortOrder == "legal_name") ? "legal_name_desc" : "legal_name";
            ViewModel.DBASortParm = (SortOrder == "doing_business_as_name") ? "doing_business_as_name_desc" : "doing_business_as_name";
            ViewModel.ZipSortParm = (SortOrder == "zip_code") ? "zip_code_desc" : "zip_code";
            ViewModel.IssuedSortParm = (SortOrder == "date_issued") ? "date_issued_desc" : "date_issued";

            bool sortAsc = (!SortOrder.Contains("_desc")) ? true : false;

            //Handle Filtering
            if (!string.IsNullOrEmpty(SearchQuery))
            {
                CurrentPage = 1;
            }
            else
            {
                SearchQuery = CurrentFilter;
            }

            ViewModel.CurrentFilter = SearchQuery;


            if (!string.IsNullOrEmpty(SearchQuery))
            {
                SearchQuery = SearchQuery.ToUpper().Trim();
            }

            //Call out to OpenData API
            ViewModel.BusinessLocations = SODAHelper.GetBusinessLocations(SearchQuery, pageNumber, pageSize, SortOrder.Replace("_desc", ""), sortAsc);
            

            return ViewModel;
        }

    }
}