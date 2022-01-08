using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarRental.App.Controllers
{
    public class RentController : Controller
    {
        public ActionResult RentCar()
        {
            if(HttpContext.Session.GetString("Username") != null)
            {
                return View();
            }
            return RedirectToAction(nameof(Index), "Car");
        }
    }
}
