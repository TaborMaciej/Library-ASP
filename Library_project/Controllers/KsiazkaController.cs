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

namespace Library_project.Controllers
{
    [Authorize]
    public class KsiazkaController : Controller
    {
        private readonly LibraryContext _context;

        public KsiazkaController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Ksiazka
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.Ksiazki.Include(k => k.Gatunek).Include(k => k.Wydawnictwo);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Ksiazka/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Ksiazki == null)
            {
                return NotFound();
            }

            var ksiazka = await _context.Ksiazki
                .Include(k => k.Gatunek)
                .Include(k => k.Wydawnictwo)
                .FirstOrDefaultAsync(m => m.ISBN == id);
            if (ksiazka == null)
            {
                return NotFound();
            }

            return View(ksiazka);
        }

        // GET: Ksiazka/Create
        [Authorize(Roles = "Admin, Bibliotekarz")]
        public IActionResult Create()
        {
            ViewData["IDGatunek"] = new SelectList(_context.Gatunki.Select(s => new { ID = s.IDGatunek, Name = s.Nazwa}), "ID", "Name");
            ViewData["IDWydawnictwo"] = new SelectList(_context.Wydawnictwa.Select(s => new { ID = s.IDWydawnictwo, Name = s.Nazwa }), "ID", "Name");
            return View();
        }

        // POST: Ksiazka/Create
        [Authorize(Roles = "Admin, Bibliotekarz")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ISBN,Tytul,RokWydania,LiczbaStron,IDWydawnictwo,IDGatunek")] Ksiazka ksiazka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ksiazka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDGatunek"] = new SelectList(_context.Gatunki.Select(s => new { ID = s.IDGatunek, Name = s.Nazwa }), "ID", "Name", ksiazka.IDGatunek);
            ViewData["IDWydawnictwo"] = new SelectList(_context.Wydawnictwa.Select(s => new { ID = s.IDWydawnictwo, Name = s.Nazwa }), "ID", "Name", ksiazka.IDWydawnictwo);
            return View(ksiazka);
        }

        // GET: Ksiazka/Edit/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Ksiazki == null)
            {
                return NotFound();
            }

            var ksiazka = await _context.Ksiazki.FindAsync(id);
            if (ksiazka == null)
            {
                return NotFound();
            }
            ViewData["IDGatunek"] = new SelectList(_context.Gatunki.Select(s => new { ID = s.IDGatunek, Name = s.Nazwa }), "ID", "Name", ksiazka.IDGatunek);
            ViewData["IDWydawnictwo"] = new SelectList(_context.Wydawnictwa.Select(s => new { ID = s.IDWydawnictwo, Name = s.Nazwa }), "ID", "Name", ksiazka.IDWydawnictwo);

            return View(ksiazka);
        }

        // POST: Ksiazka/Edit/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ISBN,Tytul,RokWydania,LiczbaStron,IDWydawnictwo,IDGatunek")] Ksiazka ksiazka)
        {
            if (id != ksiazka.ISBN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ksiazka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KsiazkaExists(ksiazka.ISBN))
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
            ViewData["IDGatunek"] = new SelectList(_context.Gatunki.Select(s => new { ID = s.IDGatunek, Name = s.Nazwa }), "ID", "Name", ksiazka.IDGatunek);
            ViewData["IDWydawnictwo"] = new SelectList(_context.Wydawnictwa.Select(s => new { ID = s.IDWydawnictwo, Name = s.Nazwa }), "ID", "Name", ksiazka.IDWydawnictwo);

            return View(ksiazka);
        }

        // GET: Ksiazka/Delete/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Ksiazki == null)
            {
                return NotFound();
            }

            var ksiazka = await _context.Ksiazki
                .Include(k => k.Gatunek)
                .Include(k => k.Wydawnictwo)
                .FirstOrDefaultAsync(m => m.ISBN == id);
            if (ksiazka == null)
            {
                return NotFound();
            }

            return View(ksiazka);
        }

        // POST: Ksiazka/Delete/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Ksiazki == null)
            {
                return Problem("Entity set 'LibraryContext.Ksiazki'  is null.");
            }
            var ksiazka = await _context.Ksiazki.FindAsync(id);
            if (ksiazka != null)
            {
                _context.Ksiazki.Remove(ksiazka);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KsiazkaExists(string id)
        {
          return (_context.Ksiazki?.Any(e => e.ISBN == id)).GetValueOrDefault();
        }
    }
}
