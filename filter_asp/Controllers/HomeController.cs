using filter_asp.Models;
using filter_asp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace filter_asp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ServiceFilter(typeof(LogActionFilter))]
        public IActionResult Index()
        {
            return View();
        }

        [ServiceFilter(typeof(LogActionFilter))]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
