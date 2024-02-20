using Microsoft.AspNetCore.Mvc;

namespace ActivoWebPage.Controllers
{
    public class CitiesController : Controller
    {
        public IActionResult Trollhattan()
        {
            return View();
        }
        public IActionResult Vastervik()
        {
            return View();
        }
    }
}

