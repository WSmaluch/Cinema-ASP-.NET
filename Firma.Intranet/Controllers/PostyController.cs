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
    public class PostyController : Controller
    {
        private readonly FirmaContext _context;

        public PostyController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Posty
        public async Task<IActionResult> Index()
        {
              return _context.Posty != null ? 
                          View(await _context.Posty.ToListAsync()) :
                          Problem("Entity set 'FirmaContext.Posty'  is null.");
        }

        // GET: Posty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Posty == null)
            {
                return NotFound();
            }

            var posty = await _context.Posty
                .FirstOrDefaultAsync(m => m.IdPostu == id);
            if (posty == null)
            {
                return NotFound();
            }

            return View(posty);
        }

        // GET: Posty/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tytul,Tresc,DataPublikacji,Autor,ObrazekUrl,CzyAktywny,KtoDodal,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] Posty posty)
        {
            if (ModelState.IsValid)
            {
                posty.CzyAktywny = true;
                posty.KtoDodal = "Admin";
                _context.Add(posty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(posty);
        }

        // GET: Posty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Posty == null)
            {
                return NotFound();
            }

            var posty = await _context.Posty.FindAsync(id);
            if (posty == null)
            {
                return NotFound();
            }
            return View(posty);
        }

        // POST: Posty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tytul,Tresc,DataPublikacji,Autor,ObrazekUrl,CzyAktywny,KtoDodal,KiedyDodal,KtoZmodyfikowal,KiedyZmodyfikowal,KtoWykasowal,KiedyWykasowal")] Posty posty)
        {
            if (id != posty.IdPostu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostyExists(posty.IdPostu))
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
            return View(posty);
        }

        // GET: Posty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Posty == null)
            {
                return NotFound();
            }

            var posty = await _context.Posty
                .FirstOrDefaultAsync(m => m.IdPostu == id);
            if (posty == null)
            {
                return NotFound();
            }

            return View(posty);
        }

        // POST: Posty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Posty == null)
            {
                return Problem("Entity set 'FirmaContext.Posty'  is null.");
            }
            var posty = await _context.Posty.FindAsync(id);
            if (posty != null)
            {
                _context.Posty.Remove(posty);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostyExists(int id)
        {
          return (_context.Posty?.Any(e => e.IdPostu == id)).GetValueOrDefault();
        }
    }
}
