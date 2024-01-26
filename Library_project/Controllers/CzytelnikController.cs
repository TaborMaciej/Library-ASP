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
    public class CzytelnikController : Controller
    {
        private readonly LibraryContext _context;

        public CzytelnikController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Czytelnik
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.Czytelnicy.Include(c => c.DanaLogowania).Include(c => c.DanaOsobowa);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Czytelnik/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Czytelnicy == null)
            {
                return NotFound();
            }

            var czytelnik = await _context.Czytelnicy
                .Include(c => c.DanaLogowania)
                .Include(c => c.DanaOsobowa)
                .FirstOrDefaultAsync(m => m.IDCzytelnik == id);
            if (czytelnik == null)
            {
                return NotFound();
            }

            return View(czytelnik);
        }

        // GET: Czytelnik/Create
        public IActionResult Create()
        {
            ViewData["IDDanaLogowania"] = new SelectList(_context.DaneLogowania, "IDDanaLogowania", "Email");
            ViewData["IDDanaOsobowe"] = new SelectList(_context.DaneOsobowe, "IDDanaOsobowa", "Pesel");
            return View();
        }

        // POST: Czytelnik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDCzytelnik,IDDanaOsobowe,IDDanaLogowania")] Czytelnik czytelnik)
        {
            if (ModelState.IsValid)
            {
                czytelnik.IDCzytelnik = Guid.NewGuid();
                _context.Add(czytelnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDDanaLogowania"] = new SelectList(_context.DaneLogowania, "IDDanaLogowania", "Email", czytelnik.IDDanaLogowania);
            ViewData["IDDanaOsobowe"] = new SelectList(_context.DaneOsobowe, "IDDanaOsobowa", "Pesel", czytelnik.IDDanaOsobowe);
            return View(czytelnik);
        }

        // GET: Czytelnik/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Czytelnicy == null)
            {
                return NotFound();
            }

            var czytelnik = await _context.Czytelnicy.FindAsync(id);
            if (czytelnik == null)
            {
                return NotFound();
            }
            ViewData["IDDanaLogowania"] = new SelectList(_context.DaneLogowania, "IDDanaLogowania", "Email", czytelnik.IDDanaLogowania);
            ViewData["IDDanaOsobowe"] = new SelectList(_context.DaneOsobowe, "IDDanaOsobowa", "Pesel", czytelnik.IDDanaOsobowe);
            return View(czytelnik);
        }

        // POST: Czytelnik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IDCzytelnik,IDDanaOsobowe,IDDanaLogowania")] Czytelnik czytelnik)
        {
            if (id != czytelnik.IDCzytelnik)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(czytelnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CzytelnikExists(czytelnik.IDCzytelnik))
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
            ViewData["IDDanaLogowania"] = new SelectList(_context.DaneLogowania, "IDDanaLogowania", "Email", czytelnik.IDDanaLogowania);
            ViewData["IDDanaOsobowe"] = new SelectList(_context.DaneOsobowe, "IDDanaOsobowa", "Pesel", czytelnik.IDDanaOsobowe);
            return View(czytelnik);
        }

        // GET: Czytelnik/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Czytelnicy == null)
            {
                return NotFound();
            }

            var czytelnik = await _context.Czytelnicy
                .Include(c => c.DanaLogowania)
                .Include(c => c.DanaOsobowa)
                .FirstOrDefaultAsync(m => m.IDCzytelnik == id);
            if (czytelnik == null)
            {
                return NotFound();
            }

            return View(czytelnik);
        }

        // POST: Czytelnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Czytelnicy == null)
            {
                return Problem("Entity set 'LibraryContext.Czytelnicy'  is null.");
            }
            var czytelnik = await _context.Czytelnicy.FindAsync(id);
            if (czytelnik != null)
            {
                _context.Czytelnicy.Remove(czytelnik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CzytelnikExists(Guid id)
        {
          return (_context.Czytelnicy?.Any(e => e.IDCzytelnik == id)).GetValueOrDefault();
        }
    }
}
