using Microsoft.AspNetCore.Mvc;
using aspapp.Models;
using aspapp.Pages.Home;


namespace aspapp.Controllers
{
    public class TripController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Search()
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
