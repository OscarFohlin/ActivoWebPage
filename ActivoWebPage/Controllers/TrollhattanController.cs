using Hv.Sos100.SingleSignOn;
using Microsoft.AspNetCore.Mvc;

namespace ActivoWebPage.Controllers
{
    public class TrollhattanController : Controller
    {

        //Flikar för Trollhättan
        public async Task<IActionResult> HomeAsync()
        {
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View("~/Views/Trollhattan/Home.cshtml");
        }
        public async Task<IActionResult> CultureAsync()
        {
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);
            return View("~/Views/Trollhattan/Trollhattan_Culture.cshtml");
        }
        public async Task<IActionResult> SportsAsync()
        {
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);
            return View("~/Views/Trollhattan/Trollhattan_Sports.cshtml");
        }
        public async Task<IActionResult> SocializingAsync()
        {
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);
            return View("~/Views/Trollhattan/Trollhattan_Socializing.cshtml");
        }
    }
}

