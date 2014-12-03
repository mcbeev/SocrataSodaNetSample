using System.Web.Mvc;
using WebApplication.Helpers;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index(string SortOrder, string CurrentFilter, string SearchQuery, int? CurrentPage)
        {
            //Handle Paging
            int pageSize = 20;
            int pageNumber = (CurrentPage ?? 1);

            //Handle Sorting by Column
            if (string.IsNullOrEmpty(SortOrder))
            {
                SortOrder = "";
            }

            ViewBag.CurrentSort = SortOrder;
            ViewBag.NameSortParm = (SortOrder == "legal_name") ? "legal_name_desc" : "legal_name";
            ViewBag.DBASortParm = (SortOrder == "doing_business_as_name") ? "doing_business_as_name_desc" : "doing_business_as_name";
            ViewBag.ZipSortParm = (SortOrder == "zip_code") ? "zip_code_desc" : "zip_code";
            ViewBag.IssuedSortParm = (SortOrder == "date_issued") ? "date_issued_desc" : "date_issued";
            
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

            ViewBag.CurrentFilter = SearchQuery;

            if (!string.IsNullOrEmpty(SearchQuery))
            {
                SearchQuery = SearchQuery.ToUpper().Trim();
            }

            //Call out to OpenData API
            var bigData = SODAHelper.GetBusinessLocations(SearchQuery, pageNumber, pageSize, SortOrder.Replace("_desc", ""), sortAsc);

            return View(bigData); 
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "A Sample Application designed to show SODA.Net";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}