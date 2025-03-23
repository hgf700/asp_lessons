using Microsoft.AspNetCore.Mvc;
using aspapp.Models;
using aspapp.Pages.Home;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;


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

        [HttpGet]
        public async Task<IActionResult> EditGuide(int id)
        {
            var guide = await _context.Guides.FindAsync(id);

            if (guide == null)
            {
                return NotFound();
            }

            return View(guide); // Przekazanie pustego modelu Traveler do widoku

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGuide([Bind("Firstname,Lastname,Email,Title")] int id, Guide guide)
        {
            if (ModelState.IsValid)
            {
                _context.Update(guide);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(guide); // Przekazanie pustego modelu Traveler do widoku
        }

        [HttpGet]
        public async Task<IActionResult> DeleteGuide(int id)
        {
            var guide = await _context.Guides.FindAsync(id);

            if (guide == null)
            {
                return NotFound(); // Jeśli nie znaleziono podróżnika
            }

            return View(guide); // Przekazanie obiektu Traveler do widoku
        }

        // POST: DeleteTraveler
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteGuide(int id, Guide guides)
        {
            var guide = await _context.Guides.FindAsync(id);

            if (guide == null)
            {
                return NotFound(); // Jeśli nie znaleziono podróżnika
            }

            _context.Guides.Remove(guide); // Usuwamy znalezionego podróżnika
            await _context.SaveChangesAsync(); // Zapisujemy zmiany w bazie danych

            return RedirectToAction(nameof(Index));

        }

    }
}
