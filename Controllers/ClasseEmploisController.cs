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
    public class ClasseEmploisController : Controller
    {
        private readonly DataContext _context;

        public ClasseEmploisController(DataContext context)
        {
            _context = context;
        }

        // GET: ClasseEmplois
        public async Task<IActionResult> Index()
        {
              return View(await _context.ClasseEmplois.ToListAsync());
        }

        // GET: ClasseEmplois/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ClasseEmplois == null)
            {
                return NotFound();
            }

            var classeEmploi = await _context.ClasseEmplois
                .FirstOrDefaultAsync(m => m.classeEmploiId == id);
            if (classeEmploi == null)
            {
                return NotFound();
            }

            return View(classeEmploi);
        }

        // GET: ClasseEmplois/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClasseEmplois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("classeEmploiId,classe,jour,creno,matier,prof,salle,etat")] ClasseEmploi classeEmploi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classeEmploi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classeEmploi);
        }

        // GET: ClasseEmplois/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ClasseEmplois == null)
            {
                return NotFound();
            }

            var classeEmploi = await _context.ClasseEmplois.FindAsync(id);
            if (classeEmploi == null)
            {
                return NotFound();
            }
            return View(classeEmploi);
        }

        // POST: ClasseEmplois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("classeEmploiId,classe,jour,creno,matier,prof,salle,etat")] ClasseEmploi classeEmploi)
        {
            if (id != classeEmploi.classeEmploiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classeEmploi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasseEmploiExists(classeEmploi.classeEmploiId))
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
            return View(classeEmploi);
        }

        // GET: ClasseEmplois/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ClasseEmplois == null)
            {
                return NotFound();
            }

            var classeEmploi = await _context.ClasseEmplois
                .FirstOrDefaultAsync(m => m.classeEmploiId == id);
            if (classeEmploi == null)
            {
                return NotFound();
            }

            return View(classeEmploi);
        }

        // POST: ClasseEmplois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ClasseEmplois == null)
            {
                return Problem("Entity set 'DataContext.ClasseEmplois'  is null.");
            }
            var classeEmploi = await _context.ClasseEmplois.FindAsync(id);
            if (classeEmploi != null)
            {
                _context.ClasseEmplois.Remove(classeEmploi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasseEmploiExists(string id)
        {
          return _context.ClasseEmplois.Any(e => e.classeEmploiId == id);
        }
    }
}
