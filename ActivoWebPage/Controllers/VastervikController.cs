using Hv.Sos100.SingleSignOn;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static ActivoWebPage.Controllers.HomeController;

namespace ActivoWebPage.Controllers
{
    public class VastervikController : Controller
    {
        private readonly EventApiService _eventApiService;

        public VastervikController(EventApiService eventApiService)
        {
            _eventApiService = eventApiService;
        }
        
        //Flikar för Västervik
        public async Task<IActionResult> HomeAsync()
        {
            //Hämtar API-datatable 
            DataTable eventDt = await _eventApiService.GetEventDataAsync();
        
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);
            return View("~/Views/Vastervik/Home.cshtml", eventDt);
        }
        
        public async Task<IActionResult> CultureAsync()
        {
            //Hämtar API-datatable 
            DataTable eventDt = await _eventApiService.GetEventDataAsync();
            
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);
            return View("~/Views/Vastervik/Vastervik_Culture.cshtml", eventDt);
        }
        public async Task<IActionResult> SportsAsync()
        {
            //Hämtar API-datatable 
            DataTable eventDt = await _eventApiService.GetEventDataAsync();
            
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);
            return View("~/Views/Vastervik/Vastervik_Sports.cshtml", eventDt);
        }
        public async Task<IActionResult> SocializingAsync()
        {
            //Hämtar API-datatable 
            DataTable eventDt = await _eventApiService.GetEventDataAsync();
            
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);
            return View("~/Views/Vastervik/Vastervik_Socializing.cshtml", eventDt);
        }
    }
}

