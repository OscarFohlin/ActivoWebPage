using ActivoWebPage.Models;
using Hv.Sos100.SingleSignOn;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using Hv.Sos100.Logger;
using static ActivoWebPage.Controllers.HomeController;
using Activity = ActivoWebPage.Models.Activity;
using static Hv.Sos100.Logger.LogService;
using System;


namespace ActivoWebPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly EventApiService _eventApiService;
        public HomeController(EventApiService eventApiService)
        {
            _eventApiService = eventApiService;        }

        public class EventApiService
        {
            private readonly IHttpClientFactory _httpClientFactory;
            private readonly string _eventApiUrl = "https://informatik4.ei.hv.se/EVENTAPI2/api/events";
            private readonly string _placeApiUrl = "https://informatik8.ei.hv.se/Places_API2/api/Places";
            private readonly string _activityApiUrl = "https://informatik1.ei.hv.se/ActivityAPI/api/Activities";
            private readonly string _advertisementApiUrl = "https://informatik6.ei.hv.se/advertisement/api/Ads/horizontal";
            private readonly string _tagApiUrl = "https://informatik1.ei.hv.se/ActivityAPI/api/Tags";
            private readonly ILogger<EventApiService> _logger;

            public EventApiService(IHttpClientFactory httpClientFactory, ILogger<EventApiService> logger)
            {
                _httpClientFactory = httpClientFactory;
                _logger = logger;
            }

            public async Task<Event?> GetEventByIdAsync(int EventID)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"{_eventApiUrl}/{EventID}");

                try
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Event>(jsonString);
                }
                catch (Exception ex)
                {
                    var logger = new LogService();

                    await logger.CreateLog("Eventivo_Website", ex);
                    _logger.LogError($"Failed to fetch event data. Status code: {response.StatusCode}");
                    return null;
                }
            }

            public async Task<Places?> GetPlaceByIdAsync(int? placeId)
            {
                if (!placeId.HasValue)
                {
                    _logger.LogError("PlaceID is null");
                    return null;
                }

                var client = _httpClientFactory.CreateClient();
                try
                {
                    var response = await client.GetAsync($"{_placeApiUrl}/{placeId.Value}");
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<Places>(jsonString);
                    }
                    else
                    {
                        _logger.LogError($"Failed to fetch place data for PlaceID {placeId}. Status code: {response.StatusCode}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Exception occurred when fetching place data for PlaceID {placeId}: {ex.Message}");
                    return null;
                }
            }

            public async Task<Activity?> GetActivityByIdAsync(int activityID)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"{_activityApiUrl}/{activityID}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Activity>(jsonString);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    _logger.LogError($"Failed to fetch activity data. Status code: {response.StatusCode}");
                    return null;
                }
            }

            public async Task<List<Activity?>> GetActivityDataAsync()
            {
                List<Activity?> activities = new List<Activity?>();
                using (var client = _httpClientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(_activityApiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("");

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        activities = JsonConvert.DeserializeObject<List<Activity?>>(result);
                    }
                    else
                    {
                        _logger.LogError("Error calling the Activities API");
                    }
                }
                return activities;
            }

            

            //random test
            public async Task<List<Advertisements>> GetAdvertisementDataAsync()
            {
                List<Advertisements> adverts = new List<Advertisements>();
                using (var client = _httpClientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(_advertisementApiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("");

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();

                        var advert = JsonConvert.DeserializeObject<Advertisements>(result);
                        adverts.Add(advert);
                    }
                    else
                    {
                        _logger.LogError("Error displaying ads or someth");
                    }
                    return adverts;
                }
            }

            public async Task<List<Event>> GetEventDataAsync()
            {
                List<Event> events = new List<Event>();
                using (var client = _httpClientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(_eventApiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("");

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        events = JsonConvert.DeserializeObject<List<Event>>(result);
                    }
                    else
                    {
                        _logger.LogError("Error calling the Events API");
                    }
                }
                return events;
            }

            public async Task<List<Tag>> GetTags()
            {
                List<Tag> tags = new List<Tag>();
                using (var client = _httpClientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(_tagApiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("");

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        tags = JsonConvert.DeserializeObject<List<Tag>>(result); // Assign deserialized tags to the tags list
                    }
                    else
                    {
                        _logger.LogError("Error");
                    }
                    return tags;
                }
            }
        }


        public async Task<IActionResult> FetchEvents()
        {
            var events = await _eventApiService.GetEventDataAsync();
            return View("Home", "Trollhattan");
        }

        public async Task<IActionResult> FetchAdvertisements(int advertisementID)
        {
            var adverts = await _eventApiService.GetAdvertisementDataAsync();
            return View();
        }

        //View
        public async Task<IActionResult?> Index()
        {
            var events = await _eventApiService.GetEventDataAsync(); 
            var activities = await _eventApiService.GetActivityDataAsync();

            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            var viewModel = new HomeViewModel
            {
                Events = events,
                Activities = activities
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Search()
        {
            var events = await _eventApiService.GetEventDataAsync();
            var activities = await _eventApiService.GetActivityDataAsync();
            var tags = await _eventApiService.GetTags();

            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);


            var viewModel = new HomeViewModel
            {
                Events = events,
                Activities = activities,
                Tags = tags
            };

            return View(viewModel); 
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

            Console.WriteLine(email, password, userRole);

            //Dirigera bara citizens till Activo, de andra till admin (profilsidan för tillfället)
            if (userRole == "Admin")
            {
                return authenticatedSession ? Redirect("https://informatik4.ei.hv.se/EVENTADMIN") : RedirectToAction("Index", "Home");
            }
            else if (userRole == "Organizer")
            {
                return authenticatedSession ? Redirect("https://informatik4.ei.hv.se/EVENTADMIN") : RedirectToAction("Index", "Home");
            }
            else
            {
                return authenticatedSession ? RedirectToAction("Index", "Home") : RedirectToAction("Index", "Home");
            }
        }



        public IActionResult Logout()
        {
            var authenticationService = new AuthenticationService();
            authenticationService.EndSession(controllerBase: this, HttpContext);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> PrivacyAsync()
        {
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View();
        }

        public async Task<IActionResult> AboutAsync()
        {
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View();
        }

        public async Task<IActionResult> ContactAsync()
        {
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
