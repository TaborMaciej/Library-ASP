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
    public class GatunekController : Controller
    {
        private readonly LibraryContext _context;

        public GatunekController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Gatunek
        public async Task<IActionResult> Index()
        {
              return _context.Gatunki != null ? 
                          View(await _context.Gatunki.ToListAsync()) :
                          Problem("Entity set 'LibraryContext.Gatunki'  is null.");
        }

        // GET: Gatunek/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Gatunki == null)
            {
                return NotFound();
            }

            var gatunek = await _context.Gatunki
                .FirstOrDefaultAsync(m => m.IDGatunek == id);
            if (gatunek == null)
            {
                return NotFound();
            }

            return View(gatunek);
        }

        // GET: Gatunek/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gatunek/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDGatunek,Nazwa")] Gatunek gatunek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gatunek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gatunek);
        }

        // GET: Gatunek/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Gatunki == null)
            {
                return NotFound();
            }

            var gatunek = await _context.Gatunki.FindAsync(id);
            if (gatunek == null)
            {
                return NotFound();
            }
            return View(gatunek);
        }

        // POST: Gatunek/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("IDGatunek,Nazwa")] Gatunek gatunek)
        {
            if (id != gatunek.IDGatunek)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gatunek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GatunekExists(gatunek.IDGatunek))
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
            return View(gatunek);
        }

        // GET: Gatunek/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Gatunki == null)
            {
                return NotFound();
            }

            var gatunek = await _context.Gatunki
                .FirstOrDefaultAsync(m => m.IDGatunek == id);
            if (gatunek == null)
            {
                return NotFound();
            }

            return View(gatunek);
        }

        // POST: Gatunek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            if (_context.Gatunki == null)
            {
                return Problem("Entity set 'LibraryContext.Gatunki'  is null.");
            }
            var gatunek = await _context.Gatunki.FindAsync(id);
            if (gatunek != null)
            {
                _context.Gatunki.Remove(gatunek);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GatunekExists(Guid? id)
        {
          return (_context.Gatunki?.Any(e => e.IDGatunek == id)).GetValueOrDefault();
        }
    }
}
