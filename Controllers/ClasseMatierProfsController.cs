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
    public class ClasseMatierProfsController : Controller
    {
        private readonly DataContext _context;

        public ClasseMatierProfsController(DataContext context)
        {

            
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        // GET: ClasseMatierProfs
        public async Task<IActionResult> Index()
        {
              return View(await _context.ClasseMatierProfs.ToListAsync());
        }

        // GET: ClasseMatierProfs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ClasseMatierProfs == null)
            {
                return NotFound();
            }

            var classeMatierProf = await _context.ClasseMatierProfs
                .FirstOrDefaultAsync(m => m.nameId == id);
            if (classeMatierProf == null)
            {
                return NotFound();
            }

            return View(classeMatierProf);
        }

        // GET: ClasseMatierProfs/Create
        public IActionResult Create()
        {

            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //var viewModel = new ClasseMatierProf();
            //viewModel.Items = _context.Classes.Select(x => new SelectListItem
            //{
            //    Value = x.NameId.ToString(),
            //    Text = x.NameId.ToString()
            //}).ToList();
            //return View(viewModel);

            ViewData["classe"] = new SelectList(_context.Classes, "NameId", "NameId");
            ViewData["matier"] = new SelectList(_context.Matiers, "nameId", "nameId");
            ViewData["prof"] = new SelectList(_context.Profs, "userName", "userName");

            return View();
        }

        // POST: ClasseMatierProfs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nameId,classe,matier,prof")] ClasseMatierProf classeMatierProf)
        {

            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            if (ModelState.IsValid)
            {
                _context.Add(classeMatierProf);
                await _context.SaveChangesAsync();

                //       !!!!!!        PAY    ATTENTION      WARNING, Huge operation about to start...

                GenerateEplois(classeMatierProf);


                return RedirectToAction(nameof(Index));
            }
            ViewData["classe"] = new SelectList(_context.Classes, "NameId", "NameId", classeMatierProf.classe);
            ViewData["matier"] = new SelectList(_context.Matiers, "nameId", "nameId", classeMatierProf.matier);
            ViewData["prof"] = new SelectList(_context.Profs, "userName", "userName", classeMatierProf.prof);

           
            return View(classeMatierProf);
        }


        public void GenerateEplois(ClasseMatierProf classeMatierProf)
        {
            //controll
            int stopBocl = 10;

            int nbrSceance = 0;

            // class     //get cllase
            String myClasse = classeMatierProf.classe;
            var myClasseObject = _context.Classes.Where(b => b.NameId == myClasse).FirstOrDefault();
            var myClasseEmploiObject = _context.ClasseEmplois.Where(b => b.classe == myClasse).ToList();   // the 20 rows of emploi of the given teacher



            // matier     //get matier object for geting the Hour per week
            String myMaatier = classeMatierProf.matier;
            var myMaatierObject = _context.Matiers.Where(b => b.nameId == myMaatier).FirstOrDefault();

            float heurParSemain = (float)Convert.ToDouble(myMaatierObject.volumHoraireHs);
            // salle     //get the list of all Salles
            var allSalle = _context.Salles.ToList();

            // prof      //get emploi of that prof chosen above
            String myProf = classeMatierProf.prof;
            var myProfEmploiObject = _context.ProfEmplois.Where(b => b.prof == myProf).ToList();   // the 20 rows of emploi of the given teacher


            while (heurParSemain > 0)
            {
                if(stopBocl < 1) { break; }
                stopBocl--;

                //heurParSemain = heurParSemain - 1.5f;
                foreach(var salle in allSalle)     // parcour all salles
                {

                    // check for salle capacite
                    //salle  and   myClasseObject

                    float salleCapacity = (float)Convert.ToDouble(salle.capacite);
                    float classeNbrEtudiant = (float)Convert.ToDouble(myClasseObject.nbrEtudiant);

                    if (salleCapacity < classeNbrEtudiant)
                    {
                        continue;
                    }


                    //
                    var mySalleEmploiObject = _context.SalleEmplois.Where(b => b.salle == salle.nameId).ToList(); 

                    foreach(var salleCreno in mySalleEmploiObject)    // parcour all creno for one salle
                    {
                        if(salleCreno.etat == "empty")
                        {
                            // we dont want to have 3 sceance of same matier in less than 2 days, only if we don't have choice
                            if ((salleCreno.jour == "Lundi" || salleCreno.jour == "Mardi") && nbrSceance >= 2)
                            {
                                continue;
                            }



                            string jour = salleCreno.jour;
                            string creno = salleCreno.creno;

                            var profCreno = myProfEmploiObject.Where(b => b.jour == jour).ToList();
                            var profEmploiRow = profCreno.Where(b => b.creno == creno).FirstOrDefault();

                            if(profEmploiRow.etat == "empty")   
                            {

                                var classCreno = myClasseEmploiObject.Where(b => b.jour == jour).ToList();
                                var classeEmploiRow = classCreno.Where(b => b.creno == creno).FirstOrDefault();

                                if (classeEmploiRow.etat == "empty")
                                {


                                    _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                                    // start the insertion for 3 emploi:
                                    //          SALLE    UPDATE
                                    SalleEmploi salleEmploi = new SalleEmploi();

                                    salleEmploi.salleEmploiId = salleCreno.salleEmploiId;
                                    salleEmploi.salle = salle.nameId;
                                    salleEmploi.jour = jour;
                                    salleEmploi.creno = creno;
                                    salleEmploi.matier = myMaatierObject.nameId;
                                    salleEmploi.prof = profEmploiRow.prof;
                                    salleEmploi.classe = myClasseObject.NameId;
                                    salleEmploi.etat = "full";

                                    _context.Update(salleEmploi);
                                    _context.SaveChanges();

                                    //         PROF     UPDATE

                                    ProfEmploi profEmploi = new ProfEmploi();

                                    profEmploi.profEmploiId = profEmploiRow.profEmploiId;
                                    profEmploi.salle = salle.nameId;
                                    profEmploi.jour = jour;
                                    profEmploi.creno = creno;
                                    profEmploi.matier = myMaatierObject.nameId;
                                    profEmploi.prof = profEmploiRow.prof;
                                    profEmploi.classe = myClasseObject.NameId;
                                    profEmploi.etat = "full";

                                    _context.Update(profEmploi);
                                    _context.SaveChanges();


                                    //         Classe Emploi, the main one     update

                                    ClasseEmploi classeEmploi = new ClasseEmploi();

                                    classeEmploi.classeEmploiId = classeEmploiRow.classeEmploiId;
                                    classeEmploi.salle = salle.nameId;
                                    classeEmploi.jour = jour;
                                    classeEmploi.creno = creno;
                                    classeEmploi.matier = myMaatierObject.nameId;
                                    classeEmploi.prof = profEmploiRow.prof;
                                    classeEmploi.classe = myClasseObject.NameId;
                                    classeEmploi.etat = "full";

                                    _context.Update(classeEmploi);
                                    _context.SaveChanges();

                                    //
                                    heurParSemain = heurParSemain - 1.5f;
                                    nbrSceance++;

                                    if (heurParSemain <= 0) { break; }

                                }





                            }

                        }
                    }

                    if (heurParSemain <= 0) { break; }

                }


                if (heurParSemain <= 0) { break; }

            }

            if (heurParSemain <= 0) 
            {
                // affectation d'emploi successd
            }
            else
            {
                // affectation d'emploi Failed, Salles, or profs not enough
            }

            return;


        }



        // GET: ClasseMatierProfs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ClasseMatierProfs == null)
            {
                return NotFound();
            }

            var classeMatierProf = await _context.ClasseMatierProfs.FindAsync(id);
            if (classeMatierProf == null)
            {
                return NotFound();
            }
            ViewData["classe"] = new SelectList(_context.Classes, "NameId", "NameId", classeMatierProf.classe);
            ViewData["matier"] = new SelectList(_context.Matiers, "nameId", "nameId", classeMatierProf.matier);
            ViewData["prof"] = new SelectList(_context.Profs, "userName", "userName", classeMatierProf.prof);
            return View(classeMatierProf);
        }

        // POST: ClasseMatierProfs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("nameId,classe,matier,prof")] ClasseMatierProf classeMatierProf)
        {
            if (id != classeMatierProf.nameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classeMatierProf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasseMatierProfExists(classeMatierProf.nameId))
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
            ViewData["classe"] = new SelectList(_context.Classes, "NameId", "NameId", classeMatierProf.classe);
            ViewData["matier"] = new SelectList(_context.Matiers, "nameId", "nameId", classeMatierProf.matier);
            ViewData["prof"] = new SelectList(_context.Profs, "userName", "userName", classeMatierProf.prof);
            return View(classeMatierProf);
        }

        // GET: ClasseMatierProfs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ClasseMatierProfs == null)
            {
                return NotFound();
            }

            var classeMatierProf = await _context.ClasseMatierProfs
                .FirstOrDefaultAsync(m => m.nameId == id);
            if (classeMatierProf == null)
            {
                return NotFound();
            }

            return View(classeMatierProf);
        }

        // POST: ClasseMatierProfs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ClasseMatierProfs == null)
            {
                return Problem("Entity set 'DataContext.ClasseMatierProfs'  is null.");
            }
            var classeMatierProf = await _context.ClasseMatierProfs.FindAsync(id);
            if (classeMatierProf != null)
            {
                _context.ClasseMatierProfs.Remove(classeMatierProf);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasseMatierProfExists(string id)
        {
          return _context.ClasseMatierProfs.Any(e => e.nameId == id);
        }
    }
}
