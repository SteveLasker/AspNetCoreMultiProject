using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_UI.Controllers
{
    public class Magic8BallController : Controller
    {
        private string _doSomethingBaseAddress;
        private string _doSomethingAPIUrl;
        public Magic8BallController()
        {
            _doSomethingBaseAddress = "http://api";
            _doSomethingAPIUrl = "/Magic8BallApi";
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = null;
            //
            // Get the HttpRequest
            //
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request =
                    new HttpRequestMessage(HttpMethod.Get, 
                        _doSomethingBaseAddress + _doSomethingAPIUrl);

                response = await client.SendAsync(request);
            }
            catch (Exception)
            {
                // eat the exception for now...
            }

            //
            // Return a response from the Crazy 8 Ball Service
            //
            if (response != null && response.IsSuccessStatusCode)
            {
                List<Dictionary<String, String>> responseElements = new List<Dictionary<String, String>>();
                JsonSerializerSettings settings = new JsonSerializerSettings();
                String responseString = await response.Content.ReadAsStringAsync();
                ViewData["Answer"] = responseString;

            }
            return View();
        }
    }
}
