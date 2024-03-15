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
        private readonly ActivitiesApiService _activitiesApiService;
        private readonly PlacesApiService _placesApiService;

        public TrollhattanController(ActivitiesApiService activitiesApiService, EventApiService eventApiService, PlacesApiService placesApiService)
        {
            _eventApiService = eventApiService;
            _activitiesApiService = activitiesApiService;
            _placesApiService = placesApiService;
        }

        //Flikar för Trollhättan
        public async Task<IActionResult> Home()
        {
            //Hämtar data från API och skickar de till view
            DataTable activitiesDt = await _activitiesApiService.GetActivitiesDataAsync();
            DataTable eventDt = await _eventApiService.GetEventDataAsync();
            DataTable placesDt = await _placesApiService.GetPlacesDataAsync();

            var viewModel = new CollectionViewModel
            {
                ActivitiesDt = activitiesDt,
                EventDt = eventDt,
                PlacesDt = placesDt
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
        
       public async Task<IActionResult> EventDetails(int eventId)
 {
     var eventModel = await _eventApiService.GetEventByIdAsync(eventId);
     if (eventModel == null)
     {
         return View("EventNotFound");
     }

     var placeModel = await _eventApiService.GetPlaceByIdAsync(eventModel.PlacesID);
     if (placeModel == null)
     {
         return View("PlaceNotFound");
     }

     var viewModel = new EventDetailsViewModel
     {
         Event = eventModel,
         Place = placeModel
     };

     return View(viewModel);
 }


 public IActionResult ActivityDetails()
 {
     return View("~/Views/Trollhattan/ActivityDetails.cshtml");
 }
        public async Task<IActionResult> ActivityDetailsAsync()
        {
            DataTable activitiesDt = await _activitiesApiService.GetActivitiesDataAsync();


            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View(activitiesDt);
        }
    }
}

