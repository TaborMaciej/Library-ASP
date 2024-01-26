using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library_project.Context;
using Library_project.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Library_project.Controllers
{
    [Authorize(Roles = "Admin, Bibliotekarz")]
    public class OsobasController : Controller
    {
        private readonly LibraryContext _context;

        public OsobasController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Osobas
        public async Task<IActionResult> Index()
        {
              return _context.Osoby != null ? 
                          View(await _context.Osoby.ToListAsync()) :
                          Problem("Entity set 'LibraryContext.Osoby'  is null.");
        }

        // GET: Osobas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Osoby == null)
            {
                return NotFound();
            }

            var osoba = await _context.Osoby
                .FirstOrDefaultAsync(m => m.IDOsoba == id);
            if (osoba == null)
            {
                return NotFound();
            }

            return View(osoba);
        }

        // GET: Osobas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Osobas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDOsoba,Imie,Nazwisko,DataUrodzenia,CzyAutor")] Osoba osoba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(osoba);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Wojewodztwoes");
            }
            return View(osoba);
        }

        // GET: Osobas/Edit/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Osoby == null)
            {
                return NotFound();
            }

            var osoba = await _context.Osoby.FindAsync(id);
            if (osoba == null)
            {
                return NotFound();
            }
            return View(osoba);
        }

        // POST: Osobas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Bibliotekarz")]
        public async Task<IActionResult> Edit(Guid? id, [Bind("IDOsoba,Imie,Nazwisko,DataUrodzenia,CzyAutor")] Osoba osoba)
        {
            if (id != osoba.IDOsoba)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(osoba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OsobaExists(osoba.IDOsoba))
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
            return View(osoba);
        }

        // GET: Osobas/Delete/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Osoby == null)
            {
                return NotFound();
            }

            var osoba = await _context.Osoby
                .FirstOrDefaultAsync(m => m.IDOsoba == id);
            if (osoba == null)
            {
                return NotFound();
            }

            return View(osoba);
        }

        // POST: Osobas/Delete/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            if (_context.Osoby == null)
            {
                return Problem("Entity set 'LibraryContext.Osoby'  is null.");
            }
            var osoba = await _context.Osoby.FindAsync(id);
            if (osoba != null)
            {
                _context.Osoby.Remove(osoba);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OsobaExists(Guid? id)
        {
          return (_context.Osoby?.Any(e => e.IDOsoba == id)).GetValueOrDefault();
        }
    }
}
