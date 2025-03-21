using Microsoft.AspNetCore.Mvc;
using aspapp.Models;
using aspapp.Pages.Home;


namespace aspapp.Controllers
{
    public class TravelerController : Controller
    {
        private readonly trip_context _context;

        public TravelerController(trip_context context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTraveler(Traveler traveler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(traveler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(traveler);
        }
    }
}
