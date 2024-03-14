using Hv.Sos100.SingleSignOn;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;

namespace ActivoWebPage.Controllers
{
    public class TrollhattanController : Controller
    {
        string eventApiUrl = "https://informatik4.ei.hv.se/EVENTAPI2/api/events";

        //Flikar för Trollhättan
        public async Task<IActionResult> Home()
        {
            //Kalla på API och skickar till view genom en datatabel
            DataTable eventDt = new DataTable();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(eventApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await client.GetAsync("");

                //Installera Newtonsoft.Json paketet
                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    eventDt = JsonConvert.DeserializeObject<DataTable>(results);
                }
                else
                {
                    Console.WriteLine("Error calling the API");
                }

                ViewData.Model = eventDt;
            }

            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);

            return View("~/Views/Trollhattan/Home.cshtml");
        }

        public async Task<IActionResult> CultureAsync()
        {
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);
            return View("~/Views/Trollhattan/Trollhattan_Culture.cshtml");
        }
        public async Task<IActionResult> SportsAsync()
        {
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);
            return View("~/Views/Trollhattan/Trollhattan_Sports.cshtml");
        }
        public async Task<IActionResult> SocializingAsync()
        {
            var authenticationService = new AuthenticationService();
            var existingSession = await authenticationService.ResumeSession(controllerBase: this, HttpContext);
            authenticationService.ReadSessionVariables(controller: this, httpContext: HttpContext);
            return View("~/Views/Trollhattan/Trollhattan_Socializing.cshtml");
        }
    }
}

