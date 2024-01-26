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
    public class DanaOsobowasController : Controller
    {
        private readonly LibraryContext _context;

        public DanaOsobowasController(LibraryContext context)
        {
            _context = context;
        }

        // GET: DanaOsobowas
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.DaneOsobowe.Include(d => d.Adres).Include(d => d.Osoba);
            return View(await libraryContext.ToListAsync());
        }

        // GET: DanaOsobowas/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.DaneOsobowe == null)
            {
                return NotFound();
            }

            var danaOsobowa = await _context.DaneOsobowe
                .Include(d => d.Adres)
                .Include(d => d.Osoba)
                .FirstOrDefaultAsync(m => m.IDDanaOsobowa == id);
            if (danaOsobowa == null)
            {
                return NotFound();
            }

            return View(danaOsobowa);
        }

        // GET: DanaOsobowas/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["IDAdres"] = new SelectList(_context.Adresy, "IDAdres", "IDAdres");
            ViewData["IDOsoba"] = new SelectList(_context.Osoby, "IDOsoba", "IDOsoba");
            return View();
        }

        // POST: DanaOsobowas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("IDDanaOsobowa,Pesel,IDOsoba,IDAdres,Telefon")] DanaOsobowa danaOsobowa)
        {
            if (ModelState.IsValid)
            {
                danaOsobowa.IDDanaOsobowa = Guid.NewGuid();
                _context.Add(danaOsobowa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDAdres"] = new SelectList(_context.Adresy, "IDAdres", "IDAdres", danaOsobowa.IDAdres);
            ViewData["IDOsoba"] = new SelectList(_context.Osoby, "IDOsoba", "IDOsoba", danaOsobowa.IDOsoba);
            return View(danaOsobowa);
        }

        // GET: DanaOsobowas/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.DaneOsobowe == null)
            {
                return NotFound();
            }

            var danaOsobowa = await _context.DaneOsobowe.FindAsync(id);
            if (danaOsobowa == null)
            {
                return NotFound();
            }
            ViewData["IDAdres"] = new SelectList(_context.Adresy, "IDAdres", "IDAdres", danaOsobowa.IDAdres);
            ViewData["IDOsoba"] = new SelectList(_context.Osoby, "IDOsoba", "IDOsoba", danaOsobowa.IDOsoba);
            return View(danaOsobowa);
        }

        // POST: DanaOsobowas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IDDanaOsobowa,Pesel,IDOsoba,IDAdres,Telefon")] DanaOsobowa danaOsobowa)
        {
            if (id != danaOsobowa.IDDanaOsobowa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danaOsobowa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanaOsobowaExists(danaOsobowa.IDDanaOsobowa))
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
            ViewData["IDAdres"] = new SelectList(_context.Adresy, "IDAdres", "IDAdres", danaOsobowa.IDAdres);
            ViewData["IDOsoba"] = new SelectList(_context.Osoby, "IDOsoba", "IDOsoba", danaOsobowa.IDOsoba);
            return View(danaOsobowa);
        }

        // GET: DanaOsobowas/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.DaneOsobowe == null)
            {
                return NotFound();
            }

            var danaOsobowa = await _context.DaneOsobowe
                .Include(d => d.Adres)
                .Include(d => d.Osoba)
                .FirstOrDefaultAsync(m => m.IDDanaOsobowa == id);
            if (danaOsobowa == null)
            {
                return NotFound();
            }

            return View(danaOsobowa);
        }

        // POST: DanaOsobowas/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.DaneOsobowe == null)
            {
                return Problem("Entity set 'LibraryContext.DaneOsobowe'  is null.");
            }
            var danaOsobowa = await _context.DaneOsobowe.FindAsync(id);
            if (danaOsobowa != null)
            {
                _context.DaneOsobowe.Remove(danaOsobowa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanaOsobowaExists(Guid id)
        {
          return (_context.DaneOsobowe?.Any(e => e.IDDanaOsobowa == id)).GetValueOrDefault();
        }
    }
}
