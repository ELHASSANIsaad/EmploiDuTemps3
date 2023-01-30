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
    public class EmploiSallesController : Controller
    {
        private readonly DataContext _context;

        public EmploiSallesController(DataContext context)
        {
            _context = context;
        }

        // GET: EmploiSalles
        public async Task<IActionResult> Index()
        {
              return View(await _context.EmploiSalles.ToListAsync());
        }

        // GET: EmploiSalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmploiSalles == null)
            {
                return NotFound();
            }

            var emploiSalle = await _context.EmploiSalles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emploiSalle == null)
            {
                return NotFound();
            }

            return View(emploiSalle);
        }

        // GET: EmploiSalles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmploiSalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,salle,jour,creno,matier,prof,classe,etat")] EmploiSalle emploiSalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emploiSalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emploiSalle);
        }

        // GET: EmploiSalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmploiSalles == null)
            {
                return NotFound();
            }

            var emploiSalle = await _context.EmploiSalles.FindAsync(id);
            if (emploiSalle == null)
            {
                return NotFound();
            }
            return View(emploiSalle);
        }

        // POST: EmploiSalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,salle,jour,creno,matier,prof,classe,etat")] EmploiSalle emploiSalle)
        {
            if (id != emploiSalle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emploiSalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmploiSalleExists(emploiSalle.Id))
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
            return View(emploiSalle);
        }

        // GET: EmploiSalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmploiSalles == null)
            {
                return NotFound();
            }

            var emploiSalle = await _context.EmploiSalles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emploiSalle == null)
            {
                return NotFound();
            }

            return View(emploiSalle);
        }

        // POST: EmploiSalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmploiSalles == null)
            {
                return Problem("Entity set 'DataContext.EmploiSalles'  is null.");
            }
            var emploiSalle = await _context.EmploiSalles.FindAsync(id);
            if (emploiSalle != null)
            {
                _context.EmploiSalles.Remove(emploiSalle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmploiSalleExists(int id)
        {
          return _context.EmploiSalles.Any(e => e.Id == id);
        }
    }
}
