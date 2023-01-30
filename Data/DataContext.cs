using EmploiDuTemps.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;



namespace EmploiDuTemps.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Fillier> Filliers { get; set; }

        public DbSet<Classe> Classes { get; set; }

        public DbSet<Etudiant> Etudiants { get; set; }

        public DbSet<Matier> Matiers { get; set; }

        public DbSet<Prof> Profs { get; set; }

        public DbSet<Salle> Salles { get; set; }

        public DbSet<ClasseMatierProf> ClasseMatierProfs { get; set; }

        //emploi

        public DbSet<ProfEmploi> ProfEmplois { get; set; }

        public DbSet<SalleEmploi> SalleEmplois { get; set; }

        public DbSet<ClasseEmploi> ClasseEmplois { get; set; }

        // trash not used, no longer

        public DbSet<EmploiClasse> EmploiClasses { get; set; }

        public DbSet<EmploiProf> EmploiProfs { get; set; }

        public DbSet<EmploiSalle> EmploiSalles { get; set; }
    }
}
