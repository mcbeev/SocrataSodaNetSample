using System.Web.Mvc;
using WebApplication.Helpers;
using KenticoCloud.Delivery;
using System.Threading.Tasks;
using WebApplication.Populaters;

namespace WebApplication.Controllers
{
    public class AboutController : BaseController
    {

        public async Task<ViewResult> Index()
        {
            return View(await new AboutPopulater().PopulateContent());
        }
        
    }
}