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
    public class MatiersController : Controller
    {
        private readonly DataContext _context;

        public MatiersController(DataContext context)
        {
            _context = context;
        }

        // GET: Matiers
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Matiers.Include(m => m.Fillier);
            return View(await dataContext.ToListAsync());
        }

        // GET: Matiers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Matiers == null)
            {
                return NotFound();
            }

            var matier = await _context.Matiers
                .Include(m => m.Fillier)
                .FirstOrDefaultAsync(m => m.nameId == id);
            if (matier == null)
            {
                return NotFound();
            }

            return View(matier);
        }

        // GET: Matiers/Create
        public IActionResult Create()
        {
            ViewData["FillierId"] = new SelectList(_context.Filliers, "NameId", "NameId");
            return View();
        }

        // POST: Matiers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nameId,volumHoraireH,volumHoraireHs,type,FillierId")] Matier matier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FillierId"] = new SelectList(_context.Filliers, "NameId", "NameId", matier.FillierId);
            return View(matier);
        }

        // GET: Matiers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Matiers == null)
            {
                return NotFound();
            }

            var matier = await _context.Matiers.FindAsync(id);
            if (matier == null)
            {
                return NotFound();
            }
            ViewData["FillierId"] = new SelectList(_context.Filliers, "NameId", "NameId", matier.FillierId);
            return View(matier);
        }

        // POST: Matiers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("nameId,volumHoraireH,volumHoraireHs,type,FillierId")] Matier matier)
        {
            if (id != matier.nameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatierExists(matier.nameId))
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
            ViewData["FillierId"] = new SelectList(_context.Filliers, "NameId", "NameId", matier.FillierId);
            return View(matier);
        }

        // GET: Matiers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Matiers == null)
            {
                return NotFound();
            }

            var matier = await _context.Matiers
                .Include(m => m.Fillier)
                .FirstOrDefaultAsync(m => m.nameId == id);
            if (matier == null)
            {
                return NotFound();
            }

            return View(matier);
        }

        // POST: Matiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Matiers == null)
            {
                return Problem("Entity set 'DataContext.Matiers'  is null.");
            }
            var matier = await _context.Matiers.FindAsync(id);
            if (matier != null)
            {
                _context.Matiers.Remove(matier);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatierExists(string id)
        {
          return _context.Matiers.Any(e => e.nameId == id);
        }
    }
}
