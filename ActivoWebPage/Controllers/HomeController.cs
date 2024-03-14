using ActivoWebPage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Hv.Sos100.SingleSignOn;
using Microsoft.AspNetCore.Http;
using System.Net.Http;


namespace ActivoWebPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Uppdaterad för att hantera session
        public async Task<IActionResult> Index()
        {
            //Läs in om session finns och skicka till ViewData, allt gör SSO NuGet
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);

            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View();
        }
        
        //Logga in
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Authenticate(string email, string password)
        {
            var authenticationService = new AuthenticationService();
            var authenticatedSession = await authenticationService.CreateSession(email, password, controllerBase: this, HttpContext);
            return authenticatedSession ?  RedirectToAction("Index", "Home") : RedirectToAction("Privacy", "Home");
        }


        public IActionResult Logout()
        {
            var authenticationService = new AuthenticationService();
            authenticationService.EndSession(controllerBase: this, HttpContext);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
