using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data.CMS;
using Firma.Data.Data.Kino;

namespace Firma.Intranet.Controllers
{
    public class KomentarzController : Controller
    {
        private readonly FirmaContext _context;

        public KomentarzController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Komentarz
        public async Task<IActionResult> Index()
        {
              return _context.Komentarz != null ? 
                          View(await _context.Komentarz.ToListAsync()) :
                          Problem("Entity set 'FirmaContext.Komentarz'  is null.");
        }

        // GET: Komentarz/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Komentarz == null)
            {
                return NotFound();
            }

            var komentarz = await _context.Komentarz
                .FirstOrDefaultAsync(m => m.IdKomentarza == id);
            if (komentarz == null)
            {
                return NotFound();
            }

            return View(komentarz);
        }

        // GET: Komentarz/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Komentarz/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tresc,DataDodania,Autor,CzyAktywny,KtoDodal,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] Komentarz komentarz)
        {
            if (ModelState.IsValid)
            {
                komentarz.CzyAktywny = true;
                komentarz.KtoDodal = "Admin";
                _context.Add(komentarz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(komentarz);
        }

        // GET: Komentarz/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Komentarz == null)
            {
                return NotFound();
            }

            var komentarz = await _context.Komentarz.FindAsync(id);
            if (komentarz == null)
            {
                return NotFound();
            }
            return View(komentarz);
        }

        // POST: Komentarz/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tresc,DataDodania,Autor,CzyAktywny,KtoDodal,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] Komentarz komentarz)
        {
            if (id != komentarz.IdKomentarza)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(komentarz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KomentarzExists(komentarz.IdKomentarza))
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
            return View(komentarz);
        }

        // GET: Komentarz/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Komentarz == null)
            {
                return NotFound();
            }

            var komentarz = await _context.Komentarz
                .FirstOrDefaultAsync(m => m.IdKomentarza == id);
            if (komentarz == null)
            {
                return NotFound();
            }

            return View(komentarz);
        }

        // POST: Komentarz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Komentarz == null)
            {
                return Problem("Entity set 'FirmaContext.Komentarz'  is null.");
            }
            var komentarz = await _context.Komentarz.FindAsync(id);
            if (komentarz != null)
            {
                _context.Komentarz.Remove(komentarz);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KomentarzExists(int id)
        {
          return (_context.Komentarz?.Any(e => e.IdKomentarza == id)).GetValueOrDefault();
        }
    }
}
