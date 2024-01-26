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
    public class AdminsController : Controller
    {
        private readonly LibraryContext _context;

        public AdminsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Admins
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.Admini.Include(a => a.DanaLogowania);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Admini == null)
            {
                return NotFound();
            }

            var admin = await _context.Admini
                .Include(a => a.DanaLogowania)
                .FirstOrDefaultAsync(m => m.IDAdmin == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: Admins/Create
        public IActionResult Create()
        {
            ViewData["IDDanaLogowania"] = new SelectList(_context.DaneLogowania, "IDDanaLogowania", "Email");
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDAdmin,IDDanaLogowania")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                admin.IDAdmin = Guid.NewGuid();
                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDDanaLogowania"] = new SelectList(_context.DaneLogowania, "IDDanaLogowania", "Email", admin.IDDanaLogowania);
            return View(admin);
        } 

        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Admini == null)
            {
                return NotFound();
            }

            var admin = await _context.Admini.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            ViewData["IDDanaLogowania"] = new SelectList(_context.DaneLogowania, "IDDanaLogowania", "Email", admin.IDDanaLogowania);
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IDAdmin,IDDanaLogowania")] Admin admin)
        {
            if (id != admin.IDAdmin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.IDAdmin))
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
            ViewData["IDDanaLogowania"] = new SelectList(_context.DaneLogowania, "IDDanaLogowania", "Email", admin.IDDanaLogowania);
            return View(admin);
        }

        // GET: Admins/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Admini == null)
            {
                return NotFound();
            }

            var admin = await _context.Admini
                .Include(a => a.DanaLogowania)
                .FirstOrDefaultAsync(m => m.IDAdmin == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Admini == null)
            {
                return Problem("Entity set 'LibraryContext.Admini'  is null.");
            }
            var admin = await _context.Admini.FindAsync(id);
            if (admin != null)
            {
                _context.Admini.Remove(admin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminExists(Guid id)
        {
          return (_context.Admini?.Any(e => e.IDAdmin == id)).GetValueOrDefault();
        }
    }
}
