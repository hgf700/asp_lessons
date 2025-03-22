using Microsoft.AspNetCore.Mvc;
using aspapp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace aspapp.Controllers
{
    public class TripController : Controller
    {
        private readonly trip_context _context;

        public TripController(trip_context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CreateTrip()
        {
            var guides = _context.Guides.ToList(); // Pobranie przewodników
            var travelers = _context.Travelers.ToList(); // Pobranie podróżników

            ViewBag.Guides = new SelectList(guides, "Id", "Firstname");
            ViewBag.Travelers = new SelectList(travelers, "Id", "Firstname"); // Tworzenie listy podróżników

            return View(new Trip()); // Przekazanie pustego modelu Trip do widoku
        }


        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Search()
        {
            return View();
        }
    }
}
