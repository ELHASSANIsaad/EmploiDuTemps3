using System.ComponentModel.DataAnnotations;

namespace EmploiDuTemps.Models
{
    public class Classe
    {
        [Key]
        public string NameId { get; set; }

        public string description { get; set; } = string.Empty;

        public string nbrEtudiant { get; set; } = string.Empty;

        public string hasEmploi { get; set; } = string.Empty;  // default no

        //
        public string FillierId { get; set; }    // NameIds

        public Fillier? Fillier { get; set; }
    }
}
