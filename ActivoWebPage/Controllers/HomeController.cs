using ActivoWebPage.Models;
using Hv.Sos100.SingleSignOn;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;


namespace ActivoWebPage.Controllers
{


    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       
        private readonly ActivitiesApiService _activitiesApiService;
        private readonly EventApiService _eventApiService;

        public HomeController(ILogger<HomeController> logger, ActivitiesApiService activitiesApiService, EventApiService eventApiService)
        {
            _logger = logger;
            _activitiesApiService = activitiesApiService;
            _eventApiService = eventApiService;

        }

        public class EventApiService
        {
            private readonly IHttpClientFactory _httpClientFactory;
            private readonly string _eventApiUrl = "https://informatik4.ei.hv.se/EVENTAPI2/api/events";
            private readonly string _placeApiUrl = "https://informatik8.ei.hv.se/Places_API/api/Places";
            private readonly ILogger<EventApiService> _logger;


            public EventApiService(IHttpClientFactory httpClientFactory, ILogger<EventApiService> logger)
            {
                _httpClientFactory = httpClientFactory;
                _logger = logger;
            }
            public async Task<Event> GetEventByIdAsync(int eventId)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"{_eventApiUrl}/{eventId}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Event>(jsonString);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // Handle not found
                    return null;
                }
                else
                {
                    // Log unexpected error
                    _logger.LogError($"Failed to fetch event data. Status code: {response.StatusCode}");
                    return null;
                }
            }

           /* public async Task<EventDetailsViewModel> GetEventDetailsAsync(int eventId)
            {
                var eventDetails = await GetEventByIdAsync(eventId);
                if (eventDetails == null)
                {
                    throw new Exception("Event not found");
                }

                var placeDetails = await GetPlaceByIdAsync(eventDetails.PlacesID);
                if (placeDetails == null)
                {
                    throw new Exception("Place not found");
                }

                return new EventDetailsViewModel
                {
                    Event = eventDetails,
                    Place = placeDetails
                };
            }*/

            /*public async Task<Places> GetPlaceByIdAsync(int placesId)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"{_placeApiUrl}/{placesId}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Places>(jsonString);
                }
                else
                {
                    _logger.LogError($"Failed to fetch place data for PlaceID {placesId}. Status code: {response.StatusCode}");
                    return null; // Return null instead of throwing an exception
                }
            }*/


            public async Task<DataTable> GetEventDataAsync()
            {
                DataTable eventDt = new DataTable();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_eventApiUrl);
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

         public class ActivitiesApiService
        {
            private readonly string activitiesApiUrl = "https://informatik1.ei.hv.se/ActivityAPI/api/Activities";

            public async Task<DataTable> GetActivitiesDataAsync()
            {
                DataTable activitiesDt = new DataTable();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(activitiesApiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage getData = await client.GetAsync("");

                    if (getData.IsSuccessStatusCode)
                    {
                        string results = await getData.Content.ReadAsStringAsync();
                        activitiesDt = JsonConvert.DeserializeObject<DataTable>(results);
                    }
                    else
                    {
                        Console.WriteLine("Error calling the API");
                    }
                }
                return activitiesDt;
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
            DataTable activitiesDt = await _activitiesApiService.GetActivitiesDataAsync();
            DataTable eventDt = await _eventApiService.GetEventDataAsync();

            var viewModel = new CollectionViewModel
            {
                ActivitiesDt = activitiesDt,
                EventDt = eventDt
            };

            return View(viewModel);
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
            return authenticatedSession ? RedirectToAction("Index", "Home") : RedirectToAction("Privacy", "Home");
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

        public async Task<IActionResult> FetchEvents()
        {
            var events = await _eventApiService.GetEventDataAsync();
            return View("Home", "Trollhattan");
        }
    }
}
