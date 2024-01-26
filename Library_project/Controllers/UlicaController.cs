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
    public class UlicaController : Controller
    {
        private readonly LibraryContext _context;

        public UlicaController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Ulica
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.Ulice.Include(u => u.Miasto);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Ulica/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Ulice == null)
            {
                return NotFound();
            }

            var ulica = await _context.Ulice
                .Include(u => u.Miasto)
                .FirstOrDefaultAsync(m => m.IDUlica == id);
            if (ulica == null)
            {
                return NotFound();
            }

            return View(ulica);
        }

        // GET: Ulica/Create
        public IActionResult Create()
        {
            ViewData["IDMiasto"] = new SelectList(_context.Miasta, "IDMiasto", "IDMiasto");
            return View();
        }

        // POST: Ulica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDUlica,Nazwa,KodPocztowy,IDMiasto")] Ulica ulica)
        {
            if (ModelState.IsValid)
            {
                ulica.IDUlica = Guid.NewGuid();
                _context.Add(ulica);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Adres");
            }
            ViewData["IDMiasto"] = new SelectList(_context.Miasta, "IDMiasto", "IDMiasto", ulica.IDMiasto);
            return View(ulica);
        }

        // GET: Ulica/Edit/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Ulice == null)
            {
                return NotFound();
            }

            var ulica = await _context.Ulice.FindAsync(id);
            if (ulica == null)
            {
                return NotFound();
            }
            ViewData["IDMiasto"] = new SelectList(_context.Miasta, "IDMiasto", "IDMiasto", ulica.IDMiasto);
            return View(ulica);
        }

        // POST: Ulica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin, Bibliotekarz")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IDUlica,Nazwa,KodPocztowy,IDMiasto")] Ulica ulica)
        {
            if (id != ulica.IDUlica)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ulica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UlicaExists(ulica.IDUlica))
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
            ViewData["IDMiasto"] = new SelectList(_context.Miasta, "IDMiasto", "IDMiasto", ulica.IDMiasto);
            return View(ulica);
        }

        // GET: Ulica/Delete/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Ulice == null)
            {
                return NotFound();
            }

            var ulica = await _context.Ulice
                .Include(u => u.Miasto)
                .FirstOrDefaultAsync(m => m.IDUlica == id);
            if (ulica == null)
            {
                return NotFound();
            }

            return View(ulica);
        }

        // POST: Ulica/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Bibliotekarz")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Ulice == null)
            {
                return Problem("Entity set 'LibraryContext.Ulice'  is null.");
            }
            var ulica = await _context.Ulice.FindAsync(id);
            if (ulica != null)
            {
                _context.Ulice.Remove(ulica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UlicaExists(Guid id)
        {
          return (_context.Ulice?.Any(e => e.IDUlica == id)).GetValueOrDefault();
        }
    }
}
