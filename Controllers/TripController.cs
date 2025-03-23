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

        [HttpGet]
        public async Task<IActionResult> EditTrip(int id)
        {
            ViewBag.Guides = new SelectList(_context.Guides, "Id", "Firstname");
            ViewBag.Travelers = new SelectList(_context.Travelers, "Id", "Firstname");

            var trip = await _context.Trips.FindAsync(id);

            if (trip == null)
            {
                return NotFound();
            }

            return View(trip); // Przekazanie pustego modelu Traveler do widoku

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTrip([Bind("Title,Description,GuideId,TravelerId")] int id, Trip trip)
        {
            ViewBag.Guides = new SelectList(_context.Guides, "Id", "Firstname");
            ViewBag.Travelers = new SelectList(_context.Travelers, "Id", "Firstname");

            if (ModelState.IsValid)
            {
                _context.Update(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(trip); // Przekazanie pustego modelu Traveler do widoku
        }

        [HttpGet]
        public async Task<IActionResult> DeleteTrip(int id)
        {
            var trip = await _context.Trips.FindAsync(id);

            if (trip == null)
            {
                return NotFound(); // Jeśli nie znaleziono podróżnika
            }

            return View(trip); // Przekazanie obiektu Traveler do widoku
        }

        // POST: DeleteTraveler
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTrip(int id, Trip trips)
        {
            var trip = await _context.Trips.FindAsync(id);

            if (trip == null)
            {
                return NotFound(); // Jeśli nie znaleziono podróżnika
            }

            _context.Trips.Remove(trip); // Usuwamy znalezionego podróżnika
            await _context.SaveChangesAsync(); // Zapisujemy zmiany w bazie danych

            return RedirectToAction(nameof(Index));

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
