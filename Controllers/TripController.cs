using Microsoft.AspNetCore.Mvc;
using aspapp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;



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
            return View();
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
