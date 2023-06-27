using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data;
using Firma.Data.Data.CMS;

namespace Firma.Intranet.Controllers
{
    public class OfertyController : Controller
    {
        private readonly FirmaContext _context;

        public OfertyController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Oferty
        public async Task<IActionResult> Index()
        {
              return _context.Oferty != null ? 
                          View(await _context.Oferty.ToListAsync()) :
                          Problem("Entity set 'FirmaContext.Oferty'  is null.");
        }

        // GET: Oferty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Oferty == null)
            {
                return NotFound();
            }

            var oferty = await _context.Oferty
                .FirstOrDefaultAsync(m => m.IdOferty == id);
            if (oferty == null)
            {
                return NotFound();
            }

            return View(oferty);
        }

        // GET: Oferty/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oferty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOferty,Tytul,Tresc,Zdjecie,CzyAktywny,KtoDodal,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] Oferty oferty)
        {
            if (ModelState.IsValid)
            {
                oferty.CzyAktywny = true;
                oferty.KtoDodal = "Admin";
                _context.Add(oferty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oferty);
        }

        // GET: Oferty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Oferty == null)
            {
                return NotFound();
            }

            var oferty = await _context.Oferty.FindAsync(id);
            if (oferty == null)
            {
                return NotFound();
            }
            return View(oferty);
        }

        // POST: Oferty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOferty,Tytul,Tresc,Zdjecie,CzyAktywny,KtoDodal,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] Oferty oferty)
        {
            if (id != oferty.IdOferty)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oferty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfertyExists(oferty.IdOferty))
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
            return View(oferty);
        }

        // GET: Oferty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Oferty == null)
            {
                return NotFound();
            }

            var oferty = await _context.Oferty
                .FirstOrDefaultAsync(m => m.IdOferty == id);
            if (oferty == null)
            {
                return NotFound();
            }

            return View(oferty);
        }

        // POST: Oferty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Oferty == null)
            {
                return Problem("Entity set 'FirmaContext.Oferty'  is null.");
            }
            var oferty = await _context.Oferty.FindAsync(id);
            if (oferty != null)
            {
                _context.Oferty.Remove(oferty);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfertyExists(int id)
        {
          return (_context.Oferty?.Any(e => e.IdOferty == id)).GetValueOrDefault();
        }
    }
}
