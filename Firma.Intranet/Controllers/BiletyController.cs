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
    public class BiletyController : Controller
    {
        private readonly FirmaContext _context;

        public BiletyController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Bilety
        public async Task<IActionResult> Index()
        {
            var firmaContext = _context.Bilet.Include(b => b.Film);
            return View(await firmaContext.ToListAsync());
        }

        // GET: Bilety/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bilet == null)
            {
                return NotFound();
            }

            var bilet = await _context.Bilet
                .Include(b => b.Film)
                .FirstOrDefaultAsync(m => m.IdBiletu == id);
            if (bilet == null)
            {
                return NotFound();
            }

            return View(bilet);
        }

        // GET: Bilety/Create
        public IActionResult Create()
        {
            ViewData["FilmId"] = new SelectList(_context.Filmy, "IdFilmu", "Gatunek");
            return View();
        }

        // POST: Bilety/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBiletu,FilmId,NumerSiedzenia,DataProjekcji,ZarezerwowanyPrzez,CzyAktywny,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] Bilet bilet)
        {
            if (ModelState.IsValid)
            {
                bilet.CzyAktywny = true;
                _context.Add(bilet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmId"] = new SelectList(_context.Filmy, "IdFilmu", "Gatunek", bilet.FilmId);
            return View(bilet);
        }

        // GET: Bilety/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bilet == null)
            {
                return NotFound();
            }

            var bilet = await _context.Bilet.FindAsync(id);
            if (bilet == null)
            {
                return NotFound();
            }
            ViewData["FilmId"] = new SelectList(_context.Filmy, "IdFilmu", "Gatunek", bilet.FilmId);
            return View(bilet);
        }

        // POST: Bilety/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBiletu,FilmId,NumerSiedzenia,DataProjekcji,ZarezerwowanyPrzez,CzyAktywny,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] Bilet bilet)
        {
            if (id != bilet.IdBiletu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bilet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiletExists(bilet.IdBiletu))
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
            ViewData["FilmId"] = new SelectList(_context.Filmy, "IdFilmu", "Gatunek", bilet.FilmId);
            return View(bilet);
        }

        // GET: Bilety/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bilet == null)
            {
                return NotFound();
            }

            var bilet = await _context.Bilet
                .Include(b => b.Film)
                .FirstOrDefaultAsync(m => m.IdBiletu == id);
            if (bilet == null)
            {
                return NotFound();
            }

            return View(bilet);
        }

        // POST: Bilety/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bilet == null)
            {
                return Problem("Entity set 'FirmaContext.Bilet'  is null.");
            }
            var bilet = await _context.Bilet.FindAsync(id);
            if (bilet != null)
            {
                _context.Bilet.Remove(bilet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiletExists(int id)
        {
          return (_context.Bilet?.Any(e => e.IdBiletu == id)).GetValueOrDefault();
        }
    }
}
