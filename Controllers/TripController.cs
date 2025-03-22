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
            return View(new Trip()); // Przekazanie pustego modelu Traveler do widoku
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Chroni przed atakami CSRF
        public async Task<IActionResult> CreateTrip(Trip trip)
        {
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
            var trips = await _context.Trips.ToListAsync();
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
