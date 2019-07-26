using Produto.WebAPI.Filters;
using System.Web.Mvc;

namespace Produto.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        [JwtAuthentication]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
