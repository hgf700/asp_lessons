using Microsoft.AspNetCore.Mvc;
using aspapp.Models;
using aspapp.Pages.Home;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace aspapp.Controllers
{
    public class GuideController : Controller
    {
        private readonly trip_context _context;

        public GuideController(trip_context context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTrip(Trip trip)
        {
            if (ModelState.IsValid)
            {
                var guide = await _context.Guides.FindAsync(trip.GuideId);
                if (guide == null)
                {
                    ModelState.AddModelError("GuideId", "Selected guide does not exist.");
                    ViewBag.Guides = new SelectList(_context.Guides, "Id", "Firstname");
                    return View(trip);
                }

                _context.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Guides = new SelectList(_context.Guides, "Id", "Firstname");
            return View(trip);
        }
    }
}
