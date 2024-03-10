using Microsoft.AspNetCore.Mvc;

namespace ActivoWebPage.Controllers
{
    public class TrollhattanController : Controller
    {

        //Flikar för Trollhättan
        public IActionResult Home()
        {
            return View("~/Views/Trollhattan/Home.cshtml");
        }
        public IActionResult Culture()
        {
            return View("~/Views/Trollhattan/Trollhattan_Culture.cshtml");
        }
        public IActionResult Sports()
        {
            return View("~/Views/Trollhattan/Trollhattan_Sports.cshtml");
        }
        public IActionResult Socializing()
        {
            return View("~/Views/Trollhattan/Trollhattan_Socializing.cshtml");
        }
    }
}

