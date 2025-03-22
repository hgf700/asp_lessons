using Microsoft.AspNetCore.Mvc;
using aspapp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;



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
            ViewBag.Guides = new SelectList(_context.Guides, "Id", "Firstname");
            ViewBag.Travelers = new SelectList(_context.Travelers, "Id", "Firstname");

            return View(); // Przekazanie pustego modelu Traveler do widoku
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Chroni przed atakami CSRF
        public async Task<IActionResult> CreateTrip(

            [Bind("Title,Description,GuideId,TravelerId")] Trip trip)
        {
            ViewBag.Guides = new SelectList(_context.Guides, "Id", "Firstname");
            ViewBag.Travelers = new SelectList(_context.Travelers, "Id", "Firstname");

            if (ModelState.IsValid)
            {

                _context.Trips.Add(trip); // Dodanie do bazy danych
                await _context.SaveChangesAsync(); // Zapisanie zmian
                return RedirectToAction(nameof(Index)); // Przekierowanie na stronę listy podróżników (lub inną stronę)
            }



            return View(trip); // Jeśli są błędy walidacji, zwróć formularz z danymi
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var trips = await _context.Trips
                .Include(t => t.Guide) // Załaduj dane przewodnika
                .Include(t => t.Traveler) // Załaduj dane podróżnika
                .ToListAsync(); // Używaj async

            return View(trips); // Wyświetlenie listy podróżników
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
