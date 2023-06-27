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
    public class GatunekController : Controller
    {
        private readonly FirmaContext _context;

        public GatunekController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Gatunek
        public async Task<IActionResult> Index()
        {
              return _context.Gatunek != null ? 
                          View(await _context.Gatunek.ToListAsync()) :
                          Problem("Entity set 'FirmaContext.Gatunek'  is null.");
        }

        // GET: Gatunek/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gatunek == null)
            {
                return NotFound();
            }

            var gatunek = await _context.Gatunek
                .FirstOrDefaultAsync(m => m.IdGatunku == id);
            if (gatunek == null)
            {
                return NotFound();
            }

            return View(gatunek);
        }

        // GET: Gatunek/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gatunek/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGatunku,Nazwa,CzyAktywny,KtoDodal,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] Gatunek gatunek)
        {
            if (ModelState.IsValid)
            {
                gatunek.CzyAktywny = true;
                gatunek.KtoDodal = "Admin";
                _context.Add(gatunek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gatunek);
        }

        // GET: Gatunek/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gatunek == null)
            {
                return NotFound();
            }

            var gatunek = await _context.Gatunek.FindAsync(id);
            if (gatunek == null)
            {
                return NotFound();
            }
            return View(gatunek);
        }

        // POST: Gatunek/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGatunku,Nazwa,CzyAktywny,KtoDodal,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] Gatunek gatunek)
        {
            if (id != gatunek.IdGatunku)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gatunek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GatunekExists(gatunek.IdGatunku))
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
            return View(gatunek);
        }

        // GET: Gatunek/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gatunek == null)
            {
                return NotFound();
            }

            var gatunek = await _context.Gatunek
                .FirstOrDefaultAsync(m => m.IdGatunku == id);
            if (gatunek == null)
            {
                return NotFound();
            }

            return View(gatunek);
        }

        // POST: Gatunek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gatunek == null)
            {
                return Problem("Entity set 'FirmaContext.Gatunek'  is null.");
            }
            var gatunek = await _context.Gatunek.FindAsync(id);
            if (gatunek != null)
            {
                _context.Gatunek.Remove(gatunek);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GatunekExists(int id)
        {
          return (_context.Gatunek?.Any(e => e.IdGatunku == id)).GetValueOrDefault();
        }
    }
}
