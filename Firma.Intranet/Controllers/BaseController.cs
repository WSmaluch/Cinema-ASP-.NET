using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;

namespace Firma.Intranet.Controllers
{
    public class BaseController : Controller
    {
        protected readonly FirmaContext _context;
        public BaseController(FirmaContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }

    }
}
