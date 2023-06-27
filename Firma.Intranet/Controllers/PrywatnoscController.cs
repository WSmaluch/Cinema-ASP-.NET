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
    public class PrywatnoscController : Controller
    {
        private readonly FirmaContext _context;

        public PrywatnoscController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Prywatnosc
        public async Task<IActionResult> Index()
        {
              return _context.Prywatnosc != null ? 
                          View(await _context.Prywatnosc.ToListAsync()) :
                          Problem("Entity set 'FirmaContext.Prywatnosc'  is null.");
        }

        // GET: Prywatnosc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prywatnosc == null)
            {
                return NotFound();
            }

            var prywatnosc = await _context.Prywatnosc
                .FirstOrDefaultAsync(m => m.IdPrywatnosci == id);
            if (prywatnosc == null)
            {
                return NotFound();
            }

            return View(prywatnosc);
        }

        // GET: Prywatnosc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prywatnosc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrywatnosci,Naglowek,Tresc1,Tresc2,Tresc3,Tresc4,Lista,Tresc5,CzyAktywny,KtoDodal,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] Prywatnosc prywatnosc)
        {
            if (ModelState.IsValid)
            {
                prywatnosc.CzyAktywny = true;
                prywatnosc.KtoDodal = "Admin";
                _context.Add(prywatnosc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prywatnosc);
        }

        // GET: Prywatnosc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prywatnosc == null)
            {
                return NotFound();
            }

            var prywatnosc = await _context.Prywatnosc.FindAsync(id);
            if (prywatnosc == null)
            {
                return NotFound();
            }
            return View(prywatnosc);
        }

        // POST: Prywatnosc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPrywatnosci,Naglowek,Tresc1,Tresc2,Tresc3,Tresc4,Lista,Tresc5,CzyAktywny,KtoDodal,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] Prywatnosc prywatnosc)
        {
            if (id != prywatnosc.IdPrywatnosci)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prywatnosc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrywatnoscExists(prywatnosc.IdPrywatnosci))
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
            return View(prywatnosc);
        }

        // GET: Prywatnosc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prywatnosc == null)
            {
                return NotFound();
            }

            var prywatnosc = await _context.Prywatnosc
                .FirstOrDefaultAsync(m => m.IdPrywatnosci == id);
            if (prywatnosc == null)
            {
                return NotFound();
            }

            return View(prywatnosc);
        }

        // POST: Prywatnosc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prywatnosc == null)
            {
                return Problem("Entity set 'FirmaContext.Prywatnosc'  is null.");
            }
            var prywatnosc = await _context.Prywatnosc.FindAsync(id);
            if (prywatnosc != null)
            {
                _context.Prywatnosc.Remove(prywatnosc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrywatnoscExists(int id)
        {
          return (_context.Prywatnosc?.Any(e => e.IdPrywatnosci == id)).GetValueOrDefault();
        }
    }
}
