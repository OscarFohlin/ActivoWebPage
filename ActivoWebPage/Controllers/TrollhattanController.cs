using ActivoWebPage.Models;
using Hv.Sos100.SingleSignOn;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using static ActivoWebPage.Controllers.HomeController;
using Activity = ActivoWebPage.Models.Activity;
using System;

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
            var events = await _eventApiService.GetEventDataAsync();
            var activities = await _eventApiService.GetActivityDataAsync();
            //random test
            var adverts = await _eventApiService.GetAdvertisementDataAsync();

            var filteredActivities = new List<Activity?>();
            var filteredEvent = new List<Event?>();
            //random test
            var randomAdvert = new Random();

            //random test
            var advertIds = adverts.Select(ad => ad.advertisementID).ToList();
            int randomIndex = randomAdvert.Next(0, advertIds.Count);
            var randomAdId = advertIds[randomIndex];
            var randomAd = adverts.FirstOrDefault(ad => ad.advertisementID == randomAdId);

            foreach (var activity in activities)
            {
                var place = await _eventApiService.GetPlaceByIdAsync(activity.PlacesID);
                if (place?.City?.Equals("Trollhättan", StringComparison.OrdinalIgnoreCase) == true)
                {
                    filteredActivities.Add(activity);
                }
            }
            foreach (var ev in events)
            {
                var place = await _eventApiService.GetPlaceByIdAsync(ev.PlacesID);
                if (place?.City?.Equals("Trollhättan", StringComparison.OrdinalIgnoreCase) == true)
                {
                    filteredEvent.Add(ev);
                }
            }

            var viewModel = new HomeViewModel
            {
                Events = filteredEvent,
                Activities = filteredActivities,
                //random test
                RandomAdvertisement = randomAd
            };

            return View(viewModel);
        }

        public async Task<IActionResult> CultureAsync()
        {
            var events = await _eventApiService.GetEventDataAsync();
            var activities = await _eventApiService.GetActivityDataAsync();
            var adverts = await _eventApiService.GetAdvertisementDataAsync();

            var filteredActivities = new List<Activity?>();
            var filteredEvent = new List<Event?>();
            //random test
            var randomAdvert = new Random();

            //random test
            var advertIds = adverts.Select(ad => ad.advertisementID).ToList();
            int randomIndex = randomAdvert.Next(0, advertIds.Count);
            var randomAdId = advertIds[randomIndex];
            var randomAd = adverts.FirstOrDefault(ad => ad.advertisementID == randomAdId);

            foreach (var activity in activities)
            {
                var place = await _eventApiService.GetPlaceByIdAsync(activity.PlacesID);
                if (place?.City?.Equals("Trollhättan", StringComparison.OrdinalIgnoreCase) == true)
                {
                    filteredActivities.Add(activity);
                }
            }
            foreach (var ev in events)
            {
                var place = await _eventApiService.GetPlaceByIdAsync(ev.PlacesID);
                if (place?.City?.Equals("Trollhättan", StringComparison.OrdinalIgnoreCase) == true)
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
            var events = await _eventApiService.GetEventDataAsync();
            var activities = await _eventApiService.GetActivityDataAsync();
            var adverts = await _eventApiService.GetAdvertisementDataAsync();

            var filteredActivities = new List<Activity?>();
            var filteredEvent = new List<Event?>();
            //random test
            var randomAdvert = new Random();

            //random test
            var advertIds = adverts.Select(ad => ad.advertisementID).ToList();
            int randomIndex = randomAdvert.Next(0, advertIds.Count);
            var randomAdId = advertIds[randomIndex];
            var randomAd = adverts.FirstOrDefault(ad => ad.advertisementID == randomAdId);

            foreach (var activity in activities)
            {
                var place = await _eventApiService.GetPlaceByIdAsync(activity.PlacesID);
                if (place?.City?.Equals("Trollhättan", StringComparison.OrdinalIgnoreCase) == true)
                {
                    filteredActivities.Add(activity);
                }
            }
            foreach (var ev in events)
            {
                var place = await _eventApiService.GetPlaceByIdAsync(ev.PlacesID);
                if (place?.City?.Equals("Trollhättan", StringComparison.OrdinalIgnoreCase) == true)
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
            //random test
            var randomAdvert = new Random();

            //random test
            var advertIds = adverts.Select(ad => ad.advertisementID).ToList();
            int randomIndex = randomAdvert.Next(0, advertIds.Count);
            var randomAdId = advertIds[randomIndex];
            var randomAd = adverts.FirstOrDefault(ad => ad.advertisementID == randomAdId);

            foreach (var activity in activities)
            {
                var place = await _eventApiService.GetPlaceByIdAsync(activity.PlacesID);
                if (place?.City?.Equals("Trollhättan", StringComparison.OrdinalIgnoreCase) == true)
                {
                    filteredActivities.Add(activity);
                }
            }
            foreach (var ev in events)
            {
                var place = await _eventApiService.GetPlaceByIdAsync(ev.PlacesID);
                if (place?.City?.Equals("Trollhättan", StringComparison.OrdinalIgnoreCase) == true)
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
            var events = await _eventApiService.GetEventDataAsync();
            var activities = await _eventApiService.GetActivityDataAsync();

            var filteredActivities = new List<Activity?>();
            var filteredEvent = new List<Event?>();

            foreach (var activity in activities)
            {
                var place = await _eventApiService.GetPlaceByIdAsync(activity.PlacesID);
                if (place?.City?.Equals("Trollhättan", StringComparison.OrdinalIgnoreCase) == true)
                {
                    filteredActivities.Add(activity);
                }
            }
            foreach (var ev in events)
            {
                var place = await _eventApiService.GetPlaceByIdAsync(ev.PlacesID);
                if (place?.City?.Equals("Trollhättan", StringComparison.OrdinalIgnoreCase) == true)
                {
                    filteredEvent.Add(ev);
                }
            }

            var viewModel = new HomeViewModel
            {
                Events = filteredEvent,
                Activities = filteredActivities
            };
            return View("Search", viewModel);
        }


        public async Task<IActionResult> EventDetails(int EventID)
        {
            var eventModel = await _eventApiService.GetEventByIdAsync(EventID);
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

        public async Task<IActionResult> ActivityDetails(int activityID)
        {
            var activityModel = await _eventApiService.GetActivityByIdAsync(activityID);
            if (activityModel == null)
            {
                return View("ActivityNotFound");
            }

            var placeModel = await _eventApiService.GetPlaceByIdAsync(activityModel.PlacesID);
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
                Activity = activityModel,
                Place = placeModel
            };

            return View(viewModel);
        }


    }
}

