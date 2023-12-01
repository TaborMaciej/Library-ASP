using Library_project.Context;
using Library_project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_project.Controllers
{
    [Authorize]
    public class AutorController : Controller
    {
        private readonly LibraryContext _context;

        public AutorController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Autor
        public IActionResult Index()
        {
            if(_context.Osoby == null)
                        Problem("Entity set 'LibraryContext.Osoby'  is null.");

            var autorzy = _context.Osoby
                .Where(a => a.CzyAutor == true);
            return View(autorzy);
        }

        // GET: Autor/Create
        [Authorize(Roles = "Admin, Bibliotekarz")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autor/Create
        [Authorize(Roles = "Admin, Bibliotekarz")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDOsoba, Imie, Nazwisko, DataUrodzenia")] Osoba autor)
        {
            if (ModelState.IsValid)
            {
                autor.CzyAutor = true;
                _context.Add(autor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }

        // GET: Autor/Edit/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Osoby== null)
            {
                return NotFound();
            }

            var autor = await _context.Osoby.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }


        // POST: Autor/Edit/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("IDOsoba, Imie, Nazwisko, DataUrodzenia")] Osoba autor)
        {
            if (id != autor.IDOsoba)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    autor.CzyAutor = true;
                    _context.Update(autor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorExists(autor.IDOsoba))
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
            return View(autor);
        }

        // GET: Gatunek/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Osoby == null)
            {
                return NotFound();
            }

            var autor = await _context.Osoby
                .FirstOrDefaultAsync(m => m.IDOsoba == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: Gatunek/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            if (_context.Osoby == null)
            {
                return Problem("Entity set 'LibraryContext.Osoby'  is null.");
            }
            var autor = await _context.Osoby.FindAsync(id);
            if (autor != null)
            {
                _context.Osoby.Remove(autor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutorExists(Guid? id)
        {
            return (_context.Osoby?.Any(e => e.IDOsoba == id && e.CzyAutor == true)).GetValueOrDefault();
        }
    }
}
