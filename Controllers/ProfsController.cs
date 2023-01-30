using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmploiDuTemps.Data;
using EmploiDuTemps.Models;

namespace EmploiDuTemps.Controllers
{
    public class ProfsController : Controller
    {
        private readonly DataContext _context;

        public ProfsController(DataContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        // GET: Profs
        public async Task<IActionResult> Index()
        {
              return View(await _context.Profs.ToListAsync());
        }

        // GET: Profs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Profs == null)
            {
                return NotFound();
            }

            var prof = await _context.Profs
                .FirstOrDefaultAsync(m => m.cinId == id);
            if (prof == null)
            {
                return NotFound();
            }

            return View(prof);
        }

        // GET: Profs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cinId,userName,nom,prenom,informtion,hasEmploi")] Prof prof)
        {

            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            if (ModelState.IsValid)
            {
                _context.Add(prof);
                await _context.SaveChangesAsync();

                // create initial emploi for this prof

                CreateEmploiProf(prof.userName);

                //
                //return RedirectToAction(nameof(Index));
            }

            return View(prof);
        }

        // create prof emploi called after each prof creation

        public void CreateEmploiProf(String profName)
        {

            ProfEmploi emploiProf = new ProfEmploi();

            //var varMaxId = _context.EmploiProfs.Max(p => p.Id);

            //TurnIdentityInsertOn("EmploiProfs");

            //int maxId = _context.ProfEmplois.Max(p => p.profEmploiId);

            string[] jours = new string[5] { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi" };

            string[] creno = new string[4] { "09:00 - 10:30", "11:00 - 12:30", "14:00 - 15:30", "16:00 - 17:30" };

            for (int i = 0; i <= 4; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    emploiProf.profEmploiId = profName + i.ToString() + j.ToString();
                    emploiProf.prof = profName;
                    emploiProf.jour = jours[i];
                    emploiProf.creno = creno[j];
                    emploiProf.salle = "";
                    emploiProf.classe = "";
                    emploiProf.matier = "";
                    emploiProf.etat = "empty";


                    _context.Add(emploiProf);
                    _context.SaveChanges();

                }

            }
            return;

        }
        public void TurnIdentityInsertOn(string tableName)
        {
            string command = $"SET IDENTITY_INSERT {tableName} ON";
            _context.Database.ExecuteSqlRaw(command);
        }


        // GET: Profs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Profs == null)
            {
                return NotFound();
            }

            var prof = await _context.Profs.FindAsync(id);
            if (prof == null)
            {
                return NotFound();
            }
            return View(prof);
        }

        // POST: Profs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("cinId,userName,nom,prenom,informtion,hasEmploi")] Prof prof)
        {
            if (id != prof.cinId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prof);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfExists(prof.cinId))
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
            return View(prof);
        }

        // GET: Profs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Profs == null)
            {
                return NotFound();
            }

            var prof = await _context.Profs
                .FirstOrDefaultAsync(m => m.cinId == id);
            if (prof == null)
            {
                return NotFound();
            }

            return View(prof);
        }

        // POST: Profs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Profs == null)
            {
                return Problem("Entity set 'DataContext.Profs'  is null.");
            }
            var prof = await _context.Profs.FindAsync(id);
            if (prof != null)
            {
                _context.Profs.Remove(prof);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfExists(string id)
        {
          return _context.Profs.Any(e => e.cinId == id);
        }
    }
}
