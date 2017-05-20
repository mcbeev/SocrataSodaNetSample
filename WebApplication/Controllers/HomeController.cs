using System.Web.Mvc;
using WebApplication.Helpers;
using KenticoCloud.Delivery;
using System.Threading.Tasks;
using WebApplication.Populaters;

namespace WebApplication.Controllers
{
    public class HomeController : BaseController
    {

        public async Task<ViewResult> Index(string SortOrder, string CurrentFilter, string SearchQuery, int? CurrentPage)
        {
            return View(await new HomePopulater().PopulateContent(
                    SortOrder,
                    CurrentFilter,
                    SearchQuery,
                    CurrentPage
                ));
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