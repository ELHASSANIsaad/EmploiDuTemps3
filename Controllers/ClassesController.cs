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
    public class ClassesController : Controller
    {
        private readonly DataContext _context;

        public ClassesController(DataContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        // GET: Classes
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Classes.Include(c => c.Fillier);
            return View(await dataContext.ToListAsync());
        }

        // GET: Classes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var classe = await _context.Classes
                .Include(c => c.Fillier)
                .FirstOrDefaultAsync(m => m.NameId == id);
            if (classe == null)
            {
                return NotFound();
            }

            return View(classe);
        }

        // GET: Classes/Create
        public IActionResult Create()
        {
            ViewData["FillierId"] = new SelectList(_context.Filliers, "NameId", "NameId");
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NameId,description,nbrEtudiant,hasEmploi,FillierId")] Classe classe)
        {

            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            if (ModelState.IsValid)
            {
                _context.Add(classe);
                await _context.SaveChangesAsync();

                CreateEmploiClasse(classe.NameId);

                return RedirectToAction(nameof(Index));
            }
            ViewData["FillierId"] = new SelectList(_context.Filliers, "NameId", "NameId", classe.FillierId);
            return View(classe);
        }


        public void CreateEmploiClasse(String classeName)
        {

            ClasseEmploi emploiClasse = new ClasseEmploi();


            string[] jours = new string[5] { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi" };

            string[] creno = new string[4] { "09:00 - 10:30", "11:00 - 12:30", "14:00 - 15:30", "16:00 - 17:30" };

            for (int i = 0; i <= 4; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    emploiClasse.classeEmploiId = classeName + i.ToString() + j.ToString();
                    emploiClasse.salle = "";
                    emploiClasse.jour = jours[i];
                    emploiClasse.creno = creno[j];
                    emploiClasse.prof = "";
                    emploiClasse.classe = classeName;
                    emploiClasse.matier = "";
                    emploiClasse.etat = "empty";


                    _context.Add(emploiClasse);
                    _context.SaveChanges();

                }

            }

            return;


        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var classe = await _context.Classes.FindAsync(id);
            if (classe == null)
            {
                return NotFound();
            }
            ViewData["FillierId"] = new SelectList(_context.Filliers, "NameId", "NameId", classe.FillierId);
            return View(classe);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NameId,description,nbrEtudiant,hasEmploi,FillierId")] Classe classe)
        {
            if (id != classe.NameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasseExists(classe.NameId))
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
            ViewData["FillierId"] = new SelectList(_context.Filliers, "NameId", "NameId", classe.FillierId);
            return View(classe);
        }

        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var classe = await _context.Classes
                .Include(c => c.Fillier)
                .FirstOrDefaultAsync(m => m.NameId == id);
            if (classe == null)
            {
                return NotFound();
            }

            return View(classe);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Classes == null)
            {
                return Problem("Entity set 'DataContext.Classes'  is null.");
            }
            var classe = await _context.Classes.FindAsync(id);
            if (classe != null)
            {
                _context.Classes.Remove(classe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasseExists(string id)
        {
          return _context.Classes.Any(e => e.NameId == id);
        }
    }
}
