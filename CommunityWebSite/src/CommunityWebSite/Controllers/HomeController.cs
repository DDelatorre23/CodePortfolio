using System;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CommunityWebSite.Controllers {
    public class HomeController : Controller
    {
        public IActionResult Index() {
            ViewBag.Today = DateTime.Today;
            return View();
        }

        public IActionResult About() {
            ViewData["Message"] = "Author Information";

            return View();
        }

        [Route("Home/About/Contact")]
        public IActionResult Contact() {
            ViewData["Message"] = "Harrisburg City Hall contact page.";

            return View();
        }

        public IActionResult History() {
            ViewData["Message"] = "History of Harrisburg";
            return View();
        }
    }
}
