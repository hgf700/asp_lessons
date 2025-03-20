using Microsoft.AspNetCore.Mvc;
using aspapp.Models;
using aspapp.Pages.Home;
using aspapp.Pages.TripController;

namespace aspapp.Controllers
{
    public class TripControler : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Traveler traveler)
        {
            if (ModelState.IsValid)
            {

            }

            return View(traveler);
        }
    }
}
