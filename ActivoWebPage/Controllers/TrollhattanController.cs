using Hv.Sos100.SingleSignOn;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static ActivoWebPage.Controllers.HomeController;

namespace ActivoWebPage.Controllers
{
    public class TrollhattanController : Controller
    {
        private readonly EventApiService _eventApiService;

        public TrollhattanController(EventApiService eventApiService)
        {
            _eventApiService = eventApiService;
        }
        //Flikar för Trollhättan
        public async Task<IActionResult> Home()
        {
        
        //Hämtar data från API och skickar de till view
            DataTable eventDt = await _eventApiService.GetEventDataAsync();
            
            
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View("~/Views/Trollhattan/Home.cshtml", eventDt);
        }

        public async Task<IActionResult> CultureAsync()
        {
            //Hämtar data från API och skickar de till view
            DataTable eventDt = await _eventApiService.GetEventDataAsync();
            
        
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);
            return View("~/Views/Trollhattan/Trollhattan_Culture.cshtml", eventDt);
        }

        
        public async Task<IActionResult> SportsAsync()
        {
        //Hämtar data från API och skickar de till view
         DataTable eventDt = await _eventApiService.GetEventDataAsync();
         
         
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);
            return View("~/Views/Trollhattan/Trollhattan_Sports.cshtml", eventDt);
        }
        public async Task<IActionResult> SocializingAsync()
        {
            DataTable eventDt = await _eventApiService.GetEventDataAsync();
        
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);
            return View("~/Views/Trollhattan/Trollhattan_Socializing.cshtml", eventDt);
        }
        
        public async Task<IActionResult> Search()
        {
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            DataTable eventDt = await _eventApiService.GetEventDataAsync();

            return View(eventDt);
        }
    }
}

