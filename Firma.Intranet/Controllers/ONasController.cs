using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data;
using Firma.Data.Data.CMS;
using Firma.Data.Data.Kino;

namespace Firma.Intranet.Controllers
{
    public class ONasController : Controller
    {
        private readonly FirmaContext _context;

        public ONasController(FirmaContext context)
        {
            _context = context;
        }

        // GET: ONas
        public async Task<IActionResult> Index()
        {
              return _context.ONas != null ? 
                          View(await _context.ONas.ToListAsync()) :
                          Problem("Entity set 'FirmaContext.ONas'  is null.");
        }

        // GET: ONas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ONas == null)
            {
                return NotFound();
            }

            var oNas = await _context.ONas
                .FirstOrDefaultAsync(m => m.IdONas == id);
            if (oNas == null)
            {
                return NotFound();
            }

            return View(oNas);
        }

        // GET: ONas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ONas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdONas,Naglowek,Tekst,Historia,Zdjecia,Kontakt,CzyAktywny,KtoDodal,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] ONas oNas)
        {
            if (ModelState.IsValid)
            {
                oNas.CzyAktywny = true;
                oNas.KtoDodal = "Admin";
                _context.Add(oNas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oNas);
        }

        // GET: ONas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ONas == null)
            {
                return NotFound();
            }

            var oNas = await _context.ONas.FindAsync(id);
            if (oNas == null)
            {
                return NotFound();
            }
            return View(oNas);
        }

        // POST: ONas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdONas,Naglowek,Tekst,Historia,Zdjecia,Kontakt,CzyAktywny,KtoDodal,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] ONas oNas)
        {
            if (id != oNas.IdONas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oNas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ONasExists(oNas.IdONas))
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
            return View(oNas);
        }

        // GET: ONas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ONas == null)
            {
                return NotFound();
            }

            var oNas = await _context.ONas
                .FirstOrDefaultAsync(m => m.IdONas == id);
            if (oNas == null)
            {
                return NotFound();
            }

            return View(oNas);
        }

        // POST: ONas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ONas == null)
            {
                return Problem("Entity set 'FirmaContext.ONas'  is null.");
            }
            var oNas = await _context.ONas.FindAsync(id);
            if (oNas != null)
            {
                _context.ONas.Remove(oNas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ONasExists(int id)
        {
          return (_context.ONas?.Any(e => e.IdONas == id)).GetValueOrDefault();
        }
    }
}
