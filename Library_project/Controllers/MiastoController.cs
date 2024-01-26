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
    public class MiastoController : Controller
    {
        private readonly LibraryContext _context;

        public MiastoController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Miasto
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.Miasta.Include(m => m.Wojewodztwo);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Miasto/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Miasta == null)
            {
                return NotFound();
            }

            var miasto = await _context.Miasta
                .Include(m => m.Wojewodztwo)
                .FirstOrDefaultAsync(m => m.IDMiasto == id);
            if (miasto == null)
            {
                return NotFound();
            }

            return View(miasto);
        }

        // GET: Miasto/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["IDWojewodztwo"] = new SelectList(_context.Wojewodztwa, "IDWojewodztwo", "IDWojewodztwo");
            return View();
        }

        // POST: Miasto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDMiasto,Nazwa,IDWojewodztwo")] Miasto miasto)
        {
            if (ModelState.IsValid)
            {
                miasto.IDMiasto = Guid.NewGuid();
                _context.Add(miasto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["IDWojewodztwo"] = new SelectList(_context.Wojewodztwa, "IDWojewodztwo", "IDWojewodztwo", miasto.IDWojewodztwo);
            return View(miasto);
        }

        // GET: Miasto/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Miasta == null)
            {
                return NotFound();
            }

            var miasto = await _context.Miasta.FindAsync(id);
            if (miasto == null)
            {
                return NotFound();
            }
            ViewData["IDWojewodztwo"] = new SelectList(_context.Wojewodztwa, "IDWojewodztwo", "IDWojewodztwo", miasto.IDWojewodztwo);
            return View(miasto);
        }

        // POST: Miasto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IDMiasto,Nazwa,IDWojewodztwo")] Miasto miasto)
        {
            if (id != miasto.IDMiasto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miasto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiastoExists(miasto.IDMiasto))
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
            ViewData["IDWojewodztwo"] = new SelectList(_context.Wojewodztwa, "IDWojewodztwo", "IDWojewodztwo", miasto.IDWojewodztwo);
            return View(miasto);
        }

        // GET: Miasto/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Miasta == null)
            {
                return NotFound();
            }

            var miasto = await _context.Miasta
                .Include(m => m.Wojewodztwo)
                .FirstOrDefaultAsync(m => m.IDMiasto == id);
            if (miasto == null)
            {
                return NotFound();
            }

            return View(miasto);
        }

        // POST: Miasto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Miasta == null)
            {
                return Problem("Entity set 'LibraryContext.Miasta'  is null.");
            }
            var miasto = await _context.Miasta.FindAsync(id);
            if (miasto != null)
            {
                _context.Miasta.Remove(miasto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiastoExists(Guid id)
        {
          return (_context.Miasta?.Any(e => e.IDMiasto == id)).GetValueOrDefault();
        }
    }
}
