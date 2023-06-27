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
    public class PrezentyController : Controller
    {
        private readonly FirmaContext _context;

        public PrezentyController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Prezenty
        public async Task<IActionResult> Index()
        {
              return _context.Prezenty != null ? 
                          View(await _context.Prezenty.ToListAsync()) :
                          Problem("Entity set 'FirmaContext.Prezenty'  is null.");
        }

        // GET: Prezenty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prezenty == null)
            {
                return NotFound();
            }

            var prezenty = await _context.Prezenty
                .FirstOrDefaultAsync(m => m.IdPrezentu == id);
            if (prezenty == null)
            {
                return NotFound();
            }

            return View(prezenty);
        }

        // GET: Prezenty/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prezenty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrezentu,Tytul,Tresc,Zdjecie,CzyAktywny,KtoDodal,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] Prezenty prezenty)
        {
            if (ModelState.IsValid)
            {
                prezenty.CzyAktywny = true;
                prezenty.KtoDodal = "Admin";
                _context.Add(prezenty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prezenty);
        }

        // GET: Prezenty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prezenty == null)
            {
                return NotFound();
            }

            var prezenty = await _context.Prezenty.FindAsync(id);
            if (prezenty == null)
            {
                return NotFound();
            }
            return View(prezenty);
        }

        // POST: Prezenty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPrezentu,Tytul,Tresc,Zdjecie,CzyAktywny,KtoDodal,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] Prezenty prezenty)
        {
            if (id != prezenty.IdPrezentu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prezenty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrezentyExists(prezenty.IdPrezentu))
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
            return View(prezenty);
        }

        // GET: Prezenty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prezenty == null)
            {
                return NotFound();
            }

            var prezenty = await _context.Prezenty
                .FirstOrDefaultAsync(m => m.IdPrezentu == id);
            if (prezenty == null)
            {
                return NotFound();
            }

            return View(prezenty);
        }

        // POST: Prezenty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prezenty == null)
            {
                return Problem("Entity set 'FirmaContext.Prezenty'  is null.");
            }
            var prezenty = await _context.Prezenty.FindAsync(id);
            if (prezenty != null)
            {
                _context.Prezenty.Remove(prezenty);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrezentyExists(int id)
        {
          return (_context.Prezenty?.Any(e => e.IdPrezentu == id)).GetValueOrDefault();
        }
    }
}
