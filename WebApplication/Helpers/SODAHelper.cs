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
        private const string _AppToken = "362kGqnbRdOUyekysKljkozax";

        //"http://data.cityofchicago.org/resource/xj6s-q5eb.json";
        private const string _APIEndPointHost = "data.cityofchicago.org";
        
        private const string _APIEndPoint4x4 = "xj6s-q5eb";


        public static PagedList<BusinessLocation> GetBusinessLocations(int PageNumber, int PageSize)
        {
            return GetBusinessLocations(null, PageNumber, PageSize);
        }

        public static PagedList<BusinessLocation> GetBusinessLocations(string SearchQuery, int PageNumber, int PageSize)
        {
            var client = new SodaClient(_APIEndPointHost, _AppToken);

            //read metadata of a dataset using the resource identifier (Socrata 4x4)
            //var metadata = client.GetMetadata(_APIEndPoint4x4);
            //Console.WriteLine("{0} has {1} views.", metadata.Name, metadata.ViewsCount);

            //get a reference to the resource itself
            //the result (a Resouce object) is a generic type
            //the type parameter represents the underlying rows of the resource
            var dataset = client.GetResource <PagedList<BusinessLocation>>(_APIEndPoint4x4);

            
            //collections of an arbitrary type can be returned
            //using SoQL and a fluent query building syntax
            string[] columns = new[] { "legal_name", "doing_business_as_name", "city", "state", "zip_code", "latitude", "longitude", "date_issued" };
            //string[] aliases = new[] { "LegalName", "DBA" };

            var soql = new SoqlQuery().Select(columns);
            if(!string.IsNullOrEmpty(SearchQuery))
            {
                //soql = new SoqlQuery().FullTextSearch("{0}={1}", "legal_name", SearchQuery);
            }

            var results = dataset.Query<BusinessLocation>(soql);

            //page'em cause there might be quite a few
            PagedList<BusinessLocation> pagedResults = new PagedList<BusinessLocation>(results.ToList(), PageNumber, PageSize);

            return pagedResults;
        }
    }
}