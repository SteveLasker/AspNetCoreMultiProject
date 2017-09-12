using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using Web.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class CustomerController : Controller
    {
        private string _doSomethingBaseAddress;
        private string _doSomethingAPIUrl;
        public CustomerController()
        {
            _doSomethingBaseAddress = "http://api";
            _doSomethingAPIUrl = "/CustomerApi";

        }
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

                global::Models.Customer cust = new global::Models.Customer();
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
                ViewData["Customer"] = responseString;

            }
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
