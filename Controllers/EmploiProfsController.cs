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
    public class EmploiProfsController : Controller
    {
        private readonly DataContext _context;

        public EmploiProfsController(DataContext context)
        {
            _context = context;
        }

        // GET: EmploiProfs
        public async Task<IActionResult> Index()
        {
              return View(await _context.EmploiProfs.ToListAsync());
        }

        // GET: EmploiProfs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmploiProfs == null)
            {
                return NotFound();
            }

            var emploiProf = await _context.EmploiProfs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emploiProf == null)
            {
                return NotFound();
            }

            return View(emploiProf);
        }

        // GET: EmploiProfs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmploiProfs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,prof,jour,creno,matier,salle,classe,etat")] EmploiProf emploiProf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emploiProf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emploiProf);
        }



        // GET: EmploiProfs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmploiProfs == null)
            {
                return NotFound();
            }

            var emploiProf = await _context.EmploiProfs.FindAsync(id);
            if (emploiProf == null)
            {
                return NotFound();
            }
            return View(emploiProf);
        }

        // POST: EmploiProfs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,prof,jour,creno,matier,salle,classe,etat")] EmploiProf emploiProf)
        {
            if (id != emploiProf.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emploiProf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmploiProfExists(emploiProf.Id))
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
            return View(emploiProf);
        }

        



        // GET: EmploiProfs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmploiProfs == null)
            {
                return NotFound();
            }

            var emploiProf = await _context.EmploiProfs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emploiProf == null)
            {
                return NotFound();
            }

            return View(emploiProf);
        }

        // POST: EmploiProfs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmploiProfs == null)
            {
                return Problem("Entity set 'DataContext.EmploiProfs'  is null.");
            }
            var emploiProf = await _context.EmploiProfs.FindAsync(id);
            if (emploiProf != null)
            {
                _context.EmploiProfs.Remove(emploiProf);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmploiProfExists(int id)
        {
          return _context.EmploiProfs.Any(e => e.Id == id);
        }
    }
}
