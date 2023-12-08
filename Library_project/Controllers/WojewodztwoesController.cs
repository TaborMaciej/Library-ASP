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
    public class WojewodztwoesController : Controller
    {
        private readonly LibraryContext _context;

        public WojewodztwoesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Wojewodztwoes
        public async Task<IActionResult> Index()
        {
              return _context.Wojewodztwa != null ? 
                          View(await _context.Wojewodztwa.ToListAsync()) :
                          Problem("Entity set 'LibraryContext.Wojewodztwa'  is null.");
        }

        // GET: Wojewodztwoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Wojewodztwa == null)
            {
                return NotFound();
            }

            var wojewodztwo = await _context.Wojewodztwa
                .FirstOrDefaultAsync(m => m.IDWojewodztwo == id);
            if (wojewodztwo == null)
            {
                return NotFound();
            }

            return View(wojewodztwo);
        }

        // GET: Wojewodztwoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wojewodztwoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDWojewodztwo,Nazwa")] Wojewodztwo wojewodztwo)
        {
            if (ModelState.IsValid)
            {
                wojewodztwo.IDWojewodztwo = Guid.NewGuid();
                _context.Add(wojewodztwo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Miasto");
            }
            return View(wojewodztwo);
        }

        // GET: Wojewodztwoes/Edit/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Wojewodztwa == null)
            {
                return NotFound();
            }

            var wojewodztwo = await _context.Wojewodztwa.FindAsync(id);
            if (wojewodztwo == null)
            {
                return NotFound();
            }
            return View(wojewodztwo);
        }

        // POST: Wojewodztwoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Bibliotekarz")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IDWojewodztwo,Nazwa")] Wojewodztwo wojewodztwo)
        {
            if (id != wojewodztwo.IDWojewodztwo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wojewodztwo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WojewodztwoExists(wojewodztwo.IDWojewodztwo))
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
            return View(wojewodztwo);
        }

        // GET: Wojewodztwoes/Delete/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Wojewodztwa == null)
            {
                return NotFound();
            }

            var wojewodztwo = await _context.Wojewodztwa
                .FirstOrDefaultAsync(m => m.IDWojewodztwo == id);
            if (wojewodztwo == null)
            {
                return NotFound();
            }

            return View(wojewodztwo);
        }

        // POST: Wojewodztwoes/Delete/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Wojewodztwa == null)
            {
                return Problem("Entity set 'LibraryContext.Wojewodztwa'  is null.");
            }
            var wojewodztwo = await _context.Wojewodztwa.FindAsync(id);
            if (wojewodztwo != null)
            {
                _context.Wojewodztwa.Remove(wojewodztwo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WojewodztwoExists(Guid id)
        {
          return (_context.Wojewodztwa?.Any(e => e.IDWojewodztwo == id)).GetValueOrDefault();
        }
    }
}
