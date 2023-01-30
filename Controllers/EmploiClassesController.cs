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
    public class EmploiClassesController : Controller
    {
        private readonly DataContext _context;

        public EmploiClassesController(DataContext context)
        {
            _context = context;
        }

        // GET: EmploiClasses
        public async Task<IActionResult> Index()
        {
              return View(await _context.EmploiClasses.ToListAsync());
        }

        // GET: EmploiClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmploiClasses == null)
            {
                return NotFound();
            }

            var emploiClasse = await _context.EmploiClasses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emploiClasse == null)
            {
                return NotFound();
            }

            return View(emploiClasse);
        }

        // GET: EmploiClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmploiClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,classe,jour,creno,matier,prof,salle,etat")] EmploiClasse emploiClasse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emploiClasse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emploiClasse);
        }

        // GET: EmploiClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmploiClasses == null)
            {
                return NotFound();
            }

            var emploiClasse = await _context.EmploiClasses.FindAsync(id);
            if (emploiClasse == null)
            {
                return NotFound();
            }
            return View(emploiClasse);
        }

        // POST: EmploiClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,classe,jour,creno,matier,prof,salle,etat")] EmploiClasse emploiClasse)
        {
            if (id != emploiClasse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emploiClasse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmploiClasseExists(emploiClasse.Id))
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
            return View(emploiClasse);
        }

        // GET: EmploiClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmploiClasses == null)
            {
                return NotFound();
            }

            var emploiClasse = await _context.EmploiClasses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emploiClasse == null)
            {
                return NotFound();
            }

            return View(emploiClasse);
        }

        // POST: EmploiClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmploiClasses == null)
            {
                return Problem("Entity set 'DataContext.EmploiClasses'  is null.");
            }
            var emploiClasse = await _context.EmploiClasses.FindAsync(id);
            if (emploiClasse != null)
            {
                _context.EmploiClasses.Remove(emploiClasse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmploiClasseExists(int id)
        {
          return _context.EmploiClasses.Any(e => e.Id == id);
        }
    }
}
