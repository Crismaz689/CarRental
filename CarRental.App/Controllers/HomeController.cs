using Microsoft.AspNetCore.Mvc;

namespace CarRental.App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
