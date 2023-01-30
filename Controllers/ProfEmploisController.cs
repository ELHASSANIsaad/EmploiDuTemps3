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
    public class ProfEmploisController : Controller
    {
        private readonly DataContext _context;

        public ProfEmploisController(DataContext context)
        {
            _context = context;
        }

        // GET: ProfEmplois
        public async Task<IActionResult> Index()
        {
              return View(await _context.ProfEmplois.ToListAsync());
        }

        // GET: ProfEmplois/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ProfEmplois == null)
            {
                return NotFound();
            }

            var profEmploi = await _context.ProfEmplois
                .FirstOrDefaultAsync(m => m.profEmploiId == id);
            if (profEmploi == null)
            {
                return NotFound();
            }

            return View(profEmploi);
        }

        // GET: ProfEmplois/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfEmplois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("profEmploiId,prof,jour,creno,matier,salle,classe,etat")] ProfEmploi profEmploi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profEmploi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profEmploi);
        }

        // GET: ProfEmplois/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ProfEmplois == null)
            {
                return NotFound();
            }

            var profEmploi = await _context.ProfEmplois.FindAsync(id);
            if (profEmploi == null)
            {
                return NotFound();
            }
            return View(profEmploi);
        }

        // POST: ProfEmplois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("profEmploiId,prof,jour,creno,matier,salle,classe,etat")] ProfEmploi profEmploi)
        {
            if (id != profEmploi.profEmploiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profEmploi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfEmploiExists(profEmploi.profEmploiId))
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
            return View(profEmploi);
        }

        // GET: ProfEmplois/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ProfEmplois == null)
            {
                return NotFound();
            }

            var profEmploi = await _context.ProfEmplois
                .FirstOrDefaultAsync(m => m.profEmploiId == id);
            if (profEmploi == null)
            {
                return NotFound();
            }

            return View(profEmploi);
        }

        // POST: ProfEmplois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ProfEmplois == null)
            {
                return Problem("Entity set 'DataContext.ProfEmplois'  is null.");
            }
            var profEmploi = await _context.ProfEmplois.FindAsync(id);
            if (profEmploi != null)
            {
                _context.ProfEmplois.Remove(profEmploi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfEmploiExists(string id)
        {
          return _context.ProfEmplois.Any(e => e.profEmploiId == id);
        }
    }
}
