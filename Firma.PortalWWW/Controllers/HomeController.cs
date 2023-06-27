using Firma.Data.Data;
using Firma.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Firma.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly FirmaContext _context;


        public HomeController(FirmaContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            var dzis = DateTime.Today;
            ViewBag.ModelFilm = (
                from film in _context.Filmy
                where film.OdKiedyGrany <= dzis && film.DoKiedyGrany >= dzis
                select film
            ).ToList();

            ViewBag.ModelFilmNadchodzace = (
                 from film in _context.Filmy
                 where film.OdKiedyGrany > dzis && film.DoKiedyGrany > dzis
                 select film
                ).ToList();

            ViewBag.ModelStrony =
                (
                   from strona in _context.Strona
                   where strona.CzyAktywny==true
                   orderby strona.Pozycja
                   select strona
                ).ToList();
            ViewBag.ModelBlog = (
                from post in _context.Posty
                orderby post.KiedyDodal descending
                select post
            ).ToList();
            ViewBag.ModelBlog = (
                from post in _context.Posty
                orderby post.KiedyDodal descending
                select post
                ).ToList();
            ViewBag.ModelStronyGlownej = (
                from banner in _context.StronaGlowna
                orderby banner.KiedyDodal descending
                select banner
                ).ToList();
            if (id == null)
                id = _context.Strona.First().IdStrony;
            var item = _context.Strona.Find(id);
            return View(item);
        }

        public IActionResult Privacy()
        {
            var prywatosc = _context.Prywatnosc!.FirstOrDefault();
            return View(prywatosc);
        }
        public IActionResult ONas()
        {
            var onas = _context.ONas!.FirstOrDefault();
            return View(onas);
        }
        public IActionResult Repertuar()
        {
            return View();
        }
        public IActionResult Oferty(int? id)
        {
            var oferty = _context.Oferty.OrderByDescending(o => o.KiedyDodal);
            return View(oferty);
        }

        public IActionResult Blog()
        {
            var blog = _context.Posty.OrderByDescending(o => o.KiedyDodal); ;

            return View(blog);
        }

        public IActionResult Prezenty()
        {
            var prezenty = _context.Prezenty.OrderByDescending(o => o.KiedyDodal); ;

            return View(prezenty);
        }
        public IActionResult Logowanie()
        {
            return View();
        }
        public IActionResult Rejestracja()
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