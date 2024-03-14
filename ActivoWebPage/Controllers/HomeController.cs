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
            DataTable eventDt = await _eventApiService.GetEventDataAsync();
            return View(eventDt);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
