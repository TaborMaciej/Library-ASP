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
    [Authorize(Roles="Admin, Bibliotekarz")]
    public class EgzemplarzController : Controller
    {
        private readonly LibraryContext _context;

        public EgzemplarzController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Egzemplarzs
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.Egzemplarze.Include(e => e.Ksiazka);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Egzemplarzs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Egzemplarze == null)
            {
                return NotFound();
            }

            var egzemplarz = await _context.Egzemplarze
                .Include(e => e.Ksiazka)
                .FirstOrDefaultAsync(m => m.IDEgzemplarz == id);
            if (egzemplarz == null)
            {
                return NotFound();
            }

            return View(egzemplarz);
        }

        // GET: Egzemplarzs/Create
        [Authorize(Roles = "Admin, Bibliotekarz")]
        public IActionResult Create()
        {
            ViewData["ISBN"] = new SelectList(_context.Ksiazki.Select(s => new {ID = s.ISBN, Name = s.ISBN + " - " + s.Tytul}), "ID", "Name");
            return View();
        }

        // POST: Egzemplarzs/Create
        [Authorize(Roles = "Admin, Bibliotekarz")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDEgzemplarz,Dostepnosc,RokZakupu,ISBN")] Egzemplarz egzemplarz)
        {
            if (ModelState.IsValid)
            {
                egzemplarz.IDEgzemplarz = Guid.NewGuid();
                _context.Add(egzemplarz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ISBN"] = new SelectList(_context.Ksiazki.Select(s => new { ID = s.ISBN, Name = s.ISBN + " - " + s.Tytul }), "ID", "Name", egzemplarz.ISBN);
            return View(egzemplarz);
        }

        // GET: Egzemplarzs/Edit/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Egzemplarze == null)
            {
                return NotFound();
            }

            var egzemplarz = await _context.Egzemplarze.FindAsync(id);
            if (egzemplarz == null)
            {
                return NotFound();
            }
            ViewData["ISBN"] = new SelectList(_context.Ksiazki.Select(s => new { ID = s.ISBN, Name = s.ISBN + " - " + s.Tytul }), "ID", "Name", egzemplarz.ISBN);
            return View(egzemplarz);
        }

        // POST: Egzemplarzs/Edit/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IDEgzemplarz,Dostepnosc,RokZakupu,ISBN")] Egzemplarz egzemplarz)
        {
            if (id != egzemplarz.IDEgzemplarz)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(egzemplarz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EgzemplarzExists(egzemplarz.IDEgzemplarz))
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
            ViewData["ISBN"] = new SelectList(_context.Ksiazki.Select(s => new { ID = s.ISBN, Name = s.ISBN + " - " + s.Tytul }), "ID", "Name", egzemplarz.ISBN);
            return View(egzemplarz);
        }

        // GET: Egzemplarzs/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Egzemplarze == null)
            {
                return NotFound();
            }

            var egzemplarz = await _context.Egzemplarze
                .Include(e => e.Ksiazka)
                .FirstOrDefaultAsync(m => m.IDEgzemplarz == id);
            if (egzemplarz == null)
            {
                return NotFound();
            }

            return View(egzemplarz);
        }

        // POST: Egzemplarzs/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Egzemplarze == null)
            {
                return Problem("Entity set 'LibraryContext.Egzemplarze'  is null.");
            }
            var egzemplarz = await _context.Egzemplarze.FindAsync(id);
            if (egzemplarz != null)
            {
                _context.Egzemplarze.Remove(egzemplarz);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EgzemplarzExists(Guid id)
        {
          return (_context.Egzemplarze?.Any(e => e.IDEgzemplarz == id)).GetValueOrDefault();
        }
    }
}
