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
        public IActionResult Trollhattan_Culture()
        {
            return View();
        }
        public IActionResult Trollhattan_Sports()
        {
            return View();
        }
        public IActionResult Trollhattan_Socializing()
        {
            return View();
        }
        public IActionResult Trollhattan_Search()
        {
            return View();
        }
    }
}

