using CarRental.App.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.App.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _repo;

        public CarController(ICarRepository repo) => _repo = repo;

        // GET: CarController
        public ActionResult Index()
        {
            var cars = _repo.GetAllCars();

            return View(cars);
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            var car = _repo.GetCar(id);

            if(car != null)
            {
                return View(car);
            }

            return View();
        }
    }
}
