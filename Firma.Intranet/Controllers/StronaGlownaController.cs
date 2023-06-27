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
    public class StronaGlownaController : Controller
    {
        private readonly FirmaContext _context;

        public StronaGlownaController(FirmaContext context)
        {
            _context = context;
        }

        // GET: StronaGlowna
        public async Task<IActionResult> Index()
        {
              return _context.StronaGlowna != null ? 
                          View(await _context.StronaGlowna.ToListAsync()) :
                          Problem("Entity set 'FirmaContext.StronaGlowna'  is null.");
        }

        // GET: StronaGlowna/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StronaGlowna == null)
            {
                return NotFound();
            }

            var stronaGlowna = await _context.StronaGlowna
                .FirstOrDefaultAsync(m => m.IdStronyGlownej == id);
            if (stronaGlowna == null)
            {
                return NotFound();
            }

            return View(stronaGlowna);
        }

        // GET: StronaGlowna/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StronaGlowna/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStronyGlownej,Bannery,TekstyBanner,ReklamyZdjecia,TekstyReklama,PartnerzyZdjecia,CzyAktywny,KtoDodal,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] StronaGlowna stronaGlowna)
        {
            if (ModelState.IsValid)
            {
                stronaGlowna.CzyAktywny = true;
                stronaGlowna.KtoDodal = "Admin";
                _context.Add(stronaGlowna);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stronaGlowna);
        }

        // GET: StronaGlowna/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StronaGlowna == null)
            {
                return NotFound();
            }

            var stronaGlowna = await _context.StronaGlowna.FindAsync(id);
            if (stronaGlowna == null)
            {
                return NotFound();
            }
            return View(stronaGlowna);
        }

        // POST: StronaGlowna/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStronyGlownej,Bannery,TekstyBanner,ReklamyZdjecia,TekstyReklama,PartnerzyZdjecia,CzyAktywny,KtoDodal,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] StronaGlowna stronaGlowna)
        {
            if (id != stronaGlowna.IdStronyGlownej)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stronaGlowna);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StronaGlownaExists(stronaGlowna.IdStronyGlownej))
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
            return View(stronaGlowna);
        }

        // GET: StronaGlowna/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StronaGlowna == null)
            {
                return NotFound();
            }

            var stronaGlowna = await _context.StronaGlowna
                .FirstOrDefaultAsync(m => m.IdStronyGlownej == id);
            if (stronaGlowna == null)
            {
                return NotFound();
            }

            return View(stronaGlowna);
        }

        // POST: StronaGlowna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StronaGlowna == null)
            {
                return Problem("Entity set 'FirmaContext.StronaGlowna'  is null.");
            }
            var stronaGlowna = await _context.StronaGlowna.FindAsync(id);
            if (stronaGlowna != null)
            {
                _context.StronaGlowna.Remove(stronaGlowna);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StronaGlownaExists(int id)
        {
          return (_context.StronaGlowna?.Any(e => e.IdStronyGlownej == id)).GetValueOrDefault();
        }
    }
}
