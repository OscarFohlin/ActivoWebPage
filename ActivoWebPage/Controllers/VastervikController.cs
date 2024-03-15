using Hv.Sos100.SingleSignOn;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ActivoWebPage.Models;
using static ActivoWebPage.Controllers.HomeController;


namespace ActivoWebPage.Controllers
{
    public class VastervikController : Controller
    {

        private readonly EventApiService _eventApiService;
        private readonly ActivitiesApiService _activitiesApiService;

        public VastervikController(ActivitiesApiService activitiesApiService, EventApiService eventApiService)
        {
            _eventApiService = eventApiService;
            _activitiesApiService = activitiesApiService;
        }

        //Flikar för Västervik
        public async Task<IActionResult> HomeAsync()
        {
            //Hämtar data från API och skickar de till view
            DataTable activitiesDt = await _activitiesApiService.GetActivitiesDataAsync();
            DataTable eventDt = await _eventApiService.GetEventDataAsync();

            var viewModel = new CollectionViewModel
            {
                ActivitiesDt = activitiesDt,
                EventDt = eventDt
            };

            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View(viewModel);
        }

        public async Task<IActionResult> CultureAsync()
        {
            //Hämtar data från API och skickar de till view
            DataTable activitiesDt = await _activitiesApiService.GetActivitiesDataAsync();
            DataTable eventDt = await _eventApiService.GetEventDataAsync();

            var viewModel = new CollectionViewModel
            {
                ActivitiesDt = activitiesDt,
                EventDt = eventDt
            };

            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View(viewModel);
        }
        public async Task<IActionResult> SportsAsync()
        {
            //Hämtar data från API och skickar de till view
            DataTable activitiesDt = await _activitiesApiService.GetActivitiesDataAsync();
            DataTable eventDt = await _eventApiService.GetEventDataAsync();

            var viewModel = new CollectionViewModel
            {
                ActivitiesDt = activitiesDt,
                EventDt = eventDt
            };

            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View(viewModel);
        }
        public async Task<IActionResult> SocializingAsync()
        {
            //Hämtar data från API och skickar de till view
            DataTable activitiesDt = await _activitiesApiService.GetActivitiesDataAsync();
            DataTable eventDt = await _eventApiService.GetEventDataAsync();

            var viewModel = new CollectionViewModel
            {
                ActivitiesDt = activitiesDt,
                EventDt = eventDt
            };

            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View(viewModel);
        }

        public async Task<IActionResult> Search()
        {

            DataTable activitiesDt = await _activitiesApiService.GetActivitiesDataAsync();
            DataTable eventDt = await _eventApiService.GetEventDataAsync();

            var viewModel = new CollectionViewModel
            {
                ActivitiesDt = activitiesDt,
                EventDt = eventDt
            };

            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View(viewModel);
        }
    }
}


