using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmploiDuTemps.Models
{
    public class EmploiClasse
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string classe { get; set; } = string.Empty;

        public string jour { get; set; } = string.Empty;
        public string creno { get; set; } = string.Empty;   // 4 for each creno
        public string matier { get; set; } = string.Empty;  // 4 for each creno
        public string prof { get; set; } = string.Empty;    // 4 for each creno
        public string salle { get; set; } = string.Empty;   // 4 for each creno

        public string etat { get; set; } = string.Empty;   // busy empty



    }
}
