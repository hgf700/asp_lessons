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
            return View(new Traveler()); // Przekazanie pustego modelu Traveler do widoku
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
    }
}
