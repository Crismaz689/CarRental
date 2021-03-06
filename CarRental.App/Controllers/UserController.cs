using CarRental.App.Helpers;
using CarRental.App.Models;
using CarRental.App.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRental.App.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _repo;
        public UserController(IUserRepository repo) => _repo = repo;

        // GET: UserController
        public ActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            var user = _repo.GetUser(id);
            
            if(user != null && HttpContext.Session.GetString("Username") == user.Username)
            {
                return View(user);
            }

            return RedirectToAction(nameof(Login));
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: UserController/Login
        public ActionResult Login()
        {
            if (HttpContext.Session.GetString("Username") != null)
            {
                return RedirectToAction(nameof(Details), "User", 
                    new { id = HttpContext.Session.GetInt32("Id") } );
            }

            return View();
        }

        // GET: UserController/Logout
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        // POST: UserController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel user)
        {
            var loggedUser = _repo.Login(user);
            if(loggedUser != null)
            {
                HttpContext.Session.SetString("Username", loggedUser.Username);
                HttpContext.Session.SetInt32("Id", loggedUser.UserId);

                return RedirectToAction(nameof(Index), "Car");
            }
            else
            {
                ViewBag.Message = "Wrong credentials!";
                return View();
            }
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserRegistrationViewModel model)
        {
            if(ModelState.IsValid)
            {
                int id = await _repo.Register(model);
                if(id > 0)
                {
                    return RedirectToAction(nameof(Login));
                }
            }
               
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            if(ModelState.IsValid)
            {

            }

            return RedirectToAction(nameof(Details));
        }
    }
}
