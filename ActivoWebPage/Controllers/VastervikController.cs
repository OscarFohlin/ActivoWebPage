using Hv.Sos100.SingleSignOn;
using Microsoft.AspNetCore.Mvc;

namespace ActivoWebPage.Controllers
{
    public class VastervikController : Controller
    {
        //Flikar för Västervik
        public async Task<IActionResult> HomeAsync()
        {
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);
            return View("~/Views/Vastervik/Home.cshtml");
        }
        public async Task<IActionResult> CultureAsync()
        {
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);
            return View("~/Views/Vastervik/Vastervik_Culture.cshtml");
        }
        public async Task<IActionResult> SportsAsync()
        {
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);
            return View("~/Views/Vastervik/Vastervik_Sports.cshtml");
        }
        public async Task<IActionResult> SocializingAsync()
        {
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);
            return View("~/Views/Vastervik/Vastervik_Socializing.cshtml");
        }
    }
}

