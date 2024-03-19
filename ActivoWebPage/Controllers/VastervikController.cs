using Hv.Sos100.SingleSignOn;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ActivoWebPage.Models;
using static ActivoWebPage.Controllers.HomeController;
using System;


namespace ActivoWebPage.Controllers
{
    public class VastervikController : Controller
    {
        private readonly EventApiService _eventApiService;

        public VastervikController(EventApiService eventApiService)
        {
            _eventApiService = eventApiService;
        }

        //Flikar för Trollhättan
        public async Task<IActionResult> Home()
        {
            //Hämtar data från API och skickar de till view
            var events = await _eventApiService.GetEventDataAsync();
            var activities = await _eventApiService.GetActivityDataAsync();
            var adverts = await _eventApiService.GetAdvertisementDataAsync();

            var filteredActivities = new List<Activity?>();
            var filteredEvent = new List<Event?>();
            var randomAdvert = new Random();

            var advertIds = adverts.Select(ad => ad.advertisementID).ToList();
            int randomIndex = randomAdvert.Next(0, advertIds.Count);
            var randomAdId = advertIds[randomIndex];
            var randomAd = adverts.FirstOrDefault(ad => ad.advertisementID == randomAdId);

            foreach (var activity in activities)
            {
                var place = await _eventApiService.GetPlaceByIdAsync(activity.PlacesID);
                if (place?.City?.Equals("Västervik", StringComparison.OrdinalIgnoreCase) == true)
                {
                    filteredActivities.Add(activity);
                }
            }
            foreach (var ev in events)
            {
                var place = await _eventApiService.GetPlaceByIdAsync(ev.PlacesID);
                if (place?.City?.Equals("Västervik", StringComparison.OrdinalIgnoreCase) == true)
                {
                    filteredEvent.Add(ev);
                }
            }

            var viewModel = new HomeViewModel
            {
                Events = filteredEvent,
                Activities = filteredActivities,
                RandomAdvertisement = randomAd
            };

            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View(viewModel);
        }

        public async Task<IActionResult> CultureAsync()
        {
            //Hämtar data från API och skickar de till view
            var events = await _eventApiService.GetEventDataAsync();
            var activities = await _eventApiService.GetActivityDataAsync();
            var adverts = await _eventApiService.GetAdvertisementDataAsync();

            var filteredActivities = new List<Activity?>();
            var filteredEvent = new List<Event?>();
            var randomAdvert = new Random();

            var advertIds = adverts.Select(ad => ad.advertisementID).ToList();
            int randomIndex = randomAdvert.Next(0, advertIds.Count);
            var randomAdId = advertIds[randomIndex];
            var randomAd = adverts.FirstOrDefault(ad => ad.advertisementID == randomAdId);

            foreach (var activity in activities)
            {
                var place = await _eventApiService.GetPlaceByIdAsync(activity.PlacesID);
                if (place?.City?.Equals("Västervik", StringComparison.OrdinalIgnoreCase) == true)
                {
                    filteredActivities.Add(activity);
                }
            }
            foreach (var ev in events)
            {
                var place = await _eventApiService.GetPlaceByIdAsync(ev.PlacesID);
                if (place?.City?.Equals("Västervik", StringComparison.OrdinalIgnoreCase) == true)
                {
                    filteredEvent.Add(ev);
                }
            }

            var viewModel = new HomeViewModel
            {
                Events = filteredEvent,
                Activities = filteredActivities,
                RandomAdvertisement = randomAd
            };

            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View(viewModel);
        }


        public async Task<IActionResult> SportsAsync()
        {
            //Hämtar data från API och skickar de till view
            var events = await _eventApiService.GetEventDataAsync();
            var activities = await _eventApiService.GetActivityDataAsync();
            var adverts = await _eventApiService.GetAdvertisementDataAsync();

            var filteredActivities = new List<Activity?>();
            var filteredEvent = new List<Event?>();
            var randomAdvert = new Random();

            var advertIds = adverts.Select(ad => ad.advertisementID).ToList();
            int randomIndex = randomAdvert.Next(0, advertIds.Count);
            var randomAdId = advertIds[randomIndex];
            var randomAd = adverts.FirstOrDefault(ad => ad.advertisementID == randomAdId);

            foreach (var activity in activities)
            {
                var place = await _eventApiService.GetPlaceByIdAsync(activity.PlacesID);
                if (place?.City?.Equals("Västervik", StringComparison.OrdinalIgnoreCase) == true)
                {
                    filteredActivities.Add(activity);
                }
            }
            foreach (var ev in events)
            {
                var place = await _eventApiService.GetPlaceByIdAsync(ev.PlacesID);
                if (place?.City?.Equals("Västervik", StringComparison.OrdinalIgnoreCase) == true)
                {
                    filteredEvent.Add(ev);
                }
            }

            var viewModel = new HomeViewModel
            {
                Events = filteredEvent,
                Activities = filteredActivities,
                RandomAdvertisement = randomAd
            };

            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View(viewModel);
        }

        public async Task<IActionResult> SocializingAsync()
        {
            var events = await _eventApiService.GetEventDataAsync();
            var activities = await _eventApiService.GetActivityDataAsync();
            var adverts = await _eventApiService.GetAdvertisementDataAsync();

            var filteredActivities = new List<Activity?>();
            var filteredEvent = new List<Event?>();
            var randomAdvert = new Random();

            var advertIds = adverts.Select(ad => ad.advertisementID).ToList();
            int randomIndex = randomAdvert.Next(0, advertIds.Count);
            var randomAdId = advertIds[randomIndex];
            var randomAd = adverts.FirstOrDefault(ad => ad.advertisementID == randomAdId);

            foreach (var activity in activities)
            {
                var place = await _eventApiService.GetPlaceByIdAsync(activity.PlacesID);
                if (place?.City?.Equals("Västervik", StringComparison.OrdinalIgnoreCase) == true)
                {
                    filteredActivities.Add(activity);
                }
            }
            foreach (var ev in events)
            {
                var place = await _eventApiService.GetPlaceByIdAsync(ev.PlacesID);
                if (place?.City?.Equals("Västervik", StringComparison.OrdinalIgnoreCase) == true)
                {
                    filteredEvent.Add(ev);
                }
            }

            var viewModel = new HomeViewModel
            {
                Events = filteredEvent,
                Activities = filteredActivities,
                RandomAdvertisement = randomAd
            };

            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View(viewModel);
        }

        public async Task<IActionResult> Search()
        {
            // Hämtar alla events och aktiviteter
            var events = await _eventApiService.GetEventDataAsync();
            var activities = await _eventApiService.GetActivityDataAsync();

            var filteredActivities = new List<Activity?>();
            var filteredEvent = new List<Event?>();

            foreach (var activity in activities)
            {
                var place = await _eventApiService.GetPlaceByIdAsync(activity?.PlacesID);
                if (place != null && place.City == "Västervik")
                {
                    filteredActivities.Add(activity);
                }
            }

            foreach (var ev in events)
            {
                var place = await _eventApiService.GetPlaceByIdAsync(ev.PlacesID);
                if (place?.City?.Equals("Västervik", StringComparison.OrdinalIgnoreCase) == true)
                {
                    filteredEvent.Add(ev);
                }
            }

            // Skapar och returnerar viewModel med filtrerade listor
            var viewModel = new HomeViewModel
            {
                Events = filteredEvent,
                Activities = filteredActivities
            };

            return View("Search", viewModel); // Se till att du har en Search-vy som tar emot HomeViewModel
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
                placeModel = new Places
                {
                    Name = "Okänd plats",
                    Address = "Ingen adress tillgänglig"
                };
            }

            var viewModel = new EventDetailsViewModel
            {
                Event = eventModel,
                Place = placeModel
            };

            return View(viewModel);
        }

        public async Task<IActionResult> ActivityDetailsAsync(int activityId)
        {
            var activityModel = await _eventApiService.GetActivityByIdAsync(activityId);
            if (activityModel == null)
            {
                return View("ActivityNotFound");
            }
            var placeModel = await _eventApiService.GetPlaceByIdAsync(activityModel.PlacesID);
            if (placeModel == null)
            {
                return View("PlaceNotFound");
            }

            var viewModel = new EventDetailsViewModel
            {
                Activity = activityModel,
                Place = placeModel
            };

            return View(viewModel);
        }
    }
}
