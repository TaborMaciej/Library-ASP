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
using Library_project.Interfaces;

namespace Library_project.Controllers
{
    public class DanaLogowaniaController : Controller
    {
        private readonly LibraryContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public DanaLogowaniaController(LibraryContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        // GET: DanaLogowania
        public async Task<IActionResult> Index()
        {
              return _context.DaneLogowania != null ? 
                          View(await _context.DaneLogowania.ToListAsync()) :
                          Problem("Entity set 'LibraryContext.DaneLogowania'  is null.");
        }

        // GET: DanaLogowania/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.DaneLogowania == null)
            {
                return NotFound();
            }

            var danaLogowania = await _context.DaneLogowania
                .FirstOrDefaultAsync(m => m.IDDanaLogowania == id);
            if (danaLogowania == null)
            {
                return NotFound();
            }

            return View(danaLogowania);
        }

        // GET: DanaLogowania/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DanaLogowania/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDDanaLogowania,Haslo,Email")] DanaLogowania danaLogowania)
        {
            if (ModelState.IsValid)
            {
                danaLogowania.IDDanaLogowania = Guid.NewGuid();
                danaLogowania.Haslo = _passwordHasher.Hash(danaLogowania.Haslo);
                _context.Add(danaLogowania);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "DanaLogowania");
            }
            return View(danaLogowania);
        }

        // GET: DanaLogowania/Edit/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.DaneLogowania == null)
            {
                return NotFound();
            }

            var danaLogowania = await _context.DaneLogowania.FindAsync(id);
            if (danaLogowania == null)
            {
                return NotFound();
            }
            return View(danaLogowania);
        }

        // POST: DanaLogowania/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Bibliotekarz")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IDDanaLogowania,Haslo,Email")] DanaLogowania danaLogowania)
        {
            if (id != danaLogowania.IDDanaLogowania)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    danaLogowania.Haslo = _passwordHasher.Hash(danaLogowania.Haslo);
                    _context.Update(danaLogowania);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanaLogowaniaExists(danaLogowania.IDDanaLogowania))
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
            return View(danaLogowania);
        }

        // GET: DanaLogowania/Delete/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.DaneLogowania == null)
            {
                return NotFound();
            }

            var danaLogowania = await _context.DaneLogowania
                .FirstOrDefaultAsync(m => m.IDDanaLogowania == id);
            if (danaLogowania == null)
            {
                return NotFound();
            }

            return View(danaLogowania);
        }

        // POST: DanaLogowania/Delete/5
        [Authorize(Roles = "Admin, Bibliotekarz")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.DaneLogowania == null)
            {
                return Problem("Entity set 'LibraryContext.DaneLogowania'  is null.");
            }
            var danaLogowania = await _context.DaneLogowania.FindAsync(id);
            if (danaLogowania != null)
            {
                _context.DaneLogowania.Remove(danaLogowania);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanaLogowaniaExists(Guid id)
        {
          return (_context.DaneLogowania?.Any(e => e.IDDanaLogowania == id)).GetValueOrDefault();
        }
    }
}
