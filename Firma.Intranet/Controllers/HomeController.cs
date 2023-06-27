using Firma.Intranet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Firma.Intranet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Posty()
        {
            return View();
        }
        public IActionResult Kategorie()
        {
            return View();
        }
        public IActionResult Komentarze()
        {
            return View();
        }
        public IActionResult Uzytkownicy()
        {
            return View();
        }
        public IActionResult Szczegoly()
        {
            return View();
        }
        public IActionResult Filmy()
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