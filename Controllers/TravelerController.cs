using Microsoft.AspNetCore.Mvc;
using aspapp.Models;
using Microsoft.EntityFrameworkCore; // Potrzebne dla ToListAsync()
using System.Threading.Tasks;

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
            return View(); // Przekazanie pustego modelu Traveler do widoku
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Chroni przed atakami CSRF
        public async Task<IActionResult> CreateTraveler(
            [Bind("Firstname,Lastname,Email,BirthDate")] Traveler traveler)
        {
            if (ModelState.IsValid)
            {
                _context.Travelers.Add(traveler); // Dodanie do bazy danych
                await _context.SaveChangesAsync(); // Zapisanie zmian
                return RedirectToAction(nameof(Index)); // Przekierowanie do listy podróżników
            }

            return View(traveler); // Jeśli są błędy walidacji, zwróć formularz z danymi
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var travelers = await _context.Travelers.ToListAsync();
            return View(travelers); // Wyświetlenie listy podróżników
        }

        [HttpGet]
        public async Task<IActionResult> EditTraveler(int id)
        {
            var traveler = await _context.Travelers.FindAsync(id);

            if (traveler == null)
            {
                return NotFound();
            }

            return View(traveler); // Przekazanie pustego modelu Traveler do widoku

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTraveler(int id, Traveler traveler)
        {
            if (ModelState.IsValid)
            {
                _context.Update(traveler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(traveler); // Przekazanie pustego modelu Traveler do widoku
        }

        // GET: DeleteTraveler
        [HttpGet]
        public async Task<IActionResult> DeleteTraveler(int id)
        {
            var traveler = await _context.Travelers.FindAsync(id);

            if (traveler == null)
            {
                return NotFound(); // Jeśli nie znaleziono podróżnika
            }

            return View(traveler); // Przekazanie obiektu Traveler do widoku
        }

        // POST: DeleteTraveler
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTraveler(int id, Traveler travelers)
        {
            var traveler = await _context.Travelers.FindAsync(id);

            if (traveler == null)
            {
                return NotFound(); // Jeśli nie znaleziono podróżnika
            }

            _context.Travelers.Remove(traveler); // Usuwamy znalezionego podróżnika
            await _context.SaveChangesAsync(); // Zapisujemy zmiany w bazie danych

            return RedirectToAction(nameof(Index));

        }
    }
}

