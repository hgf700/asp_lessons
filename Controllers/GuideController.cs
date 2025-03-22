using Microsoft.AspNetCore.Mvc;
using aspapp.Models;
using aspapp.Pages.Home;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace aspapp.Controllers
{
    public class GuideController : Controller
    {
        private readonly trip_context _context;

        public GuideController(trip_context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CreateGuide()
        {
            return View(); // Przekazanie pustego modelu Traveler do widoku
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Chroni przed atakami CSRF
        public async Task<IActionResult> CreateGuide(
            [Bind("Firstname,Lastname,Email,Title")] Guide guide)
        {
            if (ModelState.IsValid)
            {
                _context.Guides.Add(guide); // Dodanie do bazy danych
                await _context.SaveChangesAsync(); // Zapisanie zmian
                return RedirectToAction(nameof(Index)); // Przekierowanie na stronę listy podróżników (lub inną stronę)
            }

            return View(guide); // Jeśli są błędy walidacji, zwróć formularz z danymi
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var guides = await _context.Guides.ToListAsync();
            return View(guides); // Wyświetlenie listy podróżników
        }


    }
}
