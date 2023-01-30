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
    public class SalleEmploisController : Controller
    {
        private readonly DataContext _context;

        public SalleEmploisController(DataContext context)
        {
            _context = context;
        }

        // GET: SalleEmplois
        public async Task<IActionResult> Index()
        {
              return View(await _context.SalleEmplois.ToListAsync());
        }

        // GET: SalleEmplois/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.SalleEmplois == null)
            {
                return NotFound();
            }

            var salleEmploi = await _context.SalleEmplois
                .FirstOrDefaultAsync(m => m.salleEmploiId == id);
            if (salleEmploi == null)
            {
                return NotFound();
            }

            return View(salleEmploi);
        }

        // GET: SalleEmplois/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalleEmplois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("salleEmploiId,salle,jour,creno,matier,prof,classe,etat")] SalleEmploi salleEmploi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salleEmploi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salleEmploi);
        }

        // GET: SalleEmplois/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.SalleEmplois == null)
            {
                return NotFound();
            }

            var salleEmploi = await _context.SalleEmplois.FindAsync(id);
            if (salleEmploi == null)
            {
                return NotFound();
            }
            return View(salleEmploi);
        }

        // POST: SalleEmplois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("salleEmploiId,salle,jour,creno,matier,prof,classe,etat")] SalleEmploi salleEmploi)
        {
            if (id != salleEmploi.salleEmploiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salleEmploi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalleEmploiExists(salleEmploi.salleEmploiId))
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
            return View(salleEmploi);
        }

        // GET: SalleEmplois/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.SalleEmplois == null)
            {
                return NotFound();
            }

            var salleEmploi = await _context.SalleEmplois
                .FirstOrDefaultAsync(m => m.salleEmploiId == id);
            if (salleEmploi == null)
            {
                return NotFound();
            }

            return View(salleEmploi);
        }

        // POST: SalleEmplois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.SalleEmplois == null)
            {
                return Problem("Entity set 'DataContext.SalleEmplois'  is null.");
            }
            var salleEmploi = await _context.SalleEmplois.FindAsync(id);
            if (salleEmploi != null)
            {
                _context.SalleEmplois.Remove(salleEmploi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalleEmploiExists(string id)
        {
          return _context.SalleEmplois.Any(e => e.salleEmploiId == id);
        }
    }
}
