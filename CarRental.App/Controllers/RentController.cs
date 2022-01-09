using CarRental.App.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CarRental.App.Controllers
{
    public class RentController : Controller
    {
        private readonly IRentRepository _repo;
        public RentController(IRentRepository repo) => _repo = repo;

        // POST: Rent/RentCar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RentCar(int id)
        {
            if(HttpContext.Session.GetString("Username") != null)
            {
                int resultId = await _repo.RentCar(id, HttpContext.Session.GetInt32("Id"));

                if(resultId > 0)
                {
                    return RedirectToAction("Details", "User",
                        new { id = HttpContext.Session.GetInt32("Id") });
                }
                else
                {
                    return RedirectToAction("Login","User"); // call error
                }
            }
            return RedirectToAction(nameof(Index), "Car");
        }
    }
}
