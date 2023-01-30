using System.ComponentModel.DataAnnotations;

namespace EmploiDuTemps.Models
{
    public class SalleEmploi
    {
        [Key]
        public string salleEmploiId { get; set; }

        public string salle { get; set; } = string.Empty;

        public string jour { get; set; } = string.Empty;
        public string creno { get; set; } = string.Empty;

        public string matier { get; set; } = string.Empty;  // 4 for each creno
        public string prof { get; set; } = string.Empty;    // 4 for each creno

        public string classe { get; set; } = string.Empty;

        public string etat { get; set; } = string.Empty;   // full empty

    }
}
