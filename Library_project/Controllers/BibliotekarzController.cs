using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library_project.Context;
using Library_project.Models;

namespace Library_project.Controllers
{
    public class BibliotekarzController : Controller
    {
        private readonly LibraryContext _context;

        public BibliotekarzController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Bibliotekarz
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.Bibliotekarze.Include(b => b.DanaLogowania).Include(b => b.DanaOsobowa);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Bibliotekarz/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Bibliotekarze == null)
            {
                return NotFound();
            }

            var bibliotekarz = await _context.Bibliotekarze
                .Include(b => b.DanaLogowania)
                .Include(b => b.DanaOsobowa)
                .FirstOrDefaultAsync(m => m.IDBibliotekarz == id);
            if (bibliotekarz == null)
            {
                return NotFound();
            }

            return View(bibliotekarz);
        }

        // GET: Bibliotekarz/Create
        public IActionResult Create()
        {
            ViewData["IDDanaLogowania"] = new SelectList(_context.DaneLogowania, "IDDanaLogowania", "Email");
            ViewData["IDDanaOsobowe"] = new SelectList(_context.DaneOsobowe, "IDDanaOsobowa", "Pesel");
            return View();
        }

        // POST: Bibliotekarz/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDBibliotekarz,Pensja,IDDanaOsobowe,IDDanaLogowania")] Bibliotekarz bibliotekarz)
        {
            if (ModelState.IsValid)
            {
                bibliotekarz.IDBibliotekarz = Guid.NewGuid();
                _context.Add(bibliotekarz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDDanaLogowania"] = new SelectList(_context.DaneLogowania, "IDDanaLogowania", "Email", bibliotekarz.IDDanaLogowania);
            ViewData["IDDanaOsobowe"] = new SelectList(_context.DaneOsobowe, "IDDanaOsobowa", "Pesel", bibliotekarz.IDDanaOsobowe);
            return View(bibliotekarz);
        }

        // GET: Bibliotekarz/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Bibliotekarze == null)
            {
                return NotFound();
            }

            var bibliotekarz = await _context.Bibliotekarze.FindAsync(id);
            if (bibliotekarz == null)
            {
                return NotFound();
            }
            ViewData["IDDanaLogowania"] = new SelectList(_context.DaneLogowania, "IDDanaLogowania", "Email", bibliotekarz.IDDanaLogowania);
            ViewData["IDDanaOsobowe"] = new SelectList(_context.DaneOsobowe, "IDDanaOsobowa", "Pesel", bibliotekarz.IDDanaOsobowe);
            return View(bibliotekarz);
        }

        // POST: Bibliotekarz/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IDBibliotekarz,Pensja,IDDanaOsobowe,IDDanaLogowania")] Bibliotekarz bibliotekarz)
        {
            if (id != bibliotekarz.IDBibliotekarz)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bibliotekarz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BibliotekarzExists(bibliotekarz.IDBibliotekarz))
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
            ViewData["IDDanaLogowania"] = new SelectList(_context.DaneLogowania, "IDDanaLogowania", "Email", bibliotekarz.IDDanaLogowania);
            ViewData["IDDanaOsobowe"] = new SelectList(_context.DaneOsobowe, "IDDanaOsobowa", "Pesel", bibliotekarz.IDDanaOsobowe);
            return View(bibliotekarz);
        }

        // GET: Bibliotekarz/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Bibliotekarze == null)
            {
                return NotFound();
            }

            var bibliotekarz = await _context.Bibliotekarze
                .Include(b => b.DanaLogowania)
                .Include(b => b.DanaOsobowa)
                .FirstOrDefaultAsync(m => m.IDBibliotekarz == id);
            if (bibliotekarz == null)
            {
                return NotFound();
            }

            return View(bibliotekarz);
        }

        // POST: Bibliotekarz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Bibliotekarze == null)
            {
                return Problem("Entity set 'LibraryContext.Bibliotekarze'  is null.");
            }
            var bibliotekarz = await _context.Bibliotekarze.FindAsync(id);
            if (bibliotekarz != null)
            {
                _context.Bibliotekarze.Remove(bibliotekarz);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BibliotekarzExists(Guid id)
        {
          return (_context.Bibliotekarze?.Any(e => e.IDBibliotekarz == id)).GetValueOrDefault();
        }
    }
}
