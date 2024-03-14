using Microsoft.AspNetCore.Mvc;

namespace ActivoWebPage.Controllers
{
    public class TrollhattanController : Controller
    {
        string apiUrl = "https://informatik4.ei.hv.se/EVENTAPI2/api/events";
        
        //Flikar för Trollhättan
        public async Task<IActionResult> Home()
            {
                //Kalla på API och skickar till view genom en datatabel
                DataTable eventDt = new DataTable();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
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
            return View("~/Views/Trollhattan/Home.cshtml");
        }
        public IActionResult Culture()
        {
            return View("~/Views/Trollhattan/Trollhattan_Culture.cshtml");
        }
        public IActionResult Sports()
        {
            return View("~/Views/Trollhattan/Trollhattan_Sports.cshtml");
        }
        public IActionResult Socializing()
        {
            return View("~/Views/Trollhattan/Trollhattan_Socializing.cshtml");
        }
    }
}

