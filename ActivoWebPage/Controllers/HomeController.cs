using ActivoWebPage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Hv.Sos100.SingleSignOn;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;


namespace ActivoWebPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EventApiService _eventApiService;

        public HomeController(ILogger<HomeController> logger, EventApiService eventApiService)
        {
            _logger = logger;
            _eventApiService = eventApiService;
        }

   public class EventApiService
   {
       private readonly string eventApiUrl = "https://informatik4.ei.hv.se/EVENTAPI2/api/events";

       public async Task<DataTable> GetEventDataAsync()
       {
           DataTable eventDt = new DataTable();
           using (var client = new HttpClient())
           {
               client.BaseAddress = new Uri(eventApiUrl);
               client.DefaultRequestHeaders.Accept.Clear();
               client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

               HttpResponseMessage getData = await client.GetAsync("");

               if (getData.IsSuccessStatusCode)
               {
                   string results = await getData.Content.ReadAsStringAsync();
                   eventDt = JsonConvert.DeserializeObject<DataTable>(results);
               }
               else
               {
                   Console.WriteLine("Error calling the API");
               }
           }
           return eventDt;
       }
   }

        public async Task<IActionResult> Index()
        {
            //Läs in om session finns och skicka till ViewData, allt gör SSO NuGet
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);

            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View();
        }

        public async Task<IActionResult> Search()
        {
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            DataTable eventDt = await _eventApiService.GetEventDataAsync();
            return View(eventDt);
        }
        
        //Logga in
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Authenticate(string email, string password)
        {
            var authenticationService = new AuthenticationService();
            var authenticatedSession = await authenticationService.CreateSession(email, password, controllerBase: this, HttpContext);
            var userRole = HttpContext.Session.GetString("UserRole");

            //Dirigera bara citizens till Activo, de andra till admin (profilsidan för tillfället)
            if (userRole == "Admin" )
            {
                return authenticatedSession ? Redirect("https://informatik7.ei.hv.se/ProfilMVC") : RedirectToAction("Privacy", "Home");
            }
            if (userRole == "Organizer")
            {
                return authenticatedSession ? Redirect("https://informatik7.ei.hv.se/ProfilMVC") : RedirectToAction("Privacy", "Home");
            }
            else
            {
                return authenticatedSession ? RedirectToAction("Index", "Home") : RedirectToAction("Privacy", "Home");
            }
        }


        public IActionResult Logout()
        {
            var authenticationService = new AuthenticationService();
            authenticationService.EndSession(controllerBase: this, HttpContext);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Privacy()
        {
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View();
        }

        public async Task<IActionResult> About()
        {
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View();
        }

        public async Task<IActionResult> Contact()
        {
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
