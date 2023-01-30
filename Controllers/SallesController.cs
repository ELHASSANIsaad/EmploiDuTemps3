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
    public class SallesController : Controller
    {
        private readonly DataContext _context;

        public SallesController(DataContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        // GET: Salles
        public async Task<IActionResult> Index()
        {
              return View(await _context.Salles.ToListAsync());
        }

        // GET: Salles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Salles == null)
            {
                return NotFound();
            }

            var salle = await _context.Salles
                .FirstOrDefaultAsync(m => m.nameId == id);
            if (salle == null)
            {
                return NotFound();
            }

            return View(salle);
        }

        // GET: Salles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nameId,capacite,description,type,hasEmploi")] Salle salle)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            if (ModelState.IsValid)
            {
                _context.Add(salle);
                await _context.SaveChangesAsync();


                // create empty eploi for the classe once created

                CreateEmploiSalle(salle.nameId);


                return RedirectToAction(nameof(Index));
            }
            return View(salle);
        }


        public void CreateEmploiSalle(String saleName)
        {

            SalleEmploi emploiSalle = new SalleEmploi();


            string[] jours = new string[5] { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi" };

            string[] creno = new string[4] { "09:00 - 10:30", "11:00 - 12:30", "14:00 - 15:30", "16:00 - 17:30" };

            for (int i = 0; i <= 4; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    emploiSalle.salleEmploiId = saleName + i.ToString() + j.ToString();
                    emploiSalle.salle = saleName;
                    emploiSalle.jour = jours[i];
                    emploiSalle.creno = creno[j];
                    emploiSalle.prof = "";
                    emploiSalle.classe = "";
                    emploiSalle.matier = "";
                    emploiSalle.etat = "empty";


                    _context.Add(emploiSalle);
                    _context.SaveChanges();

                }

            }

            return;


        }



        // GET: Salles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Salles == null)
            {
                return NotFound();
            }

            var salle = await _context.Salles.FindAsync(id);
            if (salle == null)
            {
                return NotFound();
            }
            return View(salle);
        }

        // POST: Salles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("nameId,capacite,description,type,hasEmploi")] Salle salle)
        {
            if (id != salle.nameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalleExists(salle.nameId))
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
            return View(salle);
        }

        // GET: Salles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Salles == null)
            {
                return NotFound();
            }

            var salle = await _context.Salles
                .FirstOrDefaultAsync(m => m.nameId == id);
            if (salle == null)
            {
                return NotFound();
            }

            return View(salle);
        }

        // POST: Salles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Salles == null)
            {
                return Problem("Entity set 'DataContext.Salles'  is null.");
            }
            var salle = await _context.Salles.FindAsync(id);
            if (salle != null)
            {
                _context.Salles.Remove(salle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalleExists(string id)
        {
          return _context.Salles.Any(e => e.nameId == id);
        }
    }
}
