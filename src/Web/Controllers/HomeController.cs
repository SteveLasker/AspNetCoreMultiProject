using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections;

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
            string hostName;
            // Will only work on Windows
            //hostName = Environment.GetEnvironmentVariable("COMPUTERNAME");

            // Works on both Windows and Linux
            hostName = Environment.GetEnvironmentVariable("COMPUTERNAME") ??
                                Environment.GetEnvironmentVariable("HOSTNAME");

            ViewData["HOSTNAME"] = hostName;


            TimeZoneInfo tzInfo = null;
            // Will only work on Windows
            //tzInfo = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            // Works on both Windows and Linux
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                tzInfo = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            else
                tzInfo = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");

            ViewData["TZINFO"] = tzInfo;

            var OSArchitecture = RuntimeInformation.OSArchitecture;
            ViewData["OSARCHITECTURE"] = OSArchitecture.ToString();

            var OSDescription = RuntimeInformation.OSDescription;
            ViewData["OSDESCRIPTION"] = OSDescription.ToString();

            var ProcessArchitecture = RuntimeInformation.ProcessArchitecture;
            ViewData["PROCESSARCHITECTURE"] = ProcessArchitecture.ToString();

            string FrameworkDescription = RuntimeInformation.FrameworkDescription;
            ViewData["FRAMEWORKDESCRIPTION"] = FrameworkDescription;

            string hostingEnvironment = Environment.GetEnvironmentVariable("Hosting:Environment");
            ViewData["HOSTING_ENVIRONMENT"] = hostingEnvironment;

            StringBuilder envVars = new StringBuilder();
            foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
                envVars.Append(string.Format("<strong>{0}</strong>:{1}<br \\>", de.Key, de.Value));

            ViewData["ENV_VARS"] = envVars.ToString();


            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
