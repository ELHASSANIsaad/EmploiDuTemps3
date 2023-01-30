using System.ComponentModel.DataAnnotations;

namespace EmploiDuTemps.Models
{
    public class Salle
    {
        [Key]
        public string nameId { get; set; }

        public string capacite { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;

        public string type { get; set; } = string.Empty;

        public string hasEmploi { get; set; } = string.Empty;  // default no

    }
}
