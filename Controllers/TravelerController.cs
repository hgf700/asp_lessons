using Microsoft.AspNetCore.Mvc;
using aspapp.Models;
using aspapp.Pages.Home;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace aspapp.Controllers
{
    public class TravelerController : Controller
    {
        private readonly trip_context _context;

        public TravelerController(trip_context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CreateTraveler()
        {
            var guides = _context.Guides.ToList(); // Pobranie przewodników z bazy danych
            ViewBag.Guides = new SelectList(guides, "Id", "Firstname"); // Tworzenie listy przewodników
            return View(new Traveler()); // Przekazanie pustego modelu Traveler do widoku
        }

    }
}
