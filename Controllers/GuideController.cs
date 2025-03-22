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

        [HttpGet]
        public IActionResult CreateGuide()
        {
            return View(new Guide()); // Przekazanie pustego modelu Guide do widoku
        }

    }
}
