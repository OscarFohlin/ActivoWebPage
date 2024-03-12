using ActivoWebPage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Hv.Sos100.SingleSignOn;


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
            // Create an instance of the authenticationservice, be careful not to mix it up with the native .NET AuthenticationService
            var authenticationService = new AuthenticationService();

            // Use the authenticationService object to call the ResumeSession method and optionally store the result in a variable
            // The ResumeSession method does not need to be supplied with any account information as it checks the browser cookies for a valid token
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);

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
            // Create an instance of the authenticationservice, be careful not to mix it up with the native .NET AuthenticationService
            var authenticationService = new AuthenticationService();

            // Use the authenticationService object to call the CreateSession method and optionally store the result in a variable
            // Make sure to supply the CreateSession method with the email, password and controllerBase:this, HttpContext
            var authenticatedSession = await authenticationService.CreateSession(email, password, controllerBase: this, HttpContext);

            // Depending on if the authentication was successfull the account can be directed to different pages
            return authenticatedSession ?  RedirectToAction("Index", "Home") : RedirectToAction("Privacy", "Home");
          
        }

        public IActionResult Logout()
        {
            // Create an instance of the authenticationservice, be careful not to mix it up with the native .NET AuthenticationService
            var authenticationService = new AuthenticationService();

            // Call the EndSession method to delete the cookie and end the account´s session
            // This will force the account to authenticate themselves again if they want to have access
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
