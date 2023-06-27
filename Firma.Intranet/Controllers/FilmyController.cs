using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data;
using Firma.Data.Data.Kino;

namespace Firma.Intranet.Controllers
{
    public class FilmyController : Controller
    {
        private readonly FirmaContext _context;

        public FilmyController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Filmy
        public async Task<IActionResult> Index()
        {
              return _context.Filmy != null ? 
                          View(await _context.Filmy.ToListAsync()) :
                          Problem("Entity set 'FirmaContext.Filmy'  is null.");
        }

        // GET: Filmy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Filmy == null)
            {
                return NotFound();
            }

            var filmy = await _context.Filmy
                .FirstOrDefaultAsync(m => m.IdFilmu == id);
            if (filmy == null)
            {
                return NotFound();
            }

            return View(filmy);
        }

        // GET: Filmy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filmy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFilmu,Tytuł,Opis,DataPremiery,Rezyser,Dlugosc,Gatunek,LinkDoZwiastunu,OdKiedyGrany,DoKiedyGrany,Zdjecie,GodzinyGrania,CzyAktywny,KtoDodal,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] Filmy filmy)
        {
            //if (ModelState.IsValid)
            //{
                filmy.CzyAktywny = true;
                filmy.KtoDodal = "Admin";
                _context.Add(filmy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            
            return View(filmy);
        }

        // GET: Filmy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Filmy == null)
            {
                return NotFound();
            }

            var filmy = await _context.Filmy.FindAsync(id);
            if (filmy == null)
            {
                return NotFound();
            }
            return View(filmy);
        }

        // POST: Filmy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFilmu,Tytuł,Opis,DataPremiery,Rezyser,Dlugosc,Gatunek,LinkDoZwiastunu,OdKiedyGrany,DoKiedyGrany,Zdjecie,GodzinyGrania,CzyAktywny,KtoDodal,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] Filmy filmy)
        {
            if (id != filmy.IdFilmu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmyExists(filmy.IdFilmu))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(filmy);
        }

        // GET: Filmy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Filmy == null)
            {
                return NotFound();
            }

            var filmy = await _context.Filmy
                .FirstOrDefaultAsync(m => m.IdFilmu == id);
            if (filmy == null)
            {
                return NotFound();
            }

            return View(filmy);
        }

        // POST: Filmy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Filmy == null)
            {
                return Problem("Entity set 'FirmaContext.Filmy'  is null.");
            }
            var filmy = await _context.Filmy.FindAsync(id);
            if (filmy != null)
            {
                _context.Filmy.Remove(filmy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmyExists(int id)
        {
          return (_context.Filmy?.Any(e => e.IdFilmu == id)).GetValueOrDefault();
        }
    }
}
