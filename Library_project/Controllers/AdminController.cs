using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library_project.Context;
using Library_project.Models;
using System.Security.Claims;

namespace Library_project.Controllers
{
    public class AdminController : Controller
    {
        private readonly LibraryContext _context;

        public AdminController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.Admini.Include(a => a.DanaLogowania);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Admin/Details/5
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

        // GET: Admin/Create
        public IActionResult Create()
        {
            ViewData["IDDanaLogowania"] = new SelectList(_context.DaneLogowania, "IDDanaLogowania", "Email");
            return View();
        }

        // POST: Admin/Create
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

        // GET: Admin/Edit/5
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

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
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

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Admini == null)
            {
                return Problem("Entity set 'LibraryContext.Admini'  is null.");
            }
            var admin = await _context.Admini.FindAsync(id);
            var user = User.FindFirst("UserID");
            if (admin != null && user != null)
            {
                if(user.Value != id.ToString())
                    _context.Admini.Remove(admin);
                else
                    return RedirectToAction(nameof(Index));
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
