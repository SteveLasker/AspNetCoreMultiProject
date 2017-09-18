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

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            // Debugging Information 
            ViewData["Message"] = "Debugging Info.";

            ViewData["HOSTNAME"] = Environment.GetEnvironmentVariable("COMPUTERNAME") ??
                                            Environment.GetEnvironmentVariable("HOSTNAME");
            ViewData["OSARCHITECTURE"] = RuntimeInformation.OSArchitecture;
            ViewData["OSDESCRIPTION"] = RuntimeInformation.OSDescription;
            ViewData["PROCESSARCHITECTURE"] = RuntimeInformation.ProcessArchitecture;
            ViewData["FRAMEWORKDESCRIPTION"] = RuntimeInformation.FrameworkDescription;
            ViewData["ASPNETCOREPACKAGEVERSION"] = Environment.GetEnvironmentVariable("ASPNETCORE_PKG_VERSION");
            ViewData["ASPNETCORE_ENVIRONMENT"] = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            StringBuilder envVars = new StringBuilder();
            foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
                envVars.Append(string.Format("<strong>{0}</strong>:{1}<br \\>", de.Key, de.Value));

            ViewData["ENV_VARS"] = envVars.ToString();

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
