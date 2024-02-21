using Microsoft.AspNetCore.Mvc;

namespace ActivoWebPage.Controllers
{
    public class CitiesController : Controller
    {
        //Startsidor
        public IActionResult Trollhattan()
        {
            return View();
        }

        public IActionResult Vastervik()
        {
            return View();
        }

        //Flikar för Trollhättan
        public IActionResult ThnCulture()
        {
            return View();
        }
        public IActionResult ThnSports()
        {
            return View();
        }
        public IActionResult ThnSearch()
        {
            return View();
        }
    }
}

