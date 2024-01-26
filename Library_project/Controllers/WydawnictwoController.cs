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
    public class WydawnictwoController : Controller
    {
        private readonly LibraryContext _context;

        public WydawnictwoController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Wydawnictwoes
        public async Task<IActionResult> Index()
        {
              return _context.Wydawnictwa != null ? 
                          View(await _context.Wydawnictwa.ToListAsync()) :
                          Problem("Entity set 'LibraryContext.Wydawnictwa'  is null.");
        }

        // GET: Wydawnictwoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Wydawnictwa == null)
            {
                return NotFound();
            }

            var wydawnictwo = await _context.Wydawnictwa
                .FirstOrDefaultAsync(m => m.IDWydawnictwo == id);
            if (wydawnictwo == null)
            {
                return NotFound();
            }

            return View(wydawnictwo);
        }

        // GET: Wydawnictwoes/Create
        [Authorize(Roles = "Admin, Bibliotekarz")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wydawnictwoes/Create
        [Authorize(Roles = "Admin, Bibliotekarz")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDWydawnictwo,Nazwa")] Wydawnictwo wydawnictwo)
        {
            if (ModelState.IsValid)
            {
                wydawnictwo.IDWydawnictwo = Guid.NewGuid();
                _context.Add(wydawnictwo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wydawnictwo);
        }

        // GET: Wydawnictwoes/Edit/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Wydawnictwa == null)
            {
                return NotFound();
            }

            var wydawnictwo = await _context.Wydawnictwa.FindAsync(id);
            if (wydawnictwo == null)
            {
                return NotFound();
            }
            return View(wydawnictwo);
        }

        // POST: Wydawnictwoes/Edit/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IDWydawnictwo,Nazwa")] Wydawnictwo wydawnictwo)
        {
            if (id != wydawnictwo.IDWydawnictwo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wydawnictwo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WydawnictwoExists(wydawnictwo.IDWydawnictwo))
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
            return View(wydawnictwo);
        }

        // GET: Wydawnictwoes/Delete/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Wydawnictwa == null)
            {
                return NotFound();
            }

            var wydawnictwo = await _context.Wydawnictwa
                .FirstOrDefaultAsync(m => m.IDWydawnictwo == id);
            if (wydawnictwo == null)
            {
                return NotFound();
            }

            return View(wydawnictwo);
        }

        // POST: Wydawnictwoes/Delete/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Wydawnictwa == null)
            {
                return Problem("Entity set 'LibraryContext.Wydawnictwa'  is null.");
            }
            var wydawnictwo = await _context.Wydawnictwa.FindAsync(id);
            if (wydawnictwo != null)
            {
                _context.Wydawnictwa.Remove(wydawnictwo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WydawnictwoExists(Guid id)
        {
          return (_context.Wydawnictwa?.Any(e => e.IDWydawnictwo == id)).GetValueOrDefault();
        }
    }
}
