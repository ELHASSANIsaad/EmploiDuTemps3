using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmploiDuTemps.Data;
using EmploiDuTemps.Models;

namespace EmploiDuTemps.Controllers
{
    public class FilliersController : Controller
    {
        private readonly DataContext _context;

        public FilliersController(DataContext context)
        {
            _context = context;
        }

        // GET: Filliers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Filliers.ToListAsync());
        }

        // GET: Filliers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Filliers == null)
            {
                return NotFound();
            }

            var fillier = await _context.Filliers
                .FirstOrDefaultAsync(m => m.NameId == id);
            if (fillier == null)
            {
                return NotFound();
            }

            return View(fillier);
        }

        // GET: Filliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NameId,designation,description")] Fillier fillier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fillier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fillier);
        }

        // GET: Filliers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Filliers == null)
            {
                return NotFound();
            }

            var fillier = await _context.Filliers.FindAsync(id);
            if (fillier == null)
            {
                return NotFound();
            }
            return View(fillier);
        }

        // POST: Filliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NameId,designation,description")] Fillier fillier)
        {
            if (id != fillier.NameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fillier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FillierExists(fillier.NameId))
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
            return View(fillier);
        }

        // GET: Filliers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Filliers == null)
            {
                return NotFound();
            }

            var fillier = await _context.Filliers
                .FirstOrDefaultAsync(m => m.NameId == id);
            if (fillier == null)
            {
                return NotFound();
            }

            return View(fillier);
        }

        // POST: Filliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Filliers == null)
            {
                return Problem("Entity set 'DataContext.Filliers'  is null.");
            }
            var fillier = await _context.Filliers.FindAsync(id);
            if (fillier != null)
            {
                _context.Filliers.Remove(fillier);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FillierExists(string id)
        {
          return _context.Filliers.Any(e => e.NameId == id);
        }
    }
}
