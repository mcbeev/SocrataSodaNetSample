using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SODA;
using SODA.Models;
using SODA.Utilities;
using System.Data;
using WebApplication.Models;
using PagedList;

namespace WebApplication.Helpers
{
    public static class SODAHelper
    {
        #region Constants

        /// <summary>
        /// App Token from Socrata registered app - get yours at https://opendata.socrata.com/login
        /// </summary>
        private const string _AppToken = "362kGqnbRdOUyekysKljkozax";

        /// <summary>
        /// HostName of "http://data.cityofchicago.org/resource/xj6s-q5eb.json";
        /// </summary>
        private const string _APIEndPointHost = "data.cityofchicago.org";
        
        /// <summary>
        /// Socrata 4x4 Identifier
        /// </summary>
        private const string _APIEndPoint4x4 = "xj6s-q5eb";

        #endregion


        #region Methods

        /// <summary>
        /// Returns meta information about the dataset
        /// </summary>
        /// <returns></returns>
        public static string GetMeta()
        {
            //Create client to talk to OpenDat API Endpoint
            var client = new SodaClient(_APIEndPointHost, _AppToken);
            
            //read metadata of a dataset using the resource identifier (Socrata 4x4)
            var metadata = client.GetMetadata(_APIEndPoint4x4);

            return string.Format("{0} has {1} views. Last updated on {2:g}", metadata.Name, metadata.ViewsCount, metadata.RowsLastUpdated);
        }

        /// <summary>
        /// Gets all Business Locations in the dataset
        /// </summary>
        /// <param name="PageNumber">Current page number</param>
        /// <param name="PageSize">Number of items per page</param>
        /// <returns>object PagedList</returns>
        public static PagedList<BusinessLocation> GetBusinessLocations(int PageNumber, int PageSize)
        {
            return GetBusinessLocations(null, PageNumber, PageSize, null, true);
        }

        /// <summary>
        /// Gets sorted list of all Business Locations in the dataset by filter 
        /// </summary>
        /// <param name="SearchQuery">Query to filter on</param>
        /// <param name="PageNumber">Current page number</param>
        /// <param name="PageSize">Number of items per page</param>
        /// <param name="OrderBy">Column name to sequence the list by</param>
        /// <param name="OrderByAscDesc">Sort direction</param> 
        /// <returns>object PagedList</returns>
        public static PagedList<BusinessLocation> GetBusinessLocations(string SearchQuery, int PageNumber, int PageSize, string OrderBy, bool OrderByAscDesc)
        {
            //Create client to talk to OpenDat API Endpoint
            var client = new SodaClient(_APIEndPointHost, _AppToken);

            //get a reference to the resource itself the result (a Resouce object) is a generic type
            //the type parameter represents the underlying rows of the resource
            var dataset = client.GetResource <PagedList<BusinessLocation>>(_APIEndPoint4x4);

            string[] columns = new[] { "legal_name", "doing_business_as_name", "city", "state", "zip_code", "latitude", "longitude", "date_issued" };
            //string[] aliases = new[] { "LegalName", "DBA" };

            //using SoQL and a fluent query building syntax
            var soql = new SoqlQuery().Select(columns).Order((OrderByAscDesc) ? SoqlOrderDirection.ASC: SoqlOrderDirection.DESC,  new[] { OrderBy });

            if(!string.IsNullOrEmpty(SearchQuery))
            {
                //Uncomment to enable filtering
                //soql = new SoqlQuery().FullTextSearch(SearchQuery);
            }

            var results = dataset.Query<BusinessLocation>(soql);

            //page'em cause there might be quite a few
            PagedList<BusinessLocation> pagedResults = new PagedList<BusinessLocation>(results.ToList(), PageNumber, PageSize);

            return pagedResults;
        }

        #endregion
    }
}