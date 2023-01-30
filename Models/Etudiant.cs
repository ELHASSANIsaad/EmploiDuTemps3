using System.ComponentModel.DataAnnotations;

namespace EmploiDuTemps.Models
{
    public class Etudiant
    {

        [Key]
        public string cneId { get; set; }

        public string userName { get; set; } = string.Empty;

        public string nom { get; set; } = string.Empty;

        public string prenom { get; set; } = string.Empty;

        public string informtion { get; set; } = string.Empty;


        //
        public string ClasseId { get; set; }      // NameId

        public Classe? Classe { get; set; }



    }
}
