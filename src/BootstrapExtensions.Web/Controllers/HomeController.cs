using System.Web.Mvc;

namespace BootstrapExtensions.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.CurrPage = "Home";
            return View();
        }

        public ActionResult Base()
        {
            ViewBag.CurrPage = "Base";
            return View();
        }

        public ActionResult Components()
        {
            ViewBag.CurrPage = "Components";
            return View();
        }

    }
}
