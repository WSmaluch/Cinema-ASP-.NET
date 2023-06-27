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
    public class SzczegolyController : Controller
    {
        private readonly FirmaContext _context;

        public SzczegolyController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Szczegoly
        public async Task<IActionResult> Index()
        {
              return _context.Szczegoly != null ? 
                          View(await _context.Szczegoly.ToListAsync()) :
                          Problem("Entity set 'FirmaContext.Szczegoly'  is null.");
        }

        // GET: Szczegoly/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Szczegoly == null)
            {
                return NotFound();
            }

            var szczegoly = await _context.Szczegoly
                .FirstOrDefaultAsync(m => m.IdSzczegolu == id);
            if (szczegoly == null)
            {
                return NotFound();
            }

            return View(szczegoly);
        }

        // GET: Szczegoly/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Szczegoly/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tytul,Opis,DataDodania,Aktywny,CzyAktywny,KtoDodal,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] Szczegoly szczegoly)
        {
            if (ModelState.IsValid)
            {
                szczegoly.CzyAktywny = true;
                szczegoly.KtoDodal = "Admin";
                _context.Add(szczegoly);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(szczegoly);
        }

        // GET: Szczegoly/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Szczegoly == null)
            {
                return NotFound();
            }

            var szczegoly = await _context.Szczegoly.FindAsync(id);
            if (szczegoly == null)
            {
                return NotFound();
            }
            return View(szczegoly);
        }

        // POST: Szczegoly/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tytul,Opis,DataDodania,Aktywny,CzyAktywny,KtoDodal,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] Szczegoly szczegoly)
        {
            if (id != szczegoly.IdSzczegolu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(szczegoly);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SzczegolyExists(szczegoly.IdSzczegolu))
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
            return View(szczegoly);
        }

        // GET: Szczegoly/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Szczegoly == null)
            {
                return NotFound();
            }

            var szczegoly = await _context.Szczegoly
                .FirstOrDefaultAsync(m => m.IdSzczegolu == id);
            if (szczegoly == null)
            {
                return NotFound();
            }

            return View(szczegoly);
        }

        // POST: Szczegoly/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Szczegoly == null)
            {
                return Problem("Entity set 'FirmaContext.Szczegoly'  is null.");
            }
            var szczegoly = await _context.Szczegoly.FindAsync(id);
            if (szczegoly != null)
            {
                _context.Szczegoly.Remove(szczegoly);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SzczegolyExists(int id)
        {
          return (_context.Szczegoly?.Any(e => e.IdSzczegolu == id)).GetValueOrDefault();
        }
    }
}
