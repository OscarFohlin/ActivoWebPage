using Microsoft.AspNetCore.Mvc;

namespace ActivoWebPage.Controllers
{
    public class VastervikController : Controller
    {

        //Flikar för Trollhättan
        public IActionResult Home()
        {
            return View("~/Views/Vastervik/Home.cshtml");
        }
        public IActionResult Culture()
        {
            return View("~/Views/Vastervik/Vastervik_Culture.cshtml");
        }
        public IActionResult Sports()
        {
            return View("~/Views/Vastervik/Vastervik_Sports.cshtml");
        }
        public IActionResult Socializing()
        {
            return View("~/Views/Vastervik/Vastervik_Socializing.cshtml");
        }
    }
}

