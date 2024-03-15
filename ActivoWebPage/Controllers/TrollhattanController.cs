using ActivoWebPage.Models;
using Hv.Sos100.SingleSignOn;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
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
            DataTable eventDt = await _eventApiService.GetEventDataAsync();

            return View(eventDt);
        }
        public async Task<IActionResult> EventDetails(int eventId)
        {
            var eventModel = await _eventApiService.GetEventByIdAsync(eventId);
            if (eventModel == null)
            {
                return View("EventNotFound");
            }
           
            /*var placeModel = await _eventApiService.GetPlaceByIdAsync(eventModel.PlacesID);
            if (placeModel == null)
            {
                return View("PlaceNotFound"); 
            }*/

            var viewModel = new EventDetailsViewModel
            {
                Event = eventModel,
                //Place = placeModel
            };
            return View(viewModel);

        }
        public IActionResult ActivityDetails()
        {
            return View("~/Views/Trollhattan/ActivityDetails.cshtml");
        }
    }
}

