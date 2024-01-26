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

namespace Library_project.Controllers;

public class AdresController : Controller
{
    private readonly LibraryContext _context;

    public AdresController(LibraryContext context)
    {
        _context = context;
    }

    // GET: Adres
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Index()
    {
        var libraryContext = _context.Adresy.Include(a => a.Ulica);
        return View(await libraryContext.ToListAsync());
    }

    // GET: Adres/Details/5
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null || _context.Adresy == null)
        {
            return NotFound();
        }

        var adres = await _context.Adresy
            .Include(a => a.Ulica)
            .FirstOrDefaultAsync(m => m.IDAdres == id);
        if (adres == null)
        {
            return NotFound();
        }

        return View(adres);
    }

    // GET: Adres/Create
    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        ViewData["IDUlica"] = new SelectList(_context.Ulice, "IDUlica", "IDUlica");
        return View();
    }

    // POST: Adres/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([Bind("IDAdres,IDUlica,NumerBudynku,NumerMieszkania")] Adres adres)
    {
        if (ModelState.IsValid)
        {
            adres.IDAdres = Guid.NewGuid();
            _context.Add(adres);
            await _context.SaveChangesAsync();
            return RedirectToAction("Create", "DanaOsobowas");
        }
        ViewData["IDUlica"] = new SelectList(_context.Ulice, "IDUlica", "IDUlica", adres.IDUlica);
        return View(adres);
    }

    // GET: Adres/Edit/5
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null || _context.Adresy == null)
        {
            return NotFound();
        }

        var adres = await _context.Adresy.FindAsync(id);
        if (adres == null)
        {
            return NotFound();
        }
        ViewData["IDUlica"] = new SelectList(_context.Ulice, "IDUlica", "IDUlica", adres.IDUlica);
        return View(adres);
    }

    // POST: Adres/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "Admin, Bibliotekarz")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("IDAdres,IDUlica,NumerBudynku,NumerMieszkania")] Adres adres)
    {
        if (id != adres.IDAdres)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(adres);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdresExists(adres.IDAdres))
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
        ViewData["IDUlica"] = new SelectList(_context.Ulice, "IDUlica", "IDUlica", adres.IDUlica);
        return View(adres);
    }

    // GET: Adres/Delete/5
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null || _context.Adresy == null)
        {
            return NotFound();
        }

        var adres = await _context.Adresy
            .Include(a => a.Ulica)
            .FirstOrDefaultAsync(m => m.IDAdres == id);
        if (adres == null)
        {
            return NotFound();
        }

        return View(adres);
    }

    // POST: Adres/Delete/5
    [Authorize(Roles = "Admin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        if (_context.Adresy == null)
        {
            return Problem("Entity set 'LibraryContext.Adresy'  is null.");
        }
        var adres = await _context.Adresy.FindAsync(id);
        if (adres != null)
        {
            _context.Adresy.Remove(adres);
        }
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AdresExists(Guid id)
    {
      return (_context.Adresy?.Any(e => e.IDAdres == id)).GetValueOrDefault();
    }
}
