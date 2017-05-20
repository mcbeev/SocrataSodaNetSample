using System.Web.Mvc;
using SocrataSodaNet.Helpers;
using KenticoCloud.Delivery;
using System.Threading.Tasks;
using SocrataSodaNet.Populaters;

namespace SocrataSodaNet.Controllers
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
        

    }
}